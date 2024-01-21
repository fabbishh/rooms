// Modal.tsx
import React, { ReactNode } from 'react';

interface ModalProps {
  isOpen: boolean;
  onClose: () => void;
  children: ReactNode;
}

const Modal: React.FC<ModalProps> = ({ isOpen, onClose, children }) => {
  return isOpen ? (
    <div className="fixed inset-0 z-50 flex items-center justify-center">
      <div className="fixed inset-0 bg-black opacity-25" onClick={onClose}></div>
      <div className="relative w-auto max-w-3xl mx-auto my-6">
        <div className="relative flex flex-col bg-white border rounded-lg">
          <div className="flex items-start justify-between p-5 border-b">
            <h3 className="text-xl font-semibold">Модальное окно</h3>
            <button
              className="p-1 ml-auto text-black opacity-50 hover:opacity-100"
              onClick={onClose}
            >
              ×
            </button>
          </div>
          <div className="relative p-6 flex-auto">{children}</div>
        </div>
      </div>
    </div>
  ) : null;
};

export default Modal;
