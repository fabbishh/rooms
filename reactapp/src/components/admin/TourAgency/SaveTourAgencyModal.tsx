import React, { useState } from 'react'
import SaveTourAgencyForm from '../../tourAgency/SaveTourAgencyForm'
import { Button, Modal } from 'flowbite-react';

type Props = {
    tourAgencyId?: string
    onSave: () => void;
}

const SaveTourAgencyModal = ({tourAgencyId, onSave}: Props) => {
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
     <Button onClick={handleOpenModal}>{tourAgencyId ? 'Редактировать' : 'Создать'}</Button>
     <Modal show={openModal} onClose={handleCloseModal}>
        <Modal.Header>{tourAgencyId ? 'Редактирование турагенства' : 'Создание турагенства'}</Modal.Header>
        <Modal.Body>
            {/* <SaveSanatoriumForm role="admin" onSave={handleSave} sanatoriumId={sanatoriumId}/> */}
            <SaveTourAgencyForm role="admin" onSave={handleSave} tourAgencyId={tourAgencyId}/>
        </Modal.Body>
    </Modal>
     
    </>
    
  )
}

export default SaveTourAgencyModal