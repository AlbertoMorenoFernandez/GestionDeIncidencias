   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Capa_PresentacionCapa_Presentacion  5   	   O,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5   
   &     Capa_Presentacion.VentanaCliente   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   +localclr-namespace:Capa_Presentacion  5   	   9local2,clr-namespace:Capa_Presentacion.UserControls  5   
     � Title$  VentanaUsuario��5
   	   $	��960��6    $
��1200��6-    � WindowStyle$
 None=�6:   
�������$��1q�6e    � 
ResizeMode$ NoResize=�6z    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5         SalmonColor �� Color  OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value  contractPrincipal  	CloseMenu  expandPrincipal��%�  &	        &	 &     &	 �     &	 �    &	 �    �� 5   
   $ #d8e9e7��6.   6@   �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ 	panelMenu��6a   .\�5        $ 0��6'   $		 100Q�63     5      $ 0:0:0.3��6'   $		 250Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ panelPrincipal��6a   .\�5        $ 0��6'   $
	 1100Q�63     5      $ 0:0:0.3��6'   $		 950Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ 	panelMenu��6a   .\�5        $ 0��6'   $		 250Q�63     5      $ 0:0:0.3��6'   $		 100Q�69   5      5      �� 5   
   .��5       U� $ (FrameworkElement.Width)�6,   $ panelPrincipal��6a   .\�5!        $ 0��6'   $		 950Q�63     5"      $ 0:0:0.3��6'   $
	 1100Q�69   5#      5$      5%      
 � Triggers
 5&      :� 5'   
    :� RoutedEvent$ StackPanel.MouseEnter��6    :� 
SourceName$ 	panelMenu��6<   .[�5(      �� #��[ 6   �� 5)      #��[ 6   5+      :� 5,   
   $ StackPanel.MouseLeave��6   $ 	panelMenu��6;   .[�5-      �� #��[ 6   �� 5.      #��[ 6   50      .��55      �  � RowDefinitions 56   
   �� 57      $��30 �6   6*   �� 58      $��50 �6   6*   �� 59      $��* �6   6)   .+�5;   
   �� -   5        $��BarraSistema��5;      $��0��6)    �� Orientation$ 
Horizontal=�66   ���#356d67$��30��6e   .+�5<      �� $��Center=�6   
�������Alitec HelpDesk6Y   �� 5=      -   5         ��Name$ btMinimizar��5=      $��
1010,0,0,0q�6+   $��Right=�6Z   $��Center=�6v    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5>      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�6*   
�������
������ $��25��6d   $��25��6o   5?      �� 5@      -   5        $ btClose��5@      $��Right=�6>   $��Center=�6Z   #��[ 6u   ���	#FF31577E��6�   Z� ��6�   Z� .��5A        $ Close=�6*   
�������
������ $��25��6d   $��25��6o   5B      5C      �� 5D   
   -   5        $��BarraNotificaciones��5D   "   $��1��6   $��50��6=   $
��1200��6I   $	��Top=�6V   $
��Left=�6n   $ 
Horizontal=�6�   
�������.+�5G      �� -   5        $ btNotificaciones��5G      $��
1090,0,0,0q�63   
�������$��36��6z   $��40��6�   $��Center=�6�   $��Center=�6�   #��[ 6�   
������ ��6)  Z� .��5H        $
 Bell=�6/   
�����p�
������ $��40��6m   $��40��6x   5I      �� 5J      
��� ���$��	0,10,0,20q�6-    �� CornerRadius$ 15��6@   $��20��6R   $��20��6^   ._�5K      �� -   5        $��tbNumNotifi��5K   8    �� TextAlignment$ Center=�6    $��20��6K   $��10(�6V   
�������$��Center=�6w   $
��Left=�6�    K� ZIndex$ -4��6�   6�   5L      '  !MaterialDesignThemes.Wpf.PopupBox  5O         PlacementMode$ BottomAndAlignRightEdges=�6'   $��50��6P   $��50��6[      	StaysOpen .     ToggleContent 5P        5Q      $ Settings=�6.   $��40��6>   $��40��6J   
�����p�6U      PopupContent. 5S      �� $	��220��6   .+�5T      �� $��Sonido��6   �� 5U      $��Restablecer Password��6   �� 5V      $
��Help��6   �� 5W      �� 5X      $��Logout��6   5Y      5Z      5\      �� 5]   
   $ 
Horizontal=�6   $��2��6.   .+�5^      �� -   5        $��	panelMenu��5^      $
��Left=�6+   $	��100��6G   ���#d8e9e7$ Vertical=�6h   .+�5_      �� $ Vertical=�6!   .+�5`      �� $��Center=�6    $��90��6=   $��/Imagenes/logo.png��6I   $��10q�6e   6s   �� 5b      -   5        $��lvMenu��5b   #   
�������$��Disabled=�6I   .@�5d      �� -	   5        $��lvHome��5d   +   $��60��69   .��5e      �� $ 
Horizontal=�6*   .+�5f   "   �� $��Center=�6(   $��Center=�6E   $��40��6a   $��40��6l   $��	20,0,30,0q�6y   $��/Imagenes/home.png��6�   6�   �� 5g   "   $��Center=�6,   Inicio6O   5h   #   5i      �� 5k      -
   5        $��lvCrear��5k   ,   $��60��6;   .��5l   "   �� $ 
Horizontal=�6/   .+�5m   "   �� $��Center=�6(   $��Center=�6E   $��40��6`   $��40��6k   $��	20,0,30,0q�6w   $��/Imagenes/addTicket.png��6�   6�   �� 5n   )   $��Center=�63   Crear Ticket6^   5o   #   5p      �� 5r      -   5        $��lvVer��5r   ,   $��60��69   .��5s   "   �� $ 
Horizontal=�6/   .+�5t   "   �� $��Center=�6(   $��Center=�6E   $��40��6`   $��40��6k   $��	20,0,30,0q�6w   $��/Imagenes/ticket.png��6�   6�   �� 5u   '   $
��Left=�61   $��Center=�6L   
Histórico6s   5v   #   5w      5x      �� 5{      $ 
Horizontal=�6%   $��	5,490,5,0q�6?   .+�5|      �� $��Bottom=�6%   $��/Imagenes/usuario.png��6@   $��80��6_   $��0,0,0,20q�6j   $��80��6|   $��Center=�6�   6�   �� 5}      $��Bottom=�6*   $
��10,0q�6E   $ Vertical=�6S   .+�5~      �� -   5        $��tbNombre��5~   (   $��36��68   $	��140��6D   $
��Wrap=�6Q   Alberto Moreno Fernández6   �� 5   "   -   5        $��tbRol��5   ,   $��18��69   $��5q�6E   $	��140��6P   administrador6l   �� 5�   "   -   5        $��tbMail��5�   ,   $
��Wrap=�6:   $��38��6N   $	��140��6Z   ramonchu.lopez@alitec.es6�   5�      5�      5�      5�      �� 5�      -   5        $��panelPrincipal��5�      $	��870��6/   $
��1100��6<   5�      5�      5�      5�      