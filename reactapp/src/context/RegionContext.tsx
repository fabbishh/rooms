import { createContext, useContext, useEffect, useState, ReactNode } from 'react';
import { showNotification } from '../utils/notificationManager';
import { jwtDecode } from 'jwt-decode';
import Cookies from 'js-cookie';
import { getDecodedToken } from '../utils/jwtUtils';
import api from '../services/api/api';
import { isObjectEmpty } from '../utils/objectUtils';

type AuthProviderProps = {
	children?: ReactNode;
}

type IRegionContext = {
	region?: Region;
	handleSetRegion: (newState: Region) => void;
    loading: boolean
};

interface Region {
    id: string,
    nameWithType: string,
}

const RegionContext = createContext<IRegionContext>(undefined!);

export const useRegion = () => {
	const context = useContext(RegionContext);
	if (!context) {
		showNotification('error', 'useAuth must be used within an AuthProvider');
	}
	return context;
};

export const RegionProvider = ({ children }: AuthProviderProps) => {
	const [region, setRegion] = useState<Region>();
    const [loading, setLoading] = useState<boolean>(true);

    const handleSetRegion = (region: Region) => {
        setRegion(region);
        localStorage.setItem("region", JSON.stringify(region));
    }

    useEffect(() => {
        const fetchData = async () => {
            setLoading(true);
            try {
                const region = localStorage.getItem("region");
                if(!region || isObjectEmpty(JSON.parse(region!))) {
                    const response = await api.get("/region/get-default");
                    const newRegion = response.data
                    
                    localStorage.setItem("region", JSON.stringify(newRegion));
                    setRegion(newRegion);
                } else {
                    setRegion(JSON.parse(region!));
                }
            } catch (error: any) {
                showNotification('error', error.message);
            }
            setLoading(false);
        }

        fetchData();
        
    }, [])
	return (
		<RegionContext.Provider value={{ region, handleSetRegion, loading}}>
			{children}
		</RegionContext.Provider>
	);
};