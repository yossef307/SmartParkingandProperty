import React from 'react';
import { Outlet, useLocation } from 'react-router-dom';
import Sidebar from '../components/Sidebar';

const DashboardLayout = () => {
    const location = useLocation();
    
    // استخراج اسم الصفحة من المسار لتحديد الـ Active Link في السايد بار
    const getActivePage = () => {
        const path = location.pathname;
        if (path.includes('dashboard')) return 'overview';
        if (path.includes('payments')) return 'payments';
        if (path.includes('settings')) return 'settings';
        return 'overview';
    };

    // استرجاع اسم المستخدم من localStorage (عشان السايد بار يفضل شايفه)
    const userRaw = localStorage.getItem('user');
    const userName = userRaw ? JSON.parse(userRaw).name : 'User';

    return (
        <div className="min-h-screen bg-[#F8FAFC]">
            <div className="max-w-[1440px] mx-auto flex p-10 gap-10">
                {/* السايد بار ثابت هنا ومش هيتحرك */}
                <Sidebar activePage={getActivePage()} userName={userName} />

                {/* المحتوى المتغير (البيانات) هيظهر هنا */}
                <main className="flex-1">
                    <Outlet />
                </main>
            </div>
        </div>
    );
};

export default DashboardLayout;