   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  9    3Capa_Presentacion.UserControls.TicketTecnicoControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  :d2http://schemas.microsoft.com/expression/blend/2008  8local,clr-namespace:Capa_Presentacion.UserControls    � 	Resources  5   /Capa_Presentacion.UserControls.ConvertUsuarioId   myConverter��%   &	          .��� -   $��panelPrincipal��
�������$
��1100��.+��� $	��870�� �� Orientation$ Vertical=�.+��� $ Vertical=�$	��820��.+���  
 titulo#��[ $��
70,10,0,10q�Seleccionar Ticket�� -   $��tbSinTickets��$��80,10,10,10q�$y�	Collapsed=�.��Sin tickets pendientes�� -    ��Name$ 
myListView��$
��1000��$	��700��$��70,10,10,10q�$
��Left=����� ���� .R��� $ Vertical=�.+��� $
��Bold"�$	��0,5q�����  �� 
TargetType" �� �� Triggers ��  �� Binding �� *Estado+ �� Value 4.a���  �� Property � �� �� Value$ 
Finalizada����  � ��
 � � ���  �� *Estado+ 3.a���  � ��$ En Curso����  � ��
 � �����  �� *Estado+ 2.a���  � ��$ Asignada����  � ��
 � � ���  �� *Estado+ 5.a���  � ��$ 	Pendiente����  � ��
 �\\���� $ 
Horizontal=�$��0q�.+��� $ 
Horizontal=�$	��750��.+��� $
��Bold"�$��0,0,20,0q�
Id ticket:�� ���� *	NumTicket+�� $
��Bold"�$��	20,0,20,0q�
Usuario:�� ���� *	IdUsuario+	 �� 	Converter#	 [  �� $
��Bold"�$��	20,0,20,0q�Fecha de entrada:�� ���� *FechaEntrada+�� $��30��$��Bottom=�$��	130,0,0,0q�$��/Imagenes/editTicket.png���� $
��Bold"�$��5q�Descripción:�� 
 �� CornerRadius$
 20��$��60��$	��750��$��2q�$
��Left=�
�������._��� $��10q����� *Descripcion+�� -   $��	statusBar��
�������$��50��.@��� -   $��tbStatusInformation��
�������$��10q�