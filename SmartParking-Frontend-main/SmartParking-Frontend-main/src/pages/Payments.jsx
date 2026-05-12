import React, { useState, useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { CreditCard, ArrowUpRight, Download, FileText, CheckCircle2, DollarSign, Loader2, Calendar, ShieldCheck } from 'lucide-react';
import parkingService from '../services/parkingService';

const Payments = () => {
    const location = useLocation();
    const navigate = useNavigate();

    // البيانات القادمة من صفحة الحجز
    const pendingBooking = location.state?.bookingData;

    const [transactions, setTransactions] = useState([]);
    const [loading, setLoading] = useState(true);
    const [isProcessing, setIsProcessing] = useState(false);
    const [summary, setSummary] = useState({
        totalSpent: 0,
        refunds: 0,
        pending: 0,
        methodsCount: 1
    });

    useEffect(() => {
        fetchPaymentData();
    }, []);

    const fetchPaymentData = async () => {
        try {
            setLoading(true);
            //UserId = 1 افتراضياً للتجربة
            const data = await parkingService.getUserPaymentHistory(1);
            setTransactions(data);

            const spent = data
                .filter(t => t.status?.toLowerCase() === 'confirmed' || t.status?.toLowerCase() === 'completed')
                .reduce((sum, current) => sum + current.amount, 0);

            const ref = data
                .filter(t => t.status?.toLowerCase() === 'refunded')
                .reduce((sum, current) => sum + current.amount, 0);

            setSummary(prev => ({
                ...prev,
                totalSpent: spent,
                refunds: ref,
                pending: pendingBooking ? pendingBooking.totalAmount : 0
            }));
        } catch (error) {
            console.error("Error fetching payment history:", error);
        } finally {
            setLoading(false);
        }
    };

    const handleConfirmPayment = async () => {
        if (!pendingBooking) return;
        setIsProcessing(true);
        try {
            const paymentPayload = {
                userId: pendingBooking.userId || 1,
                amount: pendingBooking.totalAmount,
                method: "Credit Card (Visa .... 4242)",
                propertyId: pendingBooking.propertyId,
                parkingSpotId: pendingBooking.parkingSpotId,
            };

            await parkingService.processPayment(paymentPayload);
            alert("✅ تم تأكيد الحجز وإتمام الدفع بنجاح!");

            navigate('/payments', { state: null, replace: true });
            fetchPaymentData();
        } catch (error) {
            alert("❌ فشل الدفع والحجز: " + error.message);
        } finally {
            setIsProcessing(false);
        }
    };

    if (loading) {
        return (
            <div className="flex flex-col items-center justify-center h-[60vh]">
                <Loader2 className="animate-spin text-blue-600 mb-4" size={40} />
                <p className="text-xl font-bold text-slate-800">جاري تحميل سجل المدفوعات...</p>
            </div>
        );
    }

    return (
        <div className="animate-in fade-in duration-500 text-right" dir="rtl">
            {/* Header Section */}
            <div className="mb-10">
                <h2 className="text-4xl font-black text-slate-800 mb-2">المدفوعات والفواتير</h2>
                <p className="text-gray-500 font-medium">إدارة معاملاتك المالية وطرق الدفع الخاصة بك بأمان.</p>
            </div>

            {/* Pending Booking Alert */}
            {pendingBooking && (
                <div className="mb-12 relative overflow-hidden group">
                    <div className="absolute inset-0 bg-blue-600 rounded-[40px] translate-y-2 blur-2xl opacity-10"></div>
                    <div className="relative bg-white border-2 border-blue-600 rounded-[40px] overflow-hidden shadow-sm">
                        <div className="bg-blue-600 p-6 text-white flex justify-between items-center">
                            <div className="flex items-center gap-3">
                                <ShieldCheck size={24} />
                                <h3 className="text-xl font-black">تأكيد حجز الفيلا والخدمات</h3>
                            </div>
                            <span className="bg-white/20 px-4 py-1.5 rounded-full text-[10px] font-black uppercase">انتظار الدفع</span>
                        </div>

                        <div className="p-8 grid grid-cols-1 md:grid-cols-3 gap-8 items-center">
                            <div className="md:col-span-2 space-y-4 text-right">
                                <div>
                                    <h4 className="text-2xl font-black text-slate-900">{pendingBooking.propertyName}</h4>
                                    <div className="flex gap-4 mt-2 justify-start">
                                        <span className="flex items-center gap-1.5 text-xs font-bold text-slate-500"><Calendar size={14} /> {pendingBooking.nights} ليالي</span>
                                        {pendingBooking.parkingEnabled && (
                                            <span className="flex items-center gap-1.5 text-xs font-bold text-blue-600"><CheckCircle2 size={14} /> ركنة ذكية ({pendingBooking.parkingZone})</span>
                                        )}
                                    </div>
                                </div>
                                <div className="flex gap-4 bg-slate-50 p-4 rounded-2xl w-fit">
                                    <div className="text-center px-4 border-r border-slate-200">
                                        <p className="text-[10px] font-black text-slate-400 uppercase">الوصول</p>
                                        <p className="font-bold text-slate-700">{pendingBooking.checkIn}</p>
                                    </div>
                                    <div className="text-center px-4">
                                        <p className="text-[10px] font-black text-slate-400 uppercase">المغادرة</p>
                                        <p className="font-bold text-slate-700">{pendingBooking.checkOut}</p>
                                    </div>
                                </div>
                            </div>

                            <div className="bg-slate-900 rounded-[30px] p-8 text-white shadow-xl">
                                <p className="text-[10px] font-black text-slate-400 uppercase mb-1">المبلغ المطلوب</p>
                                <p className="text-4xl font-black mb-6">${pendingBooking.totalAmount.toLocaleString()}</p>
                                <button
                                    onClick={handleConfirmPayment}
                                    disabled={isProcessing}
                                    className="w-full bg-blue-600 hover:bg-blue-500 py-4 rounded-2xl font-black transition-all flex items-center justify-center gap-2"
                                >
                                    {isProcessing ? <Loader2 className="animate-spin" /> : <><CreditCard size={18} /> دفع وتأكيد الآن</>}
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            )}

            {/* Stats Grid */}
            <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6 mb-12">
                <PaymentStat label="إجمالي المصروفات" value={`$${summary.totalSpent.toFixed(2)}`} sub="All Time" icon={<DollarSign size={20} />} />
                <PaymentStat label="المبالغ المستردة" value={`$${summary.refunds.toFixed(2)}`} sub="Total" icon={<ArrowUpRight size={20} />} color="text-green-600" />
                <PaymentStat label="دفعات معلقة" value={`$${summary.pending.toFixed(2)}`} sub="Current" icon={<Loader2 size={20} />} />
                <PaymentStat label="طرق الدفع" value={summary.methodsCount} sub="Active" icon={<CreditCard size={20} />} />
            </div>

            {/* Transactions Table */}
            <div className="bg-white rounded-[32px] border border-slate-100 shadow-sm overflow-hidden">
                <div className="p-8 border-b border-gray-50 flex justify-between items-center">
                    <h3 className="text-xl font-black text-slate-800">سجل المعاملات الأخيرة</h3>
                    <button className="flex items-center gap-2 text-[10px] font-black text-gray-500 border border-gray-100 px-5 py-2.5 rounded-xl hover:bg-gray-50 transition-all uppercase tracking-widest">
                        <Download size={14} /> تصدير البيانات
                    </button>
                </div>

                <div className="overflow-x-auto">
                    <table className="w-full text-right">
                        <thead>
                            <tr className="bg-slate-50/50 text-[10px] uppercase tracking-[0.2em] font-black text-slate-400">
                                <th className="px-8 py-5">المعاملة</th>
                                <th className="px-8 py-5">التاريخ</th>
                                <th className="px-8 py-5">الطريقة</th>
                                <th className="px-8 py-5">الحالة</th>
                                <th className="px-8 py-5 text-left">المبلغ</th>
                                <th className="px-8 py-5 text-center">الإيصال</th>
                            </tr>
                        </thead>
                        <tbody className="divide-y divide-slate-50">
                            {transactions.length > 0 ? (
                                transactions.map((txn, index) => (
                                    <TransactionRow
                                        key={txn.transactionId || index}
                                        id={txn.transactionId || `TXN-${index}`}
                                        title={txn.status === 'Refunded' ? "مبلغ مسترد" : "حجز إقامة وركن"}
                                        sub={txn.propertyName || "خدمات RealPark"}
                                        date={txn.date}
                                        method={txn.method || "Visa .... 4242"}
                                        status={txn.status}
                                        amount={`$${txn.amount.toFixed(2)}`}
                                        isRefund={txn.status === 'Refunded'}
                                    />
                                ))
                            ) : (
                                <tr>
                                    <td colSpan="6" className="text-center py-16 text-gray-400 font-bold">
                                        لا توجد معاملات مالية مسجلة حالياً.
                                    </td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
};

// Sub-components
const PaymentStat = ({ label, value, sub, icon, color = "text-slate-800" }) => (
    <div className="bg-white p-7 rounded-[28px] border border-slate-100 shadow-sm group hover:border-blue-200 transition-all">
        <div className="flex justify-between items-start mb-4">
            <div className="p-3 bg-slate-50 rounded-2xl group-hover:bg-blue-50 transition-colors text-blue-600">
                {icon}
            </div>
            <span className="bg-blue-50 text-blue-600 text-[9px] font-black px-2.5 py-1 rounded-lg uppercase">{sub}</span>
        </div>
        <p className="text-slate-400 text-[10px] font-black uppercase tracking-widest mb-1">{label}</p>
        <p className={`text-3xl font-black ${color}`}>{value}</p>
    </div>
);

const TransactionRow = ({ id, title, sub, date, method, status, amount, isRefund = false }) => (
    <tr className="hover:bg-slate-50/50 transition-colors group">
        <td className="px-8 py-5 text-right">
            <div className="flex flex-col">
                <span className="text-[9px] font-black text-blue-600 mb-1 uppercase tracking-tighter">{id}</span>
                <p className="font-bold text-slate-800 text-sm">{title}</p>
                <p className="text-[10px] text-gray-400 font-medium">{sub}</p>
            </div>
        </td>
        <td className="px-8 py-5 text-sm font-bold text-slate-700">{date}</td>
        <td className="px-8 py-5 text-xs font-bold text-gray-600">{method}</td>
        <td className="px-8 py-5">
            <div className={`flex items-center gap-1.5 ${isRefund ? 'bg-amber-50 text-amber-600 border-amber-200' : 'bg-green-50 text-green-600 border-green-200'} w-fit px-3 py-1 rounded-full border opacity-80`}>
                <CheckCircle2 size={10} />
                <span className="text-[9px] font-black uppercase">{status}</span>
            </div>
        </td>
        <td className={`px-8 py-5 text-left font-black text-sm ${isRefund ? 'text-green-600' : 'text-slate-800'}`}>
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