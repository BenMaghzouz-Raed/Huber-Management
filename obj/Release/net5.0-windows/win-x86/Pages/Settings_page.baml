   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Huber_Management.PagesHuber_Management.Pages  *    $Huber_Management.Pages.Settings_page   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:Huber_Management.Pages       N� Title$  Settings_page�� � 	Resources    
Import_btn �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Padding �� CornerRadius	 � ColumnDefinitions

 � Tag �� Triggers P� Property P� Value  Soft-bg-Blue-Color �� 
TargetName��%�  &	        7  �� " ��.���  � ��
 ���� ��  � ��$ 18(���  � ��$ DemiBold"���  � �� �� " ��.R��� $ Border��#��z��$��2q�#��z��$��Center=�$��Center=�$
 10,6q�${�False��$ 6,6,6,6��._�� 	 �� �� .+��� #��z
 $��24��$��24��$��0,0,8,0q��� $��1��$��Center=�$��Center=�#��z�� P�  �@J�IsMouseOver$
 True��. ��� 8   $ Border�� � ��.���  � RowDefinitions �� $��54 ��� �� $��54 ��� .+��� $��Database Settings :��$��10 0 0 0q�$��Stretch=�$��Stretch=�
�������$��28(�$
��Bold"�$��Center=�� $��1��$��10q�	 �� �� �� .+��� -   $ Import_excel_btn��#��[ $ 10��$	��200��$	��150��$ 15q� � Cursor$
 Hand��$��0��._��  �� $
��auto ��� .+�(� $��48��$��48��.���� $��24��$��24��.+�F�   Dark-main-Blue-Color#��[ ����� � ��- Ӱ� ��- ��V H�z�G@`FE ��T �0b� �� Ӡ7� PǦ  4� �ا  � �ا ��Q��k0@�ا  -1���  -1��j � -1�I �Q��k0@��-  � ��- Ѐ�; @l Ѡ%&  �� �@KL �ا �    �ا �    @]� �@KL @]� Ѡ%& ��� р�; �-�@�  � � -1@T� � -1� �Q��k0@@]�  � @]� ��� @]� �D� �� �� pa� ѠEt �� Ӏ� pS� �b�  $�  �  $� ��Q��k0@ $�  -1���  -1 � � -1��� � -1PX� �Q��k0@�� � ����P� ���u `��^ ��� �PE 08Ӏ�V �0�� @o@ � @o@��Q��k0@@o@ -1% -1@f	�� $��Import an Excel file��$��1��$��Center=�$��Center=�$��SemiBold"�$��16(�$
��Wrap=� �� TextAlignment$ Center=�#��[ �� -   $ Export_excel_btn��  Soft-green-Color#��[ $ 10��$	��200��$	��150��$ 15q�$
 Hand��$��1��._��  �� $
��auto ��� .+�(� $��48��$��48��.���� $��24��$��24��.+�F�   Success-green-Color#��[ �����PCP�1 �`HP�1  L�g5 Ҁ�O`9 ��O�A> р�O��/Ҁ�O�$5 L �8�`H��<PC��<��yw ��<��pr ��<@yn  �8���j �$5��j ��/���j @fѰ.+ @fҠ%& @f ." ��(\��0@Ҁ�  �� �� �Q��+0@р� �yw Ҁ� �pr  ." @yn Ҡ%& ��j �.+ ��j ���j ��j ���j �A> ���j `9 @yn �g5 ��pr P�1 �yw P�1 ���j �G� � �| �'� �P!� �'� � z `� ��� ��� �q=
ףp @��� ѐ�l  R� �P/l �<� � �k �M� Ҁ�g �7� �.c @�� �^_ �� P[ ��� � z? ��� ��P\ �S� � 	= �'� � 2X �'� ���� ��)���� @fѐ�} @fѐ�} ��)���� pS� ���� �� � � �� � � pS� ����  �� ���� ��} � � ��} � �  �� ���� ��j ����  �D ѐ�}  �D ѐ�} ��j а�<��)Ѱ�<@fѐ�� @fѐ�� ��)а�<pS� Ѱ�<�� ѐ�� �� ѐ�� pS� а�< �� Ѱ�<��} ѐ�� ��} ѐ��  �� �<��j Ѱ�< �D ѐ��  �D ѐ�� ��j 	�� $*��$Export all the data as an Excel file��$��1��$��Center=�$��Center=�$��SemiBold"�$��16(�$
��Wrap=�$ Center=�#��[ �� -   $ Delete_excel_btn��  Soft-red-Color#��[ $ 10��$	��200��$	��150��$ 15q�$
 Hand��$��2��._��  �� $
��auto ��� .+�(� $��48��$��48��.���� $��24��$��24��.+�F�   Failed-red-Color#��[ �����@f 	= �@f��[ ���- ��[ ���-  	= Ѡ.c  	= ��pr ��- � �� ��- �`��  	= �@f 	= � 	= ��!� 	= ��j � $� ��j � $� ��!� $� ��2`h� @o@��� @o@р�[ @o@Ӡ�J @o@ 	= ��2 	= ��!���!��� �@o@��� �@o@@f���!@f���!��� ���!��j �@o@��j �@o@@]� ���!@]� ���!��j 	�� $-��'Delete all the data of this Application��$��1��$��Center=�$��Center=�$��SemiBold"�$��16(�$
��Wrap=�$ Center=�#��[ �� $��2��$��Accounts Settings :��$��10 0 0 0q�$��Stretch=�$��Stretch=�
�������$��28(�$
��Bold"�$��Center=�� $��3��$��10q�