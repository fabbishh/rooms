import { Button, Modal } from 'flowbite-react';
import React, { useState } from 'react'
import DataTable from 'react-data-table-component';
import api from '../../../services/api/api';
import BuyPromoBlockModal from '../../promo/BuyPromoBlockModal';
import { Status } from '../../../shared/app.enums';
import AdminPromoModal from '../Promo/AdminPromoModal';

type Props = {
    roomGroupId: string
}

const AdminRoomTable = ({roomGroupId}: Props) => {
    const [openModal, setOpenModal] = useState(false);
    const [rooms, setRooms] = useState<any[]>([]);

    const [selectedRows, setSelectedRows] = useState<any[]>([]);
	const [toggledClearRows, setToggleClearRows] = useState(false);


    const handleCloseModal = () => {
        setOpenModal(false)
    }

    const fetchData = async () => {
        try {
            var response = await api.post("/room/getPaged", {
                pageNumber: 1,
                pageSize: 1000,
                filter: {
                    roomGroupId: roomGroupId
                }
            })
            setRooms(response.data?.items)
        } catch (error) {
            
        }
    }

    const handleOpenModal = async () => {
        await fetchData();
        setOpenModal(true);
    }

    const columns = [

		{
			name: 'Название',
			selector: (row: any) => row.name,
			center: true
		},
        {
			name: 'Количество спален',
			selector: (row: any) => row.bedroomCount,
			center: true
		},
        {
			name: 'Одноместные кровати',
			selector: (row: any) => row.singleBedCount,
			center: true
		},
        {
			name: 'Двухместные кровати',
			selector: (row: any) => row.doubleBedCount,
			center: true
		},
        {
            cell: (row: any) => <AdminPromoModal id={row.roomId} type="room"/>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
	];

    return (
        <>
            <Button onClick={handleOpenModal} color="blue">Список номеров</Button>
            <Modal show={openModal} onClose={handleCloseModal} size="7xl">
                <Modal.Header>Список номеров</Modal.Header>
                <Modal.Body>
                    <DataTable
                        columns={columns}
                        data={rooms}
                        selectableRows
                        fixedHeader
                        //pagination
                        noDataComponent='Нет записей для показа'
                        onSelectedRowsChange = {({ allSelected, selectedCount, selectedRows }) => {setSelectedRows(selectedRows);}}
                        clearSelectedRows={toggledClearRows}
                    />
                </Modal.Body>
            </Modal>
        </>
    )
}

export default AdminRoomTable