   M S B A M L   `   `   `  ����`  \De.TorstenMandelkow.MetroChart, Version=0.9.5818.20693, Culture=neutral, PublicKeyToken=nullwTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart  5      L HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls 5      =   7Capa_Presentacion.UserControls.ticketsPendientescontrol   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      k
MetroChartTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Capa_Presentacion.UserControls     5        � 	Resources  5
         tickesPendientes �� Source��%&   &	        �� 5   
    6:   �� 5      .��5      � -   5        $��	gdTickets��5       � RowDefinitions 5   
   �� 5      $	��410 �6   6+   �� 5      $	��410 �6   6+   �� 5      $��50 �6   6*    � ColumnDefinitions 5   
   �� 5      $	��650 �6   6-   �� 5      6"   .+�5   
   �� $��0��6   $��0��6"   $	��Top=�62   $��0q�6J    �� Orientation$ Vertical=�6U   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��30,10q�6    
 titulo#��[ 6+   Asignar tickets6\   �� 5      -   5        $��btActualizar��5      $��290,0q�6H    � ToolTip$ Actualizar Ventana��6W   
�������$��1q�6�   $��35��6�   
������ .��5      �� $
��Fill=�6   $��../Imagenes/refresh.png��6(   6K   5      5      &   System.Windows.Controls.DataGrid  5      -   5        $��dgTickesPendientes��5    F   $   HorizontalScrollBarVisibility$ Hidden=�5      "   VerticalScrollBarVisibility$ Visible=�6>      	RowHeight$ 50Q�6d   $	��620��6s   $
��Left=�6   $��Center=�6�   $��Center=�5       $��
30,10,0,10q�62   	   CanUserAddRows	 .  
�������$	��300��6�   $
 �� IsSynchronizedWithCurrentItem$

 TrueY�6�      AutoGenerateColumns .  ��5!      ��    Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 48 6;      Header$ Id��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6U   ��  �� Path$ Id�  5$       . $	 180 6;   $ Descripción��6G    6^   �� *Descripcion+  5%       .    MaxWidth$	 155Q�6;   $ Fecha de Entrada��6K    6g   �� *FechaEntrada+4  .System.Windows.Controls.DataGridTemplateColumn  5'      -   5        	combo��$ 
Asignar a:��5'   <    .    CellTemplate 5(      �� 5)      .R�5*   "   ��  ��Name$ 
cbTecnicos��6+   -   5        $
��Left=�5*   ?   $	��115��6Z   ��6�   �� *
Tecnicos+6�   5+      5-      52      54      �� 55   
   $��0��6   $��1��6"   $
��Left=�62   $ Vertical=�6M   .+�56      �� $��
70,85,10,0q�6   $ 
Horizontal=�6-   .+�57      ��   
labelTitle#��[ 6   $	��180��6<   .��6H   
Nº Ticket6S   �� 58      -   5        $��tbNumTicket��58      $��Center=�6C   ��6/   �� *Id+6a   59      �� 5:      $��
70,10,10,0q�6   $ 
Horizontal=�6-   .+�5;      �� #��[ 6   $	��180��6<   .��6H   	Id Equipo6S   �� 5<      $��Center=�6   ��67   �� *
IdEquipo+6T   5=      �� 5>      $��
70,10,10,0q�6   $ 
Horizontal=�6-   .+�5?      �� #��[ 6   $	��180��6<   .��6H   	Usuario6Q   �� 5@      $��Center=�6   ��67   �� *	Usuario+6S   5A      �� 5B      $��
70,10,10,0q�6   $ 
Horizontal=�6-   .+�5C      �� #��[ 6   $	��180��6<   .��6H   Fecha de Entrada6Z   �� 5D      $��Center=�6   ��67   �� *FechaEntrada+6X   5E      �� 5F      $��
70,10,10,0q�6   $ 
Horizontal=�6-   .+�5G      �� #��[ 6   $	��180��6<   .��6H   Sede6N   �� 5H      $��35��6   $	��199��6(   $��Center=�65   $��0q�6P   $
��Wrap=�6[   ��6o   �� *Sede+6�   5I      �� 5J      $��
70,10,10,0q�6   $ Vertical=�6-   .+�5K      �� $
��Left=�6   #��[ 63   $	��200��6W   .��6c   Descripcion6p   �� 5L      
�������$	��400��61   $
��0,10q�6=   ._�5M      ��  �� TextAlignment$
 Left=�6    $	��380��65   $��50��6A   $��10q�6M   $
��Wrap=�6Y   ��6m   �� *Descripcion+6�   5N      5O      5Q      �� 5R   
   -   5        $��panelGraficas��5R      $��0��6*   $��1��6:   $	��455��6G   
�������$ 
Horizontal=�6h   .+�5S      9   3De.TorstenMandelkow.MetroChart.ClusteredColumnChart  -   5        $��
columnGrap��5U   5   $��	10,0,0,20q�5S   .   $	��599��6A   .   (De.TorstenMandelkow.MetroChart.ChartBase   ChartSubTitle$ Horas��6M      
ChartTitle$! Tiempo medio de Resolución��5T   "   
�������   ChartLegendVisibility$ Visible=�5U   G      Series 5W      0	   *De.TorstenMandelkow.MetroChart.ChartSeries	   	  SeriesTitle$
 Día��5Y       	  DisplayMember$	 Day��5Z       	  ValueMember$ Count��5[      ��5X      �� 5[      5`      5a      �� 5b   
   $��1��6   $��1��6%   
�������$	��455��6E   .+�5d      5
   /De.TorstenMandelkow.MetroChart.RadialGaugeChart
  -	   5        $��pieChart��5f   6   $	��400��5d   *   $	��490��67   $��Center=�6C   $��0,0,0,40q�6`   $ Actuales��6r   $ Tickets asignados��5e   "   
������� 5h      	  $ My Population Series��5j      $
 Name��5k      $ Count��5l      ��5i      �� 5l      5o      5q      �� 5s   
   -
   5        $��	statusBar��5s   ]   
�������$��2��6,   $��2��6@   $��0��6M   $��50��6n   .@�5t      �� -   5        $��tbStatusInformation��5t   +   
�������$��10q�6F   6T   5u      5w      5x      