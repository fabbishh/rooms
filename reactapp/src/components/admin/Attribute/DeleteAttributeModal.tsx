import { Button, Modal } from "flowbite-react";
import { useState } from "react";
import { FaCircleExclamation } from "react-icons/fa6";
import DeleteModal from "../../ui/modal/DeleteModal";

type Props = {
    disabled: boolean,
    onDelete: () => void
}

function DeleteAttributeModal({ disabled, onDelete } : Props) {
    return (
      <>
        <DeleteModal disabled={disabled} onDelete={onDelete} itemName="атрибуты"/>
      </>
    );
  }

  export default DeleteAttributeModal;