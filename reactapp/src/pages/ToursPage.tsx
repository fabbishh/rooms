// ToursPage.tsx
import React, { useEffect, useState } from 'react';
import TourFilters from '../components/tour/TourFilters';
import TourList from '../components/tour/TourList';
import Pagination from '../components/ui/Pagination';
import { Tour } from '../shared/app.interfaces';
import { showNotification } from '../utils/notificationManager';
import api from '../services/api/api';
import { useRegion } from '../context/RegionContext';

const ToursPage: React.FC = () => {
	const [currentPage, setCurrentPage] = useState(0);
	const [totalPages, setTotalPages] = useState(1);
	const [tours, setTours] = useState<Tour[]>([]);
	const [filter, setFilter] = useState<any>({});
	const pageSize = 10;

	const { region } = useRegion();

	useEffect(() => {
		const fetchData = async () => {
			try {
				var response = await api.post("/tour/getPaged", {
					pageNumber: currentPage + 1,
					pageSize: pageSize,
					filter: {...filter, subjectId: region?.id}
				});

				setTours(response.data.items);
				setTotalPages(response.data.totalPages);
			} catch (error: any) {
				showNotification('error', error.message)
			}
		}
		if(region) {
			fetchData();
		}
	}, [currentPage, filter, region])

	const handlePageChange = (event: any) => {
		setCurrentPage(event.selected);
	};

	const handleFilterChange = (filter: any) => {
		setFilter({...filter, subjectId: region?.id});
		setCurrentPage(0);
	}

	return (
		<div className="container m-8 p-4 min-h-screen">
			<div className="flex gap-4">
				<div className="">
					<TourFilters onFilterChange={handleFilterChange} />
				</div>
				<div className="min-w-[50%] space-y-6">
					<TourList tours={tours} />
					<Pagination
						pageNumber={currentPage}
						pageSize={pageSize}
						totalPages={totalPages}
						onPageChange={handlePageChange}
					/>
				</div>
			</div>
		</div>
	);
};

export default ToursPage;
