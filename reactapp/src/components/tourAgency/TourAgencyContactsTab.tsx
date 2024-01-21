import React, { useEffect, useState } from 'react'
import Contacts from '../contact/Contacts'
import api from '../../services/api/api';
import { showNotification } from '../../utils/notificationManager';
import useTourAgencyInfo from '../../hooks/useTourAgencyInfo';

type Contact = {
	key: number;
	id?: string;
	name: string;
	phoneNumber: string;
};

const TourAgencyContactsTab = () => {

	const [contacts, setContacts] = useState<Contact[]>([{ key: 0, name: '', phoneNumber: '' }]);
	const tourAgencyInfo = useTourAgencyInfo()

	useEffect(() => {
		const fetchData = async () => {
			try {
				var response = await api.get(`/contact/by-tour-agency/${tourAgencyInfo.id}`);
				if (response.data.length != 0) {
					var index = 0;
					setContacts(response.data.map((item: any) => ({ key: index++, id: item.id, name: item.name, phoneNumber: item.phoneNumber })));
				}
			} catch (error: any) {
				showNotification('error', error.message);
			}
		}
		if(tourAgencyInfo.id) {
			fetchData();
		}
		
	}, [tourAgencyInfo.id]);




	const handleSaveContacts = async (contacts: Contact[]) => {
		try{
			var dataToSend = {
				tourAgencyId: tourAgencyInfo.id,
				contacts: contacts.map((item) => ({ id: item.id, name: item.name, phoneNumber: item.phoneNumber }))
			};
			await api.post("/contact/update", dataToSend);
			showNotification("success", "Контакты сохранены");
		}
		catch { }
	};


	return (
		<div className='mx-24'>
			<Contacts onSave={handleSaveContacts} initialContacts={contacts}/>
		</div>
	)
}

export default TourAgencyContactsTab