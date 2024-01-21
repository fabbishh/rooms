import React from 'react';
import { Link } from 'react-router-dom';
import parse from 'html-react-parser';

interface Room {
	roomId: number;
	name: string;
	description: string;
	pricePerNight: number;
	photoUrls: string[];
}

interface RoomListProps {
	rooms: Room[];
}

const RoomList: React.FC<RoomListProps> = ({ rooms }) => {
	return (
		<div className="grid grid-cols-1 gap-4">
			{rooms.map(room => (
				<Link to={`/room/${room.roomId}`} key={room.roomId} className="text-decoration-none">
					<div className="bg-white border border-gray-300 hover:border-cyan-600  rounded-lg overflow-hidden w-full flex ">
						<div className="mr-4">
							<img src={room.photoUrls[0]} alt={room.name} className="w-48 h-48 object-cover rounded-md" />
						</div>
						<div className="flex-grow p-4">
							<h3 className="text-xl font-semibold mb-2">{room.name}</h3>
							<div className="text-gray-500 mb-4">{parse(room.description)}</div>
							<div className="flex justify-between items-center">
								<p className="text-lg text-gray-700">от {room.pricePerNight} &#8381;/ ночь</p>
							</div>
						</div>
					</div>
				</Link>
			))}
		</div>
	);
};

export default RoomList;
