import React, { useEffect, useState } from 'react'
import DataTable from 'react-data-table-component';
import { showNotification } from '../../../utils/notificationManager';
import api from '../../../services/api/api';
import { formatDateTimeToRuLocale } from '../../../utils/dateUtils';
import StatusComp from '../../status/StatusComp';
import TourReviewDetaisModal from './TourReviewDetaisModal';

type Props = {}

const ToursReviewsTab = (props: Props) => {
  const [reviews, setReviews] = useState([]);
	const [currentPage, setCurrentPage] = useState(1);

	const [selectedRows, setSelectedRows] = useState<any[]>([]);
	const [toggledClearRows, setToggleClearRows] = useState(false);

	const columns = [

		{
			name: 'Санаторий',
			selector: (row: any) => row.tourName,
			center: true
		},
		{
			name: 'Пользователь',
			selector: (row: any) => row.userName,
			center: true
		},
		{
			name: 'Оценка',
			selector: (row: any) => row.rating,
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
          cell: (row: any) => <TourReviewDetaisModal reviewId={row.id} onSave={onSave} />,
          ignoreRowClick: true,
          allowOverflow: true,
          button: true,
          center: true
      },
	];

    const onSave = async () => {
        await fetchData();
    }

	const fetchData = async () => {
		try {
			var response = await api.post("/review/tour-reviews/GetTableData", {
				pageNumber: currentPage,
				pageSize: 10,
			});

			setReviews(response.data.items);
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

	// const handleDelete = async () => {
  //       const ids = selectedRows.map(row => row?.id);
  //       try {
	// 		await api.delete('/sanatorium', {data: {ids: ids}});
	// 		await fetchData();
	// 		setToggleClearRows(!toggledClearRows);
	// 		showNotification("success", "Удаление прошло успешно")
	// 	} catch (error: any) {
	// 		showNotification("error", error.message)
	// 	}
		
  //   }

	useEffect(() => {
        setSelectedRows([])
    }, [toggledClearRows])

	return (
		<>
			<div className=''>
				<div className='flex gap-2'>
					{/* <CreateTourModal onSave={handleSave} /> */}
					{/* <SaveSanatoriumModal onSave={handleSave}/> */}
					{/* <DeleteModal disabled={selectedRows.length === 0} onDelete={handleDelete} itemName="Отзывы"/> */}
				</div>
				<DataTable
					columns={columns}
					data={reviews}
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

export default ToursReviewsTab