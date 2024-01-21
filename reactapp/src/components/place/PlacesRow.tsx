import React from 'react'

type Props = {
    places: Place[]
}

type Place = {
    id: string;
    photos: any[];
    name: string;
}

const PlacesRow : React.FC<Props> = ({ places }) => {
  return (
    <div className='flex'>
        {places.map((place) => (
            <div key={place.id} className='mr-4 text-center max-w-[200px]'>
                <img 
                    src={place.photos?.[0].url || "https://www.shutterstock.com/image-photo/plitvice-lakes-croatia-beautiful-place-260nw-1050138794.jpg"} 
                    alt={place.name} 
                    width="" 
                    className='object-cover w-[150px] h-[150px]'/>
                <span className="">{place.name}</span>
            </div>
        ))}
    </div>
  )
}

export default PlacesRow