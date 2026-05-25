import React from 'react';
import { Link } from 'react-router-dom';
import {
    LayoutDashboard,
    CreditCard,
    Settings
} from 'lucide-react';

// ضفنا userName هنا كـ prop
const Sidebar = ({ activePage, userName = 'User' }) => {

    const menuItems = [
        { id: 'overview', label: 'Overview', icon: <LayoutDashboard size={20} />, path: '/dashboard' },
        { id: 'payments', label: 'Payments', icon: <CreditCard size={20} />, path: '/payments' },
        { id: 'settings', label: 'Settings', icon: <Settings size={20} />, path: '/settings' },
    ];

    return (
        <aside className="w-72 bg-white rounded-3xl shadow-sm border border-gray-100 p-8 h-fit">
            {/* البروفايل المعدل ليكون ديناميكياً */}
            <div className="flex flex-col items-center mb-10">
                <div className="w-20 h-20 bg-blue-100 rounded-full flex items-center justify-center text-blue-600 font-bold text-2xl mb-3">
                    {/* بياخد أول حرف من الاسم اللي جاي من الـ API */}
                    {userName.charAt(0).toUpperCase()}
                </div>
                <h3 className="font-bold text-xl text-slate-800">{userName}</h3>
                <p className="text-sm text-gray-400">Premium Member</p>
            </div>

            <nav className="space-y-3">
                {menuItems.map((item) => (
                    <Link
                        key={item.id}
                        to={item.path}
                        className={`flex items-center gap-4 p-4 rounded-2xl cursor-pointer transition-all duration-300 ${activePage === item.id
                            ? 'bg-blue-50 text-blue-600 shadow-sm'
                            : 'text-gray-500 hover:bg-gray-50'
                            }`}
                    >
                        {item.icon}
                        <span className="font-semibold">{item.label}</span>
                    </Link>
                ))}
            </nav>
        </aside>
    );
};

export default Sidebar;