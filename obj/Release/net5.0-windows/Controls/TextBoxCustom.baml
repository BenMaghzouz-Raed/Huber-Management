   M S B A M L   `   `   `  ���� J  FHuber-Managment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Huber_Managment.ControlsHuber_Managment.Controls  ,    &Huber_Managment.Controls.TextBoxCustom   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     8local&clr-namespace:Huber_Managment.Controls       � 	Resources     textBoxTitleStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding �� ElementName �� Value N� EnterActions	 g� 
SpeedRatio
 �� TargetProperty	 W� To	 t� To N� ExitActions  textBoxInputStyle��%�  &	        &	 c    �� " ��.���  � ��$
 Left=���  � ��$ Center=���  � �� �#a3a3a4��  � ��$ 14(���  �@��Padding$	 2,0q� ��  �� *Text+$ Input��   �� .���� $	 10Q�.��W� $
 FontSize� 14t� $
 Margin� 0 �� .���� $	 10Q�.��W� $
 FontSize� 11t� $
 Margin� 0 0 0 25�� " ��.���  � ��$ Center=���  � ��$ 0q���  � ��
 ���� ��  � ��$ 14(���  � ��$ SemiBold"���  � ��$	 2,0q� ��  �� *
FontSize+$ Title�� 11 �� .���� $	 10Q�.��W� $
 FontSize� 14t� $
 Margin� 0 8 0 0 �� .���� $	 10Q�.��W� $
 FontSize� 14t� $
 Margin� 0.���� 
������� �� CornerRadius$ 10��$��Stretch=�$��45��$��Center=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 15Q�   ShadowDepth$ 4Q�   	Direction$	 280Q�   Color$ 
WhiteSmoke��   Opacity$ .5Q�._�� $
��10,4q�.+��� -    ��Name$ Title��#��[  �� -    ��Name$ Input��#��[ 