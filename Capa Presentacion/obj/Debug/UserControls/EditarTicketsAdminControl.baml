   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      >    8Capa_Presentacion.UserControls.EditarTicketsAdminControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Capa_Presentacion.UserControls     5      -   5          � 	Resources  5	      5   /Capa_Presentacion.UserControls.ConvertTecnicoId   myConverter��%   &	          5
   
   67   5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $	��240 �6   6+   �� 5      $	��500 �6   6+   �� 5      $��50 �6   6*   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $
��Left=�6   $��Center=�63    
 titulo#��[ 6O   $��70,0,0,0q�6o   Editar Ticket6�   5      �� 5   
   $��1��6   $��	70,5,30,5q�6"   .+�5      �� $ Vertical=�6   .+�5      �� 
������� �� CornerRadius$ 	15,15,0,0��63   ._�5      �� $ 
Horizontal=�6!   $��50��6:   .+�5      �� $��10,0,0,0q�6    $
��Bold"�62   $��Center=�6D   .��6_   	FILTRAR6h   5      5      �� 5      $��2q�6   
�������$ 	0,0,10,10��6F   ._�5       �� .+�5!      �� $ 
Horizontal=�6%   $��65��6>   .+�5"      �� $��10,0,0,0q�6$   $	��100��66   $��40��6B   $��Center=�6N     
labelTitle#��[ 6i   .��6�   Por IdTicket:6�   �� 5#      -   5        $��
TbIdTicket��5#   &   $	��170��68   $��40��6D   
�������$��2q�6i   $
��30,0q�6}   6�   �� 5$      $��10,0,0,0q�6$   $	��100��66   $��40��6B   $��Center=�6N   #��[ 6j   .��6�   Por Técnico:6�   �� 5%      -   5        $��	TbTecnico��5%   &   $	��170��67   $��40��6C   
�������$��2q�6h   $
��30,0q�6|   6�   �� 5&      $	��100��6$   $��40��60   $��Center=�6<   #��[ 6X   .��6|   Por Usuario:6�   �� 5'      -   5        $��	tbUsuario��5'   &   $	��170��67   $��40��6C   
�������$��2q�6h   $
��30,0q�6|   6�   5)      �� 5*      $ 
Horizontal=�6&   $��65��6?   .+�5+      �� $��10,0,0,0q�6$   $	��100��66   $��40��6B   $��Center=�6N   #��[ 6j   .��6�   SLA:6�   �� 5,      -   5        $��cbSLA��5,   '   $	��170��64   $��40��6@   
�������$
��30,0q�6d   
�����p�
�������$��2q�6�   .@�5-   "   �� .��6/   TODAS66   �� 5.   "   .��6/   FUERA DE SLA6=   5/      �� 50      $��10,0,0,0q�6$   $	��100��66   $��Center=�6B   $��40��6^   #��[ 6j   .��6�   Por Estado:6�   �� 51      -   5        $��cbCategorias��51   '   $	��170��6=   $��40��6I   $
��30,0q�6U   
�������
�����p�
�������$��2q�6�   .@�52   "   �� .��6/   FINALIZADAS6<   �� 53   "   .��6/   NO FINALIZADAS6?   54      55      56      58      59      5;      �� 5<   
   $��2��6   $��20,0,0,0q�6"   .+�5=      &   System.Windows.Controls.DataGrid  -   5        $��	dtTickets��5=      $��20q�6J   $	��450��6W      CanUserAddRows .  
�������
���   �   	RowHeight$ 50Q�6�   $   HorizontalScrollBarVisibility$ Hidden=�6�      AutoGenerateColumns .  ��6�   ��    Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Nº Ticket��6)   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *	NumTicket+6o     5@      $	 	Id Equipo��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6<   
 .  6H   �� *
IdEquipo+6y   4  .System.Windows.Controls.DataGridTemplateColumn  5A      -   5        
Estado��$	 Estado��5A   =   
 .    CellTemplate 5B      �� 5C      .R�5D   "   ��  ��Name$ 	imgEstado��6(   $
��Left=�6;   $	��115��6V   ��5E   &   �� 5F   *    �� 
TargetType" ��60    �� Triggers 5G   .   �� 5H   2    �� Binding 6>   �� *Estado+ �� Value 16Y   .a�5I   6   ��  �� Property � �� �� Value$" ../Imagenes/estadoCreada.png��6O   5J   3   �� 5K   2    6>   �� *Estado+ 26Y   .a�5L   6   ��  � ��$$ ../Imagenes/estadoAsignada.png��6O   5M   3   �� 5N   2    6>   �� *Estado+ 36Y   .a�5O   6   ��  � ��$# ../Imagenes/estadoEnCurso.png��6O   5P   3   �� 5Q   2    6>   �� *Estado+ 46Y   .a�5R   6   ��  � ��$&  ../Imagenes/estadoFinalizada.png��6O   5S   3   �� 5T   2    6>   �� *Estado+ 56Y   .a�5U   6   ��  � ��$% ../Imagenes/estadoPendiente.png��6O   5V   3   5Y   +   5\   #   5]      5_        5a      $	 Técnico��6)   $	 200 6:   
 .  6F   ��  �� Path$ TecnicoAsignado� �� 	Converter# [  6�     5b      $	 Descripción��6)   $	 350 6>   
 .  6J   �� *Descripcion+6�     5c      $	 Editar��6-    5d      �� 5e      .R�5f   "   �� $��btDetallesTicket��6)   -	   5        $��Center=�5f   `   
������ 
������ .��5g   &   �� $"��../Imagenes/editarTicket.png��6,   6T   5h   #   5i      5k      5n      5o      �� 5t   
   -
   5        $��	statusBar��5t   :   
�������$��3��6,   $��50��6K   .@�5u      �� -   5        $��tbStatusInformation��5u   +   
�������$��10q�6F   6T   5v      5w      5x      