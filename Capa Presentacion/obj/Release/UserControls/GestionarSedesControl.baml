   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  1    +Capa_Presentacion.UserControls.SedesControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  8local,clr-namespace:Capa_Presentacion.UserControls    � 	Resources  5   /Capa_Presentacion.UserControls.ConvertLocalidad   LocalidadConverter��%   &	          .��� -   $��	gdGeneral��
������� � DataContext ��  � RowDefinitions �� $��80 ��� $��90 ��� $��90 ��� $��80 ��� $	��430 ��� $��60 ��� $��50 �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $��../Imagenes/tuerca.png���� -   $��tbTitulo�� 
 titulo#��[ $��Center=�GESTIÓN DE SEDES�� $��1��$ 
Horizontal=�.+��� $ Vertical=�$��	70,20,0,0q�.+���   
labelTitle#��[ .��	Calle *�� -   $��tbCalle�� �� 	MaxLength$ 90��  textbox#��[ $	��400������ *Calle+ �� Mode$ TwoWay=��� $ Vertical=�$��	80,20,0,0q�.+��� #��[ .��
Planta *�� -   $��tbPlanta��$ 2��#��[ ���� *Planta+$ TwoWay=��� $ Vertical=�$��	60,20,0,0q�.+��� #��[ .��Código Postal *�� -   $��tbCodigoPostal��$ 5��#��[ ���� *CodigoPostal+$ TwoWay=��� $��2��$ 
Horizontal=�.+��� $ Vertical=�$��	70,20,0,0q�.+��� #��[ .��Localidad *�� -   $��cbLocalidad��$
��Left=�$	��200��$��30������ �� -   $��tbLocalidad��$y�	Collapsed=����� *	Localidad+$ TwoWay=��� $��Center=�$��3��$ 
Horizontal=�.+��� -   $��panelInformacion��$	��570��$y�Hidden=�$��70��$��70,0,0,0q�
�������$��1q� �� CornerRadius$ 10�����#d8e9e7._��� $ 
Horizontal=�.+��� $��../Imagenes/info.png��$��10q�$��40���� $
��Wrap=�$	��500��$��20,10q�][Los campos que deje en blanco o no modifique permanecerán sin cambios en la base de datos.�� -	   $��btImportarCSV��  RegularButton#��[ $��10,10,30,10q�.���� $ 
Horizontal=�.+��� $��../Imagenes/csv.png���� 
�����p�$��14(�$��Bottom=�.���� .��_IMPORTAR .CSV�� -
    ��Name$ 	btAgregar��#��[ .���� .��
_AGREGAR�� -   $��panelEditar��$��4��.+��� $ 
Horizontal=�.+��� $��70,10,10,10q�#��[ .��Buscar Sede:�� -   $��tbBuscarSede��$	��300��
�������$��2q�$��30��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$* $Introduzca calle de la sede a buscar���� -   $��btBuscarSede��$��30��$��10q�$��1q�
�������
������ $
��Left=�.���� .+��� $��../Imagenes/find.png��$��25��$��25��$
��Fill=�&   System.Windows.Controls.DataGrid  -   $��dgSedes��	   AutoGenerateColumns	 .  
   CanUserDeleteRows
 .     CanUserAddRows .  $	��300��$��70,10q�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Calle��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 400    
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Calle+  $ Planta��$	 100  .  �� *Planta+  $ Código Postal��$	 150  .  �� *CodigoPostal+  $ 	Localidad��$	 200  .  �� *	Localidad+4  .System.Windows.Controls.DataGridTemplateColumn  $ Editar��$ 80  .    CellTemplate �� .R��� $��btEditar��-   
������ .���� $��25��$"��../Imagenes/editarTicket.png���� $ 
Horizontal=�$��854,10,0,10q�.+��� -   $��btExportarCSV��#��[ $��10,10,70,10q�.���� $ 
Horizontal=�.+��� $��../Imagenes/csv.png���� 
�����p�.���� .��_EXPORTAR A CSV�� -   $��panelVolver��$��5��$��Right=�.+��� -   $��btVolver��$y�Hidden=�$��50,10q�#��[ .���� .��	_VOLVER�� -   $��	statusBar��
�������$��6��$��50��.@��� -   $��tbStatusInformation��
�������$��10q�