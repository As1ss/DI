   M S B A M L   `   `   `  ����R  NInicioSesionUsuario-ALB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:InicioSesionUsuario_ALBInicioSesionUsuario_ALB  5   	   *    $InicioSesionUsuario_ALB.AdminVentana   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:InicioSesionUsuario_ALB     5   	     � Title$  AdminVentana��5   	   $	��450��6   $	��800��6+   .��5	      � 
�������.+�5
   
   �� -   5        $��	btnVolver��5
      $
��10 0q�6"   $
��Left=�61   $	��Top=�6L   $��20(�6e      RoundedButtonStyle#��[  5      .��6=   Volver6E   � 5   
   $��Center=�6   $��Center=�6/    � Orientation$ Vertical=�6L   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5      $��20(�6)      AutoGenerateColumns$
 True��67      CanUserAddRows$ False��6R   $��10q�6i      
IsReadOnly$
 True��6u   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� -   5        $��btnDesbloquear��5      $	��155��6/   $��20(�6;   $��Desbloquear��6I   $��0 0 10 0q�6|   #��[  6�   �� 5      -   5        $��btnBloquear��5      $	��120��6,   $��Bloquear��68   $��20(�6K   $��10 0 0 0q�6Y   #��[  6�   5      5      5      5      