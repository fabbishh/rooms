import React, { useEffect, useState } from 'react'
import StatusComp from '../../status/StatusComp';
import { formatDateTimeToRuLocale } from '../../../utils/dateUtils';
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';
import { Button } from 'flowbite-react';
import DataTable from 'react-data-table-component';
import DeleteModal from '../../ui/modal/DeleteModal';
import SaveUserModal from './SaveUserModal';

type Props = {}

const AdminUsersTab = (props: Props) => {
	const [users, setUsers] = useState([]);

	const [selectedRows, setSelectedRows] = useState<any[]>([]);
	const [toggledClearRows, setToggleClearRows] = useState(false);
	
	const columns = [
		{
			name: 'Имя',
			selector: (row: any) => row.firstName,
			center: true
		},
		{
			name: 'Фамилия',
			selector: (row: any) => row.lastName,
			center: true
		},
		{
			name: 'Отчество',
			selector: (row: any) => row.patronymic,
			center: true
		},
		{
			name: 'Email',
			selector: (row: any) => row.email,
			center: true
		},
		{
			name: 'Номер',
			selector: (row: any) => row.phone,
			center: true
		},
		{
			name: 'Статус',
			selector: (row: any) => row.isActive,
			center: true
		},
		{
			name: 'Дата создания',
			selector: (row: any) => row.dateCreated,
			format: (row: any) => formatDateTimeToRuLocale(row.dateCreated),
			center: true
		},
		{
            cell: (row: any) => <SaveUserModal onSave={handleSave} userId={row.id}/>,
            ignoreRowClick: true,
            center: true
        },
	];

	const fetchData = async () => {
		try {
			var response = await api.get("/user/list");

			setUsers(response.data);
		} catch (error: any) {
			showNotification('error', error.message)
		}
	}

	useEffect(() => {
		fetchData();
	}, [])

	const handleSave = async () => {
		try {
			var response = await api.get("/user/list");

			setUsers(response.data);
		} catch (error: any) {
			showNotification('error', error.message)
		}
	}

	const handleDelete = async () => {
        const ids = selectedRows.map(row => row?.id);
        try {
            await api.delete('/user', {data: {ids: ids}});
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
					<SaveUserModal onSave={handleSave} />
					<DeleteModal disabled={selectedRows.length === 0} onDelete={handleDelete} itemName="Пользователи" />
				</div>
				<DataTable
					columns={columns}
					data={users}
					selectableRows
					fixedHeader
					pagination
					noDataComponent='Нет записей для показа'
					clearSelectedRows={toggledClearRows}
                    onSelectedRowsChange={({ allSelected, selectedCount, selectedRows }) => { setSelectedRows(selectedRows); }}
				/>
			</div>
		</>
	)
}

export default AdminUsersTab