import { Button, Label, Modal } from 'flowbite-react';
import React, { useEffect, useState } from 'react'
import { Controller, SubmitHandler, useForm } from 'react-hook-form';
import StarRatings from 'react-star-ratings';
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';
import StatusSelect from '../../status/StatusSelect';

type Props = {
	reviewId: string,
	onSave: any
}

interface ReviewDetails {
	id: string,
	overallRating: number,
	comment: string,
	tourId: string,
	author: { id: string, firstName: string, lastName: string, patronymic: string, email: string, phoneNumber: string },
	tourName: string,
}

interface IFormFields {
	id: string,
	status: number
}

const TourReviewDetaisModal = ({reviewId, onSave}: Props) => {
    const [openModal, setOpenModal] = useState(false);
	const [review, setReview] = useState<ReviewDetails>();

	const {
		formState: { errors },
		setValue,
		control,
		handleSubmit
	} = useForm<IFormFields>()

	useEffect(() => {
		setValue("id", reviewId);
	}, [reviewId]);

	const fetchData = async () => {
		try {
			var response = await api.get(`/review/tour-review-details/${reviewId}`);
			setReview(response.data);
			setValue("status", response.data.status);
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
	const onSubmit: SubmitHandler<IFormFields> = async (data) => {
		try {
			console.log(data);
			var response = await api.post("/review/update-tour-review-status", data);
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
				<Modal.Header>Детали отзыва</Modal.Header>
				<Modal.Body>
					<div className="space-y-6">
						<div className="space-y-6 border-b pb-6">
							<div className='grid grid-cols-2 gap-4'>
								<Label htmlFor="overallRating" value="Общее впечатление:" />
								<StarRatings
									rating={review?.overallRating}
									starRatedColor="orange"
									starHoverColor="orange"
									starDimension='25px'
									starSpacing='2px'
									numberOfStars={5}
									name='rating'
								/>
							</div>
							<div>
								<h5>Автор отзыва:</h5>
								<p>{review?.author?.lastName} {review?.author?.firstName} {review?.author?.patronymic}</p>
								<p>{review?.author?.email}</p>
								<p>{review?.author?.phoneNumber}</p>
							</div>
							<div>
								<h5>Комментарий:</h5>
								<p>{review?.comment}</p>
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
											<StatusSelect value={value} onChange={onChange} />
										)}
									/>
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

export default TourReviewDetaisModal