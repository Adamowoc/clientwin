﻿#pragma checksum "..\..\Inscription.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "82444B7EFA480C91B97466B485C87BA4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
    /// Inscription
    /// </summary>
    public partial class Inscription : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtConnexion;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock aide;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox boxIdentifiant;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pboxPwd;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pboxPwd2;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox boxEmail;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button validation;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Inscription.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button annulation;
        
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
            System.Uri resourceLocater = new System.Uri("/MizyBureau;component/inscription.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Inscription.xaml"
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
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.txtConnexion = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.aide = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.boxIdentifiant = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\Inscription.xaml"
            this.boxIdentifiant.GotFocus += new System.Windows.RoutedEventHandler(this.Id_GotFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.pboxPwd = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 16 "..\..\Inscription.xaml"
            this.pboxPwd.GotFocus += new System.Windows.RoutedEventHandler(this.Pwd1_GotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.pboxPwd2 = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 17 "..\..\Inscription.xaml"
            this.pboxPwd2.GotFocus += new System.Windows.RoutedEventHandler(this.Pwd2_GotFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.boxEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\Inscription.xaml"
            this.boxEmail.GotFocus += new System.Windows.RoutedEventHandler(this.Email_GotFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.validation = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Inscription.xaml"
            this.validation.Click += new System.Windows.RoutedEventHandler(this.RegisterUser);
            
            #line default
            #line hidden
            return;
            case 9:
            this.annulation = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Inscription.xaml"
            this.annulation.Click += new System.Windows.RoutedEventHandler(this.Connection_Load);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

