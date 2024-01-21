import React, { useEffect, useState } from 'react'
import api from '../../../services/api/api';
import { formatDateTimeToRuLocale, formatDateToRuLocale } from '../../../utils/dateUtils';
import ReservationStatusComp from '../../status/StatusComp';
import { showNotification } from '../../../utils/notificationManager';
import DataTable from 'react-data-table-component';
import SaveTourModal from '../../tour/SaveTourModal';
import DeleteModal from '../../ui/modal/DeleteModal';
import AdminPromoModal from '../Promo/AdminPromoModal';

type Props = {}

const AdminToursTab = (props: Props) => {
    const [tours, setTours] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);

    const [selectedRows, setSelectedRows] = useState<any[]>([]);
    const [toggledClearRows, setToggleClearRows] = useState(false);

    const columns = [
        {
            name: 'Турагенство',
            selector: (row: any) => row.tourAgencyName,
            center: true
        },
        {
            name: 'Тур',
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
            cell: (row: any) => <AdminPromoModal id={row.id} type="tour"/>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
        {
            cell: (row: any) => <SaveTourModal onSave={handleSave} mode='update' role='admin' tourId={row.id} />,
            ignoreRowClick: true,
            center: true
        },
    ];

    const fetchData = async () => {
        try {
            var response = await api.post("/tour/getTableData", {
                pageNumber: currentPage,
                pageSize: 10
            });

            setTours(response.data.items);
        } catch (error: any) {
            showNotification('error', error.message)
        }
    }

    useEffect(() => {
        fetchData();
    }, [])

    const handleSave = async () => {
        try {
            await fetchData()
        } catch (error: any) {
            showNotification('error', error.message)
        }
    }

    const handleDelete = async () => {
        const ids = selectedRows.map(row => row?.id);
        try {
			await api.delete('/tour', {data: {ids: ids}});
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
                    <SaveTourModal onSave={handleSave} mode='create' role='admin' />
                    <DeleteModal disabled={selectedRows.length === 0} onDelete={handleDelete} itemName="туры" />
                </div>
                <DataTable
                    columns={columns}
                    data={tours}
                    fixedHeader
                    pagination
                    selectableRows
                    noDataComponent='Нет записей для показа'
                    clearSelectedRows={toggledClearRows}
                    onSelectedRowsChange={({ allSelected, selectedCount, selectedRows }) => { setSelectedRows(selectedRows); }}
                />
            </div>
        </>
    )
}

export default AdminToursTab