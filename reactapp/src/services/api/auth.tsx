import Cookies from 'js-cookie'
import api from './api'
import { jwtDecode } from "jwt-decode";
import { showNotification } from '../../utils/notificationManager';

export const register = async (phoneNumber: string) => {
	try {
		const response = await api.post(`/auth/register`, {
			phoneNumber: phoneNumber,
			email: null
		});

		return response.data;
	} catch (error) {
		console.error('Register error:', error);
		throw error;
	}
};

export const login = async (email: string) => {
	try {
		const response = await api.post(`/auth/login`, {
			email: email,
		});

		return response.data;
	} catch (error: any) {
		showNotification("error", error.request.response)
	}
};

export const validateConfirmationCode = async (email: string, code: string, shouldUpdateConfirm: boolean, callback?: any) => {
	try {
		const response = await api.post(`/auth/validateCode`, {
			email: email,
			code: code,
			shouldUpdateConfirm: shouldUpdateConfirm
		});

		Cookies.set("accessToken", response.data.accessToken);
		Cookies.set("refreshToken", response.data.refreshToken);

		return response.data;
	} catch (error: any) {
		console.log("error");
	}
};

export const refresh = async (accessToken: string, refreshToken: string) => {
	try {
		const response = await api.post(`/auth/refresh`, {
			refreshToken: refreshToken,
			accessToken: accessToken,
		});

		Cookies.set("accessToken", response.data.accessToken);
		Cookies.set("refreshToken", response.data.refreshToken);

		return response.data;
	} catch (error) {
		console.error('Error fetching sanatoriums:', error);
		throw error;
	}
};

export const logout = async () => {
	try {
		Cookies.remove("accessToken");
		Cookies.remove("refreshToken");
	} catch (error) {
		throw error;
	}
};





