   M S B A M L   `   `   `  ���� J  FHuber-Managment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Huber_Managment.ControlsHuber_Managment.Controls  ,    &Huber_Managment.Controls.TextBoxCustom   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     8local&clr-namespace:Huber_Managment.Controls     $	��300��$��50��  � 	Resources     textBoxTitleStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding �� ElementName �� Value N� EnterActions	 g� 
SpeedRatio
 �� TargetProperty	 W� To	 t� To N� ExitActions  textBoxInputStyle��%�  &	        &	 c    �� " ��.���  � ��$
 Left=���  � ��$ Center=���  � �� �#a3a3a4��  � ��$ 18(���  �@��Padding$	 2,0q� ��  �� *Text+$ Input��   �� .���� $	 10Q�.��W� $
 FontSize� 18t� $
 Margin� 0 �� .���� $	 10Q�.��W� $
 FontSize� 12t� $
 Margin� 0 0 0 30�� " ��.���  � ��$ Center=���  � ��$ 0q���  � ��
 ���� ��  � ��$ 18(���  � ��$ SemiBold"���  � ��$	 2,0q� ��  �� *
FontSize+$ Title�� 12 �� .���� $	 10Q�.��W� $
 FontSize� 18t� $
 Margin� 0 10 0 0 �� .���� $	 10Q�.��W� $
 FontSize� 18t� $
 Margin� 0.���� 
������� �� CornerRadius$ 10�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 23Q�   ShadowDepth$ 5Q�   	Direction$	 270Q�   Color$ 
WhiteSmoke��._�� $
��20,4q�.+��� -    ��Name$ Title��#��[  �� -    ��Name$ Input��#��[ 