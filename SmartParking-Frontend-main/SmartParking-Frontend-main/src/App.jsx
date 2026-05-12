import React, { useEffect } from 'react';
import { BrowserRouter as Router, Routes, Route, useLocation, Navigate, Outlet } from 'react-router-dom';

// Components
import Navbar from './components/Navbar';
import Sidebar from './components/Sidebar';
import AdminSidebar from './components/AdminSidebar'; // تأكد من استيراده
import Footer from './components/Footer';

// Public Pages
import Home from './pages/Home';
import Properties from './pages/Properties';
import PropertyDetails from './pages/PropertyDetails';

// Auth Pages
import Login from './pages/Login';
import SignUp from './pages/SignUp';
import ForgotPassword from './pages/ForgotPassword';

// Protected Pages (User Dashboard)
import Dashboard from './pages/Dashboard';
import ParkingReservations from './pages/ParkingReservations';
import Payments from './pages/Payments';
import Settings from './pages/Settings';

// Admin Pages
import AdminUsers from './pages/AdminUsers';
import AdminSystemSettings from './pages/AdminSystemSettings';
import AdminReports from './pages/AdminReports';
import AdminAddProperty from './pages/AdminAddProperty';

// 🔝 مكون لجعل الصفحة تبدأ من الأعلى عند التنقل
const ScrollToTop = () => {
    const { pathname } = useLocation();
    useEffect(() => {
        window.scrollTo(0, 0);
    }, [pathname]);
    return null;
};

// 🛡️ مكون الـ Dashboard Layout (للمستخدم العادي)
const DashboardLayout = () => {
    const location = useLocation();
    const getActivePage = () => {
        const path = location.pathname;
        if (path.includes('dashboard')) return 'overview';
        if (path.includes('parking')) return 'parking';
        if (path.includes('payments')) return 'payments';
        if (path.includes('settings')) return 'settings';
        return 'overview';
    };

    const userRaw = localStorage.getItem('user');
    const user = userRaw ? JSON.parse(userRaw) : { name: 'User' };

    return (
        <div className="min-h-screen bg-[#F8FAFC]">
            <div className="max-w-[1440px] mx-auto flex p-6 md:p-10 gap-6 md:gap-10">
                <Sidebar activePage={getActivePage()} userName={user.name || user.userName} />
                <main className="flex-1 overflow-hidden">
                    <Outlet />
                </main>
            </div>
        </div>
    );
};

// 🛡️ مكون الـ Admin Layout (لضمان ثبات سايد بار الأدمن ومنع الـ Redirect)
const AdminLayout = () => {
    return (
        <div className="flex min-h-screen bg-[#F8FAFC]">
            {/* السايد بار الأسود هيثبت هنا */}
            <AdminSidebar />
            <main className="flex-1 overflow-y-auto">
                {/* الصفحات هتفتح هنا */}
                <Outlet />
            </main>
        </div>
    );
};

// 🛡️ مكون الـ Layout العام لإدارة الحماية
const Layout = ({ children }) => {
    const location = useLocation();

    const isLoggedIn = localStorage.getItem('isLoggedIn') === 'true';
    const userRaw = localStorage.getItem('user');
    const user = userRaw ? JSON.parse(userRaw) : null;

    // تحسين شرط الأدمن
    const isAdmin = user?.role?.toLowerCase() === 'admin' || user?.email === "admin@realstate.com";

    const authPaths = ['/login', '/signup', '/forgot-password', '/register'];
    const publicPaths = ['/', '/properties'];
    const isPropertyDetailPath = location.pathname.startsWith('/property/');
    const isAdminPath = location.pathname.startsWith('/admin');

    // 1. لو مسجل دخول ميشوفش صفحات اللوجن
    if (isLoggedIn && authPaths.includes(location.pathname)) {
        return <Navigate to="/dashboard" replace />;
    }

    // 2. حماية صفحات الأدمن
    if (isAdminPath && !isAdmin) {
        return <Navigate to="/" replace />;
    }

    // 3. حماية الصفحات الخاصة للمستخدمين
    const isPublic = publicPaths.includes(location.pathname) || isPropertyDetailPath;
    const isAuthPage = authPaths.includes(location.pathname);

    if (!isLoggedIn && !isPublic && !isAuthPage) {
        return <Navigate to="/login" replace />;
    }

    // إعدادات الظهور
    const hideNavbarPaths = [...authPaths];
    const showNavbar = !hideNavbarPaths.includes(location.pathname) && !isAdminPath;
    const showFooter = isPublic && !isAuthPage;

    return (
        <>
            {showNavbar && <Navbar />}
            <main className="w-full min-h-screen">
                {children}
            </main>
            {showFooter && <Footer />}
        </>
    );
};

function App() {
    return (
        <Router future={{ v7_startTransition: true, v7_relativeSplatPath: true }}>
            <ScrollToTop />
            <div className="App min-h-screen bg-white">
                <Layout>
                    <Routes>
                        {/* 🌐 المسارات العامة */}
                        <Route path="/" element={<Home />} />
                        <Route path="/properties" element={<Properties />} />
                        <Route path="/property/:id" element={<PropertyDetails />} />

                        {/* 🔐 مسارات الهوية */}
                        <Route path="/login" element={<Login />} />
                        <Route path="/signup" element={<SignUp />} />
                        <Route path="/register" element={<SignUp />} />
                        <Route path="/forgot-password" element={<ForgotPassword />} />

                        {/* 👤 مسارات المستخدم (User Dashboard) */}
                        <Route element={<DashboardLayout />}>
                            <Route path="/dashboard" element={<Dashboard />} />
                            <Route path="/parking" element={<ParkingReservations />} />
                            <Route path="/payments" element={<Payments />} />
                            <Route path="/settings" element={<Settings />} />
                        </Route>

                        {/* 🛠️ مسارات لوحة تحكم الآدمن (Admin Panel) */}
                        {/* تم تجميعها هنا داخل AdminLayout لضمان عدم الخروج للهوم */}
                        <Route path="/admin" element={<AdminLayout />}>
                            <Route index element={<Navigate to="/admin/users" replace />} />
                            <Route path="users" element={<AdminUsers />} />
                            <Route path="add-property" element={<AdminAddProperty />} />
                            <Route path="settings" element={<AdminSystemSettings />} />
                            <Route path="reports" element={<AdminReports />} />

                            {/* ✅ دي اللي كانت ناقصة: السماح بفتح هذه الصفحات داخل الأدمن */}
                            <Route path="properties" element={<Properties />} />
                            <Route path="parking" element={<ParkingReservations />} />
                        </Route>

                        <Route path="*" element={<Navigate to="/" replace />} />
                    </Routes>
                </Layout>
            </div>
        </Router>
    );
}

export default App;