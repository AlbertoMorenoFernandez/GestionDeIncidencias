   M S B A M L   `   `   `  ����`  \De.TorstenMandelkow.MetroChart, Version=0.9.5818.20693, Culture=neutral, PublicKeyToken=nullwTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart  5      L HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls 5      =   7Capa_Presentacion.UserControls.ticketsPendientescontrol   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      k
MetroChartTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Capa_Presentacion.UserControls     5        � 	Resources  5
         tickesPendientes �� Source��%&   &	        �� 5   
    6:   �� 5      .��5      � -   5        $��	gdTickets��5       � RowDefinitions 5   
   �� 5      $	��410 �6   6+   �� 5      $	��410 �6   6+   �� 5      $��50 �6   6*    � ColumnDefinitions 5   
   �� 5      $	��590 �6   6-   �� 5      6"   .+�5   
   �� $��0��6   $��0��6"   $	��Top=�62   $��0q�6J    �� Orientation$ Vertical=�6U   .+�5      �� $��30,10q�6    
 titulo#��[ 6'   Asignar tickets6X   &   System.Windows.Controls.DataGrid  5      -   5        $��dgTickesPendientes��5   �   $   HorizontalScrollBarVisibility$ Hidden=�6   "   VerticalScrollBarVisibility$ Visible=�6>      	RowHeight$ 50Q�6d   $	��560��6s   $
��Left=�6   $��Center=�6�   $��Center=�6�   $��
30,10,0,10q�6�      CanUserAddRows .  
�������$	��300��60  $	 �� IsSynchronizedWithCurrentItem$
	 TrueY�6>  
   AutoGenerateColumns
 .  ��6d  ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6;      Header$ Id��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6U   ��  �� Path$ Id�  5       . $	 190 6;   $ Descripción��6G    6^   �� *Descripcion+  5       .    MaxWidth$	 160Q�6;   $ Fecha de Entrada��6K    6g   �� *FechaEntrada+4  .System.Windows.Controls.DataGridTemplateColumn  5       $ 
Asignar a:��6-    .    CellTemplate 5!      �� 5"      .R�5#   "   �� $��
cbTecnicos��6+   -   5        $
��Left=�5#   =   $	��110��6X    �� SelectedIndex$ 0��6d   ��6�   �� *
Tecnicos+6�   5$      5&      5+      5-      �� 5.   
   $��0��6   $��1��6"   $
��Left=�62   $ Vertical=�6M   .+�5/      �� $��
70,85,10,0q�6   $ 
Horizontal=�6-   .+�50      �� $
��Bold"�6   $	��200��6*   .��66   
Nº Ticket6A   �� 51      -   5        $��tbNumTicket��51      $��Center=�6C   ��6/   �� *Id+6a   52      �� 53      $��
70,10,10,0q�6   $ 
Horizontal=�6-   .+�54      �� $
��Bold"�6   $	��200��6*   .��66   	Id Equipo6A   �� 55      $��Center=�6   ��67   �� *
IdEquipo+6T   56      �� 57      $��
70,10,10,0q�6   $ 
Horizontal=�6-   .+�58      �� $
��Bold"�6   $	��200��6*   .��66   	Usuario6?   �� 59      $��Center=�6   ��67   �� *	Usuario+6S   5:      �� 5;      $��
70,10,10,0q�6   $ 
Horizontal=�6-   .+�5<      �� $
��Bold"�6   $	��200��6*   .��66   Fecha de Entrada6H   �� 5=      $��Center=�6   ��67   �� *FechaEntrada+6X   5>      �� 5?      $��
70,10,10,0q�6   $ 
Horizontal=�6-   .+�5@      �� $
��Bold"�6   $	��200��6*   .��66   Sede6<   �� 5A      $��35��6   $	��199��6(   $��Center=�65   $
��Wrap=�6P   ��6d   �� *Sede+6|   5B      �� 5C      $��
70,10,10,0q�6   $ Vertical=�6-   .+�5D      �� $
��Left=�6   $
��Bold"�63   $	��200��6E   .��6Q   Descripcion6^   �� 5E      
�������$	��400��61   $
��0,10q�6=   ._�5F      ��  �� TextAlignment$
 Left=�6    $	��380��65   $��50��6A   $��10q�6M   ��6Z   �� *Descripcion+6y   5G      5H      5J      �� 5K   
   -   5        $��panelGraficas��5K      $��0��6*   $��1��6:   $	��455��6G   
�������$ 
Horizontal=�6h   .+�5L      9   3De.TorstenMandelkow.MetroChart.ClusteredColumnChart  -   5        $��
columnGrap��5N   5   $��	10,0,0,20q�5L   .   $	��599��6A   .   (De.TorstenMandelkow.MetroChart.ChartBase   ChartSubTitle$ Horas��6M      
ChartTitle$! Tiempo medio de Resolución��5M   "   
�������   ChartLegendVisibility$ Visible=�5N   G      Series 5P      0	   *De.TorstenMandelkow.MetroChart.ChartSeries	   	  SeriesTitle$
 Día��5R       	  DisplayMember$	 Day��5S       	  ValueMember$ Count��5T      ��5Q      �� 5T      5Y      5Z      �� 5[   
   $��1��6   $��1��6%   
�������$	��455��6E   .+�5]      5
   /De.TorstenMandelkow.MetroChart.RadialGaugeChart
  -   5        $��pieChart��5_   6   $	��400��5]   *   $	��530��67   $��Center=�6C   $��
10,0,10,40q�6`   $ Actuales��6t   $ Tickets asignados��5^   "   
������� 5a      	  $ My Population Series��5c      $
 Name��5d      $ Count��5e      ��5b      �� 5e      5h      5j      �� 5k   
   $��2��6   $��2��6(   $��0��65   6G   5n      5o      