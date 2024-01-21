import { Button, Modal } from 'flowbite-react';
import React, { useState } from 'react'
import SaveRoomForm from '../../room/SaveRoomForm';
import SavePlaceForm from './SavePlaceForm';

type Props = {
    placeId?: string,
    onSave?: () => void;
}

const SavePlaceModal = ({placeId, onSave}: Props) => {
    const [openModal, setOpenModal] = useState(false);

	const handleSave = async () => {
		onSave?.();
		setOpenModal(false);
	}

	const handleCloseModal = () => {
		setOpenModal(false)
	}

	return (
		<>
			<Button onClick={() => setOpenModal(true)}>{placeId ? "Редактировать" : "Создать"}</Button>
			<Modal show={openModal} onClose={handleCloseModal} size={'2xl'}>
				<Modal.Header>{placeId ? "Редактировать" : "Создать"}</Modal.Header>
				<Modal.Body>
					<SavePlaceForm onSave={handleSave} placeId={placeId}/>
				</Modal.Body>
			</Modal>
		</>
	);
}

export default SavePlaceModal