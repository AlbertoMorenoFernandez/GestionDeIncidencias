   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      B    <Capa_Presentacion.UserControls.GestionarTecnicoTicketControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Capa_Presentacion.UserControls     5      -   5          � 	Resources  5
      5   /Capa_Presentacion.UserControls.ConvertUsuarioId   userConverter7   1Capa_Presentacion.UserControls.ConvertUserAddress  myAddressConverter��%:   &	        &	        5   
   69     5   
   6@   5      .��5      �� -   5        $��panelGestionar��5       �� Orientation$ Vertical=�6?   
�������$��Right=�6i    � DataContext 6'   �� .+�5   
   �� $	��820��6   $ Vertical=�6"   .+�5      ��  
 titulo#��[ 6   $��
70,10,0,10q�68   Gestionar Ticket6^   �� 5      $ 
Horizontal=�6   .+�5      �� $��70,0,0,0q�6   $	��100��6*     
labelTitle#��[ 66   .��6Z   Nº Ticket:6g   �� 5      $
��0,10q�6   $	��500��6*   $
��Left=�66   ��6Q   �� *	NumTicket+6n   �� 5      #��[ 6   $	��150��6<   $��0,0,0,0q�6H   .��6Y   
Usuario:6c   �� 5      $
��0,10q�6   $	��300��6*   ��66   �� *	IdUsuario+ �� 	Converter# [  6}   5      �� 5      $ 
Horizontal=�6   .+�5      �� #��[ 6   $	��100��6<   $��70,0,0,0q�6H   $
��Left=�6Z   .��6u   
Dirección6�   �� 5      $	��500��6   $
��0,10q�6(   ��66   �� *	IdUsuario+# [ 6�   �� 5      #��[ 6   $	��150��6<   $��0,0,0,0q�6H   .��6Y   Fecha de entrada:6m   �� 5      $
��0,10q�6;   ��6   �� *FechaEntrada+6K   5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5        $��tbTituloIdEquipo��5      #��[ 60   $��70,0,0,0q�6U   $	��100��6g   .��6s   	IdEquipo:6~   �� 5       -   5        $��
tbIdEquipo��5       )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Service Tag��6,    �� 	MaxLength$ 6��6Y   $��0,0,0,10q�6�   $	��300��6�   $
��Left=�6�   ��6h   �� *
IdEquipo+6�   5!      �� 5"      $ 
Horizontal=�6   5$      �� 5%      $��2q�6   
������� �� CornerRadius$ 5��6A   $	��150��6R   $��70,10,70,10q�6_   
�������._�5&      �� $��20q�6   ��6(   �� *Descripcion+6G   5'      �� 5(      $ 
Horizontal=�6   $	��300��62   .+�5)      �� $ Vertical=�6   $	��500��64   .+�5+      �� $��70,10,10,10q�6   #��[ 61   .��6U   Estado6]   �� 5,      -   5        $��cbEstado��5,      $��70,10,10,10q�6\   $	��299��6q   $
��Left=�6}   �� 5-      -   5        $��tbCategoria��5-      $��70,10,10,10q�6/   #��[ 6D   .��6h   
Categoría6s   �� 5.      -   5        $��cbCategoria��5.      $��70,10,10,10q�62   $	��299��6G   $
��Left=�6S   50      51      �� 52      $ Vertical=�6   $	��600��64   $��Right=�6@   .+�53      �� -   5        $��tbTituloResolucion��53      #��[ 66   $��75,10,10,10q�6Z   .��6o   Motivo6w   �� 54      -	   5        $��BdResolucion��54      $ 9��61   $	��150��6B   $	��450��6O   $��10,10,70,10q�6[   
�������$��Right=�6�   ._�55      �� -
   5        $��tbResolucion��55   "    �� TextWrapping$
 Wrap=�66     longTextbox#��[ 6J   $��0q�6o   $	 200��6�   $ Máximo 200 carácteres��6�   $	��100��6�   $	��430��6�   $��10q�6�   6�   56      57      58      �� 59      $ 
Horizontal=�6   $
��Left=�62   $��
700,20,0,0q�6M   .+�5:      �� -   5        $��btActualizar��5:      $	��140��6H   $��10q�6T   
�������
�����p�.��5;      �� .��6!   _ACTUALIZAR6.   6;   �� 5<      -   5        $��btVolver��5<      $	��140��6@   $��10q�6L   
�������
�����p�.��5=      �� .��6!   	_VOLVER6+   68   5>      5?      �� 5@   
   -   5        $��	statusBar��5@   9   
�������$��3��6,   $��50��6J   .@�5A      �� -   5        $��tbStatusInformation��5A   +   
�������$��10q�6F   6T   5B      5D      5E      