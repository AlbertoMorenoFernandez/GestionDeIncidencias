   M S B A M L   `   `   `  ���� `  \De.TorstenMandelkow.MetroChart, Version=0.9.5818.20693, Culture=neutral, PublicKeyToken=nullwTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChartDe.TorstenMandelkow.MetroChart  L HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls =   7Capa_Presentacion.UserControls.ticketsPendientescontrol   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     k
MetroChartTclr-namespace:De.TorstenMandelkow.MetroChart;assembly=De.TorstenMandelkow.MetroChart     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:Capa_Presentacion.UserControls       � 	Resources     tickesPendientes �� Source��%   &	        ��  �� .��� -   $��	gdTickets�� � RowDefinitions �� $	��410 ��� $	��410 ��� $��50 � � ColumnDefinitions �� $	��650 ��� .+��� $��0��$��0��$	��Top=�$��0q� �� Orientation$ Vertical=�.+��� $ 
Horizontal=�.+��� $��30,10q� 
 titulo#��[ Asignar tickets�� -   $��btActualizar��$��290,0q� � ToolTip$ Actualizar Ventana��
�������$��1q�$��35��
������ .���� $
��Fill=�$��../Imagenes/refresh.png��&   System.Windows.Controls.DataGrid  -   $��dgTickesPendientes��$   HorizontalScrollBarVisibility$ Hidden=�"   VerticalScrollBarVisibility$ Visible=�   	RowHeight$ 50Q�$	��620��$
��Left=�$��Center=�$��Center=�$��
30,10,0,10q�	   CanUserAddRows	 .  
�������$	��300��$
 �� IsSynchronizedWithCurrentItem$

 TrueY�   AutoGenerateColumns .  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 48    Header$ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ Id�   . $	 180 $ Descripción�� �� *Descripcion+   .    MaxWidth$	 155Q�$ Fecha de Entrada�� �� *FechaEntrada+4  .System.Windows.Controls.DataGridTemplateColumn  -   	combo��$ 
Asignar a:�� .    CellTemplate �� .R���  ��Name$ 
cbTecnicos��-   $
��Left=�$	��115������ *
Tecnicos+�� $��0��$��1��$
��Left=�$ Vertical=�.+��� $��
70,85,10,0q�$ 
Horizontal=�.+���   
labelTitle#��[ $	��180��.��
Nº Ticket�� -   $��tbNumTicket��$��Center=����� *Id+�� $��
70,10,10,0q�$ 
Horizontal=�.+��� #��[ $	��180��.��	Id Equipo�� $��Center=����� *
IdEquipo+�� $��
70,10,10,0q�$ 
Horizontal=�.+��� #��[ $	��180��.��	Usuario�� $��Center=����� *	Usuario+�� $��
70,10,10,0q�$ 
Horizontal=�.+��� #��[ $	��180��.��Fecha de Entrada�� $��Center=����� *FechaEntrada+�� $��
70,10,10,0q�$ 
Horizontal=�.+��� #��[ $	��180��.��Sede�� $��35��$	��199��$��Center=�$��0q�$
��Wrap=����� *Sede+�� $��
70,10,10,0q�$ Vertical=�.+��� $
��Left=�#��[ $	��200��.��Descripcion�� 
�������$	��400��$
��0,10q�._���  �� TextAlignment$
 Left=�$	��380��$��50��$��10q�$
��Wrap=����� *Descripcion+�� -   $��panelGraficas��$��0��$��1��$	��455��
�������$ 
Horizontal=�.+�9   3De.TorstenMandelkow.MetroChart.ClusteredColumnChart  -   $��
columnGrap��$��	10,0,0,20q�$	��599��.   (De.TorstenMandelkow.MetroChart.ChartBase   ChartSubTitle$ Horas��   
ChartTitle$! Tiempo medio de Resolución��
�������   ChartLegendVisibility$ Visible=�   Series 0	   *De.TorstenMandelkow.MetroChart.ChartSeries	   	  SeriesTitle$
 Día�� 	  DisplayMember$	 Day�� 	  ValueMember$ Count������ �� $��1��$��1��
�������$	��455��.+�5
   /De.TorstenMandelkow.MetroChart.RadialGaugeChart
  -	   $��pieChart��$	��400��$	��490��$��Center=�$��0,0,0,40q�$ Actuales��$ Tickets asignados��
������� 	  $ My Population Series��$
 Name��$ Count������ �� -
   $��	statusBar��
�������$��2��$��2��$��0��$��50��.@��� -   $��tbStatusInformation��
�������$��10q�