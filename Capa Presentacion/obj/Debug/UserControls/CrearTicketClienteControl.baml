   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      7    1Capa_Presentacion.UserControls.CrearTicketControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      8local,clr-namespace:Capa_Presentacion.UserControls  5      .��5      � 
�������  � RowDefinitions  5   
   �� 5      $��80 �6   6*   �� 5      $	��740 �6   6+   �� 5      $��50 �6   6*   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $
��Left=�6   $��Center=�63    
  titulo#��[  6O   $��70,0,0,0q�6o   Crear Ticket6�   5      �� 5   
   -   5        $��panelPrincipal��5      $��1��6+   $ 
Horizontal=�69   $��Center=�6R   .+�5      �� $	��545��6   $ Vertical=�6%   $��Center=�6<   .+�5      �� $ 
Horizontal=�6   .+�5      ��   
labelTitle#��[ 6   $
��Left=�6@   $��70,10q�6[   .��6j   Seleccione Equipo6}   �� 5      -   5        $��imgHelp��5       � ToolTip$ 	Ver ayuda��6M   $��../Imagenes/help.png��6�   6�   5      �� 5      $ 
Horizontal=�6   .+�5       �� $
��Left=�6    �� CornerRadius$ 5��68   $��40��6I   $	��400��6U   $��70,10,20,10q�6a   
�������$��2q�6�   ._�5!      �� $ 
Horizontal=�6%   .+�5"      �� -   5        $��tbServiceTag��5"   4    �� 	MaxLength$ 6��6&   $	��5,0q�6o   $��Center=�6|   $	��350��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$0 *Introduzca el id del equipo y pulse buscar��6�   6�   �� 5#      -   5         ��Name$ btSearch��5#   &   $��40��6P   $��40��6\   $	��0,0q�6h   $��Center=�6u    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5$   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�6:   $ Pantalla Principal��6H   
�����p�
������ $��25��6�   $��25��6�   5%      5&      5'      �� 5(      -   5        $��imgResultadoBusqueda��5(      $��40��69   $��40��6E   6R   5)      �� 5*      -   5        $��	chbEquipo��5*      $G ASi no puede localizar la etiqueta del equipo marque esta casilla.��6,   $
��Left=�6�   $
��70,0q�6�   .��6�   Equipo No Etiquetado6�   �� 5+      -   5        $��tbDescripcion��5+   .    �� TextWrapping$
 Wrap=�6   $	 200��6C     longTextbox#��[ 6S   $
��Left=�6y   $	��200��6�   $	��400��6�   $��70,10q�6�   $ Máximo 200 caracteres��6�   6�   �� 5,      -   5        $��btCrear��5,      $	��150��6>     RegularButton#��[ 6J   $
��Left=�6q   $
��70,0q�6�   .��5-      �� .��6!   _CREAR PETICIÓN62   6?   5.      �� 5/      $��5��6   .+�50      �� -	   5        $��cvSeparador��50      $y�Hidden=�6,   .+�51      �� 		 �� X1$	 0��52      	
 �� Y1$
 20��6   	 �� X2$ 0��53      	 �� Y2$	 730��6   
�����p�$��1��55      57      58      �� 59      -
   5        $��
panelAyuda��59      $y�Hidden=�6+   $	��545��6?   $��Right=�6K   .+�5:      �� $��Center=�6   $��10q�69   20Localice el identificador de su equipo averiado.6w   �� 5;      $	��300��6   $"��../Imagenes/codigoBarras.png��6$   6L   �� 5<      $��Center=�6   $��10q�69   @>En caso de no encontrarlo haga click en "Equipo no Etiquetado"6�   �� 5=      $��../Imagenes/checkbox.png��6   $	��200��6:   6H   �� 5>      $��Center=�6   $��10q�69   75Redacte una breve descripción del problema que tiene6{   �� 5?      $ ��../Imagenes/incidencia.png��6   $	��300��6<   6J   �� 5@      $��Center=�6   $��10q�69   /-Haga clik en "Crear Petición para finalizar.6s   5A      5B      �� 5D   
   -   5        $��	statusBar��5D   :   
�������$��2��6-   $��50��6K   .@�5E      �� -   5        $��tbStatusInformation��5E   +   
�������$��10q�6F   6T   5F      5H      5I      