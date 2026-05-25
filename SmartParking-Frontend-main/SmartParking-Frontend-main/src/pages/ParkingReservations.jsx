import React, { useState, useEffect } from 'react';
import { XCircle, CheckCircle2, Loader2, Info, Clock, DollarSign } from 'lucide-react';
import { QRCodeSVG } from 'qrcode.react';
import parkingService from '../services/parkingService';

/**
 * Parking Reservation Management Component - RealPark System
 * Features: Dynamic QR Code & Custom Reservation Duration with Live Price Calculation
 * Fully Fixed Build/Syntax Error
 */
const ParkingReservations = () => {
    const [spots, setSpots] = useState([]);
    const [selectedSpot, setSelectedSpot] = useState(null);
    const [loading, setLoading] = useState(true);
    const [actionLoading, setActionLoading] = useState(false);
    const [confirmedBooking, setConfirmedBooking] = useState(null);

    // Control reservation hours duration (Default: 1 Hour)
    const [reservationHours, setReservationHours] = useState(1);

    // Default testing values
    const DEFAULT_USER_ID = 1;
    const DEFAULT_PROPERTY_ID = 1;

    // Fetch data from server
    const loadData = async () => {
        try {
            const data = await parkingService.getParkingSpots();

            const formatted = data.sort((a, b) =>
                a.spotNumber.localeCompare(b.spotNumber, undefined, { numeric: true })
            ).map(s => ({
                id: s.id,
                name: s.spotNumber,
                zone: s.zone || (s.spotNumber.match(/^[A-Z]/i) ? s.spotNumber[0].toUpperCase() : 'A'),
                price: s.pricePerHour || 0,
                status: s.status,
                propertyId: s.propertyId
            }));

            setSpots(formatted);
        } catch (error) {
            console.error("Data loading error:", error);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        loadData();
    }, []);

    // Live calculation of total price based on selected hours
    const calculatedTotalPrice = selectedSpot ? (Number(selectedSpot.price) * reservationHours) : 0;

    // Handle reservation confirmation
    const handleConfirm = async () => {
        if (!selectedSpot || !selectedSpot.id) {
            alert("Error: Parking spot not correctly selected");
            return;
        }

        setActionLoading(true);

        const now = new Date();
        const startTime = now.toISOString().split('.')[0] + "Z";

        // Dynamic dynamic calculation of endTime based on chosen duration
        const endDateTime = new Date(now.getTime() + (reservationHours * 60 * 60 * 1000));
        const endTime = endDateTime.toISOString().split('.')[0] + "Z";

        const localTicketId = Math.floor(100000 + Math.random() * 900000);

        // Prep the local simulation display ticket first
        setConfirmedBooking({
            spotName: selectedSpot.name,
            userId: DEFAULT_USER_ID,
            bookingTime: startTime,
            duration: reservationHours,
            totalPaid: calculatedTotalPrice,
            reservationId: localTicketId
        });

        try {
            // Precise formatting of payload variables
            const payload = {
                parkingSpotId: Number(selectedSpot.id),
                propertyId: Number(selectedSpot.propertyId || DEFAULT_PROPERTY_ID),
                userId: Number(DEFAULT_USER_ID),
                startDate: startTime,
                endDate: endTime,
                totalPrice: Number(calculatedTotalPrice)
            };

            console.log("Sending dynamic reservation payload:", payload);

            const responseData = await parkingService.confirmReservation(payload);

            if (responseData?.id) {
                setConfirmedBooking(prev => ({ ...prev, reservationId: responseData.id }));
            }

            alert(`✅ Reservation for spot ${selectedSpot.name} for (${reservationHours} Hours) confirmed successfully!`);
            setSelectedSpot(null);
            await loadData();

        } catch (error) {
            console.error("API Error:", error.response?.data);
            alert(`⚠️ UI Simulated Mode:\nSaves locally for presentation, but API connection failed.`);
            setSelectedSpot(null);
        } finally {
            setActionLoading(false);
        }
    };

    // Handle reservation cancellation
    const handleCancel = async () => {
        if (!selectedSpot) return;

        if (!window.confirm(`Are you sure you want to cancel the reservation for ${selectedSpot.name}?`)) return;

        setActionLoading(true);
        try {
            await parkingService.cancelReservation(selectedSpot.id);
            alert(`✅ Reservation for ${selectedSpot.name} has been cancelled`);
            setSelectedSpot(null);
            setConfirmedBooking(null);
            await loadData();
        } catch (e) {
            const errorMsg = e.response?.data?.message || "Cancellation failed.";
            alert(`❌ ${errorMsg}`);
        } finally {
            setActionLoading(false);
        }
    };

    const getStatusStyles = (status) => {
        const isAvailable = status?.toLowerCase() === 'available';
        return {
            text: isAvailable ? 'text-green-600' : 'text-blue-600',
            bg: isAvailable ? 'bg-green-50' : 'bg-blue-50',
            label: isAvailable ? 'Available' : 'Currently Reserved'
        };
    };

    const handleSpotSelection = (spot) => {
        setConfirmedBooking(null);
        setReservationHours(1); // Reset duration back to 1 hour on switching slots
        setSelectedSpot(spot);
    };

    if (loading && spots.length === 0) return (
        <div className="min-h-screen flex flex-col items-center justify-center bg-white">
            <Loader2 className="animate-spin text-blue-600 mb-4" size={48} />
            <p className="font-black text-slate-600">Synchronizing RealPark data...</p>
        </div>
    );

    return (
        <div className="min-h-screen bg-slate-50 p-4 md:p-8 font-sans text-left" dir="ltr">
            <div className="max-w-[1400px] mx-auto flex flex-col lg:flex-row gap-8">

                {/* Right Section: Garage Map */}
                <div className="flex-1 bg-white p-6 md:p-10 rounded-[40px] shadow-sm border border-slate-100">
                    <div className="mb-10 flex justify-between items-end">
                        <div>
                            <h2 className="text-3xl font-black text-slate-800">Live Garage Map</h2>
                            <p className="text-slate-400 font-bold mt-1">Smart Parking Management</p>
                        </div>
                        <div className="text-right">
                            <span className="text-2xl font-black text-blue-600">
                                {spots.filter(s => s.status?.toLowerCase() !== 'available').length}
                            </span>
                            <span className="text-slate-400 font-bold"> / {spots.length} Occupied</span>
                        </div>
                    </div>

                    {['A', 'B', 'C'].map(zoneLetter => {
                        const zoneSpots = spots.filter(s => s.zone === zoneLetter);
                        if (zoneSpots.length === 0) return null;

                        return (
                            <div key={zoneLetter} className="mb-12">
                                <h3 className="text-sm font-black text-slate-400 mb-5 uppercase tracking-widest border-l-4 border-blue-600 pl-3">
                                    Zone {zoneLetter}
                                </h3>
                                <div className="grid grid-cols-4 sm:grid-cols-6 md:grid-cols-8 lg:grid-cols-10 gap-3">
                                    {zoneSpots.map(spot => {
                                        const isOccupied = spot.status?.toLowerCase() !== 'available';
                                        const isSelected = selectedSpot?.id === spot.id;

                                        return (
                                            <button
                                                key={spot.id}
                                                onClick={() => handleSpotSelection(spot)}
                                                className={`h-14 rounded-2xl border-2 flex items-center justify-center transition-all font-black text-xs
                                                    ${isOccupied
                                                        ? 'bg-blue-600 border-blue-600 text-white shadow-md cursor-default opacity-90'
                                                        : isSelected
                                                            ? 'border-blue-600 bg-blue-50 text-blue-600 scale-105 shadow-inner'
                                                            : 'bg-white border-slate-100 text-blue-600 hover:border-blue-300 hover:bg-slate-50'}`}
                                            >
                                                {spot.name}
                                            </button>
                                        );
                                    })}
                                </div>
                            </div>
                        );
                    })}
                </div>

                {/* Left Section: Control Panel & Smart QR Card */}
                <div className="w-full lg:w-[380px]">
                    {selectedSpot ? (
                        <div className="bg-white p-8 rounded-[40px] border border-slate-100 shadow-2xl sticky top-8 animate-in fade-in slide-in-from-bottom-4">
                            <div className="flex items-center gap-3 mb-6">
                                <div className="p-3 bg-blue-50 text-blue-600 rounded-2xl">
                                    <span className="text-blue-600"><Info size={24} /></span>
                                </div>
                                <h3 className="text-2xl font-black">Spot Details</h3>
                            </div>

                            <div className="space-y-4 mb-6 p-6 bg-slate-50 rounded-[30px]">
                                <div className="flex justify-between items-center">
                                    <span className="text-slate-400 font-bold">Spot Number</span>
                                    <span className="font-black text-lg">{selectedSpot.name}</span>
                                </div>
                                <div className="flex justify-between items-center border-t border-slate-200 pt-4">
                                    <span className="text-slate-400 font-bold">Status</span>
                                    <span className={`font-black ${getStatusStyles(selectedSpot.status).text}`}>
                                        {getStatusStyles(selectedSpot.status).label}
                                    </span>
                                </div>
                                <div className="flex justify-between items-center border-t border-slate-200 pt-4">
                                    <span className="text-slate-400 font-bold">Rate</span>
                                    <span className="font-black text-slate-800">${selectedSpot.price}/hr</span>
                                </div>
                            </div>

                            {/* Dropdown Input layout for Duration selection */}
                            {selectedSpot.status?.toLowerCase() === 'available' && (
                                <div className="mb-6 space-y-4 border border-slate-100 p-5 rounded-[26px] bg-white shadow-sm">
                                    <div className="flex items-center justify-between">
                                        <label className="text-slate-500 font-black text-sm flex items-center gap-1.5">
                                            <Clock size={16} className="text-blue-500" /> Duration:
                                        </label>
                                        <select
                                            value={reservationHours}
                                            onChange={(e) => setReservationHours(Number(e.target.value))}
                                            className="bg-slate-50 border border-slate-200 text-slate-800 font-black rounded-xl p-2.5 focus:outline-none focus:border-blue-500 text-sm cursor-pointer"
                                        >
                                            {[...Array(24)].map((_, i) => (
                                                <option key={i + 1} value={i + 1}>{i + 1} {i === 0 ? 'Hour' : 'Hours'}</option>
                                            ))}
                                        </select>
                                    </div>

                                    <div className="flex items-center justify-between border-t border-dashed border-slate-200 pt-3">
                                        <span className="text-slate-500 font-black text-sm flex items-center gap-1.5">
                                            <DollarSign size={16} className="text-emerald-500" /> Total Price:
                                        </span>
                                        <span className="text-xl font-black text-emerald-600">
                                            ${calculatedTotalPrice}
                                        </span>
                                    </div>
                                </div>
                            )}

                            {selectedSpot.status?.toLowerCase() === 'available' ? (
                                <button
                                    onClick={handleConfirm}
                                    disabled={actionLoading}
                                    className="w-full bg-blue-600 text-white py-5 rounded-[24px] font-black flex items-center justify-center gap-2 hover:bg-blue-700 transition-all shadow-xl shadow-blue-200 disabled:bg-slate-300"
                                >
                                    {actionLoading ? <Loader2 className="animate-spin" /> : <CheckCircle2 size={22} />}
                                    Confirm Entry
                                </button>
                            ) : (
                                <button
                                    onClick={handleCancel}
                                    disabled={actionLoading}
                                    className="w-full bg-red-50 text-red-600 py-5 rounded-[24px] font-black flex items-center justify-center gap-2 hover:bg-red-100 transition-all"
                                >
                                    {actionLoading ? <Loader2 className="animate-spin" /> : <XCircle size={22} />}
                                    Cancel Reservation
                                </button>
                            )}

                            <button
                                onClick={() => setSelectedSpot(null)}
                                className="w-full mt-4 text-slate-400 font-bold py-2 hover:text-slate-600 transition-colors"
                            >
                                Go Back
                            </button>
                        </div>
                    ) : (
                        <div className="bg-slate-900 p-10 rounded-[40px] text-white text-center sticky top-8 shadow-2xl">

                            <div className="bg-white p-6 rounded-[35px] inline-block mb-8 shadow-inner">
                                {confirmedBooking ? (
                                    <QRCodeSVG
                                        value={JSON.stringify({
                                            system: "RealPark-Gate",
                                            ticketId: confirmedBooking.reservationId,
                                            spot: confirmedBooking.spotName,
                                            user: confirmedBooking.userId,
                                            durationHours: confirmedBooking.duration,
                                            totalPaidAmount: `${confirmedBooking.totalPaid}$`,
                                            issuedAt: confirmedBooking.bookingTime
                                        })}
                                        size={150}
                                        level={"H"}
                                        includeMargin={false}
                                    />
                                ) : (
                                    <QRCodeSVG value="Please select a spot first" size={150} fgColor="#cbd5e1" />
                                )}
                            </div>

                            <h3 className="font-black text-xl mb-3">
                                {confirmedBooking ? `Ticket Verified: ${confirmedBooking.spotName}` : "Smart Entry Gate"}
                            </h3>
                            <p className="text-slate-400 text-sm font-medium leading-relaxed mb-6 px-2">
                                {confirmedBooking
                                    ? `Scan code at entry barrier. Booked for ${confirmedBooking.duration} hours (Paid: $${confirmedBooking.totalPaid}).`
                                    : "Please select an available spot from the map to generate your entry QR code and confirm your reservation."
                                }
                            </p>

                            {confirmedBooking ? (
                                <div className="bg-blue-600/20 text-blue-400 text-xs font-black py-2 px-4 rounded-xl inline-block border border-blue-500/30">
                                    Ticket: #{confirmedBooking.reservationId}
                                </div>
                            ) : (
                                <div className="flex gap-2 justify-center">
                                    <div className="w-2 h-2 rounded-full bg-blue-500 animate-pulse"></div>
                                    <div className="w-2 h-2 rounded-full bg-blue-500 animate-pulse delay-75"></div>
                                    <div className="w-2 h-2 rounded-full bg-blue-500 animate-pulse delay-150"></div>
                                </div>
                            )}
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default ParkingReservations;