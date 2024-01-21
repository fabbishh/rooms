import { Button, Modal } from 'flowbite-react';
import React, { useState } from 'react'
import { FaCircleExclamation } from 'react-icons/fa6';

type Props = {
    disabled: boolean,
    itemName: string,
    onDelete: () => void
}

const DeleteModal = ({disabled, itemName, onDelete}: Props) => {
    const [openModal, setOpenModal] = useState(false);

    const handleDelete = () => {
        setOpenModal(false);
        onDelete();
    }
  
    return (
      <>
        <Button color="gray" disabled={disabled} onClick={() => setOpenModal(true)}>Удалить</Button>
        <Modal show={openModal} size="md" onClose={() => setOpenModal(false)} popup>
          <Modal.Header />
          <Modal.Body>
            <div className="text-center">
              <FaCircleExclamation className="mx-auto mb-4 h-14 w-14 text-gray-400 dark:text-gray-200" />
              <h3 className="mb-5 text-lg font-normal text-gray-500 dark:text-gray-400">
                Вы уверены, что хотите удалить выбранные {itemName}?
              </h3>
              <div className="flex justify-center gap-4">
                <Button color="failure" onClick={handleDelete}>
                  {"Удалить"}
                </Button>
                <Button color="gray" onClick={() => setOpenModal(false)}>
                  Отмена
                </Button>
              </div>
            </div>
          </Modal.Body>
        </Modal>
      </>
    );
}

export default DeleteModal