import { Button, Modal } from 'flowbite-react';
import React, { useState } from 'react'

type Props = {
    plan: any,
    onRequest: any,
    disabled: boolean
}

const PromoPopup = ({ plan, onRequest, disabled }: Props) => {
    const [openModal, setOpenModal] = useState(false);

    const handleSave = () => {
        onRequest();
        setOpenModal(false);
    }

    return (
      <>
        <Button className="w-[200px]" color='warning' pill onClick={() => setOpenModal(true)} disabled={disabled}>{plan.name} = {plan.price} &#8381;</Button>
        <Modal show={openModal} size="md" onClose={() => setOpenModal(false)} popup>
          <Modal.Header />
          <Modal.Body>
            <div className="text-center">
              <h3 className="mb-5 text-lg font-normal text-gray-500 dark:text-gray-400">
                Отправить запрос на добавление объекта в Промо ряд?
              </h3>
              <div className="flex justify-center gap-4">
                <Button color="warning" onClick={handleSave}>
                  {"Отправить"}
                </Button>
                <Button color="gray" onClick={() => setOpenModal(false)}>
                  Отменить
                </Button>
              </div>
            </div>
          </Modal.Body>
        </Modal>
      </>
    );
}

export default PromoPopup