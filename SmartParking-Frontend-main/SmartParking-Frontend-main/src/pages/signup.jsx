import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Mail, Lock, User, Phone, Briefcase, Loader2, ArrowRight, Eye, EyeOff, CheckCircle2, Home } from 'lucide-react';
import userService from '../services/userService';

const SignUp = () => {
    const navigate = useNavigate();
    const [loading, setLoading] = useState(false);
    const [showPassword, setShowPassword] = useState(false);

    const [formData, setFormData] = useState({
        fullName: '',
        email: '',
        phoneNumber: '',
        password: '',
        role: 'User'
    });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSignUp = async (e) => {
        e.preventDefault();
        setLoading(true);

        try {
            const userPayload = {
                fullName: formData.fullName,
                email: formData.email,
                phoneNumber: formData.phoneNumber,
                password: formData.password,
                role: formData.role,
                accountType: formData.role === "Admin" ? "Business Owner" : "Individual",
                status: "Active"
            };

            await userService.createUser(userPayload);
            alert("تم إنشاء الحساب بنجاح");
            navigate('/admin/users');
        } catch (error) {
            console.error("Signup Error Details:", error.response?.data);
            alert("فشل التسجيل: تأكد من تشغيل السيرفر وصحة البيانات");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="min-h-screen flex bg-white font-sans">
            <div className="w-full lg:w-1/2 flex items-center justify-center p-8 lg:p-20 bg-white relative">
                <div className="absolute top-8 left-8 lg:left-20">
                    {/* التعديل هنا: Go Home */}
                    <Link to="/" className="flex items-center gap-2 text-slate-500 hover:text-blue-600 font-bold text-sm transition-colors group">
                        <Home size={18} className="group-hover:-translate-y-0.5 transition-transform" />
                        Go Home
                    </Link>
                </div>

                <div className="max-w-[460px] w-full mt-10">
                    <div className="mb-8">
                        <div className="flex items-center gap-3 mb-6">
                            <div className="w-10 h-10 bg-blue-600 rounded-xl flex items-center justify-center text-white shadow-lg shadow-blue-200">
                                <div className="border-2 border-white w-5 h-5 rounded-sm"></div>
                            </div>
                            <h3 className="text-lg font-black text-slate-800 tracking-tight">RealPark</h3>
                        </div>
                        <h2 className="text-4xl font-black text-slate-800 mb-2 tracking-tight">Create Account</h2>
                        <p className="text-slate-500 font-medium">Join RealPark today and start your journey</p>
                    </div>

                    <form className="space-y-4" onSubmit={handleSignUp}>
                        <div className="space-y-1.5">
                            <label className="text-sm font-bold text-slate-700 ml-1">Full Name</label>
                            <div className="relative group">
                                <User className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <input type="text" name="fullName" required value={formData.fullName} onChange={handleChange} className="w-full pl-12 pr-5 py-3.5 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 outline-none transition-all font-medium" placeholder="Youssef Zeidan" />
                            </div>
                        </div>

                        <div className="space-y-1.5">
                            <label className="text-sm font-bold text-slate-700 ml-1">Email Address</label>
                            <div className="relative group">
                                <Mail className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <input type="email" name="email" required value={formData.email} onChange={handleChange} className="w-full pl-12 pr-5 py-3.5 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 outline-none transition-all font-medium" placeholder="you@example.com" />
                            </div>
                        </div>

                        <div className="space-y-1.5">
                            <label className="text-sm font-bold text-slate-700 ml-1">Phone Number</label>
                            <div className="relative group">
                                <Phone className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <input type="tel" name="phoneNumber" required value={formData.phoneNumber} onChange={handleChange} className="w-full pl-12 pr-5 py-3.5 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 outline-none transition-all font-medium" placeholder="+20 123 456 7890" />
                            </div>
                        </div>

                        <div className="space-y-1.5">
                            <label className="text-sm font-bold text-slate-700 ml-1">Password</label>
                            <div className="relative group">
                                <Lock className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <input type={showPassword ? "text" : "password"} name="password" required value={formData.password} onChange={handleChange} className="w-full pl-12 pr-12 py-3.5 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 outline-none transition-all font-medium" placeholder="••••••••" />
                                <button type="button" onClick={() => setShowPassword(!showPassword)} className="absolute right-4 top-1/2 -translate-y-1/2 text-slate-300 hover:text-slate-600 transition-colors">
                                    {showPassword ? <EyeOff size={18} /> : <Eye size={18} />}
                                </button>
                            </div>
                        </div>

                        <div className="space-y-1.5">
                            <label className="text-sm font-bold text-slate-700 ml-1">Account Type</label>
                            <div className="relative group">
                                <Briefcase className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <select name="role" value={formData.role} onChange={handleChange} className="w-full pl-12 pr-5 py-3.5 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white outline-none transition-all font-medium appearance-none">
                                    <option value="User">Individual</option>
                                    <option value="Admin">Business Owner</option>
                                </select>
                            </div>
                        </div>

                        <button type="submit" disabled={loading} className="w-full bg-blue-600 text-white py-4 rounded-2xl font-black shadow-xl shadow-blue-200 hover:bg-blue-700 active:scale-[0.98] transition-all flex items-center justify-center gap-3 mt-4">
                            {loading ? <Loader2 className="animate-spin" size={20} /> : <>Create Account <ArrowRight size={20} /></>}
                        </button>
                    </form>

                    <div className="mt-8">
                        <div className="relative mb-6">
                            <div className="absolute inset-0 flex items-center">
                                <span className="w-full border-t border-slate-100"></span>
                            </div>
                            <div className="relative flex justify-center text-[10px] uppercase font-black tracking-[0.2em]">
                                <span className="bg-white px-4 text-slate-400">Already a member?</span>
                            </div>
                        </div>
                        <Link to="/login" className="w-full flex items-center justify-center gap-2 py-4 rounded-2xl border-2 border-slate-100 font-black text-slate-700 hover:bg-slate-50 hover:border-blue-100 hover:text-blue-600 transition-all active:scale-[0.98]">
                            Sign In to Your Account
                        </Link>
                    </div>
                </div>
            </div>

            <div className="hidden lg:flex lg:w-1/2 bg-blue-600 relative overflow-hidden p-16 flex-col justify-center text-white">
                <div className="absolute top-[-10%] left-[-10%] w-[500px] h-[500px] bg-blue-500 rounded-full opacity-20 blur-3xl"></div>
                <div className="relative z-10 max-w-md">
                    <h1 className="text-5xl font-black leading-tight mb-10">Find Your Dream Property with RealPark</h1>
                    <div className="space-y-6">
                        {['Secure Gate Access with QR Codes', 'Real-time Parking Spot Availability', 'Smart Property Management Tools'].map((text, i) => (
                            <div key={i} className="flex items-center gap-4">
                                <div className="w-6 h-6 bg-blue-400/30 rounded-full flex items-center justify-center">
                                    <CheckCircle2 size={16} />
                                </div>
                                <p className="font-bold text-blue-100">{text}</p>
                            </div>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    );
};

export default SignUp;