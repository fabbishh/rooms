// ComfortOnSiteFilter.tsx
import React, { useEffect, useState } from 'react';
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';
import { Attribute } from '../../../shared/app.interfaces';
import AttributeFilter from '../../ui/AttributeFilter';

interface ComfortOnSiteFilterProps {
	onValuesChange: (selectedValues: Attribute[]) => void;
	selectedValues: Attribute[];
}

const ComfortOnSiteFilter: React.FC<ComfortOnSiteFilterProps> = ({ onValuesChange, selectedValues }) => {
	const [comfortOptions, setComfortOptions] = useState<Attribute[]>([]);

	useEffect(() => {
		const fetchData = async () => {
			try {
				var response = await api.get("/attribute/sanatorium-comfort")

				const validAttributes = response.data.map((attribute: any) => {
					const isActive = selectedValues.find(value => value.id === attribute.id)?.isActive || false;
					return { id: attribute.id, name: attribute.name, isActive: isActive }
				});
				setComfortOptions(validAttributes);

			} catch (error: any) {
				showNotification("Ошибка", error.message);
			}
		}

		fetchData();
	}, [])

	const handleComfortChange = (attributes: Attribute[]) => {
		setComfortOptions(attributes);
		onValuesChange(attributes.filter(a => a.isActive === true));
	};

	return (
		<>
			<AttributeFilter options={comfortOptions} onOptionsChange={handleComfortChange} title="Комфорт на территории"/>
		</>
	);
};

export default ComfortOnSiteFilter;
