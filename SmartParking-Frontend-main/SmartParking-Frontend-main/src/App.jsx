import React, { useEffect } from 'react';
import { BrowserRouter as Router, Routes, Route, useLocation, Navigate } from 'react-router-dom';
import Navbar from './components/Navbar';

// Public Pages
import Home from './pages/Home';
import Properties from './pages/Properties';
import PropertyDetails from './pages/PropertyDetails';

// Auth Pages
import Login from './pages/Login';
import SignUp from './pages/SignUp';
import ForgotPassword from './pages/ForgotPassword';

// Protected Pages (User)
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

// 🛡️ مكون الـ Layout لإدارة حماية المسارات وظهور الـ Navbar
const Layout = ({ children }) => {
    const location = useLocation();

    // استرجاع حالة تسجيل الدخول والبيانات
    const isLoggedIn = localStorage.getItem('isLoggedIn') === 'true';
    const userRaw = localStorage.getItem('user');
    const user = userRaw ? JSON.parse(userRaw) : null;

    // التحقق من صلاحية الآدمن
    const isAdmin = user?.role?.toLowerCase() === 'admin' || user?.email === "admin@realstate.com";

    const authPaths = ['/login', '/signup', '/forgot-password', '/register'];
    const publicPaths = ['/', '/properties'];
    const isPropertyDetailPath = location.pathname.startsWith('/property/');
    const isAdminPath = location.pathname.startsWith('/admin');

    // 1. إذا كان مسجل دخول ويحاول دخول صفحات Auth (مثل Login)، حوله للـ Dashboard
    if (isLoggedIn && authPaths.includes(location.pathname)) {
        return <Navigate to="/dashboard" replace />;
    }

    // 2. حماية المسارات الخاصة: إذا لم يسجل دخول ويحاول دخول صفحة ليست عامة، حوله للـ Login
    const isPublic = publicPaths.includes(location.pathname) || isPropertyDetailPath;
    const isAuthPage = authPaths.includes(location.pathname);

    if (!isLoggedIn && !isPublic && !isAuthPage) {
        return <Navigate to="/login" replace />;
    }

    // 3. حماية مسارات الآدمن: إذا حاول شخص عادي دخول صفحات الآدمن، حوله للرئيسية
    if (isAdminPath && !isAdmin) {
        return <Navigate to="/" replace />;
    }

    // إدارة ظهور الـ Navbar (يختفي في صفحات الـ Auth والـ Admin)
    const hideNavbarPaths = ['/login', '/signup', '/forgot-password', '/register'];
    const showNavbar = !hideNavbarPaths.includes(location.pathname) && !isAdminPath;

    return (
        <>
            {showNavbar && <Navbar />}
            <main className="w-full min-h-screen">
                {children}
            </main>
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
                        {/* 🌐 المسارات العامة (متاحة للكل) */}
                        <Route path="/" element={<Home />} />
                        <Route path="/properties" element={<Properties />} />
                        <Route path="/property/:id" element={<PropertyDetails />} />

                        {/* 🔐 مسارات الهوية (تختفي لو مسجل دخول) */}
                        <Route path="/login" element={<Login />} />
                        <Route path="/signup" element={<SignUp />} />
                        <Route path="/register" element={<SignUp />} />
                        <Route path="/forgot-password" element={<ForgotPassword />} />

                        {/* 👤 مسارات المستخدم (تحتاج تسجيل دخول) */}
                        <Route path="/dashboard" element={<Dashboard />} />
                        <Route path="/parking" element={<ParkingReservations />} />
                        <Route path="/payments" element={<Payments />} />
                        <Route path="/settings" element={<Settings />} />

                        {/* 🛠️ مسارات لوحة تحكم الآدمن */}
                        <Route path="/admin/users" element={<AdminUsers />} />
                        <Route path="/admin/add-property" element={<AdminAddProperty />} />
                        <Route path="/admin/settings" element={<AdminSystemSettings />} />
                        <Route path="/admin/reports" element={<AdminReports />} />

                        {/* تحويل المسار العام لـ /admin إلى قائمة المستخدمين */}
                        <Route path="/admin" element={<Navigate to="/admin/users" replace />} />

                        {/* 404 - أي مسار خاطئ يرجع للرئيسية */}
                        <Route path="*" element={<Navigate to="/" replace />} />
                    </Routes>
                </Layout>
            </div>
        </Router>
    );
}

export default App;