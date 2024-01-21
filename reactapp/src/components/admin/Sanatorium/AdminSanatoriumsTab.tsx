import React, { useEffect, useState } from 'react'
import api from '../../../services/api/api';
import { formatDateTimeToRuLocale } from '../../../utils/dateUtils';
import { showNotification } from '../../../utils/notificationManager';
import { Button } from 'flowbite-react';
import DataTable from 'react-data-table-component';
import SaveSanatoriumModal from './SaveSanatoriumModal';
import StatusComp from '../../status/StatusComp';
import DeleteModal from '../../ui/modal/DeleteModal';
import AdminPromoModal from '../Promo/AdminPromoModal';

type Props = {}

const AdminSanatoriumsTab = (props: Props) => {
  	const [sanatoriums, setSanatoriums] = useState([]);
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
			name: 'Время заселения',
			selector: (row: any) => row.checkInTime,
			center: true
		},
    	{
			name: 'Время выселения',
			selector: (row: any) => row.checkOutTime,
			center: true
		},
		{
			name: 'Статус',
			cell: (row: any) => (<StatusComp status={row.status} />),
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
            cell: (row: any) => <AdminPromoModal id={row.id} type="sanatorium"/>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
		{
            cell: (row: any) => <SaveSanatoriumModal onSave={handleSave} sanatoriumId={row.id}/>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
	];

	const fetchData = async () => {
		try {
			var response = await api.post("/sanatorium/getTableData", {
				pageNumber: currentPage,
				pageSize: 10,
			});

			setSanatoriums(response.data.items);
		} catch (error: any) {
			showNotification('error', error.message)
		}
	}

	useEffect(() => {
		fetchData();
	}, [])

	const handleSave = async () => {
		await fetchData();
	}

	const handleDelete = async () => {
        const ids = selectedRows.map(row => row?.id);
        try {
			await api.delete('/sanatorium', {data: {ids: ids}});
			await fetchData();
			setToggleClearRows(!toggledClearRows);
			showNotification("success", "Удаление прошло успешно")
		} catch (error: any) {
			showNotification("error", error.message)
		}
    }

	useEffect(() => {
        setSelectedRows([])
    }, [toggledClearRows])

	return (
		<>
			<div className=''>
				<div className='flex gap-2'>
					{/* <CreateTourModal onSave={handleSave} /> */}
					<SaveSanatoriumModal onSave={handleSave}/>
					<DeleteModal disabled={selectedRows.length === 0} onDelete={handleDelete} itemName="санатории"/>
				</div>
				<DataTable
					columns={columns}
					data={sanatoriums}
					selectableRows
					fixedHeader
					pagination
					noDataComponent='Нет записей для показа'
					onSelectedRowsChange = {({ allSelected, selectedCount, selectedRows }) => {setSelectedRows(selectedRows);}}
					clearSelectedRows={toggledClearRows}
				/>
			</div>
		</>
	)
}

export default AdminSanatoriumsTab