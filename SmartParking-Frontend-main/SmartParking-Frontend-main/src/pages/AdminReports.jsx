import React, { useState, useEffect } from 'react';
import axios from 'axios';
import {
    BarChart3, TrendingUp, DollarSign, Car,
    Calendar, ArrowUpRight, Download, Loader2
} from 'lucide-react';

const AdminReports = () => {
    const [reportData, setReportData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchReportData = async () => {
            try {
                // ✅ تم تحديث البورت إلى 7144 بناءً على تشغيل السيرفر الحالي
                const response = await axios.get('https://localhost:7144/api/Reports/financial-summary');
                setReportData(response.data);
                setError(null);
            } catch (error) {
                console.error("Error fetching financial reports:", error);
                setError("Could not connect to the server. Please ensure Backend is running on port 7144.");
            } finally {
                setLoading(false);
            }
        };
        fetchReportData();
    }, []);

    if (loading) {
        return (
            <div className="h-screen flex items-center justify-center">
                <Loader2 className="animate-spin text-blue-600" size={48} />
            </div>
        );
    }

    if (error) {
        return (
            <div className="h-screen flex flex-col items-center justify-center text-red-500 font-bold">
                <p>{error}</p>
                <button
                    onClick={() => window.location.reload()}
                    className="mt-4 bg-blue-600 text-white px-4 py-2 rounded-lg"
                >
                    Retry Connection
                </button>
            </div>
        );
    }

    const stats = [
        {
            label: "Total Revenue",
            value: `$${(reportData?.totalRevenue || reportData?.TotalRevenue || 0).toLocaleString()}`,
            icon: <DollarSign />, trend: "+12%", color: "text-green-600", bg: "bg-green-50"
        },
        {
            label: "Total Bookings",
            value: reportData?.totalBookings || reportData?.TotalBookings || '0',
            icon: <Calendar />, trend: "+5.4%", color: "text-blue-600", bg: "bg-blue-50"
        },
        {
            label: "Active Spots",
            value: reportData?.activeSpots || reportData?.ActiveSpots || '0/0',
            icon: <Car />, trend: "Live", color: "text-amber-600", bg: "bg-amber-50"
        },
    ];

    return (
        <div className="p-6 md:p-10 bg-gray-50/50 min-h-screen">
            <div className="max-w-[1200px] mx-auto">
                {/* Header */}
                <div className="flex flex-col md:flex-row justify-between items-start md:items-end mb-10 gap-4">
                    <div>
                        <h2 className="text-3xl font-black text-slate-800 mb-2">Financial Reports</h2>
                        <p className="text-gray-500 font-medium">Track your business performance and parking occupancy.</p>
                    </div>
                    <button className="flex items-center gap-2 bg-slate-900 text-white px-6 py-3.5 rounded-2xl font-bold text-sm hover:bg-slate-800 transition shadow-lg active:scale-95">
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

                {/* Main Content */}
                <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
                    <div className="lg:col-span-2 bg-white rounded-[32px] border border-gray-100 shadow-sm overflow-hidden">
                        <div className="p-8 border-b border-gray-50 flex justify-between items-center bg-slate-50/30">
                            <h3 className="text-xl font-black text-slate-800 flex items-center gap-2">
                                <BarChart3 className="text-blue-600" size={24} /> Recent Transactions
                            </h3>
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
                                    {(reportData?.recentTransactions || reportData?.RecentTransactions || []).map((transaction, index) => (
                                        <tr key={index} className="group hover:bg-slate-50 transition-colors">
                                            <td className="px-8 py-5">
                                                <p className="font-bold text-slate-700 text-sm">
                                                    {transaction.propertyName || transaction.PropertyName || "N/A"}
                                                </p>
                                                <p className="text-[10px] text-gray-400 font-black uppercase tracking-tighter">
                                                    Spot: {transaction.spotNumber || transaction.SpotNumber || "N/A"}
                                                </p>
                                            </td>
                                            <td className="px-8 py-5 text-xs font-bold text-slate-500">
                                                {transaction.date || transaction.Date || "Recent"}
                                            </td>
                                            <td className="px-8 py-5">
                                                <span className="font-black text-slate-800">
                                                    ${transaction.amount || transaction.Amount || 0}
                                                </span>
                                            </td>
                                            <td className="px-8 py-5 text-right">
                                                <span className="bg-green-100 text-green-600 text-[10px] font-black px-3 py-1.5 rounded-full uppercase tracking-tighter">
                                                    {transaction.status || transaction.Status || "Completed"}
                                                </span>
                                            </td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <div className="lg:col-span-1 space-y-6">
                        <div className="bg-slate-900 rounded-[32px] p-8 text-white shadow-2xl shadow-blue-900/20">
                            <h4 className="text-lg font-bold mb-8 flex items-center justify-between">
                                Revenue Breakdown
                                <span className="text-[10px] font-black text-slate-500 uppercase tracking-[0.2em]">Live</span>
                            </h4>
                            <div className="space-y-8">
                                <RevenueBar label="Real Estate Sales" percent="75" color="bg-blue-500" />
                                <RevenueBar label="Parking Subscriptions" percent="25" color="bg-emerald-400" />
                            </div>
                            <hr className="my-8 border-slate-800" />
                            <div className="flex items-center justify-between">
                                <span className="text-slate-400 text-xs font-bold uppercase tracking-widest">Est. Monthly</span>
                                <span className="font-black text-2xl text-blue-400">
                                    ${(reportData?.totalRevenue || reportData?.TotalRevenue || 0).toLocaleString()}
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
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
                className={`h-full ${color} rounded-full transition-all duration-1000 ease-out`}
                style={{ width: `${percent}%` }}
            ></div>
        </div>
    </div>
);

export default AdminReports;