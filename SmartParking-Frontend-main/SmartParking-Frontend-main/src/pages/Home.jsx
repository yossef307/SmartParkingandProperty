import React from 'react';
import { Link } from 'react-router-dom';
import { Building2, Car, ShieldCheck, ArrowRight, Star, MapPin } from 'lucide-react';
import { useAuth } from '../context/AuthContext';  // اضافة الـ import

const Home = () => {
    // استخدام useAuth بدلا من localStorage
    const { isAuthenticated } = useAuth();

    return (
        <div className="flex flex-col min-h-screen bg-white">
            {/* Hero Section */}
            <section className="relative h-[85vh] flex items-center justify-center bg-slate-900 overflow-hidden">
                <div className="absolute inset-0 z-0">
                    <img
                        src="https://images.unsplash.com/photo-1560518883-ce09059eeffa?q=80&w=2000"
                        className="w-full h-full object-cover opacity-40"
                        alt="Background"
                    />
                    <div className="absolute inset-0 bg-gradient-to-b from-transparent to-slate-900"></div>
                </div>

                <div className="container mx-auto px-6 relative z-10 text-center text-white">
                    <h1 className="text-6xl md:text-8xl font-black mb-6 tracking-tighter">
                        Real<span className="text-blue-600">Park</span>
                    </h1>
                    <p className="text-xl md:text-2xl text-slate-300 max-w-3xl mx-auto mb-10 font-light leading-relaxed">
                        A smart system combining luxury living with seamless parking. Rent your unit now and reserve your spot with a single click.
                    </p>

                    <div className="flex flex-col sm:flex-row gap-4 justify-center">
                        <Link to="/properties" className="bg-blue-600 hover:bg-blue-700 text-white px-10 py-4 rounded-2xl font-bold text-lg transition-all shadow-xl shadow-blue-500/20 flex items-center justify-center gap-2">
                            Explore Units <ArrowRight size={20} />
                        </Link>

                        {/* Button changes based on login status */}
                        {!isAuthenticated ? (
                            <Link to="/login" className="bg-white/10 backdrop-blur-md border border-white/20 hover:bg-white/20 text-white px-10 py-4 rounded-2xl font-bold text-lg transition-all">
                                Login
                            </Link>
                        ) : (
                            <Link to="/parking" className="bg-emerald-600 hover:bg-emerald-700 text-white px-10 py-4 rounded-2xl font-bold text-lg transition-all shadow-xl shadow-emerald-500/20 flex items-center justify-center gap-2">
                                <Car size={20} /> Book Parking
                            </Link>
                        )}
                    </div>
                </div>
            </section>

            {/* Features Section */}
            <section className="py-24 bg-slate-50">
                <div className="container mx-auto px-6">
                    <div className="grid md:grid-cols-3 gap-12">
                        <FeatureCard
                            icon={<Car size={40} className="text-blue-600" />}
                            title="Smart Parking"
                            desc="Fully automated system using QR Code technology for seamless parking management."
                        />
                        <FeatureCard
                            icon={<Building2 size={40} className="text-blue-600" />}
                            title="Luxury Units"
                            desc="A curated selection of premium properties designed to meet all your needs and aspirations."
                        />
                        <FeatureCard
                            icon={<ShieldCheck size={40} className="text-blue-600" />}
                            title="Safe & Secure"
                            desc="Complete protection for your data, payments, and reservation processes."
                        />
                    </div>
                </div>
            </section>
        </div>
    );
};

const FeatureCard = ({ icon, title, desc }) => (
    <div className="bg-white p-10 rounded-[2.5rem] shadow-sm border border-slate-100 hover:shadow-xl transition-all group">
        <div className="mb-6 bg-blue-50 w-20 h-20 flex items-center justify-center rounded-2xl group-hover:bg-blue-600 group-hover:text-white transition-colors">
            {icon}
        </div>
        <h3 className="text-2xl font-black mb-4 text-slate-800">{title}</h3>
        <p className="text-slate-500 leading-relaxed font-medium">{desc}</p>
    </div>
);

export default Home;