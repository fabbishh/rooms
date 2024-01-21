import React, { useEffect, useState } from 'react'
import api from '../../services/api/api';
import { showNotification } from '../../utils/notificationManager';
import Select from 'react-select';

type Props = {
    value: string,
    onChange: any,
    isClearable: boolean
}

const RegionSelect = ({ value, onChange, isClearable }: Props) => {
    const [options, setOptions] = useState<any[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await api.post("/region/get-list", {})
                const selectOptions = response.data.filter((r: any) => r.isActive);
                setOptions(selectOptions.map((item: any) => ({ value: item.id, label: item.nameWithType, name: item.name })));
            } catch (error: any) {
                showNotification('error', error.message);
            }
        }

        fetchData();
    }, [])

    return (
        <Select
            options={options}
            isSearchable={true}
            placeholder="Выберите регион"
            onChange={onChange}
            isClearable={isClearable}
            value={options.find((t: any) => t.value === value)}
            loadingMessage={() => "Загрузка..."}
            noOptionsMessage={() => "Ничего не найдено"}
        />
    )
}

export default RegionSelect