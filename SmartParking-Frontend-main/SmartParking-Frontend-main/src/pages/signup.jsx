import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Mail, Lock, User, Phone, Car, ArrowRight, Home, Loader2, ChevronLeft } from 'lucide-react';
import { useAuth } from '../context/AuthContext';

const SignUp = () => {
    const navigate = useNavigate();
    const { register } = useAuth();

    const [formData, setFormData] = useState({
        fullName: '',
        email: '',
        password: '',
        confirmPassword: '',
        phone: '',
        carPlateNumber: '',
        accountType: 'Individual'
    });

    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');
    const [fieldErrors, setFieldErrors] = useState({});

    const validateForm = () => {
        const errors = {};

        if (!formData.fullName.trim()) {
            errors.fullName = 'الاسم الكامل مطلوب';
        } else if (formData.fullName.trim().length < 2) {
            errors.fullName = 'الاسم يجب أن يكون حرفين على الأقل';
        }

        if (!formData.email.trim()) {
            errors.email = 'البريد الإلكتروني مطلوب';
        } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(formData.email)) {
            errors.email = 'البريد الإلكتروني غير صالح';
        }

        if (!formData.password) {
            errors.password = 'كلمة المرور مطلوبة';
        } else if (formData.password.length < 8) {
            errors.password = 'كلمة المرور يجب أن تكون 8 أحرف على الأقل';
        } else if (!/(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])/.test(formData.password)) {
            errors.password = 'كلمة المرور يجب أن تحتوي على حرف كبير وصغير ورقم ورمز خاص';
        }

        if (formData.password !== formData.confirmPassword) {
            errors.confirmPassword = 'كلمات المرور غير متطابقة';
        }

        setFieldErrors(errors);
        return Object.keys(errors).length === 0;
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prev => ({ ...prev, [name]: value }));

        // Clear field error when user types
        if (fieldErrors[name]) {
            setFieldErrors(prev => ({ ...prev, [name]: '' }));
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError('');

        if (!validateForm()) {
            return;
        }

        setLoading(true);

        try {
            const registerData = {
                fullName: formData.fullName.trim(),
                email: formData.email.trim().toLowerCase(),
                password: formData.password,
                phone: formData.phone.trim() || null,
                carPlateNumber: formData.carPlateNumber.trim() || null,
                accountType: formData.accountType
            };

            console.log('[v0] Register data:', registerData);

            await register(registerData);
            navigate('/dashboard');
        } catch (err) {
            console.log('[v0] Signup Error:', err);
            console.log('[v0] Error response:', err.response);
            console.log('[v0] Error data:', err.response?.data);

            const errorMsg = err.response?.data?.message
                || err.response?.data?.title
                || err.response?.data?.errors?.[0]
                || err.message
                || 'حدث خطأ أثناء التسجيل. حاول مرة أخرى.';

            setError(errorMsg);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="min-h-screen bg-white flex font-sans selection:bg-blue-100 selection:text-blue-600">
            {/* Left Side: SignUp Form */}
            <div className="w-full lg:w-1/2 flex flex-col justify-center px-8 md:px-16 lg:px-24 py-12 relative">
                {/* Home Button */}
                <Link
                    to="/"
                    className="absolute top-10 left-8 md:left-12 flex items-center gap-1.5 text-slate-400 hover:text-blue-600 transition-all font-black text-[10px] uppercase tracking-widest group"
                >
                    <ChevronLeft size={16} className="group-hover:-translate-x-1 transition-transform" />
                    Back to Home Page
                </Link>

                <div className="max-w-[400px] w-full mx-auto">
                    {/* Logo & Brand */}
                    <div className="flex items-center gap-3 mb-8">
                        <div className="bg-blue-600 p-2.5 rounded-2xl shadow-xl shadow-blue-100 ring-4 ring-blue-50">
                            <Home size={22} color="white" />
                        </div>
                        <div className="flex flex-col">
                            <span className="text-2xl font-black text-slate-800 leading-none tracking-tight">
                                Real<span className="text-blue-600">Park</span>
                            </span>
                            <span className="text-[10px] font-bold text-slate-400 uppercase tracking-[0.3em] mt-1">
                                Management System
                            </span>
                        </div>
                    </div>

                    <div className="mb-8">
                        <h2 className="text-3xl font-black text-slate-800 mb-3 tracking-tight">Create Account</h2>
                        <p className="text-slate-400 font-medium leading-relaxed">
                            Join us to manage your properties and smart parking.
                        </p>
                    </div>

                    {error && (
                        <div className="mb-6 p-4 bg-red-50 border-l-4 border-red-500 text-red-600 rounded-xl text-xs font-bold flex items-center gap-3">
                            <div className="w-2 h-2 bg-red-500 rounded-full animate-pulse" />
                            {error}
                        </div>
                    )}

                    <form onSubmit={handleSubmit} className="space-y-5">
                        {/* Full Name */}
                        <div className="space-y-2">
                            <label className="text-[11px] font-black uppercase tracking-widest text-slate-500 ml-1">
                                Full Name *
                            </label>
                            <div className="relative group">
                                <User className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-300 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <input
                                    type="text"
                                    name="fullName"
                                    value={formData.fullName}
                                    onChange={handleChange}
                                    placeholder="Enter your full name"
                                    className={`w-full bg-slate-50 border rounded-2xl py-4 pl-12 pr-4 outline-none focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 transition-all font-bold text-slate-700 ${fieldErrors.fullName ? 'border-red-500' : 'border-slate-100'}`}
                                    required
                                />
                            </div>
                            {fieldErrors.fullName && (
                                <p className="text-red-500 text-xs font-bold ml-1">{fieldErrors.fullName}</p>
                            )}
                        </div>

                        {/* Email */}
                        <div className="space-y-2">
                            <label className="text-[11px] font-black uppercase tracking-widest text-slate-500 ml-1">
                                Email Address *
                            </label>
                            <div className="relative group">
                                <Mail className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-300 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <input
                                    type="email"
                                    name="email"
                                    value={formData.email}
                                    onChange={handleChange}
                                    placeholder="name@company.com"
                                    className={`w-full bg-slate-50 border rounded-2xl py-4 pl-12 pr-4 outline-none focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 transition-all font-bold text-slate-700 ${fieldErrors.email ? 'border-red-500' : 'border-slate-100'}`}
                                    required
                                />
                            </div>
                            {fieldErrors.email && (
                                <p className="text-red-500 text-xs font-bold ml-1">{fieldErrors.email}</p>
                            )}
                        </div>

                        {/* Password */}
                        <div className="space-y-2">
                            <label className="text-[11px] font-black uppercase tracking-widest text-slate-500 ml-1">
                                Password *
                            </label>
                            <div className="relative group">
                                <Lock className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-300 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <input
                                    type="password"
                                    name="password"
                                    value={formData.password}
                                    onChange={handleChange}
                                    placeholder="Min 8 characters"
                                    className={`w-full bg-slate-50 border rounded-2xl py-4 pl-12 pr-4 outline-none focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 transition-all font-bold text-slate-700 ${fieldErrors.password ? 'border-red-500' : 'border-slate-100'}`}
                                    required
                                />
                            </div>
                            {fieldErrors.password && (
                                <p className="text-red-500 text-xs font-bold ml-1">{fieldErrors.password}</p>
                            )}
                        </div>

                        {/* Confirm Password */}
                        <div className="space-y-2">
                            <label className="text-[11px] font-black uppercase tracking-widest text-slate-500 ml-1">
                                Confirm Password *
                            </label>
                            <div className="relative group">
                                <Lock className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-300 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <input
                                    type="password"
                                    name="confirmPassword"
                                    value={formData.confirmPassword}
                                    onChange={handleChange}
                                    placeholder="Confirm your password"
                                    className={`w-full bg-slate-50 border rounded-2xl py-4 pl-12 pr-4 outline-none focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 transition-all font-bold text-slate-700 ${fieldErrors.confirmPassword ? 'border-red-500' : 'border-slate-100'}`}
                                    required
                                />
                            </div>
                            {fieldErrors.confirmPassword && (
                                <p className="text-red-500 text-xs font-bold ml-1">{fieldErrors.confirmPassword}</p>
                            )}
                        </div>

                        {/* Phone (Optional) */}
                        <div className="space-y-2">
                            <label className="text-[11px] font-black uppercase tracking-widest text-slate-500 ml-1">
                                Phone Number (Optional)
                            </label>
                            <div className="relative group">
                                <Phone className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-300 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <input
                                    type="tel"
                                    name="phone"
                                    value={formData.phone}
                                    onChange={handleChange}
                                    placeholder="+20 123 456 7890"
                                    className="w-full bg-slate-50 border border-slate-100 rounded-2xl py-4 pl-12 pr-4 outline-none focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 transition-all font-bold text-slate-700"
                                />
                            </div>
                        </div>

                        {/* Car Plate (Optional) */}
                        <div className="space-y-2">
                            <label className="text-[11px] font-black uppercase tracking-widest text-slate-500 ml-1">
                                Car Plate Number (Optional)
                            </label>
                            <div className="relative group">
                                <Car className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-300 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <input
                                    type="text"
                                    name="carPlateNumber"
                                    value={formData.carPlateNumber}
                                    onChange={handleChange}
                                    placeholder="ABC 1234"
                                    className="w-full bg-slate-50 border border-slate-100 rounded-2xl py-4 pl-12 pr-4 outline-none focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 transition-all font-bold text-slate-700"
                                />
                            </div>
                        </div>

                        {/* Account Type */}
                        <div className="space-y-2">
                            <label className="text-[11px] font-black uppercase tracking-widest text-slate-500 ml-1">
                                Account Type
                            </label>
                            <select
                                name="accountType"
                                value={formData.accountType}
                                onChange={handleChange}
                                className="w-full bg-slate-50 border border-slate-100 rounded-2xl py-4 px-4 outline-none focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 transition-all font-bold text-slate-700"
                            >
                                <option value="Individual">Individual</option>
                                <option value="Business">Business</option>
                            </select>
                        </div>

                        <button
                            type="submit"
                            disabled={loading}
                            className="w-full bg-blue-600 text-white py-5 rounded-2xl font-black shadow-2xl shadow-blue-100 hover:bg-blue-700 active:scale-[0.98] transition-all flex items-center justify-center gap-3 group mt-4 disabled:opacity-70"
                        >
                            {loading ? (
                                <Loader2 className="animate-spin" size={22} />
                            ) : (
                                <>
                                    <span>Create Account</span>
                                    <ArrowRight size={18} className="group-hover:translate-x-1 transition-transform" />
                                </>
                            )}
                        </button>
                    </form>

                    <div className="mt-8 pt-6 border-t border-slate-100 text-center">
                        <p className="text-slate-400 font-bold text-[10px] uppercase tracking-[0.2em] mb-4">
                            Already have an account?
                        </p>
                        <Link
                            to="/login"
                            className="inline-flex items-center justify-center w-full py-4 border-2 border-slate-100 rounded-2xl font-black text-slate-600 hover:bg-slate-50 hover:border-slate-200 transition-all text-sm active:scale-[0.98]"
                        >
                            Sign In
                        </Link>
                    </div>
                </div>
            </div>

            {/* Right Side: Marketing Visual */}
            <div className="hidden lg:flex w-1/2 bg-blue-600 items-center justify-center p-24 relative overflow-hidden">
                <div className="absolute top-0 right-0 w-[600px] h-[600px] bg-blue-500 rounded-full -mr-32 -mt-32 blur-[140px] opacity-60" />
                <div className="absolute bottom-0 left-0 w-[600px] h-[600px] bg-blue-700 rounded-full -ml-32 -mb-32 blur-[140px] opacity-60" />
                <div className="relative z-10 text-center text-white">
                    <h3 className="text-4xl font-black mb-4">Join Smart Parking</h3>
                    <p className="text-blue-100 text-lg">Start managing your properties today</p>
                </div>
            </div>
        </div>
    );
};

export default SignUp;