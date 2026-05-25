import React, { createContext, useContext, useState, useEffect, useCallback } from 'react';
import userService from '../services/userService';

const AuthContext = createContext(null);

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
        const loadUser = () => {
            try {
                const accessToken = localStorage.getItem('accessToken');
                const storedUser = localStorage.getItem('user');

                if (accessToken && storedUser) {
                    setUser(JSON.parse(storedUser));
                    setIsAuthenticated(true);
                }
            } catch (error) {
                console.error('Error loading user:', error);
                localStorage.removeItem('user');
                localStorage.removeItem('accessToken');
                localStorage.removeItem('refreshToken');
                localStorage.removeItem('isLoggedIn');
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

    // ✅ تم إصلاح الـ logout - الآن يمسح كل الـ localStorage
    const logout = useCallback(async () => {
        try {
            await userService.logout();
        } catch (error) {
            console.error('Logout error:', error);
        } finally {
            // مسح كل بيانات المستخدم من localStorage
            localStorage.removeItem('accessToken');
            localStorage.removeItem('refreshToken');
            localStorage.removeItem('user');
            localStorage.removeItem('isLoggedIn');

            // تحديث الـ State
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