import React, { useEffect, useState } from 'react';
import AsyncSelect from 'react-select/async';
import api from '../../../services/api/api';
import useSanatoriumInfo from '../../../hooks/useSanatoriumInfo';
import { showNotification } from '../../../utils/notificationManager';
import { Button } from 'flowbite-react';

interface Option {
    value: string;
    label: string;
}

interface Place {
    id: string;
    name: string;
    sanatoriumPlaceId?: string
}

const SanatoriumPlacesTab = () => {
    const [selectedPlace, setSelectedPlace] = useState<Option | null>(null);
    const [places, setPlaces] = useState<Place[]>([]);

	const { sanatoriumInfo } = useSanatoriumInfo();

    useEffect(() => {
        if(sanatoriumInfo.id) {
            api.post("/place/getPaged", { pageNumber: 1, pageSize: 1000, query: '', filter: { sanatoriumId: sanatoriumInfo.id} })
            .then((response) => {
                setPlaces(response.data.items);
            })
        }
       
    }, [sanatoriumInfo.id])

    const loadOptions = async (inputValue: string) => {
        try {
            const response = await api.post("/place/getPaged", { pageNumber: 1, pageSize: 1000, query: inputValue })
            const items = response.data.items;

            const options = items.map((item: { id: any; name: any; }) => ({ value: item.id, label: item.name }));
            return options;
        } catch (error) {
            console.error('Error loading options:', error);
        }
    };

    const handleAddPlace = async () => {
        if (selectedPlace) {
            try {
                const newPlace =  {
                    id: selectedPlace.value,
                    name: selectedPlace.label,
                    sanatoiumPlaceId: null
                }
                const updatedPlaces = [...places, newPlace]
                setPlaces(updatedPlaces);
                setSelectedPlace(null);
            } catch (error) {
                console.error('Error creating binding:', error);
            }
        } else {
            console.log('Please select a place before adding.');
        }
    };

    const handleRemovePlace = (placeToRemove: Place) => {
        const updatedPlaces = places.filter(place => place.id !== placeToRemove.id);
        setPlaces(updatedPlaces);
    };

    const handleSaveData = async () => {
        try {
            const placesData = places.map((item) => ({placeId: item.id, sanatoriumPlaceId: item.sanatoriumPlaceId}))
            const response = await api.post("/place/UpdateSanatoriumPlaces", {
                sanatoriumId: sanatoriumInfo.id,
                sanatoriumPlaces: placesData
            })
            showNotification("success", "Информация обновлена!")
        } catch (error) {
            
        }
    }

    return (
        <div className='mx-24'>
            <div className='flex mb-5 gap-4'>
                <div className='w-[200px]'>
                    <AsyncSelect<Option>
                        loadOptions={loadOptions}
                        defaultOptions
                        isSearchable
                        placeholder="Выберите место"
                        onChange={(value) => setSelectedPlace(value)}
                        loadingMessage={() => "Загрузка..."}
                        noOptionsMessage={() => "Ничего не найдено"}
                    />
                </div>
                
                <Button color="light" onClick={handleAddPlace}>Добавить</Button>
            </div>
            <div>
                <h2>Добавленные места</h2>
                {places.map(place => (
                    <div key={place.id} className="flex items-center justify-between border p-2 mb-2 max-w-[500px]">
                        <div>{place.name}</div>
                        <Button  onClick={() => handleRemovePlace(place)} color="failure" >Удалить</Button>
                    </div>
                )
                )}
            </div>
            <Button onClick={handleSaveData}>Сохранить</Button>
        </div>

    );
}

export default SanatoriumPlacesTab;