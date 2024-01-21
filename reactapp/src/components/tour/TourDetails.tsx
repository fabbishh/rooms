import { Button, Carousel } from 'flowbite-react';
import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import api from '../../services/api/api';
import { showNotification } from '../../utils/notificationManager';
import { FaLocationDot } from 'react-icons/fa6';
import ReviewsSection from '../review/ReviewsSection';
import { useAuth } from '../../context/AuthContext';
import TourReviewModal from './TourReviewModal';
import parse from 'html-react-parser';
import SliderWithThumbnails from '../ui/SliderWithThumbnails';
import { seasonsData } from '../../data/Seasons';

type Props = {
}

interface Tour {
    id: string,
    name: string,
    subject: string,
    subjectName: string,
    days: number,
    price: number,
    priceType: number,
    touristCountFrom: number,
    touristCountTo: number,
    tourAgencyId: string,
    tourAgencyName: string,
    type: string,
    typeName: string,
    description: string,
    seasons: any[]
}

const TourDetails = (props: Props) => {
    const { tourId } = useParams();

    const [tour, setTour] = useState<Tour>({
        id: '',
        name: '',
        subject: '',
        subjectName: '',
        days: 0,
        price: 0,
        priceType: 0,
        touristCountFrom: 0,
        touristCountTo: 0,
        tourAgencyId: '',
        tourAgencyName: '',
        type: '',
        typeName: '',
        description: '',
        seasons: []
    });
    const [reviews, setReviews] = useState<any[]>([]);
    const [images, setImages] = useState<any[]>([]);

    const { authenticated } = useAuth();
    
    useEffect(() => {
        const fetchData = async () => {
            try {
                var response = await api.get(`/tour/${tourId}`);
                setTour(response?.data);
                setImages(response?.data?.photos?.map((photo: any) => ({ original: photo.url, thumbnail: photo.url, origiginalHeight: 600, originalWidth: 1000 })))
            } catch (error: any) {
                showNotification("error", error.message);
            }
        }

        const fetchReviews = async() => {
            try {
                const response = await api.post(`review/tour-reviews/GetPaged`, {
                    pageNumber: 1,
                    pageSize: 1000,
                    filter: {
                        tourId: tourId
                    }
                })
    
                setReviews(response.data.items); 
            } catch (error: any) {
                showNotification("error", error.request.response)
            }
            
        }

        fetchReviews();
        fetchData();
    }, [])

    const mapSeasons = () => {
        if(tour?.seasons?.includes(4)) {
            return seasonsData.find(s => s.key === 4)?.name;
        }
        
        const seasons = tour?.seasons?.sort((a, b) => a - b).map((seasonKey: number) => {
            return seasonsData.find(s => s.key === seasonKey)?.name
        })

        return seasons.join(", ");
    }

    return (
        <div className="container mx-auto m-8 p-4 min-h-screen space-y-6 max-w-5xl">
            <div>
                <h1 className='text-2xl font-semibold mb-4'>{tour?.name}, Цена с {tour?.priceType == 0 ? 'туриста' : 'Группы'}: {tour?.price} рублей</h1>
                <div className='flex gap-1'>
                    <FaLocationDot />
                    <span>{tour?.subjectName}</span>
                </div>
            </div>

            <div className='flex justify-center'>
                <SliderWithThumbnails images={images} />
            </div>

            <div>
                <h2 className='text-xl font-semibold mb-4'>О туре</h2>
                <p>Организатор: {tour?.tourAgencyName}</p>
                <div className='flex flex-wrap gap-4'>
                    <p>Продолжительность тура в днях: {tour?.days}</p>
                    <p>Сезон: {mapSeasons()}</p>
                    <p>{tour?.typeName}</p>
                    <p>Туристов в группе: от {tour?.touristCountFrom} до {tour?.touristCountTo}</p>
                </div>
                
            </div>

            <div>
                <h2 className='text-xl font-semibold mb-4'>Описание</h2>
                <p>{parse(tour?.description)}</p>
            </div>

             <div>
                {authenticated && <TourReviewModal tourId={tourId!}/>}
                <ReviewsSection reviews={reviews}/>
            </div> 
        </div>
    )
}

export default TourDetails