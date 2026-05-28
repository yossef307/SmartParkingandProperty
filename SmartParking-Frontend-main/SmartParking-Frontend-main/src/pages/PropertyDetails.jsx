import React, { useState, useEffect, useMemo } from 'react';
import { MapPin, Bed, Bath, Square, Car, Heart, Share2, Star, Loader2, CheckCircle2, AlertTriangle, ShoppingBag, CreditCard } from 'lucide-react';
import { useNavigate, useParams } from 'react-router-dom';
import parkingService from '../services/parkingService';
import axios from 'axios';

const PropertyDetails = () => {
    const [isParkingEnabled, setIsParkingEnabled] = useState(false);
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [isBooking, setIsBooking] = useState(false);
    const [reservedSpot, setReservedSpot] = useState(null);
    const [reservationId, setReservationId] = useState(null);
    const [isLoved, setIsLoved] = useState(false);
    const [selectedZone, setSelectedZone] = useState('A');
    const [copySuccess, setCopySuccess] = useState(false);
    const [isPurchasing, setIsPurchasing] = useState(false);
    const [showPurchaseModal, setShowPurchaseModal] = useState(false);

    const [bookedRanges, setBookedRanges] = useState([]);
    const [isDateInvalid, setIsDateInvalid] = useState(false);

    // Property data state
    const [property, setProperty] = useState(null);
    const [isLoading, setIsLoading] = useState(true);

    const navigate = useNavigate();

    // Get propertyId from URL params instead of hardcoded value
    const { id } = useParams();
    const propertyId = Number(id) || 1;

    // Get userId from localStorage instead of hardcoded value
    const userId = JSON.parse(localStorage.getItem('user'))?.id || null;

    const serviceFee = 120;
    const zonePrices = useMemo(() => ({ 'A': 50, 'B': 30, 'C': 15 }), []);

    const getFormattedDate = (daysOffset = 0) => {
        const date = new Date();
        date.setDate(date.getDate() + daysOffset);
        return date.toISOString().split('T')[0];
    };

    const [checkIn, setCheckIn] = useState(getFormattedDate(0));
    const [checkOut, setCheckOut] = useState(getFormattedDate(1));
    const [nights, setNights] = useState(1);

    // Fetch property data from API
    useEffect(() => {
        const fetchProperty = async () => {
            setIsLoading(true);
            try {
                const response = await axios.get(`https://localhost:7144/api/Properties/${propertyId}`);
                setProperty(response.data);
            } catch (error) {
                console.error("Error fetching property:", error);
            } finally {
                setIsLoading(false);
            }
        };
        fetchProperty();
    }, [propertyId]);

    useEffect(() => {
        const fetchBookedDates = async () => {
            try {
                const response = await axios.get(`https://localhost:7144/api/Reservations/PropertyBookedDates/${propertyId}`);
                setBookedRanges(response.data);
            } catch (error) {
                console.error("Error fetching booked dates:", error);
            }
        };
        fetchBookedDates();
    }, [propertyId]);

    useEffect(() => {
        const start = new Date(checkIn);
        const end = new Date(checkOut);

        if (isNaN(start) || isNaN(end)) return;

        const difference = end.getTime() - start.getTime();
        const calculatedNights = Math.ceil(difference / (1000 * 3600 * 24));
        const finalNights = calculatedNights > 0 ? calculatedNights : 0;
        setNights(finalNights);

        if (finalNights > 0 && bookedRanges.length > 0) {
            const hasOverlap = bookedRanges.some(range => {
                const bookedStart = new Date(range.startTime);
                const bookedEnd = new Date(range.endTime);
                return (start < bookedEnd && end > bookedStart);
            });
            setIsDateInvalid(hasOverlap);
        } else {
            setIsDateInvalid(false);
        }
    }, [checkIn, checkOut, bookedRanges]);

    // Dynamic pricing from property data
    const isHourlyPricing = (!property?.pricePerNight || property?.pricePerNight === 0) && property?.pricePerHour > 0;
    const pricePerNight = property?.pricePerNight && property?.pricePerNight > 0 ? property?.pricePerNight : property?.pricePerHour ?? property?.price ?? 0;
    const priceLabel = isHourlyPricing ? "/hour" : "/night";
    const stayLabel = isHourlyPricing ? "hours" : "nights";
    const villaBasePrice = pricePerNight * nights;
    const parkingPrice = isParkingEnabled ? (zonePrices[selectedZone] * nights) : 0;
    const totalPrice = villaBasePrice + parkingPrice + serviceFee;

    const handleToggleParking = async () => {
        if (nights <= 0 || isDateInvalid) {
            alert("Please select valid, non-booked stay dates first.");
            return;
        }

        if (!userId) {
            alert("Please login first to enable parking.");
            navigate('/login');
            return;
        }

        setIsSubmitting(true);
        try {
            if (!isParkingEnabled) {
                // ✅ جلب الـ spot المتاح مباشرة من الـ API بدل ما نعمل filter في الـ frontend
                let availableInZone = null;
                try {
                    const spotResponse = await axios.get(
                        `https://localhost:7144/api/ParkingSpots/AvailableInZone?propertyId=${propertyId}&zone=${selectedZone}`
                    );
                    availableInZone = spotResponse.data;
                } catch (spotError) {
                    // 404 = مفيش spots متاحة
                    availableInZone = null;
                }

                if (availableInZone) {
                    const reservationRequest = {
                        PropertyId: Number(propertyId),
                        ParkingSpotId: Number(availableInZone.id),
                        UserId: Number(userId),
                        StartDate: checkIn,
                        EndDate: checkOut,
                        TotalPrice: Number(zonePrices[selectedZone] * nights)
                    };

                    const reservationRes = await parkingService.confirmReservation(reservationRequest);
                    setReservationId(reservationRes?.reservationId || null);
                    setReservedSpot(availableInZone);
                    setIsParkingEnabled(true);
                } else {
                    alert(`Sorry, no spots are currently available in Zone ${selectedZone}.`);
                }
            } else {
                if (reservedSpot) {
                    await parkingService.cancelReservation(reservationId);
                    setIsParkingEnabled(false);
                    setReservedSpot(null);
                    setReservationId(null);
                }
            }
        } catch (error) {
            alert(error.message);
        } finally {
            setIsSubmitting(false);
        }
    };

    const handleBooking = async () => {
        if (nights <= 0 || isDateInvalid) return;

        if (!userId) {
            alert("Please login first to book.");
            navigate('/login');
            return;
        }

        setIsBooking(true);
        try {
            const bookingSummary = {
                propertyId,
                propertyName: property?.name || "Property",
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
                totalAmount: totalPrice,
            };

            setTimeout(() => {
                navigate('/payments', { state: { bookingData: bookingSummary } });

                setIsParkingEnabled(false);
                setReservedSpot(null);
                setCheckIn(getFormattedDate(0));
                setCheckOut(getFormattedDate(1));
                setIsBooking(false);
            }, 800);

        } catch (error) {
            alert("An error occurred while preparing your invoice.");
            setIsBooking(false);
        }
    };

    const handleShare = () => {
        navigator.clipboard.writeText(window.location.href);
        setCopySuccess(true);
        setTimeout(() => setCopySuccess(false), 2000);
    };

    // Handle Purchase Property
    const handlePurchase = async () => {
        if (!userId) {
            alert("Please login first to purchase.");
            navigate('/login');
            return;
        }

        setIsPurchasing(true);
        try {
            const response = await axios.post('https://localhost:7144/api/Sales', {
                propertyId: propertyId,
                buyerId: userId,
                paymentMethod: 'Card'
            });

            if (response.data.success) {
                alert(response.data.message || 'Purchase successful!');
                setShowPurchaseModal(false);
                // Refresh property data to show sold status
                const updatedProperty = await axios.get(`https://localhost:7144/api/Properties/${propertyId}`);
                setProperty(updatedProperty.data);
            }
        } catch (error) {
            const errorMsg = error.response?.data?.message || 'An error occurred during purchase.';
            alert(errorMsg);
        } finally {
            setIsPurchasing(false);
        }
    };

    // Check if property is for sale
    const isForSale = property?.listingType === 'Sale' || property?.listingType === 'Both';
    const isForRent = property?.listingType === 'Rent' || property?.listingType === 'Both';
    const isSold = property?.isSold;

    // Loading state
    if (isLoading) {
        return (
            <div className="min-h-screen bg-[#FAFBFF] flex items-center justify-center">
                <Loader2 className="animate-spin text-blue-600" size={48} />
            </div>
        );
    }

    return (
        <div className="min-h-screen bg-[#FAFBFF] font-sans text-left" dir="ltr">
            <main className="max-w-[1400px] mx-auto px-6 lg:px-12 py-8">

                {/* Header Section */}
                <div className="flex justify-between items-center mb-8">
                    <nav className="flex items-center gap-2 text-xs font-bold text-gray-400">
                        <span className="hover:text-blue-600 cursor-pointer" onClick={() => navigate('/properties')}>Available Properties</span>
                        <span>/</span>
                        <span className="text-blue-600">{property?.name || "Property Details"}</span>
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
                        <img src={property?.imageUrl || "https://images.unsplash.com/photo-1613490493576-7fde63acd811"} alt="Main" className="w-full h-full object-cover transition-transform duration-700 group-hover:scale-105" />
                        <div className="absolute top-6 left-6 bg-white/90 backdrop-blur px-4 py-2 rounded-xl font-bold text-[10px] text-blue-600 shadow-sm">RealPark System - IoT Connected</div>
                    </div>
                    <div className="col-span-1 row-span-1 overflow-hidden">
                        <img src={property?.images?.[1] || "https://images.unsplash.com/photo-1613977257363-707ba9348227"} alt="Interior" className="w-full h-full object-cover hover:scale-110 transition-all duration-500" />
                    </div>
                    <div className="col-span-1 row-span-1 overflow-hidden">
                        <img src={property?.images?.[2] || "https://images.unsplash.com/photo-1512917774080-9991f1c4c750"} alt="Pool" className="w-full h-full object-cover hover:scale-110 transition-all duration-500" />
                    </div>
                    <div className="col-span-2 row-span-1 relative group overflow-hidden">
                        <img src={property?.images?.[3] || "https://images.unsplash.com/photo-1600585154340-be6161a56a0c"} alt="Kitchen" className="w-full h-full object-cover group-hover:scale-105 transition-all duration-700" />
                        <button className="absolute bottom-6 right-6 bg-slate-900/90 backdrop-blur-md text-white px-8 py-3 rounded-2xl font-bold text-xs hover:bg-blue-600 shadow-lg">
                            Explore {property?.images?.length || 24} Photos
                        </button>
                    </div>
                </div>

                <div className="grid grid-cols-1 lg:grid-cols-3 gap-12">
                    {/* Left Side: Info */}
                    <div className="lg:col-span-2">
                        <div className="flex flex-col gap-2 mb-6">
                            <div className="flex items-center gap-2">
                                <span className="bg-blue-600 text-white text-[9px] font-black px-3 py-1 rounded-full uppercase tracking-wider">
                                    {property?.category || "Premium Plus"}
                                </span>
                                <span className="bg-slate-100 text-slate-500 text-[9px] font-black px-3 py-1 rounded-full uppercase tracking-wider">Smart Home</span>
                                {isForSale && !isSold && (
                                    <span className="bg-green-100 text-green-600 text-[9px] font-black px-3 py-1 rounded-full uppercase tracking-wider">For Sale</span>
                                )}
                                {isSold && (
                                    <span className="bg-red-100 text-red-600 text-[9px] font-black px-3 py-1 rounded-full uppercase tracking-wider">Sold</span>
                                )}
                            </div>
                            <h1 className="text-5xl font-black text-slate-900 leading-tight">
                                {property?.name || "Modern Villa"}
                            </h1>
                        </div>

                        <div className="flex items-center gap-8 text-gray-500 font-bold mb-10 pb-8 border-b border-gray-100">
                            <div className="flex items-center gap-2 text-blue-600 cursor-pointer">
                                <MapPin size={20} /> {property?.location || "Location"}
                            </div>
                            <div className="flex items-center gap-1.5">
                                <Star size={18} className="fill-amber-400 text-amber-400" />
                                {property?.rating || "4.9"}
                                <span className="text-gray-300 font-medium">({property?.reviewsCount || 0} reviews)</span>
                            </div>
                        </div>

                        <div className="grid grid-cols-2 md:grid-cols-4 gap-5 mb-12">
                            <FeatureItem icon={<Bed />} label={`${property?.bedrooms || 4} Bedrooms`} />
                            <FeatureItem icon={<Bath />} label={`${property?.bathrooms || 3} Bathrooms`} />
                            <FeatureItem icon={<Square />} label={`${property?.area || "3,500"} m2`} />
                            <FeatureItem icon={<Car />} label={isParkingEnabled ? `Spot ${reservedSpot?.spotNumber}` : "Smart Parking"} highlight={isParkingEnabled} />
                        </div>

                        <div className="bg-gradient-to-r from-blue-50/50 to-transparent p-8 rounded-[35px] border border-blue-50 mb-10">
                            <h3 className="text-xl font-black text-blue-900 mb-4 flex items-center gap-2">
                                <CheckCircle2 className="text-blue-600" size={24} /> Why RealPark System?
                            </h3>
                            <p className="text-blue-800/70 text-md leading-relaxed font-medium">
                                {property?.description || "By integrating IoT technologies, we guarantee a designated parking spot that unlocks automatically via the app as you approach the property, eliminating the hassle of searching for parking and keeping your car in a secured area."}
                            </p>
                        </div>

                        {/* Purchase Section - For Sale Properties */}
                        {isForSale && !isSold && (
                            <div className="bg-gradient-to-r from-green-50 to-emerald-50/50 p-8 rounded-[35px] border border-green-100 mb-10">
                                <div className="flex items-center justify-between">
                                    <div>
                                        <h3 className="text-xl font-black text-green-900 mb-2 flex items-center gap-2">
                                            <ShoppingBag className="text-green-600" size={24} /> Property For Sale
                                        </h3>
                                        <p className="text-green-700/70 text-sm font-medium mb-3">
                                            This property is available for purchase. Own your dream home today!
                                        </p>
                                        <div className="flex items-baseline gap-2">
                                            <span className="text-3xl font-black text-green-700">
                                                ${(property?.salePrice || property?.price || 0).toLocaleString()}
                                            </span>
                                            <span className="text-green-600/60 text-sm font-bold">EGP</span>
                                        </div>
                                    </div>
                                    <button
                                        onClick={() => setShowPurchaseModal(true)}
                                        className="bg-green-600 hover:bg-green-700 text-white px-8 py-4 rounded-2xl font-black text-sm flex items-center gap-2 shadow-lg shadow-green-200 transition-all active:scale-95"
                                    >
                                        <CreditCard size={20} />
                                        Buy Now
                                    </button>
                                </div>
                            </div>
                        )}

                        {/* Sold Notice */}
                        {isSold && (
                            <div className="bg-gradient-to-r from-red-50 to-rose-50/50 p-8 rounded-[35px] border border-red-100 mb-10">
                                <h3 className="text-xl font-black text-red-900 mb-2 flex items-center gap-2">
                                    <AlertTriangle className="text-red-600" size={24} /> Property Sold
                                </h3>
                                <p className="text-red-700/70 text-sm font-medium">
                                    This property has been sold and is no longer available for purchase.
                                </p>
                            </div>
                        )}
                    </div>

                    {/* Right Side: Booking Card */}
                    <div className="lg:col-span-1">
                        <div className="sticky top-8 bg-white border border-blue-50 rounded-[40px] p-8 shadow-2xl shadow-blue-900/5">
                            <div className="flex justify-between items-start mb-8">
                                <div>
                                    <p className="text-[10px] font-black text-gray-400 uppercase mb-1 tracking-widest">Base Price</p>
                                    <div className="flex items-baseline gap-1">
                                        <span className="text-4xl font-black text-slate-900">${pricePerNight}</span>
                                        <span className="text-gray-400 text-sm font-bold">{priceLabel}</span>
                                    </div>
                                </div>
                                <div className="bg-green-50 text-green-600 px-4 py-1.5 rounded-full text-[10px] font-black border border-green-100">
                                    {property?.status || "Available"}
                                </div>
                            </div>

                            <div className="grid grid-cols-2 gap-3 mb-4">
                                <DateInput
                                    label="Check-in"
                                    value={checkIn}
                                    min={getFormattedDate(0)}
                                    onChange={(e) => setCheckIn(e.target.value)}
                                />
                                <DateInput
                                    label="Check-out"
                                    value={checkOut}
                                    min={checkIn}
                                    onChange={(e) => setCheckOut(e.target.value)}
                                />
                            </div>

                            {isDateInvalid && (
                                <div className="mb-4 p-4 bg-red-50 border border-red-100 rounded-2xl flex items-center gap-2 text-red-600 text-xs font-bold transition-all">
                                    <AlertTriangle size={16} />
                                    <span>Sorry, this period is already booked! Please select different dates.</span>
                                </div>
                            )}

                            <div className="mb-8">
                                <label className="text-[10px] font-black text-slate-400 uppercase mb-3 block tracking-widest text-center">Select Parking Zone</label>
                                <div className="flex gap-2">
                                    {['A', 'B', 'C'].map((zone) => (
                                        <button
                                            key={zone}
                                            disabled={isParkingEnabled || isSubmitting || isDateInvalid}
                                            onClick={() => setSelectedZone(zone)}
                                            className={`flex-1 py-4 rounded-2xl text-[11px] font-black transition-all ${selectedZone === zone ? 'bg-blue-600 text-white shadow-lg' : 'bg-white text-gray-400 border border-gray-100 hover:border-blue-200 disabled:opacity-50'}`}
                                        >
                                            Zone {zone} <span className="block text-[8px] opacity-60">${zonePrices[zone]}</span>
                                        </button>
                                    ))}
                                </div>
                            </div>

                            {/* RealPark Switch */}
                            <div className={`p-5 rounded-[25px] border-2 transition-all mb-8 flex justify-between items-center ${isParkingEnabled ? 'bg-blue-600 border-blue-500' : 'bg-blue-50/30 border-blue-100/50'} ${isDateInvalid ? 'opacity-40 pointer-events-none' : ''}`}>
                                <div className="flex items-center gap-3 text-left">
                                    <div className={`p-3 rounded-2xl ${isParkingEnabled ? 'bg-blue-500 text-white' : 'bg-white text-blue-600'}`}>
                                        <Car size={22} />
                                    </div>
                                    <div>
                                        <p className={`text-[9px] font-black uppercase ${isParkingEnabled ? 'text-blue-100' : 'text-blue-600'}`}>RealPark Active</p>
                                        <p className={`font-bold text-sm ${isParkingEnabled ? 'text-white' : 'text-slate-800'}`}>
                                            {isParkingEnabled ? `Spot: ${reservedSpot?.spotNumber}` : 'Enable Smart Parking'}
                                        </p>
                                    </div>
                                </div>
                                <button
                                    onClick={handleToggleParking}
                                    disabled={isSubmitting || isDateInvalid}
                                    className={`w-14 h-7 rounded-full relative transition-all duration-300 ${isParkingEnabled ? 'bg-white/20' : 'bg-gray-200'}`}
                                >
                                    <div className={`absolute w-5 h-5 rounded-full top-1 transition-all duration-300 flex items-center justify-center shadow-md ${isParkingEnabled ? 'right-1 bg-white' : 'left-1 bg-white'}`}>
                                        {isSubmitting && <Loader2 size={12} className="animate-spin text-blue-600" />}
                                    </div>
                                </button>
                            </div>

                            {/* Price Summary */}
                            <div className="space-y-4 mb-8 bg-slate-50/50 p-6 rounded-3xl border border-dashed border-slate-200">
                                <div className="flex justify-between text-xs font-bold text-slate-500">
                                    <span>Stay ({nights} {stayLabel})</span><span>${villaBasePrice.toLocaleString()}</span>
                                </div>
                                {isParkingEnabled && (
                                    <div className="flex justify-between text-xs font-bold text-blue-600">
                                        <span>Parking Fee (Zone {selectedZone})</span><span>+ ${parkingPrice.toLocaleString()}</span>
                                    </div>
                                )}
                                <div className="flex justify-between text-xs font-bold text-slate-500">
                                    <span>Service Fee</span><span>${serviceFee}</span>
                                </div>
                                <div className="flex justify-between text-xl font-black text-slate-900 pt-4 border-t border-slate-200">
                                    <span>Total</span><span>${totalPrice.toLocaleString()}</span>
                                </div>
                            </div>

                            {/* Main CTA Button */}
                            <button
                                onClick={handleBooking}
                                disabled={nights <= 0 || isSubmitting || isBooking || isDateInvalid}
                                className={`w-full py-5 rounded-[22px] font-black text-lg transition-all active:scale-95 flex items-center justify-center gap-3 ${nights > 0 && !isSubmitting && !isBooking && !isDateInvalid ? 'bg-slate-900 text-white hover:bg-blue-700 shadow-2xl shadow-blue-200' : 'bg-gray-100 text-gray-400 cursor-not-allowed'}`}
                            >
                                {isBooking ? (
                                    <>
                                        <Loader2 className="animate-spin" size={20} />
                                        <span>Processing...</span>
                                    </>
                                ) : (
                                    'Confirm and Pay'
                                )}
                            </button>
                        </div>
                    </div>
                </div>
            </main>

            {/* Purchase Confirmation Modal */}
            {showPurchaseModal && (
                <div className="fixed inset-0 bg-black/50 backdrop-blur-sm flex items-center justify-center z-50 p-4">
                    <div className="bg-white rounded-[32px] p-8 max-w-md w-full shadow-2xl">
                        <div className="text-center mb-6">
                            <div className="w-16 h-16 bg-green-100 rounded-full flex items-center justify-center mx-auto mb-4">
                                <ShoppingBag className="text-green-600" size={32} />
                            </div>
                            <h2 className="text-2xl font-black text-slate-900 mb-2">Confirm Purchase</h2>
                            <p className="text-slate-500 text-sm">You are about to purchase this property</p>
                        </div>

                        <div className="bg-slate-50 rounded-2xl p-4 mb-6">
                            <div className="flex items-center gap-4">
                                <img
                                    src={property?.imageUrl || "https://images.unsplash.com/photo-1613490493576-7fde63acd811"}
                                    alt={property?.name}
                                    className="w-20 h-20 rounded-xl object-cover"
                                />
                                <div>
                                    <h3 className="font-bold text-slate-900">{property?.name}</h3>
                                    <p className="text-sm text-slate-500 flex items-center gap-1">
                                        <MapPin size={12} /> {property?.location}
                                    </p>
                                </div>
                            </div>
                        </div>

                        <div className="border-t border-slate-100 pt-4 mb-6">
                            <div className="flex justify-between items-center">
                                <span className="text-slate-500 font-medium">Total Price</span>
                                <span className="text-2xl font-black text-green-600">
                                    ${(property?.salePrice || property?.price || 0).toLocaleString()}
                                </span>
                            </div>
                        </div>

                        <div className="flex gap-3">
                            <button
                                onClick={() => setShowPurchaseModal(false)}
                                disabled={isPurchasing}
                                className="flex-1 py-4 rounded-2xl font-bold text-slate-600 bg-slate-100 hover:bg-slate-200 transition-all"
                            >
                                Cancel
                            </button>
                            <button
                                onClick={handlePurchase}
                                disabled={isPurchasing}
                                className="flex-1 py-4 rounded-2xl font-bold text-white bg-green-600 hover:bg-green-700 transition-all flex items-center justify-center gap-2 disabled:bg-slate-300"
                            >
                                {isPurchasing ? (
                                    <>
                                        <Loader2 className="animate-spin" size={20} />
                                        Processing...
                                    </>
                                ) : (
                                    <>
                                        <CreditCard size={20} />
                                        Confirm Purchase
                                    </>
                                )}
                            </button>
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
};

const FeatureItem = ({ icon, label, highlight = false }) => (
    <div className={`flex flex-col items-center gap-3 p-6 rounded-[32px] border-2 transition-all cursor-default ${highlight ? 'bg-blue-600 border-blue-500 shadow-2xl scale-105' : 'bg-white border-gray-50 hover:border-blue-100'}`}>
        <div className={`p-3.5 rounded-[20px] ${highlight ? 'text-white bg-blue-500' : 'text-blue-600 bg-blue-50'}`}>
            {React.cloneElement(icon, { size: 26, strokeWidth: 2.5 })}
        </div>
        <span className={`text-[10px] font-black uppercase ${highlight ? 'text-white' : 'text-slate-500'}`}>{label}</span>
    </div>
);

const DateInput = ({ label, value, min, onChange }) => (
    <div className="p-4 bg-gray-50/50 rounded-2xl border border-gray-100 focus-within:border-blue-300 focus-within:bg-white transition-all">
        <label className="text-[9px] font-black text-gray-400 uppercase block mb-1">{label}</label>
        <input type="date" value={value} min={min} onChange={onChange} className="bg-transparent text-xs font-black w-full outline-none text-slate-700" />
    </div>
);

export default PropertyDetails;