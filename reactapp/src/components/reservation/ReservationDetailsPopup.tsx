import { Button, Label, Modal, Select, Textarea } from 'flowbite-react';
import React, { useEffect, useState } from 'react'
import api from '../../services/api/api';
import { Controller, SubmitHandler, useForm } from 'react-hook-form';
import { Status } from '../../shared/app.enums';
import { ConvertReservationStatusToRuLocale } from '../../utils/enumUtils';
import { showNotification } from '../../utils/notificationManager';
import StatusSelect from '../status/StatusSelect';

type ReservationDetailsProps = {
    reservationId: string,
    onSave: () => void;
}

interface Guest {
    id: string,
    firstName: string,
    lastName: string,
    patronymic: string,
}

interface ReservationDetails {
    id?: string,
    author?: { id: string, firstName: string, lastName: string, patronymic: string, email: string, phoneNumber: string },
    guestComment?: string,
    roomName?: string,
    guests?: Guest[]
}

interface FormFields {
    id: string,
    comment: string,
    status: Status
}

const ReservationDetailsPopup = ({ reservationId, onSave }: ReservationDetailsProps) => {
    const [openModal, setOpenModal] = useState(false);
    const [reservation, setReservation] = useState<ReservationDetails>({})

    const {
        formState: { errors },
        setValue,
        control,
        handleSubmit
    } = useForm<FormFields>()

    useEffect(() => {
        setValue("id", reservationId);
    }, [reservationId]);

    const fetchData = async () => {
        try {
            var response = await api.get(`/reservation/${reservationId}`);
            setReservation(response.data);
            setValue("status", response.data.status);
            setValue("comment", response.data.sanatoriumAdminComment);
        } catch (error: any) {
            showNotification("error", error.message);
        }
    }


    const handleCloseModal = () => {
        setOpenModal(false);
    }

    const handleOpenModal = async () => {
        setOpenModal(true);
        await fetchData();
    }

    const onSubmit: SubmitHandler<FormFields> = async (data) => {
        try {
            console.log(data);
            var response = await api.put("/reservation/updateStatus", data);
            setOpenModal(false);
            onSave();
            showNotification("success", "Изменения внесены");
        } catch (error: any) {
            showNotification("error", error.message);
        }

    }

    return (
        <>
            <Button className='h-[50%]' onClick={handleOpenModal}>Детали</Button>
            <Modal show={openModal} onClose={handleCloseModal}>
                <Modal.Header>Детали брони</Modal.Header>
                <Modal.Body>
                    <div className="space-y-6">
                        <div className="space-y-6 border-b pb-6">
                            <div>
                                <h5>Автор брони:</h5>
                                <p>{reservation.author?.lastName} {reservation.author?.firstName} {reservation.author?.patronymic}</p>
                                <p>{reservation.author?.email}</p>
                                <p>{reservation.author?.phoneNumber}</p>
                            </div>
                            <div>
                                <h5>Комментарий к заказу:</h5>
                                <p>{reservation.guestComment}</p>
                            </div>
                            <div>
                                <h5>Жилье:</h5>
                                <p>{reservation.roomName}</p>
                            </div>
                        </div>
                        <div>
                            <form className="flex flex-col gap-2" onSubmit={handleSubmit(onSubmit)}>
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
                                            <StatusSelect value={value} onChange={onChange}/>
                                        )}
                                    />
                                </div>
                                <div>
                                    <div className="mb-2 block">
                                        <Label htmlFor="comment" value="Комментарий" />
                                    </div>
                                    <Controller
                                        control={control}
                                        name="comment"
                                        rules={{
                                            required: "Поле обязательно для заполнения",
                                            validate: (value) => value.trim() !== ""
                                        }}
                                        render={({
                                            field: { onChange, onBlur, value, name, ref },
                                            fieldState: { invalid, isTouched, isDirty, error },
                                            formState,
                                        }) => (
                                            <Textarea
                                                className='min-h-[200px]'
                                                onChange={onChange}
                                                value={value}
                                            />
                                        )}
                                    />
                                    <div className='h-[20px]'>
                                        {errors?.comment && <p className='text-red-500'>Поле обязательно для заполнения</p>}
                                    </div>
                                </div>
                                <div className='flex justify-center'>
                                    <Button type="submit" className='w-[120px]'>Сохранить</Button>
                                </div>
                            </form>
                        </div>



                    </div>
                </Modal.Body>
            </Modal>
        </>
    )
}

export default ReservationDetailsPopup