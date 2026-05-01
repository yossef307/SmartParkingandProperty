import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { CreditCard, ArrowUpRight, Download, FileText, CheckCircle2, DollarSign } from 'lucide-react';

const Payments = () => {
    // 1. تعريف الـ State لشيل قائمة العمليات والبيانات الإحصائية
    const [transactions, setTransactions] = useState([]);
    const [loading, setLoading] = useState(true);
    const [summary, setSummary] = useState({
        totalSpent: 0,
        refunds: 0,
        pending: 150, // قيمة افتراضية أو يمكنك جلبها من الـ API
        methodsCount: 2
    });

    // 2. جلب البيانات من الـ API
    useEffect(() => {
        const fetchPaymentData = async () => {
            try {
                // تأكد من تشغيل الـ Backend على بورت 7048
                const response = await axios.get('https://localhost:7048/api/payments/user-history');
                const data = response.data;

                setTransactions(data);

                // حساب الإحصائيات بناءً على البيانات القادمة
                const spent = data
                    .filter(t => t.status !== 'Refunded')
                    .reduce((sum, current) => sum + current.amount, 0);

                const ref = data
                    .filter(t => t.status === 'Refunded')
                    .reduce((sum, current) => sum + current.amount, 0);

                setSummary(prev => ({
                    ...prev,
                    totalSpent: spent,
                    refunds: ref
                }));

                setLoading(false);
            } catch (error) {
                console.error("Error fetching payment history:", error);
                setLoading(false);
            }
        };

        fetchPaymentData();
    }, []);

    if (loading) {
        return (
            <div className="min-h-screen flex items-center justify-center bg-[#F8FAFC]">
                <p className="text-xl font-bold text-slate-800 animate-pulse">Loading Transactions...</p>
            </div>
        );
    }

    return (
        <div className="min-h-screen bg-[#F8FAFC]">
            <main className="max-w-[1200px] mx-auto px-6 py-20">
                <div className="mb-10">
                    <h2 className="text-4xl font-black text-slate-800 mb-2">Payments & Billing</h2>
                    <p className="text-gray-500 font-medium">Manage your transactions and payment methods securely.</p>
                </div>

                {/* Stats Row - البيانات هنا أصبحت ديناميكية */}
                <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6 mb-12">
                    <PaymentStat label="Total Spent" value={`$${summary.totalSpent.toFixed(2)}`} sub="All Time" icon={<DollarSign size={20} />} />
                    <PaymentStat label="Refunds" value={`$${summary.refunds.toFixed(2)}`} sub="Total" icon={<ArrowUpRight size={20} />} color="text-green-600" />
                    <PaymentStat label="Pending" value={`$${summary.pending}`} sub="Upcoming" icon={<CreditCard size={20} />} />
                    <PaymentStat label="Methods" value={summary.methodsCount} sub="Active" icon={<CreditCard size={20} />} />
                </div>

                {/* Transactions Table */}
                <div className="bg-white rounded-[32px] border border-slate-100 shadow-sm overflow-hidden">
                    <div className="p-8 border-b border-gray-50 flex justify-between items-center">
                        <h3 className="text-xl font-black text-slate-800">Recent Transactions</h3>
                        <button className="flex items-center gap-2 text-xs font-black text-gray-500 border border-gray-100 px-5 py-2.5 rounded-xl hover:bg-gray-50 transition-all uppercase tracking-widest">
                            <Download size={14} /> Export CSV
                        </button>
                    </div>

                    <div className="overflow-x-auto">
                        <table className="w-full text-left">
                            <thead>
                                <tr className="bg-slate-50/50 text-[10px] uppercase tracking-[0.2em] font-black text-slate-400">
                                    <th className="px-8 py-5">Transaction</th>
                                    <th className="px-8 py-5">Date</th>
                                    <th className="px-8 py-5">Method</th>
                                    <th className="px-8 py-5">Status</th>
                                    <th className="px-8 py-5 text-right">Amount</th>
                                    <th className="px-8 py-5 text-center">Receipt</th>
                                </tr>
                            </thead>
                            <tbody className="divide-y divide-slate-50">
                                {transactions.length > 0 ? (
                                    transactions.map((txn, index) => (
                                        <TransactionRow
                                            key={index}
                                            id={txn.transactionId}
                                            title={txn.status === 'Refunded' ? "Refund" : "Parking Reservation"}
                                            sub={txn.propertyName}
                                            date={txn.date}
                                            method={txn.method}
                                            status={txn.status}
                                            amount={`$${txn.amount.toFixed(2)}`}
                                            isRefund={txn.status === 'Refunded'}
                                        />
                                    ))
                                ) : (
                                    <tr>
                                        <td colSpan="6" className="text-center py-10 text-gray-400 font-bold">
                                            No transactions found.
                                        </td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </div>
                </div>
            </main>
        </div>
    );
};

// مكونات فرعية لتنظيم الكود
const PaymentStat = ({ label, value, sub, icon, color = "text-slate-800" }) => (
    <div className="bg-white p-7 rounded-[28px] border border-slate-100 shadow-sm group hover:border-blue-200 transition-all">
        <div className="flex justify-between items-start mb-4">
            <div className="p-3 bg-slate-50 rounded-2xl group-hover:bg-blue-50 transition-colors">
                {icon}
            </div>
            <span className="bg-blue-50 text-blue-600 text-[10px] font-black px-2.5 py-1 rounded-lg uppercase">{sub}</span>
        </div>
        <p className="text-slate-400 text-[10px] font-black uppercase tracking-widest mb-1">{label}</p>
        <p className={`text-3xl font-black ${color}`}>{value}</p>
    </div>
);

const TransactionRow = ({ id, title, sub, date, method, status, amount, isRefund = false }) => (
    <tr className="hover:bg-slate-50/50 transition-colors group">
        <td className="px-8 py-5">
            <div className="flex flex-col">
                <span className="text-[9px] font-black text-blue-600 mb-1 uppercase tracking-tighter">{id}</span>
                <p className="font-bold text-slate-800 text-sm">{title}</p>
                <p className="text-[10px] text-gray-400 font-medium">{sub}</p>
            </div>
        </td>
        <td className="px-8 py-5 text-sm font-bold text-slate-700">{date}</td>
        <td className="px-8 py-5 text-xs font-bold text-gray-600">{method}</td>
        <td className="px-8 py-5">
            <div className={`flex items-center gap-1.5 ${isRefund ? 'bg-blue-50 text-blue-600' : 'bg-green-50 text-green-600'} w-fit px-3 py-1 rounded-full border border-current opacity-80`}>
                <CheckCircle2 size={10} />
                <span className="text-[9px] font-black uppercase">{status}</span>
            </div>
        </td>
        <td className={`px-8 py-5 text-right font-black text-sm ${isRefund ? 'text-green-600' : 'text-slate-800'}`}>
            {isRefund ? `+${amount}` : amount}
        </td>
        <td className="px-8 py-5 text-center">
            <button className="text-slate-300 hover:text-blue-600 transition p-2 bg-slate-50 rounded-lg">
                <FileText size={16} />
            </button>
        </td>
    </tr>
);

export default Payments;