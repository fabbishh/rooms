import { Button, Label, Modal, TextInput, Textarea } from 'flowbite-react';
import React, { useState } from 'react'
import StarRatings from 'react-star-ratings';
import RatingStars from '../rating/RatingStars';
import { Controller, SubmitHandler, useForm } from 'react-hook-form';
import api from '../../services/api/api';
import { showNotification } from '../../utils/notificationManager';

type Props = {
    sanatoriumId: string
}

interface IReviewFields {
    overallRating: number,
    cleanlinessRating: number,
    therapyRating: number,
    foodRating: number,
    locationRating: number,
    entertainmentRating: number,
    staffRating: number,
    comment: string,
    sanatoriumId: string,
}

const ReviewModal = ({ sanatoriumId }: Props) => {
    const [openModal, setOpenModal] = useState(false);

    const {
        control,
        register,
        reset,
        handleSubmit,
        setValue,
        formState: { errors }
    } = useForm<IReviewFields>();

    const handleCloseModal = () => {
        setOpenModal(false);
        reset();
    }

    const handleOpenModal = () => {
        setOpenModal(true);
        setValue("sanatoriumId", sanatoriumId);
    }

    const onSubmit: SubmitHandler<IReviewFields> = async (data: any) => {
        try {
            await api.post("/review", data);
            handleCloseModal();
            showNotification("success", "Отзыв отправлен на модерацию");
        } catch (error) {

        }
        console.log(data);
    }

    return (
        <>
            <Button color="light" onClick={handleOpenModal}>Добавить отзыв</Button>
            <Modal show={openModal} onClose={handleCloseModal}>
                <Modal.Header>Добавить отзыв</Modal.Header>
                <Modal.Body>
                    <form className="space-y-6" onSubmit={handleSubmit(onSubmit)}>
                        <div className='grid grid-cols-2 gap-4'>
                            <Label htmlFor="overallRating" value="Общее впечатление:" />
                            <div>
                                <Controller
                                    control={control}
                                    name="overallRating"
                                    rules={{
                                        required: "Поставьте оценку"
                                    }}
                                    render={({
                                        field: { onChange, onBlur, value, name, ref },
                                        fieldState: { invalid, isTouched, isDirty, error },
                                        formState,
                                    }) => (
                                        <RatingStars
                                            rating={value}
                                            ratingChanged={onChange} />
                                    )}
                                />
                                <p className='text-red-500'>{errors?.overallRating?.message}</p>
                            </div>
                            <Label htmlFor="staffRating" value="Персонал:" />
                            <div>
                                <Controller
                                    control={control}
                                    name="staffRating"
                                    rules={{
                                        required: "Поставьте оценку"
                                    }}
                                    render={({
                                        field: { onChange, onBlur, value, name, ref },
                                        fieldState: { invalid, isTouched, isDirty, error },
                                        formState,
                                    }) => (
                                        <RatingStars
                                            rating={value}
                                            ratingChanged={onChange} />
                                    )}
                                />
                                <p className='text-red-500'>{errors?.staffRating?.message}</p>
                            </div>

                            <Label htmlFor="cleanlinessRating" value="Уровень чистоты:" />
                            <div>
                                <Controller
                                    control={control}
                                    name="cleanlinessRating"
                                    rules={{
                                        required: "Поставьте оценку"
                                    }}
                                    render={({
                                        field: { onChange, onBlur, value, name, ref },
                                        fieldState: { invalid, isTouched, isDirty, error },
                                        formState,
                                    }) => (
                                        <RatingStars
                                            rating={value}
                                            ratingChanged={onChange} />
                                    )}
                                />
                                <p className='text-red-500'>{errors?.cleanlinessRating?.message}</p>
                            </div>

                            <Label htmlFor="foodRating" value="Питание:" />
                            <div>
                                <Controller
                                    control={control}
                                    name="foodRating"
                                    rules={{
                                        required: "Поставьте оценку"
                                    }}
                                    render={({
                                        field: { onChange, onBlur, value, name, ref },
                                        fieldState: { invalid, isTouched, isDirty, error },
                                        formState,
                                    }) => (
                                        <RatingStars
                                            rating={value}
                                            ratingChanged={onChange} />
                                    )}
                                />
                                <p className='text-red-500'>{errors?.foodRating?.message}</p>
                            </div>

                            <Label htmlFor="locationRating" value="Расположение:" />
                            <div>
                                <Controller
                                    control={control}
                                    name="locationRating"
                                    rules={{
                                        required: "Поставьте оценку"
                                    }}
                                    render={({
                                        field: { onChange, onBlur, value, name, ref },
                                        fieldState: { invalid, isTouched, isDirty, error },
                                        formState,
                                    }) => (
                                        <RatingStars
                                            rating={value}
                                            ratingChanged={onChange} />
                                    )}
                                />
                                <p className='text-red-500'>{errors?.locationRating?.message}</p>
                            </div>

                            <Label htmlFor="entertainmentRating" value="Развлечения:" />
                            <div>
                                <Controller
                                    control={control}
                                    name="entertainmentRating"
                                    rules={{
                                        required: "Поставьте оценку"
                                    }}
                                    render={({
                                        field: { onChange, onBlur, value, name, ref },
                                        fieldState: { invalid, isTouched, isDirty, error },
                                        formState,
                                    }) => (
                                        <RatingStars
                                            rating={value}
                                            ratingChanged={onChange} />
                                    )}
                                />
                                <p className='text-red-500'>{errors?.entertainmentRating?.message}</p>
                            </div>

                            <Label htmlFor="therapyRating" value="Лечение:" />
                            <div>
                                <Controller
                                    control={control}
                                    name="therapyRating"
                                    rules={{
                                        required: "Поставьте оценку"
                                    }}
                                    render={({
                                        field: { onChange, onBlur, value, name, ref },
                                        fieldState: { invalid, isTouched, isDirty, error },
                                        formState,
                                    }) => (
                                        <RatingStars
                                            rating={value}
                                            ratingChanged={onChange} />
                                    )}
                                />
                                <p className='text-red-500'>{errors?.therapyRating?.message}</p>
                            </div>

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
                                    minLength: {
                                        value: 50,
                                        message: "Минимум 30 символов"
                                    }
                                }}
                                render={({
                                    field: { onChange, onBlur, value, name, ref },
                                    fieldState: { invalid, isTouched, isDirty, error },
                                    formState,
                                }) => (
                                    <Textarea
                                        placeholder='Минимум 30 символов'
                                        className='min-h-[100px]'
                                        value={value}
                                        onChange={onChange}
                                    />
                                )}
                            />
                            <p className='text-red-500'>{errors?.comment?.message}</p>
                        </div>

                        <div className="flex justify-center">
                            <Button type="submit">Добавить</Button>
                        </div>
                    </form>
                </Modal.Body>
            </Modal>
        </>
    );
}

export default ReviewModal