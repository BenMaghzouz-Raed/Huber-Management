﻿#pragma checksum "..\..\..\..\..\Pages\Dashboard_page.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D77C7D13904994E304948628AA5D2121B4C47C34"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Huber_Management.Controls;
using Huber_Management.Pages;
using LiveCharts.Wpf;
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
    /// Dashboard_page
    /// </summary>
    public partial class Dashboard_page : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\..\..\Pages\Dashboard_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label total_tools;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\Pages\Dashboard_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock total_price;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\Pages\Dashboard_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label total_faulty;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\Pages\Dashboard_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label total_gain;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\..\Pages\Dashboard_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.MaterialCards InputChart;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\..\Pages\Dashboard_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Huber_Management.Controls.MaterialCards OutputChart;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\..\Pages\Dashboard_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Today_tasks_rows_panel;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\..\Pages\Dashboard_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Out_of_stock_Header;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\..\..\Pages\Dashboard_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Out_of_stock_rows_panel;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\..\..\Pages\Dashboard_page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel latest_history_rows_panel;
        
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
            System.Uri resourceLocater = new System.Uri("/Huber-Management;component/pages/dashboard_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Dashboard_page.xaml"
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
            this.total_tools = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.total_price = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.total_faulty = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.total_gain = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.InputChart = ((Huber_Management.Controls.MaterialCards)(target));
            return;
            case 6:
            this.OutputChart = ((Huber_Management.Controls.MaterialCards)(target));
            return;
            case 7:
            this.Today_tasks_rows_panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.Out_of_stock_Header = ((System.Windows.Controls.Border)(target));
            return;
            case 9:
            this.Out_of_stock_rows_panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.latest_history_rows_panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

