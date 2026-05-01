import React, { useState, useEffect } from 'react';
import { QrCode, XCircle, CheckCircle2, Loader2 } from 'lucide-react';
import parkingService from '../services/parkingService';

const ParkingReservations = () => {
    const [spots, setSpots] = useState([]);
    const [selectedSpot, setSelectedSpot] = useState(null);
    const [loading, setLoading] = useState(true);
    const [actionLoading, setActionLoading] = useState(false);

    // ملاحظة لمشروع التخرج: تأكد أن الـ userId موجود في نظام الـ Auth عندك
    const userId = 1;

    const loadData = async () => {
        try {
            const data = await parkingService.getParkingSpots();
            // ترتيب البيانات وضمان وجود الحقول المطلوبة
            const formatted = data.sort((a, b) =>
                a.spotNumber.localeCompare(b.spotNumber, undefined, { numeric: true })
            ).map(s => ({
                id: s.id,
                name: s.spotNumber,
                zone: s.zone || (s.spotNumber.startsWith('A') ? 'A' : s.spotNumber.startsWith('B') ? 'B' : 'C'),
                price: s.pricePerHour || 0,
                status: s.status
            }));
            setSpots(formatted);
        } catch (error) {
            console.error("خطأ في تحميل البيانات:", error);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        loadData();
    }, []);

    const handleConfirm = async () => {
        if (!selectedSpot || !selectedSpot.id) return;

        setActionLoading(true);
        try {
            // 💡 التعديل الجوهري: التأكد من مطابقة الـ Payload لتوقعات الـ .NET Backend
            const payload = {
                reservationDto: {
                    parkingSpotId: Number(selectedSpot.id), // تحويل صريح لـ Int32
                    userId: Number(userId),
                    startDate: new Date().toISOString(),
                    endDate: new Date(Date.now() + (60 * 60 * 1000)).toISOString(), // حجز افتراضي لمدة ساعة
                    totalPrice: Number(selectedSpot.price)
                }
            };

            await parkingService.confirmReservation(payload);

            // تحديث الحالة محلياً فوراً لتحسين الـ UX قبل إعادة التحميل من السيرفر
            setSpots(prev => prev.map(s => s.id === selectedSpot.id ? { ...s, status: 'Reserved' } : s));

            alert(`✅ تم تأكيد حجز مكان رقم ${selectedSpot.name}`);
            setSelectedSpot(null);
            await loadData();
        } catch (error) {
            // إظهار تفاصيل الخطأ من الـ API إذا وجدت
            const errorMsg = error.response?.data?.reservationDto?.[0] || "فشل الاتصال بالسيرفر";
            console.error("API Error Detail:", error.response?.data);
            alert(`❌ خطأ: ${errorMsg}`);
        } finally {
            setActionLoading(false);
        }
    };

    const handleCancel = async () => {
        if (!selectedSpot) return;
        setActionLoading(true);
        try {
            await parkingService.cancelReservation(selectedSpot.id);
            await loadData();
            setSelectedSpot(null);
            alert(`✅ تم إلغاء حجز مكان ${selectedSpot.name}`);
        } catch (e) {
            alert("❌ فشل الإلغاء. حاول مرة أخرى.");
        } finally {
            setActionLoading(false);
        }
    };

    if (loading && spots.length === 0) return (
        <div className="min-h-screen flex flex-col items-center justify-center bg-white">
            <Loader2 className="animate-spin text-blue-600 mb-4" size={48} />
            <p className="font-black text-slate-600">جاري تشغيل نظام RealPark الذكي...</p>
        </div>
    );

    return (
        <div className="min-h-screen bg-slate-50 p-4 md:p-8 font-sans text-right" dir="rtl">
            <div className="max-w-[1400px] mx-auto flex flex-col lg:flex-row-reverse gap-8">

                {/* خريطة الجراج اللحظية */}
                <div className="flex-1 bg-white p-6 md:p-10 rounded-[40px] shadow-sm border border-slate-100">
                    <div className="mb-10">
                        <h2 className="text-3xl font-black text-slate-800">خريطة الجراج الحية</h2>
                        <p className="text-slate-400 font-bold">الأماكن المشغولة: {spots.filter(s => s.status !== 'Available').length} / {spots.length}</p>
                    </div>

                    {['A', 'B', 'C'].map(zoneLetter => (
                        <div key={zoneLetter} className="mb-12">
                            <h3 className="text-sm font-black text-slate-400 mb-5 uppercase tracking-widest">المنطقة {zoneLetter}</h3>
                            <div className="grid grid-cols-5 md:grid-cols-10 gap-3">
                                {spots.filter(s => s.zone === zoneLetter).map(spot => (
                                    <button
                                        key={spot.id}
                                        onClick={() => setSelectedSpot(spot)}
                                        className={`h-14 rounded-2xl border-2 flex items-center justify-center transition-all font-black text-xs
                                            ${spot.status !== 'Available'
                                                ? 'bg-blue-600 border-blue-600 text-white shadow-lg opacity-90'
                                                : selectedSpot?.id === spot.id
                                                    ? 'border-blue-600 bg-blue-50 text-blue-600'
                                                    : 'bg-white border-slate-100 text-blue-600 hover:border-blue-300'}`}
                                    >
                                        {spot.name}
                                    </button>
                                ))}
                            </div>
                        </div>
                    ))}
                </div>

                {/* لوحة التحكم الجانبية */}
                <div className="w-full lg:w-[380px]">
                    {selectedSpot ? (
                        <div className="bg-white p-8 rounded-[40px] border border-slate-100 shadow-2xl sticky top-8 animate-in fade-in slide-in-from-bottom-4">
                            <h3 className="text-2xl font-black mb-6">المكان: {selectedSpot.name}</h3>
                            <div className="space-y-4 mb-8 p-6 bg-slate-50 rounded-[30px]">
                                <div className="flex justify-between">
                                    <span className="text-slate-400 font-bold text-sm">الحالة</span>
                                    <span className={`font-black text-sm ${selectedSpot.status === 'Available' ? 'text-green-600' : 'text-blue-600'}`}>
                                        {selectedSpot.status === 'Available' ? 'متاح للركن' : 'محجوز حالياً'}
                                    </span>
                                </div>
                                <div className="flex justify-between">
                                    <span className="text-slate-400 font-bold text-sm">الساعة</span>
                                    <span className="font-black text-slate-800 text-sm">${selectedSpot.price}</span>
                                </div>
                            </div>

                            {selectedSpot.status === 'Available' ? (
                                <button
                                    onClick={handleConfirm}
                                    disabled={actionLoading}
                                    className="w-full bg-blue-600 text-white py-5 rounded-[24px] font-black flex items-center justify-center gap-2 hover:bg-blue-700 transition-all shadow-xl disabled:bg-slate-300"
                                >
                                    {actionLoading ? <Loader2 className="animate-spin" /> : <CheckCircle2 size={22} />}
                                    تأكيد حجز الدخول
                                </button>
                            ) : (
                                <button
                                    onClick={handleCancel}
                                    disabled={actionLoading}
                                    className="w-full bg-red-50 text-red-600 py-5 rounded-[24px] font-black flex items-center justify-center gap-2 hover:bg-red-100 transition-all disabled:opacity-50"
                                >
                                    {actionLoading ? <Loader2 className="animate-spin" /> : <XCircle size={22} />}
                                    إلغاء هذا الحجز
                                </button>
                            )}
                        </div>
                    ) : (
                        <div className="bg-slate-900 p-10 rounded-[40px] text-white text-center sticky top-8 shadow-2xl">
                            <div className="bg-white p-6 rounded-[35px] inline-block mb-8">
                                <QrCode size={150} className="text-slate-900" />
                            </div>
                            <h3 className="font-black text-xl mb-3">مسح الكود (QR)</h3>
                            <p className="text-slate-400 text-sm font-medium leading-relaxed">
                                قم باختيار مكان من الخريطة للحصول على تصريح دخول البوابة الذكية.
                            </p>
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default ParkingReservations;