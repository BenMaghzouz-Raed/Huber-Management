   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Huber_ManagementHuber_Management  E'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  !    Huber_Management.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:Huber_Management     ;control'clr-namespace:Huber_Management.Controls     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont#���   � Title$ Managment APP��$	��700��$
��1300�� � 
ResizeMode$ 	CanResize=� � WindowStartupLocation$ CenterScreen=� � WindowState$ Normal=�$
��1000��$	��700��  Screen-bg-Color#��[   Huber_small_icon � Icon# [  � 	Resources   side_bar_button �� 
TargetType	 �� Property
 �� Value  Grey-Blue-Color �� 
TargetType ��Name � ColumnDefinitions
 � Tag �� Triggers P� Property P� Value  Soft-bg-Blue-Color �� 
TargetName  Dark-main-Blue-Color��%4  &	       7  7  7  7  7  �� " 	�.��� 	 � ��

 ������� 	 � ��$
 0q��� 	 � ��$
 40���� 	 � ��$
 18(��� 	 � ��$
 DemiBold"��� 	 � ��8
   �� 	 � ��
 �� " 	�.R��� $ Border��#��z��._��  �� $��55 ��� $��* �.+��� #��z $��24��$��24���� $��1��$
��Left=�$��Center=�#��z��$��NoWrap=�$��CharacterEllipsis=� P�  �@J�IsMouseOver$
 True��. ��� 8
  $ Border��	 � ���� 8
  	 � ��P�  �@d�	IsChecked$
 TrueY�. ��� 8
  $ Border��	 � ���� 8
  	 � ��.���  �� $
��auto ��� $��5* �.+�� -    �Name$ gridMenu��$��0�� � RowDefinitions �� $��60 ��� $��* �.+�d� -    d�Name$ 	logo_menu��  logoMenuStyle#���   � Triggers :�  :� RoutedEvent$ ToggleButton.Unchecked��.[��� .���� -    ��Name$ 	hidePanel��.��W�  �� 
TargetName$ gridMenu�� �� TargetProperty$ Width� g� 	BeginTime	 0:0:0 W� From 60	 W� To 220 g� Duration$ 0:0:0.3D�:� $ ToggleButton.Checked��.[��� .���� -   $ 	showPanel��.��W� $ gridMenu��$ Width�	 0:0:0 220 60$ 0:0:0.3D��� 
�������$��0,0,3,3q����	#FFF8F8F9$��Stretch=�$��1��._�]� $��Stretch=�$��Stretch=�.+��� 
�������$��0,0,0,3q����	#FFF8F8F9$	��Top=�._��� $��	0,20,0,20q� �� Orientation$ Vertical=�.+�	� -   $��	Dashboard�� 	 sidebarCheckbox#��� 	 
  J� Uid$   /Pages/Dashboard_page.xaml��#��[ ! 	� 	GroupName$! 	Pages_nav��" d� 	IsChecked$
" TrueY� 
 	Dashboard# � 
 	� -   $��	All Tools��#��� 	 #��[ $! 	Pages_nav��$   /Pages/All_tools_page.xaml��  	All_Tools# �  	� -   $��	Reception��#��� 	 #��[ $! 	Pages_nav��$   /Pages/Reception_page.xaml��  	Reception# �  	� -   $��Output��#��� 	 #��[ $! 	Pages_nav��$  /Pages/Output_page.xaml�� 
 Output# �  	� -	   $��Repaired Tools��#��� 	 #��[ $! 	Pages_nav��$%  /Pages/Repaired_Tools_page.xaml��  Repaired_tools# �  	� -
   $��Faulty Tools��#��� 	 #��[ $! 	Pages_nav��$#  /Pages/Faulty_Tools_page.xaml��  Faulty_tools_Tools# �  �� 
�������$��0,0,0,3q����	#FFF8F8F9$	��Top=�._��� $��	0,20,0,20q�$ Vertical=�$	��Top=�.+�	� -   $��Purchase Order��#��� 	 #��[ $! 	Pages_nav��$%  /Pages/Purchase_order_page.xaml��  Purchase_order# �  	� -   $��Maintenance Plan��#��� 	 #��[ $! 	Pages_nav��$'  !/Pages/Maintenance_plan_page.xaml��  Maintenance_plan# �  �� 
�������$��0,0,0,3q����	#FFF8F8F9$	��Top=�._��� $��	0,20,0,20q�$ Vertical=�$	��Top=�.+�	� -   $��History��#��� 	 #��[ $! 	Pages_nav��$  /Pages/History_page.xaml��  History# �  	� -   $��Settings��#��� 	 #��[ $! 	Pages_nav��$  /Pages/Settings_page.xaml��  Settings# �  	� -   # 	�Name$# 
Logout_btn��#��� 	 $��Log Out�� 
 Logout# �  $��Bottom=�$��40��$��Bottom=�  Failed-red-Color#��[ �� $��1��$��0 3 3 3q�#��[ ._� � -   $  �Name$$ Main_container��%  � Source$ % /Pages/All_tools_page.xaml?�&  � NavigationUIVisibility$& Hidden=�