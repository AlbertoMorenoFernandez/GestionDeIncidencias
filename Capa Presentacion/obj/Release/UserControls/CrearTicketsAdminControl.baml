   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  =    7Capa_Presentacion.UserControls.CrearTicketsAdminControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  8local,clr-namespace:Capa_Presentacion.UserControls  .��� 
�������  � RowDefinitions  �� $	��100 ��� $	��260 ��� $	��320 ��� $	��140 ��� $��50 �.+��� .+��� $��
70,20,10,0q� 
  titulo#��[  Crear Ticket��  �� Orientation$ 
Horizontal=�$��1��$��70,10q�.+��� $ Vertical=�.+���   
labelTitle#��[ $	��0,5q�.��Equipo�� $ 
Horizontal=�.+��� -   $��tbEquipo��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Service Tag�� �� 	MaxLength$ 6��$��2q�$
��Left=�
�������$	��250��$��	0,10,10,0q��� -   $��imgVerificar��$��35��$��Bottom=�$y�Hidden=�$��../Imagenes/ok.png���� #��[ $��0,10,0,0q�.��
Asignar a:�� -   $��
cbTecnicos��$��35��$	��250��$��2q�
�������$
��Left=�$��0,10,0,0q��� $ 
Horizontal=�.+��� -   $��chbTecnicos��$��10q��� $��10q�" Asignar a técnico de otra sede.�� -   $��cbTecnicosExternos��$��0,10,0,0q�$y�Hidden=��� $ Vertical=�.+��� #��[ $
��50,0q�.��Descripción�� -   $��tbDescripcion��$	��600�� �� TextWrapping$
 Wrap=�  longTextbox#��[ $��Center=�
�������$	��150��$��50,20,-4,20q� �� TextAlignment$ Justify=� �� AcceptsReturn .  �� 
AcceptsTab . �� $ Vertical=�$��2��.+��� $ 
Horizontal=�.+��� $��../Imagenes/tecnico.png��$��30��$��30��$	��Top=�$��70,10,10,10q��� #��[ $��10,15q�$	��Top=�$��30��.��	Técnico:�� -   $��tbNombreTecnico��$	��250��$��10,20q�$��30��$	��Top=��� #��[ $��10,15,20,20q�$	��Top=�$��30��.��Sede:�� -   $��tbDireccionTecnico��$	��500��$��0,20,0,0q�$��30��$	��Top=��� $ 
Horizontal=�$��70,10q�.+��� $��2q�
������� �� CornerRadius$ 9��
�������$	��120��$	��120��._��� .+��� -	   $��tbAsignadas��$��80(�$��Center=�$��90��$	��Top=�-�� $��20(�$��30��$��Bottom=�$��Center=�$��0,0,0,20q�	Asignadas�� $��2q�
�������$ 9��
�������$	��120��$	��120��$
��40,0q�._��� .+��� -
   $��tbPendientes��$��80(�$��Center=�
���\\��$��90��$	��Top=�-�� $��20(�$��30��
���\\��$��Bottom=�$��Center=�$��0,0,0,20q�
Pendientes�� $��3��$ 
Horizontal=�$��Right=�.+��� -   $��btBorrar��  RegularButton#��[ $
��Left=�$��	70,0,20,0q�.��LIMPIAR DATOS�� -   $��btCrear��#��[ $
��Left=�$��	10,0,20,0q�.��CREAR TICKET�� $��4��.+��� -   $��	statusBar��
�������$��3��$��50��.@��� -   $��tbStatusInformation��
�������$��10q�