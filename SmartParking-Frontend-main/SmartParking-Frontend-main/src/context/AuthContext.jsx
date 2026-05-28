import React, { createContext, useContext, useState, useEffect, useCallback } from 'react';
import axios from 'axios';
import userService from '../services/userService';
import apiClient from '../services/apiClient';

const AuthContext = createContext(null);

const API_URL = import.meta.env.VITE_API_URL || 'https://localhost:7144/api';

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

    useEffect(() => {
        const loadUser = async () => {
            try {
                const accessToken = localStorage.getItem('accessToken');
                const storedUser = localStorage.getItem('user');
                const refreshToken = localStorage.getItem('refreshToken');

                if (!accessToken || !storedUser || !refreshToken) {
                    setIsLoading(false);
                    return;
                }

                try {
                    // ✅ استخدام axios مباشرة (مش apiClient) عشان نتجنب الـ interceptor loop
                    const response = await axios.post(
                        `${API_URL}/users/refresh-token`,
                        { refreshToken },
                        { headers: { 'Content-Type': 'application/json' } }
                    );

                    localStorage.setItem('accessToken', response.data.accessToken);
                    localStorage.setItem('refreshToken', response.data.refreshToken);

                    setUser(JSON.parse(storedUser));
                    setIsAuthenticated(true);
                } catch (apiError) {
                    // الـ refresh token انتهى → مسح البيانات
                    console.error('Token validation failed:', apiError.response?.status);
                    clearAuth();
                }
            } catch (error) {
                console.error('Error loading user:', error);
                clearAuth();
            } finally {
                setIsLoading(false);
            }
        };

        loadUser();
    }, []);

    const clearAuth = () => {
        localStorage.removeItem('user');
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
        localStorage.removeItem('isLoggedIn');
        setUser(null);
        setIsAuthenticated(false);
    };

    const login = useCallback(async (credentials) => {
        const response = await userService.login(credentials);

        localStorage.setItem('accessToken', response.accessToken);
        localStorage.setItem('refreshToken', response.refreshToken);
        localStorage.setItem('isLoggedIn', 'true');

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
            clearAuth();
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