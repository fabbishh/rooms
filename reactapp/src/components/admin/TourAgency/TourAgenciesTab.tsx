import React, { useEffect, useState } from 'react'
import ReservationStatusComp from '../../status/StatusComp';
import { formatDateTimeToRuLocale, formatDateToRuLocale } from '../../../utils/dateUtils';
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';
import { Button } from 'flowbite-react';
import DataTable from 'react-data-table-component';
import DeleteModal from '../../ui/modal/DeleteModal';
import SaveTourAgencyModal from './SaveTourAgencyModal';
import AdminPromoModal from '../Promo/AdminPromoModal';

type Props = {}

const TourAgenciesTab = (props: Props) => {
	const [tourAgencies, setTourAgencies] = useState([]);
	const [currentPage, setCurrentPage] = useState(1);

	const [selectedRows, setSelectedRows] = useState<any[]>([]);
	const [toggledClearRows, setToggleClearRows] = useState(false);

	const columns = [

		{
			name: 'Название',
			selector: (row: any) => row.name,
			center: true
		},
		{
			name: 'Email',
			selector: (row: any) => row.email,
			center: true
		},
		{
			name: 'Адрес',
			selector: (row: any) => row.location,
			center: true
		},
		{
			name: 'Ссылка на сайт',
			selector: (row: any) => row.link,
			center: true
		},
		{
			name: 'Статус',
			cell: (row: any) => (<ReservationStatusComp status={row.status} />),
			center: true
		},
		{
			name: 'Владелец',
			selector: (row: any) => row.owner,
			center: true
		},
		{
			name: 'Дата создания',
			selector: (row: any) => row.dateCreated,
			format: (row: any) => formatDateTimeToRuLocale(row.dateCreated),
			center: true
		},
		{
            cell: (row: any) => <AdminPromoModal id={row.id} type="tourAgency"/>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
		{
            cell: (row: any) => <SaveTourAgencyModal onSave={handleSave} tourAgencyId={row.id}/>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
	];

	const fetchData = async () => {
		try {
			var response = await api.post("/tourAgency/getTableData", {
				pageNumber: currentPage,
				pageSize: 10,
			});

			setTourAgencies(response.data.items);
		} catch (error: any) {
			showNotification('error', error.message)
		}
	}
	
	useEffect(() => {
		fetchData();
	}, [])

	const handleSave = async () => {
		try {
			var response = await api.post("/tourAgency/getTableData", {
				pageNumber: currentPage,
				pageSize: 10
			});

			setTourAgencies(response.data.items);
		} catch (error: any) {
			showNotification('error', error.message)
		}
	}

	useEffect(() => {
        setSelectedRows([])
    }, [toggledClearRows])

	const handleDelete = async () => {
        const ids = selectedRows.map(row => row?.id);
        try {
			await api.delete('/tourAgency', {data: {ids: ids}});
			await fetchData();
			setToggleClearRows(!toggledClearRows);
			showNotification("success", "Удаление прошло успешно")
		} catch (error: any) {
			showNotification("error", error.message)
		}
    }

	return (
		<>
			<div className=''>
				<div className='flex gap-2'>
					{/* <CreateTourModal onSave={handleSave} /> */}
					{/* <DeleteAttributeModal disabled={selectedRows.length === 0} onDelete={handleDelete}/> */}
					<SaveTourAgencyModal onSave={handleSave}/>
					<DeleteModal disabled={selectedRows.length === 0} onDelete={handleDelete} itemName="турагенства"/>
				</div>
				<DataTable
					columns={columns}
					data={tourAgencies}
					selectableRows
					fixedHeader
					pagination
					noDataComponent='Нет записей для показа'
					clearSelectedRows={toggledClearRows}
                onSelectedRowsChange = {({ allSelected, selectedCount, selectedRows }) => {setSelectedRows(selectedRows);}}
				/>
			</div>
		</>
	)
}

export default TourAgenciesTab