#pragma checksum "..\..\..\..\Pages\Settings_page.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2042985DFDA6CADE04A116B4EE018FE5970107A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Huber_Management.Pages;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Huber_Management.Pages {
    
    
    /// <summary>
    /// Settings_page
    /// </summary>
    public partial class Settings_page : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 77 "..\..\..\..\Pages\Settings_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Import_excel_btn;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\Pages\Settings_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Export_excel_btn;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\Pages\Settings_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Delete_excel_btn;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\..\Pages\Settings_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox price_convert_value;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\Pages\Settings_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox criticality_a;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\..\Pages\Settings_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox criticality_b;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\..\Pages\Settings_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox criticality_c;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\Pages\Settings_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit_settings;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\..\Pages\Settings_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save_changes;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\..\..\Pages\Settings_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_new_user;
        
        #line default
        #line hidden
        
        
        #line 251 "..\..\..\..\Pages\Settings_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel users_rows_panel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Huber-Management;component/pages/settings_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Settings_page.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\Pages\Settings_page.xaml"
            ((Huber_Management.Pages.Settings_page)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Import_excel_btn = ((System.Windows.Controls.Border)(target));
            
            #line 78 "..\..\..\..\Pages\Settings_page.xaml"
            this.Import_excel_btn.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Import_excel_btn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Export_excel_btn = ((System.Windows.Controls.Border)(target));
            
            #line 92 "..\..\..\..\Pages\Settings_page.xaml"
            this.Export_excel_btn.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Export_excel_btn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Delete_excel_btn = ((System.Windows.Controls.Border)(target));
            
            #line 106 "..\..\..\..\Pages\Settings_page.xaml"
            this.Delete_excel_btn.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Delete_excel_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.price_convert_value = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.criticality_a = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.criticality_b = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.criticality_c = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Edit_settings = ((System.Windows.Controls.Button)(target));
            
            #line 160 "..\..\..\..\Pages\Settings_page.xaml"
            this.Edit_settings.Click += new System.Windows.RoutedEventHandler(this.Edit_settings_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Save_changes = ((System.Windows.Controls.Button)(target));
            
            #line 177 "..\..\..\..\Pages\Settings_page.xaml"
            this.Save_changes.Click += new System.Windows.RoutedEventHandler(this.Save_changes_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Add_new_user = ((System.Windows.Controls.Button)(target));
            
            #line 208 "..\..\..\..\Pages\Settings_page.xaml"
            this.Add_new_user.Click += new System.Windows.RoutedEventHandler(this.Add_new_user_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.users_rows_panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

