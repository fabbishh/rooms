import React, { useEffect, useState } from 'react'
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';
import SaveRoomModal from '../../room/SaveRoomModal';
import DataTable from 'react-data-table-component';
import useSanatoriumInfo from '../../../hooks/useSanatoriumInfo';
import StatusComp from '../../status/StatusComp';
import BuyPromoBlockModal from '../../promo/BuyPromoBlockModal';
import { Status } from '../../../shared/app.enums';

type Room = {
    roomGroupId: string;
    name: string;
    count: number;
    price: number;
};

const SanatoriumHousesTab = () => {
    const [rooms, setRooms] = useState<Room[]>([]);

	const { sanatoriumInfo } = useSanatoriumInfo();

    const columns = [
        {
            name: 'Название',
            selector: (row: any) => row.name,
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
            cell: (row: any) => <BuyPromoBlockModal type="room" id={row.roomGroupId} disabled={row.status !== Status.Confirmed}/>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
        {
            cell: (row: any) => <SaveRoomModal 
                                    onSave={onSave} 
                                    roomGroupId={row.roomGroupId} 
                                    title={'Редактирование номеров'} 
                                    buttonName={'Редактировать'} 
                                    isAdmin={false} 
                                    type="house"/>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
    ];

    useEffect(() => {
        const fetchData = async () => {
            try {
                var response = await api.post("room/GetRoomTableData", { pageNumber: 1, pageSize: 10, sanatoriumId: sanatoriumInfo.id, housingType: 1 });
                setRooms(response.data.items);
            } catch (error: any) {
                showNotification("error", error.message)
            }
        }
        if(sanatoriumInfo.id) {
            fetchData();
        }
        
    }, [sanatoriumInfo.id])

    const onSave = async () => {
        try {
            var response = await api.post("room/GetRoomTableData", { pageNumber: 1, pageSize: 10, sanatoriumId: sanatoriumInfo.id, housingType: 1 });
            setRooms(response.data.items);
        } catch (error: any) {
            showNotification("error", error.message)
        }
    };

    return (
        <>
            <div className="my-4">
                <SaveRoomModal sanatoriumId={sanatoriumInfo.id} title="Создание отдельного жилья" buttonName='Создать' isAdmin={false} onSave={onSave} type="house"/>
            </div>
            <DataTable
                columns={columns}
                data={rooms}
                selectableRows
                fixedHeader
                pagination
                noDataComponent='Нет записей для показа'
            />

        </>
    );
}

export default SanatoriumHousesTab