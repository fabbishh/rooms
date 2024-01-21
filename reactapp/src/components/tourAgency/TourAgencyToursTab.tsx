import React, { useEffect, useState } from 'react'
import DataTable from 'react-data-table-component';
import { formatDateTimeToRuLocale, formatDateToRuLocale } from '../../utils/dateUtils';
import { Button } from 'flowbite-react';
import CreateTourModal from '../tour/SaveTourModal';
import { showNotification } from '../../utils/notificationManager';
import api from '../../services/api/api';
import ReservationStatusComp from '../status/StatusComp';
import SaveTourModal from '../tour/SaveTourModal';
import useTourAgencyInfo from '../../hooks/useTourAgencyInfo';
import BuyPromoBlockModal from '../promo/BuyPromoBlockModal';
import { Status } from '../../shared/app.enums';

type Props = {}

const TourAgencyToursTab = (props: Props) => {
	const [tours, setTours] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);

	const tourAgencyInfo = useTourAgencyInfo()

	const columns = [
        {

        },
        {
            name: 'Название',
            selector: (row: any) => row.name,
            center: true
        },
        {
            name: 'Субъект',
            selector: (row: any) => row.subject,
            center: true
        },
        {
            name: 'Статус',
            cell: (row: any) => (<ReservationStatusComp status={row.status} />),
            center: true
        },
		{
            name: 'Ближайшие даты',
            selector: (row: any) => row.closestDates,
            cell: (row: any) => (<div>{row.closestDates.map((item: any) => (<div>{formatDateToRuLocale(item)}</div>))}</div>),
            center: true
            
        },
        {
            name: 'Дата создания',
            selector: (row: any) => row.dateCreated,
            format: (row: any) => formatDateTimeToRuLocale(row.dateCreated),
            center: true
        },
        {
            cell: (row: any) => <BuyPromoBlockModal type="tour" id={row.id} disabled={row.status !== Status.Confirmed}/>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
        {
            cell: (row: any) => <SaveTourModal onSave={handleSave} mode='update' role='tourAgencyAdmin' tourId={row.id}/>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
    ];

	 useEffect(() => {
        const fetchData = async () => {
            try {
                var response = await api.post("/tour/getTableData", { 
                    pageNumber: currentPage, 
                    pageSize: 10, 
                    filter: { tourAgencyId: tourAgencyInfo.id }
                });

                setTours(response.data.items);
            } catch (error:any) {
                showNotification('error', error.message)
            }
        }
        if(tourAgencyInfo.id) {
            fetchData();
        }
        
	 }, [tourAgencyInfo.id])

     const handleSave = async () => {
        try {
            var response = await api.post("/tour/getTableData", { 
                pageNumber: currentPage, 
                pageSize: 10, 
                filter: { tourAgencyId: tourAgencyInfo.id }
            });

            setTours(response.data.items);
        } catch (error:any) {
            showNotification('error', error.message)
        }
     }

	return (
		<>
			<div className=''>
				<div className='flex gap-2'>
					<SaveTourModal onSave={handleSave} mode='create' role='tourAgencyAdmin' tourAgencyId={tourAgencyInfo.id}/>
					{/* <DeleteAttributeModal disabled={selectedRows.length === 0} onDelete={handleDelete}/> */}
				</div>
                <DataTable
                    columns={columns}
                    data={tours}
                    fixedHeader
                    pagination
                    noDataComponent='Нет записей для показа'
                />
            </div>
		</>
	)
}

export default TourAgencyToursTab