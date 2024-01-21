import { Button, Checkbox, Label, Modal, TextInput } from 'flowbite-react';
import React, { useState } from 'react'
import api from '../../../services/api/api';
import { showNotification } from '../../../utils/notificationManager';

type Props = {
	buttonName: string,
	modalTitle: string,
	onSave: (data: any) => void;
}

const CreateAttributeModal = ({ buttonName, modalTitle, onSave }: Props) => {
	const [openModal, setOpenModal] = useState(false);
	const [name, setName] = useState("");
	const [isActive, setIsActive] = useState(false);

	const handleSaveClick = async () => {
		await onSave({ name: name, isActive: isActive });
		setOpenModal(false);
		setName("");
		setIsActive(false);
	}

	const handleCloseModal = () => {
		setOpenModal(false)
		setName("");
		setIsActive(false);
	}

	return (
		<>
			<Button onClick={() => setOpenModal(true)}>{buttonName}</Button>
			<Modal show={openModal} onClose={handleCloseModal}>
				<Modal.Header>{modalTitle}</Modal.Header>
				<Modal.Body>
					<div className="space-y-6">
						<div>
							<div className="mb-2 block">
								<Label htmlFor="name" value="Название" />
							</div>
							<TextInput
								id="name"
								value={name}
								onChange={(event) => setName(event.target.value)}
								required
							/>
						</div>
						<div className='flex gap-2'>
							<Checkbox id="isActive" checked={isActive} onChange={() => setIsActive(!isActive)} />
							<Label htmlFor="isActive" value="Включен" />
						</div>
						<div className="w-full">
							<Button onClick={handleSaveClick}>Создать</Button>
						</div>
					</div>
				</Modal.Body>
			</Modal>
		</>
	);
}

export default CreateAttributeModal