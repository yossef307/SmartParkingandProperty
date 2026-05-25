import React, { useState, useEffect } from 'react';
import apiClient from '../services/apiClient';  // ✅ تم التغيير من axios إلى apiClient
import { Save, Loader2, User, CreditCard } from 'lucide-react';

const Settings = () => {
    const [formData, setFormData] = useState({
        fullName: '',
        email: '',
        phone: '',
        carPlateNumber: '',
        // 💳 حقول الفيزا متطابقة تماماً مع الـ Backend
        cardNumber: '',
        cardHolderName: '',
        cardExpiryMonth: '',
        cardExpiryYear: ''
    });

    // ستايت إضافي للاحتفاظ بالباسورد القادمة مع اليوزر لمنع خطأ الـ Backend
    const [userPassword, setUserPassword] = useState('');
    const [loading, setLoading] = useState(false);
    const [statusMessage, setStatusMessage] = useState({ type: '', text: '' });

    useEffect(() => {
        const rawData = localStorage.getItem('user');
        if (rawData) {
            try {
                const savedUser = JSON.parse(rawData);

                // حفظ الباسورد في الـ State لو كانت موجودة، أو وضع الباسورد الافتراضية للمشروع لتجنب الـ 400
                setUserPassword(savedUser.password || '123456');

                setFormData({
                    fullName: savedUser.fullName || '',
                    email: savedUser.email || '',
                    phone: savedUser.phone || '',
                    carPlateNumber: savedUser.carPlateNumber || '',
                    cardNumber: savedUser.cardNumber || '',
                    cardHolderName: savedUser.cardHolderName || '',
                    cardExpiryMonth: savedUser.cardExpiryMonth || '',
                    cardExpiryYear: savedUser.cardExpiryYear || ''
                });
            } catch (error) {
                console.error("Error parsing user data:", error);
            }
        }
    }, []);

    const handleUpdateProfile = async () => {
        setLoading(true);
        setStatusMessage({ type: '', text: '' });
        try {
            // 🔑 دمج الباسورد المطلوبة (Required) مع الـ formData لحل مشكلة الـ 400 Bad Request تلقائياً
            const payload = {
                ...formData,
                password: userPassword
            };

            // ✅ استخدام apiClient بدلاً من axios - هذا يرسل الـ Token تلقائياً
            const response = await apiClient.put('/users/update-profile', payload);

            if (response.status === 200) {
                setStatusMessage({ type: 'success', text: 'Account settings updated successfully!' });
                const currentUser = JSON.parse(localStorage.getItem('user')) || {};

                // تحديث الـ LocalStorage بالبيانات الجديدة مع حساب خاصية الـ hasLinkedCard تلقائياً
                const updatedUser = {
                    ...currentUser,
                    ...formData,
                    password: userPassword, // الحفاظ على الباسورد مخزنة محلياً
                    hasLinkedCard: formData.cardNumber.trim().length >= 16 // تصبح true عند إدخال فيزا كاملة 16 رقم
                };
                localStorage.setItem('user', JSON.stringify(updatedUser));
            }
        } catch (error) {
            console.error("Update Error details:", error.response?.data);
            const errorText = error.response?.data?.errors
                ? Object.values(error.response.data.errors).flat().join(', ')
                : 'Failed to update. Check server connection.';
            setStatusMessage({ type: 'error', text: errorText });
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="min-h-screen bg-[#F8FAFC] p-8 text-left">
            <div className="max-w-[800px] mx-auto">
                <div className="mb-10">
                    <h2 className="text-3xl font-black text-slate-800">Account Settings</h2>
                    <p className="text-slate-500 font-medium">Manage your personal information and preferences.</p>
                </div>

                {/* كارت البيانات الشخصية */}
                <div className="bg-white p-8 rounded-[32px] shadow-sm border border-gray-100 mb-8">
                    <div className="flex justify-between items-center mb-8 border-b border-gray-50 pb-6">
                        <div className="flex items-center gap-3">
                            <div className="p-3 bg-blue-50 text-blue-600 rounded-2xl">
                                <User size={24} />
                            </div>
                            <h3 className="text-xl font-black text-slate-800">Personal Information</h3>
                        </div>
                        {statusMessage.text && (
                            <span className={`text-sm font-bold ${statusMessage.type === 'success' ? 'text-green-500' : 'text-red-500'}`}>
                                {statusMessage.text}
                            </span>
                        )}
                    </div>

                    <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <InputGroup
                            label="Full Name"
                            value={formData.fullName}
                            onChange={(e) => setFormData({ ...formData, fullName: e.target.value })}
                        />
                        <InputGroup
                            label="Email Address"
                            value={formData.email}
                            disabled
                        />
                        <InputGroup
                            label="Phone Number"
                            value={formData.phone}
                            onChange={(e) => setFormData({ ...formData, phone: e.target.value })}
                        />
                        <InputGroup
                            label="Car Plate Number"
                            value={formData.carPlateNumber}
                            onChange={(e) => setFormData({ ...formData, carPlateNumber: e.target.value })}
                        />
                    </div>
                </div>

                {/* 💳 كارت ربط الفيزا الإجباري للحجز */}
                <div className="bg-white p-8 rounded-[32px] shadow-sm border border-gray-100">
                    <div className="flex items-center gap-3 mb-8 border-b border-gray-50 pb-6">
                        <div className="p-3 bg-blue-50 text-blue-600 rounded-2xl">
                            <CreditCard size={24} />
                        </div>
                        <div>
                            <h3 className="text-xl font-black text-slate-800">Payment Method</h3>
                            <p className="text-xs text-gray-400 font-bold mt-0.5">A registered payment card is mandatory to activate bookings.</p>
                        </div>
                    </div>

                    <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                        <InputGroup
                            label="Cardholder Name"
                            placeholder="e.g. Mahmoud Gaber"
                            value={formData.cardHolderName}
                            onChange={(e) => setFormData({ ...formData, cardHolderName: e.target.value })}
                        />
                        <InputGroup
                            label="Card Number (16 Digits)"
                            placeholder="e.g. 4111 1111 1111 1111"
                            maxLength="16"
                            value={formData.cardNumber}
                            onChange={(e) => setFormData({ ...formData, cardNumber: e.target.value.replace(/\D/g, '') })}
                        />
                        <div className="grid grid-cols-2 gap-4">
                            <InputGroup
                                label="Expiry Month"
                                placeholder="MM (e.g. 12)"
                                maxLength="2"
                                value={formData.cardExpiryMonth}
                                onChange={(e) => setFormData({ ...formData, cardExpiryMonth: e.target.value.replace(/\D/g, '') })}
                            />
                            <InputGroup
                                label="Expiry Year"
                                placeholder="YY (e.g. 28)"
                                maxLength="2"
                                value={formData.cardExpiryYear}
                                onChange={(e) => setFormData({ ...formData, cardExpiryYear: e.target.value.replace(/\D/g, '') })}
                            />
                        </div>
                    </div>

                    <div className="mt-10 flex justify-end">
                        <button
                            onClick={handleUpdateProfile}
                            disabled={loading}
                            className="bg-blue-600 text-white px-8 py-4 rounded-2xl font-black flex items-center gap-3 hover:bg-blue-700 transition-all active:scale-95 disabled:bg-slate-300 shadow-lg shadow-blue-100"
                        >
                            {loading ? <Loader2 className="animate-spin" size={20} /> : <Save size={20} />}
                            Save Changes
                        </button>
                    </div>
                </div>

            </div>
        </div>
    );
};

const InputGroup = ({ label, value, onChange, disabled, placeholder, maxLength }) => (
    <div className="space-y-2">
        <label className="text-[11px] font-black text-slate-400 uppercase tracking-widest ml-1">{label}</label>
        <input
            type="text"
            value={value}
            onChange={onChange}
            disabled={disabled}
            placeholder={placeholder}
            maxLength={maxLength}
            className={`w-full px-5 py-4 bg-slate-50 border border-transparent rounded-2xl outline-none focus:bg-white focus:border-blue-600 focus:ring-4 focus:ring-blue-50 transition-all font-bold text-slate-700 ${disabled ? 'opacity-50 cursor-not-allowed bg-slate-100' : ''
                }`}
        />
    </div>
);

export default Settings;