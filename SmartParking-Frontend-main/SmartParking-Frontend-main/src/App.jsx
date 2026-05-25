import React, { useEffect } from 'react';
import { BrowserRouter as Router, Routes, Route, useLocation, Navigate, Outlet } from 'react-router-dom';
import { AuthProvider, useAuth } from './context/AuthContext';

// Components
import Navbar from './components/Navbar';
import Sidebar from './components/Sidebar';
import AdminSidebar from './components/AdminSidebar';
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

// Scroll to top on route change
const ScrollToTop = () => {
    const { pathname } = useLocation();
    useEffect(() => {
        window.scrollTo(0, 0);
    }, [pathname]);
    return null;
};

// Protected Route Wrapper
const ProtectedRoute = ({ children, adminOnly = false }) => {
    const { isAuthenticated, isAdmin, isLoading } = useAuth();
    const location = useLocation();

    if (isLoading) {
        return (
            <div className="min-h-screen flex items-center justify-center">
                <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-blue-600" />
            </div>
        );
    }

    if (!isAuthenticated) {
        return <Navigate to="/login" state={{ from: location }} replace />;
    }

    if (adminOnly && !isAdmin) {
        return <Navigate to="/dashboard" replace />;
    }

    return children;
};

// User Dashboard Layout
const DashboardLayout = () => {
    const location = useLocation();
    const { user } = useAuth();

    const getActivePage = () => {
        const path = location.pathname;
        if (path.includes('dashboard')) return 'overview';
        if (path.includes('parking')) return 'parking';
        if (path.includes('payments')) return 'payments';
        if (path.includes('settings')) return 'settings';
        return 'overview';
    };

    return (
        <div className="min-h-screen bg-[#F8FAFC]">
            <div className="max-w-[1440px] mx-auto flex p-6 md:p-10 gap-6 md:gap-10">
                <Sidebar activePage={getActivePage()} userName={user?.fullName || 'User'} />
                <main className="flex-1 overflow-hidden">
                    <Outlet />
                </main>
            </div>
        </div>
    );
};

// Admin Layout
const AdminLayout = () => {
    return (
        <div className="flex min-h-screen bg-[#F8FAFC]">
            <AdminSidebar />
            <main className="flex-1 overflow-y-auto">
                <Outlet />
            </main>
        </div>
    );
};

// Public Layout
const PublicLayout = ({ children }) => {
    const location = useLocation();
    const { isAuthenticated, isAdmin } = useAuth();

    const authPaths = ['/login', '/signup', '/forgot-password', '/register'];
    const publicPaths = ['/', '/properties'];
    const isPropertyDetailPath = location.pathname.startsWith('/property/');
    const isAdminPath = location.pathname.startsWith('/admin');

    // Redirect logged in users away from auth pages
    if (isAuthenticated && authPaths.includes(location.pathname)) {
        return <Navigate to={isAdmin ? '/admin/users' : '/dashboard'} replace />;
    }

    const hideNavbarPaths = [...authPaths];
    const showNavbar = !hideNavbarPaths.includes(location.pathname) && !isAdminPath;
    const isPublic = publicPaths.includes(location.pathname) || isPropertyDetailPath;
    const isAuthPage = authPaths.includes(location.pathname);
    const showFooter = isPublic && !isAuthPage;

    return (
        <>
            {showNavbar && <Navbar />}
            <main className="w-full min-h-screen">{children}</main>
            {showFooter && <Footer />}
        </>
    );
};

function AppRoutes() {
    return (
        <>
            <ScrollToTop />
            <div className="App min-h-screen bg-white">
                <PublicLayout>
                    <Routes>
                        {/* Public Routes */}
                        <Route path="/" element={<Home />} />
                        <Route path="/properties" element={<Properties />} />
                        <Route path="/property/:id" element={<PropertyDetails />} />

                        {/* Auth Routes */}
                        <Route path="/login" element={<Login />} />
                        <Route path="/signup" element={<SignUp />} />
                        <Route path="/register" element={<SignUp />} />
                        <Route path="/forgot-password" element={<ForgotPassword />} />

                        {/* Protected User Routes */}
                        <Route
                            element={
                                <ProtectedRoute>
                                    <DashboardLayout />
                                </ProtectedRoute>
                            }
                        >
                            <Route path="/dashboard" element={<Dashboard />} />
                            <Route path="/parking" element={<ParkingReservations />} />
                            <Route path="/payments" element={<Payments />} />
                            <Route path="/settings" element={<Settings />} />
                        </Route>

                        {/* Protected Admin Routes */}
                        <Route
                            path="/admin"
                            element={
                                <ProtectedRoute adminOnly>
                                    <AdminLayout />
                                </ProtectedRoute>
                            }
                        >
                            <Route index element={<Navigate to="/admin/users" replace />} />
                            <Route path="users" element={<AdminUsers />} />
                            <Route path="add-property" element={<AdminAddProperty />} />
                            <Route path="settings" element={<AdminSystemSettings />} />
                            <Route path="reports" element={<AdminReports />} />
                            <Route path="properties" element={<Properties />} />
                            <Route path="parking" element={<ParkingReservations />} />
                        </Route>

                        <Route path="*" element={<Navigate to="/" replace />} />
                    </Routes>
                </PublicLayout>
            </div>
        </>
    );
}

function App() {
    return (
        <Router future={{ v7_startTransition: true, v7_relativeSplatPath: true }}>
            <AuthProvider>
                <AppRoutes />
            </AuthProvider>
        </Router>
    );
}

export default App;