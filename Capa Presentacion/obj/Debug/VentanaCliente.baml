   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Capa_PresentacionCapa_Presentacion  5   	   O,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5   
   &     Capa_Presentacion.VentanaCliente   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   +localclr-namespace:Capa_Presentacion  5   	   9local2,clr-namespace:Capa_Presentacion.UserControls  5   
     � Title$  VentanaUsuario��5
   	   $	��950��6    $
��1200��6-    � WindowStyle$
 None=�6:   $��3q�6N   ���#d8e9e7 � 
ResizeMode$ NoResize=�6z    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5         SalmonColor �� Color  OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value  contractPrincipal  	CloseMenu  expandPrincipal��%�  &	        &	 &     &	 �     &	 �    &	 �    �� 5   
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
   �� -   5        $��BarraSistema��5;      $��0��6L    �� Orientation$ 
Horizontal=�6Y   ���#356d67$��30��6�   .+�5<      �� $��Center=�6   
�������.��6C   Alitec HelpDesk6U   �� 5=      -   5         ��Name$ btMinimizar��5=       � ToolTip$ Minimizar aplicación��6*   $��
1000,0,0,0q�6I   $��Right=�6x   $��Center=�6�    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6�   ���	#FF31577E��6�   Z� ��6  Z� .��5>      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�6*   
�������
������ $��25��6d   $��25��6o   5?      �� 5@      -   5        $ btClose��5@      $ Cerrar aplicación��6<   $��Right=�6Y   $��Center=�6u   #��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5A        $ Close=�6*   
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
 Bell=�6/   $ Ver Notificaciones��6;   
�����p�
������ $��40��6�   $��40��6�   5I      �� 5J      
��� ���$��	0,10,0,20q�6-    �� CornerRadius$ 15��6@   $��20��6R   $��20��6^   ._�5K      �� -   5        $��tbNumNotifi��5K   8    �� TextAlignment$ Center=�6    $��20��6K   $��10(�6V   
�������$��Center=�6w   $
��Left=�6�    K� ZIndex$ -4��6�   6�   5L      '  !MaterialDesignThemes.Wpf.PopupBox  5O         PlacementMode$ BottomAndAlignRightEdges=�6'   $��50��6P   $��50��6[      	StaysOpen .     ToggleContent 5P        5Q      $ Settings=�6.   $  Opciones de configuración��6>   $��40��6b   $��40��6n   
�����p�6y      PopupContent. 5S      �� $	��220��6   .+�5T      �� -   5        $��btSonido��5T      $��Sonido��6c   ���	#FF5F8D746t   �� 5U      -   5        $��btCambiarPassword��5U      $��Cambiar Contraseña��6V   5V      5W      5Y      �� 5Z   
   $ 
Horizontal=�6   $��2��6.   .+�5[      �� -	   5        $��	panelMenu��5[      $
��Left=�6+   $	��100��6G   ���#d8e9e7$ Vertical=�6h   .+�5\      �� $ Vertical=�6!   .+�5]      �� $��Center=�6    $��90��6=   $��/Imagenes/logo.png��6I   $��10q�6e   6s   �� 5_      -
   5        $��lvMenu��5_   #   
�������$��Disabled=�6I   .@�5a      �� -   5        $��lvHome��5a   +   $��60��69   .��5b      �� $ 
Horizontal=�6*   .+�5c   "   �� $��Center=�6(   $��Center=�6E   $��40��6a   $��40��6l   $��	20,0,30,0q�6y   $��/Imagenes/home.png��6�   6�   �� 5d   "   $��Center=�6(   .��6C   Estado Tickets6S   5e   #   5f      �� 5h      -   5        $��lvCrear��5h   ,   $��60��6;   .��5i   "   �� $ 
Horizontal=�6/   .+�5j   "   �� $��Center=�6(   $��Center=�6E   $��40��6`   $��40��6k   $��	20,0,30,0q�6w   $��/Imagenes/addTicket.png��6�   6�   �� 5k   )   $��Center=�6/   .��6L   Crear Ticket6Z   5l   #   5m      �� 5o      -   5        $��lvVer��5o   ,   $��60��69   .��5p   "   �� $ 
Horizontal=�6/   .+�5q   "   �� $��Center=�6(   $��Center=�6E   $��40��6`   $��40��6k   $��	20,0,30,0q�6w   $��/Imagenes/ticket.png��6�   6�   �� 5r   '   $
��Left=�6-   $��Center=�6H   .��6d   Ver Histórico6s   5s   #   5t      5u      �� 5x      $ 
Horizontal=�6%   $��	5,430,5,0q�6?   .+�5y      �� $��Bottom=�6%   $��/Imagenes/usuario.png��6@   $��80��6_   $
��Fill=�6j   $��0,0,0,20q�6y   $	��100��6�   $��Center=�6�   6�   �� 5z      $��Center=�6*   $��10,10q�6E   $ Vertical=�6T   .+�5{      �� -   5        $��tbNombre��5{   <   $
��Wrap=�6(   $��40��6L   $	��140��6Y   Alberto Moreno Fernández6�   �� 5|   "   -   5        $��tbRol��5|   ,   $��20��69   $��5q�6E   $	��140��6P   administrador6l   �� 5}      -   5        $��tbMail��5}   <   $
��Wrap=�6(   $��40��6L   $	��140��6X   ramonchu.lopez@alitec.es6   5~      5      5�      5�      �� 5�      -   5        $��panelPrincipal��5�      $	��870��6/   $
��1100��6<   5�      5�      5�      5�      