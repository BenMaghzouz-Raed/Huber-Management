   M S B A M L   `   `   `  ���� U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  K GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Huber_Management.PagesHuber_Management.Pages E'clr-namespace:Huber_Management.ControlsHuber_Management.Controls +   %Huber_Management.Pages.Dashboard_page   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     6local$clr-namespace:Huber_Management.Pages     <controls'clr-namespace:Huber_Management.Controls       N� Title$  Dashboard_page��.��� $��10 0 0 0q� � RowDefinitions �� $��4* ��� $��3* �.+��  � ColumnDefinitions �� $��2* ��� $��1* �.+��  �� $	��100 ��� $��* �.+��  �� �� �� �� .+���    Soft-bg-Blue-Color#��[  $��0 5 5 5q� �� CornerRadius$ 8�� �� Padding$ 5q�._��  �� $
��auto ��� $��* �.+��� $��Total Tools��$��16(�$��Center=� �� TextAlignment$ Center=�$��SemiBold"�  Dark-main-Blue-Color#��[ �� -    ��Name$ total_tools��$��0��$��1��$��Center=�$��Center=�$��36(�$
��Bold"��� $��1��  Soft-orange-Color#��[ $��5q�$ 8��$ 5q�._��  �� $
��auto ��� $��* �.+��� $��Stock Current Value��$��16(�$
��Wrap=�$��Center=�$ Center=�$��SemiBold"�  Orange-Color#��[ �� -    ��Name$ total_price��$��0 €��$��1��$��Center=�$��Center=�$��26(�$
��Bold"�$��CharacterEllipsis=� J� Opacity$ .8Q��� $��2��  Soft-red-Color#��[ $��5q�$ 8��$ 5q�._��  �� $
��auto ��� $��* �.+��� $��Faulty Tool��$��16(�$��Center=�$��SemiBold"�  Failed-red-Color#��[ �� -   $ total_faulty��$��0��$��1��$��Center=�$��Center=�$��36(�$
��Bold"��� $��3��  Soft-green-Color#��[ $��5 5 0 5q�$ 8��$ 5q�._��  �� $
��auto ��� $��* �.+��� $��Earnings��$��Center=�$��16(�$��SemiBold"�  Success-green-Color#��[ �� -   $ 
total_gain��$��0 €��$��1��$��Center=�$��Center=�$��32(�$
��Bold"�#��[ � $��1�� �� $��1* ��� $��1* �.+�-  'Huber_Management.Controls.MaterialCards  -   	  Name$	 
InputChart��$��0 5 5 5q�  -   $	 OutputChart��$��1��$�� 5 5 0 5q��� $��1��$ 5q�
�������$ 10��$��10 5 0 5q�._��� 
 �� Orientation$
 Vertical=�.+��� $��Today Tasks :��$
��Left=�$��DemiBold"�$��18(��� $
��Auto=�.���� -    ��Name$ Today_tasks_rows_panel��$
 Vertical=� �� CanVerticallyScroll$
 True��$��Stretch=�.+��� $'��!We Can't find any tasks for today��  Label-Gray-Color#��[ $��Center=�$��0 10 0 0q�� $��1�� �� �� .+��� $ 5q�
�������$ 10��$��0 5 5 5q�._��  �� $
��auto ��� $
��auto ��� $��* �.+��� $��Out of stock :��$
��Left=�$��0��$��DemiBold"�$��18(�$��0 0 0 10q��� -    ��Name$ Out_of_stock_Header�� 	 Table-Header-style#��[	 $��1�� 
 Table-Header-bg-Color#��[
 $��0 0 0 6q�$y�	Collapsed=�._��  �� $	��100���� �� �� �� �� .+��� $��0��$��	Serial NB��  Table-Header-textBlock#��[ �� $��1��$��Actual stock��#��[ �� $��2��$��	Stock min��#��[ �� $��3��$��Needed quantity��#��[ �� $��4��$��Total (N.Q)��#��[ �� $��5��$��Supplier��#��[ �� $
��Auto=�$��2��.���� -	   $ Out_of_stock_rows_panel��$
 Vertical=�$
 True��$��Stretch=�.+��� $!��All the tools are available��#��[ $��Center=�$��0 10 0 0q��� $ 5q�
�������$ 10��$��5 5 0 5q�$��1��._��� $
 Vertical=�$��0��.+��� $��Latest History :��$
��Left=�$��DemiBold"�$��18(�$��0 0 0 10q��� $
��Auto=�.���� -
   $ latest_history_rows_panel��$
 Vertical=�$
 True��$��Stretch=�.+��� $!��We can't find any history !��#��[ $��Center=�$��0 10 0 0q�