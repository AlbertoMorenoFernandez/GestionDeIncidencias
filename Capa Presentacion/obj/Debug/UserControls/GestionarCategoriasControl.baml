   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      6    0Capa_Presentacion.UserControls.CategoriasControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      8local,clr-namespace:Capa_Presentacion.UserControls  5      .��5
      � -   5        $��	gdGeneral��5
      
�������  � DataContext  6/   ��  � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $��90 �6   6*   �� 5      $��90 �6   6*   �� 5      $	��510 �6   6+   �� 5      $��60 �6   6*   �� 5      $��50 �6   6*   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6#   .+�5      �� $��../Imagenes/tuerca.png��6   66   �� 5      -   5        $��tbTitulo��5       
  titulo#��[  6(   $��Center=�6H   GESTIÓN DE CATEGORÍAS6z   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   .+�5      �� $ Vertical=�6   $��	70,20,0,0q�60   .+�5      ��   
labelTitle#��[ 6   .��6<   
Nombre *6F   �� 5      -   5        $��tbNombre��5       �� 	MaxLength$ 50��6*   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$' !Nombre categoría (No duplicados)��69   $	��400��6|   ��6�   �� *Nombre+ �� Mode$ TwoWay=�6�   5      �� 5      $ 
Horizontal=�6   $��Bottom=�63   $��	170,0,0,5q�6N   .+�5      �� -   5        $��btImportarCSV��5        RegularButton#��[ 6J   $��10,10,30,10q�6q   .��5      �� $ 
Horizontal=�6!   .+�5       �� $��../Imagenes/csv.png��6    6?   �� 5!      
�����p�$��14(�67   $��Bottom=�6E   .��5"      �� .��6)   _IMPORTAR .CSV69   5#      5$      5%      �� 5&      -   5        $��	btAgregar��5&      #��[ 6B   .��5'      �� .��6!   
_AGREGAR6+   5(      5)      5-      �� 5/   
   $��Center=�6   $��2��63   $ 
Horizontal=�6@   .+�50      �� -   5        $��panelInformacion��50   !   $	��570��6   $y�Hidden=�69   $��70��6M   $��70,0,0,0q�6Y   
�������$��1q�6�    �� CornerRadius$ 10��6�   ���#d8e9e7._�51      �� $ 
Horizontal=�6   .+�52      �� $��../Imagenes/info.png��6   $��10q�6:   $��40��6F   6S   �� 53      $
��Wrap=�6    $	��500��64   $��20,10q�6@   ][Los campos que deje en blanco o no modifique permanecerán sin cambios en la base de datos.6�   54      56      57      �� 5;   
   -   5        $��panelEditar��5;      $��3��6)   .+�5<      �� $ 
Horizontal=�6   .+�5=      �� $��70,15,10,10q�6   #��[ 6.   .��6S   Buscar Cateogria:6f   �� 5>      -   5        $��tbBuscarCategoria��5>      $	��300��63   
�������$��2q�6W   $��30��6k   $$ Introduzca categoría a buscar��6w   6�   �� 5?      -	   5        $��btBuscarCategoria��5?      $��35��6S   $��10q�6_   $��1q�6k   
�������
������ $
��Left=�6�   .��5@      �� .+�5A      �� $��../Imagenes/find.png��6    $��25��6>   $��25��6I   $
��Fill=�6U   6g   5B      5C      5E      &   System.Windows.Controls.DataGrid  5F      -
   5        $��dgCategorias��5F         AutoGenerateColumns .     CanUserDeleteRows .  	   CanUserAddRows	 .  $	��300��6�   $��70,10q�6�   ��6G   �� 
   Columns
 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$	 850 6:      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *Nombre+6u   4  .System.Windows.Controls.DataGridTemplateColumn  5J      $ Editar��6-   $ 80 6=    .    CellTemplate 5K      �� 5L      .R�5M   "   �� $��btEditar��6)   -   5        
������ .��5N   &   �� $��25��6,   $"��../Imagenes/editarTicket.png��67   6_   5O   #   5P      5R      5T      �� 5U      $ 
Horizontal=�6   $��Right=�62   .+�5V      �� -   5        $��btExportarCSV��5V      #��[ 6J   $��10,10,70,10q�6q   .��5W      �� $ 
Horizontal=�6!   .+�5X      �� $��../Imagenes/csv.png��6    6?   �� 5Y      
�����p�.��67   EXPORTAR A CSV6G   5Z      5[      5\      5]      �� 5^   
   -   5        $��panelVolver��5^   >   $��4��6   $��Right=�6"   .+�5_      �� -   5        $��btVolver��5_   w   $y�Hidden=�6   $��50,10q�6A   #��[ 6P   .��5`      �� .��6   	_VOLVER6&   5a      5b      �� 5c   
   -   5        $��	statusBar��5c   9   
�������$��6��6,   $��50��6J   .@�5d      �� -   5        $��tbStatusInformation��5d   +   
�������$��10q�6F   6T   5e      5f      5g      