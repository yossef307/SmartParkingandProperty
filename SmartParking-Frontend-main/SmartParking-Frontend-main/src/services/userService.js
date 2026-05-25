import apiClient from './apiClient';

const userService = {
    login: async (credentials) => {
        const response = await apiClient.post('/users/login', {
            email: credentials.email.trim(),
            password: credentials.password.trim(),
        });
        return response.data;
    },

    register: async (userData) => {
        const response = await apiClient.post('/users/register', userData);
        return response.data;
    },

    refreshToken: async (refreshToken) => {
        const response = await apiClient.post('/users/refresh-token', { refreshToken });
        return response.data;
    },

    logout: async () => {
        try {
            await apiClient.post('/users/logout');
        } finally {
            localStorage.removeItem('accessToken');
            localStorage.removeItem('refreshToken');
            localStorage.removeItem('user');
            localStorage.removeItem('isLoggedIn');
        }
    },

    updateProfile: async (profileData) => {
        const response = await apiClient.put('/users/update-profile', profileData);
        return response.data;
    },

    getUsers: async () => {
        const response = await apiClient.get('/users');
        return response.data;
    },

    deleteUser: async (id) => {
        const response = await apiClient.delete(`/users/${id}`);
        return response.data;
    },
};

export default userService;