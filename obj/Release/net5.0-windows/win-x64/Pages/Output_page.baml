   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Huber_Management.PagesHuber_Management.Pages  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf (    "Huber_Management.Pages.Output_page   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:Huber_Management.Pages     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  -     N� Title$  Output_page��.���  � RowDefinitions �� $��57 ��� $��5* ��� $��3* �.+�� $��0,0,0,3q�
������� � ColumnDefinitions �� $��3* ��� $��4* ��� $��1* �.+��� -    ��Name$ Nav_search_box��$��Stretch=�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search by id ...�� �� TextWrapping$ NoWrap=�$��Center=�$
��10,0q�$��36��$��16(�$	��150��.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��$��0q�$��Segoe UI)� �� TextAlignment$
 Left=�   Label-Gray-Color#��[    Screen-bg-Color#��[ $
��10 5q�$��Center=�   HasLeadingIcon$
 True��$��Stretch=�	   LeadingIcon$	 Search=�  Dark-main-Blue-Color
   UnderlineBrush#
 [ �� $��1�� �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� $��Filter:��$��16(�$��DemiBold"�#��[  $��0 0 5 0q�$��Center=��� -    ��Name$ filter_combobox��  MaterialDesignComboBox#��[ #��[ .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryDark=�$	��110��$��35��$
��10 0q�$��Center=�$��Center=�$��Center=�$��Stretch=�$��14(�$��SemiBold"�.@��� $��	All Tools�� �� 
IsSelected$
 True���� $��Faulty Tools���� $��Out of Stock���� $��Inused���� $��Sort by:��$��16(�$��DemiBold"�#��[  $��20,0,5,0q�$��Center=��� -   $ sort_by_combobox��#��[ #��[ $ PrimaryDark=�$	��110��$��35��$��Center=�$��Center=�$��Center=�$
��10 0q�$��Stretch=�$��14(�$��SemiBold"�.@��� $
��Date��$
 True���� $	��A-Z���� $��Quantity��d� -    d�Name$ isDESC�� d� 	IsChecked$ FalseY� � ToolTip$ DESC/ASC��$��22��$��Center=�#��[  � Cursor$
 Hand�� % !MaterialDesignVerticalHeaderStyle#��[ $��15,0,0,0q��� -   $��22��$��22��$
 Hand��$��15,0,0,0q�$ Reload the page��._��� $��24��$��24��.+�F� #��[  ����� � �� ׀�O � ��� ��� � � ��  ��� ��� ����ا �@]� �ا ѐ�� p:� � �  z  �< �< � � @]�  	=  	= ��H@]� � � ��[ ���[ ��[ ����Q80@��v ��-Z �-Z р���[ 	�� -    ��Name$ Add_output_tool��$��2��$
��15 0q�$��0,0,18,0q�$ Add an Output��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��$��Right=�  Failed-red-Color#��[  " MaterialDesignFlatDarkBgButton#��[ +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�#��[ $��36��.���  �� $��25 ��� $
��auto �.+��� $��24��$��24��$��0��.+�F� 
������������@T�  � р� � ��� `�� Ѡ��{ �@�X@]� Ѡ�!���  �� р���� �@T� ��� �@T�  � �@o@��	�@o@ -1���-  -1���- ��[ �@o@��[ �@o@�9� ���^@�� ���^ 	= ���^ @,  8Q�� @o@�� ���- �� ��� ��  @,  	= �@B  -1�@B ��A�� ��O��- ��O�@o@��O� 8Q��O��^��A��^ -1���^@�� �@o@��		�� $	��NEW��$��1��$��Center=�$��10,0,0,0q�
�������� $��1��$��	10,10,0,0q� �� $
��auto ��� $��* �.+���   Table-Header-style#��[ #��[ ._��  �� $	��100 ��� $��50 ��� $��* ��� $	��120 ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$
��Date��  Table-Header-label#��[ 
��������� $��1��$��#��#��[ 
��������� $��2��$��	Serial NB��#��[ 
��������� $��3��$��Designation��#��[ 
��������� $��4��$��Quantity��#��[ 
��������� $��5��$��	Requester��#��[ 
��������� $��6��$��Price (€)��#��[ 
��������� $��7��$��Total price (€)��#��[ 
��������� $��8��$��By��#��[ 
��������� -    ��Name$ DataScrollViewer��$��Visible=�$��1��$y�	Collapsed=�.���� -	    ��Name$ Output_rows_panel��$ Vertical=� �� CanVerticallyScroll$
 True���� -
   $ LoadingIcon��$��Visible=�$��1��$y�Visible=�.���� $��Loading ...��$��Center=�$��30q�$��24(�$��DemiBold"��� $��2��$��	10 10 0 0q�._�#  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 Left=�   Series �� *SeriesCollection+   AxisX   LiveCharts.Wpf.Axis     Title$ Salesman��   Labels �� *Labels+   AxisY   $ 	Sold Apps��   LabelFormatter �� *	Formatter+