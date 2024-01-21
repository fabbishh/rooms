import React, { useEffect, useState } from 'react';
import api from '../../../services/api/api';
import Contacts from '../../contact/Contacts';
import { showNotification } from '../../../utils/notificationManager';
import useSanatoriumInfo from '../../../hooks/useSanatoriumInfo';

type Contact = {
    key: number;
    id?: string;
    name: string;
    phoneNumber: string;
};

const SanatoriumContactsTab = () => {
    const [contacts, setContacts] = useState<Contact[]>([{ key: 0,  name: '', phoneNumber: '' }]);

	const { sanatoriumInfo } = useSanatoriumInfo();

    useEffect(() => {
        const fetchData = async () => {
            var response = await api.get(`/contact/by-sanatorium/${sanatoriumInfo.id}`);
            if(response.data.length != 0) {
                var index = 0;
                setContacts(response.data.map((item: any) => ({ key: index++, id: item.id, name: item.name, phoneNumber: item.phoneNumber})));
            } 
        }
        if(sanatoriumInfo.id) {
            fetchData();
        }
        
    }, []);
        

    

    const handleSaveContacts = async (contacts: Contact[]) => {
        var dataToSend = {
            sanatoriumId: sanatoriumInfo.id,
            contacts: contacts.map((item) => ({id: item.id, name: item.name, phoneNumber: item.phoneNumber}))
        };
        try {
            var response = await api.post("/contact/update", dataToSend);
            showNotification("success", "Контакты обновлены");
        } catch (error: any) {
            
        }
        
    };

    return (
        <div className='mx-24'> 
            <Contacts onSave={handleSaveContacts} initialContacts={contacts}/>
        </div>
    );
};

export default SanatoriumContactsTab;
