   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  6    0Capa_Presentacion.UserControls.CategoriasControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  :d2http://schemas.microsoft.com/expression/blend/2008  8local,clr-namespace:Capa_Presentacion.UserControls  .��� -   $��	gdGeneral��
�������  � DataContext  ��  � RowDefinitions �� $��80 ��� $��90 ��� $��90 ��� $	��510 ��� $��60 ��� $��50 �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $��../Imagenes/tuerca.png���� -   $��tbTitulo�� 
  titulo#��[  $��Center=�GESTIÓN DE CATEGORÍAS�� $��1��$ 
Horizontal=�.+��� $ Vertical=�$��	70,20,0,0q�.+���   
labelTitle#��[ .��
Nombre *�� -   $��tbNombre�� �� 	MaxLength$ 50��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$' !Nombre categoría (No duplicados)��$	��400������ *Nombre+ �� Mode$ TwoWay=��� $ 
Horizontal=�$��Bottom=�$��	170,0,0,5q�.+��� -   $��btImportarCSV��  RegularButton#��[ $��10,10,30,10q�.���� $ 
Horizontal=�.+��� $��../Imagenes/csv.png���� 
�����p�$��14(�$��Bottom=�.���� .��_IMPORTAR .CSV�� -   $��	btAgregar��#��[ .���� .��
_AGREGAR�� $��Center=�$��2��$ 
Horizontal=�.+��� -   $��panelInformacion��$	��570��$y�Hidden=�$��70��$��70,0,0,0q�
�������$��1q� �� CornerRadius$ 10�����#d8e9e7._��� $ 
Horizontal=�.+��� $��../Imagenes/info.png��$��10q�$��40���� $
��Wrap=�$	��500��$��20,10q�][Los campos que deje en blanco o no modifique permanecerán sin cambios en la base de datos.�� -   $��panelEditar��$��3��.+��� $ 
Horizontal=�.+��� $��70,15,10,10q�#��[ .��Buscar Cateogria:�� -   $��tbBuscarCategoria��$	��300��
�������$��2q�$��30��$$ Introduzca categoría a buscar���� -	   $��btBuscarCategoria��$��35��$��10q�$��1q�
�������
������ $
��Left=�.���� .+��� $��../Imagenes/find.png��$��25��$��25��$
��Fill=�&   System.Windows.Controls.DataGrid  -
   $��dgCategorias��   AutoGenerateColumns .     CanUserDeleteRows .  	   CanUserAddRows	 .  $	��300��$��70,10q����� 
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 850    
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Nombre+4  .System.Windows.Controls.DataGridTemplateColumn  $ Editar��$ 80  .    CellTemplate �� .R��� $��btEditar��-   
������ .���� $��25��$"��../Imagenes/editarTicket.png���� $ 
Horizontal=�$��Right=�.+��� -   $��btExportarCSV��#��[ $��10,10,70,10q�.���� $ 
Horizontal=�.+��� $��../Imagenes/csv.png���� 
�����p�.��EXPORTAR A CSV�� -   $��panelVolver��$��4��$��Right=�.+��� -   $��btVolver��$y�Hidden=�$��50,10q�#��[ .���� .��	_VOLVER�� -   $��	statusBar��
�������$��6��$��50��.@��� -   $��tbStatusInformation��
�������$��10q�