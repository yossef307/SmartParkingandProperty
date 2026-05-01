import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import Sidebar from '../components/Sidebar';
import {
    CreditCard,
    Home,
    Clock,
    TrendingUp,
    MoreVertical,
    ArrowRight,
    MapPin,
    CalendarCheck
} from 'lucide-react';

const Dashboard = () => {
    const [stats, setStats] = useState({
        userName: 'User',
        activeReservations: 0,
        totalPayments: 0,
        recentInvoices: 0,
        currentSpot: 'Loading...',
        gateStatus: 'Checking...'
    });
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchDashboardData = async () => {
            try {
                // ملاحظة: تأكد أن المنفذ (Port) 7048 هو الصحيح لمشروعك في Visual Studio
                const response = await axios.get('https://localhost:7048/api/dashboard/stats');
                setStats(response.data);
            } catch (error) {
                console.error("Error fetching dashboard data:", error);
            } finally {
                setLoading(false);
            }
        };

        fetchDashboardData();
    }, []);

    // منع الـ Crash في حال كانت البيانات لم تصل بعد
    if (loading) {
        return (
            <div className="min-h-screen flex items-center justify-center bg-[#F8FAFC]">
                <div className="text-xl font-bold text-slate-600 animate-pulse">Loading Smart Dashboard...</div>
            </div>
        );
    }

    return (
        <div className="min-h-screen bg-[#F8FAFC]">
            <div className="max-w-[1440px] mx-auto flex p-10 gap-10">
                <Sidebar activePage="overview" userName={stats.userName} />

                <main className="flex-1">
                    {/* Welcome Header */}
                    <div className="flex justify-between items-center mb-10">
                        <div>
                            <h2 className="text-3xl font-black text-slate-800 mb-2">
                                Welcome back, {stats.userName}! 👋
                            </h2>
                            <p className="text-gray-500 font-medium">Manage your parking and account settings here.</p>
                        </div>
                        <div className="flex gap-4">
                            <div className="text-right">
                                <p className="text-[10px] font-black text-gray-400 uppercase tracking-widest">System Status</p>
                                <p className="font-bold text-green-500 text-sm">All Services Online</p>
                            </div>
                        </div>
                    </div>

                    {/* Quick Stats Grid */}
                    <div className="grid grid-cols-3 gap-6 mb-10">
                        <MainStat
                            label="Active Reservations"
                            value={stats.activeReservations}
                            icon={<CalendarCheck className="text-blue-600" />}
                            change="Current Spot"
                        />
                        <MainStat
                            label="Total Payments"
                            // تعديل هام: الحماية بـ || 0 لضمان عدم حدوث TypeError
                            value={`$${(stats.totalPayments || 0).toFixed(2)}`}
                            icon={<CreditCard className="text-purple-600" />}
                            change="Last 30 days"
                        />
                        <MainStat
                            label="Recent Invoices"
                            value={stats.recentInvoices}
                            icon={<TrendingUp className="text-green-600" />}
                            change="Paid"
                        />
                    </div>

                    <div className="grid grid-cols-3 gap-8">
                        <div className="col-span-2 space-y-6">
                            <Link to="/parking" className="block group">
                                <div className="bg-slate-900 rounded-[32px] p-10 text-white relative overflow-hidden shadow-2xl shadow-slate-200 transition-transform group-hover:scale-[1.01]">
                                    <div className="relative z-10 flex flex-col md:flex-row justify-between items-start md:items-center">
                                        <div>
                                            <h4 className="text-xl font-bold mb-8 text-blue-400">Current Smart Parking Status</h4>
                                            <div className="flex items-center gap-6 mb-8">
                                                <div className="w-20 h-20 bg-blue-600 rounded-[2rem] flex items-center justify-center font-black text-3xl shadow-lg shadow-blue-500/50">P</div>
                                                <div>
                                                    <p className="text-slate-400 text-sm font-bold uppercase tracking-widest mb-1">Assigned Spot</p>
                                                    <p className="text-4xl font-black italic tracking-tighter">{stats.currentSpot}</p>
                                                </div>
                                            </div>
                                        </div>

                                        <div className="bg-white/5 backdrop-blur-sm border border-white/10 rounded-3xl p-8 w-full md:w-72 space-y-5">
                                            <div className="flex justify-between items-center text-sm border-b border-white/10 pb-3">
                                                <span className="text-slate-400 font-bold uppercase text-[10px] tracking-widest">Gate Access</span>
                                                <span className={stats.gateStatus === 'ENABLED' ? "text-green-400 font-black" : "text-red-400 font-black"}>
                                                    {stats.gateStatus}
                                                </span>
                                            </div>
                                            <div className="flex justify-between items-center text-sm border-b border-white/10 pb-3">
                                                <span className="text-slate-400 font-bold uppercase text-[10px] tracking-widest">Entry Point</span>
                                                <span className="font-bold">North Gate</span>
                                            </div>
                                            <div className="flex justify-between items-center pt-2">
                                                <span className="text-slate-400 font-bold uppercase text-[10px] tracking-widest">Remaining</span>
                                                <span className="font-black text-xl text-blue-400">04:22:15</span>
                                            </div>
                                        </div>
                                    </div>
                                    <div className="absolute -bottom-20 -left-20 w-80 h-80 bg-blue-600/10 rounded-full blur-[120px]"></div>
                                </div>
                            </Link>
                        </div>

                        <div className="col-span-1 space-y-6">
                            <div className="bg-white rounded-[32px] border border-gray-100 p-8 shadow-sm">
                                <div className="flex justify-between items-center mb-6">
                                    <h4 className="font-black text-slate-800 uppercase text-xs tracking-widest">Quick Navigation</h4>
                                    <MoreVertical size={16} className="text-gray-400" />
                                </div>
                                <div className="space-y-4">
                                    <QuickActionLink to="/settings" label="Update Profile" icon={<SettingsLinkIcon />} />
                                    <QuickActionLink to="/payments" label="View Invoices" icon={<CreditCard size={18} />} />
                                    <QuickActionLink to="/properties" label="Browse Properties" icon={<Home size={18} />} />
                                </div>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
        </div>
    );
};

// المكونات الفرعية
const MainStat = ({ label, value, icon, change }) => (
    <div className="bg-white p-7 rounded-[28px] border border-gray-100 shadow-sm hover:translate-y-[-4px] transition-all duration-300">
        <div className="flex justify-between items-start mb-4">
            <div className="p-3 bg-gray-50 rounded-2xl">{icon}</div>
            <span className="text-[10px] font-black px-2 py-1 rounded-lg bg-blue-50 text-blue-600 uppercase">
                {change}
            </span>
        </div>
        <p className="text-gray-400 text-xs font-bold uppercase tracking-wider mb-1">{label}</p>
        <p className="text-3xl font-black text-slate-800 tracking-tight">{value}</p>
    </div>
);

const QuickActionLink = ({ to, label, icon }) => (
    <Link to={to} className="flex items-center justify-between p-4 bg-slate-50 rounded-2xl hover:bg-blue-600 hover:text-white transition-all group">
        <div className="flex items-center gap-3">
            <span className="text-slate-400 group-hover:text-white">{icon}</span>
            <span className="font-bold text-sm">{label}</span>
        </div>
        <ArrowRight size={16} className="text-slate-300 group-hover:text-white" />
    </Link>
);

const SettingsLinkIcon = () => (
    <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><path d="M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z"></path><circle cx="12" cy="12" r="3"></circle></svg>
);

export default Dashboard;