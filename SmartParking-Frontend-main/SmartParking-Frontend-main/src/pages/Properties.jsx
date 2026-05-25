import React, { useState, useEffect, useMemo } from 'react';
import { Link } from 'react-router-dom';
import { Search, MapPin, Star, Heart, ChevronDown, Loader2, AlertCircle, ArrowRight } from 'lucide-react';
import axios from 'axios';

const Properties = () => {
    const [propertyType, setPropertyType] = useState('All');
    const [priceRange, setPriceRange] = useState('Any Price');
    const [searchQuery, setSearchQuery] = useState('');
    const [properties, setProperties] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    // 1. جلب البيانات من الـ API
    useEffect(() => {
        const controller = new AbortController();
        const fetchProperties = async () => {
            try {
                setLoading(true);
                const response = await axios.get('https://localhost:7144/api/Properties', {
                    signal: controller.signal
                });

                const data = Array.isArray(response.data) ? response.data : [];
                setProperties(data);

                // سطر لمساعدتك في التتبع من خلال الـ Console
                console.log("Fetched Properties:", data);

                setError(null);
            } catch (err) {
                if (axios.isCancel(err)) return;
                console.error("Fetch Error:", err);
                setError(err.response?.data?.message || err.message);
            } finally {
                setLoading(false);
            }
        };

        fetchProperties();
        return () => controller.abort();
    }, []);

    // 2. منطق الفلترة المطور (حل مشكلة اختفاء البيانات)
    const filteredData = useMemo(() => {
        return properties.filter(item => {
            // تجهيز البيانات الأساسية (تأمين الـ Null ومسح المسافات)
            const name = (item.Name || item.name || "").toLowerCase().trim();
            const location = (item.Location || item.location || "").toLowerCase().trim();
            const price = item.PricePerHour || item.pricePerHour || 0;
            const typeFromApi = (item.Type || item.type || "").toLowerCase().trim();
            const selectedType = propertyType.toLowerCase().trim();

            // فلترة النوع: جعلناها مرنة لتقبل (الجمع، المفرد، أو مسافات إضافية)
            const matchesType = propertyType === 'All' ||
                typeFromApi.includes(selectedType) ||
                selectedType.includes(typeFromApi);

            // فلترة البحث
            const matchesSearch = name.includes(searchQuery.toLowerCase().trim()) ||
                location.includes(searchQuery.toLowerCase().trim());

            // فلترة السعر
            let matchesPrice = true;
            if (priceRange === 'Under $1000') matchesPrice = price < 1000;
            else if (priceRange === '$1000 - $2000') matchesPrice = price >= 1000 && price <= 2000;
            else if (priceRange === 'Above $2000') matchesPrice = price > 2000;

            return matchesType && matchesSearch && matchesPrice;
        });
    }, [properties, propertyType, searchQuery, priceRange]);

    if (loading) return (
        <div className="flex flex-col items-center justify-center min-h-screen text-blue-600 bg-white">
            <Loader2 className="animate-spin mb-4" size={50} strokeWidth={2.5} />
            <p className="font-bold text-xl animate-pulse text-slate-700">Loading Luxury Spaces...</p>
        </div>
    );

    if (error) return (
        <div className="flex flex-col items-center justify-center min-h-screen p-6 bg-[#FFF8F8]">
            <div className="bg-white p-10 rounded-[40px] shadow-2xl border border-red-100 max-w-lg text-center">
                <AlertCircle size={80} className="mb-6 mx-auto text-red-400" />
                <h2 className="text-3xl font-black mb-4 text-slate-800">Connection Issue</h2>
                <p className="text-slate-500 mb-8 leading-relaxed font-medium">
                    Please ensure your <b>ASP.NET Core</b> backend is running on <b>port 7144</b>.
                </p>
                <button
                    onClick={() => window.location.reload()}
                    className="bg-red-500 text-white px-10 py-4 rounded-2xl font-bold hover:bg-red-600 transition-all shadow-lg active:scale-95"
                >
                    Try Again
                </button>
            </div>
        </div>
    );

    return (
        <div className="min-h-screen bg-[#F8FAFC]">
            <main className="max-w-[1440px] mx-auto px-12 py-12">
                <div className="mb-12">
                    <h2 className="text-4xl font-black text-slate-900 tracking-tight mb-2 uppercase">Properties List</h2>
                    <p className="text-slate-500 font-medium italic">Found {filteredData.length} properties matching your criteria.</p>
                </div>

                {/* Filters Section */}
                <div className="bg-white p-5 rounded-[35px] shadow-2xl shadow-slate-200/50 border border-slate-100 flex flex-wrap gap-5 items-center mb-16">
                    <div className="flex-1 min-w-[300px] relative">
                        <Search className="absolute left-5 top-1/2 -translate-y-1/2 text-slate-400" size={22} />
                        <input
                            type="text"
                            placeholder="Search by name or location..."
                            value={searchQuery}
                            onChange={(e) => setSearchQuery(e.target.value)}
                            className="w-full pl-14 pr-6 py-5 bg-slate-50 rounded-[25px] border-none focus:ring-2 focus:ring-blue-500 outline-none font-semibold text-slate-700 placeholder:text-slate-400"
                        />
                    </div>

                    <div className="flex gap-4">
                        <DropdownFilter
                            label="Property Type"
                            value={propertyType}
                            options={['All', 'Villa', 'Apartment']}
                            onChange={setPropertyType}
                        />
                        <DropdownFilter
                            label="Your Budget"
                            value={priceRange}
                            options={['Any Price', 'Under $1000', '$1000 - $2000', 'Above $2000']}
                            onChange={setPriceRange}
                        />
                    </div>
                </div>

                {/* Properties Grid */}
                {filteredData.length === 0 ? (
                    <div className="text-center py-32 bg-white rounded-[50px] border-2 border-dashed border-slate-200">
                        <Search size={48} className="text-slate-200 mx-auto mb-4" />
                        <h3 className="text-2xl font-black text-slate-800">No properties found.</h3>
                        <p className="text-slate-400 font-medium">Try adjusting your filters to find what you're looking for.</p>
                    </div>
                ) : (
                    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-12">
                        {filteredData.map((item) => (
                            <PropertyCard
                                key={item.Id || item.id}
                                id={item.Id || item.id}
                                image={item.ImageUrl || item.imageUrl}
                                title={item.Name || item.name}
                                location={item.Location || item.location}
                                price={item.PricePerHour || item.pricePerHour}
                                rating="4.9"
                            />
                        ))}
                    </div>
                )}
            </main>
        </div>
    );
};

// --- المكونات الفرعية (Sub-Components) ---

const DropdownFilter = ({ label, value, options, onChange }) => {
    const [isOpen, setIsOpen] = useState(false);
    return (
        <div className="relative">
            <button
                onClick={() => setIsOpen(!isOpen)}
                className={`px-6 py-4 rounded-[22px] border transition-all min-w-[170px] flex justify-between items-center ${isOpen ? 'bg-white border-blue-500 shadow-lg' : 'bg-slate-50 border-slate-100'}`}
            >
                <div className="text-left">
                    <p className="text-[9px] font-black text-slate-400 uppercase mb-1">{label}</p>
                    <p className="font-bold text-slate-800 text-sm">{value}</p>
                </div>
                <ChevronDown size={16} className={`transition-transform text-slate-400 ${isOpen ? 'rotate-180' : ''}`} />
            </button>
            {isOpen && (
                <>
                    <div className="fixed inset-0 z-40" onClick={() => setIsOpen(false)}></div>
                    <div className="absolute top-full mt-2 left-0 w-full bg-white border border-slate-100 rounded-2xl shadow-2xl z-50 overflow-hidden animate-in fade-in slide-in-from-top-2 duration-200">
                        {options.map((opt) => (
                            <div
                                key={opt}
                                onClick={() => { onChange(opt); setIsOpen(false); }}
                                className={`px-6 py-3 text-sm font-bold cursor-pointer transition-colors ${value === opt ? 'text-blue-600 bg-blue-50' : 'text-slate-600 hover:bg-slate-50'}`}
                            >
                                {opt}
                            </div>
                        ))}
                    </div>
                </>
            )}
        </div>
    );
};

const PropertyCard = ({ id, image, title, location, price, rating }) => {
    const [isLoved, setIsLoved] = useState(false);

    const formattedPrice = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        maximumFractionDigits: 0
    }).format(price || 0);

    return (
        <div className="group bg-white rounded-[40px] border border-slate-100 overflow-hidden hover:shadow-2xl hover:-translate-y-2 transition-all duration-500">
            <div className="relative h-64 overflow-hidden">
                <img
                    src={image || 'https://images.unsplash.com/photo-1512917774080-9991f1c4c750?w=800'}
                    alt={title}
                    className="w-full h-full object-cover group-hover:scale-110 transition-transform duration-700"
                />
                <button
                    onClick={(e) => { e.preventDefault(); setIsLoved(!isLoved); }}
                    className={`absolute top-5 right-5 p-3 rounded-xl backdrop-blur-md transition-all active:scale-90 ${isLoved ? 'bg-red-500 text-white' : 'bg-white/80 text-slate-600'}`}
                >
                    <Heart size={18} className={isLoved ? 'fill-current' : ''} />
                </button>
            </div>
            <div className="p-7">
                <div className="flex justify-between items-start mb-2">
                    <h3 className="font-bold text-xl text-slate-800 line-clamp-1">{title}</h3>
                    <div className="flex items-center gap-1 bg-amber-50 px-2 py-1 rounded-lg text-amber-600 text-xs font-bold shrink-0">
                        <Star size={12} className="fill-current" /> {rating}
                    </div>
                </div>
                <p className="flex items-center gap-2 text-slate-400 text-sm mb-6 font-medium">
                    <MapPin size={14} className="text-blue-500" /> {location}
                </p>
                <div className="flex justify-between items-center pt-5 border-t border-slate-50">
                    <div>
                        <span className="text-2xl font-black text-slate-900">{formattedPrice}</span>
                    </div>
                    <Link to={`/property/${id}`} className="bg-slate-900 text-white p-3 rounded-xl hover:bg-blue-600 transition-all active:scale-95 shadow-lg">
                        <ArrowRight size={20} />
                    </Link>
                </div>
            </div>
        </div>
    );
};

export default Properties;