   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Huber_Management.PagesHuber_Management.Pages  E'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  0    *Huber_Management.Pages.Purchase_order_page   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:Huber_Management.Pages     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6controls'clr-namespace:Huber_Management.Controls  -     N� Title$  Purchase_order_page��.���  � RowDefinitions �� $��57 ��� $��8* �.+�� $��0,0,0,3q�
������� � ColumnDefinitions �� $��4* ��� $��2* ��� $
��auto �.+�� $��Stretch=� �� $��* ��� $
��auto �.+��� -    ��Name$ Nav_search_box��   searchTextBox#���   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search by ...�� �� TextWrapping$ NoWrap=�$��10 0 0 0q�$	��150��.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��$
��10 5q�   HasLeadingIcon$
 True��$��Stretch=�   LeadingIcon$ Search=�  Dark-main-Blue-Color	   UnderlineBrush#	 [ �� -   
 ��Name$
 search_filter��$��1��$��2 0 0 0q�.  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryLight=�$	��140��$��36��$
��10 0q�  Label-Gray-Color#��[   MaterialDesignDivider#���     TextFieldCornerRadius$ 0��$��Center=�$��Center=�$��Center=�  Screen-bg-Color#��[ $��Stretch=�$��14(�$��SemiBold"�.@��� $��Serial Number�� �� 
IsSelected$
 True���� $��Drawing���� $��Supplier���� $��Position���� $��1��$y�	Collapsed=� �� Orientation$ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��Filter:��$��16(�$��DemiBold"�#��[ $��0 0 5 0q�$��Center=��� -   $
 filter_combobox��  MaterialDesignComboBox#��[ #��[ $ PrimaryDark=�$	��110��$��35��$
��10 0q�$��Center=�$��Center=�$��Center=�$��Stretch=�$��14(�$��SemiBold"�.@��� $��	All Tools��$
 True���� $��Faulty Tools���� $��Out of Stock���� $��Inused��(� -   $��22��$��22�� � Cursor$
 Hand��$��15,0,0,0q� � ToolTip$ Reload the page��.���� $��24��$��24��.+�F� #��[ ����� � �� ׀�O � ��� ��� � � ��  ��� ��� ����ا �@]� �ا ѐ�� p:� � �  z  �< �< � � @]�  	=  	= ��H@]� � � ��[ ���[ ��[ ����Q80@��v ��-Z �-Z р���[ 	�� -    ��Name$ Purchase��$��2��$
��15 0q�$��0,0,18,0q�$ Export To Word File��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��$��Right=� " MaterialDesignFlatDarkBgButton#��[ +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�$��36��.���  �� $��25 ��� $
��auto �.+��� $��24��$��24��$��0��.+�F� 
�������  Purchase_order#���  �� $��Purchase��$��1��$��Center=�$��10,0,0,0q�
�������� $��1��$��	10,10,0,0q� �� $
��auto ��� $��* �.+���   Table-Header-style#��[  	 Table-Header-bg-Color#��[	 ._��  �� $��50 ��� �� �� �� �� �� �� �� $��35 �.+��� $��#�� 
 Table-Header-label#��[
 4   .Huber_Management.Controls.TableHeader_RadioBtn  -     Name$ 	serial_id��4   .Huber_Management.Controls.TableHeader_RadioBtn   MouseLeftButtonDown$! sort_by_MouseLeftButtonDown��$��1��
 � Tag$ 	Serial ID��  -   $ actual_stock��$! sort_by_MouseLeftButtonDown��$��2��$ Actual stock��  -	   $ 	min_stock��$! sort_by_MouseLeftButtonDown��$��3��$ 	Stock min��  -
   $ needed_quantity��$! sort_by_MouseLeftButtonDown��$��4��$ Needed quantity��  -   $ total_nq��$! sort_by_MouseLeftButtonDown��$��5��$ Total (N.Q)��  -   $ supplier��$! sort_by_MouseLeftButtonDown��$��6��$ Supplier��  -   $ criticality��$! sort_by_MouseLeftButtonDown��$��7��$ Criticality���� -    ��Name$ 
select_all��$
 Hand��$��Center=�$��8���� -    ��Name$ DataScrollViewer��$��Visible=�$��1��$y�	Collapsed=�.���� -    ��Name$ All_tools_rows_panel��$ Vertical=� �� CanVerticallyScroll$
 True��.+��� -    ��Name$ noDataFound��$��NO DATA FOUND��$��Center=�$��0 30 0 0q�$��32(�$��DemiBold"��� -   $ LoadingIcon��$��Visible=�$��1��$y�Visible=�$��Center=�.���� $��Loading ...��$��Center=�$��32(�$��DemiBold"�