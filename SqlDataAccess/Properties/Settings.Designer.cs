﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SqlDataAccess.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ITAUTO-SERVER\\XFORM;Initial Catalog=KCZYS_LIMS;User ID=sa;Password=40" +
            "6ITAUTOitauto")]
        public string KCZYS_LIMSConnectionString {
            get {
                return ((string)(this["KCZYS_LIMSConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ITAUTO-SERVER\\XFORM;Initial Catalog=KCZYS_LIMS;User ID=sa;Pooling=Tru" +
            "e;Min Pool Size=50;Max Pool Size=30000;Load Balance Timeout=120")]
        public string KCZYS_LIMSConnectionString1 {
            get {
                return ((string)(this["KCZYS_LIMSConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ITAUTO-SERVER\\XFORM;Initial Catalog=KCZYS_LIMS;User ID=sa;Password=40" +
            "6ITAUTOitauto;Pooling=True;Min Pool Size=50;Max Pool Size=30000;Load Balance Tim" +
            "eout=120")]
        public string KCZYS_LIMSConnectionString2 {
            get {
                return ((string)(this["KCZYS_LIMSConnectionString2"]));
            }
        }
    }
}
