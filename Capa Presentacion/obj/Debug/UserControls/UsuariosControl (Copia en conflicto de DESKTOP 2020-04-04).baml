   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      4    .Capa_Presentacion.UserControls.UsuariosControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Capa_Presentacion.UserControls     5        � 	Resources  5	         SalmonColor �� Color/   )Capa_Presentacion.UserControls.ConvertRol  myRolConverter��%M   &	        &	 &     �� 5
   
   $ #d8e9e7��6.   6@     5   
   64   5      .��5      � -   5        $��	gdGeneral��5      
������� � DataContext 6/   ��  � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $��90 �6   6*   �� 5      $��90 �6   6*   �� 5      $��80 �6   6*   �� 5      $	��430 �6   6+   �� 5      $��60 �6   6*   �� 5      $��50 �6   6*   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6#   .+�5      �� $��../Imagenes/tuerca.png��6   66   �� 5      -   5        $��tbTitulo��5       
 titulo#��[ 6(   $��Center=�6H   GESTIÓN DE USUARIOS6x   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   .+�5      �� $ Vertical=�6   $��	20,20,0,0q�60   .+�5      �� .��6   
Nombre *6"   �� 5        textbox#��[ 6   ��6;   �� *Nombre+ �� Mode$ TwoWay=�6c   5      �� 5       $ Vertical=�6   $��	20,20,0,0q�60   .+�5!      �� .��6   Apellidos *6%   �� 5"      #��[ 6B   ��6   �� *	Apellidos+$ TwoWay=�6e   5#      �� 5$      $ Vertical=�6   $��	20,20,0,0q�60   .+�5%      �� .��6   Correo Electrónico *6.   �� 5&      #��[ 6=   ��6   �� *Mail+$ TwoWay=�6`   5'      �� 5(      $ Vertical=�6   $��	20,20,0,0q�60   .+�5)      �� .��6   Extensión *6%   �� 5*      #��[ 6B   ��6   �� *	Extension+$ TwoWay=�6e   5+      5,      �� 5-   
   $��2��6   $ 
Horizontal=�6"   .+�5.      �� $ Vertical=�6   $��	20,20,0,0q�60   .+�5/      �� .��6   
Password *6$   G� 50      -   5        $��
pwPassword��50        
paswordbox#��[ 60   6V   51      �� 52      $ Vertical=�6   $��	20,20,0,0q�60   .+�53      �� .��6   Repetir Password*6+   G� 54      -   5        $��pwRepeat��54      #��[ 6.   6T   55      �� 56      $ Vertical=�6   $��	20,20,0,0q�60   .+�57      �� .��6   	Oficina *6#   �� 58      -   5        $��	cbOficina��58      $
��Left=�6D   $	��200��6_   $��30��6k   ��6,   �� 6y   59      �� 5:      $ Vertical=�6   $��	20,20,0,0q�60   .+�5;      �� .��6   Rol *6   �� 5<      -   5        $��cbRoles��5<      $
��Left=�6�   $	��200��6�   $��30��6�   ��6*   ��  �� SelectedIndex 6B   ��  �� Path$ Usuario.RolUsuario�$ TwoWay=�6�   5=      5>      �� 5?   
   $��Center=�6   $��3��61   $ 
Horizontal=�6>   .+�5@      �� -   5        $��
lbImportar��5@      $��
590,0,10,0q�6&   .��6:   Importar .csv:6J   �� 5A      -   5        $��imgImportarCsv��5A      $��../Imagenes/csv.png��6v   $��30��6�   $��30��6�   $��	10,0,60,0q�6�   $��Center=�6�   6�   �� 5B      -	   5        $��	btAgregar��5B      
�������
�����p�$��30��6n   $��90��6z   .��6�   	Agregar6�   5C      �� 5E   
   -
   5        $��panelStatusBar��5E      $��6��6+   
�������.+�5F      �� -   5        $��lbError��5F   '   
�������68   5H      5I      5J      