import { useState, useEffect } from 'react';
import { showNotification } from '../utils/notificationManager';
import api from '../services/api/api';
import { useAuth } from '../context/AuthContext';

const useSanatoriumInfo = () => {
    const [sanatoriumInfo, setSanatoriumInfo] = useState({id: undefined, status: undefined});
    const [toggleFetch, setToggleFetch] = useState(false)
    const [tabsDisabled, setTabsDisabled] = useState(true); 
    const { user } = useAuth()
    
    useEffect(() => {
        const fetchData = async () => {
            try {
                if(user?.id) {
                    var response = await api.get(`/sanatorium/get-by-user/${user.id}`)
                    setSanatoriumInfo({ id: response.data.id, status: response.data.status });
                }
            } catch (error: any) {
                showNotification("error", error.message)
            }
        }

        fetchData();
        
    }, [user, toggleFetch]);

    useEffect(() => {
        if(sanatoriumInfo?.id) {
            setTabsDisabled(false)
        } else {
            setTabsDisabled(true)
        }
    }, [sanatoriumInfo])

    return { sanatoriumInfo, tabsDisabled, toggleFetch, setToggleFetch };
};

export default useSanatoriumInfo;