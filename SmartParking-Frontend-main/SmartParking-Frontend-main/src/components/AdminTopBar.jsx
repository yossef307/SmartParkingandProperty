import React from 'react';
import { Bell, Search, Calendar } from 'lucide-react';

const AdminTopBar = () => {
    const userEmail = localStorage.getItem('userEmail');
    const today = new Date().toLocaleDateString('en-US', { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' });

    return (
        <div className="h-20 bg-white border-b border-slate-100 px-8 flex justify-between items-center sticky top-0 z-40">
            {/* جهة اليسار: التاريخ أو البحث */}
            <div className="flex items-center gap-4">
                <div className="bg-slate-50 p-2 rounded-lg text-slate-400">
                    <Calendar size={18} />
                </div>
                <span className="text-xs font-bold text-slate-500 uppercase tracking-widest">{today}</span>
            </div>

            {/* جهة اليمين: التنبيهات والبيانات */}
            <div className="flex items-center gap-6">
                <button className="relative p-2 text-slate-400 hover:text-blue-600 transition-colors">
                    <Bell size={20} />
                    <span className="absolute top-2 right-2 w-2 h-2 bg-red-500 rounded-full border-2 border-white"></span>
                </button>

                <div className="h-8 w-[1px] bg-slate-100"></div>

                <div className="flex items-center gap-3">
                    <div className="text-right">
                        <p className="text-xs font-black text-slate-800 leading-none">Control Panel</p>
                        <p className="text-[10px] text-blue-500 font-bold tracking-tight">{userEmail}</p>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default AdminTopBar;