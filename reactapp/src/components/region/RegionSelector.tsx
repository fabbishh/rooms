import { Button, Modal } from 'flowbite-react';
import React, { useEffect, useState } from 'react'
import { FaLocationDot } from 'react-icons/fa6';
import { Link } from 'react-router-dom';
import Select from 'react-select';
import api from '../../services/api/api';
import { showNotification } from '../../utils/notificationManager';
import { Placemark, YMaps, Map } from '@pbe/react-yandex-maps';
import { useRegion } from '../../context/RegionContext';
import { isObjectEmpty } from '../../utils/objectUtils';

type Props = {
}

const RegionSelector = (props: Props) => {
    const [openModal, setOpenModal] = useState(false);
    const [options, setOptions] = useState<{ value: string, label: string }[]>([]);
    const [selectedRegion, setSelectedRegion] = useState<{ value: string, label: string } | null>(null);

    const { region, handleSetRegion, loading } = useRegion();

    const handleSave = async () => {
        setOpenModal(false);
        handleSetRegion({ id: selectedRegion?.value!, nameWithType: selectedRegion?.label!})
    }

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await api.post("/region/get-list", {})
                const selectOptions = response.data.filter((r: any) => r.isActive);
                setOptions(selectOptions.map((item: any) => ({ value: item.id, label: item.nameWithType })));
            } catch (error: any) {
                showNotification('error', error.message);
            }
        }

        fetchData();

        if(!loading) {
            setSelectedRegion({ value: region?.id!, label: region?.nameWithType!});
        }
    }, [loading, region])

    const handleOpenModal = async () => {
        setOpenModal(true);
        fetchData();
        setSelectedRegion({ value: region?.id!, label: region?.nameWithType!});
    }

    const fetchData = async () => {
        try {
            const response = await api.post("/region/get-list", {})
            const selectOptions = response.data.filter((r: any) => r.isActive);
            setOptions(selectOptions.map((item: any) => ({ value: item.id, label: item.nameWithType })));
        } catch (error: any) {
            showNotification('error', error.message);
        }
    }

    const handleCloseModal = () => {
        setOpenModal(false)
    }

    const handleRegionChange = (option: any) => {
        if(option) {
            setSelectedRegion(option);
        }
    }

    return (
        <>
            <div onClick={handleOpenModal} className='bg-white hover:bg-white color-black hover:color-cyan cursor-pointer flex gap-1'>
                <FaLocationDot />
                <p>{region?.nameWithType}</p>
            </div>
            <Modal show={openModal} onClose={handleCloseModal} size="2xl">
                <Modal.Header>Выбор региона</Modal.Header>
                <Modal.Body>
                    <div className='min-h-[500px]'>
                        <Select
                            id="regionSelect"
                            options={options}
                            isSearchable={true}
                            placeholder="Выберите регион"
                            onChange={handleRegionChange}
                            isClearable={false}
                            value={selectedRegion}
                            loadingMessage={() => "Загрузка..."}
                            noOptionsMessage={() => "Ничего не найдено"}
                        />
                    </div>
                    <div className='flex justify-center'>
                        <Button onClick={handleSave} disabled={selectedRegion === null || isObjectEmpty(selectedRegion)}>Сохранить</Button>
                    </div>
                </Modal.Body>
            </Modal>
        </>
    );
}

export default RegionSelector
