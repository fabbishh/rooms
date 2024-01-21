import React, { useEffect, useState } from 'react'
import api from '../../services/api/api';
import { showNotification } from '../../utils/notificationManager';
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { FaChevronLeft, FaChevronRight } from 'react-icons/fa6';
import { Link } from 'react-router-dom';
import Carousel from 'react-multi-carousel';
import 'react-multi-carousel/lib/styles.css';
import { useRegion } from '../../context/RegionContext';

type Props = {}

type PromoItem = {
    id: string;
    sanatoriumId: string,
    name: string;
    location: string;
    minPrice: number;
    maxPrice: number;
    photoUrl?: string;
    season: number;
}

const responsive = {
    superLargeDesktop: {
      // the naming can be any, depends on you.
      breakpoint: { max: 4000, min: 3000 },
      items: 5
    },
    desktop: {
      breakpoint: { max: 3000, min: 1024 },
      items: 5
    },
    tablet: {
      breakpoint: { max: 1024, min: 464 },
      items: 3
    },
    mobile: {
      breakpoint: { max: 464, min: 0 },
      items: 1
    }
  };

const PromoRow = (props: Props) => {
    const [promoItems, setPromoItems] = useState<PromoItem[]>([]);

    const {region} = useRegion();

    useEffect(() => {
        const fetchData = async () => {
            try {
                var response = await api.post('/promo/getPromoRowItems', { region: region?.id });
                setPromoItems(response.data);
            }
            catch (error: any) {
                showNotification('error', error.message);
            }
        };
        if(region) {
            fetchData();
        }
    }, [region])

    const mapSeason = (season: number) => {
        if(season === 0) {
            return "весна-лето"
        }
        if(season === 1) {
            return "осень-зима"
        }
        if(season === 2) {
            return "круглогодично"
        }
    }

    return (
        <>
            {Array.isArray(promoItems) && promoItems.length !== 0 &&
            <div className='border-b-2 mb-2 bg-white'>
                <Carousel responsive={responsive}>
                    {promoItems.map((item) => (
                        <div key={item.id} className="max-w-md p-2 cursor-pointer">
                            <Link to={`/sanatoriums/${item.sanatoriumId}`}>
                                <img
                                    src={item.photoUrl ? item.photoUrl : "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/09/b2/07/0d/caption.jpg?w=700&h=-1&s=1"}
                                    alt={`Photo of ${item.name}`}
                                    className="sanatorium-photo max-w-md h-40 object-cover mb-4 rounded-md"
                                />
                                <h2 className='mb-4 font-bold'>{item.name}</h2>
                                <p>От {item.minPrice} &#8381;/сутки</p>
                                <p>Сезон: {mapSeason(item.season)}</p>
                            </Link>
                        </div>
                    ))}
                </Carousel>
            </div>}
        </>
        
    )
}

export default PromoRow