import { showNotification } from '../../utils/notificationManager';
import api from './api';



export const getSanatorium = async (id: string | undefined) => {
  try {
    const response = await api.get(`/sanatorium/${id}`);
    return response.data; 
  } catch (error: any) {
    showNotification('error', error.message)
  }
};

export const getSanatoriumComfortAttributes = async (sanatoriumId: string | undefined) => {
  try {
    const response = await api.get(`/attribute/comfort-attributes/${sanatoriumId}`);
    return response.data; 
  } catch (error: any) {
    showNotification('error', error.message)
  }
};

export const getSanatoriumServiceAttributes = async (sanatoriumId: string | undefined) => {
  try {
    const response = await api.get(`/attribute/service-attributes/${sanatoriumId}`);
    return response.data; 
  } catch (error: any) {
    showNotification('error', error.message)
  }
};
