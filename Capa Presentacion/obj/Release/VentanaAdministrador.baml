   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5clr-namespace:Capa_PresentacionCapa_Presentacion  ,    &Capa_Presentacion.VentanaAdministrador   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  9local2,clr-namespace:Capa_Presentacion.UserControls  +localclr-namespace:Capa_Presentacion    � Title$  VentanaAdministrador��$	��960��$
��1200�� � WindowStyle$
 None=�$��3q����#d8e9e7 � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources    SalmonColor �� Color  OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value  contractPrincipal  	CloseMenu  expandPrincipal��%  &	        &	      &	 �     &	 �     &	 r    �� $ #d8e9e7���� .��U� $ (FrameworkElement.Width)�$ 	panelMenu��.\�  $ 0��$		 100Q�  $ 0:0:0.3��$		 250Q��� .��U� $ (FrameworkElement.Width)�$ panelPrincipal��.\�  $ 0��$
	 1100Q�  $ 0:0:0.3��$		 950Q��� .��U� $ (FrameworkElement.Width)�$ 	panelMenu��.\�  $ 0��$		 250Q�  $ 0:0:0.3��$		 100Q��� .��U� $ (FrameworkElement.Width)�$ panelPrincipal��.\�  $ 0��$		 950Q�  $ 0:0:0.3��$
	 1100Q�
 � Triggers
 :�  :� RoutedEvent$ StackPanel.MouseEnter�� :� 
SourceName$ 	panelMenu��.[��� #��[ �� #��[ :� $ StackPanel.MouseLeave��$ 	panelMenu��.[��� #��[ �� #��[ .���  � RowDefinitions �� $��30 ��� $��50 ��� $��* �.+��� -   $��BarraSistema�� � Cursor$
 Hand��$��0�� �� Orientation$ 
Horizontal=�$	��Top=����#356d67$��30��.+��� $��Center=�
�������$��
10,0,990,0q�.��Alitec HelpDesk�� -    ��Name$ btMinimizar��$��Right=�$��Center=� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ ���	#FF31577E��Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=� � ToolTip$ Minimizar Aplicación��
�������
������ $��25��$��25���� -   $ btClose��$��Right=�$��Center=�#��[ ���	#FF31577E��Z� ��Z� .��  $ Close=�$ Cerrar Aplicación��
�������
������ $��25��$��25���� $��50��$��1��$	��Top=�$ 
Horizontal=�
�������.+��� $ 
Horizontal=�$��60��$��
1070,0,0,0q�.+��� -   $ btNotificaciones��$ Ver Notificaciones��
�������$��36��$��40��$��Center=�$��Center=�#��[ 
������ ��Z� .��  $
 Bell=�
�����p�
������ $��40��$��40���� 
��� ���$��	0,10,0,20q� �� CornerRadius$ 15��$��20��$��20��._��� -   $��tbNumNotifi�� �� TextAlignment$ Center=�$��20��$��10(�
�������$��Center=�$
��Left=� K� ZIndex$ -4��'  !MaterialDesignThemes.Wpf.PopupBox     PlacementMode$ BottomAndAlignRightEdges=�$��50��$��50��   	StaysOpen .     ToggleContent   $ Settings=�$! Opciones de configuración.��$��40��$��40��
�����p�   PopupContent. �� $	��220��.+��� -   $��btSonido�����	#FF5F8D74$��Sonido���� -   $��btCambiarPassword��$��Cambiar contraseña���� $ 
Horizontal=�$��2��.+��� -   $��	panelMenu��$
��Left=�$	��100�����#d8e9e7$ Vertical=�.+��� $ Vertical=�.+��� $��Center=�$��90��$��/Imagenes/logo.png��$��10q��� -	   $��lvMenu��
�������$��Disabled=�.@��� -
   $��	lvTickets��$��60��.���� $ 
Horizontal=�.+��� $��Center=�$��Center=�$��40��$��40��$��	20,0,30,0q�$��/Imagenes/Ticket.png���� $��Center=�.��Asignar Tickets�� -   $��lvCrear��$��60��.���� $ 
Horizontal=�.+��� $��Center=�$��Center=�$��40��$��40��$��	20,0,30,0q�$��/Imagenes/addTicket.png���� $��Center=�.��Crear Ticket�� -   $��lvEditar��$��60��.���� $ 
Horizontal=�.+��� $��Center=�$��Center=�$��40��$��40��$��	20,0,30,0q�$��/Imagenes/editTicket.png���� $
��Left=�$��Center=�.��Editar Ticket�� -   $��
lvUsuarios��$��60��.���� $ 
Horizontal=�.+��� $��Center=�$��Center=�$��40��$��40��$��	20,0,30,0q�$��/Imagenes/usuarios.png���� $
��Left=�$��Center=�.��Gestionar Usuarios�� -   $��lvSedes��$��60��.���� $ 
Horizontal=�.+��� $��Center=�$��Center=�$��40��$��40��$��	20,0,30,0q�$��/Imagenes/oficina.png���� $
��Left=�$��Center=�.��Gestionar Sedes�� -   $��lvCategorias��$��60��.���� $ 
Horizontal=�.+��� $��Center=�$��Center=�$��40��$��40��$��	20,0,30,0q�$��/Imagenes/equipos.png���� $
��Left=�$��Center=�.��Gestionar Categorías�� -   $��
lvCiudades��$��60��.���� $ 
Horizontal=�.+��� $��Center=�$��Center=�$��40��$��40��$��	20,0,30,0q�$��/Imagenes/ciudad.png���� $
��Left=�$��Center=�.��Gestionar Ciudades�� -   $��	lvEquipos��$��60��.���� $ 
Horizontal=�.+��� $��Center=�$��Center=�$��40��$��40��$��	20,0,30,0q�$��/Imagenes/pc.png���� $
��Left=�$��Center=�.��Gestionar Equipos�� $ 
Horizontal=�$��	5,150,5,0q�.+��� $��Bottom=�$!��/Imagenes/administrador.png��$
��Fill=�$	��100��$��0,0,0,20q�$	��140��$��Center=��� $��Center=�$
��10,0q�$ Vertical=�.+��� -   $��tbNombre��$
��Wrap=�$��36��$	��120��Alberto Moreno Fernández�� -   $��tbRol��$
��Wrap=�$��18��$��5q�$	��120��administrador�� -   $��tbMail��$
��Wrap=�$��38��$	��120��ramonchu.lopez@alitec.es�� -   $��panelPrincipal��$
��1100��$��Bottom=�$��Right=�