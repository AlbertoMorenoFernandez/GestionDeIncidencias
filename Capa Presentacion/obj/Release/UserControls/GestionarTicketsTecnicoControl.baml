   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  B    <Capa_Presentacion.UserControls.GestionarTecnicoTicketControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:Capa_Presentacion.UserControls     -     � 	Resources  5   /Capa_Presentacion.UserControls.ConvertUsuarioId   userConverter7   1Capa_Presentacion.UserControls.ConvertUserAddress  myAddressConverter��%   &	        &	          .���� -   $��panelGestionar�� �� Orientation$ Vertical=�
�������$��Right=� � DataContext �� .+��� $	��820��$ Vertical=�.+���  
 titulo#��[ $��
70,10,0,10q�Gestionar Ticket�� $ 
Horizontal=�.+��� $��70,0,0,0q�$	��100��  
labelTitle#��[ .��Nº Ticket:�� $
��0,10q�$	��500��$
��Left=����� *	NumTicket+�� #��[ $	��150��$��0,0,0,0q�.��
Usuario:�� $
��0,10q�$	��300������ *	IdUsuario+ �� 	Converter# [  �� $ 
Horizontal=�.+��� #��[ $	��100��$��70,0,0,0q�$
��Left=�.��
Dirección�� $	��500��$
��0,10q����� *	IdUsuario+# [ �� #��[ $	��150��$��0,0,0,0q�.��Fecha de entrada:�� $
��0,10q����� *FechaEntrada+�� $ 
Horizontal=�.+��� -   $��tbTituloIdEquipo��#��[ $��70,0,0,0q�$	��100��.��	IdEquipo:�� -   $��
tbIdEquipo��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Service Tag�� �� 	MaxLength$ 6��$��0,0,0,10q�$	��300��$
��Left=����� *
IdEquipo+�� $ 
Horizontal=��� $��2q�
������� �� CornerRadius$ 5��$	��150��$��70,10,70,10q�
�������._��� $��20q����� *Descripcion+�� $ 
Horizontal=�$	��300��.+��� $ Vertical=�$	��500��.+��� $��70,10,10,10q�#��[ .��Estado�� -   $��cbEstado��$��70,10,10,10q�$	��299��$
��Left=��� -   $��tbCategoria��$��70,10,10,10q�#��[ .��
Categoría�� -   $��cbCategoria��$��70,10,10,10q�$	��299��$
��Left=��� $ Vertical=�$	��600��$��Right=�.+��� -   $��tbTituloResolucion��#��[ $��75,10,10,10q�.��Motivo�� -	   $��BdResolucion��$ 9��$	��150��$	��450��$��10,10,70,10q�
�������$��Right=�._��� -
   $��tbResolucion�� �� TextWrapping$
 Wrap=�  longTextbox#��[ $��0q�$	 200��$ Máximo 200 carácteres��$	��100��$	��430��$��10q��� $ 
Horizontal=�$
��Left=�$��
700,20,0,0q�.+��� -   $��btActualizar��$	��140��$��10q�
�������
�����p�.���� .��_ACTUALIZAR�� -   $��btVolver��$	��140��$��10q�
�������
�����p�.���� .��	_VOLVER�� -   $��	statusBar��
�������$��3��$��50��.@��� -   $��tbStatusInformation��
�������$��10q�