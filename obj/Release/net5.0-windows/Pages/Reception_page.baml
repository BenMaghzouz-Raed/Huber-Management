   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Huber_Management.PagesHuber_Management.Pages  E'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  +    %Huber_Management.Pages.Reception_page   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:Huber_Management.Pages     <controls'clr-namespace:Huber_Management.Controls     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     N� Title$  Reception_page��.���  � RowDefinitions �� $��57 ��� $��* �.+�� $��0,0,0,3q�
������� � ColumnDefinitions �� $��* ��� $��* ��� $
��auto �.+�� $��Stretch=� �� $��* ��� $
��auto �.+��� -    ��Name$ Nav_search_box��   searchTextBox#���   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search by ...�� �� TextWrapping$ NoWrap=�$��10 0 0 0q�$	��150��.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��$
��10 5q�   HasLeadingIcon$
 True��$��Stretch=�   LeadingIcon$ Search=�  Dark-main-Blue-Color	   UnderlineBrush#	 [ �� -   
 ��Name$
 search_filter��$��1��$��2 0 0 0q�$	��140��$��36��$
��10 0q�  Label-Gray-Color#��[   MaterialDesignDivider#���     TextFieldCornerRadius$ 0��$��Center=�$��Center=�$��Center=�  Screen-bg-Color#��[ $��Stretch=�$��14(�$��SemiBold"�.@��� $��Serial Number�� �� 
IsSelected$
 True���� $��Drawing���� $��Supplier���� $��Position���� $��1�� �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� $��When:��$��14(�$��Normal"�#��[ $��0 0 2 0q�$��Center=��� -   $
 when_combobox�� " MaterialDesignOutlinedComboBox#��[ 
������ #��[ #��[ $	��110��$��35��$
��10 0q�$��Center=�$��Center=�$��Center=�$��Stretch=�$��14(�$��SemiBold"�.@��� $��
This Month��$
 True���� $��
Last Month���� $��	This Year���� $��	Last Year���� $	��All���� $
��Who:��$��14(�$��Normal"�#��[ $��15 0 2 0q�$��Center=��� -   $
 by_who_combobox��#��[ 
������ #��[ #��[ $��80��$��35��$
��10 0q�$��Center=�$��Center=�$��Center=�$��Stretch=�$��14(�$��SemiBold"�.@��� $	��Any��$
 True���� -    ��Name$ Add_reception_tool��$��2��$
��15 0q�$��0,0,18,0q� � ToolTip$ Add a Reception��+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��$��Right=�  Success-green-Color#��[  " MaterialDesignFlatDarkBgButton#��[ +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�#��[ $��36��.���  �� $��25 ��� $
��auto �.+��� $��24��$��24��$��0��.+�F� 
������������@B  � рˤ  � ������� @`�� Ѡ� ��{ �@�� @]� Ѡ� �!������� @ �� рˤ ��� �@B ��� �@B  � �@o@�� ���- �� ��� ��  @,  	= �@B  � ���-  � ���- ��[ �@o@��[ �@o@ -1���-  -1���-  $� �@B  $� �@B  -1�@B ��A�� ��O��- ��O�@o@��O� 8Q��O��^��A��^ -1���^ 	= ���^ @,  8Q�� @o@�� 	�� $��	RECEPTION��$��1��$��Center=�$��10,0,0,0q�
�������� $��1��$��	10,10,0,0q� �� $
��auto ��� $��* �.+���   Table-Header-style#��[ #��[ ._��  �� $	��100 ��� $��50 ��� $��* ��� $	��120 ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�4   .Huber_Management.Controls.TableHeader_RadioBtn  -     Name$
 date��4   .Huber_Management.Controls.TableHeader_RadioBtn   MouseLeftButtonDown$! sort_by_MouseLeftButtonDown��$��0��
 � Tag$
 Date��
��������� $��1��$��#�� 	 Table-Header-label#��[	 
�������  -   $ 	serial_id��$! sort_by_MouseLeftButtonDown��$��2��$ 	Serial NB��
��������� $��3��$��Designation��#��[	 
�������  -	   $ quantity��$! sort_by_MouseLeftButtonDown��$��4��$ Quantity��
�������  -
   $ supplier��$! sort_by_MouseLeftButtonDown��$��5��$ Supplier��
�������  -   $ price��$! sort_by_MouseLeftButtonDown��$��6��$ Price (€)��
�������  -   $ total_price��$! sort_by_MouseLeftButtonDown��$��7��$ Total price (€)��
��������� $��8��$��By��#��[	 
��������� -    ��Name$ DataScrollViewer��$��Visible=�$��1��$y�	Collapsed=�.���� -    ��Name$ Reception_rows_panel��$ Vertical=� �� CanVerticallyScroll$
 True��.+��� -    ��Name$ noDataFound��$��NO DATA FOUND��$��Center=�$��0 30 0 0q�$��32(�$��DemiBold"��� -   $ LoadingIcon��$��Visible=�$��1��$y�Visible=�.���� $��Loading ...��$��Center=�$��30q�$��24(�$��DemiBold"�