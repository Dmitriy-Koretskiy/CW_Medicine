﻿#pragma checksum "..\..\AdminMode.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6095CE73CFC01BCBF1A4A8782605FAFB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34014
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace CW_Medicine {
    
    
    /// <summary>
    /// AdminMode
    /// </summary>
    public partial class AdminMode : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\AdminMode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ShowResultDataGrid;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\AdminMode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button B_delete;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\AdminMode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button B_update;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AdminMode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button B_insert;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AdminMode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CW_Medicine;component/adminmode.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminMode.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ShowResultDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.B_delete = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\AdminMode.xaml"
            this.B_delete.Click += new System.Windows.RoutedEventHandler(this.B_delete_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.B_update = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\AdminMode.xaml"
            this.B_update.Click += new System.Windows.RoutedEventHandler(this.B_update_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.B_insert = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\AdminMode.xaml"
            this.B_insert.Click += new System.Windows.RoutedEventHandler(this.B_insert_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\AdminMode.xaml"
            this.CBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
