   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Capa_PresentacionCapa_Presentacion  5   	   &     Capa_Presentacion.ConfirmarSalir   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Capa_Presentacion     5   	   -   5          � Title$  ConfirmarSalir��5   	   $	��200��6    $	��400��6-    � AllowsTransparency .  � WindowStyle$
 None=�6T    � WindowStartupLocation$ CenterScreen=�6�   ��6g   Z�  � Triggers 5	      :� 5
   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� .��5      ��  g� FillBehavior$ HoldEnd=�6    g� AutoReverse .  .��5      W�  �� TargetProperty$ Opacity�6&   	 W� From$	 0X�6J   	
 W� To$
 1X�6S    g� Duration$ 0:0:0.5D�6Z   5      5      5      .��5      � .+�5   
   � -   5         �Name$ gBody��5       � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    .+�5      �� $��1q�6   
������� �� CornerRadius$ 20��6=   $��2��6O   ���	#FF7070706`   �� 5      -   5         ��Name$ tbText��5   #   $��0��6    �� TextWrapping$
 Wrap=�63   $&�� ¿Desea salir de la aplicación?��6G   $��	10,42,0,0q�6m   $	��Top=�6�   $��18(�6�    �� TextAlignment$ Center=�6�   
���   �$
��Left=�6�   $	��380��6�   ��. " �� VerticalScrollBarVisibility$
 Auto=�6J   �� 
IsReadOnly . ��6�   Z� ��6  Z� 6m  �� 5      -   5        $��btSalir��5      $��1��6$   
�������
�����p�$
��Left=�6a   $��	88,5,8,18q�6|   $	��100��6�   .��6�   Si6�   �� 5      -   5        $��	btNoSalir��5      $��1��6&   
�������
�����p�$��Right=�6c   $��
8,10,88,18q�6   $	��100��6�   .��6�   No6�   5      � 5   
   -   5        $
 gBar��5   )    � Cursor$
 Hand��6   $��50��6   $	��Top=�68   .+�5      �� ���#356d67$ 
20,20,10,0��6*   �� 5      -   5         ��Name$ btnClose��5         MyRedButton#��[  6'   $��X��6L   
������ 
�������$��Right=�6�   $��45��6�   $��58��6�   5!      5"      5#      