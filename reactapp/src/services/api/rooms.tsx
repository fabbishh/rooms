import api from "./api";


export const getPagedRooms = async (phoneNumber: string) => {
	try {
		const response = await api.post(`/auth/login`, {
			phoneNumber: phoneNumber,
		});

		return response.data;
	} catch (error) {
		console.error('Login error:', error);
		throw error;
	}
};