import { Button, Label, TextInput } from 'flowbite-react';
import React, { useEffect, useState } from 'react'
import { FaTimes, FaUserPlus } from 'react-icons/fa';
import Input, { isValidPhoneNumber } from 'react-phone-number-input/input';

type Contact = {
    id?: string;
    name: string;
    phoneNumber: string;
};

type Props = {
    onSave: (contacts: any[]) => void;
    initialContacts: any[];
}

const Contacts: React.FC<Props> = ({ onSave, initialContacts }) => {
    const [contacts, setContacts] = useState<Contact[]>(initialContacts);
    const [errors, setErrors] = useState<any[]>(Array(initialContacts.length).fill({ name: '', phoneNumber: '' }));

    useEffect(() => {
        setContacts(initialContacts);
    }, [initialContacts]);

    const handleAddContact = () => {
        if (contacts.length < 3) {
            setContacts((prevContacts) => [...prevContacts, { name: '', phoneNumber: '' }]);
        }
    };

    const handleRemoveContact = (key: number) => {
        if (contacts.length > 1) {
            setContacts((prevContacts) => prevContacts.filter((contact, index) => key !== index));
        }
    };

    const handleSave = () => {
        let isValid = true;
        const newErrors = contacts.map((contact, index) => {
            var error = { name: '', phoneNumber: ''}
            if (contact.name.trim().length === 0) {
                isValid = false;
                error.name = 'Поле обязательно для заполнения';
            } 
            if (!isValidPhoneNumber(contact.phoneNumber)) {
                isValid = false;
                error.phoneNumber = 'Некорректный формат номера телефона';
            }
            return error;
        });

        setErrors(newErrors);

        if(isValid) {
            contacts.forEach((contact) => {
                contact.name = contact.name.trim()
            })
            onSave(contacts);
        }
        
    }

    return (
        <div className=''>
            <div className=''>
                {contacts.map((contact, index) => (
                    <div key={index} className="border rounded-md p-4 mb-4 max-w-[400px]">
                        <div className="mb-4">
                            <div className="mb-2 block">
                                <Label htmlFor={`name-${index}`} value="Имя" />
                            </div>
                            <TextInput
                                type="text"
                                id={`name-${index}`}
                                value={contact.name}
                                onChange={(e) => {
                                    const updatedContacts = [...contacts];
                                    updatedContacts[index].name = e.target.value;
                                    setContacts(updatedContacts);
                                    setErrors((prevErrors) => {
                                        const newErrors = [...prevErrors];
                                        newErrors[index] = { ...newErrors[index], name: ''};
                                        return newErrors;
                                    });
                                }}
                            />
                            {errors[index]?.name && <div className="text-red-500 text-sm">{errors[index].name}</div>}
                        </div>
                        <div className="mb-4">
                            <div className="mb-2 block">
                                <Label htmlFor={`phoneNumber-${index}`} value="Номер телефона" />
                            </div>
                            <Input
                                id={`phoneNumber-${index}`}
                                placeholder="+71234567890"
                                country="RU"
                                international
                                withCountryCallingCode
                                onChange={(value) => {
                                    const updatedContacts = [...contacts];
                                    updatedContacts[index].phoneNumber = value?.toString()!;
                                    setContacts(updatedContacts);
                                    setErrors((prevErrors) => {
                                        const newErrors = [...prevErrors];
                                        newErrors[index] = { ...newErrors[index], phoneNumber: ''};
                                        return newErrors;
                                    });
                                }}
                                value={contact.phoneNumber}
                                inputComponent={TextInput} 
                            />
                            {errors[index]?.phoneNumber && <div className="text-red-500 text-sm">{errors[index].phoneNumber}</div>}
                        </div>
                        {contacts.length > 1 &&
                            <div className="mb-4 flex justify-center">
                                <button onClick={() => handleRemoveContact(index)} className="bg-red-500 text-white p-2 rounded-md">
                                    <FaTimes className="" />
                                </button>
                            </div>}
                    </div>
                ))}
            </div>


            {contacts.length < 3 && (
                <div className="mb-4">
                    <button onClick={handleAddContact} className="bg-gray-500 text-white rounded-md p-2">
                        <FaUserPlus className="" />
                    </button>
                </div>
            )}

            <Button onClick={handleSave}>
                Сохранить
            </Button>
        </div>
    )
}

export default Contacts

