// SanatoriumProfileTab.tsx
import React, { useEffect, useState } from 'react';
import { getSanatoriumServiceAttributes } from '../../../services/api/sanatoriumService';
import api from '../../../services/api/api';
import useSanatoriumInfo from '../../../hooks/useSanatoriumInfo';
import { showNotification } from '../../../utils/notificationManager';
import { Button } from 'flowbite-react';

interface IAttribute {
	name: string,
	isActive: boolean,
	sanatoriumAttributeId: string
}

const SanatoriumServiceTab = () => {
	const [serviceAttributes, setServiceAttributes] = useState<IAttribute[]>([]);
	const { sanatoriumInfo } = useSanatoriumInfo();

	useEffect(() => {
		if(sanatoriumInfo.id) {
			getSanatoriumServiceAttributes(sanatoriumInfo.id).then(attributes => {
				setServiceAttributes(attributes);
			});
		}
		
	}, [sanatoriumInfo.id])

	const handleCheckboxChange = (attributeId: string) => {
		setServiceAttributes((prevAttributes) =>
		  prevAttributes.map((attribute) =>
			attribute.sanatoriumAttributeId === attributeId
			  ? { ...attribute, isActive: !attribute.isActive }
			  : attribute
		  )
		);
	  };
	
	  const handleSaveChanges = async () => {
		try {
		  await api.post("/attribute/UpdateSanatoriumAttributes", serviceAttributes);
		  showNotification("success", 'Данные успешно сохранены');
		} catch (error) {
		  console.error('Ошибка при сохранении данных:', error);
		}
	  };

	return (
		<div className='mx-24'> 
			{serviceAttributes.map((attribute) => (
				<div key={attribute.sanatoriumAttributeId} className="mb-4">
					<label className="flex items-center">
						<input
							type="checkbox"
							checked={attribute.isActive}
							onChange={() => {
								handleCheckboxChange(attribute.sanatoriumAttributeId)
							}}
							className="mr-2"
						/>
						<span>{attribute.name}</span>
					</label>
				</div>
			))}
			<Button 
				onClick={handleSaveChanges} 
			>
				Сохранить
			</Button>
		</div>
	);
};

export default SanatoriumServiceTab;
