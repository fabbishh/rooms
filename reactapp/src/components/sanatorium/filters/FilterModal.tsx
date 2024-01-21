import React, { useState } from 'react';
import { Button, Modal } from 'flowbite-react';

import SeasonFilter from './SeasonFilter';
import MealFilter from './MealFilter';
import BedroomCountFilter from './BedroomCountFilter';
import BathroomFilter from './BathroomFilter';
import ComfortOnSiteFilter from './ComfortOnSiteFilter';
import AccommodationTypeFilter from './AccommodationTypeFilter';
import ServiceFilter from './ServiceFilter';
import PriceRangeFilter from './PriceRangeFilter';
import { Attribute, SanatoriumFilter } from '../../../shared/app.interfaces';

type Props = {
	onFilterApply: (filter: SanatoriumFilter) => void;
}

const FilterModal: React.FC<Props> = ({ onFilterApply }) => {
	const [openModal, setOpenModal] = useState(false);
	const [selectedSeasons, setSelectedSeasons] = useState<any[]>([]);
	const [selectedMeals, setSelectedMeals] = useState<any[]>([]);
	const [selectedCounts, setSelectedCounts] = useState<number[]>([]);
	const [selectedBathrooms, setSelectedBathrooms] = useState<any[]>([]);
	const [selectedComforts, setSelectedComforts] = useState<Attribute[]>([]);
	const [selectedServices, setSelectedServices] = useState<Attribute[]>([]);
	const [selectedPriceRange, setSelectedPriceRange] = useState<number[]>([0, 100000]);
	const [selectedAccomodationTypes, setSelectedAccomodationTypes] = useState<any[]>([]);

	const handleFilterApply = () => {
		onFilterApply({
			serviceAttributeIds: selectedServices.map((attribute) => (attribute.id)),
			comfortAttributeIds: selectedComforts.map((attribute) => (attribute.id)),
			foodAttributeIds: selectedMeals.map((attribute) => (attribute.id)),
			bathAttributeIds: selectedBathrooms.map((attribute) => (attribute.id)),
			housingTypes: selectedAccomodationTypes.map((attribute) => (attribute.id)),
			seasons: selectedSeasons.map((attribute) => (attribute.id)),
			bedroomCounts: selectedCounts,
			priceFrom: selectedPriceRange[0],
			priceTo: selectedPriceRange[1],
		});
		setSelectedSeasons([]);
		setSelectedMeals([]);
		setSelectedCounts([]);
		setSelectedBathrooms([]);
		setSelectedComforts([])
		setSelectedServices([])
		setSelectedPriceRange([0, 100000])
		setSelectedAccomodationTypes([])
		setOpenModal(false)
	}

	return (
		<>
			<Button onClick={() => setOpenModal(true)}>Фильтр</Button>
			<Modal show={openModal} onClose={() => setOpenModal(false)}>
				<Modal.Header>Фильтр</Modal.Header>
				<Modal.Body>
					<AccommodationTypeFilter selectedTypes={selectedAccomodationTypes} onTypeChange={setSelectedAccomodationTypes} />
					<SeasonFilter selectedSeasons={selectedSeasons} onSeasonChange={setSelectedSeasons} />
					{/* <LocationFilter selectedRegion={selectedLocation} onRegionChange={setSelectedLocation} /> */}
					<MealFilter selectedMeals={selectedMeals} onMealChange={setSelectedMeals} />
					<BedroomCountFilter selectedCounts={selectedCounts} onCountChange={setSelectedCounts} />
					<BathroomFilter selectedBathrooms={selectedBathrooms} onBathroomChange={setSelectedBathrooms} />
					<ComfortOnSiteFilter selectedValues={selectedComforts} onValuesChange={setSelectedComforts} />
					<ServiceFilter selectedValues={selectedServices} onServiceChange={setSelectedServices} />
					<PriceRangeFilter
						selectedRange={selectedPriceRange}
						onRangeChange={setSelectedPriceRange}
					/>
				</Modal.Body>
				<Modal.Footer>
					<div className='flex justify-center'>
						<Button onClick={handleFilterApply}>Показать</Button>
					</div>
				</Modal.Footer>
			</Modal>
		</>
	);
};

export default FilterModal;

