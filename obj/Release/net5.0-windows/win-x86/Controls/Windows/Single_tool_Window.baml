   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  2    ,Huber_Management.Controls.Single_tool_Window   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:Huber_Management.Controls     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  Tool Details��$	��360��$	��650�� � WindowStartupLocation$ CenterScreen=� � Topmost$
 True��.��� $��10q� � RowDefinitions �� $��1* ��� $��1* �.+�� $��0�� � ColumnDefinitions �� $��2* �$	��100���� $��3* ��� $��3* ��� $
��auto �.+��� $��0��$��0 0 2 0q�   Table-Header-bg-Color#��[  ._��� -    ��Name$ image_detail��  noImage#��[  � Cursor$ SizeAll��$��Uniform=��� $��1��$��0,0,2,0q� �� Padding$ 5,0,5,0q�#��[  ._��  �� �� �� $��30 ��� �� �� .+��� -    ��Name$ serial_nb_detail��$��0��$��	SERIAL ID��$��20(�$��DemiBold"�$��Center=��� -   $ project_detail��$��1��$��
no project��$��14(�$��Center=��� -   $ designation_detail��$��2��$��2��$��no designation��$��12(�$��Light"�  Label-Gray-Color#��[ $��WrapWithOverflow=��� -   $ actual_stock_detail��$��4��$��0 Available��$
��Left=�$
��Left=�$��SemiBold"�$��18(�  Success-green-Color#��[ ]� $��5��.+��� $��
?? in work��#��[ $��Bottom=�$��DemiBold"��� $��0 Defective��$��Right=�$��SemiBold"�$��Bottom=�$��Right=�  Failed-red-Color#��[ �� $��2��._��� $��1��$��0,0,2,0q�$ 5,0,5,0q�#��[  ._��  �� �� �� �� .+�� $��Center=� �� �� �� .+��� $��Unit price:��$
��Left=�$��Center=�$��SemiBold"��� -   $��price_detail��$��	0.000 €��$��1��$��Center=��� -   $��price_detail_dt��$��0.000 DT��$��2��$��Right=�� $��1��$��Center=� �� �� �� .+��� $��Total price:��$
��Left=�$��Center=�$��SemiBold"��� -   $��total_price_detail��$��	0.000 €��$��1��$��Center=��� -	   $��total_price_detail_dt��$��0.000 DT��$��2��$��Right=�� $��2��$��Center=� �� �� .+��� $��	Supplier:��$
��Left=�$��Center=�$��SemiBold"��� -
   $��supplier_detail��$	��...��$��1��$��Right=�� $��3��$��Center=� �� �� .+��� $��Supplier code article:��$
��Left=�$��Center=�$
��Wrap=�$��SemiBold"��� -   $��supplier_code_article��$��-��$��1��$��Right=��� $��3��._��  �� �� �� �� .+��� -   $��0��$
��10 0q�$��0q�+  %MaterialDesignThemes.Wpf.ShadowAssist	   ShadowDepth$	 Depth0=�$��Right=�
�������$��0q�
 � ToolTip$
 Make a Reception��.���� $��24��$��24��.+�F� #��[ �����@KL @o@���- ��!��� �� ���- @KL �@KL ��- ��� �� ���!��- �@o@@KL ��� �� �@o@��!�@o@��2��2@o@��!@o@�@KL @o@���[ @]� Ѡ@� @]� ��ا  �� Ѡ��  pѠ� � Ѡ��  �\ ��ا �pr Ѡ@� �ا р�[ �ا р�[ @]� 	�� -   $��1��$
��10 0q�$��0q�$	 Depth0=�$��Right=�
�������$��0q�$
 Make an Exchange��.���� $��24��$��24��.+�F� #��[ �����@KL @o@���- ��!��� �� ���- @KL �@KL ��- ��� �� ���!��- �@o@@KL ��� �� �@o@��!�@o@��2��2@o@��!@o@�@KL @o@���[ @]� Ѡ@� @]� ��ا  �� Ѡ��  pѠ� � Ѡ��  �\ ��ا �pr Ѡ@� �ا р�[ �ا р�[ @]� 	�� -   $��2��$
��10 0q�$��0q�$	 Depth0=�$��Right=�
�������$��0q�$
 Modify This Tool��.���� $��24��$��24��.+�F�   Grey-Blue-Color#��[ �����`�4�� Ѡ�v �� Ӏ�g �� ��[ ��* ��[ ��9 Q��[ ���Q80@Ӏ�[ �s��g ����v ���`�4��Ӏ|C����O����O���Q80@р�O��9 Ӏ�O��* �|C�� `�4�� � è ��� �@T� ��� �@T� �r� � ��  �h � ;�i� � è ��� ��V�&p Ѡ0i ���� `!` �fffff�0@ �P �`C��M ����M ��	 �P ��V gd �@� p�g @� ��l �V�&p � 	= ��[ р� ��[ р�  -1Ӏ� �B @, ��O 	= ��Oр���Oр� -1� 	=  -1� 	= ��[ 	�� -   $��3��$
��10 0q�$��0q�$	 Depth0=�$��Right=�
�������$��0q�$
 Delete From Database��.���� $��24��$��24��.+�F�   Soft-red-Color#��[ �������! 	= ����  	= Ѡ@� ��- �`�� ��- � ��  	= �@KL  	= �@KL ��[ ���!��[ ���[ ��!� z @o@ �� �� � $� @o@׀���! �� �� р���j р�[ ��j р�[ ��!	� $��1��$��0,15,0,0q� �� $
��auto ��� $��* �.+���   Table-Header-style#��[ #��[  $��0,0,0,6q�._��  �� $	��100���� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Date��  Table-Header-label#��[ �� $��1��$
��Time��#��[ �� $��2��$��Transaction��#��[ �� $��3��$��Quantity��#��[ �� $��4��$��Req/Prov��#��[ �� $��5��$��By��#��[ �� $��6��$��Comment��#��[ �� $
��Auto=�$��1��.���� -    ��Name$ Transactions_rows_panel�� �� Orientation$ Vertical=� �� CanVerticallyScroll$
 True��$��40��.+��� $1��+The is no transaction history for this tool��#��[ $��Center=�$��0 10 0 0q�