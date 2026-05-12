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
        <footer className="bg-slate-900 text-slate-300 font-sans border-t border-slate-800" dir="rtl">
            <div className="max-w-[1440px] mx-auto px-8 pt-16 pb-8 text-right">
                <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-12 mb-16">

                    {/* القسم الأول: اللوجو والوصف */}
                    <div className="space-y-6">
                        <div className="flex items-center gap-2 text-white">
                            <div className="bg-blue-600 p-2 rounded-xl">
                                <Car size={24} className="text-white" />
                            </div>
                            <span className="text-2xl font-black tracking-tighter">REAL<span className="text-blue-500">PARK</span></span>
                        </div>
                        <p className="text-sm leading-relaxed opacity-70">
                            نحن نقدم حلولاً ذكية متكاملة لإدارة العقارات وركن السيارات بأحدث التقنيات العالمية.
                        </p>
                        {/* أيقونات عامة بديلة عشان الأيرور يختفي */}
                        <div className="flex gap-4">
                            <SocialIcon icon={<Share2 size={18} />} />
                            <SocialIcon icon={<Globe size={18} />} />
                            <SocialIcon icon={<Users size={18} />} />
                        </div>
                    </div>

                    {/* القسم الثاني: روابط سريعة */}
                    <div>
                        <h4 className="text-white font-bold text-lg mb-6">روابط سريعة</h4>
                        <ul className="space-y-4 text-sm">
                            <li><FooterLink to="/">الرئيسية</FooterLink></li>
                            <li><FooterLink to="/properties">العقارات</FooterLink></li>
                            <li><FooterLink to="/dashboard">لوحة التحكم</FooterLink></li>
                            <li><FooterLink to="/parking">حجز الركنات</FooterLink></li>
                        </ul>
                    </div>

                    {/* القسم الثالث: خدماتنا */}
                    <div>
                        <h4 className="text-white font-bold text-lg mb-6">خدماتنا</h4>
                        <ul className="space-y-4 text-sm">
                            <li className="hover:text-blue-400 transition-colors cursor-pointer flex items-center gap-2">
                                <span>إدارة العقارات</span>
                            </li>
                            <li className="hover:text-blue-400 transition-colors cursor-pointer flex items-center gap-2">
                                <span>ركن ذكي</span>
                            </li>
                            <li className="hover:text-blue-400 transition-colors cursor-pointer flex items-center gap-2">
                                <span>أنظمة أمان</span>
                            </li>
                        </ul>
                    </div>

                    {/* القسم الرابع: تواصل معنا */}
                    <div className="space-y-4">
                        <h4 className="text-white font-bold text-lg mb-6">اتصل بنا</h4>
                        <div className="flex items-center gap-3">
                            <MapPin size={18} className="text-blue-500" />
                            <span className="text-sm">القاهرة، مصر - التجمع الخامس</span>
                        </div>
                        <div className="flex items-center gap-3" dir="ltr">
                            <span className="text-sm">+20 123 456 789</span>
                            <Phone size={18} className="text-blue-500" />
                        </div>
                        <div className="flex items-center gap-3">
                            <Mail size={18} className="text-blue-500" />
                            <span className="text-sm">support@realpark.com</span>
                        </div>
                    </div>

                </div>

                <div className="border-t border-slate-800 pt-8 flex flex-col md:flex-row justify-between items-center gap-4 text-xs opacity-50">
                    <p>© {new Date().getFullYear()} RealPark System. جميع الحقوق محفوظة.</p>
                    <div className="flex gap-6">
                        <span className="hover:text-white cursor-pointer transition-colors">سياسة الخصوصية</span>
                        <span className="hover:text-white cursor-pointer transition-colors">الشروط والأحكام</span>
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