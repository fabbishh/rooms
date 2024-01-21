import React, { useEffect, useState } from 'react';
import { getSanatoriumServiceAttributes } from '../../../services/api/sanatoriumService';
import api from '../../../services/api/api';
import useSanatoriumInfo from '../../../hooks/useSanatoriumInfo';
import { showNotification } from '../../../utils/notificationManager';
import { Button } from 'flowbite-react';

type Props = {}

const SanatoriumFoodTab = (props: Props) => {
    const [foodAttributes, setFoodAttributes] = useState<any[]>([]);
	const { sanatoriumInfo } = useSanatoriumInfo();

	useEffect(() => {
        const fetchData = async () => {
            if(sanatoriumInfo.id) {
                try {
                    const response = await api.get(`/attribute/sanatorium-food/${sanatoriumInfo.id}`);
                    setFoodAttributes(response?.data) 
                  } catch (error: any) {
                    //showNotification('error', error.message)
                  }
            }
        }
		
		fetchData();
	}, [sanatoriumInfo.id])

	const handleCheckboxChange = (attributeId: string) => {
		setFoodAttributes((prevAttributes) =>
		  prevAttributes.map((attribute) =>
			attribute.sanatoriumAttributeId === attributeId
			  ? { ...attribute, isActive: !attribute.isActive }
			  : attribute
		  )
		);
	  };
	
	  const handleSaveChanges = async () => {
		try {
		  await api.post("/attribute/UpdateSanatoriumAttributes", foodAttributes);
		  showNotification("success", 'Данные успешно сохранены');
		} catch (error) {
		  console.error('Ошибка при сохранении данных:', error);
		}
	  };

	return (
		<div className='mx-24'> 
			{foodAttributes.map((attribute) => (
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
}

export default SanatoriumFoodTab