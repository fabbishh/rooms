import React, { useEffect, useState } from 'react'
import api from '../../../services/api/api';
import { Button } from 'flowbite-react';
import PromoPopup from '../PromoPopup';
import { showNotification } from '../../../utils/notificationManager';
import { useAuth } from '../../../context/AuthContext';
import useSanatoriumInfo from '../../../hooks/useSanatoriumInfo';
import { formatDateToRuLocale } from '../../../utils/dateUtils';
import PromoBlockPopup from '../PromoBlockPopup';

type Props = {
    sanatoriumId: string,
}

const SanatoriumPromoTab = () => {
    const [promoRowPlans, setPromoRowPlans] = useState<any[]>([]);
    const [promoBlocks, setPromoBlocks] = useState<any[]>([])

    const [rowInfo, setRowInfo] = useState<any>()
    const [blocksInfo, setBlocksInfo] = useState<any[]>([])

    const [rowButtonsState, setRowButtonsState] = useState<boolean>(false);

    const { sanatoriumInfo } = useSanatoriumInfo();

    useEffect(() => {
        if (rowInfo) {
            setRowButtonsState(true)
        } else {
            setRowButtonsState(false)
        }
    }, [rowInfo])

    useEffect(() => {
        const fetchData = async () => {
            try {
                var response = await api.get("/promoRowPlan/list");
                setPromoRowPlans(response.data);
            } catch (error: any) {
                showNotification('error', error.message)
            }
        }

        const fetchPromoBlocks = async () => {
            try {
                var response = await api.get("/promo/promo-blocks-prices");
                setPromoBlocks(response.data);
            } catch (error: any) {
                showNotification('error', error.message)
            }
        }



        fetchData();
        fetchPromoBlocks();

    }, [])

    useEffect(() => {
        const fetchRowInfo = async () => {
            try {
                var response = await api.get(`/promo/row-info/${sanatoriumInfo?.id}`);
                setRowInfo(response.data);
            } catch (error: any) {
                showNotification('error', error.message)
            }
        }

        const fetchBlocksInfo = async () => {
            try {
                var response = await api.post("/promo/blocks-info", { sanatoriumId: sanatoriumInfo?.id });
                setBlocksInfo(response.data);
            } catch (error: any) {
                showNotification('error', error.message)
            }
        }
        if (sanatoriumInfo.id) {
            fetchRowInfo();
            fetchBlocksInfo();
        }

    }, [sanatoriumInfo])

    const addToPromoRow = (id: string) => {
        try {
            var response = api.post("/promo/CreatePromoRowItem", { planId: id, sanatoriumId: sanatoriumInfo.id });
            showNotification('success', "Запрос отправлен");
        }
        catch (error: any) {
            showNotification('error', error.message);
        }
    }

    const addToPromoBlock = (id: string) => {
        try {
            var response = api.post("/promo/CreatePromoBlockItem", { promoBlockId: id, sanatoriumId: sanatoriumInfo.id });
            showNotification('success', "Запрос отправлен");
        }
        catch (error: any) {
            showNotification('error', error.message);
        }
    }

    const renderPromoRowEnabled = () => {
        if (rowInfo) {
            return (
                <div className="text-green-500">
                    <p>Услуга "Промо ряд" подключена</p>
                    <p>Дата начала: {formatDateToRuLocale(rowInfo.startDate)}</p>
                    <p>Дата окончания: {formatDateToRuLocale(rowInfo.endDate)}</p>
                </div>
            )
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
        <div className='mx-24 space-y-6'>
            <div className='border-b-2 pb-8'>
                <h2 className='text-2xl font-bold mb-4'>Добавить мой объект в Промо ряд на главной странице</h2>
                <div className='flex justify-between'>
                    <div className='max-w-[500px] space-y-4'>
                        <p className='text-gray-600'>Ваш объект будет всегда отображаться в верхнем списке на Главной странице сайта для пользователей, которые ищут жилье в вашем регионе независимо от других параметров поиска</p>
                        <img src="https://work-seo.ru/wp-content/uploads/sajty-s-avtomaticheskim-napolneniem.jpg" alt="" className='object-cover' />
                    </div>
                    <div className='flex gap-4'>
                        {renderPromoRowEnabled()}
                        <div className='space-y-2'>
                            {promoRowPlans.map((plan: any) => (
                                <PromoPopup plan={plan} onRequest={() => addToPromoRow(plan.id)} disabled={rowButtonsState} />
                            ))}
                        </div>

                    </div>
                </div>
            </div>
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
                                <PromoBlockPopup block={block} disabled={checkPromoDisabled(block.name)} onRequest={() => addToPromoBlock(block.id)}/>
                            ))}
                        </div>

                    </div>
                </div>
            </div>
        </div>
    )
}

export default SanatoriumPromoTab