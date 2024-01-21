import Cookies from "js-cookie";
import { jwtDecode } from "jwt-decode";
import { showNotification } from "./notificationManager";

interface JwtPayload {
	nameid: string;
	role: string;
	email?: string;
	phone?: string;
	exp: number;
}

export const getDecodedToken = () => {
    const token = Cookies.get("accessToken");
    if(!token) {
        return null;
    }
    try {
        const decodedToken = jwtDecode<JwtPayload>(token!);
        return decodedToken;
    } catch (error) {
        showNotification("error", "Token is not valid");
    }
    
}