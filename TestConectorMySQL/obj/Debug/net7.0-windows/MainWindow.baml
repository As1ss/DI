   M S B A M L   `   `   `  ����L  HTestConectorMySQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TestConectorMySQLTestConectorMySQL  5   	   "    TestConectorMySQL.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TestConectorMySQL     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��450��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   �� $��1��6   $��0��6$   $��Center=�61   $��Bottom=�6N   $��35(�5      Iniciar conexión64   � 5   
   $
��Auto��6   $
��Auto��6   $��1��6*   $��1��6:   $��Center=�6G   $��Center=�6d    5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    .+�5'      �� $��Center=�6   $��Center=�65   $��0��6P   $��0��6`   $��0,0,5,0q�5(      	Servidor:64   �� 5)      -   5         ��Name$ 
tbServidor��5)      $��1��5*      $��0��6!   $��Center=�6.   $��75��6I   $��0,0,0,5q�6T   �� 5,      $��Center=�6   $��0��65   $��1��6E   $��0,5,5,0q�6R   	Puerto:6l   �� 5-      -   5        $ tbPuerto��5-      $��1��5.      $��1��6!   $��75��6.   $��0,2,0,3q�69   �� 50      $��Center=�6   $��0��65   $��2��6E   $��0,5,5,0q�6R   Base de Datos:6s   �� 51      -   5        $��tbBDD��51      $��1��52      $��2��6!   $��75��6.   $��0,2,0,3q�69   �� 54      $��Center=�6   $��0��65   $��3��6E   $��0,5,5,0q�6R   
Usuario:6m   �� 55      -   5        $ 	tbUsuario��55      $��1��56      $��3��6!   $��75��6.   $��0,2,0,3q�69   �� 58      $��Center=�6   $��0��65   $��4��6E   $��0,5,5,0q�6R   Contraseña:6p   G� 59      -   5         G�Name$ tbContrasena��5:      $��1��5;      $��4��6!   $��75��6.   $��0,5,0,25q�69   $��2��6K   �� 5=      -   5         ��Name$ btnConectar��5=      $��0��6D   $��5��6T   $��2��6a   $��Conectar��6u   $��0,5,0,0q�6�   5>      5?      5B      