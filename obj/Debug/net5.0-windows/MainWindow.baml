   M S B A M L   `   `   `  ����K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Huber_ManagementHuber_Management  5   	   E'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  5   	   !    Huber_Management.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Huber_Management     5   	   ;control'clr-namespace:Huber_Management.Controls     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ Managment APP��5   	   $	��700��6   $
��1300��6,    � 
ResizeMode$ 	CanResize=�69    � WindowStartupLocation$ CenterScreen=�6P    � WindowState$ Normal=�6u   $
��1000��5   	   $	��700��6     Screen-bg-Color#��[ 5   	     Huber_small_icon � Icon# [ 5   	    � 	Resources 5        side_bar_button �� 
TargetType	 �� Property
 �� Value  Grey-Blue-Color �� 
TargetType ��Name � ColumnDefinitions
 � Tag �� Triggers P� Property P� Value  Soft-bg-Blue-Color �� 
TargetName  Dark-main-Blue-Color��%�  &	       7  7  7  7  7  �� 5   
   " 	�6(   .�5      �� 	 � ��

 �����6+   �� 5      	 � ��$
 0q�60   �� 5      	 � ��$
 40��6'   �� 5      	 � ��$
 18(�6)   �� 5      	 � ��$
 DemiBold"�6+   �� 5      	 � ��8
   6+   �� 5      	 � ��
 5      �� 5       " 	�6&   .R�5!      �� $ Border��6!   #��z��61   ._�5"      �  5#   "   �� 5$   &   $��55 �67   �� 5%   &   $��* �67   .+�5)   "   �� #��z 6(   $��24��6G   $��24��6R   �� 5,   "   $��1��6,   $
��Left=�6<   $��Center=�6W   #��z��5-   )   $��NoWrap=�6J   $��CharacterEllipsis=�6`   5/      50       51      P� 52       �@J�IsMouseOver$
 True��6=   . �53   "   �� 8
  $ Border��6k   	 � ���� 54   "   8
  	 � ��6?   55      P� 56       �@d�	IsChecked$
 TrueY�6;   . �57   "   �� 8
  $ Border��6k   	 � ���� 58   "   8
  	 � ��6?   59      5;      5=      5>      5A      .��5D      �  5E   
   �� 5F      $
��auto �6   �� 5G      $��5* �6   .+�5J   
   � -   5         �Name$ gridMenu��5J      $��0��6    � RowDefinitions 5K      �� 5L      $��60 �6    �� 5M      $��* �6    .+�5T      d� -   5         d�Name$ 	logo_menu��5T        logoMenuStyle#���  6.    � Triggers 5U      :� 5V       :� RoutedEvent$ ToggleButton.Unchecked��6#   .[�5W      �� .��5X      �� -   5         ��Name$ 	hidePanel��5X   )   .��5Y   "   W�  �� 
TargetName$ gridMenu��62    �� TargetProperty$ Width�6S    g� 	BeginTime	 0:0:06u    W� From 606�   	 W� To 2206�    g� Duration$ 0:0:0.3D�6�   5Z      5[      5\      :� 5]      $ ToggleButton.Checked��6#   .[�5^      �� .��5_      �� -   5        $ 	showPanel��5_   )   .��5`   "   W� $ gridMenu��62   $ Width�6S   	 0:0:06u    2206�    606�   $ 0:0:0.3D�6�   5b      5c      5d      5f      �� 5h      
�������$��0,0,3,3q�6(   ���	#FFF8F8F9$��Stretch=�5i      $��1��61   ._�5j      ]� $��Stretch=�6   $��Stretch=�6:   .+�5l      �� 
�������$��0,0,0,3q�60   ���	#FFF8F8F9$	��Top=�6b   ._�5m      �� $��	0,20,0,20q�6%    �� Orientation$ Vertical=�68   .+�5o      	� -   5        $��	Dashboard��5o   *    	 sidebarCheckbox#��� 	 6>   
  J� Uid$   /Pages/Dashboard_page.xaml��6h   #��[ 6�   ! 	� 	GroupName$! 	Pages_nav��5p   F   " d� 	IsChecked$
" TrueY�6\    
 	Dashboard# � 
 6m   	� 5r      -   5        $��	All Tools��5r   *   #��� 	 6>   #��[ 6h   $! 	Pages_nav��6�   $   /Pages/All_tools_page.xaml��5s   7     	All_Tools# �  6y   	� 5u      -   5        $��	Reception��5u   *   #��� 	 6>   #��[ 6h   $! 	Pages_nav��6�   $   /Pages/Reception_page.xaml��5v   7     	Reception# �  6y   	� 5x      -   5        $��Output��5x   *   #��� 	 6;   #��[ 6e   $! 	Pages_nav��6�   $  /Pages/Output_page.xaml��5y   7    
 Output# �  6v   	� 5{      -	   5        $��Repaired Tools��5{   *   #��� 	 6C   #��[ 6m   $! 	Pages_nav��6�   $%  /Pages/Repaired_Tools_page.xaml��5|   7     Repaired_tools# �  6~   	� 5~      -
   5        $��Faulty Tools��5~   *   #��� 	 6A   #��[ 6k   $! 	Pages_nav��6�   $#  /Pages/Faulty_Tools_page.xaml��5   7     Faulty_tools_Tools# �  6|   5�      5�      �� 5�      
�������$��0,0,0,3q�60   ���	#FFF8F8F9$	��Top=�6b   ._�5�      �� $��	0,20,0,20q�6%   $ Vertical=�68   $	��Top=�6O   .+�5�      	� -   5        $��Purchase Order��5�   *   #��� 	 6C   #��[ 6n   $! 	Pages_nav��6�   $%  /Pages/Purchase_order_page.xaml��5�   7     Purchase_order# �  6~   	� 5�      -   5        $��Maintenance Plan��5�   *   #��� 	 6E   #��[ 6p   $! 	Pages_nav��6�   $'  !/Pages/Maintenance_plan_page.xaml��5�   7     Maintenance_plan# �  6�   5�      5�      �� 5�      
�������$��0,0,0,3q�60   ���	#FFF8F8F9$	��Top=�6b   ._�5�      �� $��	0,20,0,20q�6%   $ Vertical=�68   $	��Top=�6O   .+�5�      	� -   5        $��History��5�   *   #��� 	 6<   #��[ 6g   $! 	Pages_nav��6�   $  /Pages/History_page.xaml��5�   7     History# �  6w   	� 5�      -   5        $��Settings��5�   *   #��� 	 6=   #��[ 6h   $! 	Pages_nav��6�   $  /Pages/Settings_page.xaml��5�   7     Settings# �  6x   5�      5�      	� 5�      -   5        # 	�Name$# 
Logout_btn��5�   "   #��� 	 66   $��Log Out��6`    
 Logout# �  6r   $��Bottom=�5�   "   $��40��6:   $��Bottom=�6F     Failed-red-Color#��[ 6~   5�      5�      5�      �� 5�   
   $��1��6   $��0 3 3 3q�6!   #��[ 6;   ._�5�       � -   5        $  �Name$$ Main_container��5�      %  � Source$ % /Pages/All_tools_page.xaml?�6,   &  � NavigationUIVisibility$& Hidden=�6P   5�      5�      5�      