// ServiceFilter.tsx
import React, { useEffect, useState } from 'react';
import api from '../../../services/api/api';
import { Attribute } from '../../../shared/app.interfaces';
import { showNotification } from '../../../utils/notificationManager';
import AttributeFilter from '../../ui/AttributeFilter';

interface ServiceFilterProps {
  onServiceChange: (selectedServices: Attribute[]) => void;
  selectedValues: Attribute[];
}

const ServiceFilter: React.FC<ServiceFilterProps> = ({ onServiceChange, selectedValues }) => {
  const [serviceOptions, setServiceOptions] = useState<Attribute[]>([]);

  useEffect(() => {
		const fetchData = async () => {
			try {
				var response = await api.get("/attribute/sanatorium-service")

				const validAttributes = response.data.map((attribute: any) => {
					const isActive = selectedValues.find(value => value.id === attribute.id)?.isActive || false;
					return { id: attribute.id, name: attribute.name, isActive: isActive }
				})
				setServiceOptions(validAttributes);

			} catch (error: any) {
				showNotification("Ошибка", error.message);
			}
		}

		fetchData();
	}, [])

	const handleServiceChange = (attributes: Attribute[]) => {
		setServiceOptions(attributes);
		onServiceChange(attributes.filter(a => a.isActive === true));
	};

	return (
		<>
			<AttributeFilter options={serviceOptions} onOptionsChange={handleServiceChange} title="Услуги"/>
		</>
	);
};

export default ServiceFilter;
