   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Capa_PresentacionCapa_Presentacion  5   	   "    Capa_Presentacion.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   +localclr-namespace:Capa_Presentacion  5   	     � Title$  Loging��5	   
   $	��470��6   $	��650��6&    � 
ResizeMode$ NoResize=�62    � WindowStyle$
 None=�6H    � WindowStartupLocation$ CenterScreen=�6[   .��5
      �  � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      6    � ColumnDefinitions 5   
   �� 5      $	��230 �6   6-   �� 5      6!   .+�5   
   �� -   5        $��barraSistema��5      $��0��6)    �� Orientation$ 
Horizontal=�66   $��2��6s   ���#356d67$��30��6�   .+�5      �� $��Center=�6   
�������$��
20,0,440,0q�6F   Alitec HelpDesk6l   �� 5      -   5         ��Name$ btMinimizar��5      $��Right=�6E   $��Center=�6a    0  ,MaterialDesignFloatingActionMiniAccentButton#��[  6|   ���	#FF31577E��6�   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Minus=�6*   	 � ToolTip$	 Minimizar Aplicación��67   
�������
������ $��25��6�   $��25��6�   5      �� 5      -   5        $ btClose��5      $��Right=�6=   $��Center=�6Y   #��[  6t   ���	#FF31577E��6�   Z� ��6�   Z� .��5        $ Close=�6*   $	 Cerrar Aplicación��67   
�������
������ $��25��6�   $��25��6�   5      5      �� 5   
   $��0��6   $��1��6    $
��Fill=�6-   $��Imagenes/gafas.png��6<   6Z   �� 5   
   $��1��6   $��1��6"   .+�5      �� $ Vertical=�6   .+�5       �� $��24(�6   
�������$��110,120,0,0q�6A   $��34��6V   Alitec Service Support6z   �� 5!      -   5        $��tbCorreo��5!      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Correo Electrónico��6*   $	��200��6_   $��30��6k   $��	0,10,0,10q�6w   G� 5"      -   5        $��
tbPassword��5"      $
 Contraseña��6N   $	��200��6z   $��30��6�   $��	0,10,0,10q�6�   �� 5#      -   5        $��tbRecuperar��5#      $1	 +Envía nueva clave a su correo electrónico��6/   
����d�$��14(�6   $��	underline{�6�   $	��200��6�   $��	0,10,0,10q�6�   Recuperar contraseña6%  �� 5&      -   5        $��
btIngresar��5&      $��80,10,180,0q�6,     ModalButton#��[ 6Z   .��5'      �� .��6!   	_Ingresar6-   5(      �� 5)      $ 
Horizontal=�6   .+�5*      �� $��110,10,0,10q�6    $��Bottom=�65   
�������support@alitec.es6{   �� 5+      $��40,0,0,0q�6   $��Imagenes/auriculares.png��6.   $	��100��6P   $	��120��6]   5,      5-      5.      50      51      