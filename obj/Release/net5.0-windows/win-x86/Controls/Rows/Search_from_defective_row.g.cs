﻿#pragma checksum "..\..\..\..\..\..\Controls\Rows\Search_from_defective_row.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96D35AB9F585E75E63A909CD308D18F3F7FB0877"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
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
    /// Search_from_defective_row
    /// </summary>
    public partial class Search_from_defective_row : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\..\..\Controls\Rows\Search_from_defective_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Tool_row_element;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\Controls\Rows\Search_from_defective_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label defective_id;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\..\Controls\Rows\Search_from_defective_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton tool_radio_btn;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\..\Controls\Rows\Search_from_defective_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image tool_image;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\..\Controls\Rows\Search_from_defective_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label tool_serial_id;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\..\Controls\Rows\Search_from_defective_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label defective_quantity;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\..\Controls\Rows\Search_from_defective_row.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tool_designation;
        
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
            System.Uri resourceLocater = new System.Uri("/Huber-Management;component/controls/rows/search_from_defective_row.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Controls\Rows\Search_from_defective_row.xaml"
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
            
            #line 27 "..\..\..\..\..\..\Controls\Rows\Search_from_defective_row.xaml"
            this.Tool_row_element.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Tool_row_element_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.defective_id = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.tool_radio_btn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 40 "..\..\..\..\..\..\Controls\Rows\Search_from_defective_row.xaml"
            this.tool_radio_btn.Checked += new System.Windows.RoutedEventHandler(this.tool_radio_btn_Checked);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\..\..\..\Controls\Rows\Search_from_defective_row.xaml"
            this.tool_radio_btn.Unchecked += new System.Windows.RoutedEventHandler(this.tool_radio_btn_Unchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tool_image = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.tool_serial_id = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.defective_quantity = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.tool_designation = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
