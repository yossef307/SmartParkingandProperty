import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import axios from 'axios';
import { faker } from '@faker-js/faker'; // تأكد من تثبيت المكتبة: npm install @faker-js/faker
import {
    Building2, MapPin, DollarSign, Image as ImageIcon,
    ArrowLeft, Plus, CheckCircle2, Loader2, Info, Layout, Sparkles
} from 'lucide-react';

const AdminAddProperty = () => {
    const navigate = useNavigate();
    const [loading, setLoading] = useState(false);
    const [success, setSuccess] = useState(false);

    const [formData, setFormData] = useState({
        name: '',
        location: '',
        description: '',
        pricePerHour: '',
        totalSpots: '',
        imageUrl: '',
        type: 'Villa',
        bedrooms: 2,
        bathrooms: 2,
        rating: 5,
        hasSmartParking: true
    });

    // ✨ دالة توليد البيانات السحرية
    const generateMagicData = () => {
        const types = ['Villa', 'Apartment', 'Office', 'Studio'];
        const selectedType = types[Math.floor(Math.random() * types.length)];

        // جلب صورة عشوائية حقيقية للعقارات
        const randomImageId = Math.floor(Math.random() * 1000);
        const randomImageUrl = `https://loremflickr.com/800/600/building,villa,apartment?lock=${randomImageId}`;

        setFormData({
            ...formData,
            name: `${faker.company.name()} ${selectedType}`,
            location: `${faker.location.city()}, Egypt`,
            description: faker.lorem.paragraph(2),
            pricePerHour: faker.number.int({ min: 100, max: 2000 }).toString(),
            totalSpots: faker.number.int({ min: 5, max: 150 }).toString(),
            imageUrl: randomImageUrl,
            type: selectedType,
            bedrooms: faker.number.int({ min: 1, max: 6 }),
            bathrooms: faker.number.int({ min: 1, max: 4 })
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);

        try {
            const dataToSubmit = {
                ...formData,
                pricePerHour: parseFloat(formData.pricePerHour),
                totalSpots: parseInt(formData.totalSpots),
                bedrooms: parseInt(formData.bedrooms),
                bathrooms: parseInt(formData.bathrooms)
            };

            const response = await axios.post('https://localhost:7048/api/properties', dataToSubmit);

            if (response.status === 201 || response.status === 200) {
                setLoading(false);
                setSuccess(true);
                setTimeout(() => navigate('/admin/properties'), 2000);
            }
        } catch (error) {
            console.error("Error details:", error.response?.data);
            alert("حدث خطأ أثناء الحفظ، تأكد من تشغيل الـ API");
            setLoading(false);
        }
    };

    return (
        <div className="min-h-screen bg-slate-50 p-6 lg:p-12">
            <div className="max-w-4xl mx-auto">

                {/* Header */}
                <div className="flex items-center justify-between mb-8">
                    <div className="flex items-center gap-4">
                        <Link to="/admin/properties" className="w-10 h-10 bg-white rounded-xl flex items-center justify-center text-slate-400 hover:text-blue-600 shadow-sm transition-all">
                            <ArrowLeft size={20} />
                        </Link>
                        <h1 className="text-3xl font-black text-slate-800">Add New Property</h1>
                    </div>

                    {/* زر الـ Magic Data الذكي */}
                    {!success && (
                        <button
                            type="button"
                            onClick={generateMagicData}
                            className="flex items-center gap-2 bg-amber-50 text-amber-600 px-5 py-2.5 rounded-2xl border border-amber-200 font-bold hover:bg-amber-100 transition-all active:scale-95 shadow-sm shadow-amber-100"
                        >
                            <Sparkles size={18} />
                            Generate Magic Data
                        </button>
                    )}
                </div>

                {success ? (
                    <div className="bg-white p-12 rounded-[32px] shadow-xl shadow-slate-200/50 text-center animate-in fade-in zoom-in duration-500">
                        <div className="w-20 h-20 bg-green-100 text-green-600 rounded-full flex items-center justify-center mx-auto mb-6">
                            <CheckCircle2 size={40} />
                        </div>
                        <h2 className="text-2xl font-black text-slate-800 mb-2">Property Added Successfully!</h2>
                        <p className="text-slate-500">Redirecting to listings...</p>
                    </div>
                ) : (
                    <form onSubmit={handleSubmit} className="bg-white p-8 lg:p-10 rounded-[32px] shadow-xl shadow-slate-200/50 border border-white">
                        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">

                            {/* Property Name */}
                            <div className="space-y-2">
                                <label className="text-sm font-bold text-slate-700 ml-1">Property Name</label>
                                <div className="relative group">
                                    <Building2 className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-blue-600" size={18} />
                                    <input type="text" required value={formData.name} onChange={(e) => setFormData({ ...formData, name: e.target.value })} className="w-full pl-12 pr-5 py-3.5 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white outline-none transition-all" placeholder="e.g. JO PHONE Tower" />
                                </div>
                            </div>

                            {/* Location */}
                            <div className="space-y-2">
                                <label className="text-sm font-bold text-slate-700 ml-1">Location</label>
                                <div className="relative group">
                                    <MapPin className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-blue-600" size={18} />
                                    <input type="text" required value={formData.location} onChange={(e) => setFormData({ ...formData, location: e.target.value })} className="w-full pl-12 pr-5 py-3.5 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white outline-none transition-all" placeholder="Obour City, Egypt" />
                                </div>
                            </div>

                            {/* Price Per Day */}
                            <div className="space-y-2">
                                <label className="text-sm font-bold text-slate-700 ml-1">Price / Day (EGP)</label>
                                <div className="relative group">
                                    <DollarSign className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-blue-600" size={18} />
                                    <input type="number" required value={formData.pricePerHour} onChange={(e) => setFormData({ ...formData, pricePerHour: e.target.value })} className="w-full pl-12 pr-5 py-3.5 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white outline-none transition-all" placeholder="500" />
                                </div>
                            </div>

                            {/* Total Spots */}
                            <div className="space-y-2">
                                <label className="text-sm font-bold text-slate-700 ml-1">Total Parking Spots</label>
                                <div className="relative group">
                                    <Plus className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-blue-600" size={18} />
                                    <input type="number" required value={formData.totalSpots} onChange={(e) => setFormData({ ...formData, totalSpots: e.target.value })} className="w-full pl-12 pr-5 py-3.5 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white outline-none transition-all" placeholder="50" />
                                </div>
                            </div>

                            {/* Property Type */}
                            <div className="md:col-span-2 space-y-2">
                                <label className="text-sm font-bold text-slate-700 ml-1">Property Type</label>
                                <div className="relative group">
                                    <Layout className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-blue-600" size={18} />
                                    <select
                                        required
                                        value={formData.type}
                                        onChange={(e) => setFormData({ ...formData, type: e.target.value })}
                                        className="w-full pl-12 pr-5 py-3.5 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white outline-none transition-all appearance-none font-medium text-slate-700"
                                    >
                                        <option value="Villa">Villa</option>
                                        <option value="Apartment">Apartment</option>
                                        <option value="Office">Office</option>
                                        <option value="Studio">Studio</option>
                                    </select>
                                </div>
                            </div>

                            {/* Description */}
                            <div className="md:col-span-2 space-y-2">
                                <label className="text-sm font-bold text-slate-700 ml-1">Description</label>
                                <div className="relative group">
                                    <Info className="absolute left-4 top-5 text-slate-400 group-focus-within:text-blue-600" size={18} />
                                    <textarea rows="3" value={formData.description} onChange={(e) => setFormData({ ...formData, description: e.target.value })} className="w-full pl-12 pr-5 py-3.5 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white outline-none transition-all" placeholder="Tell us more about the property..."></textarea>
                                </div>
                            </div>

                            {/* Image URL */}
                            <div className="md:col-span-2 space-y-2">
                                <label className="text-sm font-bold text-slate-700 ml-1">Property Image URL</label>
                                <div className="relative group">
                                    <ImageIcon className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400 group-focus-within:text-blue-600" size={18} />
                                    <input type="text" required value={formData.imageUrl} onChange={(e) => setFormData({ ...formData, imageUrl: e.target.value })} className="w-full pl-12 pr-5 py-3.5 rounded-2xl bg-slate-50 border border-slate-200 focus:border-blue-600 focus:bg-white outline-none transition-all" placeholder="https://image-link.com/photo.jpg" />
                                </div>
                            </div>
                        </div>

                        <button type="submit" disabled={loading} className="w-full mt-10 bg-blue-600 text-white py-4 rounded-2xl font-black shadow-xl shadow-blue-200 hover:bg-blue-700 active:scale-[0.98] transition-all flex items-center justify-center gap-3 disabled:bg-slate-300">
                            {loading ? <Loader2 className="animate-spin" size={24} /> : <><Plus size={24} /> Register Property in System</>}
                        </button>
                    </form>
                )}
            </div>
        </div>
    );
};

export default AdminAddProperty;