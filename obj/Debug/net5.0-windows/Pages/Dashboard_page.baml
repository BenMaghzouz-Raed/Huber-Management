   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      K GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Huber_Management.PagesHuber_Management.Pages 5      E'clr-namespace:Huber_Management.ControlsHuber_Management.Controls 5      +   %Huber_Management.Pages.Dashboard_page   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      6local$clr-namespace:Huber_Management.Pages     5      <controls'clr-namespace:Huber_Management.Controls     5        N� Title$  Dashboard_page��5      .��5      � $��10 0 0 0q�6    � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��3* �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��1* �6#   .+�5      �  5      �� 5      $	��100 �6$   �� 5      $��* �6$   .+�5      �  5      �� 5       �� 5!      �� 5"      �� 5#      .+�5&      ��    Soft-bg-Blue-Color#��[  6   $��0 5 5 5q�6N    �� CornerRadius$ 8��6_    �� Padding$ 5q�6p   ._�5'      �  5(      �� 5)   "   $
��auto �60   �� 5*   "   $��* �60   .+�5,      �� $��Total Tools��6(   $��16(�6;   $��Center=�6I    �� TextAlignment$ Center=�6f   $��SemiBold"�6}     Dark-main-Blue-Color#��[ 6�   �� 5-      -   5         ��Name$ total_tools��5-   $   $��0��69   $��1��6E   $��Center=�6R   $��Center=�6m   $��36(�5.   $   $
��Bold"�62   5/      50      �� 51      $��1��6     Soft-orange-Color#��[ 6-   $��5q�6]   $ 8��6h   $ 5q�6y   ._�52      �  53      �� 54   "   $
��auto �60   �� 55   "   $��* �60   .+�57      �� $��Stock Current Value��6(   $��16(�6C   $
��Wrap=�6Q   $��Center=�6e   $ Center=�6�   $��SemiBold"�6�     Orange-Color#��[ 6�   �� 58      -   5         ��Name$ total_price��58   (   $��0 €��6=   $��1��6H   $��Center=�6U   $��Center=�6p   $��26(�59   $   $
��Bold"�62   $��CharacterEllipsis=�6D    J� Opacity$ .8Q�6e   5:      5;      �� 5<      $��2��6     Soft-red-Color#��[ 6-   $��5q�6Z   $ 8��6e   $ 5q�6v   ._�5=      �  5>      �� 5?   "   $
��auto �60   �� 5@   "   $��* �60   .+�5B      �� $��Faulty Tool��6(   $��16(�6;   $��Center=�6I   $��SemiBold"�6f     Failed-red-Color#��[ 6|   �� 5C      -   5        $ total_faulty��5C   $   $��0��6:   $��1��6F   $��Center=�6S   $��Center=�6n   $��36(�5D   $   $
��Bold"�62   5E      5F      �� 5G      $��3��6     Soft-green-Color#��[ 6-   $��5 5 0 5q�6\   $ 8��6m   $ 5q�6~   ._�5H      �  5I      �� 5J   "   $
��auto �60   �� 5K   "   $��* �60   .+�5M      �� $��Earnings��6(   $��Center=�68   $��16(�6U   $��SemiBold"�6c     Success-green-Color#��[ 6y   �� 5N      -   5        $ 
total_gain��5N   $   $��0 €��68   $��1��6F   $��Center=�6S   $��Center=�6n   $��32(�5O   $   $
��Bold"�62   #��[ 6D   5P      5Q      5R      � 5U      $��1��6    5V      �� 5W      $��1* �6+   �� 5X      $��1* �6+   .+�5[      -  'Huber_Management.Controls.MaterialCards  -   5        	  Name$	 
InputChart��5[   -   $��0 5 5 5q�6A     5]      -   5        $	 OutputChart��5]   -   $��1��6B   $�� 5 5 0 5q�6R   5^      5_      �� 5a      $��1��6   $ 5q�6%   
�������$ 10��6D   $��10 5 0 5q�6V   ._�5b      �� 
 �� Orientation$
 Vertical=�6   .+�5c      �� $��Today Tasks :��6   $
��Left=�64   $��DemiBold"�5d      $��18(�6.   �� 5f      $
��Auto=�6#   .��5g      �� -   5         ��Name$ Today_tasks_rows_panel��5g   %   $
 Vertical=�6E    �� CanVerticallyScroll$
 True��6\   $��Stretch=�6w   .+�5h      �� $'��!We Can't find any tasks for today��6$     Label-Gray-Color#��[ 6P   $��Center=�6   $��0 10 0 0q�6�   5i      5j      5k      5l      5m      � 5p   
   $��1��6    5q      �� 5r      �� 5s      .+�5v      �� $ 5q�6   
�������$ 10��64   $��0 5 5 5q�6F   ._�5w      �  5x      �� 5y      $
��auto �6(   �� 5z      $
��auto �6(   �� 5{      $��* �6(   .+�5~      �� $��Out of stock :��6   $
��Left=�65   $��0��6P   $��DemiBold"�5      $��18(�6.   $��0 0 0 10q�6<   �� 5�      -   5         ��Name$ Out_of_stock_Header��5�       	 Table-Header-style#��[	 6:   $��1��6f    
 Table-Header-bg-Color#��[
 5�      $��0 0 0 6q�6Q   $y�	Collapsed=�6b   ._�5�      �  5�      �� 5�   "   $	��100��63   �� 5�   "   �� 5�   "   �� 5�   "   �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��	Serial NB��68     Table-Header-textBlock#��[ 6I   �� 5�      $��1��6(   $��Actual stock��68   #��[ 6L   �� 5�      $��2��6(   $��	Stock min��68   #��[ 6I   �� 5�      $��3��6(   $��Needed quantity��68   #��[ 6O   �� 5�      $��4��6(   $��Total (N.Q)��68   #��[ 6K   �� 5�      $��5��6(   $��Supplier��68   #��[ 6H   5�      5�      �� 5�      $
��Auto=�6#   $��2��6F   .��5�      �� -	   5        $ Out_of_stock_rows_panel��5�   %   $
 Vertical=�6F   $
 True��6]   $��Stretch=�6x   .+�5�      �� $!��All the tools are available��6$   #��[ 6J   $��Center=�6y   $��0 10 0 0q�6�   5�      5�      5�      5�      �� 5�      $ 5q�6   
�������$ 10��64   $��5 5 0 5q�6F   $��1��6W   ._�5�      �� $
 Vertical=�6   $��0��64   .+�5�      �� $��Latest History :��6   $
��Left=�67   $��DemiBold"�5�      $��18(�6.   $��0 0 0 10q�6<   �� 5�      $
��Auto=�6#   .��5�      �� -
   5        $ latest_history_rows_panel��5�   %   $
 Vertical=�6H   $
 True��6_   $��Stretch=�6z   .+�5�      �� $!��We can't find any history !��6$   #��[ 6J   $��Center=�6y   $��0 10 0 0q�6�   5�      5�      5�      5�      5�      5�      5�      