   M S B A M L   `   `   `  ����L  HProyecto_1EVA_ALB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Proyecto_1EVA_ALBProyecto_1EVA_ALB  5      !    Proyecto_1EVA_ALB.Principal   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Proyecto_1EVA_ALB     5        N� Title$  	Principal��5
       � 	Resources 5         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType �� 
TargetType	 ��Name
 �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5        � ��8  6+   �� 5!       � ��8  6,   �� 5"       � ��# � ��6+   �� 5#       � ��$ 1q�60   �� 5$       � ��$ Center=�6;   �� 5%       � ��$ Center=�69   �� 5&       � ��$ 1q�6(   �� 5'       � �� 5(      �� 5)      " ��6&   .R�5*      �� $	 border��6!   $
 25��61   #��z��6C   #��z��6m   #��z��6�   $
 true��6�   ._�5+      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5,       5-      P� 5.       �@��IsDefaulted$
 true��6=   . �5/   "   �� $ border��6@   # � ��6T    � ��50      P� 51       �@J�IsMouseOver$
 true��6=   . �52   "   �� $ border��6?   8   � ��6S   �� 53   "   $ border��6@   8   � ��6T   54      P� 55       � ��$
 true��6;   . �56   "   �� $ border��6?   8   � ��6S   �� 57   "   $ border��6@   8   � ��6T   58      P� 59       � {�$ false��6;   . �5:   "   �� $ border��6?   8   � ��6S   �� 5;   "   $ border��6@   8   � ��6T   �� 5<   "   $ contentPresenter��6K   8 	  � ��6i   5=      5?      5A      5B      5C      .��5D      �� ��5E   
   �� 5F       �� ImageSource$$ images/PrincipalBackground.png��6   .+�5H   
   �� $	��125(�6   $��ShowCard Gothic)�5I       �� Left$	 302��6-   
 �� Top$ 10��6?   
�������$
��Left=�6b   $��Center=�6}    J� Effect 5J      3  -System.Windows.Media.Effects.DropShadowEffect  5K      
ORDENA TÓ5L   +   �� 5M   
   $��images/winstonMenu.png��6   $	��754��60   $	��718��6<   $	 126��6I   $ 30��6[   $
��Left=�6k    J� RenderTransformOrigin$ 0.5,0.5&�6�   $	��Top=�6�   z�5N      V� 5O      .~�5P      ��  �� ScaleX$ -1Q�6%   �� 5Q      �� 5R      T� 5S      5T      5V      �� 5W   
   -   5         ��Name$ btnJugar��5Z      #��� 
 5Y      $��65(�5Z   #   $	 340��61   $	��250��5[      $	��100��6   $	 538��5\      $��ShowCard Gothic)�6   $
��Left=�5]      $��Center=�5^      ��5`      �� 5a      $ images/buttonTexture.jpg��6    j� Stretch$
 None=�5b       5f        5g      .��5h      JUGAR5i      �� 5j   
   -   5        $ btnSalir��5k      #��� 
 5j      $��65(�5k      $	 672��6-   $	 538��5l      $
��Left=�5m      $	��Top=�5n      $	��250��5o      $	��100��6   $��ShowCard Gothic)�5q      ���	#FFCE3636
������� 5r        5s      .��5t      SALIR5u      5w      5x      