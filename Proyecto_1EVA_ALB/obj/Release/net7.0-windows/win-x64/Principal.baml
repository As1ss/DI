   M S B A M L   `   `   `  ���� L  HProyecto_1EVA_ALB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Proyecto_1EVA_ALBProyecto_1EVA_ALB  !    Proyecto_1EVA_ALB.Principal   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:Proyecto_1EVA_ALB       N� Title$  	Principal�� � 	Resources    FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType �� 
TargetType	 ��Name
 �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 R     &	 g     &	 |     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     7   7  7  7  7  7  7  7  7  7 	 �� .���  � �� �� .R��� $��2q�$	 1 2R�#��� ��$
 true��$��1���� $ 	#FFDDDDDD���� $ 	#FF707070���� $ 	#FFBEE6FD���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $	 border��$
 25��#��z��#��z��#��z��$
 true��._��� $ contentPresenter��$|�False��#��z��#��z��$
��True��# z #��z�� P�  �@��IsDefaulted$
 true��. ��� $ border��# � �� � ��P�  �@J�IsMouseOver$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � ��$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � {�$ false��. ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8 	  � ��.���� ����  �� ImageSource$$ images/PrincipalBackground.png��.+��� $	��125(�$��ShowCard Gothic)� �� Left$	 302��
 �� Top$ 10��
�������$
��Left=�$��Center=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  
ORDENA TÓ�� $��images/winstonMenu.png��$	��754��$	��718��$	 126��$ 30��$
��Left=� J� RenderTransformOrigin$ 0.5,0.5&�$	��Top=�z�V� .~���  �� ScaleX$ -1Q��� �� T� �� -    ��Name$ btnJugar��#��� 
 $��65(�$	 340��$	��250��$	��100��$	 538��$��ShowCard Gothic)�$
��Left=�$��Center=����� $ images/buttonTexture.jpg�� j� Stretch$
 None=�   .��JUGAR�� -   $ btnSalir��#��� 
 $��65(�$	 672��$	 538��$
��Left=�$	��Top=�$	��250��$	��100��$��ShowCard Gothic)����	#FFCE3636
�������   .��SALIR