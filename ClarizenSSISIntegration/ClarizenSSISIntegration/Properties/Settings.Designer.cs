﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClarizenSSISIntegration.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Setting {
            get {
                return ((string)(this["Setting"]));
            }
            set {
                this["Setting"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\n          https://api.clarizen.com/v1.0/Clarizen.svc\r\n        ")]
        public string ClarizenSSISIntegration_ApiClarizenProxy_Clarizen {
            get {
                return ((string)(this["ClarizenSSISIntegration_ApiClarizenProxy_Clarizen"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Currency Type")]
        public string RevenueCurrencyType {
            get {
                return ((string)(this["RevenueCurrencyType"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_SFDC_Customer_Number {
            get {
                return ((string)(this["C_SFDC_Customer_Number"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_SFDC_Contact_Name {
            get {
                return ((string)(this["C_SFDC_Contact_Name"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_SFDC_Contact_Job_Title {
            get {
                return ((string)(this["C_SFDC_Contact_Job_Title"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_SFDC_Contact_Phone {
            get {
                return ((string)(this["C_SFDC_Contact_Phone"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_SFDC_Contact_Mobile {
            get {
                return ((string)(this["C_SFDC_Contact_Mobile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_SFDC_Contact_Email {
            get {
                return ((string)(this["C_SFDC_Contact_Email"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string SYSID {
            get {
                return ((string)(this["SYSID"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_SFDC_Opportunity_Number {
            get {
                return ((string)(this["C_SFDC_Opportunity_Number"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_SFDC__Customer_PO {
            get {
                return ((string)(this["C_SFDC__Customer_PO"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_SFDC_Sales_Rep_Name {
            get {
                return ((string)(this["C_SFDC_Sales_Rep_Name"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_SFDC_Sales_Rep_Number {
            get {
                return ((string)(this["C_SFDC_Sales_Rep_Number"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_SFDC_Source_of_Opp {
            get {
                return ((string)(this["C_SFDC_Source_of_Opp"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("User")]
        public string ProjectManager {
            get {
                return ((string)(this["ProjectManager"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string Name {
            get {
                return ((string)(this["Name"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.Double, mscorlib, Culture=neutral")]
        public string C_SFDC_Issue_adv_Payment_Percentage {
            get {
                return ((string)(this["C_SFDC_Issue_adv_Payment_Percentage"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.Double, mscorlib, Culture=neutral")]
        public string C_SFDC_OpportunityTotalBeforeDiscount {
            get {
                return ((string)(this["C_SFDC_OpportunityTotalBeforeDiscount"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.Double, mscorlib, Culture=neutral")]
        public string C_SFDC_Opportunity_Discount {
            get {
                return ((string)(this["C_SFDC_Opportunity_Discount"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.Double, mscorlib, Culture=neutral")]
        public string C_SFDC_OpportunityTotalAfterDiscount {
            get {
                return ((string)(this["C_SFDC_OpportunityTotalAfterDiscount"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_SFDC_Opportunity_Special_Comment {
            get {
                return ((string)(this["C_SFDC_Opportunity_Special_Comment"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C_GenericTaskOriginatedFrom")]
        public string C_OriginatedFrom {
            get {
                return ((string)(this["C_OriginatedFrom"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_ProductSFDCCode {
            get {
                return ((string)(this["C_ProductSFDCCode"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.Double, mscorlib, Culture=neutral")]
        public string C_ProductSFDCQuantity {
            get {
                return ((string)(this["C_ProductSFDCQuantity"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C_GenericTaskPricingUnit")]
        public string C_PricingUnit {
            get {
                return ((string)(this["C_PricingUnit"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.Double, mscorlib, Culture=neutral")]
        public string C_SFDCProductListPriceNew {
            get {
                return ((string)(this["C_SFDCProductListPriceNew"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C_GenericTaskPOState")]
        public string C_POState {
            get {
                return ((string)(this["C_POState"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string C_TranslatorPONumber {
            get {
                return ((string)(this["C_TranslatorPONumber"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.Double, mscorlib, Culture=neutral")]
        public string C_TotalPO {
            get {
                return ((string)(this["C_TotalPO"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C_GenericTaskPricingCurrency")]
        public string C_PricingCurrency {
            get {
                return ((string)(this["C_PricingCurrency"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string OrderID {
            get {
                return ((string)(this["OrderID"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("User")]
        public string Manager {
            get {
                return ((string)(this["Manager"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string DisplayName {
            get {
                return ((string)(this["DisplayName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string Email {
            get {
                return ((string)(this["Email"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string BusinessAddress {
            get {
                return ((string)(this["BusinessAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C_UserTCountry")]
        public string C_TCountry {
            get {
                return ((string)(this["C_TCountry"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string OfficePhone {
            get {
                return ((string)(this["OfficePhone"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System.String, mscorlib, Culture=neutral")]
        public string MobilePhone {
            get {
                return ((string)(this["MobilePhone"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C_UserCurrency")]
        public string C_Currency {
            get {
                return ((string)(this["C_Currency"]));
            }
        }
    }
}
