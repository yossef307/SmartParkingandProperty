import React, { useState, useEffect, useMemo } from 'react';
import { MapPin, Bed, Bath, Square, Car, Heart, Share2, Star, Loader2, CheckCircle2 } from 'lucide-react';
import { useNavigate } from 'react-router-dom';
import parkingService from '../services/parkingService';

const PropertyDetails = () => {
    const [isParkingEnabled, setIsParkingEnabled] = useState(false);
    const [isSubmitting, setIsSubmitting] = useState(false); // لحالة السويتش
    const [isBooking, setIsBooking] = useState(false);     // لحالة زرار الدفع
    const [reservedSpot, setReservedSpot] = useState(null);
    const [isLoved, setIsLoved] = useState(false);
    const [selectedZone, setSelectedZone] = useState('A');
    const [copySuccess, setCopySuccess] = useState(false);

    const navigate = useNavigate();

    // داتا ثابتة للتجربة (يمكن جلبها من API لاحقاً)
    const propertyId = 1;
    const userId = 1;
    const pricePerNight = 1250;
    const serviceFee = 120;
    const zonePrices = useMemo(() => ({ 'A': 50, 'B': 30, 'C': 15 }), []);

    const [checkIn, setCheckIn] = useState('2026-03-14');
    const [checkOut, setCheckOut] = useState('2026-03-21');
    const [nights, setNights] = useState(7);

    // حساب عدد الليالي تلقائياً
    useEffect(() => {
        const start = new Date(checkIn);
        const end = new Date(checkOut);
        if (isNaN(start) || isNaN(end)) return;
        const difference = end.getTime() - start.getTime();
        const calculatedNights = Math.ceil(difference / (1000 * 3600 * 24));
        setNights(calculatedNights > 0 ? calculatedNights : 0);
    }, [checkIn, checkOut]);

    const villaBasePrice = pricePerNight * nights;
    const parkingPrice = isParkingEnabled ? (zonePrices[selectedZone] * nights) : 0;
    const totalPrice = villaBasePrice + parkingPrice + serviceFee;

    // تفعيل أو إلغاء الركن الذكي
    const handleToggleParking = async () => {
        if (nights <= 0) {
            alert("يرجى اختيار تواريخ إقامة صحيحة أولاً");
            return;
        }

        setIsSubmitting(true);
        try {
            if (!isParkingEnabled) {
                // 1. جلب الركنات المتاحة
                const spots = await parkingService.getParkingSpots();

                // 2. البحث عن ركنة مناسبة في الزون المختارة وتابعة للعقار
                const availableInZone = spots.find(s =>
                    s.status?.trim().toLowerCase() === 'available' &&
                    s.zone?.trim().toUpperCase() === selectedZone.toUpperCase() &&
                    Number(s.propertyId) === Number(propertyId)
                );

                if (availableInZone) {
                    const reservationRequest = {
                        PropertyId: Number(propertyId),
                        ParkingSpotId: Number(availableInZone.id),
                        UserId: Number(userId),
                        StartDate: checkIn, // الـ service هيحولها لـ ISO
                        EndDate: checkOut,
                        TotalPrice: Number(zonePrices[selectedZone] * nights)
                    };

                    // 3. حجز الركنة في الـ Backend
                    await parkingService.confirmReservation(reservationRequest);
                    setReservedSpot(availableInZone);
                    setIsParkingEnabled(true);
                } else {
                    alert(`عذراً، لا توجد أماكن متاحة حالياً في Zone ${selectedZone}`);
                }
            } else {
                // إلغاء الحجز
                if (reservedSpot) {
                    await parkingService.cancelReservation(reservedSpot.id);
                    setIsParkingEnabled(false);
                    setReservedSpot(null);
                }
            }
        } catch (error) {
            alert(error.message);
        } finally {
            setIsSubmitting(false);
        }
    };

    // ✅ دالة الانتقال للدفع مع تمرير كافة البيانات
    const handleBooking = async () => {
        if (nights <= 0) return;

        setIsBooking(true);
        try {
            const bookingSummary = {
                propertyId,
                propertyName: "فيلا بيفرلي هيلز الذكية",
                userId,
                checkIn,
                checkOut,
                nights,
                villaBasePrice,
                serviceFee,
                parkingEnabled: isParkingEnabled,
                parkingSpotId: reservedSpot?.id || null,
                parkingSpotNumber: reservedSpot?.spotNumber || null,
                parkingZone: isParkingEnabled ? selectedZone : null,
                parkingPrice,
                totalAmount: totalPrice, // السعر النهائي للدفع
            };

            // محاكاة تأخير بسيط للتحميل لإعطاء شعور بالاحترافية
            setTimeout(() => {
                navigate('/payments', { state: { bookingData: bookingSummary } });
                setIsBooking(false);
            }, 800);

        } catch (error) {
            alert("حدث خطأ أثناء تجهيز الفاتورة.");
            setIsBooking(false);
        }
    };

    const handleShare = () => {
        navigator.clipboard.writeText(window.location.href);
        setCopySuccess(true);
        setTimeout(() => setCopySuccess(false), 2000);
    };

    return (
        <div className="min-h-screen bg-[#FAFBFF] font-sans text-right" dir="rtl">
            <main className="max-w-[1400px] mx-auto px-6 lg:px-12 py-8">

                {/* Header Section */}
                <div className="flex justify-between items-center mb-8">
                    <nav className="flex items-center gap-2 text-xs font-bold text-gray-400">
                        <span className="hover:text-blue-600 cursor-pointer">العقارات المتاحة</span>
                        <span>/</span>
                        <span className="text-blue-600">فيلا بيفرلي هيلز الذكية</span>
                    </nav>
                    <div className="flex gap-3">
                        <button onClick={handleShare} className="p-3 bg-white border border-gray-100 rounded-2xl hover:shadow-md transition-all">
                            {copySuccess ? <CheckCircle2 size={20} className="text-green-500" /> : <Share2 size={20} className="text-gray-600" />}
                        </button>
                        <button onClick={() => setIsLoved(!isLoved)} className={`p-3 border transition-all rounded-2xl ${isLoved ? 'border-red-100 bg-red-50 text-red-500 shadow-inner' : 'bg-white border-gray-100 text-gray-600'}`}>
                            <Heart size={20} className={isLoved ? 'fill-red-500' : ''} />
                        </button>
                    </div>
                </div>

                {/* Image Gallery Grid */}
                <div className="grid grid-cols-4 grid-rows-2 gap-4 h-[500px] mb-12 rounded-[40px] overflow-hidden shadow-2xl shadow-blue-900/5">
                    <div className="col-span-2 row-span-2 relative group">
                        <img src="https://images.unsplash.com/photo-1613490493576-7fde63acd811" alt="Main" className="w-full h-full object-cover transition-transform duration-700 group-hover:scale-105" />
                        <div className="absolute top-6 right-6 bg-white/90 backdrop-blur px-4 py-2 rounded-xl font-bold text-[10px] text-blue-600 shadow-sm">RealPark System - IoT Connected</div>
                    </div>
                    <div className="col-span-1 row-span-1 overflow-hidden">
                        <img src="https://images.unsplash.com/photo-1613977257363-707ba9348227" alt="Int" className="w-full h-full object-cover hover:scale-110 transition-all duration-500" />
                    </div>
                    <div className="col-span-1 row-span-1 overflow-hidden">
                        <img src="https://images.unsplash.com/photo-1512917774080-9991f1c4c750" alt="Pool" className="w-full h-full object-cover hover:scale-110 transition-all duration-500" />
                    </div>
                    <div className="col-span-2 row-span-1 relative group overflow-hidden">
                        <img src="https://images.unsplash.com/photo-1600585154340-be6161a56a0c" alt="Kitchen" className="w-full h-full object-cover group-hover:scale-105 transition-all duration-700" />
                        <button className="absolute bottom-6 left-6 bg-slate-900/90 backdrop-blur-md text-white px-8 py-3 rounded-2xl font-bold text-xs hover:bg-blue-600 shadow-lg">استكشاف 24 صورة</button>
                    </div>
                </div>

                <div className="grid grid-cols-1 lg:grid-cols-3 gap-12">
                    {/* Left Side: Info */}
                    <div className="lg:col-span-2">
                        <div className="flex flex-col gap-2 mb-6">
                            <div className="flex items-center gap-2">
                                <span className="bg-blue-600 text-white text-[9px] font-black px-3 py-1 rounded-full uppercase tracking-wider">Premium Plus</span>
                                <span className="bg-slate-100 text-slate-500 text-[9px] font-black px-3 py-1 rounded-full uppercase tracking-wider">Smart Home</span>
                            </div>
                            <h1 className="text-5xl font-black text-slate-900 leading-tight">
                                فيلا مودرن <span className="text-blue-600 underline decoration-blue-100 decoration-8 underline-offset-8">بيفرلي هيلز</span>
                            </h1>
                        </div>

                        <div className="flex items-center gap-8 text-gray-500 font-bold mb-10 pb-8 border-b border-gray-100">
                            <div className="flex items-center gap-2 text-blue-600 cursor-pointer"><MapPin size={20} /> الشيخ زايد، بوابة 4</div>
                            <div className="flex items-center gap-1.5"><Star size={18} className="fill-amber-400 text-amber-400" /> 4.9 <span className="text-gray-300 font-medium">(124 تقييم)</span></div>
                        </div>

                        <div className="grid grid-cols-2 md:grid-cols-4 gap-5 mb-12">
                            <FeatureItem icon={<Bed />} label="4 غرف نوم" />
                            <FeatureItem icon={<Bath />} label="3 حمامات" />
                            <FeatureItem icon={<Square />} label="3,500 م²" />
                            <FeatureItem icon={<Car />} label={isParkingEnabled ? `ركنة ${reservedSpot?.spotNumber}` : "ركن ذكي"} highlight={isParkingEnabled} />
                        </div>

                        <div className="bg-gradient-to-l from-blue-50/50 to-transparent p-8 rounded-[35px] border border-blue-50 mb-10">
                            <h3 className="text-xl font-black text-blue-900 mb-4 flex items-center gap-2">
                                <CheckCircle2 className="text-blue-600" size={24} /> لماذا نظام RealPark؟
                            </h3>
                            <p className="text-blue-800/70 text-md leading-relaxed font-medium">
                                من خلال دمج تقنيات IoT، نضمن لك مكاناً مخصصاً لسيارتك يتم فتحه تلقائياً عبر التطبيق عند اقترابك من العقار، مما يلغي عناء البحث عن ركنة وتأمين سيارتك في منطقة مراقبة.
                            </p>
                        </div>
                    </div>

                    {/* Right Side: Booking Card */}
                    <div className="lg:col-span-1">
                        <div className="sticky top-8 bg-white border border-blue-50 rounded-[40px] p-8 shadow-2xl shadow-blue-900/5">
                            <div className="flex justify-between items-start mb-8">
                                <div>
                                    <p className="text-[10px] font-black text-gray-400 uppercase mb-1 tracking-widest">السعر الأساسي</p>
                                    <div className="flex items-baseline gap-1">
                                        <span className="text-4xl font-black text-slate-900">${pricePerNight}</span>
                                        <span className="text-gray-400 text-sm font-bold">/ليلة</span>
                                    </div>
                                </div>
                                <div className="bg-green-50 text-green-600 px-4 py-1.5 rounded-full text-[10px] font-black border border-green-100">متاح للحجز</div>
                            </div>

                            <div className="grid grid-cols-2 gap-3 mb-6">
                                <DateInput label="وصول" value={checkIn} onChange={(e) => setCheckIn(e.target.value)} />
                                <DateInput label="مغادرة" value={checkOut} onChange={(e) => setCheckOut(e.target.value)} />
                            </div>

                            <div className="mb-8">
                                <label className="text-[10px] font-black text-slate-400 uppercase mb-3 block tracking-widest text-center">اختر المنطقة (Zone)</label>
                                <div className="flex gap-2">
                                    {['A', 'B', 'C'].map((zone) => (
                                        <button
                                            key={zone}
                                            disabled={isParkingEnabled || isSubmitting}
                                            onClick={() => setSelectedZone(zone)}
                                            className={`flex-1 py-4 rounded-2xl text-[11px] font-black transition-all ${selectedZone === zone ? 'bg-blue-600 text-white shadow-lg' : 'bg-white text-gray-400 border border-gray-100 hover:border-blue-200 disabled:opacity-50'}`}
                                        >
                                            Zone {zone} <span className="block text-[8px] opacity-60">${zonePrices[zone]}</span>
                                        </button>
                                    ))}
                                </div>
                            </div>

                            {/* RealPark Switch */}
                            <div className={`p-5 rounded-[25px] border-2 transition-all mb-8 flex justify-between items-center ${isParkingEnabled ? 'bg-blue-600 border-blue-500' : 'bg-blue-50/30 border-blue-100/50'}`}>
                                <div className="flex items-center gap-3 text-right">
                                    <div className={`p-3 rounded-2xl ${isParkingEnabled ? 'bg-blue-500 text-white' : 'bg-white text-blue-600'}`}>
                                        <Car size={22} />
                                    </div>
                                    <div>
                                        <p className={`text-[9px] font-black uppercase ${isParkingEnabled ? 'text-blue-100' : 'text-blue-600'}`}>RealPark Active</p>
                                        <p className={`font-bold text-sm ${isParkingEnabled ? 'text-white' : 'text-slate-800'}`}>
                                            {isParkingEnabled ? `ركنة رقم: ${reservedSpot?.spotNumber}` : 'تفعيل الركن الذكي'}
                                        </p>
                                    </div>
                                </div>
                                <button
                                    onClick={handleToggleParking}
                                    disabled={isSubmitting}
                                    className={`w-14 h-7 rounded-full relative transition-all duration-300 ${isParkingEnabled ? 'bg-white/20' : 'bg-gray-200'}`}
                                >
                                    <div className={`absolute w-5 h-5 rounded-full top-1 transition-all duration-300 flex items-center justify-center shadow-md ${isParkingEnabled ? 'left-1 bg-white' : 'right-1 bg-white'}`}>
                                        {isSubmitting && <Loader2 size={12} className="animate-spin text-blue-600" />}
                                    </div>
                                </button>
                            </div>

                            {/* Price Summary */}
                            <div className="space-y-4 mb-8 bg-slate-50/50 p-6 rounded-3xl border border-dashed border-slate-200">
                                <div className="flex justify-between text-xs font-bold text-slate-500">
                                    <span>الإقامة ({nights} ليالي)</span><span>${villaBasePrice.toLocaleString()}</span>
                                </div>
                                {isParkingEnabled && (
                                    <div className="flex justify-between text-xs font-bold text-blue-600">
                                        <span>إضافة الركن (Zone {selectedZone})</span><span>+ ${parkingPrice.toLocaleString()}</span>
                                    </div>
                                )}
                                <div className="flex justify-between text-xs font-bold text-slate-500">
                                    <span>رسوم الخدمة</span><span>${serviceFee}</span>
                                </div>
                                <div className="flex justify-between text-xl font-black text-slate-900 pt-4 border-t border-slate-200">
                                    <span>الإجمالي</span><span>${totalPrice.toLocaleString()}</span>
                                </div>
                            </div>

                            {/* Main CTA Button */}
                            <button
                                onClick={handleBooking}
                                disabled={nights <= 0 || isSubmitting || isBooking}
                                className={`w-full py-5 rounded-[22px] font-black text-lg transition-all active:scale-95 flex items-center justify-center gap-3 ${nights > 0 && !isSubmitting && !isBooking ? 'bg-slate-900 text-white hover:bg-blue-700 shadow-2xl shadow-blue-200' : 'bg-gray-100 text-gray-400 cursor-not-allowed'}`}
                            >
                                {isBooking ? (
                                    <>
                                        <Loader2 className="animate-spin" size={20} />
                                        <span>جاري التحميل...</span>
                                    </>
                                ) : (
                                    'تأكيد الحجز والدفع'
                                )}
                            </button>

                            {!isParkingEnabled && nights > 0 && (
                                <p className="text-center text-[10px] text-gray-400 mt-3 font-medium">
                                    يمكنك إضافة ركن ذكي من خلال تفعيل RealPark أعلاه
                                </p>
                            )}
                        </div>
                    </div>
                </div>
            </main>
        </div>
    );
};

// Sub-components
const FeatureItem = ({ icon, label, highlight = false }) => (
    <div className={`flex flex-col items-center gap-3 p-6 rounded-[32px] border-2 transition-all cursor-default ${highlight ? 'bg-blue-600 border-blue-500 shadow-2xl scale-105' : 'bg-white border-gray-50 hover:border-blue-100'}`}>
        <div className={`p-3.5 rounded-[20px] ${highlight ? 'text-white bg-blue-500' : 'text-blue-600 bg-blue-50'}`}>
            {React.cloneElement(icon, { size: 26, strokeWidth: 2.5 })}
        </div>
        <span className={`text-[10px] font-black uppercase ${highlight ? 'text-white' : 'text-slate-500'}`}>{label}</span>
    </div>
);

const DateInput = ({ label, value, onChange }) => (
    <div className="p-4 bg-gray-50/50 rounded-2xl border border-gray-100 focus-within:border-blue-300 focus-within:bg-white transition-all">
        <label className="text-[9px] font-black text-gray-400 uppercase block mb-1">{label}</label>
        <input type="date" value={value} onChange={onChange} className="bg-transparent text-xs font-black w-full outline-none text-slate-700" />
    </div>
);

export default PropertyDetails;