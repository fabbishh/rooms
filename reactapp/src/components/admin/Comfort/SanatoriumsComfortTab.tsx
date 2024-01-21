import React, { useEffect, useState } from 'react'
import { Attribute } from '../../../shared/app.interfaces'
import { showNotification } from '../../../utils/notificationManager'
import api from '../../../services/api/api'
import AttributeTable from '../Attribute/AttributeTable';

type Props = {}

const SanatoriumsComfortTab = (props: Props) => {
    const [attributes, setAttributes] = useState<Attribute[]>([])

    const fetchData = async () => {
        try {
            var response = await api.get("/attribute/sanatorium-comfort")

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
            var response = await api.post("/attribute/CreateSanatoriumComfort", data)
            showNotification("success", "Атрибут комфорта добавлен");
          } catch (error: any) {
           // showNotification("error", error.message);
          }
        fetchData();
    }

    const handleDeleteComfort = async (ids: string[]) => {
        try {
            var response = await api.delete("/attribute/delete", { data: { attributeIds: ids } });
            showNotification("success", "Атрибуты успешно удалены");
        } catch (error: any) {
            showNotification("error", error.message);
        }
        fetchData();
    }

    return (
        <>
            <AttributeTable attributes={attributes} onCreate={handleCreateComfort} onDelete={handleDeleteComfort}/>
        </>
    )
}

export default SanatoriumsComfortTab