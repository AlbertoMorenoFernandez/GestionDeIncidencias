   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      =    7Capa_Presentacion.UserControls.CrearTicketsAdminControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      8local,clr-namespace:Capa_Presentacion.UserControls  5      .��5      � 
�������  � RowDefinitions  5   
   �� 5      $	��100 �6   6+   �� 5      $	��260 �6   6+   �� 5      $	��320 �6   6+   �� 5      $	��140 �6   6+   �� 5      $��50 �6   6*   .+�5   
   �� .+�5      �� $��
70,20,10,0q�6    
  titulo#��[  6,   Crear Ticket6Z   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��70,10q�6;   .+�5      �� $ Vertical=�6   .+�5      ��   
labelTitle#��[ 6   $	��0,5q�6<   .��6I   Equipo6Q   �� 5      $ 
Horizontal=�6   .+�5      �� -   5        $��tbEquipo��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Service Tag��6.    �� 	MaxLength$ 6��6[   $��2q�6�   $
��Left=�6�   
�������$	��250��6�   $��	0,10,10,0q�6  6  �� 5      -   5        $��imgVerificar��5      $��35��60   $��Bottom=�6;   $y�Hidden=�6V   $��../Imagenes/ok.png��6j   6�   5      �� 5      #��[ 6   $��0,10,0,0q�6=   .��6O   
Asignar a:6[   �� 5      -   5        $��
cbTecnicos��5      $��35��6-   $	��250��6:   $��2q�6F   
�������$
��Left=�6s   $��0,10,0,0q�6�   6�   �� 5       $ 
Horizontal=�6   .+�5!      �� -   5        $��chbTecnicos��5!      $��10q�62   6�   �� 5"      $��10q�6    " Asignar a técnico de otra sede.6M   5$      �� 5%      -   5        $��cbTecnicosExternos��5%      $��0,10,0,0q�65   $y�Hidden=�6G   6�   5&      �� 5'      $ Vertical=�6   .+�5(      �� #��[ 6   $
��50,0q�6=   .��6K   Descripción6X   �� 5)      -   5        $��tbDescripcion��5)      $	��600��6/    �� TextWrapping$
 Wrap=�6<     longTextbox#��[ 6P   $��Center=�6u   
�������$	��150��6�   $��50,20,-4,20q�6�    �� TextAlignment$ Justify=�6�    �� AcceptsReturn .  �� 
AcceptsTab . 6�   5*      5+      �� 5,   
   $ Vertical=�6   $��2��6,   .+�5-      �� $ 
Horizontal=�6   .+�5.      �� $��../Imagenes/tecnico.png��6   $��30��69   $��30��6E   $	��Top=�6P   $��70,10,10,10q�6h   6   �� 5/      #��[ 6   $��10,15q�6<   $	��Top=�6K   $��30��6c   .��6o   	Técnico:6z   �� 50      -   5        $��tbNombreTecnico��50      $	��250��63   $��10,20q�6?   $��30��6N   $	��Top=�6Z   6t   �� 51      #��[ 6   $��10,15,20,20q�6<   $	��Top=�6Q   $��30��6i   .��6u   Sede:6}   �� 52      -   5        $��tbDireccionTecnico��52      $	��500��66   $��0,20,0,0q�6B   $��30��6T   $	��Top=�6`   6z   53      �� 54      $ 
Horizontal=�6   $��70,10q�62   .+�55      �� $��2q�6   
������� �� CornerRadius$ 9��6E   
�������$	��120��6n   $	��120��6z   ._�56      �� .+�57      �� -	   5        $��tbAsignadas��57   $   $��80(�67   $��Center=�6E   $��90��6b   $	��Top=�6n   -6�   �� 58      $��20(�6$   $��30��62   $��Bottom=�6>   $��Center=�6Y   $��0,0,0,20q�6v   	Asignadas6�   59      5:      �� 5;      $��2q�6   
�������$ 9��6E   
�������$	��120��6n   $	��120��6z   $
��40,0q�6�   ._�5<      �� .+�5=      �� -
   5        $��tbPendientes��5=       $��80(�64   $��Center=�6B   
���\\��$��90��6v   $	��Top=�6�   -6�   �� 5>      $��20(�6    $��30��6.   
���\\��$��Bottom=�6Q   $��Center=�6l   $��0,0,0,20q�6�   
Pendientes6�   5?      5@      5A      5B      �� 5C   
   $��3��6   $ 
Horizontal=�6"   $��Right=�6;   .+�5D      �� -   5        $��btBorrar��5D        RegularButton#��[ 6>   $
��Left=�6e   $��	70,0,20,0q�6�   .��6�   LIMPIAR DATOS6�   �� 5E      -   5        $��btCrear��5E      #��[ 6:   $
��Left=�6a   $��	10,0,20,0q�6|   .��6�   CREAR TICKET6�   5F      �� 5G   
   $��4��6   .+�5H      �� -   5        $��	statusBar��5H   =   
�������$��3��60   $��50��6N   .@�5I      �� -   5        $��tbStatusInformation��5I   /   
�������$��10q�6J   6X   5J      5K      5M      5N      