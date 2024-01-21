import { Button, Card, Checkbox, Label, TextInput } from 'flowbite-react';
import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import Counter from '../components/ui/Counter';
import { Controller, SubmitHandler, useForm } from 'react-hook-form';
import api from '../services/api/api';
import { showNotification } from '../utils/notificationManager';
import 'react-phone-number-input/style.css'
import Input, { isValidPhoneNumber } from 'react-phone-number-input/input'
import { getDatesBetween } from '../utils/dateUtils';
import CustomDateRangePicker from '../components/ui/CustomDateRangePicker';
import { useAuth } from '../context/AuthContext';


type RoomReservePageProps = {}

interface IReservationFormFields {
    dateRange: [{
        startDate: Date,
        endDate: Date,
        key: 'selection'
    }]
    firstName: string,
    lastName: string,
    patronymic: string,
    phone: string,
    isAuthorGuest: boolean,
    adultGuestsCount: number,
    childGuestsCount: number,
    roomId: string,
    email: string
}

const RoomReservePage = (props: RoomReservePageProps) => {
    const { roomId } = useParams();
    const [disablesDates, setDisabledDates] = useState<Date[]>([]);
    const { authenticated } = useAuth();

    const {
        register,
        handleSubmit,
        watch,
        setValue,
        reset,
        control,
        formState: { errors },
    } = useForm<IReservationFormFields>({
        mode: "onBlur"
    });

    register('roomId');

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await api.get(`/reservation/GetDisabledDatesForRoom/${roomId}`);
                if (response.data.length !== 0) {
                    const dates = response.data.reduce((result: Date[], { start, end }: any) => {
                        const datesInRange = getDatesBetween(new Date(start), new Date(end));
                        return [...result, ...datesInRange];
                    }, []);

                    setDisabledDates(dates);
                }
            } catch (error: any) {
                showNotification('error', error.message);
            }
        }

        setValue('roomId', roomId!);
        fetchData();
    }, [roomId, setValue])

    useEffect(() => {
        const fetchUser = async () => {
            try {
                if(authenticated) {
                    const response = await api.get("/user/profile");
                    var data = { 
                        firstName: response.data?.firstName, 
                        lastName: response.data?.firstName, 
                        patronymic: response.data?.patronymic,
                        phone: response.data?.phone, 
                        roomId: roomId
                    }
                    reset(data)
                }
            } catch (error) {
                
            }
        }

        fetchUser();
    }, [authenticated])

    const onSubmit: SubmitHandler<IReservationFormFields> = async (data) => {
        try {
            const { dateRange, ...formData } = { ...data, startDate: data.dateRange[0].startDate, endDate: data.dateRange[0].endDate }
            //console.log(formData);
            if(authenticated) {
                var response = await api.post("/reservation/CreateAuthorized", formData);
            } else {
                var response = await api.post("/reservation/CreateUnauthorized", formData);
            }
            
            showNotification("success", "Бронирование отправлено на рассмотрение");
        } catch (error: any) {
            showNotification("error", error.message);
        }

    }

    const handleDateRangeChange = (item: any) => {
        setValue("dateRange", [item.selection]);
    }

    return (
        <div className="container mt-8 p-4 min-h-screen mx-auto max-w-xl">
            <Card >
                <form className="flex flex-col gap-2" onSubmit={handleSubmit(onSubmit)}>
                    <div className="items-center gap-4 border-b p-4">
                        <div className='flex justify-center mb-4'>
                            <Controller
                                name="dateRange"
                                control={control}
                                defaultValue={[{
                                    startDate: new Date(),
                                    endDate: new Date(),
                                    key: 'selection'
                                }]}
                                render={({
                                    field: { value },
                                }) => (
                                    <CustomDateRangePicker
                                        value={value}
                                        onChange={handleDateRangeChange}
                                        disabledDates={disablesDates}
                                    />
                                )}
                            />
                        </div>
                        <div className='flex justify-center gap-4'>
                            <div className='max-w-[110px]'>
                                <span>Взрослые</span>
                                <Controller
                                    name="adultGuestsCount"
                                    control={control}
                                    defaultValue={1}
                                    render={({
                                        field: { onChange, value },
                                    }) => (
                                        <Counter onCountChange={onChange} value={value} />
                                    )}
                                />
                            </div>

                            <div className='max-w-[110px]'>
                                <span>Дети</span>
                                <Controller
                                    name="childGuestsCount"
                                    control={control}
                                    defaultValue={0}
                                    render={({
                                        field: { onChange, value },
                                    }) => (
                                        <Counter onCountChange={onChange} value={value} />
                                    )}
                                />
                            </div>
                        </div>
                    </div>
                    <h5>Автор брони</h5>
                    <div>
                        <div className="mb-2 block">
                            <Label htmlFor="firstName" value="Имя" />
                        </div>

                        <TextInput {...register("firstName", { required: "Поле обязательно к заполнению" })} />
                        <div className='h-[20px]'>
                            {errors?.firstName && <p className='text-red-500'>{errors?.firstName?.message}</p>}
                        </div>
                    </div>
                    <div>
                        <div className="mb-2 block">
                            <Label htmlFor="lastName" value="Фамилия" />
                        </div>
                        <TextInput {...register("lastName", { required: "Поле обязательно к заполнению" })} />
                        <div className='h-[20px]'>
                            {errors?.lastName && <p className='text-red-500'>{errors?.lastName?.message}</p>}
                        </div>
                    </div>
                    <div>
                        <div className="mb-2 block">
                            <Label htmlFor="patronymic" value="Отчество" />
                        </div>
                        <TextInput {...register("patronymic", { required: "Поле обязательно к заполнению" })} />
                        <div className='h-[20px]'>
                            {errors?.patronymic && <p className='text-red-500'>{errors?.patronymic?.message}</p>}
                        </div>
                    </div>

                    {!authenticated && <div>
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
                        <div className='h-[20px]'>
                            {errors?.email && <p className='text-red-500'>{errors?.email?.message}</p>}
                        </div>
                    </div>}

                    <div>
                        <div className="mb-2 block">
                            <Label htmlFor="phone" value="Телефон для связи" />
                        </div>
                        {/* <TextInput {...register("phone", { required: "Поле обязательно к заполнению" })}/> */}
                        <Controller
                            name="phone"
                            control={control}
                            rules={{
                                required: "Поле обязательно для заполнения",
                                validate: (value) => isValidPhoneNumber(value)
                            }}
                            render={({ field: { value, onChange } }) => (
                                <Input
                                    placeholder="+71234567890"
                                    country="RU"
                                    international
                                    withCountryCallingCode
                                    onChange={onChange}
                                    value={value}
                                    inputComponent={TextInput} />
                            )}
                        />

                        <div className='h-[20px]'>
                            {errors?.phone && <p className='text-red-500'>Неверный формат номера телeфона</p>}
                        </div>
                    </div>

                    <div className="flex items-center gap-2">
                        <Controller
                            name="isAuthorGuest"
                            control={control}
                            rules={{ required: false }}
                            defaultValue={false}
                            render={({ field: { value, onChange } }) => <Checkbox checked={value} onChange={onChange} />}
                        />
                        <Label htmlFor="isAuthorGuest">Я гость</Label>
                    </div>
                    <Button type="submit">Забронировать</Button>
                </form>
            </Card>

        </div>
    )
}

export default RoomReservePage