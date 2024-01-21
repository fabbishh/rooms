import { Button, Label, Radio, TextInput } from 'flowbite-react'
import React, { useEffect } from 'react'
import { Controller, SubmitHandler, useForm } from 'react-hook-form'
import Input, { isValidPhoneNumber } from 'react-phone-number-input/input'
import api from '../../services/api/api'
import { format, parseISO } from 'date-fns'
import { showNotification } from '../../utils/notificationManager'
import RoleSelect from '../admin/users/RoleSelect'

interface IUserProfileFields {
    id: string,
    firstName: string,
    lastName: string,
    patronymic: string,
    birthday: string,
    phone: string,
    email: string,
    gender: number,
    role: number
}
type Props = {
    role: "admin" | "user",
    userId?: string,
    onSave?: any
}

const UserForm = ({role, userId, onSave}: Props) => {
    const {
        control,
        formState: { errors },
        setValue,
        handleSubmit,
        reset,
        getValues,
    } = useForm<IUserProfileFields>()

    useEffect(() => {
        const fetchData = async () => {
            try {
                let url = "";
				if(role === "admin") {
					if(!userId) {
						return;
					}
					url = `/user/${userId}`;
				} else {
					url = `/user/profile`
				}
                const response = await api.get(url);
                reset(response.data);
                setValue("birthday", format(parseISO(response.data.birthday), 'yyyy-MM-dd'));
            } catch (error: any) {

            }

        }

        fetchData();
    }, [])

    const onSubmit: SubmitHandler<IUserProfileFields> = async (data: any) => {
        try {
            if(role === "user") {
                var response = await api.post("/user/save-profile", data);
            }
            if(role === "admin") {
                var response = await api.post("/user/save-by-admin", data);
            }
            onSave?.()
            showNotification("success", "Данные обновлены")
        } catch (error: any) {
            //showNotification("error", "dddd");
        }
    }

    const renderRoleSelect = () => {
        if (role === "admin") {
            return (
                <div>
                    <div className="mb-2 block">
                        <Label htmlFor="status" value="Роль" />
                    </div>
                    <Controller
                        control={control}
                        name="role"
                        render={({
                            field: { onChange, value },
                            fieldState: { error },
                            formState,
                        }) => (
                            <RoleSelect value={value} onChange={onChange} />
                        )}
                    />
                </div>
            )
        }
    }

    return (
        <form className="space-y-6 max-w-[700px]" onSubmit={handleSubmit(onSubmit)}>
            <div className='flex flex-wrap gap-2'>
                <div className='grow max-w-[300px]'>
                    <div className="mb-2 block">
                        <Label htmlFor="lastName" value="Фамилия" />
                    </div>
                    <Controller
                        control={control}
                        name="lastName"
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
                    <p className='text-red-500'>{errors?.lastName?.message}</p>
                </div>
                <div className='grow max-w-[300px]'>
                    <div className="mb-2 block">
                        <Label htmlFor="firstName" value="Имя" />
                    </div>
                    <Controller
                        control={control}
                        name="firstName"
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
                    <p className='text-red-500'>{errors?.firstName?.message}</p>
                </div>


            </div>
            <div className='flex flex-wrap gap-2'>
                <div className='grow max-w-[300px]'>
                    <div className="mb-2 block">
                        <Label htmlFor="patronymic" value="Отчество" />
                    </div>
                    <Controller
                        control={control}
                        name="patronymic"
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
                    <p className='text-red-500'>{errors?.patronymic?.message}</p>
                </div>
                <div className='grow max-w-[300px]'>
                    <div className="mb-2 block">
                        <Label htmlFor="birthday" value="Дата рождения" />
                    </div>
                    <Controller
                        control={control}
                        name="birthday"
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
                                type="date"
                            />
                        )}
                    />
                    <p className='text-red-500'>{errors?.birthday?.message}</p>
                </div>
            </div>
            <div className='flex flex-wrap gap-2 items-center'>
                <Controller
                    control={control}
                    name="gender"
                    rules={{
                        required: "Поле обязательно для заполнения"
                    }}
                    render={({ field: { value, onChange } }) => (
                        <fieldset className="flex flex-wrap max-w-md gap-4">
                            <div className="flex items-center gap-2">
                                <Radio
                                    id="male"
                                    name="gender"
                                    value="0"
                                    checked={getValues().gender == 0}
                                    onChange={() => onChange(0)}
                                />
                                <Label htmlFor="male">Мужчина</Label>
                            </div>
                            <div className="flex items-center gap-2">
                                <Radio
                                    id="female"
                                    name="gender"
                                    value="1"
                                    checked={getValues().gender == 1}
                                    onChange={() => onChange(1)}
                                />
                                <Label htmlFor="female">Женщина</Label>
                            </div>
                        </fieldset>
                    )}
                />
                <p className='text-red-500'>{errors?.gender?.message}</p>
                
            </div>
            <div className='flex flex-wrap gap-2 '>
                <div className='grow max-w-[300px]'>
                    <div className="mb-2 block">
                        <Label htmlFor="phone" value="Номер телефона" />
                    </div>
                    <Controller
                        control={control}
                        name="phone"
                        rules={{
                            required: "Поле обязательно для заполнения",
                            validate: (value) => isValidPhoneNumber(value)
                        }}
                        render={({
                            field: { onChange, value },
                            fieldState: { invalid, isTouched, isDirty, error },
                            formState,
                        }) => (
                            <Input
                                country="RU"
                                international
                                withCountryCallingCode
                                value={value}
                                onChange={onChange}
                                inputComponent={TextInput}
                            />
                        )}
                    />
                    <p className='text-red-500'>{errors?.phone?.message}</p>
                    {
                        errors.phone && errors.phone.type === "validate" && (
                            <p className="text-red-500">Неверный формат номера телефона</p>
                        )
                    }
                </div>
                <div className='grow max-w-[300px]'>
                    <div className="mb-2 block">
                        <Label htmlFor="email" value="Email" />
                    </div>
                    <Controller
                        control={control}
                        name="email"
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
                                disabled={role === "user"}
                            />
                        )}
                    />
                    <p className='text-red-500'>{errors?.email?.message}</p>
                </div>
            </div>
            {renderRoleSelect()}
            <div className='flex justify-center'>
                <Button type="submit">Сохранить</Button>
            </div>
        </form>
    )
}

export default UserForm