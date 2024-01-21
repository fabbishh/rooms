import api from "./api";


export const uploadPhotos = async (formData: FormData) => {
	try {
		const response = await api.post(`/photo/uploadPreviewPhotos`, formData);

		return response.data;
	} catch (error) {
		console.error('Login error:', error);
		throw error;
	}
};