   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      4    .Capa_Presentacion.UserControls.UsuariosControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      8local,clr-namespace:Capa_Presentacion.UserControls  5        � 	Resources  5
         SalmonColor �� Color/   )Capa_Presentacion.UserControls.ConvertRol  myRolConverter2   ,Capa_Presentacion.UserControls.ConvertIdSede  sedeConverter��%j   &	        &	 &     &	 9     �� 5   
   $ #d8e9e7��6.   6@     5   
   64     5   
   66   5      .��5      � -   5        $��	gdGeneral��5      
������� � DataContext 6/   ��  � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $��90 �6   6*   �� 5      $��90 �6   6*   �� 5      $��80 �6   6*   �� 5      $	��430 �6   6+   �� 5      $��60 �6   6*   �� 5      $��50 �6   6*   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6#   .+�5      �� $��../Imagenes/tuerca.png��6   66   �� 5      -   5        $��tbTitulo��5       
 titulo#��[ 6(   $��Center=�6H   GESTIÓN DE USUARIOS6x   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   .+�5      �� $ Vertical=�6   $��	70,20,0,0q�60   .+�5      ��   
labelTitle#��[ 6   .��6<   
Nombre *6F   �� 5       -   5        $��tbNombre��5        �� 	MaxLength$ 50��6*     textbox#��[ 6:   ��6\   �� *Nombre+ �� Mode$ TwoWay=�6�   5!      �� 5"      $ Vertical=�6   $��	52,20,0,0q�60   .+�5#      �� #��[ 6   .��6<   Apellidos *6I   �� 5$      -   5        $��tbApellidos��5$      $ 50��6-   #��[ 6d   ��6<   �� *	Apellidos+$ TwoWay=�6�   5%      �� 5&      $ Vertical=�6   $��	52,20,0,0q�60   .+�5'      �� #��[ 6   .��6<   Correo Electrónico *6R   �� 5(      -   5        $��tbCorreo��5(      $ 50��6+   #��[ 6]   ��6:   �� *Mail+$ TwoWay=�6�   5)      �� 5*      $ Vertical=�6   $��	57,20,0,0q�60   .+�5+      �� #��[ 6   .��6<   Extensión *6I   �� 5,      -   5        $��tbExtension��5,      $ 4��6-   #��[ 6c   ��6;   �� *	Extension+$ TwoWay=�6�   5-      5.      �� 5/   
   $��2��6   $ 
Horizontal=�6"   .+�50      �� $ Vertical=�6   $	��200��60   $��	70,20,0,0q�6<   .+�51      �� #��[ 6   .��6<   
Password *6H   G� 52      -   5        $��
pwPassword��52      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ *****��61   $��30��6X   6g   �� 53      -   5        $��
tbPassword��53      $y�	Collapsed=�6U   ��6.   �� *
Password+$ TwoWay=�6n   54      �� 55      $ Vertical=�6   $	��200��61   $��	52,20,0,0q�6=   .+�56      �� #��[ 6   .��6<   Repetir Password*6O   G� 57      -	   5        $��pwRepeat��57      $ *****��6/   $��30��6V   6d   58      �� 59      $ Vertical=�6   $��	52,20,0,0q�60   .+�5:      �� #��[ 6   .��6<   	Oficina *6G   �� 5;      -
   5        $��	cbOficina��5;      $
��Left=�6D   $	��200��6_   $��30��6k   ��6,   �� 6�   �� 5<      -   5        $��	tbOficina��5<      $y�	Collapsed=�6V   ��6-   �� *
NumOficina+$ TwoWay=�6o   5=      �� 5>      $ Vertical=�6   $��	57,20,0,0q�60   .+�5?      �� #��[ 6   .��6<   Rol *6C   �� 5@      -   5        $��cbRoles��5@      $
��Left=�6�   $	��200��6�   $��30��6�   ��6*   ��  �� SelectedIndex 6B   �� 	 �� Path$	 Usuario.RolUsuario�$ TwoWay=�6�   �� 5A      -   5        $��tbRol��5A      $y�	Collapsed=�6)   ��6@   �� *
RolUsuario+$ TwoWay=�6k   5B      5C      �� 5D   
   $��Center=�6   $��3��63   $ 
Horizontal=�6@   .+�5E      �� -   5        $��panelInformacion��5E   !   $	��585��6   $y�Hidden=�69   $��70��6M   $��70,0,0,0q�6Y   
�������$��1q�6�   
 �� CornerRadius$
 10��6�   ���#d8e9e7._�5F      �� $ 
Horizontal=�6   .+�5G      �� $��../Imagenes/info.png��6   $��10q�6:   $��40��6F   6S   �� 5H      $
��Wrap=�6    $	��500��64   $��20,10q�6@   ][Los campos que deje en blanco o no modifique permanecerán sin cambios en la base de datos.6�   5I      5K      �� 5L      -   5        $��btImportarCSV��5L        RegularButton#��[ 6F   $��10,10,30,10q�6m   .��5M      �� $ 
Horizontal=�6   .+�5N      �� $��../Imagenes/csv.png��6   6;   �� 5O      
�����p�$��14(�63   $��Bottom=�6A   .��5P      �� .��6%   _IMPORTAR .CSV65   6B   5Q      5R      �� 5S      -   5        $��	btAgregar��5S      #��[ 6>   .��5T      �� .��6   
_AGREGAR6'   64   5U      �� 5V   
   -   5        $��panelEditar��5V      $��4��6)   .+�5W      �� $ 
Horizontal=�6   .+�5X      �� $��70,10,10,10q�6   #��[ 6.   .��6S   Buscar Usuario:6d   �� 5Y      -   5        $��tbBuscarUsuario��5Y      $	��300��61   $ 
Por nombre��6=   
�������$��2q�6�   $��30��6�   6�   �� 5Z      -   5        $��btBuscarUsuario��5Z      $��30��6O   $��10q�6[   $��1q�6g   
�������
������ $
��Left=�6�   .��5[      �� .+�5\      �� $��../Imagenes/find.png��6    $��25��6>   $��25��6I   $
��Fill=�6U   6g   5]      5^      �� 5_      -   5        $��cbBuscarSede��5_   '   $��10q�6   $	��300��6S   ��6;   �� 6a   5`      &   System.Windows.Controls.DataGrid  5a      -   5        $��	dgUsuario��5a         AutoGenerateColumns .     CanUserDeleteRows .     CanUserAddRows .  $	��300��6�   $��70,10q�6�   ��6D   ��    Columns 5b      0  *System.Windows.Controls.DataGridTextColumn  5c      ,  &System.Windows.Controls.DataGridColumn   Header$ 	UsuarioId��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$ 85 6=      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *	UsuarioId+6z     5d      $ Nombre��6)   $ 90 69    .  6D   �� *Nombre+6t     5e      $ 	Apellidos��6)   $	 160 6<    .  6H   �� *	Apellidos+6~     5f      $ 	Extension��6)   $	 100 6<    .  6H   �� *	Extension+6{     5g      $ E-mail��6)   $	 170 69    .  6E   �� *Mail+6s     5h      $ Oficina��6)   $	 170 6:    .  6F   �� *
NumOficina+ �� 	Converter# [ 6�     5i      $	 Rol��6)   $ 70 66    .  6A   �� *
RolUsuario+6u   4	  .System.Windows.Controls.DataGridTemplateColumn	  5j      $ Editar��6-   $ 80 6=    .  	  CellTemplate 5k      �� 5l      .R�5m   "   �� $��btEditar��6)   -   5        
������ .��5n   &   �� $��25��6,   $"��../Imagenes/editarTicket.png��67   6_   5o   #   5p      5r      5t      �� 5u      $ 
Horizontal=�6   $��850,10,0,10q�62   .+�5v      �� -   5        $��btExportarCSV��5v      #��[ 6J   $��10,10,70,10q�6q   .��5w      �� $ 
Horizontal=�6!   .+�5x      �� $��../Imagenes/csv.png��6!   6@   �� 5y      
�����p�.��67   EXPORTAR A CSV6G   5z      5{      5|      5}      �� 5~   
   -   5        $��panelVolver��5~   >   $��5��6   $��Right=�6"   .+�5      �� -   5        $��btVolver��5   w   $y�Hidden=�6   $��50,10q�6A   #��[ 6P   .��5�      �� .��6   	_VOLVER6&   5�      5�      �� 5�   
   -   5        $��	statusBar��5�   9   
�������$��6��6,   $��50��6J   .@�5�      �� -   5        $��tbStatusInformation��5�   +   
�������$��10q�6F   6T   5�      5�      5�      