import React, { useState, useEffect } from 'react';
import userService from '../services/userService';
import { Users, Trash2, Search, Mail, Loader2, Plus, AlertCircle } from 'lucide-react';
import { Link } from 'react-router-dom';
import AdminSidebar from '../components/AdminSidebar';
import AdminTopBar from '../components/AdminTopBar';

const AdminUsers = () => {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [searchTerm, setSearchTerm] = useState("");
    const [error, setError] = useState(null);

    // 1. جلب البيانات من الـ API
    const fetchUsers = async () => {
        try {
            setLoading(true);
            setError(null);
            const data = await userService.getUsers();
            // الـ .NET API بيرجع Array، هنتأكد منها هنا
            setUsers(Array.isArray(data) ? data : []);
        } catch (error) {
            console.error("Connection Error:", error);
            setError("عذراً، لا يمكن الوصول للسيرفر (تأكد من تشغيل الـ API والـ Database).");
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchUsers();
    }, []);

    // 2. معالجة الحذف
    const handleDeleteUser = async (id, email) => {
        if (window.confirm(`⚠️ هل أنت متأكد من حذف حساب: ${email}؟`)) {
            try {
                await userService.deleteUser(id);
                // تحديث اللستة في الواجهة فوراً بعد الحذف الناجح
                setUsers(prevUsers => prevUsers.filter(u => (u.id || u.Id) !== id));
            } catch (error) {
                console.error("Delete Error:", error);
                alert("حدث خطأ أثناء محاولة الحذف من السيرفر.");
            }
        }
    };

    // 3. فلترة البحث (مع دعم PascalCase و camelCase)
    const filteredUsers = users.filter(u => {
        const email = (u.email || u.Email || "").toLowerCase();
        const name = (u.fullName || u.FullName || u.name || u.Name || "").toLowerCase();
        const search = searchTerm.toLowerCase();
        return email.includes(search) || name.includes(search);
    });

    return (
        <div className="flex min-h-screen bg-[#F8FAFC]">
            {/* القائمة الجانبية */}
            <AdminSidebar />

            <div className="flex-1 flex flex-col h-screen overflow-hidden">
                {/* الشريحة العلوية */}
                <AdminTopBar />

                <main className="flex-1 p-10 overflow-y-auto">
                    <div className="max-w-[1200px] mx-auto">

                        {/* العنوان وزر الإضافة */}
                        <div className="mb-10 flex flex-col md:flex-row justify-between items-start md:items-end gap-4">
                            <div>
                                <h2 className="text-3xl font-black text-slate-800 mb-2">Management Portal</h2>
                                <p className="text-gray-500 font-medium">إدارة حسابات المستخدمين المسجلين في النظام (SQL Server Database).</p>
                            </div>
                            <Link to="/admin/add-property" className="flex items-center gap-2 bg-blue-600 text-white px-6 py-3.5 rounded-2xl font-black shadow-lg hover:bg-blue-700 transition-all active:scale-95">
                                <Plus size={20} /> Add New Property
                            </Link>
                        </div>

                        {/* عرض الخطأ إن وجد */}
                        {error && !loading && (
                            <div className="mb-6 p-4 bg-red-50 border border-red-100 rounded-2xl flex items-center gap-3 text-red-600 font-bold">
                                <AlertCircle size={20} /> {error}
                            </div>
                        )}

                        {/* جدول المستخدمين */}
                        <div className="bg-white rounded-[32px] border border-gray-100 shadow-sm overflow-hidden">

                            {/* شريط البحث والعنوان الداخلي */}
                            <div className="p-8 border-b border-gray-50 flex flex-col md:flex-row justify-between items-center gap-4 bg-slate-50/50">
                                <h3 className="text-xl font-black text-slate-800 flex items-center gap-2">
                                    <Users className="text-blue-600" size={24} /> Registered Users
                                </h3>
                                <div className="relative w-full md:w-96">
                                    <Search className="absolute left-4 top-1/2 -translate-y-1/2 text-gray-400" size={18} />
                                    <input
                                        type="text"
                                        placeholder="بحث بالاسم أو البريد..."
                                        className="w-full pl-12 pr-4 py-3.5 bg-white rounded-2xl border border-gray-200 outline-none text-sm transition-all focus:ring-4 focus:ring-blue-50 font-medium"
                                        value={searchTerm}
                                        onChange={(e) => setSearchTerm(e.target.value)}
                                    />
                                </div>
                            </div>

                            {/* الحالات المختلفة: تحميل، قائمة فارغة، أو عرض الجدول */}
                            {loading ? (
                                <div className="p-32 flex flex-col items-center gap-4 text-gray-400">
                                    <Loader2 className="animate-spin text-blue-600" size={48} />
                                    <p className="font-black text-[10px] uppercase tracking-widest">جاري جلب البيانات من SQL Server...</p>
                                </div>
                            ) : filteredUsers.length === 0 ? (
                                <div className="p-32 text-center text-gray-400">
                                    <Users size={48} className="mx-auto mb-4 opacity-20" />
                                    <p className="font-bold">لا يوجد مستخدمين يطابقون بحثك حالياً.</p>
                                </div>
                            ) : (
                                <div className="overflow-x-auto">
                                    <table className="w-full text-left">
                                        <thead>
                                            <tr className="text-[11px] font-black text-gray-400 uppercase tracking-[0.2em] bg-gray-50/30">
                                                <th className="px-8 py-6">User Profile</th>
                                                <th className="px-8 py-6">Role</th>
                                                <th className="px-8 py-6">Status</th>
                                                <th className="px-8 py-6 text-right">Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody className="divide-y divide-gray-50">
                                            {filteredUsers.map((user) => {
                                                // معالجة البيانات القادمة من .NET (التي تكون PascalCase)
                                                const id = user.id || user.Id;
                                                const name = user.fullName || user.FullName || user.name || user.Name || "Unknown";
                                                const email = user.email || user.Email || "No Email";
                                                const role = user.role || user.Role || "User";
                                                const status = user.status || user.Status || "Active";

                                                return (
                                                    <tr key={id} className="hover:bg-slate-50/80 transition-colors group">
                                                        <td className="px-8 py-5">
                                                            <div className="flex items-center gap-4">
                                                                <div className={`w-11 h-11 rounded-2xl flex items-center justify-center font-black shadow-lg transition-transform group-hover:scale-110 ${role.toLowerCase() === 'admin' ? 'bg-purple-600 text-white' : 'bg-slate-800 text-white'}`}>
                                                                    {name.charAt(0).toUpperCase()}
                                                                </div>
                                                                <div>
                                                                    <p className="font-black text-slate-800 text-sm">{name}</p>
                                                                    <p className="text-xs text-gray-400 flex items-center gap-1 font-medium">
                                                                        <Mail size={12} /> {email}
                                                                    </p>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td className="px-8 py-5">
                                                            <span className={`text-[10px] font-black px-3 py-1.5 rounded-lg uppercase ${role.toLowerCase() === 'admin' ? 'bg-purple-100 text-purple-600' : 'bg-blue-100 text-blue-600'}`}>
                                                                {role}
                                                            </span>
                                                        </td>
                                                        <td className="px-8 py-5">
                                                            <div className="flex items-center gap-1.5">
                                                                <div className={`w-1.5 h-1.5 rounded-full ${status.toLowerCase() === 'active' ? 'bg-green-500 animate-pulse' : 'bg-gray-300'}`}></div>
                                                                <span className="text-[10px] font-black text-slate-500 uppercase">{status}</span>
                                                            </div>
                                                        </td>
                                                        <td className="px-8 py-5 text-right">
                                                            <button
                                                                onClick={() => handleDeleteUser(id, email)}
                                                                className="p-3 text-gray-400 hover:text-white hover:bg-red-500 rounded-xl transition-all duration-200 active:scale-90"
                                                            >
                                                                <Trash2 size={18} />
                                                            </button>
                                                        </td>
                                                    </tr>
                                                );
                                            })}
                                        </tbody>
                                    </table>
                                </div>
                            )}
                        </div>
                    </div>
                </main>
            </div>
        </div>
    );
};

export default AdminUsers;