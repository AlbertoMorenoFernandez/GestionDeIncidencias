   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5   	   5clr-namespace:Capa_PresentacionCapa_Presentacion  5   	   ,    &Capa_Presentacion.VentanaAdministrador   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      9local2,clr-namespace:Capa_Presentacion.UserControls  5   	   +localclr-namespace:Capa_Presentacion  5   	     � Title$  VentanaAdministrador��5
   	   $	��960��6'   $
��1200��64    � WindowStyle$
 None=�6A   $��3q�6T   ���#d8e9e7 � 
ResizeMode$ NoResize=�6�    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5         SalmonColor �� Color  OpenMenu �� TargetProperty �� 
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
   $ StackPanel.MouseLeave��6   $ 	panelMenu��6;   .[�5-      �� #��[ 6   �� 5.      #��[ 6   50      .��53      �  � RowDefinitions 54   
   �� 55      $��30 �6   6*   �� 56      $��50 �6   6*   �� 57      $��* �6   6)   .+�5;   
   �� -   5        $��BarraSistema��5;       � Cursor$
 Hand��6L   $��0��6Z    �� Orientation$ 
Horizontal=�6g   $	��Top=�6�   ���#356d67$��30��6�   .+�5=      �� $��Center=�6   
�������$��
10,0,990,0q�6B   .��6V   Alitec HelpDesk6h   �� 5>      -   5         ��Name$ btMinimizar��5>      $��Right=�6E   $��Center=�6a    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6|   ���	#FF31577E��6�   Z� ��6�   Z� .��5?      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�6*    � ToolTip$ Minimizar Aplicación��67   
�������
������ $��25��6�   $��25��6�   5@      �� 5A      -   5        $ btClose��5A      $��Right=�6>   $��Center=�6Z   #��[ 6u   ���	#FF31577E��6�   Z� ��6�   Z� .��5B        $ Close=�6*   $ Cerrar Aplicación��67   
�������
������ $��25��6�   $��25��6�   5C      5D      �� 5E   
   $��50��6   $��1��6!   $	��Top=�6.   $ 
Horizontal=�6F   
�������.+�5F      �� $ 
Horizontal=�6   $��60��62   $��
1070,0,0,0q�6=   .+�5H      �� -   5        $ btNotificaciones��5H      $ Ver Notificaciones��6R   
�������$��36��6�   $��40��6�   $��Center=�6�   $��Center=�6�   #��[ 6�   
������ ��61  Z� .��5I        $
 Bell=�6/   
�����p�
������ $��40��6m   $��40��6x   5J      �� 5K      
��� ���$��	0,10,0,20q�6-    �� CornerRadius$ 15��6@   $��20��6R   $��20��6^   ._�5L      �� -   5        $��tbNumNotifi��5L   8    �� TextAlignment$ Center=�6    $��20��6K   $��10(�6V   
�������$��Center=�6w   $
��Left=�6�    K� ZIndex$ -4��6�   6�   5M      5N      '  !MaterialDesignThemes.Wpf.PopupBox  5O         PlacementMode$ BottomAndAlignRightEdges=�6'   $��50��6P   $��50��6[      	StaysOpen .     ToggleContent 5P        5Q      $ Settings=�6.   $! Opciones de configuración.��6>   $��40��6c   $��40��6o   
�����p�6z      PopupContent. 5S      �� $	��220��6   .+�5T      �� -   5        $��btSonido��5T      ���	#FF5F8D74$��Sonido��6�   �� 5U      -   5        $��btCambiarPassword��5U      $��Cambiar contraseña��6V   5V      5W      5Y      �� 5Z   
   $ 
Horizontal=�6   $��2��6.   .+�5[      �� -   5        $��	panelMenu��5[      $
��Left=�6+   $	��100��6G   ���#d8e9e7$ Vertical=�6h   .+�5\      �� $ Vertical=�6   .+�5]      �� $��Center=�6   $��90��69   $��/Imagenes/logo.png��6E   $��10q�6a   6o   �� 5_      -	   5        $��lvMenu��5_      
�������$��Disabled=�6E   .@�5a      �� -
   5        $��	lvTickets��5a   '   $��60��68   .��5b      �� $ 
Horizontal=�6*   .+�5c   "   �� $��Center=�6(   $��Center=�6E   $��40��6a   $��40��6l   $��	20,0,30,0q�6y   $��/Imagenes/Ticket.png��6�   6�   �� 5d   "   $��Center=�6(   .��6C   Asignar Tickets6T   5e      5f      �� 5h      -   5        $��lvCrear��5h   (   $��60��67   .��5i      �� $ 
Horizontal=�6+   .+�5j   "   �� $��Center=�6(   $��Center=�6E   $��40��6`   $��40��6k   $��	20,0,30,0q�6w   $��/Imagenes/addTicket.png��6�   6�   �� 5k   "   $��Center=�6(   .��6E   Crear Ticket6S   5l      5m      �� 5n      -   5        $��lvEditar��5n   (   $��60��68   .��5o      �� $ 
Horizontal=�6+   .+�5p   "   �� $��Center=�6(   $��Center=�6E   $��40��6`   $��40��6k   $��	20,0,30,0q�6w   $��/Imagenes/editTicket.png��6�   6�   �� 5q   "   $
��Left=�6(   $��Center=�6C   .��6_   Editar Ticket6n   5r      5s      �� 5v      -   5        $��
lvUsuarios��5v   (   $��60��6:   .��5w      �� $ 
Horizontal=�6+   .+�5x   "   �� $��Center=�6(   $��Center=�6E   $��40��6`   $��40��6k   $��	20,0,30,0q�6w   $��/Imagenes/usuarios.png��6�   6�   �� 5y   "   $
��Left=�6(   $��Center=�6C   .��6_   Gestionar Usuarios6s   5z      5{      �� 5}      -   5        $��lvSedes��5}   (   $��60��67   .��5~      �� $ 
Horizontal=�6+   .+�5   "   �� $��Center=�6(   $��Center=�6E   $��40��6`   $��40��6k   $��	20,0,30,0q�6w   $��/Imagenes/oficina.png��6�   6�   �� 5�   "   $
��Left=�6(   $��Center=�6C   .��6_   Gestionar Sedes6p   5�      5�      �� 5�      -   5        $��lvCategorias��5�   (   $��60��6<   .��5�      �� $ 
Horizontal=�6+   .+�5�   "   �� $��Center=�6(   $��Center=�6E   $��40��6`   $��40��6k   $��	20,0,30,0q�6w   $��/Imagenes/equipos.png��6�   6�   �� 5�   "   $
��Left=�6(   $��Center=�6C   .��6_   Gestionar Categorías6u   5�      5�      �� 5�      -   5        $��
lvCiudades��5�   (   $��60��6:   .��5�      �� $ 
Horizontal=�6+   .+�5�   "   �� $��Center=�6(   $��Center=�6E   $��40��6`   $��40��6k   $��	20,0,30,0q�6w   $��/Imagenes/ciudad.png��6�   6�   �� 5�   "   $
��Left=�6(   $��Center=�6C   .��6_   Gestionar Ciudades6s   5�      5�      �� 5�      -   5        $��	lvEquipos��5�   (   $��60��69   .��5�      �� $ 
Horizontal=�6+   .+�5�   "   �� $��Center=�6(   $��Center=�6E   $��40��6`   $��40��6k   $��	20,0,30,0q�6w   $��/Imagenes/pc.png��6�   6�   �� 5�   "   $
��Left=�6(   $��Center=�6C   .��6_   Gestionar Equipos6r   5�      5�      5�      �� 5�      $ 
Horizontal=�6!   $��	5,150,5,0q�6;   .+�5�      �� $��Bottom=�6!   $!��/Imagenes/administrador.png��6<   $
��Fill=�6a   $	��100��6p   $��0,0,0,20q�6|   $	��140��6�   $��Center=�6�   6�   �� 5�      $��Center=�6%   $
��10,0q�6@   $ Vertical=�6N   .+�5�      �� -   5        $��tbNombre��5�   <   $
��Wrap=�6(   $��36��6L   $	��120��6X   Alberto Moreno Fernández6�   �� 5�      -   5        $��tbRol��5�   <   $
��Wrap=�6(   $��18��6I   $��5q�6U   $	��120��6`   administrador6|   �� 5�      -   5        $��tbMail��5�   <   $
��Wrap=�6(   $��38��6K   $	��120��6W   ramonchu.lopez@alitec.es6~   5�      5�      5�      5�      �� 5�      -   5        $��panelPrincipal��5�      $
��1100��6/   $��Bottom=�6<   $��Right=�6W   5�      5�      5�      5�      