import React, { useEffect, useState } from 'react'
import { showNotification } from '../../utils/notificationManager'
import api from '../../services/api/api'
import PromoBlockPopup from '../sanatorium/PromoBlockPopup'
import { formatDateToRuLocale } from '../../utils/dateUtils'

type Props = {
    type: "sanatorium" | "room" | "tourAgency" | "tour",
    id?: string,
}

const BuyPromoBlock = ({type, id}: Props) => {
    const [promoBlocks, setPromoBlocks] = useState<any[]>([])
    const [blocksInfo, setBlocksInfo] = useState<any[]>([])

    useEffect(() => {
        const fetchPromoBlocks = async () => {
            try {
                var response = await api.get("/promo/promo-blocks-prices");
                setPromoBlocks(response.data);
            } catch (error: any) {
                showNotification('error', error.message)
            }
        }

        fetchPromoBlocks();
    }, [])

    useEffect(() => {
        const fetchBlocksInfo = async () => {
            if(id) {
                try {
                    const data = type === 'room'
                    ? { roomId: id }
                    : type == "tour"
                    ? { tourId: id }
                    : type == "tourAgency"
                    ? { tourAgencyId: id }
                    : { sanatoriumId: id }
                    const  response = await api.post("/promo/blocks-info", data);
                    setBlocksInfo(response.data);
                } catch (error: any) {
                    showNotification('error', error.message)
                }
            }
        }

        fetchBlocksInfo();
    }, [id, type])

    const addToPromoBlock = async (promoBlockId: string) => {
        try {
            const data = type === 'room'
                ? { promoBlockId: promoBlockId, roomId: id }
                : type == "tour"
                ? { promoBlockId: promoBlockId, tourId: id }
                : type == "tourAgency"
                ? { promoBlockId: promoBlockId, tourAgencyId: id }
                : { promoBlockId: promoBlockId, sanatoriumId: id }
                
            await api.post("/promo/CreatePromoBlockItem", data);
            showNotification('success', "Запрос отправлен");
        }
        catch (error: any) {

        }
    }

    const renderPromoBlocksEnabled = () => {
        if (blocksInfo && blocksInfo.length !== 0) {
            return (
                blocksInfo.map((item) => {
                    return (
                        <div className="text-green-500">
                            <p>Услуга "{item.name}" подключена</p>
                            <p>Дата начала: {formatDateToRuLocale(item.startDate)}</p>
                            <p>Дата окончания: {formatDateToRuLocale(item.endDate)}</p>
                        </div>
                    )
                })

            )
        }
    }

    const checkPromoDisabled = (blockName: string) => {
        return blocksInfo?.some(value => value.name === blockName);
    }

    return (
        <>
            <div>
                <h2 className='text-2xl font-bold mb-4'>Добавить мой объект в Промо блок </h2>
                <div className='flex justify-between'>
                    <div className='max-w-[500px] space-y-4'>
                        <p className='text-gray-600'>Ваш объект будет показываться в течение одного месяца в одном из трех промоблоков</p>
                        <img src="https://work-seo.ru/wp-content/uploads/sajty-s-avtomaticheskim-napolneniem.jpg" alt="" className='object-cover' />
                    </div>
                    <div className='flex gap-4'>
                        <div className='space-y-4'>
                            {renderPromoBlocksEnabled()}
                        </div>
                        <div className='space-y-2'>
                            {promoBlocks.map((block: any) => (
                                <PromoBlockPopup block={block} disabled={checkPromoDisabled(block.name)} onRequest={() => addToPromoBlock(block.id)} />
                            ))}
                        </div>

                    </div>
                </div>
            </div>
        </>
    )
}

export default BuyPromoBlock