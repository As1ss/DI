   M S B A M L   `   `   `  ���� L  HProyecto_1EVA_ALB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Proyecto_1EVA_ALBProyecto_1EVA_ALB  !    Proyecto_1EVA_ALB.ModoFacil   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:Proyecto_1EVA_ALB       N� Title$  	ModoFacil��.���� -    ��Name$ canvasNivel1��$
��1280��$	��720�� J� 	AllowDrop$
 True��$��Center=�$��Center=�����  �� ImageSource$! images/nivel1Background.png�� j� Stretch$ UniformToFill=�.+��� $��25(�$��ShowCard Gothic)� �� Left$ 10��
������� J� RenderTransformOrigin$ -0.233,-4.054&�$
��Left=�$	��Top=�
 �� Top$	 669�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  ���� $ images/buttonTexture.jpg��.��	Nivel 1�� -   	 ��Name$	 
labelVidas��$��ShowCard Gothic)�$��25(�$
��Left=�$ 10��$	��Top=�
�������$ 10��   ���� $ images/buttonTexture.jpg��.��
Vidas: 3�� -   $	 labelPuntuacion��$��ShowCard Gothic)�$��35(�$
��Left=�$	 620��$��Center=�
�������$ 10��   ���� $ images/buttonTexture.jpg��.��0/5�� -   
 ��Name$
 rectProc��$��2��$ 83��$ 78��$
��Left=�$	��Top=����� $ images/boxCPU.png��$
 None=�
���   �$	��174��$	��183���� -   $
 rectHDD��$��2��$ 83��$	 479��$
��Left=�$	��Top=����� $ images/boxHDD.png��$
 None=�
���   �$	��176��$	��183���� -   $
 	rectPower��$��2��$	 528��$	 479��$
��Left=�$	��Top=����� $ images/boxPower.png��$
 None=�
���   �$	��175��$	��184���� -   $
 rectRam��$��2��$	 548��$ 77��$
��Left=�$	��Top=����� $ images/boxRAM.png��$
 None=�
���   �$	��175��$	��183���� -   $
 rectGIU��$��2��$	 307��$	 272��$
��Left=�$	��Top=����� $ images/boxGIU.png��$
 None=�
���   �$	��176��$	��183���� -	   $
 imgProc��$��2��$
 1072��$ 22��$
��Left=�$��Center=����� $ images/Proc.png��$
 Fill=�$	��111��$	��122���� -
   $
 imgHDD��$��2��$
 1082��$	 138��$��Center=�$��Center=����� $ images/HDDpng.png��$ UniformToFill=�$	��149��$	��102���� -   $
 imgPower��$��2��$	 997��$	 310��$ 0.5,0.5&�$��Center=�$	��Top=�z�V� .~��� �� ��  �� Angle$ -360.677Q�T� ���� $ images/Power.png��$ UniformToFill=�$	��118��$	��226���� -   $
 imgRam��$��2��$	 935��$	 523��$ 0.5,0.5&�$��Center=�$	��Top=�z�V� .~��� �� �� $ 89.463Q�T� ���� $ images/RAM.png��$ UniformToFill=� j� TileMode$
 None=�$��79��$	��237���� -   $
 imgGIU��$��2��$
 1124��$	 448��$
��Left=�$	��Top=����� $ images/GIU.png��$ UniformToFill=�$	��238��$	��120��