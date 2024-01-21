import React, { useEffect, useState } from 'react'
import { showNotification } from '../../../utils/notificationManager';
import api from '../../../services/api/api';
import SaveRoomModal from '../../room/SaveRoomModal';
import DataTable from 'react-data-table-component';
import DeleteModal from '../../ui/modal/DeleteModal';
import StatusComp from '../../status/StatusComp';
import { formatDateTimeToRuLocale } from '../../../utils/dateUtils';
import AdminPromoModal from '../Promo/AdminPromoModal';
import AdminRoomTable from './AdminRoomTable';

type Props = {}

const AdminRoomsTab = (props: Props) => {
    const [rooms, setRooms] = useState<any[]>([]);
    const [selectedRows, setSelectedRows] = useState<any[]>([]);
    const [toggledClearRows, setToggleClearRows] = useState(false);

    const columns = [
        {
            name: 'Название',
            selector: (row: any) => row.name,
            center: true
        },
        {
            name: 'Санаторий',
            selector: (row: any) => row.sanatoriumName,
            center: true
        },
        {
            name: 'Количество',
            selector: (row: any) => row.count,
            center: true
        },
        {
            name: 'Цена в сутки',
            selector: (row: any) => row.price,
            center: true
        },
        {
            name: 'Статус',
            cell: (row: any) => (<StatusComp status={row.status} />),
            center: true
        },
        {
            name: 'Дата создания',
            selector: (row: any) => row.dateCreated,
            format: (row: any) => formatDateTimeToRuLocale(row.dateCreated),
            center: true
        },
        {
            cell: (row: any) => <AdminRoomTable roomGroupId={row.roomGroupId}/>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
        {
            cell: (row: any) => <SaveRoomModal
                onSave={handleSaveRoom}
                roomGroupId={row.roomGroupId}
                title={'Редактирование номеров'}
                buttonName={'Редактировать'}
                isAdmin={true}
                type="room" />,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
    ];

    const fetchData = async () => {
        try {
            var response = await api.post("room/GetRoomTableData", { pageNumber: 1, pageSize: 10, housingType: 0 });
            setRooms(response.data.items);
        } catch (error: any) {
            showNotification("error", JSON.parse(error.response))
        }
    }

    useEffect(() => {
        

        fetchData();
    }, [])

    const handleSaveRoom = async () => {
        try {
            var response = await api.post("room/GetRoomTableData", { pageNumber: 1, pageSize: 10, housingType: 0 });
            setRooms(response.data.items);
        } catch (error: any) {
            showNotification("error", error.message)
        }
    };

    const handleDelete = async () => {
        const ids = selectedRows.map(row => row?.roomGroupId);
        try {
			await api.delete('/room', {data: {ids: ids}});
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
            <div className='flex gap-2'>
                <SaveRoomModal title="Создание комнаты" buttonName='Создать' onSave={handleSaveRoom} isAdmin={true} type="room" />
                <DeleteModal disabled={selectedRows.length === 0} onDelete={handleDelete} itemName="номера" />
            </div>
            <DataTable
                columns={columns}
                data={rooms}
                selectableRows
                fixedHeader
                pagination
                noDataComponent='Нет записей для показа'
                clearSelectedRows={toggledClearRows}
                onSelectedRowsChange={({ allSelected, selectedCount, selectedRows }) => { setSelectedRows(selectedRows); }}
            />
        </>
    );
}

export default AdminRoomsTab