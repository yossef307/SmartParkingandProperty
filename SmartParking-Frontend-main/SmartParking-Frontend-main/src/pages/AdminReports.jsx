import React from 'react';
import { BarChart3, TrendingUp, DollarSign, Car, Calendar, ArrowUpRight, Download } from 'lucide-react';
import AdminSidebar from '../components/AdminSidebar';
import AdminTopBar from '../components/AdminTopBar'; // ✅ استيراد التوب بار

const AdminReports = () => {
    const stats = [
        { label: "Total Revenue", value: "$12,850", icon: <DollarSign />, trend: "+12%", color: "text-green-600", bg: "bg-green-50" },
        { label: "Total Bookings", value: "452", icon: <Calendar />, trend: "+5.4%", color: "text-blue-600", bg: "bg-blue-50" },
        { label: "Active Spots", value: "24/50", icon: <Car />, trend: "Busy", color: "text-amber-600", bg: "bg-amber-50" },
    ];

    return (
        <div className="flex min-h-screen bg-[#F8FAFC]">
            {/* 1. السايدبار الثابت على اليسار */}
            <AdminSidebar />

            {/* 2. المحتوى اليمين (TopBar + Main Content) */}
            <div className="flex-1 flex flex-col h-screen overflow-hidden">

                {/* ✅ التوب بار يظهر فوق على طول */}
                <AdminTopBar />

                {/* 3. الجزء القابل للتمرير */}
                <main className="flex-1 p-10 overflow-y-auto">
                    <div className="max-w-[1200px] mx-auto">

                        {/* Header Section */}
                        <div className="flex justify-between items-end mb-10">
                            <div>
                                <h2 className="text-3xl font-black text-slate-800 mb-2">Financial Reports</h2>
                                <p className="text-gray-500 font-medium">Track your business performance and parking occupancy.</p>
                            </div>
                            <button className="flex items-center gap-2 bg-slate-900 text-white px-6 py-3 rounded-2xl font-bold text-sm hover:bg-slate-800 transition shadow-lg active:scale-95">
                                <Download size={18} /> Export PDF
                            </button>
                        </div>

                        {/* Stats Grid */}
                        <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-10">
                            {stats.map((stat, index) => (
                                <div key={index} className="bg-white p-6 rounded-[32px] border border-gray-100 shadow-sm flex items-center justify-between transition-transform hover:scale-[1.02]">
                                    <div className="flex items-center gap-4">
                                        <div className={`w-14 h-14 ${stat.bg} ${stat.color} rounded-2xl flex items-center justify-center shadow-inner`}>
                                            {React.cloneElement(stat.icon, { size: 28 })}
                                        </div>
                                        <div>
                                            <p className="text-[10px] font-black text-gray-400 uppercase tracking-widest mb-1">{stat.label}</p>
                                            <p className="text-2xl font-black text-slate-800">{stat.value}</p>
                                        </div>
                                    </div>
                                    <div className={`flex items-center gap-1 text-[10px] font-black ${stat.color} bg-white px-2 py-1 rounded-lg border border-gray-50 shadow-sm`}>
                                        <TrendingUp size={14} /> {stat.trend}
                                    </div>
                                </div>
                            ))}
                        </div>

                        {/* Main Content Grid */}
                        <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
                            {/* Recent Transactions Table */}
                            <div className="lg:col-span-2 bg-white rounded-[32px] border border-gray-100 shadow-sm overflow-hidden">
                                <div className="p-8 border-b border-gray-50 flex justify-between items-center bg-slate-50/30">
                                    <h3 className="text-xl font-black text-slate-800 flex items-center gap-2">
                                        <BarChart3 className="text-blue-600" size={24} /> Recent Transactions
                                    </h3>
                                    <button className="text-[10px] font-black text-blue-600 uppercase tracking-widest hover:underline text-xs">View Full Ledger</button>
                                </div>
                                <div className="overflow-x-auto">
                                    <table className="w-full text-left">
                                        <thead>
                                            <tr className="text-[10px] font-black text-gray-400 uppercase tracking-[0.15em] bg-gray-50/50">
                                                <th className="px-8 py-5">Property / Spot</th>
                                                <th className="px-8 py-5">Date</th>
                                                <th className="px-8 py-5">Amount</th>
                                                <th className="px-8 py-5 text-right">Status</th>
                                            </tr>
                                        </thead>
                                        <tbody className="divide-y divide-gray-50">
                                            {[1, 2, 3, 4].map((item) => (
                                                <tr key={item} className="group hover:bg-slate-50 transition-colors">
                                                    <td className="px-8 py-5">
                                                        <p className="font-bold text-slate-700 text-sm">Luxury Villa A-104</p>
                                                        <p className="text-[10px] text-gray-400 font-black uppercase tracking-tighter">Zone A • Spot 12</p>
                                                    </td>
                                                    <td className="px-8 py-5 text-xs font-bold text-slate-500">Mar 12, 2026</td>
                                                    <td className="px-8 py-5">
                                                        <span className="font-black text-slate-800">$150.00</span>
                                                    </td>
                                                    <td className="px-8 py-5 text-right">
                                                        <span className="bg-green-100 text-green-600 text-[10px] font-black px-3 py-1.5 rounded-full uppercase tracking-tighter">Completed</span>
                                                    </td>
                                                </tr>
                                            ))}
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                            {/* Right Column / Revenue Breakdown */}
                            <div className="lg:col-span-1 space-y-6">
                                <div className="bg-slate-900 rounded-[32px] p-8 text-white shadow-2xl shadow-blue-900/20">
                                    <h4 className="text-lg font-bold mb-8 flex items-center justify-between">
                                        Revenue Breakdown
                                        <span className="text-[10px] font-black text-slate-500 uppercase tracking-[0.2em]">Monthly</span>
                                    </h4>
                                    <div className="space-y-8">
                                        <RevenueBar label="Real Estate Sales" percent="75" color="bg-blue-500" />
                                        <RevenueBar label="Parking Subscriptions" percent="25" color="bg-emerald-400" />
                                    </div>
                                    <hr className="my-8 border-slate-800" />
                                    <div className="flex items-center justify-between">
                                        <span className="text-slate-400 text-xs font-bold uppercase tracking-widest">Est. Monthly</span>
                                        <span className="font-black text-2xl text-blue-400">$15,400</span>
                                    </div>
                                </div>

                                {/* Performance Card */}
                                <div className="bg-blue-600 rounded-[32px] p-8 text-white flex items-center justify-between overflow-hidden relative group cursor-pointer shadow-xl shadow-blue-200">
                                    <div className="relative z-10">
                                        <p className="text-blue-100 text-[10px] font-black uppercase tracking-widest mb-1 opacity-80">Top Performing Area</p>
                                        <h4 className="text-xl font-black italic tracking-tight">Zone B - Level 2</h4>
                                    </div>
                                    <ArrowUpRight className="relative z-10 group-hover:translate-x-1 group-hover:-translate-y-1 transition-transform" size={32} />
                                    <div className="absolute -right-4 -bottom-4 w-24 h-24 bg-blue-500 rounded-full blur-3xl opacity-50"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
        </div>
    );
};

const RevenueBar = ({ label, percent, color }) => (
    <div className="space-y-3">
        <div className="flex justify-between text-[10px] font-black uppercase tracking-[0.1em] text-slate-500">
            <span>{label}</span>
            <span className="text-white">{percent}%</span>
        </div>
        <div className="h-1.5 w-full bg-slate-800 rounded-full overflow-hidden">
            <div
                className={`h-full ${color} rounded-full transition-all duration-1000 ease-out shadow-[0_0_12px_rgba(59,130,246,0.5)]`}
                style={{ width: `${percent}%` }}
            ></div>
        </div>
    </div>
);

export default AdminReports;