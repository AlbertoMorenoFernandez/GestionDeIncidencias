﻿#pragma checksum "..\..\..\UserControls\ticketsPendientescontrol.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B46029194FDE03A8007FD5CAF700B41DF11CE219"
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
using De.TorstenMandelkow.MetroChart;
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
    /// ticketsPendientescontrol
    /// </summary>
    public partial class ticketsPendientescontrol : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 14 "..\..\..\UserControls\ticketsPendientescontrol.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gdTickets;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\UserControls\ticketsPendientescontrol.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgTickesPendientes;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\UserControls\ticketsPendientescontrol.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbNumTicket;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\UserControls\ticketsPendientescontrol.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panelGraficas;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\UserControls\ticketsPendientescontrol.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal De.TorstenMandelkow.MetroChart.ClusteredColumnChart columnGrap;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\UserControls\ticketsPendientescontrol.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal De.TorstenMandelkow.MetroChart.RadialGaugeChart pieChart;
        
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
            System.Uri resourceLocater = new System.Uri("/Capa Presentacion;component/usercontrols/ticketspendientescontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\ticketsPendientescontrol.xaml"
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
            this.gdTickets = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.dgTickesPendientes = ((System.Windows.Controls.DataGrid)(target));
            
            #line 26 "..\..\..\UserControls\ticketsPendientescontrol.xaml"
            this.dgTickesPendientes.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.DgTickesPendientes_LoadingRow);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbNumTicket = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.panelGraficas = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.columnGrap = ((De.TorstenMandelkow.MetroChart.ClusteredColumnChart)(target));
            return;
            case 7:
            this.pieChart = ((De.TorstenMandelkow.MetroChart.RadialGaugeChart)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 35 "..\..\..\UserControls\ticketsPendientescontrol.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbTecnicos_SelectionChanged);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

