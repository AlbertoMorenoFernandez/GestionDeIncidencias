   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Capa_PresentacionCapa_Presentacion  5   	   &     Capa_Presentacion.VentanaTecnico   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +localclr-namespace:Capa_Presentacion  5   	     � Title$  VentanaTecnico��5	   	   $	��950��6    $
��1200��6-    � WindowStyle$
 None=�6:   $��3q�6N   ���#d8e9e7 � 
ResizeMode$ NoResize=�6y    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5         SalmonColor �� Color  OpenMenu �� TargetProperty �� 
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
   $ StackPanel.MouseLeave��6   $ 	panelMenu��6;   .[�5-      �� #��[ 6   �� 5.      #��[ 6   50      .��56      �  � RowDefinitions 57   
   �� 58      $��30 �6   6*   �� 59      $��50 �6   6*   �� 5:      $��* �6   6)   .+�5=   
   �� -   5        $��BarraSistema��5=      $��0��6L    �� Orientation$ 
Horizontal=�6Y   ���#356d67$��30��6�   .+�5>      �� $��Center=�6   
�������.��6C   Alitec HelpDesk6U   �� 5?      -   5         ��Name$ btMinimizar��5?       � ToolTip$ Minimizar aplicación��6*   $��
1000,0,0,0q�6J   $��Right=�6y   $��Center=�6�    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6�   ���	#FF31577E��6�   Z� ��6  Z� .��5@      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�6*   
�������
������ $��25��6d   $��25��6o   5A      �� 5B      -   5        $ btClose��5B      $��Right=�6>   $��Center=�6Z   #��[ 6u   ���	#FF31577E��6�   Z� ��6�   Z� .��5C        $ Close=�6*   $ Cerrar Aplicación��67   
�������
������ $��25��6�   $��25��6�   5D      5E      �� 5F   
   -   5        $��BarraNotificaciones��5F   "   $��1��6   $��50��6=   $
��1200��6I   $	��Top=�6V   $
��Left=�6n   $ 
Horizontal=�6�   
�������.+�5H      �� -   5        $ btNotificaciones��5H      $��
1090,0,0,0q�6/   
�������$��36��6v   $��40��6�   $��Center=�6�   $��Center=�6�   #��[ 6�   
������ ��6%  Z� .��5I        $
 Bell=�6+   $ Ver notificaciones��67   
�����p�
������ $��40��6�   $��40��6�   5J      �� 5K      
��� ���$��	0,10,0,20q�6)    �� CornerRadius$ 15��6<   $��20��6N   $��20��6Z   ._�5L      �� -   5        $��tbNumNotifi��5L   4    �� TextAlignment$ Center=�6   $��20��6G   $��10(�6R   
�������$��Center=�6s   $
��Left=�6�    K� ZIndex$ -4��6�   6�   5M      '  !MaterialDesignThemes.Wpf.PopupBox  5P         PlacementMode$ BottomAndAlignRightEdges=�6'   $��50��6P   $��50��6[      	StaysOpen .     ToggleContent 5Q        5R      $ Settings=�6.   $  Opciones de configuración��6>   $��40��6b   $��40��6n   
�����p�6y      PopupContent. 5T      �� $	��220��6   .+�5U      �� -   5        $��btSonido��5U      ���	#FF5F8D74$��Sonido��6~   �� 5V      -   5        $��btCambiarPassword��5V      $��Cambiar contraseña��6V   5W      5X      5Z      �� 5\   
   $ 
Horizontal=�6   $��2��6.   .+�5]      �� -	   5        $��	panelMenu��5]      $
��Left=�6+   $	��100��6G   ���#d8e9e7$ Vertical=�6h   .+�5^      �� $ Vertical=�6   .+�5_      �� $��Center=�6   $��90��69   $��/Imagenes/logo.png��6E   $��10q�6a   6o   �� 5a      -
   5        $��lvMenu��5a      
�������$��Disabled=�6E   .@�5c      �� -   5        $��lvMisTickets��5c   '   $��60��6;   .��5d      �� $ 
Horizontal=�6*   .+�5e   "   �� $��Center=�6(   $��Center=�6E   $��40��6a   $��40��6l   $��	20,0,30,0q�6y   $��/Imagenes/ticket.png��6�   6�   �� 5f   "   $��Center=�6,   Mis Tickets6T   5g      5h      �� 5k      -   5        $��lvEtiquetas��5k   (   $��60��6;   .��5l      �� $ 
Horizontal=�6+   .+�5m   "   �� $��Center=�6(   $��Center=�6E   $��40��6`   $��40��6k   $��	20,0,30,0q�6w   $��/Imagenes/barcode.png��6�    J� RenderTransformOrigin$ 17.953,9.822&�6�   6�   �� 5n   "   $
��Left=�6,   $��Center=�6G   Crear Etiqueta6s   5o      5p      5q      �� 5t      $ 
Horizontal=�6!   $��	5,490,5,0q�6;   .+�5u      �� $��Bottom=�6!   $��/Imagenes/tecnico.png��6<   $��80��6[   $��0,0,0,20q�6f   $��80��6x   $��Center=�6�   6�   �� 5v      $��Bottom=�6&   $
��10,0q�6A   $ Vertical=�6O   .+�5w      �� -   5        $��tbNombre��5w   <   $
��Wrap=�6(   $��36��6L   $	��140��6X   Alberto Moreno Fernández6�   �� 5x      -   5        $��tbRol��5x   <   $
��Wrap=�6(   $��18��6I   $��5q�6U   $	��140��6`   administrador6|   �� 5y      -   5        $��tbMail��5y   <   $
��Wrap=�6(   $��38��6K   $	��140��6W   ramonchu.lopez@alitec.es6~   5z      5{      5|      5      �� 5�      -   5        $��panelPrincipal��5�      $	��870��6/   $
��1100��6<   5�      5�      5�      5�      