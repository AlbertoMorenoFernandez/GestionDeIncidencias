   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Capa_PresentacionCapa_Presentacion  5   	   &     Capa_Presentacion.ConfirmarSalir   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Capa_Presentacion     5   	   -   5          � Title$  ConfirmarSalir��5   	   $	��210��6    $	��400��6-    � AllowsTransparency .  � WindowStyle$
 None=�6T    � WindowStartupLocation$ CenterScreen=�6�   ��6g   Z�  � Triggers 5	      :� 5
   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� .��5      ��  g� FillBehavior$ HoldEnd=�6    g� AutoReverse .  .��5      W�  �� TargetProperty$ Opacity�6&   	 W� From$	 0X�6J   	
 W� To$
 1X�6S    g� Duration$ 0:0:0.5D�6Z   5      5      5      .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   �� -   5         ��Name$
 gBar��5      $��50��6   ���#356d67 �� CornerRadius$ 	20,20,0,0��6]   ._�5      �� .+�5      �� -   5         ��Name$ btnClose��5         MyRedButton#��[  6+   $��X��6P   
������ 
�������$��Right=�6�   $��45��6�   $��58��6�   5      5      �� 5   
   $	��140��6   $��2q�6   ���#356d67$��1��6H   
�������$ 	0,0,20,20��6h   ._�5      �� -   5         ��Name$ gBody��5   1   $ Vertical=�6   .+�5      �� $ Vertical=�6   .+�5      �� -   5         ��Name$ tbText��5   +   $��41��6   $&�� ¿Desea salir de la aplicación?��6;   $��0,10,5,0q�6a   $��18(�6t   $��Center=�6�   $��Center=�6�   
���   �$��0q�6�    �� 
IsReadOnly . 6�   �� 5      $ 
Horizontal=�6!   $��Center=�6:   .+�5      �� -   5        $��btSalir��5   "     ModalButton#��[ 61   $
��Left=�6V   $��5q�6q   .��5      �� .��6)   _Si5!      6,   �� 5"      -   5        $��	btNoSalir��5"   !   #��[ 62   $��Right=�6W   $��5q�6s   .��6�   No6�   5#      5$      5&      5'      5(      5)      