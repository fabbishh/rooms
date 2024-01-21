import React, { useEffect, useState } from 'react'
import DataTable from 'react-data-table-component';
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';
import ReservationStatusComp from '../../status/StatusComp';
import { formatDateTimeToRuLocale, formatDateToRuLocale } from '../../../utils/dateUtils';
import { Button, Checkbox, Label, Radio } from 'flowbite-react';
import ReservationDetailsPopup from '../../reservation/ReservationDetailsPopup';
import useSanatoriumInfo from '../../../hooks/useSanatoriumInfo';

interface Reservation {
    id: string,
    startDate: Date,
    endDate: Date,
    roomName: string,
    guestsCount: number,
    status: number,
    dateCreated: Date,
    authorEmail: string,
}

const options = [{ id: "0", name: "В ожидании", isActive: false }, { id: "1", name: "Подтверждено", isActive: false }, { id: "2", name: "Отклонено", isActive: false },]

const SanatoriumReservationsTab = () => {
    const [reservations, setReservations] = useState<Reservation[]>([]);
    const [currentPage, setCurrentPage] = useState<number>(1);
    const [activityFilter, setActivityFilter] = useState(true);
    const [statusOptions, setStatusOptions] = useState(options);
    const [isFiltered, setIsFiltered] = useState(false);
    const pagesize = 10;

	const { sanatoriumInfo } = useSanatoriumInfo();

    useEffect(() => {
        if(sanatoriumInfo.id) {
            fetchData({ sanatoriumId: sanatoriumInfo.id});
        }
    }, [sanatoriumInfo])

    const columns = [
        {
            name: 'Жилье',
            selector: (row: any) => row.roomName,
            center: true
        },
        {
            name: 'Автор брони',
            selector: (row: any) => row.authorEmail,
            center: true
        },
        {
            name: 'Дата Заселения',
            selector: (row: any) => row.startDate,
            format: (row: any) => formatDateToRuLocale(row.startDate),
            center: true
        },
        {
            name: 'Дата Выселения',
            selector: (row: any) => row.endDate,
            format: (row: any) => formatDateToRuLocale(row.endDate),
            center: true
        },
        {
            name: 'Количество Гостей',
            selector: (row: any) => row.guestsCount,
            maxWidth: "200px",
            center: true
        },
        {
            name: 'Статус',
            cell: (row: any) => (<ReservationStatusComp status={row.status} />),
            center: true
        },
        {
            name: 'Дата создания',
            selector: (row: any) => row.dateCreated,
            format: (row: any) => formatDateTimeToRuLocale(row.dateCreated),
            center: true
        },
        {
            cell: (row: any) => <ReservationDetailsPopup reservationId={row.id} onSave={onSave} />,
            ignoreRowClick: true,
            allowOverflow: true,
            button: true,
            center: true
        },
    ];

    const fetchData = async (filter?: any ) => {
        try {
            const response = await api.post("reservation/GetPaged", {
                pageNumber: currentPage,
                pagesize: pagesize,
                filter: filter
            });

            setReservations(response.data.items);
        } catch (error: any) {
            showNotification("error", error.message);
        }
    }

    const onSave = async () => {
        let filter = null;
        if(isFiltered){
            filter = {
                sanatoriumId: sanatoriumInfo.id,
                activity: activityFilter,
                statuses: statusOptions.filter(o => o.isActive === true).map(item => item.id),
            };
        } else {
            filter = {
                sanatoriumId: sanatoriumInfo.id,
            }
        }
        await fetchData(filter)
    }

    const handleFilterApply = async () => {
        var filter = {
            sanatoriumId: sanatoriumInfo.id,
            activity: activityFilter,
            statuses: statusOptions.filter(o => o.isActive === true).map(item => item.id),
        };

        setIsFiltered(true);
        await fetchData(filter)
    }

    const handleFilterReset = async () => {
        setStatusOptions(options);
        setActivityFilter(true);
        setIsFiltered(false);
        await fetchData()
    }

    const handleOptionsChange = (option: any) => {
        const changedOptions = statusOptions.map((status) =>
            status.id === option.id
                ? { ...status, isActive: !status.isActive }
                : status
        )
        console.log(changedOptions);
        setStatusOptions(changedOptions);
    }

    return (
        <div className='flex gap-10 min-h-screen'>
            <div className='border-r p-4 space-y-6'>
                <h3>Фильтр</h3>
                <fieldset className="flex max-w-md flex-col gap-4">
                    <div className="flex items-center gap-2">
                        <Radio
                            id="active"
                            name="activity"
                            value="true"
                            checked={activityFilter}
                            onChange={() => setActivityFilter(true)}
                        />
                        <Label htmlFor="active">Активные (будущие)</Label>
                    </div>
                    <div className="flex items-center gap-2">
                        <Radio
                            id="disabled"
                            name="activity"
                            value="false"
                            checked={!activityFilter}
                            onChange={() => setActivityFilter(false)}
                        />
                        <Label htmlFor="disabled">Не активные (в прошлом)</Label>
                    </div>
                </fieldset>

                <div className="flex max-w-md flex-col gap-4" id="checkbox">
                    <h5>Статус</h5>
                    { statusOptions.map(option => (
                    <div key={option.id} className="flex items-center gap-2">
                        <Checkbox
                            id={option.id}
                            onChange={() => handleOptionsChange(option)}
                            checked={option.isActive}
                        />
                        <Label htmlFor={option.id}>{option.name}</Label>
                    </div>
                    ))}
                </div>
                <div className='space-y-6'>
                    <div className='flex justify-center'>
                        <Button onClick={handleFilterApply}>Применить фильтр</Button>
                    </div>
                    <div className='flex justify-center'>
                        <Button onClick={handleFilterReset} color="light">Сбросить</Button>
                    </div>

                </div>
            </div>
            <div className=''>
                <DataTable
                    columns={columns}
                    data={reservations}
                    fixedHeader
                    pagination
                    noDataComponent='Нет записей для показа'
                />
            </div>
        </div>
    )
}

export default SanatoriumReservationsTab