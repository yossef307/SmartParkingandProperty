import React from 'react';
import { NavLink, useNavigate } from 'react-router-dom';
import {
    Users,
    BarChart3,
    Settings,
    LogOut,
    ShieldCheck,
    Home,
    Car
} from 'lucide-react';

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
        { name: 'Manage Properties', path: '/admin/properties', icon: <Home size={20} /> },
        { name: 'Smart Parking', path: '/admin/parking', icon: <Car size={20} /> },
        { name: 'Financial Reports', path: '/admin/reports', icon: <BarChart3 size={20} /> },
        { name: 'System Settings', path: '/admin/settings', icon: <Settings size={20} /> },
    ];

    // جلب البيانات بشكل آمن
    const userRaw = localStorage.getItem('user');
    const user = userRaw ? JSON.parse(userRaw) : null;
    const displayName = user?.name || user?.userName || localStorage.getItem('userName') || 'Admin';

    return (
        <aside className="w-72 min-h-screen bg-slate-900 text-white flex flex-col sticky top-0 shadow-2xl">
            {/* Logo */}
            <div className="p-8">
                <div
                    onClick={() => navigate('/')}
                    className="flex items-center gap-3 mb-2 cursor-pointer hover:opacity-80 transition"
                >
                    <div className="w-10 h-10 bg-blue-600 rounded-xl flex items-center justify-center shadow-lg shadow-blue-500/20">
                        <ShieldCheck size={24} />
                    </div>
                    <span className="text-xl font-black tracking-tighter uppercase">ADMIN <span className="text-blue-500">PRO</span></span>
                </div>
                <p className="text-[10px] text-slate-500 font-bold uppercase tracking-[0.2em] ml-1">Management Suite</p>
            </div>

            {/* Navigation */}
            <nav className="flex-1 px-4 py-4 space-y-2">
                <p className="text-[10px] text-slate-600 font-black uppercase tracking-widest px-4 mb-4">Main Menu</p>
                {menuItems.map((item) => (
                    <NavLink
                        key={item.path}
                        to={item.path}
                        // الحل هنا: نستخدم دالة داخل الـ children عشان نوصل لـ isActive
                        className={({ isActive }) => `
                            flex items-center gap-4 px-4 py-4 rounded-2xl font-bold text-sm transition-all duration-300
                            ${isActive
                                ? 'bg-blue-600 text-white shadow-lg shadow-blue-600/20 translate-x-2'
                                : 'text-slate-400 hover:bg-slate-800 hover:text-white'}
                        `}
                    >
                        {/* تمرير دالة لاستلام حالة isActive للأيقونة */}
                        {({ isActive }) => (
                            <>
                                <span className={`${isActive ? 'scale-110 opacity-100' : 'opacity-70'} transition-transform`}>
                                    {item.icon}
                                </span>
                                {item.name}
                            </>
                        )}
                    </NavLink>
                ))}
            </nav>

            {/* User Card & Logout */}
            <div className="p-6 border-t border-slate-800 bg-slate-900/50">
                <button
                    onClick={handleLogout}
                    className="w-full flex items-center gap-4 px-4 py-4 rounded-2xl font-bold text-sm text-red-400 hover:bg-red-500/10 hover:text-red-500 transition-all duration-200 cursor-pointer group mb-4"
                >
                    <LogOut size={20} className="group-hover:-translate-x-1 transition-transform" />
                    Sign Out
                </button>

                <div className="p-4 bg-slate-800/40 border border-slate-800 rounded-[24px] flex items-center gap-3">
                    <div className="w-10 h-10 bg-gradient-to-br from-blue-500 to-blue-700 rounded-xl flex items-center justify-center text-xs font-black shadow-lg">
                        {displayName.substring(0, 2).toUpperCase()}
                    </div>
                    <div className="overflow-hidden">
                        <p className="text-xs font-black tracking-tight text-white truncate">
                            {displayName}
                        </p>
                        <p className="text-[9px] text-blue-500 font-bold uppercase tracking-tighter">Super Admin</p>
                    </div>
                </div>
            </div>
        </aside>
    );
};

export default AdminSidebar;