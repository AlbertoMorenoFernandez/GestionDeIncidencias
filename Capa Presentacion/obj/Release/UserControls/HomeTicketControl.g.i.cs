﻿#pragma checksum "..\..\..\UserControls\HomeTicketControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A4A7B7BDE5E9003A64483F9BC37337428FE107B3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Capa_Presentacion.UserControls;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Capa_Presentacion.UserControls {
    
    
    /// <summary>
    /// HomeTicketControl
    /// </summary>
    public partial class HomeTicketControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\UserControls\HomeTicketControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid panelPrincipal;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UserControls\HomeTicketControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbInformacion;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\UserControls\HomeTicketControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTickets;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\UserControls\HomeTicketControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgEstado;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UserControls\HomeTicketControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvNotificaciones;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControls\HomeTicketControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel bdValorar;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\UserControls\HomeTicketControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel btValorar;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\UserControls\HomeTicketControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbFechaLimite;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\UserControls\HomeTicketControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBar statusBar;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\UserControls\HomeTicketControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbStatusInformation;
        
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
            System.Uri resourceLocater = new System.Uri("/Capa Presentacion;component/usercontrols/hometicketcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\HomeTicketControl.xaml"
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
            this.panelPrincipal = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.lbInformacion = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.cbTickets = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\..\UserControls\HomeTicketControl.xaml"
            this.cbTickets.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbTickets_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.imgEstado = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.lvNotificaciones = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.bdValorar = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.btValorar = ((System.Windows.Controls.StackPanel)(target));
            
            #line 37 "..\..\..\UserControls\HomeTicketControl.xaml"
            this.btValorar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BtValorar_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tbFechaLimite = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.statusBar = ((System.Windows.Controls.Primitives.StatusBar)(target));
            return;
            case 10:
            this.tbStatusInformation = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

