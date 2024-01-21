import React, { useEffect, useState } from 'react'
import api from '../services/api/api';
import { showNotification } from '../utils/notificationManager';
import { useAuth } from '../context/AuthContext';

type Props = {}

const useTourAgencyInfo = () => {
    const [tourAgencyInfo, setTourAgencyInfo] = useState({id: undefined, status: undefined});
    const { user } = useAuth()
    
    useEffect(() => {
        const fetchData = async () => {
            try {
                if(user?.id) {
                    var response = await api.get(`/tourAgency/get-by-user/${user.id}`)
                    setTourAgencyInfo({ id: response.data.id, status: response.data.status });
                }
            } catch (error: any) {
                showNotification("error", error.message)
            }
        }

        fetchData();
        
    }, [user]);

    return tourAgencyInfo;
};
export default useTourAgencyInfo