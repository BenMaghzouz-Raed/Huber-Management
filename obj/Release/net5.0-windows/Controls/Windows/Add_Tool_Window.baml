   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  E'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  /    )Huber_Management.Controls.Add_Tool_Window   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <Controls'clr-namespace:Huber_Management.Controls     9local'clr-namespace:Huber_Management.Controls     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  Add New Tool��$	��540��$	��450��   MaterialDesignPaper#���    � 
ResizeMode$ NoResize=�  Huber_small_icon � Icon# [  � WindowStartupLocation$ CenterScreen=�.��� $��10q� � RowDefinitions �� $
��auto �$	��127���� $
��auto ��� $
��auto �$	��127���� $��* �.+��� $��0��$��0 0 0 5q� �� Padding$ 0 0 0 5q�$��0,0,0,2q�  MaterialDesignDivider#��[ ._��  �� �� .+��  � ColumnDefinitions �� $��4* ��� $��2* �.+��� -    ��Name$ Serial_nb_add��$��0 0 5 5q�  textBoxInputStyle#���  .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasTrailingIcon$
 True��)  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Serial Number��#���  
   TrailingIcon$
 IdCard=�$��Center=�$��12q��� -   $ quantity_add��$��1��$��5 0 0 5q�#���  $	 Quantity��#���  $��Center=�$��12q�� $��1�� �� $��4* ��� $��1* ��� $��1* �.+��� -   $ supplier_code_add��$��0 5 5 5q�#���  $	 Supplier code��#���  $��Center=�$��12q��� -   $ min_add��$��1��$��	5 5 2.5 5q�#���  $		 Min��#���  $��Center=�$��12q��� -   $ max_add��$��2��$��	7.5 5 0 5q�#���  $		 Max��#���  $��Center=�$��12q��� $��1��$��0 0 0 5q�$ 0 0 0 5q�$��0,0,0,2q�#��[ ._��  �� �� �� .+��  �� �� .+��� -   $ 	price_add��$��0 5 5 5q�$��0��$
 True��#���  $	 
Price Euro��#���  $��Center=�$��12q�$

 Euro=��� -   $ price_add_DT��$��5 5 0 5q�$��1��#���  $	 Price DT��#���  $��Center=�$��12q�� $��1�� �� �� .+��� -    ��Name$ division_add_combobox��  comboBoxInputStyle#���  $y�Visible=�#���  $	 Select a Division��$��0 5 5 5q�.@���  � Cursor$
 Hand��.��� -	   $��new_division�� �� �� .+��� $��25��$��25��.+�F� 
������������@f@]� �@]� @]� �@]� @f��ا @f��ا @]� ���j @]� ���j �ا ��ا �ا ��ا ��j �@]� ��j �@]� �ا �@f�ا � � �� ׀�  �  ��� ��� � � ��O ��� ��� ׀�O �  ��� ��� � � ��  ��� ��� 	�� $��Add New Division��$��1��$��DemiBold"�
��������� -
   $ division_add��$��0 5 5 5q�#���  $y�	Collapsed=�$	 Division��#���  $��Center=�$��12q��� -   $ position_add��$��1��$��5 5 0 5q�#���  $	 Position��#���  $��Center=�$��12q�� $��2�� �� �� .+��� -   $ project_add_combobox��#���  $y�Visible=�#���  $	 Select a project��$��0 5 5 5q�.@��� $
 Hand��.��� -    �Name$ new_project�� �� �� .+��� $��25��$��25��.+�F� 
������������@f@]� �@]� @]� �@]� @f��ا @f��ا @]� ���j @]� ���j �ا ��ا �ا ��ا ��j �@]� ��j �@]� �ا �@f�ا � � �� ׀�  �  ��� ��� � � ��O ��� ��� ׀�O �  ��� ��� � � ��  ��� ��� 	�� $��Add New Project��$��1��$��DemiBold"�
��������� -   $ project_add��$��0 5 5 5q�$y�	Collapsed=�#���  $	 Project��#���  $��Center=�$��12q��� -   $ process_add_combobox��$��1��#���  $y�Visible=�#���  $	 Select a process��$��5 5 0 5q�.@��� $
 Hand��.��� -   $ new_process�� �� �� .+��� $��25��$��25��.+�F� 
������������@f@]� �@]� @]� �@]� @f��ا @f��ا @]� ���j @]� ���j �ا ��ا �ا ��ا ��j �@]� ��j �@]� �ا �@f�ا � � �� ׀�  �  ��� ��� � � ��O ��� ��� ׀�O �  ��� ��� � � ��  ��� ��� 	�� $��Add New Process��$��1��$��DemiBold"�
��������� -   $ process_add��$��1��$��5 5 0 5q�$y�	Collapsed=�#���  $	 Process��#���  $��Center=�$��12q��� $��2��$ 0 0 0 5q�$��Center=�._��  �� $��4* ��� $��2* �.+��  �� �� .+��� -   $ designation_add�� �� 	IsEnabled$
 True��$��0 5 5 5q�#���  $	 Designation��#���  $��Center=�$��12q�� $��1�� �� �� .+��� -   $ supplier_add_combobox��#���  $y�Visible=�#���  $	 Supplier��$��0 5 5 5q�.@��� $
 Hand��.��� -   $ new_supplier��$
��Left=� �� �� .+��� $��25��$��25��.+�F� 
������������@f@]� �@]� @]� �@]� @f��ا @f��ا @]� ���j @]� ���j �ا ��ا �ا ��ا ��j �@]� ��j �@]� �ا �@f�ا � � �� ׀�  �  ��� ��� � � ��O ��� ��� ׀�O �  ��� ��� � � ��  ��� ��� 	�� $��Add New Supplier��$��1��$��DemiBold"�
��������� -   $ supplier_add��$��0 5 5 5q�#���  $y�	Collapsed=�$	 Supplier��#���  $��Center=�$��12q��� -   $ tool_criticality��$��5q�$��1��#���  $	 Criticality��#���  $��Center=�$��12q��� -   $��1��$��Stretch=�$
 Hand��$��5q� �� CornerRadius$ 2��._��  �� $��* ��� $
��auto �.+��� -    ��Name$ MyImage��  addImage#��[ $	��105��$��Uniform=�$��Center=�$��Center=� �� StretchDirection$
 Both=��� -    ��Name$ 	ImagePath��$�� ��$��1��$y�	Collapsed=�$��CharacterEllipsis=�$��Center=�����  �� 
TargetType" ��.���  �� Property � �� �� Value$ 1q���  � ��# [  �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  � ��  Soft-bg-Blue-Color# [ ��  � ��$ 2q���  � ��  Dark-main-Blue-Color# [ � $��3��$��Bottom=� �� $
��auto ��� $��* ��� $
��auto �.+��� -   $��
Cancel_btn��$��0��$��Cancel��+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�$
��15 0q�$��25��  Label-Gray-Color#���   	 MaterialDesignFlatButton#��[	 �� -    ��Name$ Add_new_tool��$��2��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��$��5,0,0,0q� !
 MaterialDesignFlatMidBgButton#��[
 $��CONFIRM��$ Depth0=�