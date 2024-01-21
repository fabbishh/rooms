import { Button, Label, Modal, Textarea } from 'flowbite-react'
import React, { useState } from 'react'
import { Controller, SubmitHandler, useForm } from 'react-hook-form'
import RatingStars from '../rating/RatingStars'
import { showNotification } from '../../utils/notificationManager'
import api from '../../services/api/api'

type Props = {
	tourId: string
}

interface ITourReviewFields {
	overallRating: number,
	comment: string,
	tourId: string,
}

const TourReviewModal = ({ tourId }: Props) => {

	const [openModal, setOpenModal] = useState(false);

	const {
		control,
		register,
		reset,
		handleSubmit,
		setValue,
		formState: { errors }
	} = useForm<ITourReviewFields>();

	const handleCloseModal = () => {
		setOpenModal(false);
		reset();
	}

	const handleOpenModal = () => {
		setOpenModal(true);
		setValue("tourId", tourId);
	}

	const onSubmit: SubmitHandler<ITourReviewFields> = async (data: any) => {
		try {
			await api.post("/review/create-tour-review", data);
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
							<Button type="submit" >Добавить</Button>
						</div>
					</form>
				</Modal.Body>
			</Modal>
		</>
	)
}

export default TourReviewModal