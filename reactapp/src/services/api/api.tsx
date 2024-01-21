import axios from 'axios';
import Cookies from 'js-cookie'
import { showNotification } from '../../utils/notificationManager';

const api = axios.create({
    baseURL: 'https://localhost:443/api',
});

// Add a request interceptor
api.interceptors.request.use(
    (config) => {
        const token = Cookies.get('accessToken');
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => Promise.reject(error)
);

// Add a response interceptor
api.interceptors.response.use(
    (response) => response,
    async (error) => {
        const originalRequest = error.config;

        // If the error status is 401 and there is no originalRequest._retry flag,
        // it means the token has expired and we need to refresh it
        if (error.response.status === 401 && !originalRequest._retry) {
            originalRequest._retry = true;

            try {
                const refreshToken = Cookies.get('refreshToken');
                const accessToken = Cookies.get('accessToken');
                
                const response = await axios.post(`https://localhost:443/api/auth/refresh`, { 
                    accessToken: accessToken,
                    refreshToken: refreshToken
                });

                Cookies.set('accessToken', response.data.accessToken);
                Cookies.set('refreshToken', response.data.refreshToken);

                // Retry the original request with the new token
                originalRequest.headers.Authorization = `Bearer ${response.data.accessToken}`;
                return axios(originalRequest);
            } catch (error: any) {
                showNotification('error', error.message);
            }
        }

        if (error.response.status !== 401) {
            showNotification('error', error.response.data.message);
        }

        return Promise.reject(error);
    }
);

export default api
