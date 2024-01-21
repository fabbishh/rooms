import { useEffect, useState } from 'react'
import { Controller, SubmitHandler, useForm } from 'react-hook-form';
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';
import CustomTimePicker from '../../ui/CustomTimePicker';
import { Button, Label, TextInput } from 'flowbite-react';
import { AddressSuggestions, DaDataAddress, DaDataSuggestion } from 'react-dadata';
import { getUsers } from '../../../services/api/userService';
import Select from 'react-select';
import ImageUploader from '../../image/ImageUploader';
import { getSanatoriumSeasonOptions } from '../../../services/api/sanatoriumSeasons';
import StatusSelect from '../../status/StatusSelect';

type SaveSanatoriumFormProps = {
    sanatoriumId?: string,
    role: 'admin' | 'sanatoriumAdmin',
    onSave?: () => void
}

interface ISanatoriumProfileFields {
    id?: string
    name: string,
    email: string,
    objectType: string,
    subjectId: string,
    location?: DaDataSuggestion<DaDataAddress>;
    season: number,
    checkInTime: string,
    checkOutTime: string,
    ownerId?: string,
    photo: File,
    status: number
}

const SaveSanatoriumForm = ({ sanatoriumId, role, onSave }: SaveSanatoriumFormProps) => {
    const [userOptions, setUserOptions] = useState<any[]>([]);
    const [typeOptions, setTypeOptions] = useState<any[]>([]);
    const [seasonOptions, setSeasonOptions] = useState<any[]>([]);
    const [regionOptions, setRegionOptions] = useState<any[]>([]);
    const [photoData, setPhotoData] = useState<any>();

    const {
        control,
        formState: { errors },
        setValue,
        handleSubmit,
        reset,
        getValues,
        watch
    } = useForm<ISanatoriumProfileFields>()

    const onSubmit: SubmitHandler<ISanatoriumProfileFields> = async (data: any) => {
        const formData = new FormData();

        for (var key in data) {
            if (key === "location") {
                formData.append(key, data[key].value);
                continue;
            }

            formData.append(key, data[key]);
        }

        try {
            await api.post(role === 'admin' ? '/sanatorium/save-by-admin' : '/sanatorium/save', formData);
            showNotification("success", "Данные сохранены");
            onSave?.();
        } catch (error: any) {
            showNotification("error", error.message);
        }
    }

    useEffect(() => {
        const fetchSanatoriumData = async () => {
            if (sanatoriumId) {
                try {
                    const response = await api.get(`/sanatorium/GetSanatoriumProfileData/${sanatoriumId}`)
                    const data = {
                        ...response.data, location: {
                            value: response.data.location,
                            unrestricted_value: null,
                            data: null
                        }
                    };
                    reset(data);
                    setValue("location", { value: response.data.location, unrestricted_value: null!, data: null! });
                    setPhotoData(response.data?.photoUrl);
                } catch (error: any) {
                    showNotification("error", error.message);
                }
            }
        }

        const fetchUsers = async () => {
            const users = await getUsers();
            const options = users?.map((item: any) => ({ value: item.id, label: item.email }))
            setUserOptions(options);
        }

        const fetchSanatoriumTypes = async () => {
            try {
                const response = await api.get("/sanatoriumTypes/get-list");
                const options = response.data.map((item: any) => ({ value: item.id, label: item.name }))
                setTypeOptions(options);
            } catch (error: any) {
                showNotification("error", error.message);
            }
        }

        const fetchRegionOptions = async () => {
            try {
                const regionsResponse = await api.post("/region/get-list", { isActive: true })
                const regOptions = regionsResponse.data.map((item: any) => ({ value: item.id, label: item.nameWithType, name: item.name }));
                setRegionOptions(regOptions);
            } catch (error: any) {
                showNotification("error", error.message);
            }
        }

        fetchSanatoriumData();
        fetchSanatoriumTypes();
        const seasonOptions = getSanatoriumSeasonOptions();
        setSeasonOptions(seasonOptions);
        fetchRegionOptions();


        if (role === 'admin') {
            fetchUsers();
        }
    }, [sanatoriumId])

    const onPhotoChange = (imageList: any) => {
        setValue("photo", imageList[0].file);
        setPhotoData(imageList[0].data_url);
    }

    const renderStatusSelect = () => {
        if (role === "admin") {
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
        <form className="space-y-6 max-w-[700px]" onSubmit={handleSubmit(onSubmit)}>
            <div className="flex flex-wrap gap-5">
                <div className="space-y-6 grow">
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

                    <div className="mb-4">
                        <div className="mb-2 block">
                            <Label htmlFor="objectType" value="Тип объекта" />
                        </div>
                        <Controller
                            control={control}
                            name="objectType"
                            rules={{
                                required: "Поле обязательно для заполнения"
                            }}
                            render={({
                                field: { onChange, value },
                                fieldState: { invalid, isTouched, isDirty, error },
                                formState,
                            }) => (
                                <Select
                                    options={typeOptions}
                                    isSearchable={true}
                                    placeholder="Выберите тип объекта"
                                    value={typeOptions.find(t => t.value === value)}
                                    onChange={(item: any) => setValue("objectType", item?.value)}
                                    isClearable={true}
                                    loadingMessage={() => "Загрузка..."}
                                    noOptionsMessage={() => "Ничего не найдено"}
                                />
                            )}
                        />
                        <p className='text-red-500'>{errors?.objectType?.message}</p>
                    </div>
                </div>
                <div className='h-[134px] w-[134px] items-center mt-8'>
                    <ImageUploader multiple={false} initialImages={photoData ? [{ 'data_url': photoData }] : []} onChange={onPhotoChange} />
                </div>
            </div>


            <div>
                <div className="mb-2 block">
                    <Label htmlFor="email" value="Email" />
                </div>
                <Controller
                    control={control}
                    name="email"
                    rules={{
                        required: "Поле обязательно для заполнения",
                        pattern: {
                            value: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
                            message: "Неверный формат электронной почты"
                        }
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
                <p className='text-red-500'>{errors?.email?.message}</p>
            </div>

            {role === 'admin' &&
                <div>
                    <div className="mb-2 block">
                        <Label htmlFor="ownerId" value="Владелец" />
                    </div>
                    <Controller
                        control={control}
                        name="ownerId"
                        rules={{
                            required: "Поле обязательно для заполнения",
                        }}
                        render={({
                            field: { onChange, value },
                            fieldState: { invalid, isTouched, isDirty, error },
                            formState,
                        }) => (
                            <Select
                                options={userOptions}
                                isSearchable={true}
                                placeholder="Выберите пользователя"
                                value={userOptions.find(u => u.value === value)}
                                onChange={(item: any) => setValue("ownerId", item?.value)}
                                isClearable={true}
                                loadingMessage={() => "Загрузка..."}
                                noOptionsMessage={() => "Ничего не найдено"}
                            />
                        )}
                    />
                    <p className='text-red-500'>{errors?.ownerId?.message}</p>
                </div>}

            <div>
                <div className="mb-2 block">
                    <Label htmlFor="subject" value="Субъект" />
                </div>
                <Controller
                    control={control}
                    name="subjectId"
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
                            onChange={(item: any) => {
                                setValue("subjectId", item?.value);
                                setValue("location", undefined);
                            }}
                            isClearable={true}
                            loadingMessage={() => "Загрузка..."}
                            noOptionsMessage={() => "Ничего не найдено"}
                        />
                    )}
                />
                <p className='text-red-500'>{errors?.subjectId?.message}</p>
            </div>
            {/* Адрес */}
            <div>
                <div className="mb-2 block">
                    <Label htmlFor="location" value="Адрес" />
                </div>
                <Controller
                    name="location"
                    control={control}
                    rules={{
                        required: "Поле обязательно для заполнения",
                        minLength: {
                            value: 3,
                            message: "Поле обязательно для заполнения"
                        }
                    }}
                    render={({
                        field: { onChange, value, onBlur },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <AddressSuggestions
                            token={process.env.REACT_APP_DADATA_API_KEY!}
                            value={value}
                            filterLocations={[{ "region": regionOptions.find(r => r.value === getValues().subjectId)?.name }]}
                            onChange={onChange}
                            selectOnBlur={true}
                            inputProps={{
                                disabled: !watch("subjectId"),
                                onChange: (event: any) => {
                                    if (event.target.value == "") {
                                        setValue("location", undefined)
                                    }
                                },
                                // onBlur: (event: any) => {
                                //     if(getValues().location?.value) {
                                //         event.target.value = getValues().location?.value
                                //     } else {
                                //         event.target.value = undefined
                                //     }
                                // },
                            }}
                            httpCache={false}
                        />
                    )}
                />
                <p className='text-red-500'>{errors?.location?.message}</p>
            </div>

            {/* Время */}
            <div className="mb-4">
                <div className='flex flex-wrap gap-4'>
                    <div className='checkInTime'>
                        <div className="mb-2 block">
                            <Label htmlFor="checkInTime" value="Время заселения" />
                        </div>
                        <Controller
                            name="checkInTime"
                            control={control}
                            defaultValue='10:00'
                            rules={{
                                validate: {
                                    required: (value) => {
                                        if (!value) {
                                            return "Поле обязательно для заполнения"
                                        }
                                        if (value <= getValues().checkOutTime) {
                                            return "Заселение осуществляется после выселения"
                                        }
                                    }
                                }
                            }}
                            render={({
                                field: { onChange, value },
                                fieldState: { invalid, isTouched, isDirty, error },
                                formState,
                            }) => (
                                <CustomTimePicker
                                    value={value}
                                    onChange={onChange} />
                            )}
                        />
                    </div>
                    <div className="checkOutTime">
                        <div className="mb-2 block">
                            <Label htmlFor="checkOutTime" value="Время выселения" />
                        </div>
                        <Controller
                            name="checkOutTime"
                            defaultValue='10:00'
                            control={control}
                            rules={{
                                required: "Поле обязательно для заполнения",
                            }}
                            render={({
                                field: { onChange, value },
                                fieldState: { invalid, isTouched, isDirty, error },
                                formState,
                            }) => (
                                <CustomTimePicker
                                    value={value}
                                    //onChange={(value: any) => setValue("checkOutTime", value)} 
                                    onChange={onChange} />
                            )}
                        />
                    </div>
                </div>

                <p className='text-red-500'>{errors?.checkInTime?.message}</p>
            </div>



            {/* Сезон */}
            <div>
                <div className="mb-2 block">
                    <Label htmlFor="days" value="Сезон" />
                </div>
                <Controller
                    control={control}
                    name="season"
                    rules={{
                        required: "Поле обязательно для заполнения",

                    }}
                    render={({
                        field: { onChange, value },
                        fieldState: { invalid, isTouched, isDirty, error },
                        formState,
                    }) => (
                        <Select
                            options={seasonOptions}
                            isSearchable={true}
                            placeholder="Выберите сезон"
                            value={seasonOptions.find(u => u.value === value)}
                            onChange={(item: any) => setValue("season", item?.value)}
                            isClearable={true}
                            loadingMessage={() => "Загрузка..."}
                            noOptionsMessage={() => "Ничего не найдено"}
                        />
                    )}
                />
                <p className='text-red-500'>{errors?.season?.message}</p>
            </div>
            {renderStatusSelect()}


            <div className='flex justify-center'>
                <Button type="submit">Сохранить</Button>
            </div>

        </form>
    )
}

export default SaveSanatoriumForm