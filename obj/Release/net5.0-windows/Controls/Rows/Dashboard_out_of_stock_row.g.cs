﻿#pragma checksum "..\..\..\..\..\Controls\Rows\Dashboard_out_of_stock_row.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C37917CC3E7B4D26732760079C70AD844055437B"
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


namespace Huber_Management.Controls {
    
    
    /// <summary>
    /// Dashboard_out_of_stock_row
    /// </summary>
    public partial class Dashboard_out_of_stock_row : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\..\Controls\Rows\Dashboard_out_of_stock_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Tool_row_element;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Controls\Rows\Dashboard_out_of_stock_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuItem_viewDetails;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\Controls\Rows\Dashboard_out_of_stock_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tools_row_serial_id;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\Controls\Rows\Dashboard_out_of_stock_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label tools_row_actual_stock;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\Controls\Rows\Dashboard_out_of_stock_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label tools_row_needed_quantity;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\Controls\Rows\Dashboard_out_of_stock_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label tools_row_total_nq;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\Controls\Rows\Dashboard_out_of_stock_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label tools_row_supplier;
        
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
            System.Uri resourceLocater = new System.Uri("/Huber-Management;component/controls/rows/dashboard_out_of_stock_row.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Controls\Rows\Dashboard_out_of_stock_row.xaml"
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
            this.Tool_row_element = ((System.Windows.Controls.Border)(target));
            
            #line 28 "..\..\..\..\..\Controls\Rows\Dashboard_out_of_stock_row.xaml"
            this.Tool_row_element.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Tool_row_element_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MenuItem_viewDetails = ((System.Windows.Controls.MenuItem)(target));
            
            #line 32 "..\..\..\..\..\Controls\Rows\Dashboard_out_of_stock_row.xaml"
            this.MenuItem_viewDetails.Click += new System.Windows.RoutedEventHandler(this.MenuItem_viewDetails_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tools_row_serial_id = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.tools_row_actual_stock = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.tools_row_needed_quantity = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.tools_row_total_nq = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.tools_row_supplier = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

