﻿#pragma checksum "..\..\..\VentanasModales\ConfirmarSalir.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2AC6C311166A80F26A115C82A64B3CDBEB7C921D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Capa_Presentacion;
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


namespace Capa_Presentacion {
    
    
    /// <summary>
    /// ConfirmarSalir
    /// </summary>
    public partial class ConfirmarSalir : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gBar;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel gBody;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbText;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btSalir;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btNoSalir;
        
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
            System.Uri resourceLocater = new System.Uri("/Capa Presentacion;component/ventanasmodales/confirmarsalir.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
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
            
            #line 8 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
            ((Capa_Presentacion.ConfirmarSalir)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
            ((Capa_Presentacion.ConfirmarSalir)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gBar = ((System.Windows.Controls.Grid)(target));
            
            #line 19 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
            this.gBar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.gBar_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.gBody = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.tbText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btSalir = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
            this.btSalir.Click += new System.Windows.RoutedEventHandler(this.btSalir_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btNoSalir = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\VentanasModales\ConfirmarSalir.xaml"
            this.btNoSalir.Click += new System.Windows.RoutedEventHandler(this.btNoSalir_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

