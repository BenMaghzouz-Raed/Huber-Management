#pragma checksum "..\..\..\..\..\..\Controls\Windows\Add_new_output_Window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E97D220BF96C825C3B6A23B772334BAC63115DCF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Huber_Management.Controls;
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


namespace Huber_Management.Controls {
    
    
    /// <summary>
    /// Add_new_output_Window
    /// </summary>
    public partial class Add_new_output_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\..\..\Controls\Windows\Add_new_output_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Add_reception_container;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\..\Controls\Windows\Add_new_output_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_new_tool;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\..\Controls\Windows\Add_new_output_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button return_btn;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\..\Controls\Windows\Add_new_output_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button next_btn;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\..\..\Controls\Windows\Add_new_output_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button confirm_btn;
        
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
            System.Uri resourceLocater = new System.Uri("/Huber-Management;component/controls/windows/add_new_output_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Controls\Windows\Add_new_output_Window.xaml"
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
            this.Add_reception_container = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.Add_new_tool = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\..\..\Controls\Windows\Add_new_output_Window.xaml"
            this.Add_new_tool.Click += new System.Windows.RoutedEventHandler(this.Add_new_tool_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.return_btn = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\..\..\Controls\Windows\Add_new_output_Window.xaml"
            this.return_btn.Click += new System.Windows.RoutedEventHandler(this.return_btn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.next_btn = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\..\..\Controls\Windows\Add_new_output_Window.xaml"
            this.next_btn.Click += new System.Windows.RoutedEventHandler(this.next_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.confirm_btn = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\..\..\..\Controls\Windows\Add_new_output_Window.xaml"
            this.confirm_btn.Click += new System.Windows.RoutedEventHandler(this.confirm_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

