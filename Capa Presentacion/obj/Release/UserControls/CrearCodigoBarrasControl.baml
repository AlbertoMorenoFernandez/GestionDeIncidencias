   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  =    7Capa_Presentacion.UserControls.CrearCodigoBarrasContorl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  8local,clr-namespace:Capa_Presentacion.UserControls  -     � 	Resources  2   ,Capa_Presentacion.UserControls.ConvertIdSede   ubicacionConverter��%   &	          .����  �� Orientation$ Vertical=�.+��� $ Vertical=�$	��820��
�������$
��1100��.+���  
 titulo#��[ $��
70,10,0,10q�Generar Etiqueta�� $ 
Horizontal=�.+��� $	��200��
�������$	��400��$
��Left=�$��
70,10,0,10q�$��2q� �� CornerRadius$ 9��._��� -   $��	imgCodigo��$&�� ../Imagenes/etiquetaGenerada.png��$��Center=�$y�Hidden=�$	��150��$��10,10,10,10q��� -   $��btAbrirEtiqueta��$��55��
������ 
�������$��Bottom=�$��10q�.����  � ToolTip$ Abrir etiqueta generada.��$ ��../Imagenes/abirCodigo.png����   
labelTitle#��[ $��
70,10,0,10q�.��Seleccione Equipo:�� $ 
Horizontal=�.+��� -   $��
TbNumSerie��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Nº Serie��$��30��$	��200��$
��Left=�$��
70,10,0,10q��� -   $��
tbEtiqueta��$	��100��$��20,10q�$ 
ServiceTag���� -   $��	btGenerar��  RegularButton#��[ $
��60,0q�.���� .��_GENERAR ETIQUETA&   System.Windows.Controls.DataGrid  -   $��	dtEquipos��   AutoGenerateColumns .  $8 2Haz doble click en el equipo para generar etiqueta��   CanUserAddRows .     CanUserDeleteRows .  $	��960��$
��Left=�$��
70,20,0,10q�$	��400��
�����������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Service Tag��
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 115    
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
ServiceTag+  $	 Marca��$
 90  .  �� *Marca+  $	 Modelo��$	
 120  .  �� *Modelo+  $	 Fin garantía��$	
 170  .  �� *FinGarantia+  $	 
Ubicación��$	
 300  .  �� *
NumOficina+ �� 	Converter# [    $	 	Nº Serie��$	
 100  .  �� *
NumSerie+�� -   $��	statusBar��
�������$��50��.@��� -	   $��tbStatusInformation��
�������$��10q�