   M S B A M L   `   `   `  ����K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Huber_Management.PagesHuber_Management.Pages  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      (    "Huber_Management.Pages.Output_page   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Huber_Management.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5      -   5          N� Title$  Output_page��5      .��5      �  � RowDefinitions 5   
   �� 5      $��57 �6   �� 5      $��5* �6   �� 5      $��3* �6   .+�5   
   � $��0,0,0,3q�6   
������� � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $��4* �6#   �� 5      $��1* �6#   .+�5      �� -   5         ��Name$ Nav_search_box��5      $��Stretch=�6.   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search by id ...��6L    �� TextWrapping$ NoWrap=�6   $��Center=�5      $
��10,0q�65   $��36��6C   $��16(�6O   $	��150��6]   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��6l   $��0q�5       $��Segoe UI)�6.    �� TextAlignment$
 Left=�6D      Label-Gray-Color#��[  6Y     Screen-bg-Color#��[ 5!      $
��10 5q�6H   $��Center=�6W      HasLeadingIcon$
 True��6y   $��Stretch=�5"      	   LeadingIcon$	 Search=�6@     Dark-main-Blue-Color
   UnderlineBrush#
 [ 6t   �� 5%      $��1��6    �� Orientation$ 
Horizontal=�6)   $��Center=�6B   $��Center=�6]   .+�5'      �� $��Filter:��6   $��16(�6*   $��DemiBold"�68   #��[  6N   $��0 0 5 0q�6}   $��Center=�6�   �� 5(      -   5         ��Name$ filter_combobox��5(        MaterialDesignComboBox#��[ 64   #��[ 6d   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryDark=�5)      $	��110��6G   $��35��6V   $
��10 0q�6b   $��Center=�5*      $��Center=�6=   $��Center=�6a   $��Stretch=�5+      $��14(�69   $��SemiBold"�6G   .@�5-      �� $��	All Tools��6#    �� 
IsSelected$
 True��67   �� 5.      $��Faulty Tools��6#   �� 5/      $��Out of Stock��6#   �� 50      $��Inused��6#   51      �� 54      $��Sort by:��6   $��16(�6+   $��DemiBold"�69   #��[  6O   $��20,0,5,0q�6~   $��Center=�6�   �� 55      -   5        $ sort_by_combobox��55      #��[ 65   #��[ 6e   $ PrimaryDark=�56      $	��110��6G   $��35��6V   $��Center=�6b   $��Center=�57      $��Center=�6?   $
��10 0q�6Z   $��Stretch=�58      $��14(�69   $��SemiBold"�6G   .@�5:      �� $
��Date��6#   $
 True��62   �� 5;      $	��A-Z��6#   �� 5<      $��Quantity��6#   5=      d� 5>      -   5         d�Name$ isDESC��5>       d� 	IsChecked$ FalseY�6Q    � ToolTip$ DESC/ASC��6c   $��22��5?      $��Center=�6+   #��[ 6M    � Cursor$
 Hand��6�    % !MaterialDesignVerticalHeaderStyle#��[ 5@      $��15,0,0,0q�6Z   �� 5A      -   5        $��22��5A      $��22��6$   $
 Hand��6N   $��15,0,0,0q�6\   $ Reload the page��6n   ._�5B      �� $��24��6   $��24��6(   .+�5C      F� #��[  6   ����� � �� ׀�O � ��� ��� � � ��  ��� ��� ����ا �@]� �ا ѐ�� p:� � �  z  �< �< � � @]�  	=  	= ��H@]� � � ��[ ���[ ��[ ����Q80@��v ��-Z �-Z р���[ 	6H   5D      5E      5F      �� 5I      -   5         ��Name$ Add_output_tool��5I      $��2��6.   $
��15 0q�6>   $��0,0,18,0q�6M   $ Add an Output��6_   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��6w   $��Right=�5J        Failed-red-Color#��[ 61    " MaterialDesignFlatDarkBgButton#��[ 6`   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�6�   #��[ 5K      $��36��6c   .��5L      �  5M      �� 5N      $��25 �6+   �� 5O      $
��auto �6+   .+�5R      �� $��24��6   $��24��6(   $��0��64   .+�5S      F� 
������������@T�  � р� � ��� `�� Ѡ��{ �@�X@]� Ѡ�!���  �� р���� �@T� ��� �@T�  � �@o@��	�@o@ -1���-  -1���- ��[ �@o@��[ �@o@�9� ���^@�� ���^ 	= ���^ @,  8Q�� @o@�� ���- �� ��� ��  @,  	= �@B  -1�@B ��A�� ��O��- ��O�@o@��O� 8Q��O��^��A��^ -1���^@�� �@o@��		6,   5T      �� 5U      $	��NEW��6    $��1��6+   $��Center=�6;   $��10,0,0,0q�6V   
�������6h   5V      5W      5Y      � 5]   
   $��1��6   $��	10,10,0,0q�6    5^      �� 5_      $
��auto �6    �� 5`      $��* �6    .+�5c      ��   Table-Header-style#��[ 6   #��[ 6A   ._�5d      �  5e      �� 5f      $	��100 �6+   �� 5g      $��50 �6+   �� 5h      $��* �6+   �� 5i      $	��120 �6+   �� 5j      $��* �6+   �� 5k      $��* �6+   �� 5l      $��* �6+   �� 5m      $��* �6+   �� 5n      $��* �6+   .+�5q      �� $��0��6   $
��Date��6,     Table-Header-label#��[ 6;   
�������6g   �� 5r      $��1��6   $��#��6,   #��[ 68   
�������6d   �� 5s      $��2��6   $��	Serial NB��6,   #��[ 6@   
�������6l   �� 5t      $��3��6   $��Designation��6,   #��[ 6B   
�������6n   �� 5u      $��4��6   $��Quantity��6,   #��[ 6?   
�������6k   �� 5v      $��5��6   $��	Requester��6,   #��[ 6@   
�������6l   �� 5w      $��6��6   $��Price (€)��6,   #��[ 6@   
�������6l   �� 5x      $��7��6   $��Total price (€)��6,   #��[ 6F   
�������6r   �� 5y      $��8��6   $��By��6,   #��[ 69   
�������6e   5{      5|      �� 5      -   5         ��Name$ DataScrollViewer��5      $��Visible=�65   $��1��6[   $y�	Collapsed=�6h   .��5�      �� -	   5         ��Name$ Output_rows_panel��5�      $ Vertical=�68    �� CanVerticallyScroll$
 True��6O   5�      �� 5�      -
   5        $ LoadingIcon��5�      $��Visible=�60   $��1��6V   $y�Visible=�6c   .��5�      �� $��Loading ...��6   $��Center=�6/   $��30q�6L   $��24(�6X   $��DemiBold"�6f   5�      5�      �� 5�   
   $��2��6   $��	10 10 0 0q�6   ._�5�      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 Left=�6E      Series 6!   �� *SeriesCollection+   AxisX 5�        LiveCharts.Wpf.Axis     Title$ Salesman��6      Labels 60   �� *Labels+6L      AxisY 5�        $ 	Sold Apps��6      LabelFormatter 61   �� *	Formatter+6X   5�      5�      5�      5�      