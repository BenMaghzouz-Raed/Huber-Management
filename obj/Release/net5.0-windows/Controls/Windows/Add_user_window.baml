   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  /    )Huber_Management.Controls.Add_user_window   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:Huber_Management.Controls     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  Add New Tool��$	��450��$	��500��   MaterialDesignPaper#���    � 
ResizeMode$ NoResize=�  Huber_small_icon � Icon# [  � WindowStartupLocation$ CenterScreen=� � 	Resources   privileges_checkbox �� 
TargetType �� Property �� Value �� 
TargetType  Soft-bg-Blue-Color	 � Cursor
 �� Padding �� CornerRadius �� Orientation F�Name
 � Tag �� Triggers P� Property P� Value �� 
TargetName��%;  &	       7  �� " 	�.���  � ��$ 0q���  � ��$ 18(���  � ��$ DemiBold"���  � �� �� " 	�.R��� $��
border_btn��$��0 5 10 5q�
�������$��1q�8��  $
	 Hand��$
��Left=�$

 10 5q�$ 15��._��� $ 
Horizontal=�$
��Left=�.+��� $��24��$��24��$��Center=�$��0 0 5 0q�$��Center=�.+�F� $ icon_btn��#��z��#��z �� $��
text_block��$��2��#��z��#��z��$
��Left=�$��Center=�$��14(�$��NoWrap=�$��CharacterEllipsis=� P�  �@J�IsMouseOver$
 True��. ��� $ 
border_btn�� � �� �#F6F9FFP�  �@d�	IsChecked$
 TrueY�. ��� $ 
border_btn�� � �� �#F6F9FF�� $ 
text_block�� � �� �#005596�� $ icon_btn�� � �� �#005596�� $ 
border_btn�� � �� �#005596�� $ 
border_btn�� � ��$	 1.5q�.��� $��10q� � RowDefinitions �� $��* ��� $
��auto �.+��� $��0��$��0 0 0 5q�$
 0 0 0 5q�$��0,0,0,2q�  MaterialDesignDivider#��[ ._��  �� �� �� �� �� $
��auto �.+��� -    ��Name$ user_name_add��$��0 0 0 5q�  textBoxInputStyle#���  .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasTrailingIcon$
 True��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	User Name��#���     TrailingIcon$ UserBox=�$��Center=�$��12q��� -   $ full_name_add��$��1��$	��0 5q�#���  $ 	Full Name��#���  $��Center=�$��12q�G� -    G�Name$ password_add��$	��0 5q�$��2��#���  $ Password��  passwordBoxInputStyle#���  $��Center=�$��12q�G� -   $ password_confirm_add��$��3��$	��0 5q�#���  $ Confirm Password��#���  $��Center=�$��12q��� $��4��$ Vertical=�$��Center=�.+��� $ 
Horizontal=�$��Center=�.+�	� -    	�Name$ Admin��#��[  	� 	GroupName$ 
privileges��$ Has all the privileges��  Grey-Blue-Color#��[ $��Admin�� 	 Admin# �  	� -   $ 	SuperUser��#��[ $ 
privileges��$1 +Can't delete or edit, Can't access settings��#��[ $��
Super User�� 	 	SuperUser# � 	 	� -   $ ReadOnly��#��[ $ 
privileges��$ Can only read data��#��[ $��	Read Only�� 
 ReadOnlyUser# � 
 �� $ 
Horizontal=�$��Center=�.+�	� -   $ MakeTransaction��#��[ $ 
privileges��#��[ $��Transactions��  Transactions# �  	� -	   $ MakeReception��#��[ $ 
privileges��#��[ $��
Receptions��  	Reception# �  	� -
   $ MakeCheckout��#��[ $ 
privileges��#��[ $��	Checkouts�� 
 Output# �  � $��3��$��Bottom=� � ColumnDefinitions �� $
��auto ��� $��* ��� $
��auto �.+��� -   $��
Cancel_btn��$��0��$��Cancel��+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�$
��15 0q�$��25��  Label-Gray-Color#���    MaterialDesignFlatButton#��[ �� -    ��Name$ Add_new_user��$��2��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��$��5,0,0,0q� ! MaterialDesignFlatMidBgButton#��[ $��Add User��$ Depth0=�