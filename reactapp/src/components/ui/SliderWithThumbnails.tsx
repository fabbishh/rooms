import React, { useState } from 'react';
import ImageGallery  from 'react-image-gallery';
import '../../styles/image-gallery.css'
import { FaArrowLeft } from 'react-icons/fa6';

interface SliderWithThumbnailsProps {
	images: { original: string; thumbnail: string }[];
}

const SliderWithThumbnails: React.FC<SliderWithThumbnailsProps> = ({ images }) => {
	if(!images || images?.length === 0) {
		return <ImageGallery 
			items={[{ original: "https://nsk.triproom.ru/photo/big/noimage.png", thumbnail: "https://nsk.triproom.ru/photo/big/noimage.png"}]} 
			showPlayButton={false} 
			thumbnailPosition="right"
		/>;
	}

	return <ImageGallery 
		items={images} 
		showPlayButton={false} 
		thumbnailPosition="right"
		//onMouseOver={() => setShowNav(true)}
		//onMouseLeave={handleMouseLeave}
		//renderLeftNav={(onClick) => (<FaArrowLeft/>)}
	/>;
};

export default SliderWithThumbnails;
