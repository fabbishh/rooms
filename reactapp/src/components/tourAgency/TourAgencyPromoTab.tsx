import React, { useEffect, useState } from 'react'
import BuyPromoBlock from '../promo/BuyPromoBlock'
import useTourAgencyInfo from '../../hooks/useTourAgencyInfo'

type Props = {}

const TourAgencyPromoTab = (props: Props) => {
    const tourAgencyInfo = useTourAgencyInfo();
    const [loading, setLoading] = useState<boolean>(true);

    useEffect(() => {
        if(tourAgencyInfo?.id) {
            setLoading(false);
        }
    }, [tourAgencyInfo])

    const renderBody = () => {
        if(!loading) {
            return <BuyPromoBlock type="tourAgency" id={tourAgencyInfo?.id} />
        }
            
    }

    return (
        <div className='mx-24'>
            { renderBody() }
        </div>
        
    )
}

export default TourAgencyPromoTab