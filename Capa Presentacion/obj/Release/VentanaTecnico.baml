   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Capa_PresentacionCapa_Presentacion  &     Capa_Presentacion.VentanaTecnico   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  +localclr-namespace:Capa_Presentacion    � Title$  VentanaTecnico��$	��950��$
��1200�� � WindowStyle$
 None=�$��3q����#d8e9e7 � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources    SalmonColor �� Color  OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value  contractPrincipal  	CloseMenu  expandPrincipal��%  &	        &	      &	 �     &	 �     &	 r    �� $ #d8e9e7���� .��U� $ (FrameworkElement.Width)�$ 	panelMenu��.\�  $ 0��$		 100Q�  $ 0:0:0.3��$		 250Q��� .��U� $ (FrameworkElement.Width)�$ panelPrincipal��.\�  $ 0��$
	 1100Q�  $ 0:0:0.3��$		 950Q��� .��U� $ (FrameworkElement.Width)�$ 	panelMenu��.\�  $ 0��$		 250Q�  $ 0:0:0.3��$		 100Q��� .��U� $ (FrameworkElement.Width)�$ panelPrincipal��.\�  $ 0��$		 950Q�  $ 0:0:0.3��$
	 1100Q�
 � Triggers
 :�  :� RoutedEvent$ StackPanel.MouseEnter�� :� 
SourceName$ 	panelMenu��.[��� #��[ �� #��[ :� $ StackPanel.MouseLeave��$ 	panelMenu��.[��� #��[ �� #��[ .���  � RowDefinitions �� $��30 ��� $��50 ��� $��* �.+��� -   $��BarraSistema��$��0�� �� Orientation$ 
Horizontal=����#356d67$��30��.+��� $��Center=�
�������.��Alitec HelpDesk�� -    ��Name$ btMinimizar�� � ToolTip$ Minimizar aplicación��$��
1000,0,0,0q�$��Right=�$��Center=� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ ���	#FF31577E��Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�
�������
������ $��25��$��25���� -   $ btClose��$��Right=�$��Center=�#��[ ���	#FF31577E��Z� ��Z� .��  $ Close=�$ Cerrar Aplicación��
�������
������ $��25��$��25���� -   $��BarraNotificaciones��$��1��$��50��$
��1200��$	��Top=�$
��Left=�$ 
Horizontal=�
�������.+��� -   $ btNotificaciones��$��
1090,0,0,0q�
�������$��36��$��40��$��Center=�$��Center=�#��[ 
������ ��Z� .��  $
 Bell=�$ Ver notificaciones��
�����p�
������ $��40��$��40���� 
��� ���$��	0,10,0,20q� �� CornerRadius$ 15��$��20��$��20��._��� -   $��tbNumNotifi�� �� TextAlignment$ Center=�$��20��$��10(�
�������$��Center=�$
��Left=� K� ZIndex$ -4��'  !MaterialDesignThemes.Wpf.PopupBox     PlacementMode$ BottomAndAlignRightEdges=�$��50��$��50��   	StaysOpen .     ToggleContent   $ Settings=�$  Opciones de configuración��$��40��$��40��
�����p�   PopupContent. �� $	��220��.+��� -   $��btSonido�����	#FF5F8D74$��Sonido���� -   $��btCambiarPassword��$��Cambiar contraseña���� $ 
Horizontal=�$��2��.+��� -	   $��	panelMenu��$
��Left=�$	��100�����#d8e9e7$ Vertical=�.+��� $ Vertical=�.+��� $��Center=�$��90��$��/Imagenes/logo.png��$��10q��� -
   $��lvMenu��
�������$��Disabled=�.@��� -   $��lvMisTickets��$��60��.���� $ 
Horizontal=�.+��� $��Center=�$��Center=�$��40��$��40��$��	20,0,30,0q�$��/Imagenes/ticket.png���� $��Center=�Mis Tickets�� -   $��lvEtiquetas��$��60��.���� $ 
Horizontal=�.+��� $��Center=�$��Center=�$��40��$��40��$��	20,0,30,0q�$��/Imagenes/barcode.png�� J� RenderTransformOrigin$ 17.953,9.822&��� $
��Left=�$��Center=�Crear Etiqueta�� $ 
Horizontal=�$��	5,490,5,0q�.+��� $��Bottom=�$��/Imagenes/tecnico.png��$��80��$��0,0,0,20q�$��80��$��Center=��� $��Bottom=�$
��10,0q�$ Vertical=�.+��� -   $��tbNombre��$
��Wrap=�$��36��$	��140��Alberto Moreno Fernández�� -   $��tbRol��$
��Wrap=�$��18��$��5q�$	��140��administrador�� -   $��tbMail��$
��Wrap=�$��38��$	��140��ramonchu.lopez@alitec.es�� -   $��panelPrincipal��$	��870��$
��1100��