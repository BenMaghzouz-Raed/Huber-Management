﻿#pragma checksum "..\..\..\..\..\Pages\Purchase_order_page.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8F4331F2CD7F4D78586353A39C16860F1D2BA946"
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
    /// Purchase_order_page
    /// </summary>
    public partial class Purchase_order_page : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Nav_search_box;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox filter_combobox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox sort_by_combobox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton isDESC;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_tool_to_db;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Purchase_order_rows_panel;
        
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
            System.Uri resourceLocater = new System.Uri("/Huber-Management;component/pages/purchase_order_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
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
            
            #line 10 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
            ((Huber_Management.Pages.Purchase_order_page)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Load);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Nav_search_box = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
            this.Nav_search_box.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.InitializeAllData_Filters);
            
            #line default
            #line hidden
            return;
            case 3:
            this.filter_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 42 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
            this.filter_combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.InitializeAllData_Filters);
            
            #line default
            #line hidden
            return;
            case 4:
            this.sort_by_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 55 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
            this.sort_by_combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.InitializeAllData_Filters);
            
            #line default
            #line hidden
            return;
            case 5:
            this.isDESC = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 61 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
            this.isDESC.Click += new System.Windows.RoutedEventHandler(this.InitializeAllData_Filters);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 64 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Viewbox_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Add_tool_to_db = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\..\..\Pages\Purchase_order_page.xaml"
            this.Add_tool_to_db.Click += new System.Windows.RoutedEventHandler(this.Add_tool_to_db_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Purchase_order_rows_panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

