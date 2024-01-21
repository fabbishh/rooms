import { useEffect, useState } from 'react'
import api from '../../services/api/api';
import PromoBlock from './PromoBlock';



const PromoBlocksSection = () => {
    const [block1, setBlock1] = useState<any[]>([]);
    const [block2, setBlock2] = useState<any[]>([]);
    const [block3, setBlock3] = useState<any[]>([]);

    useEffect(() => {
        const fetchData = async (url: string, callback: any) => {
            try {
                var response = await api.get(url);
                callback(response?.data)
            } catch (error) {

            }
        }

        fetchData("/promo/block-one-items", setBlock1)
        fetchData("/promo/block-two-items", setBlock2)
        fetchData("/promo/block-three-items", setBlock3)
    }, [])

    return (
        <div className='space-y-6 mt-12'>
            <PromoBlock block={block1}/>
            <PromoBlock block={block2}/>
            <PromoBlock block={block3}/>
        </div>
    )
}

export default PromoBlocksSection