import React from 'react';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import { LogOut, Home, ShieldCheck } from 'lucide-react';
import { useAuth } from '../context/AuthContext';  // اضافة الـ import

const Navbar = () => {
    const location = useLocation();
    const navigate = useNavigate();

    // استخدام useAuth بدلا من localStorage مباشرة
    const { isAuthenticated, user, logout } = useAuth();

    const isActive = (path) => location.pathname === path;

    const handleLogout = async () => {
        if (window.confirm("Are you sure you want to logout?")) {
            await logout();  // استخدام logout من الـ Context
            navigate('/login', { replace: true });
        }
    };

    // استخراج البيانات من الـ user object
    const userName = user?.fullName || 'User';
    const userEmail = user?.email || '';
    const userRole = user?.role?.toLowerCase();

    return (
        <nav className="bg-white/90 backdrop-blur-md border-b border-gray-100 px-12 py-5 flex justify-between items-center sticky top-0 z-50">
            {/* Logo Section */}
            <Link to="/" className="flex items-center gap-3 hover:opacity-80 transition group">
                <div className="bg-blue-600 p-2.5 rounded-xl shadow-lg shadow-blue-200 group-hover:scale-110 transition-transform">
                    <Home size={22} color="white" />
                </div>
                <div>
                    <h1 className="text-2xl font-black text-slate-800 tracking-tight">Real<span className="text-blue-600">Park</span></h1>
                    <p className="text-[10px] text-gray-400 uppercase tracking-widest font-bold leading-none">Smart Living</p>
                </div>
            </Link>

            {/* Main Navigation */}
            <div className="hidden md:flex gap-10 font-bold text-sm items-center">
                <Link to="/" className={`transition-colors ${isActive('/') ? 'text-blue-600' : 'text-gray-400 hover:text-blue-600'}`}>
                    Home
                </Link>

                <Link to="/properties" className={`transition-colors ${isActive('/properties') ? 'text-blue-600' : 'text-gray-400 hover:text-blue-600'}`}>
                    Properties
                </Link>

                <Link to="/parking" className={`transition-colors ${isActive('/parking') ? 'text-blue-600' : 'text-gray-400 hover:text-blue-600'}`}>
                    Smart Parking
                </Link>

                <Link to="/dashboard" className={`transition-colors ${isActive('/dashboard') ? 'text-blue-600' : 'text-gray-400 hover:text-blue-600'}`}>
                    Dashboard
                </Link>

                {/* زرار الأدمن - يظهر فقط إذا كان الدور admin */}
                {isAuthenticated && userRole === 'admin' && (
                    <Link
                        to="/admin/users"
                        className="flex items-center gap-2 bg-purple-50 text-purple-600 px-4 py-2 rounded-xl border border-purple-100 hover:bg-purple-600 hover:text-white transition-all duration-300 font-black text-[11px] uppercase tracking-wider"
                    >
                        <ShieldCheck size={16} />
                        Admin Panel
                    </Link>
                )}
            </div>

            {/* Auth Actions Section */}
            <div className="flex items-center gap-6">
                {!isAuthenticated ? (
                    <>
                        <Link to="/login" className="text-gray-600 font-bold text-sm hover:text-blue-600 transition">
                            Sign In
                        </Link>
                        <Link to="/register">
                            <button className="bg-blue-600 text-white px-8 py-3 rounded-xl font-bold text-sm shadow-lg shadow-blue-200 hover:bg-blue-700 transition active:scale-95">
                                Get Started
                            </button>
                        </Link>
                    </>
                ) : (
                    <div className="flex items-center gap-6">
                        <div className="flex items-center gap-3 pr-6 border-r border-gray-100">
                            <div className="text-right hidden sm:block leading-tight">
                                <p className="text-xs font-black text-slate-800">{userName}</p>
                                <p className="text-[9px] text-slate-400 font-bold uppercase tracking-tighter truncate max-w-[100px]">{userEmail}</p>
                            </div>
                            {/* تمييز صورة الأدمن بلون مختلف */}
                            <div className={`w-10 h-10 rounded-2xl flex items-center justify-center font-black text-sm border shadow-sm ${userRole === 'admin' ? 'bg-purple-600 text-white border-purple-400' : 'bg-slate-50 text-blue-600 border-slate-100'}`}>
                                {userName.charAt(0).toUpperCase()}
                            </div>
                        </div>

                        <button
                            onClick={handleLogout}
                            className="flex items-center gap-2 text-gray-400 hover:text-red-500 font-bold text-xs uppercase tracking-widest transition-colors group"
                        >
                            <LogOut size={18} className="group-hover:translate-x-1 transition-transform" />
                            Logout
                        </button>
                    </div>
                )}
            </div>
        </nav>
    );
};

export default Navbar;