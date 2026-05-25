import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Mail, ArrowLeft, CheckCircle2, Loader2 } from 'lucide-react';

const ForgotPassword = () => {
    const [email, setEmail] = useState('');
    const [isSent, setIsSent] = useState(false);
    const [loading, setLoading] = useState(false);

    const handleSubmit = (e) => {
        e.preventDefault();
        setLoading(true);
        setTimeout(() => {
            setLoading(false);
            setIsSent(true);
        }, 1500);
    };

    return (
        <div className="min-h-screen flex items-center justify-center bg-[#F8FAFC] p-6">
            <div className="max-w-[440px] w-full bg-white p-10 rounded-[32px] shadow-xl shadow-slate-200/50">
                {!isSent ? (
                    <>
                        <div className="mb-8">
                            <h2 className="text-3xl font-black text-slate-800 mb-2">Reset Password</h2>
                            <p className="text-slate-500 font-medium">Enter your email and we'll send you a link to reset your password.</p>
                        </div>
                        <form onSubmit={handleSubmit} className="space-y-6">
                            <div className="space-y-2">
                                <label className="text-sm font-bold text-slate-700 ml-1">Email Address</label>
                                <div className="relative group">
                                    <Mail className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-blue-600 transition-colors" size={20} />
                                    <input
                                        type="email"
                                        required
                                        value={email}
                                        onChange={(e) => setEmail(e.target.value)}
                                        className="w-full pl-12 pr-5 py-4 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white outline-none transition-all font-medium"
                                        placeholder="you@example.com"
                                    />
                                </div>
                            </div>
                            <button type="submit" disabled={loading} className="w-full bg-blue-600 text-white py-4 rounded-2xl font-black hover:bg-blue-700 transition-all flex items-center justify-center gap-2">
                                {loading ? <Loader2 className="animate-spin" size={20} /> : "Send Reset Link"}
                            </button>
                        </form>
                    </>
                ) : (
                    <div className="text-center py-4">
                        <div className="w-20 h-20 bg-green-100 text-green-600 rounded-full flex items-center justify-center mx-auto mb-6">
                            <CheckCircle2 size={40} />
                        </div>
                        <h2 className="text-2xl font-black text-slate-800 mb-2">Check your email</h2>
                        <p className="text-slate-500 font-medium mb-8">We've sent a password reset link to <br /><span className="text-slate-800 font-bold">{email}</span></p>
                    </div>
                )}

                <Link to="/login" className="flex items-center justify-center gap-2 text-slate-400 hover:text-blue-600 font-bold mt-8 transition-colors">
                    <ArrowLeft size={18} />
                    Back to Login
                </Link>
            </div>
        </div>
    );
};

export default ForgotPassword;