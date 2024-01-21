
import { Button } from 'flowbite-react';
import React, { useEffect, useState } from 'react'
import api from '../../services/api/api';
import { showNotification } from '../../utils/notificationManager';
import DataTable from 'react-data-table-component';
import Select from 'react-select';

type Props = {}

interface Region {
    id: string,
    nameWithType: string,
    isActive: boolean,
}

const RegionsTab = (props: Props) => {
    const [selectedRegion, setSelectedRegion] = useState<{value: string, label: string} | null>(null);
    const [activeRegions, setActiveRegions] = useState<Region[]>([]);
    const [options, setOptions] = useState([]);
    const [loadState, setloadState] = useState(false);

    

    const columns = [
        {
            name: 'Название',
            selector: (row: any) => row.nameWithType,
            center: true
        },
        {
            cell: (row: any) => (<Button color="failure" onClick={() => handleChangeActivity(row.id, false)}>Отключить</Button>),
            button: true,
            center: true
        }
    ]

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await api.post("/region/get-list", {})
                setActiveRegions(response.data.filter((r: any) => r.isActive));

                const selectOptions = response.data.filter((r: any) => !r.isActive);
                setOptions(selectOptions.map((item: Region) => ({ value: item.id, label: item.nameWithType })));
            } catch (error: any) {
                showNotification('error', error.message);
            }
        }
        
        fetchData();
    }, [loadState])

    const handleRegionChange = (option: any) => {
        setSelectedRegion(option);
    }

    const handleChangeActivity = async (id: string, isActive: boolean) => {
        try {
            await api.post("/region/update-activity", { id: id, isActive: isActive });
            setloadState(!loadState);
            setSelectedRegion(null);
        } catch (error) {
            
        }
    }

    return (
        <div>
            <div className="flex gap-4">
                <Select
                    id="regionSelect"
                    options={options}
                    //isSearchable={false}
                    placeholder="Выберите регион"
                    onChange={handleRegionChange}
                    isClearable = {true}
                    value={selectedRegion}
                    className='min-w-[200px]'
                    loadingMessage={() => "Загрузка..."}
                    noOptionsMessage={() => "Ничего не найдено"}
                />
                <Button onClick={() => handleChangeActivity(selectedRegion!.value, true)} disabled={selectedRegion === null}>Добавить</Button>
            </div>
            <div>
                <DataTable
                    columns={columns}
                    data={activeRegions}
                    pagination
                    noDataComponent = 'Нет записей для показа'
                />
            </div>
        </div>
    )
}

export default RegionsTab