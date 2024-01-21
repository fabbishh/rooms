// BathroomFilter.tsx
import React, { useEffect, useState } from 'react';
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';
import AttributeFilter from '../../ui/AttributeFilter';

interface BathroomFilterProps {
	selectedBathrooms: any[];
	onBathroomChange: (selectedBathrooms: any[]) => void;
}

const BathroomFilter: React.FC<BathroomFilterProps> = ({ selectedBathrooms, onBathroomChange }) => {
	const [bathOptions, setBathOptions] = useState<any[]>([]);

	useEffect(() => {
		const fetchData = async () => {
			try {
				var response = await api.get("/attribute/room-bathroom")

				const validAttributes = response.data.map((attribute: any) => {
					const isActive = selectedBathrooms.find(value => value.id === attribute.id)?.isActive || false;
					return { id: attribute.id, name: attribute.name, isActive: isActive }
				});
				setBathOptions(validAttributes);

			} catch (error: any) {
				showNotification("Ошибка", error.message);
			}
		}

		fetchData();
	}, [])

	const handleBathroomChange = (attributes: any) => {
		setBathOptions(attributes);
		onBathroomChange(attributes.filter((a: any) => a.isActive === true));
	};

	return (
		<>
			<AttributeFilter options={bathOptions} onOptionsChange={handleBathroomChange} title="Санузел"/>
		</>
	);
};

export default BathroomFilter;
