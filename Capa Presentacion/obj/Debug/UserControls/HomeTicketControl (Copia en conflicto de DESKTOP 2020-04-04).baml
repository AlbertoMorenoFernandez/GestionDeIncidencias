   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      6    0Capa_Presentacion.UserControls.HomeTicketControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      8local,clr-namespace:Capa_Presentacion.UserControls  5      .��5
      � -   5        $��panelPrincipal��5
      
�������$��Right=�64   $
��1100��6P     � RowDefinitions  5   
   �� 5      $��80 �6   6*   �� 5      $	��740 �6   6+   �� 5      $��50 �6   6*   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $
��Left=�6   $��Center=�63    
  titulo#��[  6O   $��
40,0,100,0q�6o   !Bienvenido al gestor de tickets6�   5      �� 5   
   $��1��6   $ Vertical=�6#   $
��Left=�6:   .+�5      �� 
�����p�$��40,10q�6+   $
��Bold"�6:   .��6L   TICKETS EN CURSO:6_   �� 5      -   5        $��	cbTickets��5   0   $	��300��6A   $
��Left=�6M   $��48,10q�6h   $��30��6w   ��6   �� 6�   �� 5      -   5        $��	imgEstado��5   l   $��../Imagenes/asignada.png��6   $	��300��66   $��20,10q�6B   $
��Left=�6Q   6   �� 5      -   5        $��lvNotificaciones��5      $
��Left=�6/   $��40,10q�6J   6\   �� 5!      -   5        $��	bdValorar��5!      $y�Hidden=�6&   $
��Left=�6:   $��	40,0,0,20q�6U   $	��210��6h    �� CornerRadius$ 8��6t   
�������$��2q�6�   ._�5"      �� -   5        $��	btValorar��5"      
�������$ 
Horizontal=�6g   .+�5#      �� $
��Left=�6   $��Center=�67   $
��10,5q�6R   $��40��6`   $��../Imagenes/rate.png��6k   6�   �� 5$      $��Center=�6    $
��Bold"�6;   $��0,0,0,0q�6M   Valorar Resolución6r   5%      5&      5(      �� 5)   
   $ Vertical=�6   $��2��6,   5,      �� 5-   
   $��3��6   6#   5/      50      