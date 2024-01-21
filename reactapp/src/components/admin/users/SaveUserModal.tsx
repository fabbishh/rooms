import { Button, Modal } from 'flowbite-react';
import React, { useState } from 'react'
import { useForm } from 'react-hook-form';
import UserForm from '../../users/UserForm';

type Props = {
    userId?: string;
    onSave: any
}
const SaveUserModal = ({ userId, onSave }: Props) => {
    const [openModal, setOpenModal] = useState(false);
    const {
        control,
        setValue,
        handleSubmit,
        register,
        reset,
        getValues,
        formState: { errors }
    } = useForm()

    const handleOpenModal = async () => {
        setOpenModal(true)
    }

    const handleCloseModal = () => {
        setOpenModal(false);
        reset();
    }

    const handleSave = () => {
        setOpenModal(false);
        onSave();
    }

    return (
        <>
            <Button onClick={handleOpenModal}>{userId ? 'Редактировать' : 'Создать'}</Button>
            <Modal show={openModal} onClose={handleCloseModal}>
                <Modal.Header>{userId ? 'Редактирование пользователя' : 'Добавление пользователя'}</Modal.Header>
                <Modal.Body>
                    <UserForm role="admin" userId={userId} onSave={handleSave}/>
                </Modal.Body>
            </Modal>
        </>
    )
}

export default SaveUserModal