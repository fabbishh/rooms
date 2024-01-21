import { Button, Modal } from 'flowbite-react';
import React, { useState } from 'react'
import { seasonsData } from '../../../data/Seasons';
import { getUsers } from '../../../services/api/userService';
import SaveSanatoriumForm from '../../sanatorium/forms/SaveSanatoriumForm';

type Props = {
    sanatoriumId?: string
    onSave: () => void;
}

const SaveSanatoriumModal = ({ sanatoriumId, onSave }: Props) => {
    const [openModal, setOpenModal] = useState(false);

    const handleCloseModal = () => {
        setOpenModal(false)
    }

    const handleOpenModal = async () => {
        setOpenModal(true);
    }

    const handleSave = () => {
        setOpenModal(false);
        onSave();
    }
    
    return (
        <>
            <Button onClick={handleOpenModal}>{sanatoriumId ? 'Редактировать' : 'Создать'}</Button>
            <Modal show={openModal} onClose={handleCloseModal}>
                <Modal.Header>{sanatoriumId ? 'Редактирование санатория' : 'Создание санатория'}</Modal.Header>
                <Modal.Body>
                    <SaveSanatoriumForm role="admin" onSave={handleSave} sanatoriumId={sanatoriumId}/>
                </Modal.Body>
            </Modal>
        </>
    )
}

export default SaveSanatoriumModal