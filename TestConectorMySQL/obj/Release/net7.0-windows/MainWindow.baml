   M S B A M L   `   `   `  ���� L  HTestConectorMySQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TestConectorMySQLTestConectorMySQL  "    TestConectorMySQL.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:TestConectorMySQL       � Title$  
MainWindow��$	��450��$	��450��.���  � ColumnDefinitions �� $	��100 ��� $��* ��� $	��100 � � RowDefinitions �� $	��150 ��� $��* ��� $	��100 �.+��� $��1��$��0��$��Center=�$��Bottom=�$��35(�Iniciar conexión� $
��Auto��$
��Auto��$��1��$��1��$��Center=�$��Center=� �� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��Center=�$��Center=�$��0��$��0��$��0,0,5,0q�	Servidor:�� -    ��Name$ 
tbServidor��$��1��$��0��$��Center=�$��75��$��0,0,0,5q��� $��Center=�$��0��$��1��$��0,5,5,0q�	Puerto:�� -   $ tbPuerto��$��1��$��1��$��75��$��0,2,0,3q��� $��Center=�$��0��$��2��$��0,5,5,0q�Base de Datos:�� -   $��tbBDD��$��1��$��2��$��75��$��0,2,0,3q��� $��Center=�$��0��$��3��$��0,5,5,0q�
Usuario:�� -   $ 	tbUsuario��$��1��$��3��$��75��$��0,2,0,3q��� $��Center=�$��0��$��4��$��0,5,5,0q�Contraseña:G� -    G�Name$ tbContrasena��$��1��$��4��$��75��$��0,5,0,25q�$��2���� -    ��Name$ btnConectar��$��0��$��5��$��2��$��Conectar��$��0,5,0,0q�