   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Capa_PresentacionCapa_Presentacion  -    'Capa_Presentacion.VentanaRecuperarClave   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  +localclr-namespace:Capa_Presentacion    � Title$  VentanaRecuperarClave��$	��250��$	��500�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=���Z� .��� .+��� 
�������
������� �� CornerRadius$ 20��._�� -   $��gdVentanaRecuperar�� � RowDefinitions �� $��50 ��� $��* �.+��� ���#356d67$ 	20,20,0,0��$��0��._��� .+��� -    ��Name$ btClose��$��Right=�$��Center=� 0  ,MaterialDesignFloatingActionMiniAccentButton#��[  
������ ���	#FF31577E��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=� � ToolTip$ Pantalla Principal��
�������
������ $��35��$��35���� $��1��$
��Left=�._��� 	 �� Orientation$	 Vertical=�.+��� $��20q�$	��300��.��Recuperar clave:�� -   $��tbCorreo��
�������)  #MaterialDesignThemes.Wpf.HintAssist
   Hint$(
 "Introduzca e-mail de recuperación��$��	20,0,10,0q�$��40��
�������$��2q�$	��300���� $	 
Horizontal=�$
��Left=�$��10q�.+��� -   $��btEnviar��$��1��  ModalButton#��[ $��20,20,10,20q�.���� .��	_Enviar�� -   $��btSalir��$��1��#��[ .���� .��	_Cancelar