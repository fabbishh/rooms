import React, { useEffect, useState } from 'react'
import api from '../../services/api/api';
import Select from 'react-select';

type Props = {
    value: any;
    onChange: any;
}

const TourTypeSelect = ({ value, onChange }: Props) => {
    const [options, setOptions] = useState<any[]>([])

    useEffect(() => {
        const fetchData = async () => {
            try {
                const typesResponse = await api.get("/tourType")
                const typeOptions = typesResponse?.data?.map((item: any) => ({ value: item.id, label: item.name }));
                setOptions(typeOptions);
            } catch (error) {

            }
        }

        fetchData();
    }, [])
    return (
        <Select
            options={options}
            isSearchable={true}
            placeholder="Выберите вид тура"
            value={options.find((t: any) => t.value === value) || null}
            onChange={onChange}
            isClearable={true}
            loadingMessage={() => "Загрузка..."}
            noOptionsMessage={() => "Ничего не найдено"}
        />
    )
}

export default TourTypeSelect