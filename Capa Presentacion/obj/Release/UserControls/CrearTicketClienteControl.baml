   M S B A M L   `   `   `  ���� L  HCapa Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Capa_Presentacion.UserControlsCapa_Presentacion.UserControls  7    1Capa_Presentacion.UserControls.CrearTicketControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  :d2http://schemas.microsoft.com/expression/blend/2008  8local,clr-namespace:Capa_Presentacion.UserControls  .��� 
�������  � RowDefinitions  �� $��80 ��� $	��740 ��� $��50 �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $
��Left=�$��Center=� 
  titulo#��[  $��70,0,0,0q�Crear Ticket�� -   $��panelPrincipal��$��1��$ 
Horizontal=�$��Center=�.+��� $	��545��$ Vertical=�$��Center=�.+��� $ 
Horizontal=�.+���   
labelTitle#��[ $
��Left=�$��70,10q�.��Seleccione Equipo�� -   $��imgHelp�� � ToolTip$ 	Ver ayuda��$��../Imagenes/help.png���� $ 
Horizontal=�.+��� $
��Left=� �� CornerRadius$ 5��$��40��$	��400��$��70,10,20,10q�
�������$��2q�._��� $ 
Horizontal=�.+��� -   $��tbServiceTag�� �� 	MaxLength$ 6��$	��5,0q�$��Center=�$	��350��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$0 *Introduzca el id del equipo y pulse buscar���� -    ��Name$ btSearch��$��40��$��40��$	��0,0q�$��Center=� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ ���	#FF31577E��Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�$ Pantalla Principal��
�����p�
������ $��25��$��25���� -   $��imgResultadoBusqueda��$��40��$��40���� -   $��	chbEquipo��$G ASi no puede localizar la etiqueta del equipo marque esta casilla.��$
��Left=�$
��70,0q�.��Equipo No Etiquetado�� -   $��tbDescripcion�� �� TextWrapping$
 Wrap=�$	 200��  longTextbox#��[ $
��Left=�$	��200��$	��400��$��70,10q�$ Máximo 200 caracteres���� -   $��btCrear��$	��150��  RegularButton#��[ $
��Left=�$
��70,0q�.���� .��_CREAR PETICIÓN�� $��5��.+��� -	   $��cvSeparador��$y�Hidden=�.+��� 		 �� X1$	 0��	
 �� Y1$
 20��	 �� X2$ 0��	 �� Y2$	 730��
�����p�$��1���� -
   $��
panelAyuda��$y�Hidden=�$	��545��$��Right=�.+��� $��Center=�$��10q�20Localice el identificador de su equipo averiado.�� $	��300��$"��../Imagenes/codigoBarras.png���� $��Center=�$��10q�@>En caso de no encontrarlo haga click en "Equipo no Etiquetado"�� $��../Imagenes/checkbox.png��$	��200���� $��Center=�$��10q�75Redacte una breve descripción del problema que tiene�� $ ��../Imagenes/incidencia.png��$	��300���� $��Center=�$��10q�/-Haga clik en "Crear Petición para finalizar.�� -   $��	statusBar��
�������$��2��$��50��.@��� -   $��tbStatusInformation��
�������$��10q�