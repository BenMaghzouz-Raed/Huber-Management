   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Huber_Management.PagesHuber_Management.Pages  E'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  +    %Huber_Management.Pages.All_tools_page   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:Huber_Management.Pages     <controls'clr-namespace:Huber_Management.Controls     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -      Screen-bg-Color  N� 
Background#  [   N� Title$ All Tools page��.���  � RowDefinitions �� $��57 ��� $��8* �.+�� $��0,0,0,3q�
������� � ColumnDefinitions �� $��4* ��� $��3* ��� $
��auto �.+�� $��Stretch=� �� $��* ��� $
��auto �.+��� -    ��Name$ Nav_search_box��  searchTextBox#���  )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search by ...�� �� TextWrapping$ NoWrap=�$��10 0 0 0q�$	��150��.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��$
��10 5q�   HasLeadingIcon$
 True��$��Stretch=�	   LeadingIcon$	 Search=�  Dark-main-Blue-Color
   UnderlineBrush#
 [ �� -    ��Name$ search_filter��$��1��$��Stretch=�$��14(�$��SemiBold"�.  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ 
PrimaryMid=�$	��140��$��36��$
��10 0q�
�������  MaterialDesignDivider#���     TextFieldCornerRadius$ 0��$��Center=�$��Center=�$��Center=�  Label-Gray-Color#��[ .@��� $��Serial Number�� �� 
IsSelected$
 True���� $��Drawing���� $��Project���� $��Position���� $��Process���� $��Division���� $��Supplier���� $��Supplier Code���� $��1�� �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� $
��Top:��$��14(�$��Normal"�#��[ $��Center=��� -   $ top_combobox�� " MaterialDesignOutlinedComboBox#��[ 
������ #��[ #��[ $��65��$��35��$
��10 0q�$��Center=�$��Center=�$��Center=�$��Stretch=�$��14(�$��SemiBold"�.@��� $��15��$
 True���� $��30���� $��50���� $	��100���� $	��200���� $	��All���� $��Filters:��$��14(�$��20 0 0 0q�$��Normal"�#��[ $��Center=��� -   $ filter_combobox��#��[ 
������ #��[ #��[ $	��110��$��35��$
��10 0q�$��Center=�$��Center=�$��Center=�$��Stretch=�$��14(�$��SemiBold"�.@��� $	��All��$
 True���� $��Mismatched data���� -    ��Name$ Add_tool_to_db��$��2��$
��10 0q�$��0,0,18,0q� � ToolTip$ Add new tool to database��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��$��Right=� " MaterialDesignFlatDarkBgButton#��[ +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�$��36��.���  �� $��25 ��� $
��auto �.+��� $��24��$��24��$��0��.+�F� 
�����������Ѐ���� � -1��� � -1@f���^@f���^��!� -1��!� -1��Oр���Oр���!���� ��!���� @fр�@fр���� � � ��- ��Q��k0@��-  -1�I  -1��j � -1��� �Q��k0@�ا  � �ا �`�s �ا  	= ���  	= ��j � 	= �I `�s ��-  � ��- � 	= @T� � 	= � `�s @]�  � @]� ��Q��k0@@]�  -1�  -1@T� � -1@T� � -1�S� ���! � Ӑe�  � ��� @!� ��� �9� � �  $� �`�s  $�  	= ���  	=  � � 	= @T� � 	= ��� � 	= PX� `�s �� � ���@]� ���@]� �"�{� @�1��� ��>� � @o@�`�s @o@ 	= % 	= @f� 	= ��� 	�� $��NEW TOOL��$��1��$��Center=�$��10,0,0,0q�
�������� $��1��$��	10,10,0,0q� �� $
��auto ��� $��* �.+���   Table-Header-style#��[   Table-Header-bg-Color#��[ ._��  �� $��50 ��� �� $	��150���� �� �� �� �� $��70���� $��70���� �� $��24 �.+��� $��#�� 	 Table-Header-label#��[	 4   .Huber_Management.Controls.TableHeader_RadioBtn  -     Name$ 	serial_id��4   .Huber_Management.Controls.TableHeader_RadioBtn   MouseLeftButtonDown$! sort_by_MouseLeftButtonDown��$��1��
 � Tag$ 	Serial ID���� $��2��$��Designation��#��[	   -   $ project��$! sort_by_MouseLeftButtonDown��$��3��$ Project��  -	   $ process��$! sort_by_MouseLeftButtonDown��$��4��$ Process��  -
   $ division��$! sort_by_MouseLeftButtonDown��$��5��$ Division��  -   $ position��$! sort_by_MouseLeftButtonDown��$��6��$ Position��  -   $ 	min_stock��$! sort_by_MouseLeftButtonDown��$��7��$	 Min��  -   $ actual_stock��$! sort_by_MouseLeftButtonDown��$��8��$ Actual���� $��9��$��Supplier��#��[	 �� -    ��Name$ DataScrollViewer��$��Visible=�$��1��$y�	Collapsed=�.���� -    ��Name$ All_tools_rows_panel��$ Vertical=� �� CanVerticallyScroll$
 True��.+��� -    ��Name$ noDataFound��$��NO DATA FOUND��$��Center=�$��0 30 0 0q�$��32(�$��DemiBold"��� -   $ LoadingIcon��$��Visible=�$��1��$y�Visible=�$��Center=�.���� $��Loading ...��$��Center=�$��32(�$��DemiBold"�