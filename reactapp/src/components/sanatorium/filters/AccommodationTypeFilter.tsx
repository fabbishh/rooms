// AccommodationTypeFilter.tsx
import React, { useEffect, useState } from 'react';
import AttributeFilter from '../../ui/AttributeFilter';

interface AccommodationTypeFilterProps {
  selectedTypes: any[];
  onTypeChange: (selectedTypes: string[]) => void;
}

const AccommodationTypeFilter: React.FC<AccommodationTypeFilterProps> = ({ selectedTypes, onTypeChange }) => {
  const [accommodationTypes, setTypes] = useState<any[]>([]);

  useEffect(() => {
    const types = [{id: 0, name: 'Номер'}, { id: 1, name: 'Отдельное жилье' }];
    
		const validAttributes = types?.map((attribute: any) => {
			const isActive = selectedTypes.find(value => value.id === attribute.id)?.isActive || false;
			return { id: attribute.id, name: attribute.name, isActive: isActive }
		});
		setTypes(validAttributes);
	}, [])

	const handleChange = (attributes: any) => {
		setTypes(attributes);
		onTypeChange(attributes.filter((a: any) => a.isActive === true));
	};

	return (
		<>
			<AttributeFilter options={accommodationTypes} onOptionsChange={handleChange} title="Тип проживания" />
		</>
	);
};

export default AccommodationTypeFilter;
