import React, { useState } from 'react';
import { Save, Lock, Bell, Globe, Database, ShieldCheck, Server } from 'lucide-react';
import AdminSidebar from '../components/AdminSidebar';
import AdminTopBar from '../components/AdminTopBar';

// 1. غيرنا الاسم ليكون معبر عن الصفحة (System Settings)
const AdminSystemSettings = () => {
    const [systemStatus, setSystemStatus] = useState(true);
    const [backupLoading, setBackupLoading] = useState(false);

    // دالة وهمية لمحاكاة عملية النسخ الاحتياطي (عشان تبهرهم في العرض)
    const handleBackup = () => {
        setBackupLoading(true);
        setTimeout(() => {
            setBackupLoading(false);
            alert("Database backup completed successfully!");
        }, 2000);
    };

    return (
        <div className="flex min-h-screen bg-[#F8FAFC]">
            <AdminSidebar />

            <div className="flex-1 flex flex-col h-screen overflow-hidden">
                <AdminTopBar />

                <main className="flex-1 p-10 overflow-y-auto">
                    <div className="max-w-[1000px] mx-auto">

                        <div className="flex justify-between items-end mb-10">
                            <div>
                                <h2 className="text-3xl font-black text-slate-800 mb-2">System Settings</h2>
                                <p className="text-gray-500 font-medium">Global configuration & system security parameters.</p>
                            </div>
                            <button className="flex items-center gap-2 bg-blue-600 text-white px-8 py-3 rounded-2xl font-black text-sm hover:bg-blue-700 transition shadow-lg shadow-blue-200 active:scale-95">
                                <Save size={18} /> Save Changes
                            </button>
                        </div>

                        <div className="grid grid-cols-1 gap-8">

                            {/* General System Configuration */}
                            <div className="bg-white rounded-[32px] border border-slate-100 shadow-sm p-8">
                                <div className="flex items-center gap-3 mb-8">
                                    <div className="w-10 h-10 bg-blue-50 text-blue-600 rounded-xl flex items-center justify-center">
                                        <Globe size={20} />
                                    </div>
                                    <h3 className="text-lg font-black text-slate-800">Global Configuration</h3>
                                </div>

                                <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
                                    <SettingInput label="Project Name" placeholder="RealPark Management" defaultValue="RealPark Pro" />
                                    <SettingInput label="Support Email" placeholder="admin@realstate.com" defaultValue="admin@realstate.com" />

                                    <div className="flex items-center justify-between p-4 bg-slate-50 rounded-2xl border border-slate-100">
                                        <div>
                                            <p className="text-sm font-black text-slate-800">Maintenance Mode</p>
                                            <p className="text-[10px] text-slate-400 font-bold uppercase tracking-tighter italic">Off limits for regular users</p>
                                        </div>
                                        <button
                                            onClick={() => setSystemStatus(!systemStatus)}
                                            className={`w-12 h-6 rounded-full transition-all relative shadow-inner ${systemStatus ? 'bg-green-500' : 'bg-slate-300'}`}
                                        >
                                            <div className={`absolute top-1 w-4 h-4 bg-white rounded-full shadow-md transition-all ${systemStatus ? 'left-7' : 'left-1'}`}></div>
                                        </button>
                                    </div>

                                    <div className="flex items-center justify-between p-4 bg-slate-50 rounded-2xl border border-slate-100">
                                        <div>
                                            <p className="text-sm font-black text-slate-800">Booking Permissions</p>
                                            <p className="text-[10px] text-slate-400 font-bold uppercase tracking-tighter italic">Live parking reservation status</p>
                                        </div>
                                        <span className="text-[10px] font-black text-green-600 bg-green-100 px-3 py-1.5 rounded-full border border-green-200">ACTIVE</span>
                                    </div>
                                </div>
                            </div>

                            {/* Server & Security Section */}
                            <div className="bg-white rounded-[32px] border border-slate-100 shadow-sm p-8 mb-10">
                                <div className="flex items-center gap-3 mb-8">
                                    <div className="w-10 h-10 bg-red-50 text-red-600 rounded-xl flex items-center justify-center">
                                        <ShieldCheck size={20} />
                                    </div>
                                    <h3 className="text-lg font-black text-slate-800">Security & Server</h3>
                                </div>

                                <div className="space-y-4">
                                    <div className="flex items-center justify-between p-5 border border-slate-50 hover:border-blue-100 group cursor-pointer hover:bg-blue-50/30 transition-all rounded-[24px]">
                                        <div className="flex items-center gap-4">
                                            <div className="p-3 bg-white rounded-xl shadow-sm text-slate-400 group-hover:text-blue-600 transition-colors">
                                                <Database size={20} />
                                            </div>
                                            <div>
                                                <p className="text-sm font-bold text-slate-700">Database Backup</p>
                                                <p className="text-xs text-slate-400 font-medium">Last automated sync: 2 hours ago</p>
                                            </div>
                                        </div>
                                        <button
                                            onClick={handleBackup}
                                            disabled={backupLoading}
                                            className="text-slate-900 font-black text-[10px] uppercase tracking-widest border border-slate-200 px-5 py-2.5 rounded-xl hover:bg-white hover:shadow-md transition-all disabled:opacity-50"
                                        >
                                            {backupLoading ? 'Running...' : 'Run Backup Now'}
                                        </button>
                                    </div>

                                    <div className="flex items-center justify-between p-5 border border-slate-50 hover:border-red-100 group cursor-pointer hover:bg-red-50/30 transition-all rounded-[24px]">
                                        <div className="flex items-center gap-4">
                                            <div className="p-3 bg-white rounded-xl shadow-sm text-slate-400 group-hover:text-red-500 transition-colors">
                                                <Lock size={20} />
                                            </div>
                                            <div>
                                                <p className="text-sm font-bold text-slate-700">API Security Key</p>
                                                <p className="text-xs text-slate-400 font-medium">Manage your backend authentication tokens</p>
                                            </div>
                                        </div>
                                        <span className="text-slate-300 font-black text-[10px] uppercase tracking-widest">Configure</span>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </main>
            </div>
        </div>
    );
};

const SettingInput = ({ label, placeholder, defaultValue }) => (
    <div className="space-y-2">
        <label className="text-[11px] font-black text-slate-400 uppercase tracking-widest ml-1">{label}</label>
        <input
            type="text"
            defaultValue={defaultValue}
            placeholder={placeholder}
            className="w-full px-5 py-4 bg-slate-50 border border-slate-100 rounded-2xl focus:bg-white focus:border-blue-600 focus:ring-4 focus:ring-blue-50 outline-none transition-all font-bold text-slate-700 text-sm shadow-sm"
        />
    </div>
);

export default AdminSystemSettings; // تأكد من الـ Export بالاسم الجديد