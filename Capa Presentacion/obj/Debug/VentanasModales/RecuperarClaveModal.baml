   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Capa_PresentacionCapa_Presentacion  5   	   -    'Capa_Presentacion.VentanaRecuperarClave   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   +localclr-namespace:Capa_Presentacion  5   	     � Title$  VentanaRecuperarClave��5	   	   $	��250��6'   $	��500��64    � AllowsTransparency .  � WindowStyle$
 None=�6[    � WindowStartupLocation$ CenterScreen=�6�   ��6n   Z� .��5
      � .+�5   
   �� 
�������
������� �� CornerRadius$ 20��6=   ._�5      � -   5        $��gdVentanaRecuperar��5       � RowDefinitions 5      �� 5      $��50 �6$   �� 5      $��* �6$   .+�5      �� ���#356d67$ 	20,20,0,0��6.   $��0��6G   ._�5      �� .+�5      �� -   5         ��Name$ btClose��5   !   $��Right=�6I   $��Center=�6e    0  ,MaterialDesignFloatingActionMiniAccentButton#��[  6�   
������ ���	#FF31577E��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�66    � ToolTip$ Pantalla Principal��6C   
�������
������ $��35��6�   $��35��6�   5      5      5      �� 5      $��1��6   $
��Left=�6&   ._�5      �� 	 �� Orientation$	 Vertical=�6!   .+�5      �� $��20q�6    $	��300��6,   .��68   Recuperar clave:6K   �� 5      -   5        $��tbCorreo��5   "   
�������)  #MaterialDesignThemes.Wpf.HintAssist
   Hint$(
 "Introduzca e-mail de recuperación��6E   $��	20,0,10,0q�6�   $��40��6�   
�������$��2q�6�   $	��300��6�   6�   �� 5      $	 
Horizontal=�6%   $
��Left=�6>   $��10q�6Y   .+�5      �� -   5        $��btEnviar��5   %   $��1��65     ModalButton#��[ 6B   $��20,20,10,20q�6g   .��5    "   �� .��6-   	_Enviar66   5!      �� 5"      -   5        $��btSalir��5"   %   $��1��64   #��[ 6A   .��5#   "   �� .��6-   	_Cancelar68   6E   5$      5&      5'      5)      5*      5+      5,      