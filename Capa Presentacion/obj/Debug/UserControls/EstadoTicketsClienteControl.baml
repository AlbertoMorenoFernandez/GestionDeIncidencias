   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      6    0Capa_Presentacion.UserControls.HomeTicketControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      8local,clr-namespace:Capa_Presentacion.UserControls  5      .��5
      � -   5        $��panelPrincipal��5
      
�������  � RowDefinitions  5   
   �� 5      $��80 �6   6*   �� 5      $	��740 �6   6+   �� 5      $��50 �6   6*   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $
��Left=�6   $��Center=�63    
  titulo#��[  6O   $��
70,0,100,0q�6o   Estado tickets pendientes6�   5      �� 5   
   $��1��6   $ Vertical=�6#   $
��Left=�6:   .+�5      �� 
�����p�$��70,10q�6/     
labelTitle#��[ 6>   .��6b   TICKETS EN CURSO:6u   �� 5      -   5        $��lbInformacion��5      $��70,10q�6.   
�����p�$��16(�6T   $y�	Collapsed=�6b   .��6y   Sin tickets en curso.6�   �� 5      $ 
Horizontal=�6   .+�5       �� -   5        $��	cbTickets��5    4   $	��300��6E   $
��Left=�6Q   $��70,10,20,10q�6l   $��30��6�   ��6   �� 6�   �� 5!      -   5        $��btActualizar��5!      $	��0,0q�6I    � ToolTip$ Actualizar Ventana��6V   
�������$��1q�6�   $��35��6�   
������ .��5"      �� $
��Fill=�6   $��../Imagenes/refresh.png��6,   6O   5#      5$      �� 5%      -   5        $��	imgEstado��5%   l   $��../Imagenes/asignada.png��6   $	��700��66   $��70,10q�6B   $
��Left=�6Q   6   �� 5&      -   5        $��lvNotificaciones��5&      $
��Left=�6/   $��70,10q�6J   6\   �� 5(      -   5        $��	bdValorar��5(   1   $ Vertical=�6   $y�Hidden=�6C   .+�5)      �� $
��Left=�6   $��	70,0,0,20q�64   $	��260��6G   $��70��6S    �� CornerRadius$ 12��6_   
�������$��2q�6�   ._�5*      �� $ Vertical=�6!   .+�5+      �� -   5        $��	btValorar��5+   &   $��70��68   
�������$ 
Horizontal=�6}   .+�5,      �� $
��Left=�6$   $��Center=�6?   $
��10,5q�6Z   $��50��6h   $��50��6s   $��../Imagenes/rate.png��6   6�   �� 5-      $��Center=�6(   $��SemiBold"�6C   
�����p�$��16(�6p   $��0,0,0,0q�6~   VALORAR RESOLUCIÓN6�   5.      50      51      �� 52      $��	70,0,0,10q�6   
���\\��$
��Bold"�6F   Valorar antes de:6l   �� 53      -	   5        $��tbFechaLimite��53   W   $��	70,0,0,20q�6   $	��200��60   $
��Left=�6<   6o   54      56      �� 57   
   $ Vertical=�6   $��2��6,   5:      �� 5;   
   -
   5        $��	statusBar��5;   9   
�������$��3��6,   $��50��6J   .@�5<      �� -   5        $��tbStatusInformation��5<   +   
�������$��10q�6F   6T   5=      5?      5@      