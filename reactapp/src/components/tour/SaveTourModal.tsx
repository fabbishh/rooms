import { Button, Checkbox, Label, Modal, Radio, TextInput } from 'flowbite-react';
import React, { useEffect, useState } from 'react'
import { Controller, SubmitHandler, useForm } from 'react-hook-form';
import Select from 'react-select';
import api from '../../services/api/api';
import DatePicker from '../ui/DatePicker';
import { format } from 'date-fns';
import { ru } from 'date-fns/locale';
import { showNotification } from '../../utils/notificationManager';
import { seasonsData } from '../../data/Seasons';
import { getUsers } from '../../services/api/userService';
import StatusSelect from '../status/StatusSelect';
import ImageUploader from '../image/ImageUploader';
import { formatDateToRuLocale } from '../../utils/dateUtils';
import Editor from '../ui/Editor';
import TourTypeSelect from './TourTypeSelect';
import { isArraysEqual } from '../../utils/arrayUtils';

type SaveTourModalProps = {
    onSave: () => void,
    tourId?: string,
    mode: 'create' | 'update',
    role: 'admin' | 'tourAgencyAdmin',
    tourAgencyId?: string
}

interface IFormData {
    id: string,
    name: string,
    subject: string,
    isActive: boolean,
    days: number,
    startDates: any[],
    price: number,
    priceType: number,
    touristCountFrom: number,
    touristCountTo: number,
    type: string,
    tourAgencyId: string,
    description: string,
    seasons: number[],
    status: number,
    photos: File[]
}

const SaveTourModal = ({ onSave, mode, role, tourId, tourAgencyId }: SaveTourModalProps) => {

    const [openModal, setOpenModal] = useState(false);

    const [regionOptions, setRegionOptions] = useState<any[]>([]);
    const [tourAgencyOptions, setTourAgencyOptions] = useState<any[]>([]);


    const [startDates, setStartDates] = useState<any[]>([]);
    const [selectedDate, setSelectedDate] = useState<Date>();
    const [seasons, setSeasons] = useState<any[]>([]);

    const [initialPhotos, setInitialPhotos] = useState<any[]>([]);
    const [deletedPhotos, setDeletedPhotos] = useState<any[]>([]);

    const {
        control,
        setValue,
        handleSubmit,
        register,
        reset,
        getValues,
        formState: { errors }
    } = useForm<IFormData>()


    const onSubmit: SubmitHandler<IFormData> = async (data: any) => {
        try {
            if (startDates.length === 0) {
                return;
            }
            if (!validateCheckBoxes()) {
                return;
            }
            var formData = new FormData();
            for (var key in data) {
                if (key === "photos") {
                    data[key].forEach((photo: File) => {
                        formData.append("photos", photo);
                    })
                    continue;
                }
                if (key === "startDates") {
                    continue;
                }
                if (key === "seasons") {
                    continue;
                }
                formData.append(key, data[key]);
            }


            seasons.forEach((item) => {
                if (item.checked) {
                    formData.append("seasons", item.key);
                }
            });

            startDates.forEach((item, index) => {
                formData.append(`startDates[${index}]?.Id`, item.id);
                formData.append(`startDates[${index}].StartDate`, typeof item.startDate === "string" ? item.startDate : item.startDate.toISOString());
            });

            if (data.id) {
                deletedPhotos.forEach((photoId: string) => {
                    formData.append("deletedPhotos", photoId);
                })
            }

            var response = await api.post(role === 'admin' ? "/tour/save-by-admin" : "/tour", formData);
            if (role === 'admin') {
                if (mode === 'create') {
                    showNotification("success", "Тур создан");
                } else {
                    showNotification("success", "Тур обновлен");
                }
            } else {
                showNotification("success", "Тур отправлен на рассмотрение");
            }

            setOpenModal(false);
            reset();
            setStartDates([]);
            onSave();
        } catch (error: any) {
            showNotification("error", error.message);
        }
    }

    const handleCloseModal = () => {
        setOpenModal(false);
        reset();
        setStartDates([]);
    }

    const handleOpenModal = async () => {
        setOpenModal(true)

        const regionsResponse = await api.post("/region/get-list", { isActive: true })
        const regOptions = regionsResponse?.data?.map((item: any) => ({ value: item.id, label: item.nameWithType }));
        setRegionOptions(regOptions);



        if (role === "admin") {
            const agenciesResponse = await api.get("/tourAgency/list")
            const agenciesOptions = agenciesResponse?.data?.map((item: any) => ({ value: item.id, label: item.name }));
            setTourAgencyOptions(agenciesOptions);
        }

        setSeasons(seasonsData);

        if (mode === 'update') {
            try {
                const response = await api.get(`/tour/get-form-data/${tourId}`);
                reset(response.data);
                setInitialPhotos(response.data.photos.map((item: any) => ({ 'data_url': item.url, id: item.id })))
                const dates = response.data.startDates.map((item: any, index: number) => ({
                    key: index,
                    id: item.id,
                    startDate: item.startDate,
                    startDateName: formatDateToRuLocale(item.startDate)
                })
                );
                setStartDates(dates);

                const fetchedSeasons = response.data.seasons;
                const newSeasons = seasonsData.map((season: any) => {
                    if (fetchedSeasons.includes(season.key)) {
                        return { key: season.key, name: season.name, checked: true, disabled: false }
                    }
                    return season;
                })
                setSeasons(newSeasons);
            } catch (error: any) {
                showNotification("error", error.message);
            }
        }
    }

    useEffect(() => {
        if (tourAgencyId) {
            setValue('tourAgencyId', tourAgencyId);
        }
    }, [tourAgencyId])

    const handleStartDatesChange = () => {
        const dateName = format(selectedDate!, 'd MMMM yyyy', { locale: ru });
        if (!startDates.findIndex(d => d.startDateName === dateName)) {
            showNotification("warn", "Дата уже добавлена");
            return;
        }

        const dates = [...startDates, { key: startDates.length, id: null, startDateName: dateName, startDate: selectedDate! }];
        setStartDates(dates);
        console.log(startDates);
    }

    useEffect(() => {
        setValue("seasons", seasons.filter(s => s.checked === true).map(item => item.key));
    }, [seasons])

    useEffect(() => {
        setValue("startDates", startDates.map(date => ({ startDate: date.startDate, id: date.id })));
    }, [startDates])

    const handleImagesChange = (imageList: any) => {
        setValue("photos", imageList.map((image: any) => image.file));
    }

    const handleImageDelete = (item: any) => {
        if (item.hasOwnProperty("id")) {
            console.log(item.id)
            setDeletedPhotos([...deletedPhotos, item.id])
        }
    }

    const handleCheckboxChange = (clickedKey: number) => {
        var newSeasons = []
        if (clickedKey === 4) {
            const checked = seasons.find(s => s.key === 4)?.checked
            newSeasons = seasons.map((item) => {
                return { ...item, checked: !checked };
            });
        } else {
            newSeasons = seasons.map((item) => {
                if (item.key === clickedKey) {
                    return { ...item, checked: !item.checked };
                }

                return item;
            });
        }
        if (newSeasons[0].checked && newSeasons[1].checked && newSeasons[2].checked && newSeasons[3].checked) {
            newSeasons[4].checked = true;
        } else {
            newSeasons[4].checked = false;
        }
        setSeasons(newSeasons);
    };

    const validateCheckBoxes = () => {
        var checked = seasons.findIndex(s => s.checked);
        if (checked !== -1) {
            return true;
        }

        return false;
    }

    const renderTourAgencyField = () => {
        if (role === "admin") {
            return (
                <div>
                    <div className="mb-2 block">
                        <Label htmlFor="tourAgencyId" value="Турагенство" />
                    </div>
                    <Controller
                        control={control}
                        name="tourAgencyId"
                        rules={{
                            required: "Поле обязательно для заполнения",
                        }}
                        render={({
                            field: { onChange, value },
                            fieldState: { invalid, isTouched, isDirty, error },
                            formState,
                        }) => (
                            <Select
                                options={tourAgencyOptions}
                                isSearchable={true}
                                placeholder="Выберите турагенство"
                                value={tourAgencyOptions.find(u => u.value === value)}
                                onChange={(item: any) => setValue("tourAgencyId", item?.value)}
                                isClearable={true}
                                isDisabled={mode === "update"}
                                loadingMessage={() => "Загрузка..."}
                                noOptionsMessage={() => "Ничего не найдено"}
                            />
                        )}
                    />
                    <p className='text-red-500'>{errors?.tourAgencyId?.message}</p>
                </div>
            )
        }
    }

    return (
        <>
            <Button onClick={handleOpenModal}>{mode === 'create' ? 'Создать' : 'Редактировать'}</Button>
            <Modal show={openModal} onClose={handleCloseModal}>
                <Modal.Header>{mode === 'create' ? 'Добавление тура' : 'Редактирование тура'}</Modal.Header>
                <Modal.Body>
                    <form className="space-y-6" onSubmit={handleSubmit(onSubmit)}>
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
                        {renderTourAgencyField()}
                        <div>
                            <div className="mb-2 block">
                                <Label htmlFor="subject" value="Субъект" />
                            </div>
                            <Controller
                                control={control}
                                name="subject"
                                rules={{
                                    required: "Поле обязательно для заполнения"
                                }}
                                render={({
                                    field: { onChange, value },
                                    fieldState: { invalid, isTouched, isDirty, error },
                                    formState,
                                }) => (
                                    <Select
                                        options={regionOptions}
                                        isSearchable={true}
                                        placeholder="Выберите регион"
                                        value={regionOptions.find((t: any) => t.value === value)}
                                        onChange={(item: any) => setValue("subject", item?.value)}
                                        isClearable={true}
                                        loadingMessage={() => "Загрузка..."}
                                        noOptionsMessage={() => "Ничего не найдено"}
                                    />
                                )}
                            />
                            <p className='text-red-500'>{errors?.subject?.message}</p>
                        </div>

                        <div className="flex items-center gap-2">
                            <Controller
                                control={control}
                                name="isActive"
                                defaultValue={true}
                                render={({
                                    field: { onChange, value },
                                    fieldState: { invalid, isTouched, isDirty, error },
                                    formState,
                                }) => (
                                    <Checkbox
                                        id="isActive"
                                        checked={value}
                                        onChange={onChange}
                                    />

                                )}
                            />
                            <Label htmlFor="isActive">
                                Опубликовать
                            </Label>
                        </div>

                        <div>
                            <div className="mb-2 block">
                                <Label htmlFor="type" value="Вид" />
                            </div>
                            <Controller
                                control={control}
                                name="type"
                                rules={{
                                    required: "Поле обязательно для заполнения"
                                }}
                                render={({
                                    field: { onChange, value },
                                    fieldState: { invalid, isTouched, isDirty, error },
                                    formState,
                                }) => (
                                    <TourTypeSelect value={value} onChange={(item: any) => setValue("type", item?.value)} />
                                )}
                            />
                            <p className='text-red-500'>{errors?.type?.message}</p>
                        </div>

                        <div>
                            <div className="mb-2 block">
                                <Label htmlFor="seasons" value="Сезон" />
                            </div>
                            <Controller
                                control={control}
                                name="seasons"
                                render={({
                                    field: { onChange, value },
                                    fieldState: { invalid, isTouched, isDirty, error },
                                    formState,
                                }) => (
                                    <div className='flex gap-4'>
                                        {seasons.map((item: any) => (
                                            <div key={item.key} className='flex items-center gap-2'>
                                                <Checkbox
                                                    checked={item.checked}
                                                    disabled={item.disabled}
                                                    onChange={() => handleCheckboxChange(item.key)} />
                                                <Label >
                                                    {item.name}
                                                </Label>
                                            </div>
                                        ))}

                                    </div>
                                )}
                            />
                            {!validateCheckBoxes() && (
                                <p className='text-red-500'>Выберите хотя бы один сезон</p>
                            )}

                        </div>
                        <div>
                            <div className="mb-2 block">
                                <Label htmlFor="days" value="Продолжительность (дней)" />
                            </div>
                            <Controller
                                control={control}
                                name="days"
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
                            <p className='text-red-500'>{errors?.days?.message}</p>
                        </div>
                        <div>
                            <div className="mb-2 block">
                                <Label value="Туристов в группе" />
                            </div>
                            <div className='flex items-center gap-2'>
                                <p>От</p>
                                <Controller
                                    control={control}
                                    name="touristCountFrom"
                                    rules={{
                                        required: "Поле обязательно для заполнения"
                                    }}
                                    render={({
                                        field: { onChange, value },
                                        fieldState: { invalid, isTouched, isDirty, error },
                                        formState,
                                    }) => (
                                        <TextInput type="number" value={value} onChange={onChange} />
                                    )}
                                />

                                <p>до</p>
                                <Controller
                                    control={control}
                                    name="touristCountTo"
                                    rules={{
                                        required: "Поле обязательно для заполнения"
                                    }}
                                    render={({
                                        field: { onChange, value },
                                    }) => (
                                        <TextInput type="number" value={value} onChange={onChange} />
                                    )}
                                />

                            </div>
                            {(errors?.touristCountFrom || errors?.touristCountTo) && <p className='text-red-500'>Поля обязательны для заполнения</p>}
                        </div>
                        <div>
                            <div className="mb-2 block">
                                <Label value="Стоимость" />
                            </div>
                            <div className='flex gap-4'>
                                <div className="flex items-center gap-2">
                                    <Radio
                                        {...register("priceType")}
                                        value="0"
                                        defaultChecked
                                    />
                                    <Label >С туриста</Label>
                                </div>
                                <div className="flex items-center gap-2">
                                    <Radio {...register("priceType")} value="1" />
                                    <Label >С группы</Label>
                                </div>
                            </div>


                            <Controller
                                control={control}
                                name="price"
                                rules={{
                                    required: "Поле обязательно для заполнения"
                                }}
                                render={({
                                    field: { onChange, value },
                                }) => (
                                    <TextInput type="number" value={value} onChange={onChange} />
                                )}
                            />
                            <p className='text-red-500'>{errors?.price?.message}</p>
                        </div>
                        {role === "admin" && mode === 'update' &&
                            <div>
                                <div className="mb-2 block">
                                    <Label value="Статус" />
                                </div>
                                <Controller
                                    control={control}
                                    name="status"
                                    defaultValue={
                                        1
                                    }
                                    rules={{
                                        required: "Поле обязательно для заполнения"
                                    }}
                                    render={({
                                        field: { onChange, value },
                                        fieldState: { invalid, isTouched, isDirty, error },
                                        formState,
                                    }) => (
                                        <StatusSelect value={value} onChange={onChange} />
                                    )}
                                />
                                <p className='text-red-500'>{errors?.status?.message}</p>
                            </div>
                        }

                        <div>
                            <div className="mb-2 block">
                                <Label value="Ближайшие даты начала" />
                            </div>
                            <div>
                                <div className='flex gap-2'>
                                    <DatePicker onDateChange={(value) => setSelectedDate(value)} />
                                    <Button color="light" onClick={handleStartDatesChange} disabled={!selectedDate}>Добавить</Button>
                                </div>
                                <div id="dateList mt-6">
                                    <ul>
                                        {Array.isArray(startDates) && startDates.length === 0 && (
                                            <p className='text-red-500'>Выберите хотя бы одну дату</p>
                                        )}
                                        {startDates.map((item: any) => (
                                            <li key={item.key} className="flex gap-2">
                                                <p>{item.startDateName}</p>
                                                <button className="text-red-500 cursor-pointer" onClick={() => {
                                                    const newDates = startDates.filter(d => d.key !== item.key);
                                                    setStartDates(newDates);
                                                }}>Удалить</button>
                                            </li>
                                        ))}
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div className="mb-2 block">
                                <Label value="Фото" />
                            </div>
                            <ImageUploader multiple={true} maxNumber={10} onChange={handleImagesChange} onDelete={handleImageDelete} initialImages={initialPhotos} />
                        </div>

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
                                }) => (
                                    <Editor value={value} onChange={onChange} />
                                )}
                            />
                            <p className='text-red-500'>{errors?.description?.message}</p>
                        </div>

                        <div className="w-full flex justify-center">
                            <Button type="submit">Сохранить</Button>
                        </div>
                    </form>
                </Modal.Body>
            </Modal>
        </>
    )
}

export default SaveTourModal