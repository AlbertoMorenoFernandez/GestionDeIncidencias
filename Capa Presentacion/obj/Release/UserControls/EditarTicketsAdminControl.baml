   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  >    8Capa_Presentacion.UserControls.EditarTicketsAdminControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:Capa_Presentacion.UserControls     -     � 	Resources  5   /Capa_Presentacion.UserControls.ConvertTecnicoId   myConverter��%   &	          .��� 
������� � RowDefinitions �� $��80 ��� $	��240 ��� $	��500 ��� $��50 �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $
��Left=�$��Center=� 
 titulo#��[ $��70,0,0,0q�Editar Ticket�� $��1��$��	70,5,30,5q�.+��� $ Vertical=�.+��� 
������� �� CornerRadius$ 	15,15,0,0��._��� $ 
Horizontal=�$��50��.+��� $��10,0,0,0q�$
��Bold"�$��Center=�.��	FILTRAR�� $��2q�
�������$ 	0,0,10,10��._��� .+��� $ 
Horizontal=�$��65��.+��� $��10,0,0,0q�$	��100��$��40��$��Center=�  
labelTitle#��[ .��Por IdTicket:�� -   $��
TbIdTicket��$	��170��$��40��
�������$��2q�$
��30,0q��� $��10,0,0,0q�$	��100��$��40��$��Center=�#��[ .��Por Técnico:�� -   $��	TbTecnico��$	��170��$��40��
�������$��2q�$
��30,0q��� $	��100��$��40��$��Center=�#��[ .��Por Usuario:�� -   $��	tbUsuario��$	��170��$��40��
�������$��2q�$
��30,0q��� $ 
Horizontal=�$��65��.+��� $��10,0,0,0q�$	��100��$��40��$��Center=�#��[ .��SLA:�� -   $��cbSLA��$	��170��$��40��
�������$
��30,0q�
�����p�
�������$��2q�.@��� .��TODAS�� .��FUERA DE SLA�� $��10,0,0,0q�$	��100��$��Center=�$��40��#��[ .��Por Estado:�� -   $��cbCategorias��$	��170��$��40��$
��30,0q�
�������
�����p�
�������$��2q�.@��� .��FINALIZADAS�� .��NO FINALIZADAS�� $��2��$��20,0,0,0q�.+�&   System.Windows.Controls.DataGrid  -   $��	dtTickets��$��20q�$	��450��   CanUserAddRows .  
�������
���   �   	RowHeight$ 50Q�$   HorizontalScrollBarVisibility$ Hidden=�   AutoGenerateColumns .  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Nº Ticket��
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	NumTicket+  $	 	Id Equipo��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 
 .  �� *
IdEquipo+4  .System.Windows.Controls.DataGridTemplateColumn  -   
Estado��$	 Estado��
 .    CellTemplate �� .R���  ��Name$ 	imgEstado��$
��Left=�$	��115������  �� 
TargetType" �� �� Triggers ��  �� Binding �� *Estado+ �� Value 1.a���  �� Property � �� �� Value$" ../Imagenes/estadoCreada.png����  �� *Estado+ 2.a���  � ��$$ ../Imagenes/estadoAsignada.png����  �� *Estado+ 3.a���  � ��$# ../Imagenes/estadoEnCurso.png����  �� *Estado+ 4.a���  � ��$&  ../Imagenes/estadoFinalizada.png����  �� *Estado+ 5.a���  � ��$% ../Imagenes/estadoPendiente.png��  $	 Técnico��$	 200 
 .  ��  �� Path$ TecnicoAsignado� �� 	Converter# [    $	 Descripción��$	 350 
 .  �� *Descripcion+  $	 Editar�� �� .R��� $��btDetallesTicket��-	   $��Center=�
������ 
������ .���� $"��../Imagenes/editarTicket.png���� -
   $��	statusBar��
�������$��3��$��50��.@��� -   $��tbStatusInformation��
�������$��10q�