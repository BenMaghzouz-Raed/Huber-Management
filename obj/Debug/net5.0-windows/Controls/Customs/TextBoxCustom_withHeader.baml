   M S B A M L   `   `   `  ����K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  5      8    2Huber_Management.Controls.TextBoxCustom_withHeader   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Huber_Management.Controls     5      $��60��5        � 	Resources  5
         textBoxInputStyle �� 
TargetType �� Property �� Value  Table-Header-bg-Color �� 
TargetType �� CornerRadius �� Padding �� Triggers P� Property	 P� Value  Dark-main-Blue-Color��%_  &	        7  7  7  �� 5   
   " ��6*   .�5      ��  � ��$ Center=�62   �� 5       � ��
 ���� 6+   �� 5       � ��8   6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ SemiBold"�6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� 
�������$ 6��64   $
 10 0q�6E   #��z��6T   $��2q�5      $��30��61   8�� ._�5      �� #��z��6(   $��Center=�6F   $��Center=�6c   5      5      5       5       P� 5!       �@J�	IsFocused$
	 True��6/   . �5"      ��  � ��8  64   5#      5%      5'      .��5)      � 
 � RowDefinitions
 5*   
   �� 5+      $
��auto �6   �� 5,      $��* �6   .+�5/   
   �� -   5         ��Name$ textboxTitle��5/      $��	Serial id��6&   $��12(�50      $��Normal"�6   $	��Top=�62     Text-Black-Color#��[ 51      �� 53   
   -   5         ��Name$ 	textInput��53      $��Placeholder��6%    �� TextWrapping$ NoWrap=�68   $��1��6N   #��[  54   !   $��30��6L   55      56      