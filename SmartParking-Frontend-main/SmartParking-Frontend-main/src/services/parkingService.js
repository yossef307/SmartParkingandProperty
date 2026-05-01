import axios from 'axios';

/** * الإعدادات الأساسية للـ API
 * تأكد أن البورت 7048 هو الذي يعمل عليه مشروع ASP.NET Core حالياً
 */
const API_URL = 'https://localhost:7048/api';

const parkingService = {
    /**
     * 1. جلب قائمة الركنات المتاحة
     * المسار: GET /api/ParkingSpots
     */
    getParkingSpots: async () => {
        try {
            const response = await axios.get(`${API_URL}/ParkingSpots`);
            // التأكد من إرجاع البيانات حتى لو كانت مصفوفة فارغة
            return response.data || [];
        } catch (error) {
            console.error("خطأ أثناء جلب أماكن الركن:", error.message);
            throw error;
        }
    },

    /**
     * 2. إنشاء حجز جديد (ربط المستخدم، العقار، والركنة)
     * المسار: POST /api/Reservations
     * يتوقع كائن مطابق لـ ReservationDto.cs
     */
    confirmReservation: async (reservationData) => {
        try {
            // إرسال البيانات (PropertyId, ParkingSpotId, UserId, StartDate, EndDate, TotalPrice)
            const response = await axios.post(`${API_URL}/Reservations`, reservationData);

            // السيرفر يرجع كائن يحتوي على message و data
            return response.data;
        } catch (error) {
            // التقاط رسائل الخطأ المخصصة من السيرفر (مثل: المكان غير متاح)
            const errorMessage = error.response?.data?.message
                || "فشل الاتصال بالسيرفر، تأكد من وجود العقار والمستخدم برقم 1";

            console.error("خطأ في عملية الحجز:", errorMessage);
            throw new Error(errorMessage);
        }
    },

    /**
     * 3. إلغاء الحجز بناءً على معرف الركنة (خاص بمفتاح التبديل في React)
     * المسار: DELETE /api/Reservations/CancelBySpot/{spotId}
     */
    cancelReservation: async (spotId) => {
        try {
            // تصحيح الرابط الذي كان مقطوعاً في الكود السابق
            const response = await axios.delete(`${API_URL}/Reservations/CancelBySpot/${spotId}`);
            return response.data;
        } catch (error) {
            const errorMessage = error.response?.data?.message || "فشل إلغاء الحجز";
            console.error("خطأ في إلغاء الحجز:", errorMessage);
            throw new Error(errorMessage);
        }
    },

    /**
     * 4. جلب تفاصيل حجز معين (اختياري - للعرض في لوحة التحكم)
     * المسار: GET /api/Reservations/{id}
     */
    getReservationById: async (id) => {
        try {
            const response = await axios.get(`${API_URL}/Reservations/${id}`);
            return response.data;
        } catch (error) {
            console.error("خطأ في جلب بيانات الحجز:", error);
            throw error;
        }
    }
};

export default parkingService;