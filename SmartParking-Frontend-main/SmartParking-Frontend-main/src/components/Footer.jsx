import React from 'react';
import {
    Mail,
    Phone,
    MapPin,
    Car,
    Share2,
    Globe,
    Users,
    Info
} from 'lucide-react';
import { Link } from 'react-router-dom';

const Footer = () => {
    return (
        <footer className="bg-slate-900 text-slate-300 font-sans border-t border-slate-800" dir="ltr">
            <div className="max-w-[1440px] mx-auto px-8 pt-16 pb-8 text-left">
                <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-12 mb-16">

                    {/* Section 1: Logo and Description */}
                    <div className="space-y-6">
                        <div className="flex items-center gap-2 text-white">
                            <div className="bg-blue-600 p-2 rounded-xl">
                                <Car size={24} className="text-white" />
                            </div>
                            <span className="text-2xl font-black tracking-tighter">REAL<span className="text-blue-500">PARK</span></span>
                        </div>
                        <p className="text-sm leading-relaxed opacity-70">
                            We provide smart integrated solutions for property management and parking using the latest global technologies.
                        </p>
                        <div className="flex gap-4">
                            <SocialIcon icon={<Share2 size={18} />} />
                            <SocialIcon icon={<Globe size={18} />} />
                            <SocialIcon icon={<Users size={18} />} />
                        </div>
                    </div>

                    {/* Section 2: Quick Links */}
                    <div>
                        <h4 className="text-white font-bold text-lg mb-6">Quick Links</h4>
                        <ul className="space-y-4 text-sm">
                            <li><FooterLink to="/">Home</FooterLink></li>
                            <li><FooterLink to="/properties">Properties</FooterLink></li>
                            <li><FooterLink to="/dashboard">Dashboard</FooterLink></li>
                            <li><FooterLink to="/parking">Parking Reservations</FooterLink></li>
                        </ul>
                    </div>

                    {/* Section 3: Our Services */}
                    <div>
                        <h4 className="text-white font-bold text-lg mb-6">Our Services</h4>
                        <ul className="space-y-4 text-sm">
                            <li className="hover:text-blue-400 transition-colors cursor-pointer flex items-center gap-2">
                                <span>Property Management</span>
                            </li>
                            <li className="hover:text-blue-400 transition-colors cursor-pointer flex items-center gap-2">
                                <span>Smart Parking</span>
                            </li>
                            <li className="hover:text-blue-400 transition-colors cursor-pointer flex items-center gap-2">
                                <span>Security Systems</span>
                            </li>
                        </ul>
                    </div>

                    {/* Section 4: Contact Us */}
                    <div className="space-y-4">
                        <h4 className="text-white font-bold text-lg mb-6">Contact Us</h4>
                        <div className="flex items-center gap-3">
                            <MapPin size={18} className="text-blue-500" />
                            <span className="text-sm">Cairo, Egypt - Fifth Settlement</span>
                        </div>
                        <div className="flex items-center gap-3">
                            <Phone size={18} className="text-blue-500" />
                            <span className="text-sm">+20 123 456 789</span>
                        </div>
                        <div className="flex items-center gap-3">
                            <Mail size={18} className="text-blue-500" />
                            <span className="text-sm">support@realpark.com</span>
                        </div>
                    </div>

                </div>

                <div className="border-t border-slate-800 pt-8 flex flex-col md:flex-row justify-between items-center gap-4 text-xs opacity-50">
                    <p>&copy; {new Date().getFullYear()} RealPark System. All rights reserved.</p>
                    <div className="flex gap-6">
                        <span className="hover:text-white cursor-pointer transition-colors">Privacy Policy</span>
                        <span className="hover:text-white cursor-pointer transition-colors">Terms & Conditions</span>
                    </div>
                </div>
            </div>
        </footer>
    );
};

const SocialIcon = ({ icon }) => (
    <div className="w-9 h-9 rounded-full bg-slate-800 flex items-center justify-center hover:bg-blue-600 hover:text-white transition-all cursor-pointer">
        {icon}
    </div>
);

const FooterLink = ({ to, children }) => (
    <Link to={to} className="hover:text-blue-400 transition-colors block w-fit">
        {children}
    </Link>
);

export default Footer;
