   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  2    ,Huber_Management.Controls.Single_tool_Window   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:Huber_Management.Controls     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignPaper#���     � Title$  Tool Details��$	��430��$	��720�� � WindowStartupLocation$ CenterScreen=� � Topmost$
 True�� � 	Resources   single_tool_Checkbox �� 
TargetType �� Property �� Value  Grey-Blue-Color �� 
TargetType ��Name	 � ColumnDefinitions
 ��Name F�Name
 � Tag �� Triggers P� Property P� Value �� 
TargetName��%i  &	       7  7  �� " 	�.���  � ��$ 16(���  � ��$ DemiBold"���  � ��8   ��  � �� �� " 	�.R��� $ border_bottom��$��0,1,0,1q�
�������8�� ._�� $��grid_btn��
������ $��40��$��Center=�$��Center=�	 �� $
 icon_column��$��60 ��� $
��auto �.+�F� $ icon_btn��$��0��$��24��$��24��#��z��#��z �� $��
text_block��$��1��#��z��#��z��$
��Left=�$��Center=�$��NoWrap=�$��CharacterEllipsis=� P�  �@J�IsMouseOver$
 True��. ��� $ border_bottom�� � �� �#F6F9FF�� $ 
text_block�� � �� �#005596�� $ icon_btn�� � �� �#005596P�  �@d�	IsChecked$
 TrueY�. ��� $ border_bottom�� � �� �#F6F9FF�� $ 
text_block�� � �� �#005596�� $ icon_btn�� � �� �#005596�� $ border_bottom�� � �� �#005596.���  � RowDefinitions �� $	��150���� $��40 ��� $��2* �.+�� $��0��$��10q�	 �� $��2* �$	��100���� $��3* ��� $��2* �.+��� $��0��$��1q�  MaterialDesignDivider#��[ ._��� -    ��Name$ image_detail��  noImage#��[  � Cursor$ SizeAll��$��Uniform=�� $��1��$��	10 0 10 0q� �� $
��auto ��� $��* ��� $
��auto �.+��� -    ��Name$ serial_nb_detail��$��0��$��	SERIAL ID��$��26(�$��DemiBold"�$	��Top=��� -   $ designation_detail��$��1��$%��No designation for this tool !!��$��14(�  Label-Gray-Color#��[ $��WrapWithOverflow=��� $��2�� �� Orientation$ 
Horizontal=�$
��Left=�.+��� -   $ actual_stock_detail�� �� Padding$
 10 5q� � ToolTip$ Actual Stock��$��0 0 20 0q�$��0 Available��  Soft-green-Color#��[ $��DemiBold"�$��16(�  Success-green-Color#��[ �� -   $ defective_detail��$
 10 5q�$ Defective quantity��$��0��  Soft-red-Color#��[ $��DemiBold"�$��16(� 	 Failed-red-Color#��[	 �� $��2��$��1,0,0,0q� �� Padding$
 10 0q�#��[ ._��  �� �� �� .+��� -    ��Name$ Add_reception_tool��$��2��$��Stretch=�$
��15 0q�$ Make a Reception��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��#��[  "
 MaterialDesignFlatDarkBgButton#��[
 +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�#��[ $��36��.��� 	 �� $��25 ��� $
��auto �.+��� $��24��$��24��$��0��.+�F� 
������������@B  � рˤ  � ������� @`�� Ѡ� ��{ �@�� @]� Ѡ� �!������� @ �� рˤ ��� �@B ��� �@B  � �@o@�� ���- �� ��� ��  @,  	= �@B  � ���-  � ���- ��[ �@o@��[ �@o@ -1���-  -1���-  $� �@B  $� �@B  -1�@B ��A�� ��O��- ��O�@o@��O� 8Q��O��^��A��^ -1���^ 	= ���^ @,  8Q�� @o@�� 	�� $��	RECEPTION��$��1��$��Center=�$��10,0,0,0q�
��������� -   $ Add_output_tool��$��1��$
��15 0q�$ Make a Checkout��$ 0��$��Stretch=�#��[	 #��[
 $ Depth0=�#��[	 $��36��.��� 	 �� $��25 ��� $
��auto �.+��� $��24��$��24��$��0��.+�F� 
������������@T�  � р� � ��� `�� Ѡ��{ �@�X@]� Ѡ�!���  �� р���� �@T� ��� �@T�  � �@o@��	�@o@ -1���-  -1���- ��[ �@o@��[ �@o@�9� ���^@�� ���^ 	= ���^ @,  8Q�� @o@�� ���- �� ��� ��  @,  	= �@B  -1�@B ��A�� ��O��- ��O�@o@��O� 8Q��O��^��A��^ -1���^@�� �@o@��		�� $��CHECKOUT��$��1��$��Center=�$��10,0,0,0q�
�������� $��2��	 �� �� .+��� -   $ MenuItem_modify��$��Stretch=�$	��5 0q�$ Edit the Tool��$ 0��#��[ #��[
 $ Depth0=�#��[ $��36��.��� 	 �� $��24 ��� $
��auto �.+��� $��24��$��24��$��0��.+�F� 
������������`�4�� Ѡ�v �� Ӏ�g �� ��[ ��* ��[ ��9 Q��[ ���Q80@Ӏ�[ �s��g ����v ���`�4��Ӏ|C����O����O���Q80@р�O��9 Ӏ�O��* �|C�� `�4�� � è ��� �@T� ��� �@T� �r� � ��  �h � ;�i� � è ��� ��V�&p Ѡ0i ���� `!` �fffff�0@ �P �`C��M ����M ��	 �P ��V gd �@� p�g @� ��l �V�&p � 	= ��[ р� ��[ р�  -1Ӏ� �B @, ��O 	= ��Oр���Oр� -1� 	=  -1� 	= ��[ 	�� $
��EDIT��$��1��$��Center=�$��5,0,0,0q�
��������� -	   $ MenuItem_Delete��$��1��$��Stretch=�$	��5 0q�$ Delete from the Database��$ 0��
������ #��[
 $ Depth0=�
������ $��36��.��� 	 �� $��24 ��� $
��auto �.+��� $��24��$��24��$��0��.+�F� #��[	 �������! 	= ����  	= Ѡ@� ��- �`�� ��- � ��  	= �@KL  	= �@KL ��[ ���!��[ ���[ ��!� z @o@ �� �� � $� @o@׀���! �� �� р���j р�[ ��j р�[ ��!	�� $��DELETE��$��1��$��Center=�$��5,0,0,0q�#��[	 � $��1��	 �� �� .+�	� -
    	�Name$ details_button��#���   d� 	IsChecked$
 TrueY�$��DETAILS�� 	� 	GroupName$ tool_informations��  	All_Tools# [ 	� -   $ history_button��$��1��#���  $��HISTORY��$ tool_informations��# [  � -     �Name$ Single_tool_section��$��2��   � NavigationUIVisibility$  Hidden=�