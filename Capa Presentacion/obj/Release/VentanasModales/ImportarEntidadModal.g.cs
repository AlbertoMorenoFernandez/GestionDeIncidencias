﻿#pragma checksum "..\..\..\VentanasModales\ImportarEntidadModal.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F82C658F0CE075AA35F42D8BDC6C627A03C0F2BE"
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
    /// impUserModal
    /// </summary>
    public partial class impUserModal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\VentanasModales\ImportarEntidadModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbImportar;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\VentanasModales\ImportarEntidadModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgImportar;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\VentanasModales\ImportarEntidadModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAñadir;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\VentanasModales\ImportarEntidadModal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/Capa Presentacion;component/ventanasmodales/importarentidadmodal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\VentanasModales\ImportarEntidadModal.xaml"
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
            this.lbImportar = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.dgImportar = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.btAñadir = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\VentanasModales\ImportarEntidadModal.xaml"
            this.btAñadir.Click += new System.Windows.RoutedEventHandler(this.BtAñadir_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\VentanasModales\ImportarEntidadModal.xaml"
            this.btCancelar.Click += new System.Windows.RoutedEventHandler(this.BtCancelar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

