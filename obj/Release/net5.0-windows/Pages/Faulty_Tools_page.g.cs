﻿#pragma checksum "..\..\..\..\Pages\Faulty_Tools_page.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9E21DFF515808B51DB14578EF5998B5E9B59ABE5"
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
    /// Faulty_Tools_page
    /// </summary>
    public partial class Faulty_Tools_page : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Nav_search_box;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox search_filter;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox when_combobox;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox by_who_combobox;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_faulty_tool;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.TableHeader_RadioBtn serial_id;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.TableHeader_RadioBtn quantity;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.TableHeader_RadioBtn total_price;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.TableHeader_RadioBtn faulty_by;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.TableHeader_RadioBtn date;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer DataScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Faulty_rows_panel;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock noDataFound;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Huber-Management;component/pages/faulty_tools_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
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
            
            #line 9 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
            ((Huber_Management.Pages.Faulty_Tools_page)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Load);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Nav_search_box = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
            this.Nav_search_box.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.InitializeAllData_Filters);
            
            #line default
            #line hidden
            return;
            case 3:
            this.search_filter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 44 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
            this.search_filter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.InitializeAllData_Filters);
            
            #line default
            #line hidden
            return;
            case 4:
            this.when_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 60 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
            this.when_combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.InitializeAllData_Filters);
            
            #line default
            #line hidden
            return;
            case 5:
            this.by_who_combobox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 74 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
            this.by_who_combobox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.InitializeAllData_Filters);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Add_faulty_tool = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\..\Pages\Faulty_Tools_page.xaml"
            this.Add_faulty_tool.Click += new System.Windows.RoutedEventHandler(this.Add_faulty_tool_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.serial_id = ((Huber_Management.Controls.TableHeader_RadioBtn)(target));
            return;
            case 8:
            this.quantity = ((Huber_Management.Controls.TableHeader_RadioBtn)(target));
            return;
            case 9:
            this.total_price = ((Huber_Management.Controls.TableHeader_RadioBtn)(target));
            return;
            case 10:
            this.faulty_by = ((Huber_Management.Controls.TableHeader_RadioBtn)(target));
            return;
            case 11:
            this.date = ((Huber_Management.Controls.TableHeader_RadioBtn)(target));
            return;
            case 12:
            this.DataScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 13:
            this.Faulty_rows_panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 14:
            this.noDataFound = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            this.LoadingIcon = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

