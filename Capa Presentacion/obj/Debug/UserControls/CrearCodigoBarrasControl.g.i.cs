﻿#pragma checksum "..\..\..\UserControls\CrearCodigoBarrasControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E7F009E36E6373B862D1117281BAD7E758ABCE2E"
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
    /// CrearCodigoBarrasContorl
    /// </summary>
    public partial class CrearCodigoBarrasContorl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgCodigo;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAbrirEtiqueta;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbNumSerie;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEtiqueta;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btGenerar;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtEquipos;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.StatusBar statusBar;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Capa Presentacion;component/usercontrols/crearcodigobarrascontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
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
            
            #line 9 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
            ((Capa_Presentacion.UserControls.CrearCodigoBarrasContorl)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.imgCodigo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.btAbrirEtiqueta = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
            this.btAbrirEtiqueta.Click += new System.Windows.RoutedEventHandler(this.BtAbrirEtiqueta_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TbNumSerie = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
            this.TbNumSerie.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TbNumSerie_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbEtiqueta = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btGenerar = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
            this.btGenerar.Click += new System.Windows.RoutedEventHandler(this.BtGenerar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dtEquipos = ((System.Windows.Controls.DataGrid)(target));
            
            #line 39 "..\..\..\UserControls\CrearCodigoBarrasControl.xaml"
            this.dtEquipos.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DtEquipos_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.statusBar = ((System.Windows.Controls.Primitives.StatusBar)(target));
            return;
            case 9:
            this.tbStatusInformation = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

