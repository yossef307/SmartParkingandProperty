import React, { useState, useEffect } from 'react';
import { QrCode, XCircle, CheckCircle2, Loader2, Info } from 'lucide-react';
import parkingService from '../services/parkingService';

/**
 * Parking Reservation Management Component - RealPark System
 * Modified for full compatibility with SQL Server data types
 */
const ParkingReservations = () => {
    const [spots, setSpots] = useState([]);
    const [selectedSpot, setSelectedSpot] = useState(null);
    const [loading, setLoading] = useState(true);
    const [actionLoading, setActionLoading] = useState(false);

    // Default testing values - Ensure these IDs exist in your database
    const DEFAULT_USER_ID = 1;
    const DEFAULT_PROPERTY_ID = 1;
    const DEFAULT_USER_EMAIL = "testuser@realpark.com";

    // Fetch data from server
    const loadData = async () => {
        try {
            const data = await parkingService.getParkingSpots();

            // Process and sort data logically (A1, A2, B1...)
            const formatted = data.sort((a, b) =>
                a.spotNumber.localeCompare(b.spotNumber, undefined, { numeric: true })
            ).map(s => ({
                id: s.id,
                name: s.spotNumber,
                // Infer zone from first character if not present
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

    // Handle reservation confirmation
    const handleConfirm = async () => {
        if (!selectedSpot || !selectedSpot.id) {
            alert("Error: Parking spot not correctly selected");
            return;
        }

        setActionLoading(true);
        try {
            // Format date to be server-compatible (no extra milliseconds)
            const now = new Date();
            const startTime = now.toISOString().split('.')[0] + "Z";
            const endTime = new Date(now.getTime() + (60 * 60 * 1000)).toISOString().split('.')[0] + "Z";

            // Build request payload with numeric conversions
            const payload = {
                parkingSpotId: Number(selectedSpot.id),
                propertyId: Number(selectedSpot.propertyId || DEFAULT_PROPERTY_ID),
                userId: Number(DEFAULT_USER_ID),
                userEmail: DEFAULT_USER_EMAIL,
                startDate: startTime,
                endDate: endTime,
                totalPrice: Number(selectedSpot.price) || 0
            };

            console.log("Sending reservation request:", payload);

            await parkingService.confirmReservation(payload);

            alert(`✅ Reservation for spot ${selectedSpot.name} confirmed successfully`);
            setSelectedSpot(null);
            await loadData(); // Immediate map update

        } catch (error) {
            console.error("API Error:", error.response?.data);

            const serverError = error.response?.data;
            // Extract detailed error message from Validation or Exception
            const detailedMsg = serverError?.errors
                ? Object.values(serverError.errors).flat().join(" | ")
                : (serverError?.message || serverError?.title || "Failed to connect to server");

            alert(`❌ Reservation Failed:\n${detailedMsg}`);
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
            await loadData();
        } catch (e) {
            const errorMsg = e.response?.data?.message || "Cancellation failed. The reservation may already have expired.";
            alert(`❌ ${errorMsg}`);
        } finally {
            setActionLoading(false);
        }
    };

    // Helper to determine status styles
    const getStatusStyles = (status) => {
        const isAvailable = status?.toLowerCase() === 'available';
        return {
            text: isAvailable ? 'text-green-600' : 'text-blue-600',
            bg: isAvailable ? 'bg-green-50' : 'bg-blue-50',
            label: isAvailable ? 'Available' : 'Currently Reserved'
        };
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

                    {/* Display Zones A, B, C */}
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
                                                onClick={() => setSelectedSpot(spot)}
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

                {/* Left Section: Control Panel */}
                <div className="w-full lg:w-[380px]">
                    {selectedSpot ? (
                        <div className="bg-white p-8 rounded-[40px] border border-slate-100 shadow-2xl sticky top-8 animate-in fade-in slide-in-from-bottom-4">
                            <div className="flex items-center gap-3 mb-6">
                                <div className="p-3 bg-blue-50 text-blue-600 rounded-2xl">
                                    <span className="text-blue-600"><Info size={24} /></span>
                                </div>
                                <h3 className="text-2xl font-black">Spot Details</h3>
                            </div>

                            <div className="space-y-4 mb-8 p-6 bg-slate-50 rounded-[30px]">
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
                                    <span className="text-slate-400 font-bold">Price</span>
                                    <span className="font-black text-slate-800">${selectedSpot.price}/hr</span>
                                </div>
                            </div>

                            {selectedSpot.status?.toLowerCase() === 'available' ? (
                                <button
                                    onClick={handleConfirm}
                                    disabled={actionLoading}
                                    className="w-full bg-blue-600 text-white py-5 rounded-[24px] font-black flex items-center justify-center gap-2 hover:bg-blue-700 transition-all shadow-xl shadow-blue-200 disabled:bg-slate-300 disabled:shadow-none"
                                >
                                    {actionLoading ? <Loader2 className="animate-spin" /> : <CheckCircle2 size={22} />}
                                    Confirm Entry
                                </button>
                            ) : (
                                <button
                                    onClick={handleCancel}
                                    disabled={actionLoading}
                                    className="w-full bg-red-50 text-red-600 py-5 rounded-[24px] font-black flex items-center justify-center gap-2 hover:bg-red-100 transition-all disabled:opacity-50"
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
                                <QrCode size={150} className="text-slate-900" />
                            </div>
                            <h3 className="font-black text-xl mb-3">Smart Entry Gate</h3>
                            <p className="text-slate-400 text-sm font-medium leading-relaxed mb-6">
                                Please select an available spot from the map to generate your entry QR code and confirm your reservation.
                            </p>
                            <div className="flex gap-2 justify-center">
                                <div className="w-2 h-2 rounded-full bg-blue-500 animate-pulse"></div>
                                <div className="w-2 h-2 rounded-full bg-blue-500 animate-pulse delay-75"></div>
                                <div className="w-2 h-2 rounded-full bg-blue-500 animate-pulse delay-150"></div>
                            </div>
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default ParkingReservations;