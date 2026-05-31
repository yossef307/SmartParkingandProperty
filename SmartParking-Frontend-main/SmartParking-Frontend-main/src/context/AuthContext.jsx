import React, { createContext, useContext, useState, useEffect, useCallback } from 'react';
import axios from 'axios';
import userService from '../services/userService';
import apiClient from '../services/apiClient';

const AuthContext = createContext(null);

// ثابت الـ API URL مشترك
const API_URL = import.meta.env.VITE_API_URL || 'https://localhost:7144/api';

// دالة مساعدة لمسح كل بيانات الجلسة
const clearSession = () => {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
    localStorage.removeItem('user');
    localStorage.removeItem('isLoggedIn');
};

export const useAuth = () => {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error('useAuth must be used within an AuthProvider');
    }
    return context;
};

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [isLoading, setIsLoading] = useState(true);
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    // تحميل بيانات المستخدم من localStorage عند بدء التطبيق
    useEffect(() => {
        const loadUser = async () => {
            const accessToken = localStorage.getItem('accessToken');
            const refreshToken = localStorage.getItem('refreshToken');
            const storedUser = localStorage.getItem('user');

            // لو مفيش بيانات محفوظة أصلاً - مفيش داعي نعمل أي request
            if (!accessToken || !refreshToken || !storedUser) {
                setIsLoading(false);
                return;
            }

            try {
                // ✅ الإصلاح الأساسي: بنستخدم axios خام (مش apiClient) عشان نتجنب
                // حلقة الـ interceptor اللانهائية:
                // apiClient → 401 → interceptor يحاول refresh → نفس الـ endpoint → 401 مرة تانية
                const response = await axios.post(
                    `${API_URL}/users/refresh-token`,
                    { refreshToken },
                    { headers: { 'Content-Type': 'application/json' } }
                );

                // الـ token صالح - نحدث الـ tokens ونحمل المستخدم
                localStorage.setItem('accessToken', response.data.accessToken);
                localStorage.setItem('refreshToken', response.data.refreshToken);
                setUser(JSON.parse(storedUser));
                setIsAuthenticated(true);

            } catch {
                // الـ token منتهي أو مش صالح - نمسح كل حاجة بهدوء
                clearSession();
                setUser(null);
                setIsAuthenticated(false);
            } finally {
                setIsLoading(false);
            }
        };

        loadUser();
    }, []);

    const login = useCallback(async (credentials) => {
        const response = await userService.login(credentials);

        // حفظ الـ Tokens بأمان
        localStorage.setItem('accessToken', response.accessToken);
        localStorage.setItem('refreshToken', response.refreshToken);
        localStorage.setItem('isLoggedIn', 'true');

        // حفظ بيانات المستخدم (بدون بيانات حساسة)
        const userData = {
            id: response.id,
            fullName: response.fullName,
            email: response.email,
            role: response.role,
            phone: response.phone,
            carPlateNumber: response.carPlateNumber,
            hasLinkedCard: response.hasLinkedCard,
        };

        localStorage.setItem('user', JSON.stringify(userData));
        setUser(userData);
        setIsAuthenticated(true);

        return response;
    }, []);

    const register = useCallback(async (userData) => {
        const response = await userService.register(userData);

        localStorage.setItem('accessToken', response.accessToken);
        localStorage.setItem('refreshToken', response.refreshToken);
        localStorage.setItem('isLoggedIn', 'true');

        const user = {
            id: response.id,
            fullName: response.fullName,
            email: response.email,
            role: response.role,
            phone: response.phone,
            carPlateNumber: response.carPlateNumber,
            hasLinkedCard: response.hasLinkedCard,
        };

        localStorage.setItem('user', JSON.stringify(user));
        setUser(user);
        setIsAuthenticated(true);

        return response;
    }, []);

    const logout = useCallback(async () => {
        try {
            await userService.logout();
        } catch (error) {
            console.error('Logout error:', error);
        } finally {
            clearSession();
            setUser(null);
            setIsAuthenticated(false);
        }
    }, []);

    const updateUser = useCallback((updatedData) => {
        const newUserData = { ...user, ...updatedData };
        setUser(newUserData);
        localStorage.setItem('user', JSON.stringify(newUserData));
    }, [user]);

    const isAdmin = user?.role?.toLowerCase() === 'admin';

    const value = {
        user,
        isLoading,
        isAuthenticated,
        isAdmin,
        login,
        register,
        logout,
        updateUser,
    };

    return (
        <AuthContext.Provider value={value}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthContext;