import { Rating } from 'flowbite-react';
import React from 'react';
import StarRatings from 'react-star-ratings';
import { formatDateToRuLocale } from '../../utils/dateUtils';

interface ReviewsSectionProps {
	reviews: any[];
}

const ReviewsSection: React.FC<ReviewsSectionProps> = ({ reviews }) => {
	const calculateAverageRating = () => {
		if (reviews.length === 0) return 0;

		const totalRating = reviews.reduce((sum, review) => sum + review.overallRating, 0);
		return totalRating / reviews.length;
	};

	const averageRating = calculateAverageRating();

	return (
		<div className="my-4">
			<div className="mb-4 flex items-center border-b border-gray-300 pb-2">
				<strong className="text-xl mr-2">Общий рейтинг:</strong>
				<div className="flex items-center">
					<StarRatings
						rating={averageRating}
						starRatedColor="orange"
						starHoverColor="orange"
						starDimension='25px'
						starSpacing='2px'
						numberOfStars={5}
						name='rating'
					/>
					<p className="ml-2 text-sm font-medium text-gray-500 dark:text-gray-400">{averageRating.toFixed(2)} из 5</p>
				</div>
			</div>

			{reviews.length === 0 ? (
				<p className="text-gray-500">Пока нет отзывов.</p>
			) : (
				<div>
					{reviews.map(review => (
						<div key={review.id} className="bg-white border border-gray-300 rounded-lg overflow-hidden mb-4">
							<div className="p-6 flex gap-4">
								<div className='border-r pr-4'>
									<span className="font-semibold mb-2">{review.author || 'Неизвестный пользователь'}</span>
									<p className="text-gray-500 mb-2">{formatDateToRuLocale(review.date)}</p>
								</div>
								<div>
									<div>
										<StarRatings
											rating={review.overallRating}
											starRatedColor="orange"
											starHoverColor="orange"
											starDimension='20px'
											starSpacing='2px'
											numberOfStars={5}
											name='rating'
										/>
									</div>
									<div>
										<p className="mb-2">{review.content}</p>
									</div>
									
								</div>
								
							</div>
						</div>
					))}
				</div>
			)}
		</div>
	);
};

export default ReviewsSection;
