﻿#pragma checksum "..\..\..\..\Pages\Purchase_order_page.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BF667FA8D2C633CEFF4C71BEEDCA59E08985226E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Huber_Management.Controls;
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
        
        
        #line 34 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Nav_search_box;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox search_filter;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox filter_combobox;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Purchase;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.TableHeader_RadioBtn serial_id;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.TableHeader_RadioBtn actual_stock;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.TableHeader_RadioBtn min_stock;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.TableHeader_RadioBtn needed_quantity;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.TableHeader_RadioBtn total_nq;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.TableHeader_RadioBtn supplier;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.TableHeader_RadioBtn criticality;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox select_all;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer DataScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel All_tools_rows_panel;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock noDataFound;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\..\Pages\Purchase_order_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer LoadingIcon;
        
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
            
            #line 1 "..\..\..\..\Pages\Purchase_order_page.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 10 "..\..\..\..\Pages\Purchase_order_page.xaml"
            ((Huber_Management.Pages.Purchase_order_page)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Load);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Nav_search_box = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\..\Pages\Purchase_order_page.xaml"
            this.Nav_search_box.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.InitializeAllData_Filters);
            
            #line default
            #line hidden
            return;
            case 3:
            this.search_filter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 43 "..\..\..\..\Pages\Purchase_order_page.xaml"
            this.search_filter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.InitializeAllData_Filters);
            
            #line default
            #line hidden
            return;
            case 4:
            this.filter_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 59 "..\..\..\..\Pages\Purchase_order_page.xaml"
            this.filter_combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.InitializeAllData_Filters);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 68 "..\..\..\..\Pages\Purchase_order_page.xaml"
            ((System.Windows.Controls.Viewbox)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Viewbox_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Purchase = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\..\Pages\Purchase_order_page.xaml"
            this.Purchase.Click += new System.Windows.RoutedEventHandler(this.Purchase_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.serial_id = ((Huber_Management.Controls.TableHeader_RadioBtn)(target));
            return;
            case 8:
            this.actual_stock = ((Huber_Management.Controls.TableHeader_RadioBtn)(target));
            return;
            case 9:
            this.min_stock = ((Huber_Management.Controls.TableHeader_RadioBtn)(target));
            return;
            case 10:
            this.needed_quantity = ((Huber_Management.Controls.TableHeader_RadioBtn)(target));
            return;
            case 11:
            this.total_nq = ((Huber_Management.Controls.TableHeader_RadioBtn)(target));
            return;
            case 12:
            this.supplier = ((Huber_Management.Controls.TableHeader_RadioBtn)(target));
            return;
            case 13:
            this.criticality = ((Huber_Management.Controls.TableHeader_RadioBtn)(target));
            return;
            case 14:
            this.select_all = ((System.Windows.Controls.CheckBox)(target));
            
            #line 124 "..\..\..\..\Pages\Purchase_order_page.xaml"
            this.select_all.Checked += new System.Windows.RoutedEventHandler(this.select_all_Checked);
            
            #line default
            #line hidden
            
            #line 124 "..\..\..\..\Pages\Purchase_order_page.xaml"
            this.select_all.Unchecked += new System.Windows.RoutedEventHandler(this.select_all_Unchecked);
            
            #line default
            #line hidden
            return;
            case 15:
            this.DataScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 16:
            this.All_tools_rows_panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 17:
            this.noDataFound = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 18:
            this.LoadingIcon = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

