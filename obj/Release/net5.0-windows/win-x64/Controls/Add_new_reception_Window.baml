   M S B A M L   `   `   `  ���� J  FHuber-Managment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Huber_Managment.ControlsHuber_Managment.Controls  7    1Huber_Managment.Controls.Add_new_reception_Window   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  2local&clr-namespace:Huber_Managment.Controls    � WindowStartupLocation$  CenterScreen=� � Title$ Add New Reception Window��$	��500��$	��400��.��� $��10q� � RowDefinitions �� $��1* ��� $��4* ��� $��4* �.+��  � ColumnDefinitions �� $��2* ��� $��60 ��� $��1* �.+��� -    ��Name$ search_for_tools_to_add��$
��Left=�$	��200��$��35��$��Search by serial ID...��   Screen-bg-Color#��[  $��5,4,4,4q�.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��$��0q�$��Segoe UI)� �� TextAlignment$
 Left=�  Label-Gray-Color#��[ $��Stretch=�$��16(�$��Center=��� $
��-OR-��$��1��$��Center=�$��Right=�$��14(�$��DemiBold"��� -    ��Name$ Add_new_tool��$��2��$
��10 0q�$��Right=�$��Right=�  Dark-main-Blue-Color#��[ #��[ .���  �� $��25 ��� $
��auto �.+��� $��25��$��25��$��0��.+�F� 
������������@f@]� �@]� @]� �@]� @f��ا @f��ا @]� ���j @]� ���j �ا ��ا �ا ��ا ��j �@]� ��j �@]� �ا �@f�ا � � �� ׀�  �  ��� ��� � � ��O ��� ��� ׀�O �  ��� ��� � � ��  ��� ��� 	�� $	��New��$��1��$��Center=�$��10,0,0,0q�
��������� $
��Auto=�$
��Auto=�$��1��.��&   System.Windows.Controls.DataGrid  -     Name$ searched_Tools��$��Stretch=�$��Stretch=�	   	RowHeight$	 40Q�
   
IsReadOnly$

 True��   AutoGenerateColumns$ False��   CanUserResizeColumns$ False��   SelectionMode$ Single=�$��Center=�  MaterialDesignDataGrid#��[    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Image��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 40   $ 	Serial NB��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	Serial_id+  $ Designation��   MaxWidth$	 120Q� �� *Designation+  $ Division�� �� *
Division+  $ Position�� �� *
Position+  $ 	Stock min�� �� *
Stock_mini+  $ Actual Stock�� �� *Actual_stock+   RowDetailsTemplate �� .R�]� 
�������.+�� $
��0,10q� �� $
��Auto ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $
��ID: ��$
��Bold"��� $��my id��$��1���� $��Name: ��$
��Bold"�$��1���� $��this is a name��$��1��$��1���� $��
Birthday: ��$
��Bold"�$��2���� $��hello��$��1��$��2��