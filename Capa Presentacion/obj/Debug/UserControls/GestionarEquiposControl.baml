   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      3    -Capa_Presentacion.UserControls.EquiposControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      8local,clr-namespace:Capa_Presentacion.UserControls  5        � 	Resources  5
         SalmonColor �� Color2   ,Capa_Presentacion.UserControls.ConvertIdSede  sedeConverter7   1Capa_Presentacion.UserControls.ConvertIdCategoria  tipoConverter��%j   &	        &	 &     &	 9     �� 5   
   $ #d8e9e7��6.   6@     5   
   66     5   
   6;   5      .��5      � -   5        $��	gdGeneral��5      
������� � DataContext 6/   ��  � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $��90 �6   6*   �� 5      $��90 �6   6*   �� 5      $��80 �6   6*   �� 5      $	��430 �6   6+   �� 5      $��60 �6   6*   �� 5      $��50 �6   6*   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6#   .+�5      �� $��../Imagenes/tuerca.png��6   66   �� 5      -   5        $��tbTitulo��5       
 titulo#��[ 6(   $��Center=�6H   GESTIÓN DE EQUIPOS6w   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   .+�5      �� $ Vertical=�6   $��	70,20,0,0q�60   .+�5      ��   
labelTitle#��[ 6   .��6<   Service Tag*6J   �� 5       -   5        $��tbServiceTag��5        �� 	MaxLength$ 7��6.    �� 
IsReadOnly .   textbox#��[ 6�   ��6N   �� *
ServiceTag+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5!      �� 5"      $ Vertical=�6   $��	40,20,0,0q�60   .+�5#      �� #��[ 6   .��6<   	Marca *6E   �� 5$      -   5        $��tbMarca��5$      $ 50��6)   #��[ 6\   ��68   �� *Marca+$ TwoWay=�6   5%      �� 5&      $ Vertical=�6   $��	40,20,0,0q�60   .+�5'      �� #��[ 6   .��6<   
Modelo *6F   �� 5(      -   5        $��tbModelo��5(      $ 50��6+   #��[ 6_   ��6:   �� *Modelo+$ TwoWay=�6�   5)      �� 5*      $ Vertical=�6   $��	40,20,0,0q�60   .+�5+      �� #��[ 6   .��6<   Nº Serie *6H   �� 5,      -   5        $��
tbNumSerie��5,      $ 50��6,   #��[ 6b   ��6;   �� *
NumSerie+$ TwoWay=�6�   5-      5.      �� 5/   
   $��2��6   $ 
Horizontal=�6"   .+�50      �� $ Vertical=�6   $	��200��60   $��	70,20,0,0q�6<   .+�51      �� #��[ 6   .��6<   Fin Garantía *6L   (  "System.Windows.Controls.DatePicker  52      -   5        $��dtpGarantia��52      $��30��6�   	   SelectedDate	 6f   �� *FinGarantia+$ TwoWay=�6�   53      �� 54      $ Vertical=�6   $	��200��61   $��	40,20,0,0q�6=   .+�55      �� #��[ 6   .��6<   Tipo*6C   �� 56      -   5        $��cbCategoria��56      ��6^   �� 6x   57      �� 58      $ Vertical=�6   $��	40,20,0,0q�60   .+�59      �� #��[ 6   .��6<   	Oficina *6G   �� 5:      -	   5        $��	cbOficina��5:      $
��Left=�6D   $	��200��6_   $��30��6k   ��6,   �� 6�   �� 5;      -
   5        $��	tbOficina��5;      $y�	Collapsed=�6V   ��6-   �� *
NumOficina+$ TwoWay=�6o   5<      5>      �� 5?   
   $��Center=�6   $��3��63   $ 
Horizontal=�6@   .+�5@      �� -   5        $��panelInformacion��5@   !   $	��570��6   $y�Hidden=�69   $��70��6M   $��70,0,0,0q�6Y   
�������$��1q�6�   
 �� CornerRadius$
 10��6�   ���#d8e9e7._�5A      �� $ 
Horizontal=�6   .+�5B      �� $��../Imagenes/info.png��6   $��10q�6:   $��40��6F   6S   �� 5C      $
��Wrap=�6    $	��500��64   $��20,10q�6@   ][Los campos que deje en blanco o no modifique permanecerán sin cambios en la base de datos.6�   5D      5F      �� 5G      -   5        $��btImportarCSV��5G        RegularButton#��[ 6F   $��10,10,30,10q�6m   .��5H      �� $ 
Horizontal=�6   .+�5I      �� $��../Imagenes/csv.png��6   6;   �� 5J      
�����p�$��14(�63   $��Bottom=�6A   .��5K      �� .��6%   _IMPORTAR .CSV65   5L      5M      5N      �� 5O      -   5        $��	btAgregar��5O      #��[ 6>   .��5P      �� .��6   
_AGREGAR6'   5Q      5R      �� 5S   
   -   5        $��panelEditar��5S      $��4��6)   .+�5T      �� $ 
Horizontal=�6   .+�5U      �� $��70,10,10,10q�6   #��[ 6.   .��6S   Buscar Equipo:6c   �� 5V      -   5        $��tbBuscarEquipo��5V      $	��300��60   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Service Tag��6=   $��30��6j   6x   �� 5W      -   5        $��btBuscarEquipo��5W      $��30��6M   $��10q�6Y   $��1q�6e   
�������
������ $
��Left=�6�   .��5X      �� .+�5Y      �� $��../Imagenes/find.png��6    $��25��6>   $��25��6I   $
��Fill=�6U   6g   5Z      5[      5]      &   System.Windows.Controls.DataGrid  5^      -   5        $��dgEquipo��5^         AutoGenerateColumns .     CanUserDeleteRows .     CanUserAddRows .  $	��300��6�   $��70,10q�6�   ��6C   ��    Columns 5_      0  *System.Windows.Controls.DataGridTextColumn  5`      ,  &System.Windows.Controls.DataGridColumn   Header$ Service Tag��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$ 85 6?      
IsReadOnly . 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6J   �� *
ServiceTag+6}     5a      $ Marca��6)   $ 80 68    .  6C   �� *Marca+6q     5b      $ Modelo��6)   $ 80 69    .  6D   �� *Modelo+6t     5c      $ 	Garantía��6)   $	 150 6;    .  6G   �� *FinGarantia+6     5d      $
 Tipo��6)   $	 110 67    .  6C   �� *Idtipo+ �� 	Converter# [ 6�     5e      $ Oficina��6)   $	 350 6:    .  6F   �� *
NumOficina+# [ 6�   4
  .System.Windows.Controls.DataGridTemplateColumn
  5f      $ Editar��6-   $ 80 6=    .  
  CellTemplate 5g      �� 5h      .R�5i   "   �� $��btEditar��6)   -   5        
������ .��5j   &   �� $��25��6,   $"��../Imagenes/editarTicket.png��67   6_   5k   #   5l      5n      5p      �� 5q      $ 
Horizontal=�6   $��850,10,0,10q�62   .+�5r      �� -   5        $��btExportarCSV��5r      #��[ 6J   $��10,10,70,10q�6q   .��5s      �� $ 
Horizontal=�6!   .+�5t      �� $��../Imagenes/csv.png��6    6?   �� 5u      
�����p�.��67   EXPORTAR A CSV6G   5v      5w      5x      5y      �� 5z   
   -   5        $��panelVolver��5z   >   $��5��6   $��Right=�6"   .+�5{      �� -   5        $��btVolver��5{   w   $y�Hidden=�6   $��50,10q�6A   #��[ 6P   .��5|      �� .��6   	_VOLVER6&   5}      5~      �� 5   
   -   5        $��	statusBar��5   9   
�������$��6��6,   $��50��6J   .@�5�      �� -   5        $��tbStatusInformation��5�   +   
�������$��10q�6F   6T   5�      5�      5�      