import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Save, Loader2, User } from 'lucide-react';

const Settings = () => {
    const [formData, setFormData] = useState({
        fullName: '',
        email: '',
        phone: '',
        carPlateNumber: ''
    });
    const [loading, setLoading] = useState(false);
    const [statusMessage, setStatusMessage] = useState({ type: '', text: '' });

    useEffect(() => {
        const rawData = localStorage.getItem('user');
        if (rawData) {
            try {
                const savedUser = JSON.parse(rawData);
                setFormData({
                    fullName: savedUser.fullName || '',
                    email: savedUser.email || '',
                    phone: savedUser.phone || '',
                    carPlateNumber: savedUser.carPlateNumber || ''
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
            const response = await axios.put('https://localhost:7048/api/users/update-profile', formData);
            if (response.status === 200) {
                setStatusMessage({ type: 'success', text: 'Profile updated successfully! ✅' });
                const currentUser = JSON.parse(localStorage.getItem('user')) || {};
                const updatedUser = { ...currentUser, ...formData };
                localStorage.setItem('user', JSON.stringify(updatedUser));
            }
        } catch (error) {
            setStatusMessage({ type: 'error', text: 'Failed to update. Check server connection. ❌' });
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="min-h-screen bg-[#F8FAFC] p-8">
            <div className="max-w-[800px] mx-auto">
                <div className="mb-10">
                    <h2 className="text-3xl font-black text-slate-800">Account Settings</h2>
                    <p className="text-slate-500 font-medium">Manage your personal information and preferences.</p>
                </div>

                <div className="bg-white p-8 rounded-[32px] shadow-sm border border-gray-100">
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

const InputGroup = ({ label, value, onChange, disabled }) => (
    <div className="space-y-2">
        <label className="text-[11px] font-black text-slate-400 uppercase tracking-widest ml-1">{label}</label>
        <input
            type="text"
            value={value}
            onChange={onChange}
            disabled={disabled}
            className={`w-full px-5 py-4 bg-slate-50 border border-transparent rounded-2xl outline-none focus:bg-white focus:border-blue-600 focus:ring-4 focus:ring-blue-50 transition-all font-bold text-slate-700 ${disabled ? 'opacity-50 cursor-not-allowed bg-slate-100' : ''
                }`}
        />
    </div>
);

export default Settings;