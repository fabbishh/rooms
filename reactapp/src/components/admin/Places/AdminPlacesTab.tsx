import React, { useEffect, useState } from 'react'
import DataTable from 'react-data-table-component';
import { formatDateTimeToRuLocale } from '../../../utils/dateUtils';
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';
import DeleteModal from '../../ui/modal/DeleteModal';
import SavePlaceModal from './SavePlaceModal';

type Props = {}

const AdminPlacesTab = (props: Props) => {
    const [places, setPlaces] = useState<any[]>([]);

    const [selectedRows, setSelectedRows] = useState<any[]>([]);
    const [toggledClearRows, setToggleClearRows] = useState(false);

    const columns = [
        {
            name: 'Название',
            selector: (row: any) => row.name,
            center: true
        },
        {
            name: 'Регион',
            selector: (row: any) => row.subjectName,
            center: true
        },
        {
            name: 'Дата создания',
            selector: (row: any) => row.dateCreated,
            format: (row: any) => formatDateTimeToRuLocale(row.dateCreated),
            center: true
        },
        {
            cell: (row: any) => <SavePlaceModal
                onSave={handleSaveRoom}
                placeId={row.id}
            />,
            ignoreRowClick: true,
            allowOverflow: true,
            //button: true,
            center: true
        },
    ];

    useEffect(() => {
        const fetchData = async () => {
            try {
                var response = await api.post("/place/getPaged", { pageNumber: 1, pageSize: 10, housingType: 0 });
                setPlaces(response.data.items);
            } catch (error: any) {
                showNotification("error", JSON.parse(error.response))
            }
        }

        fetchData();
    }, [])

    const handleSaveRoom = async () => {
        try {
            var response = await api.post("/place/getPaged", { pageNumber: 1, pageSize: 10, housingType: 0 });
            setPlaces(response.data.items);
        } catch (error: any) {
            showNotification("error", error.message)
        }
    };

    const handleDelete = async () => {
        const ids = selectedRows.map(row => row?.id);
        try {
            //await api.delete('/sanatorium', {data: {ids: ids}});
            //await fetchData();
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
                <SavePlaceModal onSave={handleSaveRoom} />
                <DeleteModal disabled={selectedRows.length === 0} onDelete={handleDelete} itemName="места" /> 
            </div>
            <DataTable
                columns={columns}
                data={places}
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

export default AdminPlacesTab