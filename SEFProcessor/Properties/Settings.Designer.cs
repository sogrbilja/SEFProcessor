//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEFProcessor.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://efaktura.mfin.gov.rs")]
        public string publicApiEndpoint {
            get {
                return ((string)(this["publicApiEndpoint"]));
            }
            set {
                this["publicApiEndpoint"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string APIKey {
            get {
                return ((string)(this["APIKey"]));
            }
            set {
                this["APIKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/publicApi/get-unit-measures")]
        public string API_getUnitMeasures {
            get {
                return ((string)(this["API_getUnitMeasures"]));
            }
            set {
                this["API_getUnitMeasures"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/publicApi/sales-invoice?invoiceId={0}")]
        public string API_salesInvoiceGet {
            get {
                return ((string)(this["API_salesInvoiceGet"]));
            }
            set {
                this["API_salesInvoiceGet"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/publicApi/sales-invoice/ubl")]
        public string API_salesInvoice_ubl {
            get {
                return ((string)(this["API_salesInvoice_ubl"]));
            }
            set {
                this["API_salesInvoice_ubl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://demoefaktura.mfin.gov.rs/")]
        public string sandboxApiEndpoint {
            get {
                return ((string)(this["sandboxApiEndpoint"]));
            }
            set {
                this["sandboxApiEndpoint"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string sandboxAPIKey {
            get {
                return ((string)(this["sandboxAPIKey"]));
            }
            set {
                this["sandboxAPIKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/publicApi/sales-invoice/cancel")]
        public string API_salesInvoice_cancel {
            get {
                return ((string)(this["API_salesInvoice_cancel"]));
            }
            set {
                this["API_salesInvoice_cancel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/publicApi/sales-invoice/storno")]
        public string API_salesInvoice_storno {
            get {
                return ((string)(this["API_salesInvoice_storno"]));
            }
            set {
                this["API_salesInvoice_storno"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/publicApi/purchase-invoice/changes?date={0}")]
        public string Api_purchaseInvoice_changes {
            get {
                return ((string)(this["Api_purchaseInvoice_changes"]));
            }
            set {
                this["Api_purchaseInvoice_changes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/api/publicApi/sales-invoice/changes?date={0}")]
        public string Api_salesInvoice_changes {
            get {
                return ((string)(this["Api_salesInvoice_changes"]));
            }
            set {
                this["Api_salesInvoice_changes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UpgradeRequired {
            get {
                return ((bool)(this["UpgradeRequired"]));
            }
            set {
                this["UpgradeRequired"] = value;
            }
        }
    }
}
