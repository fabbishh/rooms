// SanatoriumCard.tsx
import React, { useState } from 'react';
import SanatoriumCardProps from '../../models/SanatoriumCardProps';
import { mapSanatoriumSeason } from '../../utils/enumUtils';
import { FaHeart } from 'react-icons/fa6';
import { Button } from 'flowbite-react';
import { Link } from 'react-router-dom';
import { IconContext } from 'react-icons';
import api from '../../services/api/api';
import { showNotification } from '../../utils/notificationManager';
import { useAuth } from '../../context/AuthContext';

const SanatoriumCard: React.FC<SanatoriumCardProps> = ({
	id,
	photoUrl,
	name,
	priceFrom,
	address,
	season,
	isFavourite,
	onLikeClick
}) => {
	const [favourite, setFavourite] = useState<boolean>(isFavourite || false)
	const { authenticated } = useAuth();

	const handleChangeFavourite = async (e: any) => {
		e.preventDefault();
		if(favourite) {
			try {
				await api.post("/favourite/remove", { sanatoriumId: id })
				setFavourite(false);
			} catch (error: any) {
				showNotification("error", error.message)
			}
		} else {
			try {
				await api.post("/favourite/add", { sanatoriumId: id })
				setFavourite(true);
			} catch (error: any) {
				showNotification("error", error.message)
			}
		}
		onLikeClick?.();
	}

	const renderFavouriteButton = () => {
		if(!authenticated) {
			return;
		}

		if(favourite) {
			return (
				<Button color="failure" className="absolute top-2 left-2 text-white rounded-full" onClick={handleChangeFavourite}>
					<IconContext.Provider value={{className: "rounded-full" }}>
						<FaHeart/>
					</IconContext.Provider>
				</Button>
			)
		}
		return (
			<Button color="light" className="absolute top-2 left-2 text-gray-500 rounded-full" onClick={handleChangeFavourite}>
				<IconContext.Provider value={{className: "rounded-full" }}>
					<FaHeart/>
				</IconContext.Provider>
			</Button>
		)
	}

	return (
		<Link to={`/sanatoriums/${id}`}>
			<div className="sanatorium-card max-w-md shadow-lg bg-white p-2 rounded-lg overflow-hidden relative">
				<img
					src={photoUrl || "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/09/b2/07/0d/caption.jpg?w=700&h=-1&s=1"}
					alt={`Photo of ${name}`}
					className="sanatorium-photo w-full h-40 object-cover mb-4 rounded-md"
				/>
				<div className="sanatorium-details">
					<h2 className="font-bold mb-4">{name}</h2>
					<p className="text-gray-600 mb-2">От {priceFrom || 'от 0'}&#8381;/сутки</p>
					{/* <p className="text-gray-600 mb-2">{address}</p> */}
					<p className="text-gray-600 mb-2">Сезон: {mapSanatoriumSeason(season)}</p>
				</div>
				{renderFavouriteButton()}
			</div>
		</Link>

	);
};

export default SanatoriumCard;
