   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  A    ;Capa_Presentacion.UserControls.GestionarTicketsAdminControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:Capa_Presentacion.UserControls     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � 	Resources  5   /Capa_Presentacion.UserControls.ConvertUsuarioId   usuarioConverter7   1Capa_Presentacion.UserControls.ConvertUserAddress  direccionConverter5   /Capa_Presentacion.UserControls.ConvertTecnicoId  tecnicoConverter<   6Capa_Presentacion.UserControls.ConvertTecnicianAddress  tecnicoAddressConverter��%<   &	        &	      &	 
     &	              .��� -   $��gdPrincipal��
������� � DataContext ��  � RowDefinitions �� $��80 ��� $	��220 ��� $	��140 ��� $	��300 ��� $��80 ��� $��50 �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $
��Left=�$��Center=� 
 titulo#��[ $��70,0,0,0q�Gestionar Ticket�� $ Vertical=�$��1��.+��� $ 
Horizontal=�$��65��.+��� $��70,0,0,0q�$	��150��$��Center=�  
labelTitle#��[ .��Nº Ticket:�� -   $��TbNumTicket��$	��250��$��Center=����� *	NumTicket+�� $	��150��$��Center=�#��[ .��
Id Equipo:�� -   $��
TbIdEquipo��$	��150��$��Center=����� *
IdEquipo+�� $	��100��$��Center=�#��[ .��	Estado:�� -    ��Name$ 	imgEstado��$
��Left=�$	��115������  �� 
TargetType" �� �� Triggers ��  �� Binding �� *Estado+ �� Value 1.a��� 	 �� Property	 � ��
 �� Value$"
 ../Imagenes/estadoCreada.png����  �� *Estado+ 2.a��� 	 � ��$$
 ../Imagenes/estadoAsignada.png����  �� *Estado+ 3.a��� 	 � ��$#
 ../Imagenes/estadoEnCurso.png����  �� *Estado+ 4.a��� 	 � ��$&
  ../Imagenes/estadoFinalizada.png����  �� *Estado+ 5.a��� 	 � ��$%
 ../Imagenes/estadoPendiente.png���� $ 
Horizontal=�.+��� $��70,0,0,0q�$	��150��$��Center=�#��[ .��
Usuario:�� -   $��	tbUsuario��$	��250��$��Center=����� *	IdUsuario+ �� 	Converter# [  �� $	��150��$��Center=�#��[ .��Dirección:�� -   $��tbDireccion��$	��450��$��Center=����� *	IdUsuario+# [ �� $ 
Horizontal=�$��65��.+��� $��70,0,0,0q�$	��150��$��Center=�#��[ .��Fecha de entrada:�� -   $��tbFecha��$	��250��$��Center=����� *FechaEntrada+�� $	��150��$��Center=�#��[ .��Categoria::�� -	   $��cbCategoria��$	��200��$��30������ �� $��60��$
��70,0q�
������� �� CornerRadius$ 10��$	��950��._��� $��10,10q����� *Descripcion+�� $ 
Horizontal=�$��2��.+��� $ Vertical=�$	��550��.+��� $��	70,10,0,0q�#��[ .��Resolución�� -
   $��tbResolucion�� �� 	MaxLength$	 200��  longTextbox#��[ $��70,0,0,0q� �� TextWrapping$
 Wrap=�$��0q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Máximo 200 carácteres��
�������$	��400��$��90������ *
Resolucion+�� $ Vertical=�$	��550��.+��� $��	70,10,0,0q�#��[ .��Notas Técnico:�� -   $��tbNotasTecnico��$��	70,0,0,10q�$	 200��#��[ $��0q�$
 Wrap=�$ Máximo 200 carácteres��
�������$	��400��$��90������ *NotasTecnico+�� $ 
Horizontal=�$��3��.+��� $ Vertical=�$	��550��$
��0,15q�.+��� -   $��lbTituloReloj��$��	70,30,0,0q�#��[ .��TIEMPO RESOLUCIÓN:�� $ 
Horizontal=�.+��� -   $��imgRelojSLA��$	��110��$��../Imagenes/lejosSLA.png��$
��70,0q��� -   $��tbTiempoResolucion��$��65(�$��Bottom=�04:30�� $ 
Horizontal=�.+�	� -   $��	rbAsignar��$��70,20q�.��
Asignar a:	� -   $��rbCerrar�� d� 	IsChecked$
 TrueY�$
��0,20q�.��Cerrar�� -   $��
cbTecnicos��$y�Hidden=�$��40��$
��70,0q����� �� $ Vertical=�$	��550��.+��� $ 
Horizontal=�.+��� $��	70,50,0,0q�$	��150��$��Center=�#��[ .��	Técnico:�� -   $��	tbTecnico��$	��250��$��0,50,0,0q�$��Center=����� *TecnicoAsignado+# [ �� $ 
Horizontal=�.+��� $��	70,10,0,0q�$	��150��$	��top=�#��[ .��Dirección:�� -   $��tbTecnicoDireccion��$��50��$
��Wrap=�$	��250��$��0,10,0,0q�$��Center=����� *TecnicoAsignado+# [ �� $ 
Horizontal=�$
��0,40q�.+��� 
�������$ 10��$��2q�$	��100��$	��100��
�������$��70,10,20,10q�._��� .+��� -   $��tbAsignadas��$��60(�$��Center=�$��70��$	��Top=�-�� $��18(�$��30��$��Bottom=�$��Center=�$��0,0,0,20q�	Asignadas�� 
�������$ 10��$��2q�$	��100��$	��100��
�������$��
0,10,20,10q�._��� $ Vertical=�.+��� -   $��tbPendientes��$��60(�$��Center=�
���\\��$��70��$	��Top=�-�� $��18(�$��30��
���\\��$��Bottom=�$��Center=�$��0,0,0,20q�
Pendientes�� $ 
Horizontal=�$��4��$��Right=�.+��� -   $��btVolver��  RegularButton#��[ .���� .��	_VOLVER�� -   $��btActualizar��#��[ $��	30,0,70,0q�.���� .��_ACTUALIZAR�� -   $��	statusBar��
�������$��5��$��50��.@��� -   $��tbStatusInformation��
�������$��10q�