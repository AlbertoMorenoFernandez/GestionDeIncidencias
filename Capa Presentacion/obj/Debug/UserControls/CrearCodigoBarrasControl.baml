   M S B A M L   `   `   `  ����L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  5      =    7Capa_Presentacion.UserControls.CrearCodigoBarrasContorl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      8local,clr-namespace:Capa_Presentacion.UserControls  5      -   5          � 	Resources  5
      2   ,Capa_Presentacion.UserControls.ConvertIdSede   ubicacionConverter��%   &	          5   
   6;   5      .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   �� $ Vertical=�6   $	��820��6,   
�������$
��1100��6L   .+�5   
   ��  
 titulo#��[ 6   $��
70,10,0,10q�64   Generar Etiqueta6Z   �� 5      $ 
Horizontal=�6   .+�5      �� $	��200��6   
�������$	��400��6>   $
��Left=�6J   $��
70,10,0,10q�6e   $��2q�6y    �� CornerRadius$ 9��6�   ._�5      �� -   5        $��	imgCodigo��5      $&�� ../Imagenes/etiquetaGenerada.png��6-   $��Center=�6W   $y�Hidden=�6t   $	��150��6�   $��10,10,10,10q�6�   6�   5      �� 5      -   5        $��btAbrirEtiqueta��5      $��55��6N   
������ 
�������$��Bottom=�6�   $��10q�6�   .��5      ��  � ToolTip$ Abrir etiqueta generada.��6   $ ��../Imagenes/abirCodigo.png��6?   6f   5      5      �� 5        
labelTitle#��[ 6   $��
70,10,0,10q�68   .��6L   Seleccione Equipo:6a   �� 5      $ 
Horizontal=�6   .+�5      �� -   5        $��
TbNumSerie��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Nº Serie��6-   $��30��6W   $	��200��6d   $
��Left=�6p   $��
70,10,0,10q�6�   6�   �� 5!      -   5        $��
tbEtiqueta��5!      $	��100��6-   $��20,10q�69   $ 
ServiceTag��6I   6w   �� 5"      -   5        $��	btGenerar��5"        RegularButton#��[ 6B   $
��60,0q�6j   .��5#      �� .��6!   _GENERAR ETIQUETA64   5$      5%      &   System.Windows.Controls.DataGrid  5'   
   -   5        $��	dtEquipos��5'         AutoGenerateColumns .  $8 2Haz doble click en el equipo para generar etiqueta��6@      CanUserAddRows .     CanUserDeleteRows .  $	��960��6�   $
��Left=�6  $��
70,20,0,10q�6  $	��400��60  
���������6�   ��    Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Service Tag��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 115 6>      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *
ServiceTag+6}     5*      $	 Marca��6)   $
 90 68    .  6C   �� *Marca+6q     5+      $	 Modelo��6)   $	
 120 69    .  6E   �� *Modelo+6u     5,      $	 Fin garantía��6)   $	
 170 6?    .  6K   �� *FinGarantia+6�     5-      $	 
Ubicación��6)   $	
 300 6<    .  6H   �� *
NumOficina+ �� 	Converter# [  6�     5.      $	 	Nº Serie��6)   $	
 100 6;    .  6G   �� *
NumSerie+6y   51      54      �� 56   
   -   5        $��	statusBar��56   -   
�������$��50��6>   .@�57      �� -	   5        $��tbStatusInformation��57   +   
�������$��10q�6F   6T   58      59      5;      