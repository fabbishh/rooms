import React, { useEffect, useState } from 'react'
import Carousel from 'react-multi-carousel';
import parse from 'html-react-parser';
import { Link } from 'react-router-dom';

type Props = {
    block: any[]
}

const responsive = {
    superLargeDesktop: {
      // the naming can be any, depends on you.
      breakpoint: { max: 4000, min: 3000 },
      items: 1
    },
    desktop: {
      breakpoint: { max: 3000, min: 1024 },
      items: 1
    },
    tablet: {
      breakpoint: { max: 1024, min: 464 },
      items: 1
    },
    mobile: {
      breakpoint: { max: 464, min: 0 },
      items: 1
    }
  };

const PromoBlock = ({block}: Props) => {
    const [autoplay, setAutoplay] = useState<boolean>(false);
    const [items, setItems] = useState<any[]>([])

    useEffect(() => {
        if(block) {
            setAutoplay(block?.length > 1)
            var newItems = block.map((b: any) => {
                let link = ""
                if(b.sanatoriumId) {
                    link = `/sanatoriums/${b.sanatoriumId}`
                }
                else if(b.roomId) {
                    link = `/room/${b.roomId}`
                }
                else if(b.tourId) {
                    link = `/tours/${b.tourId}`
                }
                else if(b.tourAgencyId) {
                    link = `#`
                }
                return {...b, link: link}
            })
            setItems(newItems);
        }

        
    }, [block])

    return (
        <>
            {Array.isArray(block) && block.length !== 0 && <Carousel responsive={responsive} className='border-2 border-black' autoPlay={autoplay} infinite={autoplay} autoPlaySpeed={5000} arrows={false}>
                {items?.map((item) => (
                    <div key={item.promoBlockItemId} className="max-w-md p-2 cursor-pointer">
                        <Link to={item.link}>
                        
                            <img
                                src={item.photoUrl ? item.photoUrl : "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/09/b2/07/0d/caption.jpg?w=700&h=-1&s=1"}
                                alt={`Photo of ${item.name}`}
                                className="object-cover mb-4"
                            />
                            <div className='font-semibold'>{item.name}</div>
                            {/* <div className='w-[50px]'>
                                {parse(item.description)}
                            </div> */}
                        </Link>
                    </div>
                ))}
            </Carousel>}
        </>
    )
}

export default PromoBlock