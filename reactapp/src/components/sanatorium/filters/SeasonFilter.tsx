// SeasonFilter.tsx
import React, { useEffect, useState } from 'react';
import { getSanatoriumSeasonOptions } from '../../../services/api/sanatoriumSeasons';
import api from '../../../services/api/api';
import AttributeFilter from '../../ui/AttributeFilter';

interface SeasonFilterProps {
	selectedSeasons: any[];
	onSeasonChange: (selectedSeasons: any[]) => void;
}

const SeasonFilter: React.FC<SeasonFilterProps> = ({ selectedSeasons, onSeasonChange }) => {
	const [seasons, setSeasons] = useState<any[]>([]);

	useEffect(() => {
		const attributes = getSanatoriumSeasonOptions();
		const validAttributes = attributes?.map((attribute: any) => {
			const isActive = selectedSeasons.find(value => value.id === attribute.value)?.isActive || false;
			return { id: attribute.value, name: attribute.label, isActive: isActive }
		});
		setSeasons(validAttributes);
	}, [])

	const handleChange = (attributes: any) => {
		setSeasons(attributes);
		onSeasonChange(attributes.filter((a: any) => a.isActive === true));
	};

	return (
		<>
			<AttributeFilter options={seasons} onOptionsChange={handleChange} title="Сезоны" />
		</>
	);
};

export default SeasonFilter;
