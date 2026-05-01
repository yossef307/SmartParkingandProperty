import axios from 'axios';

const apiClient = axios.create({
    // تأكد أن هذا الرابط هو الذي يظهر عند تشغيل الـ Backend (Swagger)
    baseURL: 'https://localhost:7048/api',
    headers: {
        'Content-Type': 'application/json',
    }
});

const userService = {
    // تسجيل دخول
    login: async (credentials) => {
        try {
            const response = await apiClient.post('/users/login', credentials);
            return response.data;
        } catch (error) {
            console.error("Login Error:", error.response?.data || error.message);
            throw error;
        }
    },

    // تسجيل مستخدم جديد
    createUser: async (userData) => {
        try {
            const response = await apiClient.post('/users/register', userData);
            return response.data;
        } catch (error) {
            console.error("Signup Error:", error.response?.data || error.message);
            throw error;
        }
    },

    getUsers: async () => {
        const response = await apiClient.get('/users');
        return response.data;
    },

    deleteUser: async (id) => {
        const response = await apiClient.delete(`/users/${id}`);
        return response.data;
    }
};

export default userService;