   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  5    /Huber_Management.Controls.Add_new_output_Window   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:Huber_Management.Controls     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  New Checkout��$	��400��$	��500��   MaterialDesignPaper#���    � 
ResizeMode$ NoResize=� � Topmost$
 True��  Huber_small_icon � Icon# [  � WindowStartupLocation$ CenterScreen=�.��� $��10q� � RowDefinitions �� $��* ��� $
��auto �.+� � -     �Name$ Add_reception_container��  � Source$/ )/Controls//Windows_Pages/search_page.xaml?�  � NavigationUIVisibility$ Hidden=�� $��2��	 � ColumnDefinitions	 �� �� .+��� -   $��
Cancel_btn��$��0��$��Cancel��+  %MaterialDesignThemes.Wpf.ShadowAssist
   ShadowDepth$
 Depth0=�$
��Left=�$
��15 0q�$��25��  Label-Gray-Color#���    MaterialDesignFlatButton#��[ �� -    ��Name$ 
return_btn��$��0��$
��10 0q�+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��$y�	Collapsed=�$
��Left=�#��[ $
 Depth0=�.��� 	 �� $��25 ��� $
��auto �.+��� $��25��$��25��$��0��.+�F�   Dark-main-Blue-Color#��[ ����Ѐ�  � � � �� ���� ��� ׀�O � ���� ��� � � ��O���� ��� ׀�  � ���� ��� ����ا р�� �ا �`�� �pr рS�  �\ р�]  � рS�  p�`��  �� р�� @]� р�@]� р��ا 	�� $
��BACK��$��1��$��Center=�$��10,0,0,0q�#��[ �� -   $ next_btn��$��1�� ! MaterialDesignFlatMidBgButton#��[ $��5,0,0,0q�$ 4��$��Right=�$
 Depth1=�
 J� Uid$7 1/Controls/Window-Pages/reception_fields_page.xaml��.��� 	 �� $
��auto ��� $��25 �.+��� $
��NEXT��$��Center=�$��0,0,10,0q�#���   �� $��1��$��25��$��25��.+�F� #���   ����Ѐ�O � � � ��O���� ��� ׀�  � ���� ��� � � �� ���� ��� ׀�O � ���� ��� ���[ @]� р�� @]� Ѡ7�  �� р�  pр7 � р�  �\ Ѡ7� �pr р�� �ا р�[ �ا р�[ @]� 	�� -   $ confirm_btn��$��1��#��[ $y�	Collapsed=�$��5,0,0,0q�$ 4��$��CONFIRM��$��Right=�$
 Depth1=�