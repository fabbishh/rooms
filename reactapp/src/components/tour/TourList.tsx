// TourList.tsx
import React from 'react';
import { Tour } from '../../shared/app.interfaces';
import { Link } from 'react-router-dom';
import { formatDateToRuLocale } from '../../utils/dateUtils';
import { Card } from 'flowbite-react';

interface TourListProps {
    tours: Tour[];
}

const TourList: React.FC<TourListProps> = ({ tours }) => {
    return (
        <>
            {tours.map((tour) => (
                <Card
                    key={tour.id}
                    href={`/tours/${tour.id}`}
                    className="min-w-full"
                    imgSrc={tour.imageUrl || "https://images.unsplash.com/photo-1569949381669-ecf31ae8e613?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8dG91cnxlbnwwfHwwfHx8MA%3D%3D"}
                    horizontal
                    >
                        <div>
                            <h5 className="text-2xl font-bold tracking-tight text-gray-900">{tour.name}</h5>
                            <p className="text-gray-500">{tour.touristCountFrom} - {tour.touristCountTo} человек</p>
                            <p className="text-gray-500">Продолжительность: {tour.days} дней</p>
                            <p className="text-gray-500">Ближайшая дата: {formatDateToRuLocale(tour.closestDate) || 'неизвестна'}</p>
                            <p className="text-lg text-gray-700">{tour.priceByGroup == null ? `${tour.priceByTourist} Р. с человека` : `${tour.priceByGroup} Р. с группы`} </p>
                        </div>
                        
                        <Link to={tour.organizer.id}>
                            <p className="text-gray-500">Организатор: {tour.organizer.name}</p>
                        </Link>
                    
                </Card>
            ))}
        </>
    );
};

export default TourList;
