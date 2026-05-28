import apiClient from './apiClient';

const parkingService = {
    getParkingSpots: async () => {
        const response = await apiClient.get('/ParkingSpots');
        return response.data || [];
    },

    // دالة جلب كل الحجوزات للمستخدم
    getReservations: async (userId) => {
        const response = await apiClient.get(`/Reservations/user/${userId}`);
        return response.data || [];
    },

    // دالة جلب كل الحجوزات (للادمن)
    getAllReservations: async () => {
        const response = await apiClient.get('/Reservations');
        return response.data || [];
    },

    // دالة جلب حجز معين بالـ ID
    getReservationById: async (reservationId) => {
        const response = await apiClient.get(`/Reservations/${reservationId}`);
        return response.data;
    },

    confirmReservation: async (reservationData) => {
        const response = await apiClient.post('/Reservations', reservationData);
        return response.data;
    },

    cancelReservation: async (reservationId) => {
        const response = await apiClient.delete(`/Reservations/Cancel/${reservationId}`);
        return response.data;
    },

    getUserPaymentHistory: async (userId) => {
        const response = await apiClient.get(`/Payments/user-history/${userId}`);
        return response.data || [];
    },

    processPayment: async (paymentPayload) => {
        const response = await apiClient.post('/Payments/Process', paymentPayload);
        return response.data;
    },
};

export default parkingService;
