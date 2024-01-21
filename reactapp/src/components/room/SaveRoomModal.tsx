import { Button, Modal } from 'flowbite-react';
import React, { useState } from 'react'
import SaveRoomForm from './SaveRoomForm';

type Props = {
    sanatoriumId?: string,
	roomGroupId?: string,
    title: string,
    buttonName: string,
	isAdmin: boolean,
    onSave: () => void,
	type: "house" | "room"
}

const SaveRoomModal = ({ title, buttonName, isAdmin, onSave, sanatoriumId, roomGroupId, type }: Props) => {
    const [openModal, setOpenModal] = useState(false);

	const handleSaveClick = async () => {
		await onSave();
		setOpenModal(false);
	}

	const handleCloseModal = () => {
		setOpenModal(false)
	}

	return (
		<>
			<Button onClick={() => setOpenModal(true)}>{buttonName}</Button>
			<Modal show={openModal} onClose={handleCloseModal} size={'7xl'}>
				<Modal.Header>{title}</Modal.Header>
				<Modal.Body>
					<SaveRoomForm sanatoriumId={sanatoriumId} roomGroupId={roomGroupId} onSave={handleSaveClick} isAdmin={isAdmin} type={type}/>
				</Modal.Body>
			</Modal>
		</>
	);
}

export default SaveRoomModal