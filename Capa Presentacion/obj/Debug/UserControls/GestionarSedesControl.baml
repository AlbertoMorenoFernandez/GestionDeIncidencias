   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      1    +Capa_Presentacion.UserControls.SedesControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      8local,clr-namespace:Capa_Presentacion.UserControls  5        � 	Resources  5
      5   /Capa_Presentacion.UserControls.ConvertLocalidad   LocalidadConverter��%   &	          5   
   6>   5      .��5      � -   5        $��	gdGeneral��5      
������� � DataContext 6/   ��  � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $��90 �6   6*   �� 5      $��90 �6   6*   �� 5      $��80 �6   6*   �� 5      $	��430 �6   6+   �� 5      $��60 �6   6*   �� 5      $��50 �6   6*   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6#   .+�5      �� $��../Imagenes/tuerca.png��6   66   �� 5      -   5        $��tbTitulo��5       
 titulo#��[ 6(   $��Center=�6H   GESTIÓN DE SEDES6u   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   .+�5      �� $ Vertical=�6   $��	70,20,0,0q�60   .+�5      ��   
labelTitle#��[ 6   .��6<   	Calle *6E   �� 5      -   5        $��tbCalle��5       �� 	MaxLength$ 90��6)     textbox#��[ 68   $	��400��6Y   ��6e   �� *Calle+ �� Mode$ TwoWay=�6�   5       �� 5!      $ Vertical=�6   $��	80,20,0,0q�60   .+�5"      �� #��[ 6   .��6<   
Planta *6F   �� 5#      -   5        $��tbPlanta��5#      $ 2��6*   #��[ 6]   ��68   �� *Planta+$ TwoWay=�6�   5$      �� 5%      $ Vertical=�6   $��	60,20,0,0q�60   .+�5&      �� #��[ 6   .��6<   Código Postal *6M   �� 5'      -   5        $��tbCodigoPostal��5'      $ 5��61   #��[ 6j   ��6?   �� *CodigoPostal+$ TwoWay=�6�   5(      5*      �� 5+   
   $��2��6   $ 
Horizontal=�6"   .+�5,      �� $ Vertical=�6   $��	70,20,0,0q�65   .+�5-      �� #��[ 6   .��6<   Localidad *6I   �� 5.      -   5        $��cbLocalidad��5.      $
��Left=�6w   $	��200��6�   $��30��6�   ��6.   �� 6�   �� 5/      -   5        $��tbLocalidad��5/   3   $y�	Collapsed=�6   ��6F   �� *	Localidad+$ TwoWay=�6p   50      51      �� 52   
   $��Center=�6   $��3��63   $ 
Horizontal=�6@   .+�53      �� -   5        $��panelInformacion��53   !   $	��570��6   $y�Hidden=�69   $��70��6M   $��70,0,0,0q�6Y   
�������$��1q�6�    �� CornerRadius$ 10��6�   ���#d8e9e7._�54      �� $ 
Horizontal=�6   .+�55      �� $��../Imagenes/info.png��6   $��10q�6:   $��40��6F   6S   �� 56      $
��Wrap=�6    $	��500��64   $��20,10q�6@   ][Los campos que deje en blanco o no modifique permanecerán sin cambios en la base de datos.6�   57      59      �� 5:      -	   5        $��btImportarCSV��5:        RegularButton#��[ 6G   $��10,10,30,10q�6n   .��5;      �� $ 
Horizontal=�6   .+�5<      �� $��../Imagenes/csv.png��6   6;   �� 5=      
�����p�$��14(�63   $��Bottom=�6A   .��5>      �� .��6%   _IMPORTAR .CSV65   6B   5?      5@      �� 5A      -
   5         ��Name$ 	btAgregar��5A      #��[ 6@   .��5B      �� .��6   
_AGREGAR6'   64   5C      �� 5G   
   -   5        $��panelEditar��5G      $��4��6)   .+�5H      �� $ 
Horizontal=�6   .+�5I      �� $��70,10,10,10q�6   #��[ 6.   .��6S   Buscar Sede:6a   �� 5J      -   5        $��tbBuscarSede��5J      $	��300��6.   
�������$��2q�6R   $��30��6f   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$* $Introduzca calle de la sede a buscar��6r   6�   �� 5K      -   5        $��btBuscarSede��5K      $��30��6I   $��10q�6U   $��1q�6a   
�������
������ $
��Left=�6�   .��5L      �� .+�5M      �� $��../Imagenes/find.png��6    $��25��6>   $��25��6I   $
��Fill=�6U   6g   5N      5O      5Q      &   System.Windows.Controls.DataGrid  5R      -   5        $��dgSedes��5R      	   AutoGenerateColumns	 .  
   CanUserDeleteRows
 .     CanUserAddRows .  $	��300��6�   $��70,10q�6�   ��6B   ��    Columns 5S      0  *System.Windows.Controls.DataGridTextColumn  5T      ,  &System.Windows.Controls.DataGridColumn   Header$ Calle��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$	 400 69      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Calle+6s     5U      $ Planta��6)   $	 100 69    .  6E   �� *Planta+6t     5V      $ Código Postal��6)   $	 150 6@    .  6L   �� *CodigoPostal+6�     5W      $ 	Localidad��6)   $	 200 6<    .  6H   �� *	Localidad+6~   4  .System.Windows.Controls.DataGridTemplateColumn  5X      $ Editar��6.   $ 80 6>    .    CellTemplate 5Y      �� 5Z      .R�5[   "   �� $��btEditar��6)   -   5        
������ .��5\   &   �� $��25��6,   $"��../Imagenes/editarTicket.png��67   6_   5]   #   5^      5`      5b      �� 5c      $ 
Horizontal=�6   $��854,10,0,10q�62   .+�5d      �� -   5        $��btExportarCSV��5d      #��[ 6J   $��10,10,70,10q�6q   .��5e      �� $ 
Horizontal=�6!   .+�5f      �� $��../Imagenes/csv.png��6    6?   �� 5g      
�����p�.��5h      �� .��6)   _EXPORTAR A CSV6:   6G   5i      5j      5k      5l      �� 5m   
   -   5        $��panelVolver��5m   >   $��5��6   $��Right=�6"   .+�5n      �� -   5        $��btVolver��5n   w   $y�Hidden=�6   $��50,10q�6A   #��[ 6P   .��5o      �� .��6   	_VOLVER6&   63   5p      �� 5q   
   -   5        $��	statusBar��5q   9   
�������$��6��6,   $��50��6J   .@�5r      �� -   5        $��tbStatusInformation��5r   +   
�������$��10q�6F   6T   5s      5t      5u      