   M S B A M L   `   `   `  ����L  HProyecto_1EVA_ALB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Proyecto_1EVA_ALBProyecto_1EVA_ALB  5           Proyecto_1EVA_ALB.ModoDios   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Proyecto_1EVA_ALB     5        N� Title$  ModoDios��5	      .��5      �� -   5         ��Name$ canvasNivel3��5      $
��1280��5      $	��720��6    J� 	AllowDrop$
 True��5      $��Center=�5      $��Center=�5      ��5   
   �� 5       �� ImageSource$! images/nivel3Background.jpg��6    j� Stretch$ UniformToFill=�6C   .+�5   
   �� $��25(�6   $��ShowCard Gothic)�6    �� Left$ 10��6;   
������� J� RenderTransformOrigin$ -0.233,-4.054&�6_   $
��Left=�6�   $	��Top=�6�   
 �� Top$	 669��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      ��5      �� 5      $ images/metalTexture.jpg��6   .��5       	Nivel 25      �� 5   
   -   5        	 ��Name$	 
labelVidas��5      $��ShowCard Gothic)�5      $��25(�5      $
��Left=�6   $ 10��5      $	��Top=�5      
�������$ 10��66    5         5!      ��5#      �� 5$      $ images/metalTexture.jpg��6   .��5%       
Vidas: 15&      �� 5(   
   -   5        $	 labelPuntuacion��5(      $��ShowCard Gothic)�5)      $��35(�5*      $
��Left=�6   $	 620��5+      $��Center=�5,      
�������$ 10��5-   !    5.        5/      ��51      �� 52      $ images/metalTexture.jpg��6   .��53       0/1254      �� 56   
   -   5        
 ��Name$
 rectProc��56      $��2��57      $	 548��6   $	 481��61   $
��Left=�6B   $	��Top=�6]   ��58      �� 59      $ images/devilChestCPU.png��6   $ UniformToFill=�6D   
���   �$	��174��5<   5   $	��183��5=   3   5>      �� 5@   
   -   5        $
 rectHDD��5@      $��2��6%   $ 83��69   $	 479��6J   $
��Left=�6[   $	��Top=�6v   ��5A      �� 5B      $ images/devilChestHDD.png��6   $ UniformToFill=�6D   
���   �$	��176��5E   5   $	��183��5F   3   5G      �� 5H   
   -   5        $
 	rectPower��5H      $��2��6'   $ 83��6;   $ 95��6L   $
��Left=�6\   $	��Top=�6w   ��5I      �� 5J      $  images/devilChestPower.png��6   $ UniformToFill=�6F   
���   �$	��175��5M   5   $	��184��5N   3   5O      �� 5P   
   -   5        $
 rectRam��5P      $��2��6%   $	 317��69   $	 272��6K   $��Center=�6\   $��Center=�6y   ��5Q      �� 5R      $ images/devilChestRAM.png��6   $ UniformToFill=�6D   
���   �$	��176��5U   5   $	��183��5V   3   5W      �� 5X   
   -   5        $
 rectGIU��5X      $��2��6%   $	 548��69   $ 78��6K   $
��Left=�6[   $��Center=�6v   ��5Y      �� 5Z      $ images/devilChestGIU.png��6   $ UniformToFill=�6D   
���   �$	��176��5]   5   $	��184��5^   3   5_      �� 5a   
   -	   5        $
 imgProc��5b      $��2��6   $
 1072��60   $ 22��6C   $
��Left=�6S   $��Center=�6n   ��5c      �� 5d      $ images/Proc.png��6   $
 Fill=�6;   $	��111��5g   5   $	��122��5h   3   5i      �� 5k   
   -
   5        $
 imgHDD��5l      $��2��6   $
 1082��6%   $	 138��68   $��Center=�6I   $��Center=�6f   ��5m      �� 5n      $ images/HDDpng.png��6   $ UniformToFill=�6=   $	��149��5p   5   $	��102��5q   3   5r      �� 5s   
   -   5        $
 imgPower��5u      $��2��6   $	 997��61   $	 310��6C   $ 0.5,0.5&�6T   $��Center=�6t   $	��Top=�6�   z�5v      V� 5w      .~�5x      �� �� 5y      �� 5z       �� Angle$ -360.677Q�6&   T� 5{      5|      ��5~      �� 5�      $ images/Power.png��6   $ UniformToFill=�6<   $	��118��5�   5   $	��226��5�   3   5�      �� 5�   
   -   5        $
 imgRam��5�      $��2��6   $	 935��6/   $	 523��6A   $ 0.5,0.5&�6R   $��Center=�6r   $	��Top=�6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 89.463Q�6&   T� 5�      5�      ��5�      �� 5�      $ images/RAM.png��6   $ UniformToFill=�6:    j� TileMode$
 None=�6R   $��79��5�   4   $	��237��5�   3   5�      �� 5�   
   -   5        $
 imgGIU��5�      $��2��6   $
 1124��6/   $	 448��6B   $
��Left=�6S   $	��Top=�6n   ��5�      �� 5�      $ images/GIU.png��6   $ UniformToFill=�6:   $	��238��5�   5   $	��120��5�   3   5�      5�      5�      