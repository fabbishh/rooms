import React, { useEffect, useState } from 'react'
import CreateAttributeModal from './CreateAttributeModal';
import DeleteAttributeModal from './DeleteAttributeModal';
import { Button } from 'flowbite-react';
import DataTable from 'react-data-table-component';
import { Attribute } from '../../../shared/app.interfaces';
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';

type Props = {
    attributes: Attribute[],
    onCreate: (data: any) => void,
    onDelete: (ids: string[]) => void,
}

const AttributeTable = ({ attributes, onCreate, onDelete }: Props) => {
    const [selectedRows, setSelectedRows] = useState<Attribute[]>([]);
    const [toggledClearRows, setToggleClearRows] = useState(false);

    const columns = [
        {
            name: 'Название',
            selector: (row: any) => row.name,
        },
        {
            name: 'Статус',
            selector: (row: any) => row.isActive ? "Включено" : "Отключено",
        },
    ];

    useEffect(() => {
        setSelectedRows([])
    }, [toggledClearRows])

    const handleCreate = async (data: any) => {
        await onCreate(data);
    }

    const handleDelete = async () => {
        const ids = selectedRows.map(row => row.id);
        await onDelete(ids);

        setToggleClearRows(!toggledClearRows)
    }

    const handleRowSelected = React.useCallback((state: any) => {
		setSelectedRows(state.selectedRows);
	}, []);

    return (
        <>
            <div className='flex gap-2'>
                <CreateAttributeModal buttonName="Создать" modalTitle="Создание атрибута" onSave={handleCreate}/>
                <DeleteAttributeModal disabled={selectedRows.length === 0} onDelete={handleDelete}/>
            </div>
            <DataTable
                columns={columns}
                data={attributes}
                selectableRows
                fixedHeader
                pagination
                onSelectedRowsChange = {handleRowSelected}
                clearSelectedRows={toggledClearRows}
                noDataComponent = 'Нет записей для показа'
            />
        </>
    )
}

export default AttributeTable