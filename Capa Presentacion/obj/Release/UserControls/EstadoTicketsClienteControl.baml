   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  6    0Capa_Presentacion.UserControls.HomeTicketControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  :d2http://schemas.microsoft.com/expression/blend/2008  8local,clr-namespace:Capa_Presentacion.UserControls  .��� -   $��panelPrincipal��
�������  � RowDefinitions  �� $��80 ��� $	��740 ��� $��50 �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $
��Left=�$��Center=� 
  titulo#��[  $��
70,0,100,0q�Estado tickets pendientes�� $��1��$ Vertical=�$
��Left=�.+��� 
�����p�$��70,10q�  
labelTitle#��[ .��TICKETS EN CURSO:�� -   $��lbInformacion��$��70,10q�
�����p�$��16(�$y�	Collapsed=�.��Sin tickets en curso.�� $ 
Horizontal=�.+��� -   $��	cbTickets��$	��300��$
��Left=�$��70,10,20,10q�$��30������ �� -   $��btActualizar��$	��0,0q� � ToolTip$ Actualizar Ventana��
�������$��1q�$��35��
������ .���� $
��Fill=�$��../Imagenes/refresh.png���� -   $��	imgEstado��$��../Imagenes/asignada.png��$	��700��$��70,10q�$
��Left=��� -   $��lvNotificaciones��$
��Left=�$��70,10q��� -   $��	bdValorar��$ Vertical=�$y�Hidden=�.+��� $
��Left=�$��	70,0,0,20q�$	��260��$��70�� �� CornerRadius$ 12��
�������$��2q�._��� $ Vertical=�.+��� -   $��	btValorar��$��70��
�������$ 
Horizontal=�.+��� $
��Left=�$��Center=�$
��10,5q�$��50��$��50��$��../Imagenes/rate.png���� $��Center=�$��SemiBold"�
�����p�$��16(�$��0,0,0,0q�VALORAR RESOLUCIÓN�� $��	70,0,0,10q�
���\\��$
��Bold"�Valorar antes de:�� -	   $��tbFechaLimite��$��	70,0,0,20q�$	��200��$
��Left=��� $ Vertical=�$��2���� -
   $��	statusBar��
�������$��3��$��50��.@��� -   $��tbStatusInformation��
�������$��10q�