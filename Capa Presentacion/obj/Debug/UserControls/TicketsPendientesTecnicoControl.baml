   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      9    3Capa_Presentacion.UserControls.TicketTecnicoControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      8local,clr-namespace:Capa_Presentacion.UserControls  5        � 	Resources  5
      5   /Capa_Presentacion.UserControls.ConvertUsuarioId   myConverter��%   &	          5   
   67   5      .��5      � -   5        $��panelPrincipal��5      
�������$
��1100��65   .+�5   
   �� $	��870��6    �� Orientation$ Vertical=�6"   .+�5      �� $ Vertical=�6   $	��820��60   .+�5      ��  
 titulo#��[ 6   $��
70,10,0,10q�6<   Seleccionar Ticket6d   �� 5      -   5        $��tbSinTickets��5      $��80,10,10,10q�6-   $y�	Collapsed=�6B   .��6Y   Sin tickets pendientes6q   �� 5      -   5         ��Name$ 
myListView��5      $
��1000��6/   $	��700��6<   $��70,10,10,10q�6I   $
��Left=�6^   ��6y   �� ��5      �� 5      .R�5      �� $ Vertical=�6)   .+�5   "   �� $
��Bold"�6,   $	��0,5q�6>   ��5   &   �� 5   *    �� 
TargetType" ��60    �� Triggers 5   .   �� 5   2    �� Binding 6>   �� *Estado+ �� Value 46Y   .a�5   6   ��  �� Property � �� �� Value$ 
Finalizada��6M   �� 5   6    � ��
 � � �6c   5   3   �� 5   2    6>   �� *Estado+ 36Y   .a�5    6   ��  � ��$ En Curso��6M   �� 5!   6    � ��
 � ���6d   5"   3   �� 5#   2    6>   �� *Estado+ 26Y   .a�5$   6   ��  � ��$ Asignada��6M   �� 5%   6    � ��
 � � �6c   5&   3   �� 5'   2    6>   �� *Estado+ 56Y   .a�5(   6   ��  � ��$ 	Pendiente��6M   �� 5)   6    � ��
 �\\��6g   5*   3   5-   +   5/   &   �� 50   "   $ 
Horizontal=�6-   $��0q�6F   .+�51   &   �� $ 
Horizontal=�61   $	��750��6J   .+�52   *   �� $
��Bold"�64   $��0,0,20,0q�6F   
Id ticket:6d   �� 53   *   ��64   �� *	NumTicket+�� 54   *   $
��Bold"�64   $��	20,0,20,0q�6F   
Usuario:6c   �� 55   *   ��64   �� *	IdUsuario+	 �� 	Converter#	 [  �� 56   *   $
��Bold"�64   $��	20,0,20,0q�6F   Fecha de entrada:6l   �� 57   *   ��64   �� *FechaEntrada+58   '   �� 59   &   $��30��6,   $��Bottom=�67   $��	130,0,0,0q�6R   $��/Imagenes/editTicket.png��6e   6�   5:   #   �� 5;   "   $
��Bold"�6,   $��5q�6>   Descripción:6W   �� 5<   "   
 �� CornerRadius$
 20��6)   $��60��6;   $	��750��6G   $��2q�6S   $
��Left=�6g   
�������._�5=   &   �� $��10q�6N   ��61   �� *Descripcion+6\   5?   #   5@      5B      5D      5E      �� 5F      -   5        $��	statusBar��5F   0   
�������$��50��6A   .@�5G      �� -   5        $��tbStatusInformation��5G   /   
�������$��10q�6J   6X   5H      5I      5J      5K      