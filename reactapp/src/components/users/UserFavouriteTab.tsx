import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom';
import SanatoriumCard from '../sanatorium/SanatoriumCard';
import Pagination from '../ui/Pagination';
import { showNotification } from '../../utils/notificationManager';
import api from '../../services/api/api';

type Props = {}

const UserFavouriteTab = (props: Props) => {
	const [sanatoriums, setSanatoriums] = useState<any[]>([]);
	const [currentPage, setCurrentPage] = useState(1);
	const [totalPages, setTotalPages] = useState(1);

	const [reloadState, setReloadState] = useState(false);

	const pageSize = 10;

	const handlePageChange = (event: any) => {
		setCurrentPage(event.selected);
	};

	useEffect(() => {
		const fetchData = async () => {
			try {
				const response = await api.post(`/favourite/sanatoriums`, {
					pageNumber: currentPage,
					pageSize: pageSize,
				});
				setSanatoriums(response.data.items);
				setTotalPages(response.data.totalPages);
			} catch (error: any) {
				showNotification('error', error.message)
			}
		}
		
		fetchData();
	}, [currentPage, reloadState]);

	return (
		<div className="space-y-6">
			<div className="flex flex-wrap -mx-2">
				{sanatoriums
					.map(sanatorium => (
						<div key={sanatorium.id} className="w-full sm:w-1/2 lg:w-1/3 xl:w-1/5 px-2 mb-4">
							<Link to={`/sanatoriums/${sanatorium.id}`}>
								<SanatoriumCard {...sanatorium} onLikeClick={() => setReloadState(!reloadState)}/>
							</Link>
						</div>
					))}
			</div>
			<Pagination pageSize={pageSize} totalPages={totalPages} pageNumber={currentPage} onPageChange={handlePageChange} />
		</div>
	)
}

export default UserFavouriteTab