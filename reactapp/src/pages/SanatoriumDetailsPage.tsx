import React, { useEffect, useState } from 'react';
import SliderWithThumbnails from '../components/ui/SliderWithThumbnails';
import ReviewsSection from '../components/review/ReviewsSection';
import RoomList from '../components/sanatorium/RoomList';
import Pagination from '../components/ui/Pagination';
//import { YMaps, Map, Placemark, SearchControl } from '@pbe/react-yandex-maps';
import { useParams } from 'react-router-dom';
import { getSanatorium } from '../services/api/sanatoriumService';
import api from '../services/api/api';
import PlacesRow from '../components/place/PlacesRow';
import ReviewModal from '../components/review/ReviewModal';
import { showNotification } from '../utils/notificationManager';
import { useAuth } from '../context/AuthContext';
import { FaCircleCheck } from 'react-icons/fa6';
import parse from 'html-react-parser';

type Image = {
    original: string,
    thumbnail: string
}

type Contact = {
    id: string,
    name: string,
    phoneNumber: string
}

const SanatoriumDetailsPage: React.FC = () => {
    const { sanatoriumId } = useParams();

    const [currentPage, setCurrentPage] = useState(0);
    const [totalPages, setTotalPages] = useState(1);

    const [images, setImages] = useState<Image[]>([]);
    const [rooms, setRooms] = useState([]);
    const [reviews, setReviews] = useState([]);
    const [sanatoriumData, setSanatoriumData] = useState<any>(null);
    const [comfortAttributes, setComfortAttributes] = useState<any>([]);
    const [foodAttributes, setFoodAttributes] = useState<any>([]);
    const [contacts, setContacts] = useState<Contact[]>([]);
    const [places, setPlaces] = useState([]);

    const { authenticated } = useAuth();

    const defaultState = {
        center: [47.2082861, 38.9423576],
        zoom: 12,
    };

    useEffect(() => {
        const fetchSanatorium = async () => {
            try{
                const sanatorium = await getSanatorium(sanatoriumId);
                setSanatoriumData(sanatorium);
                setImages(sanatorium?.photoUrls?.map((photoUrl: string) => ({ original: photoUrl, thumbnail: photoUrl, origiginalHeight: 600, originalWidth: 1000 })))
            } catch (error: any) {
                showNotification("error", error.message);
            }
            
        }

        

        const fetchComfortAttributes = async () => {
            try {
                const comfortAttributesResponse = await api.get(`/attribute/comfort-attributes/${sanatoriumId}`);
                setComfortAttributes(comfortAttributesResponse.data?.filter((c: any) => c.isActive));
            } catch (error: any) {
                showNotification("error", error.message);
            }
            
        }

        const fetchFoodAttributes = async () => {
            try {
                const comfortAttributesResponse = await api.get(`/attribute/sanatorium-food/${sanatoriumId}`);
                setFoodAttributes(comfortAttributesResponse.data?.filter((c: any) => c.isActive));
            } catch (error: any) {
                showNotification("error", error.message);
            }
            
        }

        const fetchContacts = async () => {
            try {
                const response = await api.get(`contact/by-sanatorium/${sanatoriumId}`)
                setContacts(response.data);
            } catch (error: any) {
                showNotification("error", error.message);
            }
        }

        const fetchPlaces = async() => {
            try {
                const response = await api.post(`place/getPaged`, {
                    pageNumber: 1,
                    pageSize: 10,
                    filter: {
                        sanatoriumId: sanatoriumId,
                        searchQuery: ""
                    }
                    
                })
                setPlaces(response.data.items);
            } catch (error: any) {
                showNotification("error", error.message);
            }
            
        }

        const fetchReviews = async() => {
            try {
                const response = await api.post(`review/getPaged`, {
                    pageNumber: 1,
                    pageSize: 1000,
                    filter: {
                        sanatoriumId: sanatoriumId
                    }
                })
    
                setReviews(response.data.items); 
            } catch (error: any) {
                showNotification("error", error.request.response)
            }
            
        }

        const fetchData = async () => {
            await fetchSanatorium()
            
            await fetchComfortAttributes();
            await fetchFoodAttributes();
            await fetchContacts();
            await fetchPlaces();
            await fetchReviews();
        };

        fetchData();
    }, [sanatoriumId])

    useEffect(() => {
        const fetchRooms = async () => {
            try {
                const response = await api.post("/room/GetPaged", {
                    pageNumber: currentPage + 1,
                    pageSize: 4,
                    filter: {
                        sanatoriumId: sanatoriumId
                    }
                });
                setRooms(response.data.items);
                setTotalPages(response.data.totalPages)
            } catch (error: any) {
                showNotification("error", error.message);
            } 
        }

        fetchRooms();
    }, [sanatoriumId, currentPage])


    const handlePageChange = (page: any) => {
        setCurrentPage(page.selected);
    };

    return (
        <div className="container mx-auto mt-8 p-4 min-h-screen space-y-6 max-w-5xl">
            <h1 className="text-2xl font-bold mb-4">{sanatoriumData?.name}</h1>
            <div className='flex justify-center'>
                <SliderWithThumbnails images={images} />
            </div>
            
            
            <div className="my-4">
                <h2 className="text-xl font-semibold mb-4">Где вы будете жить</h2>
                <div className='space-y-6'>
                    <RoomList rooms={rooms} />
                    <Pagination
                        pageNumber={currentPage}
                        pageSize={4}
                        totalPages={totalPages}
                        onPageChange={handlePageChange}
                    />
                </div>
                
            </div>

            <div className="my-4">
                <h2 className="text-xl font-semibold mb-4">Комфорт на территории</h2>
                {comfortAttributes.map((attribute: any) => (
                    <div className="flex gap-2 items-center mb-2" key={attribute.sanatoriumAttributeId}>
                        <FaCircleCheck/>
                        <p>{attribute.name}</p>
                    </div>
                ))}
            </div>

            <div className="my-4">
                <h2 className="text-xl font-semibold mb-4">Питание</h2>
                {foodAttributes.map((attribute: any) => (
                    <div className="flex gap-2 items-center mb-2" key={attribute.sanatoriumAttributeId}>
                        <FaCircleCheck/>
                        <p>{attribute.name}</p>
                    </div>
                ))}
            </div>

            <div className="my-4">
                <h2 className="text-xl font-semibold mb-4">Контакты</h2>
                {contacts.map((contact) => 
                (<div key = {contact.id} className="flex">
                    <span>{contact.phoneNumber}  ({contact.name})</span>
                </div>))}
            </div>

            <div className="my-4">
                <h2 className="text-xl font-semibold mb-4">Описание</h2>
                {parse(sanatoriumData?.description ? sanatoriumData?.description : "")}
            </div>

            <div className="my-4">
                <h2 className="text-xl font-semibold mb-4">Места рядом</h2>
                <PlacesRow places={places}/>
            </div>

            {/* <div className="my-4">
                <h2 className="text-3xl font-semibold mb-4">Расположение</h2>

                <YMaps>
                    <Map defaultState={defaultState} width={'100%'} height={500}>
                        <SearchControl options={{ float: "right" }} />
                        <Placemark geometry={defaultState.center} />
                    </Map>
                </YMaps>
            </div> */}

            <div className="my-4">
                <h2 className="text-xl font-semibold mb-4">Отзывы и рейтинг</h2>
                {authenticated && <ReviewModal sanatoriumId={sanatoriumId!}/>}
                <ReviewsSection reviews={reviews} />
            </div>

        </div>
    );
};

export default SanatoriumDetailsPage;
