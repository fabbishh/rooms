import React, { useEffect, useState } from 'react';
import PhotoUploader from '../ui/PhotoUploader';
import { Controller, SubmitHandler, useForm } from 'react-hook-form';
import api from '../../services/api/api';
import Select from 'react-select'
import { Button, Checkbox, Label, TextInput, Textarea } from 'flowbite-react';
import { showNotification } from '../../utils/notificationManager';
import ImageUploader from '../image/ImageUploader';
import Editor from '../ui/Editor';
import StatusSelect from '../status/StatusSelect';

interface IRoomFormFields {
    id?: string,
    name: string,
    sameRoomCount: number,
    minDaysReservation: number,
    roomType: number,
    bedroomCount: number,
    singleBedCount: number,
    doubleBedCount: number,
    pricePerNight: number,
    description: string,
    mealType: string,
    sanatoriumId: string,
    photos: File[],
    housingType: number,
    status: number
    //deletedPhotos?: string[]
}

interface Props {
    sanatoriumId?: string,
    roomGroupId?: string,
    onSave: () => void,
    isAdmin: boolean,
    type: "house" | "room"
}

const SaveRoomForm: React.FC<Props> = ({ sanatoriumId, roomGroupId, isAdmin, onSave, type }) => {
    const [initialPhotos, setInitialPhotos] = useState<any[]>([]);
    const [deletedPhotos, setDeletedPhotos] = useState<any[]>([]);

    const [comfortAttributes, setComfortAttributes] = useState<any[]>([])
    const [foodAttributes, setFoodAttributes] = useState<any[]>([])
    const [bathAttributes, setBathAttributes] = useState<any[]>([])
    const [sanatoriumOptions, setSanatoriumOptions] = useState<any[]>([])

    const {
        register,
        handleSubmit,
        setValue,
        reset,
        control,
        formState: { errors }
    } = useForm<IRoomFormFields>();

    useEffect(() => {

        const fetchBath = async () => {
            await api.get("/attribute/room-bathroom").then((response) => {
                const items = response.data?.map((item: any) => ({
                    attributeId: item.id,
                    name: item.name,
                    isActive: false
                }))
                setBathAttributes(items);
            })
        }

        const fetchFood = async () => {
            await api.get("/attribute/room-food").then((response) => {
                const items = response.data?.map((item: any) => ({
                    attributeId: item.id,
                    name: item.name,
                    isActive: false
                }))
                setFoodAttributes(items);
            })
        }

        const fetchComfort = async () => {
            await api.get("/attribute/room-comfort").then((response) => {
                const items = response.data?.map((item: any) => ({
                    attributeId: item.id,
                    name: item.name,
                    isActive: false
                }))
                setComfortAttributes(items);
            })
        }
        if (!roomGroupId) {
            fetchComfort();
            fetchFood();
            fetchBath();
        }
        if (sanatoriumId) {
            setValue("sanatoriumId", sanatoriumId);
        }

        if (!isAdmin) {
            setValue("status", 0);
        }

        const fetchSanatoriums = async () => {
            try {
                var response = await api.get("/sanatorium/list");
                if (response) {
                    const options = response.data?.map((item: any) => ({ value: item.id, label: item.name }));
                    setSanatoriumOptions(options);
                }
            } catch (error) {

            }
        }

        fetchSanatoriums();

        setValue("housingType", type === "room" ? 0 : 1);
    }, [roomGroupId])

    useEffect(() => {
        if (roomGroupId) {
            const fetchFormData = async () => {
                try {
                    const response = await api.get(`/room/get-form-data/${roomGroupId}`)
                    const { comfortAttributes, bathroomAttributes, foodAttributes, ...data } = response.data;
                    reset(data);
                    setInitialPhotos(response.data.photos.map((item: any) => ({ 'data_url': item.url, id: item.id })))

                    const comfort = response.data.comfortAttributes?.map((item: any) => ({
                        id: item.roomAttributeId,
                        attributeId: item.attributeId,
                        name: item.name,
                        isActive: item.isActive
                    }))
                    setComfortAttributes(comfort);

                    const food = response.data.foodAttributes?.map((item: any) => ({
                        id: item.roomAttributeId,
                        attributeId: item.attributeId,
                        name: item.name,
                        isActive: item.isActive
                    }))
                    setFoodAttributes(food);

                    const bath = response.data.bathroomAttributes?.map((item: any) => ({
                        id: item.roomAttributeId,
                        attributeId: item.attributeId,
                        name: item.name,
                        isActive: item.isActive
                    }))
                    setBathAttributes(bath);
                } catch (error: any) {
                    showNotification("error", error.message)
                }
            }

            fetchFormData();
        }

    }, [roomGroupId])

    const handleComfortCheckboxChange = (attributeId: string) => {
        const updatedCheckboxes = comfortAttributes.map((item) => {
            return item.attributeId === attributeId ? { name: item.name, isActive: !item.isActive, attributeId: item.attributeId, id: item.id } : item
        });

        setComfortAttributes(updatedCheckboxes);
    };

    const handleFoodCheckboxChange = (attributeId: string) => {
        const updatedCheckboxes = foodAttributes.map((item) => {
            return item.attributeId === attributeId ? { name: item.name, isActive: !item.isActive, attributeId: item.attributeId, id: item.id } : item
        });

        setFoodAttributes(updatedCheckboxes);
    };

    const handleBathCheckboxChange = (attributeId: string) => {
        const updatedCheckboxes = bathAttributes.map((item) => {
            return item.attributeId === attributeId ? { name: item.name, isActive: !item.isActive, attributeId: item.attributeId, id: item.id } : item
        });

        setBathAttributes(updatedCheckboxes);
    };

    const handleImagesChange = (imageList: any) => {
        setValue("photos", imageList.map((image: any) => image.file));
    }

    const handleImageDelete = (item: any) => {
        if (item.hasOwnProperty("id")) {
            console.log(item.id)
            setDeletedPhotos([...deletedPhotos, item.id])
        }
    }

    const onSubmit: SubmitHandler<IRoomFormFields> = async (data: any) => {
        try {
            var formData = new FormData();

            for (var key in data) {
                if (key === "photos") {
                    data[key].forEach((photo: File) => {
                        formData.append("photos", photo);
                    })
                    continue;
                }
                formData.append(key, data[key]);
            }

            comfortAttributes.forEach((attribute, index) => {
                formData.append(`ComfortAttributes[${index}].attributeId`, attribute.attributeId);
                formData.append(`ComfortAttributes[${index}].isActive`, attribute.isActive.toString());
                if (attribute.id) {
                    formData.append(`ComfortAttributes[${index}].roomAttributeId`, attribute.id);
                }
            })

            foodAttributes.forEach((attribute, index) => {
                formData.append(`FoodAttributes[${index}].attributeId`, attribute.attributeId);
                formData.append(`FoodAttributes[${index}].isActive`, attribute.isActive.toString());
                if (attribute.id) {
                    formData.append(`FoodAttributes[${index}].roomAttributeId`, attribute.id);
                }
            })

            bathAttributes.forEach((attribute, index) => {
                formData.append(`BathroomAttributes[${index}].attributeId`, attribute.attributeId);
                formData.append(`BathroomAttributes[${index}].isActive`, attribute.isActive.toString());
                if (attribute.id) {
                    formData.append(`BathroomAttributes[${index}].roomAttributeId`, attribute.id);
                }
            })

            if (data.id) {
                deletedPhotos.forEach((photoId: string) => {
                    formData.append("deletedPhotos", photoId);
                })

                var response = await api.post("/room/UpdateMany", formData);
            } else {
                var response = await api.post("/room/CreateMany", formData);
            }

            showNotification("success", "Комната отправлена на рассмотрение");
            onSave();
        } catch (error: any) {
            showNotification("error", error.message);
        }
    }

    const renderSanatoriumSelect = () => {
        if (isAdmin) {
            return (
                <div>
                    <div className="mb-2 block">
                        <Label htmlFor="sanatoriumId" value="Санаторий" />
                    </div>
                    <Controller
                        control={control}
                        name="sanatoriumId"
                        rules={{
                            required: "Поле обязательно для заполнения"
                        }}
                        render={({
                            field: { onChange, value },
                            fieldState: { invalid, isTouched, isDirty, error },
                            formState,
                        }) => (
                            <Select
                                options={sanatoriumOptions}
                                isSearchable={true}
                                placeholder="Выберите санаторий"
                                value={sanatoriumOptions.find(t => t.value === value)}
                                onChange={(item: any) => setValue("sanatoriumId", item?.value)}
                                isClearable={true}
                                loadingMessage={() => "Загрузка..."}
                                noOptionsMessage={() => "Ничего не найдено"}
                            />
                        )}
                    />
                    <p className='text-red-500'>{errors?.sanatoriumId?.message}</p>
                </div>

            )
        }
    }

    const renderRoomTypes = () => {
        if (type === "room") {
            return (
                <div>
                    <div className="mb-2 block">
                        <Label htmlFor="roomType" value="Тип" />
                    </div>
                    <select id="roomType" {...register('roomType')}>
                        <option value="0">Личная комната</option>
                        <option value="1">Комната с подселением</option>
                    </select>
                </div>
            )
        }

        if (type === "house") {
            return (
                <div>
                    <div className="mb-2 block">
                        <Label htmlFor="roomType" value="Тип" />
                    </div>
                    <select id="roomType" {...register('roomType')}>
                        <option value="2">Гостевой дом</option>
                        <option value="3">Таунхаус</option>
                    </select>
                </div>
            )
        }
    }

    const renderStatusSelect = () => {
        if (isAdmin) {
            return (
                <div>
                    <div className="mb-2 block">
                        <Label htmlFor="status" value="Изменить статус" />
                    </div>
                    <Controller
                        control={control}
                        name="status"
                        defaultValue={
                            1
                        }
                        render={({
                            field: { onChange, value },
                            fieldState: { error },
                            formState,
                        }) => (
                            <StatusSelect value={value} onChange={onChange} />
                        )}
                    />
                </div>
            )
        }
    }

    return (
        <form onSubmit={handleSubmit(onSubmit)} className="space-y-6">
            <div>
                <div className="mb-2 block">
                    <Label htmlFor="name" value="Название" />
                </div>

                <Controller
                    control={control}
                    name="name"
                    rules={{
                        required: "Поле обязательно для заполнения"
                    }}
                    render={({
                        field: { onChange, value },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <TextInput
                            value={value}
                            onChange={onChange}
                        />
                    )}
                />
                <p className='text-red-500'>{errors?.name?.message}</p>
            </div>

            <div>
                <div className="mb-2 block">
                    <Label htmlFor="sameRoomCount" value="Количество комнат" />
                </div>
                <Controller
                    control={control}
                    name="sameRoomCount"
                    rules={{
                        required: "Поле обязательно для заполнения"
                    }}
                    render={({
                        field: { onChange, value },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <TextInput
                            type="number"
                            value={value}
                            onChange={onChange}
                        />
                    )}
                />
                <p className='text-red-500'>{errors?.sameRoomCount?.message}</p>
            </div>

            {renderSanatoriumSelect()}

            {renderRoomTypes()}

            <div>
                <div className="mb-2 block">
                    <Label htmlFor="bedroomCount" value="Количество спален" />
                </div>
                <Controller
                    control={control}
                    name="bedroomCount"
                    rules={{
                        required: "Поле обязательно для заполнения",
                        max: {
                            value: 5,
                            message: "Максимум 5 спален"
                        }
                    }}
                    render={({
                        field: { onChange, value },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <TextInput
                            type="number"
                            value={value}
                            onChange={onChange}
                        />
                    )}
                />
                <p className='text-red-500'>{errors?.bedroomCount?.message}</p>
            </div>

            <div>
                <div className="mb-2 block">
                    <Label htmlFor="singleBedCount" value="Количество одноместных спальных мест" />
                </div>
                <Controller
                    control={control}
                    name="singleBedCount"
                    rules={{
                        required: "Поле обязательно для заполнения"
                    }}
                    render={({
                        field: { onChange, value },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <TextInput
                            type="number"
                            value={value}
                            onChange={onChange}
                        />
                    )}
                />
                <p className='text-red-500'>{errors?.singleBedCount?.message}</p>
            </div>

            <div>
                <div className="mb-2 block">
                    <Label htmlFor="doubleBedCount" value="Количество двухместных спальных мест" />
                </div>
                <Controller
                    control={control}
                    name="doubleBedCount"
                    rules={{
                        required: "Поле обязательно для заполнения"
                    }}
                    render={({
                        field: { onChange, value },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <TextInput
                            type="number"
                            value={value}
                            onChange={onChange}
                        />
                    )}
                />
                <p className='text-red-500'>{errors?.doubleBedCount?.message}</p>
            </div>

            <div>
                <div className="mb-2 block">
                    <Label htmlFor="bathroomType" value="Cанузел" />
                </div>
                <div className="flex gap-4">
                    {bathAttributes?.map((attribute) => (
                        <div key={attribute.attributeId} className="flex items-center gap-2">
                            <Checkbox
                                name="comfort"
                                checked={attribute.isActive}
                                onChange={(e) => handleBathCheckboxChange(attribute.attributeId)}
                            />
                            <Label htmlFor="age">{attribute.name}</Label>
                        </div>
                    ))}
                </div>
            </div>

            <div>
                <div className="mb-2 block">
                    <Label htmlFor="mealType" value="Питание" />
                </div>
                <div className="flex gap-4">
                    {foodAttributes?.map((attribute) => (
                        <div key={attribute.attributeId} className="flex items-center gap-2">
                            <Checkbox
                                name="comfort"
                                checked={attribute.isActive}
                                onChange={(e) => handleFoodCheckboxChange(attribute.attributeId)}
                            />
                            <Label htmlFor="age">{attribute.name}</Label>
                        </div>
                    ))}
                </div>
            </div>

            <div>
                <div className="mb-2 block">
                    <Label htmlFor="comfort" value="Комфорт" />
                </div>
                <div className="flex gap-4">
                    {comfortAttributes?.map((attribute) => (
                        <div key={attribute.attributeId} className="flex items-center gap-2">
                            <Checkbox
                                name="comfort"
                                checked={attribute.isActive}
                                onChange={(e) => handleComfortCheckboxChange(attribute.attributeId)}
                            />
                            <Label htmlFor="age">{attribute.name}</Label>
                        </div>
                    ))}
                </div>
            </div>

            <div>
                <div className="mb-2 block">
                    <Label htmlFor="pricePerNight" value="Цена за ночь" />
                </div>
                <Controller
                    control={control}
                    name="pricePerNight"
                    rules={{
                        required: "Поле обязательно для заполнения"
                    }}
                    render={({
                        field: { onChange, value },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <TextInput
                            type="number"
                            value={value}
                            onChange={onChange}
                        />
                    )}
                />
                <p className='text-red-500'>{errors?.pricePerNight?.message}</p>
            </div>

            <div>
                <div className="mb-2 block">
                    <Label htmlFor="minDaysReservation" value="Минимальное количество дней для брони" />
                </div>
                <Controller
                    control={control}
                    name="minDaysReservation"
                    rules={{
                        required: "Поле обязательно для заполнения"
                    }}
                    render={({
                        field: { onChange, value },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <TextInput
                            type="number"
                            value={value}
                            onChange={onChange}
                        />
                    )}
                />
                <p className='text-red-500'>{errors?.minDaysReservation?.message}</p>
            </div>

            {renderStatusSelect()}

            <div>
                <div className="mb-2 block">
                    <Label htmlFor="description" value="Описание" />
                </div>
                <Controller
                    control={control}
                    name="description"
                    rules={{
                        required: "Поле обязательно для заполнения"
                    }}
                    render={({
                        field: { onChange, value },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <Editor value={value} onChange={onChange} />
                    )}
                />
                <p className='text-red-500'>{errors?.description?.message}</p>
            </div>

            <div className=''>
                <ImageUploader multiple={true} maxNumber={10} onChange={handleImagesChange} onDelete={handleImageDelete} initialImages={initialPhotos} />
            </div>

            <div className="flex justify-center">
                <Button type="submit">
                    Сохранить
                </Button>
            </div>
        </form>
    );
};

export default SaveRoomForm;

