import { Button, Modal } from 'flowbite-react';
import React, { useEffect, useState } from 'react'
import BuyPromoBlock from './BuyPromoBlock';
import api from '../../services/api/api';
import { showNotification } from '../../utils/notificationManager';

type Props = {
    type: "sanatorium" | "room" | "tourAgency" | "tour",
    id?: string,
    disabled: boolean
}

const BuyPromoBlockModal = ({type, id, disabled}: Props) => {
    const [openModal, setOpenModal] = useState(false);

    const handleOpenModal = async () => {
        setOpenModal(true)
    }

    const handleCloseModal = () => {
        setOpenModal(false);
    }

  return (
    <>
            <Button onClick={handleOpenModal} color="warning" disabled={disabled}>Промо</Button>
            <Modal show={openModal} onClose={handleCloseModal} size="6xl">
                <Modal.Header>Промо</Modal.Header>
                <Modal.Body>
                   <BuyPromoBlock id={id} type={type}/>
                </Modal.Body>
            </Modal>
        </>
  )
}

export default BuyPromoBlockModal