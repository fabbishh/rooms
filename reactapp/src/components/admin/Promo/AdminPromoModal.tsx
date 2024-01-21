import { Button, Modal } from 'flowbite-react';
import React, { useEffect, useState } from 'react'
import api from '../../../services/api/api';
import StatusComp from '../../status/StatusComp';
import DataTable from 'react-data-table-component';
import { showNotification } from '../../../utils/notificationManager';
import { Status } from '../../../shared/app.enums';
import { formatDateToRuLocale } from '../../../utils/dateUtils';

type Props = {
    id: string,
    type: "sanatorium" | "room" | "tourAgency" | "tour"
}

const AdminPromoModal = ({ id, type}: Props) => {
    const [openModal, setOpenModal] = useState(false);
    const [promos, setPromos] = useState<any[]>([]);

    const [selectedRows, setSelectedRows] = useState<any[]>([]);
	const [toggledClearRows, setToggleClearRows] = useState(false);


    const handleCloseModal = () => {
        setOpenModal(false)
    }

    const fetchData = async () => {
        try {
            const data = type === 'room'
                ? { roomId: id }
                : type == "tour"
                ? { tourId: id }
                : type == "tourAgency"
                ? { tourAgencyId: id }
                : { sanatoriumId: id }
            var response = await api.post("/promo/requests", data);
            setPromos(response.data);
        } catch (error: any ) {
            
        }
    }

    const handleOpenModal = async () => {
        await fetchData();
        setOpenModal(true);
    }

    const changeStatus = async (status: number, promoId: string, promoType: number) => {
        try {
            var response = await api.post("/promo/change-status", { promoId: promoId, status: status, promoType: promoType});
            await fetchData();
        } catch (error: any ) {

        }
    }

    const columns = [

		{
			name: 'Название',
			selector: (row: any) => row.name,
			center: true
		},
        {
            name: 'Дата начала',
            selector: (row: any) => row.startDate,
            format: (row: any) => formatDateToRuLocale(row.startDate),
            center: true
        },
        {
            name: 'Дата окончания',
            selector: (row: any) => row.endDate,
            format: (row: any) => formatDateToRuLocale(row.endDate),
            center: true
        },
		{
			name: 'Статус',
			cell: (row: any) => (<StatusComp status={row.status} />),
			center: true
		},
        {
            cell: (row: any) => <Button color="success" onClick={() => changeStatus(Status.Confirmed, row.id, row.promoType)} disabled={row.status == Status.Confirmed || row.status == Status.Declined}>Подтвердить</Button>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
        {
            cell: (row: any) => <Button color="failure" onClick={() => changeStatus(Status.Declined, row.id, row.promoType)} disabled={row.status == Status.Confirmed || row.status == Status.Declined}>Отклонить</Button>,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
		// {
		// 	name: 'Дата создания',
		// 	selector: (row: any) => row.dateCreated,
		// 	format: (row: any) => formatDateTimeToRuLocale(row.dateCreated),
		// 	center: true
		// },
	];

    return (
        <>
            <Button onClick={handleOpenModal} color="warning">Промо</Button>
            <Modal show={openModal} onClose={handleCloseModal} size="7xl">
                <Modal.Header>Промо</Modal.Header>
                <Modal.Body>
                    <DataTable
                        columns={columns}
                        data={promos}
                        selectableRows
                        fixedHeader
                        pagination
                        noDataComponent='Нет записей для показа'
                        onSelectedRowsChange = {({ allSelected, selectedCount, selectedRows }) => {setSelectedRows(selectedRows);}}
                        clearSelectedRows={toggledClearRows}
                    />
                </Modal.Body>
            </Modal>
        </>
    )
}

export default AdminPromoModal