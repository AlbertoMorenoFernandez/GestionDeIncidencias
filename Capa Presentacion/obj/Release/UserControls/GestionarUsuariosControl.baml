   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  4    .Capa_Presentacion.UserControls.UsuariosControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  8local,clr-namespace:Capa_Presentacion.UserControls    � 	Resources     SalmonColor �� Color/   )Capa_Presentacion.UserControls.ConvertRol  myRolConverter2   ,Capa_Presentacion.UserControls.ConvertIdSede  sedeConverter��%;   &	        &	      &	      �� $ #d8e9e7��    .��� -   $��	gdGeneral��
������� � DataContext ��  � RowDefinitions �� $��80 ��� $��90 ��� $��90 ��� $��80 ��� $	��430 ��� $��60 ��� $��50 �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $��../Imagenes/tuerca.png���� -   $��tbTitulo�� 
 titulo#��[ $��Center=�GESTIÓN DE USUARIOS�� $��1��$ 
Horizontal=�.+��� $ Vertical=�$��	70,20,0,0q�.+���   
labelTitle#��[ .��
Nombre *�� -   $��tbNombre�� �� 	MaxLength$ 50��  textbox#��[ ���� *Nombre+ �� Mode$ TwoWay=��� $ Vertical=�$��	52,20,0,0q�.+��� #��[ .��Apellidos *�� -   $��tbApellidos��$ 50��#��[ ���� *	Apellidos+$ TwoWay=��� $ Vertical=�$��	52,20,0,0q�.+��� #��[ .��Correo Electrónico *�� -   $��tbCorreo��$ 50��#��[ ���� *Mail+$ TwoWay=��� $ Vertical=�$��	57,20,0,0q�.+��� #��[ .��Extensión *�� -   $��tbExtension��$ 4��#��[ ���� *	Extension+$ TwoWay=��� $��2��$ 
Horizontal=�.+��� $ Vertical=�$	��200��$��	70,20,0,0q�.+��� #��[ .��
Password *G� -   $��
pwPassword��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ *****��$��30���� -   $��
tbPassword��$y�	Collapsed=����� *
Password+$ TwoWay=��� $ Vertical=�$	��200��$��	52,20,0,0q�.+��� #��[ .��Repetir Password*G� -	   $��pwRepeat��$ *****��$��30���� $ Vertical=�$��	52,20,0,0q�.+��� #��[ .��	Oficina *�� -
   $��	cbOficina��$
��Left=�$	��200��$��30������ �� -   $��	tbOficina��$y�	Collapsed=����� *
NumOficina+$ TwoWay=��� $ Vertical=�$��	57,20,0,0q�.+��� #��[ .��Rol *�� -   $��cbRoles��$
��Left=�$	��200��$��30������  �� SelectedIndex �� 	 �� Path$	 Usuario.RolUsuario�$ TwoWay=��� -   $��tbRol��$y�	Collapsed=����� *
RolUsuario+$ TwoWay=��� $��Center=�$��3��$ 
Horizontal=�.+��� -   $��panelInformacion��$	��585��$y�Hidden=�$��70��$��70,0,0,0q�
�������$��1q�
 �� CornerRadius$
 10�����#d8e9e7._��� $ 
Horizontal=�.+��� $��../Imagenes/info.png��$��10q�$��40���� $
��Wrap=�$	��500��$��20,10q�][Los campos que deje en blanco o no modifique permanecerán sin cambios en la base de datos.�� -   $��btImportarCSV��  RegularButton#��[ $��10,10,30,10q�.���� $ 
Horizontal=�.+��� $��../Imagenes/csv.png���� 
�����p�$��14(�$��Bottom=�.���� .��_IMPORTAR .CSV�� -   $��	btAgregar��#��[ .���� .��
_AGREGAR�� -   $��panelEditar��$��4��.+��� $ 
Horizontal=�.+��� $��70,10,10,10q�#��[ .��Buscar Usuario:�� -   $��tbBuscarUsuario��$	��300��$ 
Por nombre��
�������$��2q�$��30���� -   $��btBuscarUsuario��$��30��$��10q�$��1q�
�������
������ $
��Left=�.���� .+��� $��../Imagenes/find.png��$��25��$��25��$
��Fill=��� -   $��cbBuscarSede��$��10q�$	��300������ &   System.Windows.Controls.DataGrid  -   $��	dgUsuario��   AutoGenerateColumns .     CanUserDeleteRows .     CanUserAddRows .  $	��300��$��70,10q�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	UsuarioId��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 85    
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	UsuarioId+  $ Nombre��$ 90  .  �� *Nombre+  $ 	Apellidos��$	 160  .  �� *	Apellidos+  $ 	Extension��$	 100  .  �� *	Extension+  $ E-mail��$	 170  .  �� *Mail+  $ Oficina��$	 170  .  �� *
NumOficina+ �� 	Converter# [   $	 Rol��$ 70  .  �� *
RolUsuario+4	  .System.Windows.Controls.DataGridTemplateColumn	  $ Editar��$ 80  .  	  CellTemplate �� .R��� $��btEditar��-   
������ .���� $��25��$"��../Imagenes/editarTicket.png���� $ 
Horizontal=�$��850,10,0,10q�.+��� -   $��btExportarCSV��#��[ $��10,10,70,10q�.���� $ 
Horizontal=�.+��� $��../Imagenes/csv.png���� 
�����p�.��EXPORTAR A CSV�� -   $��panelVolver��$��5��$��Right=�.+��� -   $��btVolver��$y�Hidden=�$��50,10q�#��[ .���� .��	_VOLVER�� -   $��	statusBar��
�������$��6��$��50��.@��� -   $��tbStatusInformation��
�������$��10q�