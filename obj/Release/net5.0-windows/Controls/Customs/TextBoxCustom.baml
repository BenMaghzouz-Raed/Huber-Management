   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  -    'Huber_Management.Controls.TextBoxCustom   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9local'clr-namespace:Huber_Management.Controls       � 	Resources     textBoxTitleStyle �� 
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
������� �� CornerRadius$ 4��$��Stretch=�$��45��$��Center=����	#CC91A6B1$��2q�._�� $
��10,4q�.+��� -    ��Name$ Title��#��[  �� -    ��Name$ Input��#��[ 