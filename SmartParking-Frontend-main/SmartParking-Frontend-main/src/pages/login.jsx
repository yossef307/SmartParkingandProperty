import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Mail, Lock, ArrowRight, Home, Loader2, ChevronLeft } from 'lucide-react';
import { useAuth } from '../context/AuthContext';

const Login = () => {
    const navigate = useNavigate();
    const { login } = useAuth();
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');

    const handleLogin = async (e) => {
        e.preventDefault();
        setLoading(true);
        setError('');

        try {
            const response = await login({ email, password });

            if (response.role === 'admin') {
                navigate('/admin/users');
            } else {
                navigate('/dashboard');
            }
        } catch (err) {
            const errorMsg = err.response?.data?.message || 'Invalid email or password. Please try again.';
            setError(errorMsg);
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="min-h-screen bg-white flex font-sans selection:bg-blue-100 selection:text-blue-600">
            {/* Left Side: Login Form */}
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
                    <div className="flex items-center gap-3 mb-10">
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

                    <div className="mb-10">
                        <h2 className="text-4xl font-black text-slate-800 mb-3 tracking-tight">Welcome Back</h2>
                        <p className="text-slate-400 font-medium leading-relaxed">
                            Log in to access your properties, smart parking spots, and security settings.
                        </p>
                    </div>

                    {error && (
                        <div className="mb-8 p-4 bg-red-50 border-l-4 border-red-500 text-red-600 rounded-xl text-xs font-bold flex items-center gap-3">
                            <div className="w-2 h-2 bg-red-500 rounded-full animate-pulse" />
                            {error}
                        </div>
                    )}

                    <form onSubmit={handleLogin} className="space-y-6">
                        {/* Email */}
                        <div className="space-y-2.5">
                            <label className="text-[11px] font-black uppercase tracking-widest text-slate-500 ml-1">
                                Work Email
                            </label>
                            <div className="relative group">
                                <Mail className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-300 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <input
                                    type="email"
                                    value={email}
                                    onChange={(e) => setEmail(e.target.value)}
                                    placeholder="name@company.com"
                                    className="w-full bg-slate-50 border border-slate-100 rounded-2xl py-4 pl-12 pr-4 outline-none focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 transition-all font-bold text-slate-700"
                                    required
                                    autoComplete="email"
                                />
                            </div>
                        </div>

                        {/* Password */}
                        <div className="space-y-2.5">
                            <div className="flex justify-between items-end px-1">
                                <label className="text-[11px] font-black uppercase tracking-widest text-slate-500">
                                    Security Password
                                </label>
                                <Link
                                    to="/forgot-password"
                                    className="text-[10px] font-black uppercase tracking-wider text-blue-600 hover:text-blue-800 transition-colors"
                                >
                                    Lost Password?
                                </Link>
                            </div>
                            <div className="relative group">
                                <Lock className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-300 group-focus-within:text-blue-600 transition-colors" size={18} />
                                <input
                                    type="password"
                                    value={password}
                                    onChange={(e) => setPassword(e.target.value)}
                                    placeholder="Enter your password"
                                    className="w-full bg-slate-50 border border-slate-100 rounded-2xl py-4 pl-12 pr-4 outline-none focus:border-blue-600 focus:bg-white focus:ring-4 focus:ring-blue-50 transition-all font-bold text-slate-700"
                                    required
                                    autoComplete="current-password"
                                />
                            </div>
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
                                    <span>Secure Sign In</span>
                                    <ArrowRight size={18} className="group-hover:translate-x-1 transition-transform" />
                                </>
                            )}
                        </button>
                    </form>

                    <div className="mt-12 pt-8 border-t border-slate-100 text-center">
                        <p className="text-slate-400 font-bold text-[10px] uppercase tracking-[0.2em] mb-5">
                            New to the platform?
                        </p>
                        <Link
                            to="/register"
                            className="inline-flex items-center justify-center w-full py-4 border-2 border-slate-100 rounded-2xl font-black text-slate-600 hover:bg-slate-50 hover:border-slate-200 transition-all text-sm active:scale-[0.98]"
                        >
                            Create New Account
                        </Link>
                    </div>
                </div>
            </div>

            {/* Right Side: Marketing Visual */}
            <div className="hidden lg:flex w-1/2 bg-blue-600 items-center justify-center p-24 relative overflow-hidden">
                <div className="absolute top-0 right-0 w-[600px] h-[600px] bg-blue-500 rounded-full -mr-32 -mt-32 blur-[140px] opacity-60" />
                <div className="absolute bottom-0 left-0 w-[600px] h-[600px] bg-blue-700 rounded-full -ml-32 -mb-32 blur-[140px] opacity-60" />
                <div className="relative z-10 text-center text-white">
                    <h3 className="text-4xl font-black mb-4">Smart Parking</h3>
                    <p className="text-blue-100 text-lg">Manage your properties with ease</p>
                </div>
            </div>
        </div>
    );
};

export default Login;