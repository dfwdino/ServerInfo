﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerInfo.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"SELECT Caption,CSName,InstallDate,LastBootUpTime,LocalDateTime,Version FROM Win32_OperatingSystem;SELECT HotFixID,InstalledOn FROM Win32_QuickFixEngineering;Select * from Win32_LogicalDisk where DriveType=3;select * from Win32_Share;Select Caption,State from Win32_Service;Select Name from Win32_NetworkProtocol;Select SystemUpTime From Win32_PerfFormattedData_PerfOS_System;select * from Win32_NetworkAdapterConfiguration Where IPEnabled = True;Select * from Win32_ComputerSystem")]
        public string WMIQuery {
            get {
                return ((string)(this["WMIQuery"]));
            }
        }
    }
}
