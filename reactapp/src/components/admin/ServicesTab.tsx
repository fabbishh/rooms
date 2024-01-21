import React, { useEffect, useState } from 'react'
import { showNotification } from '../../utils/notificationManager'
import api from '../../services/api/api'
import AttributeTable from './Attribute/AttributeTable'
import { Attribute } from '../../shared/app.interfaces'

type Props = {}

const ServicesTab = (props: Props) => {
    const [attributes, setAttributes] = useState<Attribute[]>([])

    const fetchData = async () => {
        try {
            var response = await api.get("/attribute/sanatorium-service")

            setAttributes(response.data);
        } catch (error: any) {
            showNotification("error", error.message)
        }
    }

    useEffect(() => {
        fetchData();
    }, [])
    

    const handleCreateComfort = async (data: any) => {
        try {
            var response = await api.post("/attribute/CreateService", data)
            showNotification("success", "Услуга добавлена");
          } catch (error: any) {
            //showNotification("error", error.message);
          }
        fetchData();
    }

    const handleDeleteComfort = async (ids: string[]) => {
        try {
            var response = await api.delete("/attribute/delete", { data: { attributeIds: ids } });
            fetchData();
            showNotification("success", "Услуги успешно удалены");
        } catch (error: any) {
            showNotification("error", error.message);
        }
    }

    return (
        <>
            <AttributeTable attributes={attributes} onCreate={handleCreateComfort} onDelete={handleDeleteComfort}/>
        </>
    )
}

export default ServicesTab