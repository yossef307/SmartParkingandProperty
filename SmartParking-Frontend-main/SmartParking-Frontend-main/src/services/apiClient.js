import axios from 'axios';

const API_URL = import.meta.env.VITE_API_URL || 'https://localhost:7144/api';

const apiClient = axios.create({
    baseURL: API_URL,
    headers: {
        'Content-Type': 'application/json',
    },
});

// Request Interceptor - إضافة الـ Token لكل طلب
apiClient.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('accessToken');
        console.log('[v0] Request URL:', config.url);
        console.log('[v0] Access Token exists:', !!token);

        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
            console.log('[v0] Authorization header set');
        }
        return config;
    },
    (error) => {
        console.log('[v0] Request error:', error);
        return Promise.reject(error);
    }
);

// Response Interceptor - معالجة الأخطاء وتجديد الـ Token
apiClient.interceptors.response.use(
    (response) => {
        console.log('[v0] Response success:', response.config.url);
        return response;
    },
    async (error) => {
        const originalRequest = error.config;

        console.log('[v0] Response error:', error.response?.status, error.config?.url);

        // لو الـ Token انتهى (401) ومحاولنش نجدده قبل كده
        if (error.response?.status === 401 && !originalRequest._retry) {
            originalRequest._retry = true;
            console.log('[v0] Attempting token refresh...');

            try {
                const refreshToken = localStorage.getItem('refreshToken');
                console.log('[v0] Refresh token exists:', !!refreshToken);

                if (!refreshToken) {
                    throw new Error('No refresh token');
                }

                // استخدام axios مباشرة بدون الـ interceptors
                const response = await axios.post(`${API_URL}/users/refresh-token`, {
                    refreshToken,
                }, {
                    headers: { 'Content-Type': 'application/json' }
                });

                console.log('[v0] Token refresh successful');

                const { accessToken, refreshToken: newRefreshToken } = response.data;

                localStorage.setItem('accessToken', accessToken);
                localStorage.setItem('refreshToken', newRefreshToken);

                // إعادة الطلب الأصلي بالـ Token الجديد
                originalRequest.headers.Authorization = `Bearer ${accessToken}`;
                return apiClient(originalRequest);
            } catch (refreshError) {
                console.log('[v0] Token refresh failed:', refreshError);

                // فشل تجديد الـ Token - نسجل خروج المستخدم
                localStorage.removeItem('accessToken');
                localStorage.removeItem('refreshToken');
                localStorage.removeItem('user');
                localStorage.removeItem('isLoggedIn');

                // توجيه للـ Login
                if (window.location.pathname !== '/login') {
                    window.location.href = '/login';
                }
                return Promise.reject(refreshError);
            }
        }

        return Promise.reject(error);
    }
);

export default apiClient;