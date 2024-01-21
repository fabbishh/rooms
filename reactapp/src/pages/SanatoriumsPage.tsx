// SanatoriumPage.tsx
import React, { useState, useEffect } from 'react';
import SanatoriumCard from '../components/sanatorium/SanatoriumCard';
import Pagination from '../components/ui/Pagination';
import { Link } from 'react-router-dom';
import PromoRow from '../components/sanatorium/PromoRow';
import api from '../services/api/api';
import { showNotification } from '../utils/notificationManager';
import FilterModal from '../components/sanatorium/filters/FilterModal';
import { SanatoriumFilter } from '../shared/app.interfaces';
import { useRegion } from '../context/RegionContext';
import { Button } from 'flowbite-react';
import PromoBlocksSection from '../components/promo/PromoBlocksSection';

interface Sanatorium {
	id: string;
	name: string;
	photoUrl: string;
	priceFrom: number;
	address: string;
	season: number;
	isFavourite: boolean;
}

const SanatoriumPage: React.FC = () => {
	const { region } = useRegion();

	const [sanatoriums, setSanatoriums] = useState<Sanatorium[]>([]);
	const [currentPage, setCurrentPage] = useState(0);
	const [totalPages, setTotalPages] = useState(1);
	const [filter, setFilter] = useState<SanatoriumFilter>({ regionId: region?.id })
	const pageSize = 10;

	useEffect(() => {
		if(region) {
			updateSanatoriumsList(currentPage + 1, pageSize, {...filter, regionId: region.id});
		}
	}, [currentPage, filter, region]);

	const handlePageChange = (event: any) => {
		setCurrentPage(event.selected);
	};

	const updateSanatoriumsList = async (pageNumber: number, pageSize: number, filter?: SanatoriumFilter) => {
		try {
			const response = await api.post(`/sanatorium/GetPaged`, {
				pageNumber: pageNumber,
				pageSize: pageSize,
				filter: filter
			});
			setSanatoriums(response.data.items);
			setTotalPages(response.data.totalPages);
		} catch (error: any) {
			showNotification('error', error.message)
		}
	};

	const handleApplyFilters = (filter: SanatoriumFilter) => {
		setCurrentPage(0);
		setFilter({...filter, regionId: region?.id });
	};

	const resetFilter = () => {
		setFilter({});
	}

	return (
		<div className="container mx-auto grid grid-cols-6 gap-4 min-h-screen mt-2">
			<div className='col-span-5'>
				<PromoRow />
				<div className='flex gap-2'>
					<FilterModal onFilterApply={handleApplyFilters}/>
					<Button color="light" onClick={resetFilter}>Сбросить</Button>
				</div>
				
				<div className="space-y-6">
					<div className="flex flex-wrap -mx-2">
						{sanatoriums
							.map(sanatorium => (
								<div key={sanatorium.id} className="w-full sm:w-1/2 lg:w-1/3 xl:w-1/5 px-2 mb-4">
									<Link to={`/sanatoriums/${sanatorium.id}`}>
										<SanatoriumCard {...sanatorium} />
									</Link>
								</div>
							))}
					</div>
					<Pagination pageSize={pageSize} totalPages={totalPages} pageNumber={currentPage} onPageChange={handlePageChange} />
				</div>
			</div>
			<div className='col-span-1'>
				<PromoBlocksSection/>
			</div>
			
		</div>
	);
};

export default SanatoriumPage;
