﻿#pragma checksum "..\..\Conversation.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3A7102CC592429E2482763FF95ED69A3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MizyBureau;
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


namespace MizyBureau {
    
    
    /// <summary>
    /// Conversation
    /// </summary>
    public partial class Conversation : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\Conversation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Page_Profile;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Conversation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgFbLogo;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Conversation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgTwitter;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Conversation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgfille;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Conversation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtUser;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Conversation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtHint;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Conversation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_new;
        
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
            System.Uri resourceLocater = new System.Uri("/MizyBureau;component/conversation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Conversation.xaml"
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
            this.Page_Profile = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.imgFbLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.imgTwitter = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.imgfille = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.txtUser = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtHint = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.button_new = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\Conversation.xaml"
            this.button_new.Click += new System.Windows.RoutedEventHandler(this.addConv);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

