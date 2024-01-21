import React from 'react'
import StarRatings from 'react-star-ratings'

type Props = {
    rating: number,
    ratingChanged: (newRating: any) => void
}

const RatingStars = ({ rating, ratingChanged }: Props) => {
  return (
    <StarRatings
        rating={rating}
        starRatedColor="orange"
        starHoverColor="orange"
        starDimension='30px'
        starSpacing='2px'
        changeRating={ratingChanged}
        numberOfStars={5}
        name='rating'
    />
  )
}

export default RatingStars