﻿#pragma checksum "..\..\..\UserView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F63DDAA634F817AE947A9A7300EF99A4F1BC8E90"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Zeiterfassungssystem;


namespace Zeiterfassungssystem {
    
    
    /// <summary>
    /// UserView
    /// </summary>
    public partial class UserView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UserWelcomeLabel;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UserLogoutButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button KommenButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GehenButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label AktuelleZeitUserView;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UserTimeState;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatumUser;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Zeiterfassungssystem;component/userview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UserWelcomeLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.UserLogoutButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\UserView.xaml"
            this.UserLogoutButton.Click += new System.Windows.RoutedEventHandler(this.UserLogoutButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.KommenButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\UserView.xaml"
            this.KommenButton.Click += new System.Windows.RoutedEventHandler(this.KommenButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GehenButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\UserView.xaml"
            this.GehenButton.Click += new System.Windows.RoutedEventHandler(this.GehenButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AktuelleZeitUserView = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.UserTimeState = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.DatumUser = ((System.Windows.Controls.DatePicker)(target));
            
            #line 19 "..\..\..\UserView.xaml"
            this.DatumUser.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DatePicker_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

