import React, { useEffect, useState } from 'react';
import SliderWithThumbnails from '../components/ui/SliderWithThumbnails';
import { Link, useParams } from 'react-router-dom';
import api from '../services/api/api';
import { Button } from 'flowbite-react';
import parse from 'html-react-parser';
import { FaCircleCheck } from 'react-icons/fa6';

type Room = {
	id: string,
	name: string
	bedroomCount: number,
	singleBedCount: number,
	doubleBedCount: number,
	bathroomType: Named,
	mealType: Named,
	description: string,
	pricePerNight: number,
	photoUrls: string[],
	comfortAttrbutes: any,
	roomGroupId?: string
}

type Named = {
	id: string,
	name: string
}

const RoomDetailsPage: React.FC = () => {
	const { roomId } = useParams();
	const [roomData, setRoomData] = useState<Room>({ 
		id: '',
		name: '',
		bedroomCount: 0,
		singleBedCount: 0,
		doubleBedCount: 0,
		bathroomType: {id: '', name: ''},
		mealType: {id: '', name: ''},
		description: '',
		pricePerNight: 0,
		photoUrls: [],
		comfortAttrbutes: [],
		roomGroupId: undefined 
	});

	const [comfort, setComfort] = useState<any[]>([]);
	const [food, setFood] = useState<any[]>([]);
	const [bathroom, setBathroom] = useState<any[]>([]);

	useEffect(() => {
		const fetchData = async () => {
			try {
				var response = await api.get(`/room/${roomId}`)
				setRoomData(response.data);
			} catch (error) {
				
			}
			
		}

		fetchData();
	}, [])

	useEffect(() => {
		const fetchComfort = async () => {
			try {
				var response = await api.get(`attribute/room-comfort/${roomData.roomGroupId}`)
				setComfort(response.data?.filter((a: any) => a.isActive));
			} catch (error) {
				
			}
		}

		const fetchFood = async () => {
			try {
				var response = await api.get(`attribute/room-food/${roomData.roomGroupId}`)
				setFood(response.data?.filter((a: any) => a.isActive));
			} catch (error) {
				
			}
		}

		const fetchBathroom = async () => {
			try {
				var response = await api.get(`attribute/room-bathroom/${roomData.roomGroupId}`)
				setBathroom(response.data?.filter((a: any) => a.isActive));
			} catch (error) {
				
			}
		}

		if(roomData.roomGroupId) {
			fetchComfort();
			fetchFood();
			fetchBathroom();
		}
		
	}, [roomData.roomGroupId])

	const handleReserveClick = () => {
		
	}

	return (
		<div className="container mx-auto mt-8 p-4 min-h-screen space-y-6 max-w-5xl">
			<div className='flex justify-between'>
				<h3 className="text-2xl font-bold mb-4">{roomData!.name}</h3>
				<Button color="light" as={Link} to={`/room/reserve/${roomId}`}> Забронировать</Button>
			</div>
			
			<div className='flex justify-center'>
				<SliderWithThumbnails images={roomData?.photoUrls.map(p => ({ original: p, thumbnail: p, origiginalHeight: 300, originalWidth: 500 }))} />
			</div>
			<div className="my-4 ">
				<h2 className="text-xl font-semibold mb-4 border-b">Количество спален: {roomData?.bedroomCount}</h2>
			</div>
			<div className="my-4 pb-4 border-b">
				<h2 className="text-xl font-semibold mb-4 border-b">Количество спальных мест: {roomData?.singleBedCount + roomData?.doubleBedCount}</h2>
				<div>
					<p>Односпальные: {roomData?.singleBedCount}</p>
					<p>Двухспальные: {roomData?.doubleBedCount}</p>
				</div>
			</div>
			<div className="my-4 pb-4 border-b">
                <h2 className="text-xl font-semibold mb-4">Санузел</h2>
                {bathroom.map((attribute: any) => (
                    <div className="flex gap-2 items-center mb-2" key={attribute.sanatoriumAttributeId}>
                        <FaCircleCheck/>
                        <p>{attribute.name}</p>
                    </div>
                ))}
            </div>
			<div className="my-4 pb-4 border-b">
                <h2 className="text-xl font-semibold mb-4">Комфорт</h2>
                {comfort.map((attribute: any) => (
                    <div className="flex gap-2 items-center mb-2" key={attribute.sanatoriumAttributeId}>
                        <FaCircleCheck/>
                        <p>{attribute.name}</p>
                    </div>
                ))}
            </div>
			<div className="my-4 pb-4 border-b pb-4 border-b">
                <h2 className="text-xl font-semibold mb-4">Питание</h2>
                {food.map((attribute: any) => (
                    <div className="flex gap-2 items-center mb-2" key={attribute.sanatoriumAttributeId}>
                        <FaCircleCheck/>
                        <p>{attribute.name}</p>
                    </div>
                ))}
            </div>
			<div className="my-4 pb-4 border-b">
				<h2 className="text-xl font-semibold mb-4">Цена за сутки</h2>
				<div className='flex flex-wrap gap-4 items-center'>
					<p className='font-semibold'>{roomData?.pricePerNight} &#8381;</p>
					<Button color="light" as={Link} to={`/room/reserve/${roomId}`}> Забронировать</Button>
				</div>
				
			</div>

			<div className="my-4">
				<h2 className="text-xl font-semibold mb-2">Описание</h2>
				<div className="text-gray-700">
					{parse(roomData?.description)}
				</div>
			</div>
		</div>
	);
};

export default RoomDetailsPage;