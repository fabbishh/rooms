// MealFilter.tsx
import React, { useEffect, useState } from 'react';
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';
import AttributeFilter from '../../ui/AttributeFilter';

interface MealFilterProps {
	selectedMeals: any[];
	onMealChange: (selectedMeals: any[]) => void;
}

const MealFilter: React.FC<MealFilterProps> = ({ selectedMeals, onMealChange }) => {
	const [mealOptions, setMealOptions] = useState<any[]>([]);

	useEffect(() => {
		const fetchData = async () => {
			try {
				var response = await api.get("/attribute/room-food")

				const validAttributes = response.data.map((attribute: any) => {
					const isActive = selectedMeals.find(value => value.id === attribute.id)?.isActive || false;
					return { id: attribute.id, name: attribute.name, isActive: isActive }
				});
				setMealOptions(validAttributes);
			} catch (error: any) {
				showNotification("Ошибка", error.message);
			}
		}

		fetchData();
	}, [])

	const handleChange = (attributes: any) => {
		setMealOptions(attributes);
		onMealChange(attributes.filter((a: any) => a.isActive === true));
	};

	return (
		<>
			<AttributeFilter options={mealOptions} onOptionsChange={handleChange} title="Питание" />
		</>
	);
};

export default MealFilter;
