   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  ?    9Capa_Presentacion.UserControls.VerHistoricoTicketsControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  :d2http://schemas.microsoft.com/expression/blend/2008  8local,clr-namespace:Capa_Presentacion.UserControls  .��� 
�������  � RowDefinitions  �� $	��330 ��� $	��490 ��� $��50 �.+��� $��0��.+���  
  titulo#��[  $��45,10q�Histórico de incidencias��  �� Orientation$ Vertical=�$
��Left=�$	��220��
�������$��50,20q�$	��Top=�$
��1000��.+���  �� CornerRadius$ 	20,20,0,0��
�������$��40��._��� $ 
Horizontal=�.+��� $��20��$��../Imagenes/ticket.png��$	��3,0q��� $��Center=�$
��Bold"�Filtrar búsqueda�� $��1q�$ 	0,0,20,20��
�������._��� $ Vertical=�.+��� $ 
Horizontal=�.+���   
labelTitle#��[ $��	5,10,10,5q�$	��200��.��
Id Equipo:�� -   $��tbEquipo��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Introduzca id de equipo��
�������$	��200��$��30��$��	5,10,10,5q��� $ 
Horizontal=�.+��� #��[ $��	5,10,10,5q�$	��200��.��Desde:(  "System.Windows.Controls.DatePicker  -   $��dtpDesde��$	��200��$��	5,10,10,5q��� $ 
Horizontal=�.+��� #��[ $��5,5,10,5q�$	��200��.��Hasta:  -   $��dtpHasta��$	��200��$��	5,10,10,5q��� -   $��	btFiltrar��  RegularButton#��[ $��Right=�$��	10,0,10,5q�.���� $ 
Horizontal=�.+��� $��30��$��Uniform=�$"��../Imagenes/buscarTicket.png���� $��10q�$��Center=�$��80���� .��
_FILTRAR�� $��1��.+�&   System.Windows.Controls.DataGrid  -   $��	dtTickets��$
��1000��$��20q�$	��450��   CanUserAddRows .  
�������
���   �   	RowHeight$ 50Q�$   HorizontalScrollBarVisibility$ Hidden=�   AutoGenerateColumns .  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Nº Ticket��
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	NumTicket+  $	 Fecha Entrada��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 170 
 .  �� *FechaEntrada+  $	 Fecha Salida��$	 170 
 .  �� *FechaResolucion+  $	 Descripción��$	 300 
 .  �� *Descripcion+  $	 Resolución��$	 300 
 .  �� *
Resolucion+�� -   $��	statusBar��
�������$��2��$��50��.@��� -   $��tbStatusInformation��
�������$��10q�