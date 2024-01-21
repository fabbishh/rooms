import React, { useEffect, useState } from 'react'
import api from '../../services/api/api';
import { formatDateToRuLocale } from '../../utils/dateUtils';
import StatusComp from '../status/StatusComp';

type Props = {}

const UserReservationsTab = (props: Props) => {
	const [reservations, setReservations] = useState<any[]>([]);

	useEffect(() => {
		const fetchData = async () => {
			try {
				var response = await api.post("/reservation/user-reservations", { pageNumber: 1, pageSize: 100 })
				setReservations(response.data.items)
			} catch (error) {

			}
		}

		fetchData();
	}, [])

	return (
		<div className="container mx-auto my-10">
			<h2 className="text-3xl font-semibold mb-6">Мои бронирования</h2>
			{reservations.length === 0 && <p>У вас пока нет бронирований.</p>}
			<ul className="grid gap-6 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3">
				{reservations.map(booking => (
					<li key={booking.id} className="bg-white rounded-md p-6 shadow-md">
						<div className='flex justify-between'>
							<p className="text-lg font-semibold mb-2">Номер: {booking.roomName}</p>
							<StatusComp status={booking.status}/>
						</div>
						
						<p className="text-sm mb-2">Заезд: {formatDateToRuLocale(booking.startDate)}</p>
						<p className="text-sm mb-2">Выезд: {formatDateToRuLocale(booking.endDate)}</p>
						{/* Добавьте дополнительные данные о бронировании, если необходимо */}
					</li>
				))}
			</ul>
		</div>
	);
};

export default UserReservationsTab