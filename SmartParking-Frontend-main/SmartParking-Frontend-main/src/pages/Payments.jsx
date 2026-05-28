import React, { useState, useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { CreditCard, ArrowUpRight, Download, FileText, CheckCircle2, DollarSign, Loader2, Calendar, ShieldCheck, XCircle } from 'lucide-react';
import parkingService from '../services/parkingService';

const Payments = () => {
    const location = useLocation();
    const navigate = useNavigate();

    // Data from booking page
    const pendingBooking = location.state?.bookingData;

    const [transactions, setTransactions] = useState([]);
    const [loading, setLoading] = useState(true);
    const [isProcessing, setIsProcessing] = useState(false);
    const [cancellingId, setCancellingId] = useState(null);
    const [summary, setSummary] = useState({
        totalSpent: 0,
        refunds: 0,
        pending: 0,
        methodsCount: 1
    });

    // جلب بيانات المستخدم الحالي من الـ LocalStorage لاستخراج رقم الفيزا وحالة الربط
    const rawUser = localStorage.getItem('user');
    const currentUser = rawUser ? JSON.parse(rawUser) : null;

    useEffect(() => {
        fetchPaymentData();
    }, []);

    const fetchPaymentData = async () => {
        try {
            setLoading(true);
            // باستخدام الـ UserId الرقمي الفعلي المستخرج ديناميكياً أو الافتراضي 1
            const currentUserId = currentUser?.id || currentUser?.userId || 1;
            const data = await parkingService.getUserPaymentHistory(currentUserId);

            console.log("البيانات القادمة من الـ API بالكامل:", data);

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
            // 💳 1. التحقق الصارم من وجود الفيزا وحالة الربط قبل المتابعة
            if (!currentUser || !currentUser.hasLinkedCard || !currentUser.cardNumber) {
                alert("⚠️ Booking Denied!\n\nYou must register a valid credit card in your Account Settings before processing any reservations.");
                navigate('/settings'); // توجيه المستخدم مباشرة لصفحة الإعدادات لربط الكارت
                return;
            }

            // اقتطاع آخر 4 أرقام فقط من الفيزا المخزنة للأمان والاحترافية
            const lastFourDigits = currentUser.cardNumber.slice(-4);

            // 💳 2. تجهيز البيلود برقم الكارت الحقيقي المدخل من الإعدادات
            const paymentPayload = {
                userId: currentUser.id || currentUser.userId || pendingBooking.userId || 1,
                amount: pendingBooking.totalAmount,
                method: `Credit Card (Visa .... ${lastFourDigits})`,
                propertyId: pendingBooking.propertyId,
                parkingSpotId: pendingBooking.parkingSpotId,
            };

            await parkingService.processPayment(paymentPayload);
            alert("Booking confirmed and payment completed successfully using your registered card! 🎉");

            navigate('/payments', { state: null, replace: true });
            fetchPaymentData();
        } catch (error) {
            alert("Payment and booking failed: " + error.message);
        } finally {
            setIsProcessing(false);
        }
    };

    const handleCancelReservation = async (reservationId) => {
        if (!reservationId) {
            alert("Error: Valid Reservation ID not found for this transaction. Check your Browser Console to see object property names!");
            return;
        }

        if (!window.confirm("Are you sure you want to cancel this reservation?")) return;

        setCancellingId(reservationId);
        try {
            await parkingService.cancelReservation(reservationId);
            alert("Reservation cancelled successfully!");
            fetchPaymentData();
        } catch (error) {
            alert("Failed to cancel reservation: " + error.message);
        } finally {
            setCancellingId(null);
        }
    };

    if (loading) {
        return (
            <div className="flex flex-col items-center justify-center h-[60vh]">
                <Loader2 className="animate-spin text-blue-600 mb-4" size={40} />
                <p className="text-xl font-bold text-slate-800">Loading payment history...</p>
            </div>
        );
    }

    return (
        <div className="animate-in fade-in duration-500 text-left" dir="ltr">
            {/* Header Section */}
            <div className="mb-10">
                <h2 className="text-4xl font-black text-slate-800 mb-2">Payments & Invoices</h2>
                <p className="text-gray-500 font-medium">Manage your financial transactions and payment methods securely.</p>
            </div>

            {/* Pending Booking Alert */}
            {pendingBooking && (
                <div className="mb-12 relative overflow-hidden group">
                    <div className="absolute inset-0 bg-blue-600 rounded-[40px] translate-y-2 blur-2xl opacity-10"></div>
                    <div className="relative bg-white border-2 border-blue-600 rounded-[40px] overflow-hidden shadow-sm">
                        <div className="bg-blue-600 p-6 text-white flex justify-between items-center">
                            <div className="flex items-center gap-3">
                                <span className="p-2 bg-white/10 rounded-xl"><ShieldCheck size={24} /></span>
                                <h3 className="text-xl font-black">Confirm Villa & Services Booking</h3>
                            </div>
                            <span className="bg-white/20 px-4 py-1.5 rounded-full text-[10px] font-black uppercase">Awaiting Payment</span>
                        </div>

                        <div className="p-8 grid grid-cols-1 md:grid-cols-3 gap-8 items-center">
                            <div className="md:col-span-2 space-y-4 text-left">
                                <div>
                                    <h4 className="text-2xl font-black text-slate-900">{pendingBooking.propertyName}</h4>
                                    <div className="flex gap-4 mt-2 justify-start">
                                        <span className="flex items-center gap-1.5 text-xs font-bold text-slate-500"><Calendar size={14} /> {pendingBooking.nights} nights</span>
                                        {pendingBooking.parkingEnabled && (
                                            <span className="flex items-center gap-1.5 text-xs font-bold text-blue-600"><CheckCircle2 size={14} /> Smart Parking ({pendingBooking.parkingZone})</span>
                                        )}
                                    </div>
                                </div>
                                <div className="flex gap-4 bg-slate-50 p-4 rounded-2xl w-fit">
                                    <div className="text-center px-4 border-r border-slate-200">
                                        <p className="text-[10px] font-black text-slate-400 uppercase">Check-in</p>
                                        <p className="font-bold text-slate-700">{pendingBooking.checkIn}</p>
                                    </div>
                                    <div className="text-center px-4">
                                        <p className="text-[10px] font-black text-slate-400 uppercase">Check-out</p>
                                        <p className="font-bold text-slate-700">{pendingBooking.checkOut}</p>
                                    </div>
                                </div>
                            </div>

                            <div className="bg-slate-900 rounded-[30px] p-8 text-white shadow-xl">
                                <p className="text-[10px] font-black text-slate-400 uppercase mb-1">Amount Due</p>
                                <p className="text-4xl font-black mb-6">${pendingBooking.totalAmount.toLocaleString()}</p>
                                <button
                                    onClick={handleConfirmPayment}
                                    disabled={isProcessing}
                                    className="w-full bg-blue-600 hover:bg-blue-500 py-4 rounded-2xl font-black transition-all flex items-center justify-center gap-2"
                                >
                                    {isProcessing ? <Loader2 className="animate-spin" /> : <><CreditCard size={18} /> Pay & Confirm Now</>}
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            )}

            {/* Stats Grid */}
            <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6 mb-12">
                <PaymentStat label="Total Spent" value={`$${summary.totalSpent.toFixed(2)}`} sub="All Time" icon={<DollarSign size={20} />} />
                <PaymentStat label="Refunds" value={`$${summary.refunds.toFixed(2)}`} sub="Total" icon={<ArrowUpRight size={20} />} color="text-green-600" />
                <PaymentStat label="Pending Payments" value={`$${summary.pending.toFixed(2)}`} sub="Current" icon={<Loader2 size={20} />} />
                <PaymentStat label="Payment Methods" value={currentUser?.hasLinkedCard ? 1 : 0} sub="Active" icon={<CreditCard size={20} />} />
            </div>

            {/* Transactions Table */}
            <div className="bg-white rounded-[32px] border border-slate-100 shadow-sm overflow-hidden">
                <div className="p-8 border-b border-gray-50 flex justify-between items-center">
                    <h3 className="text-xl font-black text-slate-800">Recent Transactions</h3>
                    <button className="flex items-center gap-2 text-[10px] font-black text-gray-500 border border-gray-100 px-5 py-2.5 rounded-xl hover:bg-gray-50 transition-all uppercase tracking-widest">
                        <Download size={14} /> Export Data
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
                                <th className="px-8 py-5 text-center">Actions</th>
                            </tr>
                        </thead>
                        <tbody className="divide-y divide-slate-50">
                            {transactions.length > 0 ? (
                                transactions.map((txn, index) => {
                                    const targetReservationId = txn.id;

                                    // 🛠️ التعديل الجوهري: إجبار السطر على قراءة رقم الفيزا المربوطة حالياً بالحساب من الـ LocalStorage 
                                    // إذا لم ترجع فيزا من الـ API أو رجعت القيمة الافتراضية القديمة "4242"
                                    let formattedMethod = txn.method;
                                    if (!formattedMethod || formattedMethod.includes("4242")) {
                                        formattedMethod = currentUser?.cardNumber
                                            ? `Credit Card (Visa .... ${currentUser.cardNumber.slice(-4)})`
                                            : "Credit Card (Visa .... 4242)";
                                    }

                                    return (
                                        <TransactionRow
                                            key={txn.transactionId || index}
                                            id={txn.transactionId || `TXN-${String(index + 1).padStart(6, '0')}`}
                                            title={txn.status === 'Refunded' ? "Refund" : (txn.type === 'Property Purchase' ? "Property Purchase" : "Stay & Parking Booking")}
                                            sub={txn.propertyName || "RealPark Services"}
                                            date={txn.date}
                                            method={formattedMethod}
                                            status={txn.status}
                                            amount={`$${txn.amount.toFixed(2)}`}
                                            isRefund={txn.status === 'Refunded'}
                                            isPurchase={txn.type === 'Property Purchase'}
                                            onCancel={() => handleCancelReservation(targetReservationId)}
                                            isCancelling={cancellingId === targetReservationId}
                                        />
                                    );
                                })
                            ) : (
                                <tr>
                                    <td colSpan="6" className="text-center py-16 text-gray-400 font-bold">
                                        No financial transactions recorded yet.
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

const TransactionRow = ({ id, title, sub, date, method, status, amount, isRefund = false, isPurchase = false, onCancel, isCancelling }) => {
    const canCancel = status?.toLowerCase() !== 'refunded' && status?.toLowerCase() !== 'cancelled' && status?.toLowerCase() !== 'failed' && !isPurchase;

    const currentStatus = status?.toLowerCase();
    let badgeClasses = "bg-green-50 text-green-600 border-green-200";
    let StatusIcon = CheckCircle2;

    if (currentStatus === 'cancelled' || currentStatus === 'failed') {
        badgeClasses = "bg-red-50 text-red-600 border-red-200";
        StatusIcon = XCircle;
    } else if (currentStatus === 'refunded') {
        badgeClasses = "bg-amber-50 text-amber-600 border-amber-200";
    }

    return (
        <tr className="hover:bg-slate-50/50 transition-colors group">
            <td className="px-8 py-5 text-left">
                <div className="flex flex-col">
                    <span className="text-[9px] font-black text-blue-600 mb-1 uppercase tracking-tighter">{id}</span>
                    <p className="font-bold text-slate-800 text-sm">{title}</p>
                    <p className="text-[10px] text-gray-400 font-medium">{sub}</p>
                </div>
            </td>
            <td className="px-8 py-5 text-sm font-bold text-slate-700">{date}</td>
            <td className="px-8 py-5 text-xs font-bold text-gray-600">{method}</td>
            <td className="px-8 py-5">
                <div className={`flex items-center gap-1.5 ${badgeClasses} w-fit px-3 py-1 rounded-full border opacity-80`}>
                    <StatusIcon size={10} />
                    <span className="text-[9px] font-black uppercase">{status}</span>
                </div>
            </td>
            <td className={`px-8 py-5 text-right font-black text-sm ${isRefund ? 'text-green-600' : 'text-slate-800'}`}>
                {isRefund ? `+${amount}` : amount}
            </td>
            <td className="px-8 py-5 text-center">
                <div className="flex gap-2 justify-center">
                    <button className="text-slate-300 hover:text-blue-600 transition p-2 bg-slate-50 rounded-lg" title="View Receipt">
                        <FileText size={16} />
                    </button>
                    {canCancel && (
                        <button
                            onClick={() => onCancel()}
                            disabled={isCancelling}
                            className="text-red-400 hover:text-red-600 hover:bg-red-100 transition p-2 bg-red-50 rounded-lg disabled:opacity-50"
                            title="Cancel Reservation"
                        >
                            {isCancelling ? <Loader2 size={16} className="animate-spin" /> : <XCircle size={16} />}
                        </button>
                    )}
                </div>
            </td>
        </tr>
    );
};

export default Payments;
