import React from 'react';
import { NavLink, useNavigate } from 'react-router-dom';
import { Users, BarChart3, Settings, LogOut, ShieldCheck } from 'lucide-react';

const AdminSidebar = () => {
    const navigate = useNavigate();

    const handleLogout = () => {
        if (window.confirm("Are you sure you want to sign out from Admin Panel?")) {
            localStorage.clear();
            navigate('/login', { replace: true });
        }
    };

    const menuItems = [
        { name: 'Users Control', path: '/admin/users', icon: <Users size={20} /> },
        { name: 'Financial Reports', path: '/admin/reports', icon: <BarChart3 size={20} /> },
        // ✅ التعديل هنا: اتأكد إن المسار يطابق اللي في App.jsx
        { name: 'System Settings', path: '/admin/settings', icon: <Settings size={20} /> },
    ];

    return (
        <aside className="w-72 min-h-screen bg-slate-900 text-white flex flex-col sticky top-0 shadow-2xl">
            {/* Logo Section */}
            <div className="p-8">
                {/* 🏠 حركة ذكية: لو داس على اللوجو يرجعه للموقع الرئيسي (Properties) */}
                <div
                    onClick={() => navigate('/')}
                    className="flex items-center gap-3 mb-2 cursor-pointer hover:opacity-80 transition"
                >
                    <div className="w-10 h-10 bg-blue-600 rounded-xl flex items-center justify-center shadow-lg shadow-blue-500/20">
                        <ShieldCheck size={24} />
                    </div>
                    <span className="text-xl font-black tracking-tighter">ADMIN <span className="text-blue-500">PRO</span></span>
                </div>
                <p className="text-[10px] text-slate-500 font-bold uppercase tracking-[0.2em] ml-1">Management Suite</p>
            </div>

            {/* Navigation Links */}
            <nav className="flex-1 px-4 py-4 space-y-2">
                <p className="text-[10px] text-slate-600 font-black uppercase tracking-widest px-4 mb-4">Main Menu</p>
                {menuItems.map((item) => (
                    <NavLink
                        key={item.path}
                        to={item.path}
                        className={({ isActive }) => `
                            flex items-center gap-4 px-4 py-4 rounded-2xl font-bold text-sm transition-all duration-300
                            ${isActive
                                ? 'bg-blue-600 text-white shadow-lg shadow-blue-600/20 translate-x-2'
                                : 'text-slate-400 hover:bg-slate-800 hover:text-white'}
                        `}
                    >
                        {item.icon}
                        {item.name}
                    </NavLink>
                ))}
            </nav>

            {/* Bottom Section */}
            <div className="p-6 border-t border-slate-800 bg-slate-900/50">
                <button
                    onClick={handleLogout}
                    className="w-full flex items-center gap-4 px-4 py-4 rounded-2xl font-bold text-sm text-red-400 hover:bg-red-500/10 hover:text-red-500 transition-all duration-200 cursor-pointer group"
                >
                    <LogOut size={20} className="group-hover:-translate-x-1 transition-transform" />
                    Sign Out
                </button>

                {/* User Info Card */}
                <div className="mt-6 p-4 bg-slate-800/40 border border-slate-800 rounded-[24px] flex items-center gap-3">
                    <div className="w-10 h-10 bg-gradient-to-br from-blue-500 to-blue-700 rounded-xl flex items-center justify-center text-sm font-black shadow-lg">
                        YZ
                    </div>
                    <div>
                        <p className="text-xs font-black tracking-tight text-white truncate max-w-[120px]">
                            {localStorage.getItem('userName') || 'Youssef Zeidan'}
                        </p>
                        <p className="text-[9px] text-blue-500 font-bold uppercase tracking-tighter">Super Admin</p>
                    </div>
                </div>
            </div>
        </aside>
    );
};

export default AdminSidebar;