   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Capa_PresentacionCapa_Presentacion  *    $Capa_Presentacion.VentanaInformacion   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  +localclr-namespace:Capa_Presentacion    � Title$  VentanaInformacion��$	��250��$	��450�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=���Z� .��� .+��� 
�������
������� �� CornerRadius$ 20��._�� -   $��gdVentanaRecuperar�� � RowDefinitions �� $��50 ��� $��* �.+��� ���#356d67$ 	20,20,0,0��$��0��._��� .+��� -    ��Name$ btClose��$��Right=�$��Center=� 0  ,MaterialDesignFloatingActionMiniAccentButton#��[  
������ ���	#FF31577E��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=� � ToolTip$ Pantalla Principal��
�������
������ $��35��$��35���� 	 �� Orientation$	 Vertical=�$��1��.+��� $	 
Horizontal=�.+��� -   $��imgTipoInformacion��$��../Imagenes/exito.png��$��50��$	��Top=�$��20q��� $��Visible=�.���� -   $��tbInformacion��  longTextbox#��[ $��0q�
 �� 
IsReadOnly
 . 
�������$	��310��$	��110��$	��Top=�$��	0,25,0,10q�.��_]Contraseña restablecida correctamente, revise su dirección de email para más indicaciones.�� -   $��	btAceptar��  ModalButton#��[ $��10q�.���� .��
_Aceptar