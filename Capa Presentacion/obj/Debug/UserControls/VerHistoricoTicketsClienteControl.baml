   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      ?    9Capa_Presentacion.UserControls.VerHistoricoTicketsControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      8local,clr-namespace:Capa_Presentacion.UserControls  5      .��5
      � 
�������  � RowDefinitions  5   
   �� 5      $	��330 �6   6+   �� 5      $	��490 �6   6+   �� 5      $��50 �6   6*   .+�5   
   �� $��0��6   .+�5      ��  
  titulo#��[  6   $��45,10q�68   Histórico de incidencias6b   �� 5       �� Orientation$ Vertical=�6   $
��Left=�65   $	��220��6P   
�������$��50,20q�6q   $	��Top=�6�   $
��1000��6�   .+�5      ��  �� CornerRadius$ 	20,20,0,0��6   
�������$��40��6N   ._�5      �� $ 
Horizontal=�6%   .+�5      �� $��20��6$   $��../Imagenes/ticket.png��60   $	��3,0q�6P   �� 5      $��Center=�6(   $
��Bold"�6C   Filtrar búsqueda6g   5      5      �� 5      $��1q�6   $ 	0,0,20,20��6-   
�������._�5      �� $ Vertical=�6!   .+�5      �� $ 
Horizontal=�6%   .+�5      ��   
labelTitle#��[ 6$   $��	5,10,10,5q�6H   $	��200��6[   .��6g   
Id Equipo:6s   �� 5       -   5        $��tbEquipo��5    &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Introduzca id de equipo��66   
�������$	��200��6�   $��30��6�   $��	5,10,10,5q�6�   6�   5!      �� 5"      $ 
Horizontal=�6%   .+�5#      �� #��[ 6$   $��	5,10,10,5q�6H   $	��200��6[   .��6g   Desde:6o   (  "System.Windows.Controls.DatePicker  5$      -   5        $��dtpDesde��5$   )   $	��200��69   $��	5,10,10,5q�6F   6\   5%      �� 5&      $ 
Horizontal=�6%   .+�5'      �� #��[ 6$   $��5,5,10,5q�6H   $	��200��6Z   .��6f   Hasta:6n     5(      -   5        $��dtpHasta��5(   )   $	��200��69   $��	5,10,10,5q�6F   6\   5)      �� 5*      -   5        $��	btFiltrar��5*   !     RegularButton#��[ 62   $��Right=�6Y   $��	10,0,10,5q�6u   .��5+      �� $ 
Horizontal=�6)   .+�5,   "   �� $��30��6)   $��Uniform=�64   $"��../Imagenes/buscarTicket.png��6F   6o   �� 5-   "   $��10q�6,   $��Center=�68   $��80��6U   �� 6a   .��6l   
_FILTRAR6v   6�   5.      5/      50      51      52      54      �� 55      $��1��6   .+�56      &   System.Windows.Controls.DataGrid  -   5        $��	dtTickets��56      $
��1000��6(   $��20q�65   $	��450��6B      CanUserAddRows .  
�������
���   �   	RowHeight$ 50Q�6�   $   HorizontalScrollBarVisibility$ Hidden=�6�      AutoGenerateColumns .  ��6�   ��    Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Nº Ticket��6)   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	NumTicket+6n     59      $	 Fecha Entrada��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 170 6@   
 .  6L   �� *FechaEntrada+6�     5:      $	 Fecha Salida��6)   $	 170 6?   
 .  6K   �� *FechaResolucion+6�     5;      $	 Descripción��6)   $	 300 6>   
 .  6J   �� *Descripcion+6�     5<      $	 Resolución��6)   $	 300 6=   
 .  6I   �� *
Resolucion+6}   5?      5@      �� 5A   
   -   5        $��	statusBar��5A   9   
�������$��2��6,   $��50��6J   .@�5B      �� -   5        $��tbStatusInformation��5B   +   
�������$��10q�6F   6T   5C      5F      5G      