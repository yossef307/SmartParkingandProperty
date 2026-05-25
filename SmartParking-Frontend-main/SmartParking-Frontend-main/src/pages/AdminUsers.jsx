import React, { useState, useEffect } from 'react';
import userService from '../services/userService';
import { Users, Trash2, Search, Mail, Loader2, Plus, AlertCircle } from 'lucide-react';
import { Link } from 'react-router-dom';

const AdminUsers = () => {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [searchTerm, setSearchTerm] = useState("");
    const [error, setError] = useState(null);

    // 1. جلب البيانات من الـ API (SQL Server)
    const fetchUsers = async () => {
        try {
            setLoading(true);
            setError(null);
            const data = await userService.getUsers();
            // دعم استلام البيانات سواء كانت PascalCase من .NET أو camelCase
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
                setUsers(prevUsers => prevUsers.filter(u => (u.id || u.Id) !== id));
            } catch (error) {
                console.error("Delete Error:", error);
                alert("حدث خطأ أثناء محاولة الحذف من السيرفر.");
            }
        }
    };

    // 3. فلترة البحث الذكي
    const filteredUsers = users.filter(u => {
        const email = (u.email || u.Email || "").toLowerCase();
        const name = (u.fullName || u.FullName || u.name || u.Name || "").toLowerCase();
        const search = searchTerm.toLowerCase();
        return email.includes(search) || name.includes(search);
    });

    return (
        /* ✅ هذا الـ Container مصمم ليعمل داخل الـ Outlet الخاص بالـ AdminLayout */
        <div className="p-6 md:p-10 bg-transparent">
            <div className="max-w-[1200px] mx-auto">

                {/* Header Section */}
                <div className="mb-10 flex flex-col md:flex-row justify-between items-start md:items-end gap-4">
                    <div>
                        <h2 className="text-3xl font-black text-slate-800 mb-2 tracking-tight">Management Portal</h2>
                        <p className="text-slate-500 font-medium text-sm flex items-center gap-2">
                            إدارة حسابات المستخدمين المسجلين في النظام
                            <span className="px-2 py-0.5 bg-blue-50 text-blue-600 rounded-md text-[10px] font-bold border border-blue-100">SQL SERVER</span>
                        </p>
                    </div>
                    <Link
                        to="/admin/add-property"
                        className="flex items-center gap-2 bg-blue-600 text-white px-6 py-3.5 rounded-2xl font-black shadow-lg shadow-blue-600/20 hover:bg-blue-700 hover:-translate-y-0.5 transition-all active:scale-95"
                    >
                        <Plus size={20} /> Add New Property
                    </Link>
                </div>

                {/* Error Alert */}
                {error && !loading && (
                    <div className="mb-6 p-4 bg-red-50 border border-red-100 rounded-2xl flex items-center gap-3 text-red-600 font-bold animate-in fade-in slide-in-from-top-4">
                        <AlertCircle size={20} /> {error}
                    </div>
                )}

                {/* Main Table Card */}
                <div className="bg-white rounded-[32px] border border-slate-100 shadow-sm overflow-hidden transition-all hover:shadow-md">

                    {/* Table Toolbar */}
                    <div className="p-8 border-b border-slate-50 flex flex-col md:flex-row justify-between items-center gap-4 bg-slate-50/30">
                        <h3 className="text-xl font-black text-slate-800 flex items-center gap-2">
                            <Users className="text-blue-600" size={24} />
                            Registered Users
                            <span className="text-sm font-bold text-slate-400 ml-2">({filteredUsers.length})</span>
                        </h3>
                        <div className="relative w-full md:w-96">
                            <Search className="absolute left-4 top-1/2 -translate-y-1/2 text-slate-400" size={18} />
                            <input
                                type="text"
                                placeholder="بحث بالاسم أو البريد..."
                                className="w-full pl-12 pr-4 py-3.5 bg-white rounded-2xl border border-slate-200 outline-none text-sm transition-all focus:ring-4 focus:ring-blue-100/50 focus:border-blue-400 font-medium"
                                value={searchTerm}
                                onChange={(e) => setSearchTerm(e.target.value)}
                            />
                        </div>
                    </div>

                    {/* Table Body / Loading / Empty States */}
                    {loading ? (
                        <div className="p-32 flex flex-col items-center gap-4 text-slate-400">
                            <div className="relative">
                                <Loader2 className="animate-spin text-blue-600" size={48} />
                                <div className="absolute inset-0 blur-xl bg-blue-400/20 animate-pulse"></div>
                            </div>
                            <p className="font-black text-[10px] uppercase tracking-[0.2em]">Connecting to API...</p>
                        </div>
                    ) : filteredUsers.length === 0 ? (
                        <div className="p-32 text-center text-slate-400">
                            <Users size={48} className="mx-auto mb-4 opacity-10" />
                            <p className="font-bold">لا يوجد مستخدمين يطابقون بحثك حالياً.</p>
                        </div>
                    ) : (
                        <div className="overflow-x-auto">
                            <table className="w-full text-left">
                                <thead>
                                    <tr className="text-[11px] font-black text-slate-400 uppercase tracking-[0.2em] bg-slate-50/50">
                                        <th className="px-8 py-6">User Profile</th>
                                        <th className="px-8 py-6">Role</th>
                                        <th className="px-8 py-6">Status</th>
                                        <th className="px-8 py-6 text-right">Actions</th>
                                    </tr>
                                </thead>
                                <tbody className="divide-y divide-slate-50">
                                    {filteredUsers.map((user) => {
                                        const id = user.id || user.Id;
                                        const name = user.fullName || user.FullName || user.name || user.Name || "Unknown";
                                        const email = user.email || user.Email || "No Email";
                                        const role = (user.role || user.Role || "User").toUpperCase();
                                        const status = user.status || user.Status || "Active";

                                        return (
                                            <tr key={id} className="hover:bg-slate-50/50 transition-colors group">
                                                <td className="px-8 py-5">
                                                    <div className="flex items-center gap-4">
                                                        <div className={`w-11 h-11 rounded-2xl flex items-center justify-center font-black shadow-md transition-all group-hover:scale-110 group-hover:rotate-3 ${role === 'ADMIN' ? 'bg-indigo-600 text-white' : 'bg-slate-800 text-white'}`}>
                                                            {name.charAt(0).toUpperCase()}
                                                        </div>
                                                        <div>
                                                            <p className="font-black text-slate-800 text-sm">{name}</p>
                                                            <p className="text-[11px] text-slate-400 flex items-center gap-1.5 font-bold">
                                                                <Mail size={12} className="text-slate-300" /> {email}
                                                            </p>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td className="px-8 py-5">
                                                    <span className={`text-[10px] font-black px-3 py-1.5 rounded-lg border ${role === 'ADMIN' ? 'bg-indigo-50 text-indigo-600 border-indigo-100' : 'bg-blue-50 text-blue-600 border-blue-100'}`}>
                                                        {role}
                                                    </span>
                                                </td>
                                                <td className="px-8 py-5">
                                                    <div className="flex items-center gap-1.5">
                                                        <div className={`w-1.5 h-1.5 rounded-full ${status.toLowerCase() === 'active' ? 'bg-emerald-500 shadow-[0_0_8px_rgba(16,185,129,0.5)] animate-pulse' : 'bg-slate-300'}`}></div>
                                                        <span className="text-[10px] font-black text-slate-500 uppercase">{status}</span>
                                                    </div>
                                                </td>
                                                <td className="px-8 py-5 text-right">
                                                    <button
                                                        onClick={() => handleDeleteUser(id, email)}
                                                        className="p-3 text-slate-300 hover:text-white hover:bg-red-500 hover:shadow-lg hover:shadow-red-500/20 rounded-xl transition-all duration-200 active:scale-90"
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
        </div>
    );
};

export default AdminUsers;