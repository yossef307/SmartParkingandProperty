import axios from 'axios';

/**
 * الإعدادات الأساسية للـ API
 * تم ضبط الـ Base URL ليتوافق مع بورت الـ ASP.NET Core الخاص بك
 */
const API_URL = 'https://localhost:7048/api';

const apiClient = axios.create({
    baseURL: API_URL,
    headers: {
        'Content-Type': 'application/json'
    }
});

const parkingService = {
    /**
     * 1. جلب قائمة الركنات المتاحة
     */
    getParkingSpots: async () => {
        try {
            const response = await apiClient.get('/ParkingSpots');
            return response.data || [];
        } catch (error) {
            console.error("Error fetching spots:", error.message);
            throw error;
        }
    },

    /**
     * 2. إنشاء حجز جديد (Parking + Property)
     */
    confirmReservation: async (reservationData) => {
        try {
            const formattedData = {
                ...reservationData,
                startDate: new Date(reservationData.StartDate).toISOString(),
                endDate: new Date(reservationData.EndDate).toISOString(),
            };

            const response = await apiClient.post('/Reservations', formattedData);
            return response.data;
        } catch (error) {
            const msg = error.response?.data?.message || "فشل حجز المكان، قد يكون مشغولاً حالياً.";
            throw new Error(msg);
        }
    },

    /**
     * 3. إلغاء الحجز بناءً على معرف الركنة
     */
    cancelReservation: async (spotId) => {
        try {
            const response = await apiClient.delete(`/Reservations/CancelBySpot/${spotId}`);
            return response.data;
        } catch (error) {
            throw new Error(error.response?.data?.message || "فشل إلغاء الحجز");
        }
    },

    /**
     * 4. جلب تاريخ مدفوعات المستخدم (المعدل)
     * يطابق الآن: [HttpGet("user-history/{userId}")] في الـ Controller
     */
    getUserPaymentHistory: async (userId = 1) => {
        try {
            // نمرر الـ userId كجزء من الرابط كما هو محدد في الـ Backend
            const response = await apiClient.get(`/Payments/user-history/${userId}`);
            return response.data || [];
        } catch (error) {
            console.error("Error fetching payments history:", error.response?.data || error.message);
            throw error;
        }
    },

    /**
     * 5. معالجة عملية دفع جديدة
     * يطابق الآن: [HttpPost("Process")] في الـ Controller
     */
    processPayment: async (paymentPayload) => {
        try {
            // إرسال البيانات إلى الأكشن الجديد الذي أضفناه في الـ C#
            const response = await apiClient.post('/Payments/Process', paymentPayload);
            return response.data;
        } catch (error) {
            console.error("Payment processing error:", error.response?.data || error.message);
            const msg = error.response?.data?.message || "حدث خطأ أثناء معالجة الدفع، يرجى المحاولة مرة أخرى.";
            throw new Error(msg);
        }
    }
};

export default parkingService;