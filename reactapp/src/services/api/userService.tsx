import { showNotification } from "../../utils/notificationManager";
import api from "./api";

export const getUsers = async () => {
    try {
        var response = await api.get("/user/sanatorium-admins");
        return response.data;
    } catch (error: any) {
        showNotification("error", error.message);
    }
}