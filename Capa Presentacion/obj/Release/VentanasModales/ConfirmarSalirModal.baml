   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Capa_PresentacionCapa_Presentacion  &     Capa_Presentacion.ConfirmarSalir   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:Capa_Presentacion     -     � Title$  ConfirmarSalir��$	��210��$	��400�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=���Z�  � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� .����  g� FillBehavior$ HoldEnd=� g� AutoReverse .  .��W�  �� TargetProperty$ Opacity�	 W� From$	 0X�	
 W� To$
 1X� g� Duration$ 0:0:0.5D�.����  �� Orientation$ Vertical=�.+��� -    ��Name$
 gBar��$��50�����#356d67 �� CornerRadius$ 	20,20,0,0��._��� .+��� -    ��Name$ btnClose��   MyRedButton#��[  $��X��
������ 
�������$��Right=�$��45��$��58���� $	��140��$��2q����#356d67$��1��
�������$ 	0,0,20,20��._��� -    ��Name$ gBody��$ Vertical=�.+��� $ Vertical=�.+��� -    ��Name$ tbText��$��41��$&�� ¿Desea salir de la aplicación?��$��0,10,5,0q�$��18(�$��Center=�$��Center=�
���   �$��0q� �� 
IsReadOnly . �� $ 
Horizontal=�$��Center=�.+��� -   $��btSalir��  ModalButton#��[ $
��Left=�$��5q�.���� .��_Si�� -   $��	btNoSalir��#��[ $��Right=�$��5q�.��No