   M S B A M L   `   `   `  ����K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  5      -    'Huber_Management.Controls.TextBoxCustom   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Huber_Management.Controls     5        � 	Resources  5	         textBoxTitleStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding �� ElementName �� Value N� EnterActions	 g� 
SpeedRatio
 �� TargetProperty	 W� To	 t� To N� ExitActions  textBoxInputStyle��%^  &	        &	 �    �� 5   
   " ��6*   .�5      ��  � ��$
 Left=�64   �� 5       � ��$ Center=�62   �� 5       � �� �#a3a3a46+   �� 5       � ��$ 14(�6)   �� 5       �@��Padding$	 2,0q�6(    5      �� 5       6   �� *Text+$ Input��  6J    5      �� 5      .��5      �� $	 10Q�6)   .��5   "   W� $
 FontSize�62    146W   t� 5   "   $
 Margin�65    06X   5      5       5      �� 5      .��5       �� $	 10Q�6)   .��5!   "   W� $
 FontSize�62    116W   t� 5"   "   $
 Margin�65    0 0 0 256X   5#      5$      5'      5)      �� 5-   
   " ��6*   .�5.      ��  � ��$ Center=�62   �� 5/       � ��$ 0q�60   �� 50       � ��
 ���� 6+   �� 51       � ��$ 14(�6)   �� 52       � ��$ SemiBold"�6+   �� 53       � ��$	 2,0q�6(    54      �� 55       6   �� *
FontSize+$ Title�� 116N    57      �� 58      .��59      �� $	 10Q�6)   .��5:   "   W� $
 FontSize�62    146W   t� 5;   "   $
 Margin�65    0 8 0 06X   5<      5=       5A      �� 5B      .��5C      �� $	 10Q�6)   .��5D   "   W� $
 FontSize�62    146W   t� 5E   "   $
 Margin�65    06X   5F      5G      5J      5L      5N      .��5P      �� 
������� �� CornerRadius$ 4��6    $��Stretch=�61   $��45��5Q      $��Center=�6   ���	#CC91A6B1$��2q�6L   ._�5S      � $
��10,4q�6   .+�5U      �� -   5         ��Name$ Title��5U      #��[  5V      �� 5Y      -   5         ��Name$ Input��5Y      #��[ 5Z      5\      5]      5^      