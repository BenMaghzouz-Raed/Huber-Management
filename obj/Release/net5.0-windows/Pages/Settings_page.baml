   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Huber_Management.PagesHuber_Management.Pages  *    $Huber_Management.Pages.Settings_page   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6local$clr-namespace:Huber_Management.Pages     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     N� Title$  Settings_page�� � 	Resources    
Import_btn �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Padding �� CornerRadius	 � ColumnDefinitions

 � Tag �� Triggers P� Property P� Value  Soft-bg-Blue-Color �� 
TargetName��%�  &	        7  �� " ��.���  � ��
 ���� ��  � ��$ 18(���  � ��$ DemiBold"���  � �� �� " ��.R��� $ Border��#��z��$��2q�#��z��$��Center=�$��Center=�$
 10,6q�${�False��$ 6,6,6,6��._�� 	 �� �� .+��� #��z
 $��24��$��24��$��0,0,8,0q��� $��1��$��Center=�$��Center=�#��z�� P�  �@J�IsMouseOver$
 True��. ��� 8   $ Border�� � ��.���  � RowDefinitions �� $��54 ��� $
��auto ��� $��54 ��� $��* �.+��� $��Database Settings :��$��10 0 0 0q�$��Stretch=�$��Stretch=�
�������$��28(�$
��Bold"�$��Center=�� $��1��$��10q�	 �� $��* ��� $��* �.+�� $��0�� �� �� �� .+��� -   $ Import_excel_btn��$��0 0 5 5q�#��[ $ 10��$ 15 10q� � Cursor$
 Hand��$��0��._���  �� Orientation$ 
Horizontal=�.+�(� $��48��$��48��.���� $��24��$��24��.+�F�   Dark-main-Blue-Color#��[ ����� � ��- Ӱ� ��- ��V H�z�G@`FE ��T �0b� �� Ӡ7� PǦ  4� �ا  � �ا ��Q��k0@�ا  -1���  -1��j � -1�I �Q��k0@��-  � ��- Ѐ�; @l Ѡ%&  �� �@KL �ا �    �ا �    @]� �@KL @]� Ѡ%& ��� р�; �-�@�  � � -1@T� � -1� �Q��k0@@]�  � @]� ��� @]� �D� �� �� pa� ѠEt �� Ӏ� pS� �b�  $�  �  $� ��Q��k0@ $�  -1���  -1 � � -1��� � -1PX� �Q��k0@�� � ����P� ���u `��^ ��� �PE 08Ӏ�V �0�� @o@ � @o@��Q��k0@@o@ -1% -1@f	�� $��Import an Excel file��$��Center=�$��Center=�$��SemiBold"�$��16(�$
��Wrap=� �� TextAlignment$ Center=�#��[ �� -   $ Export_excel_btn��$��0 5 5 5q�  Soft-green-Color#��[ $ 10��$ 15 10q�$
 Hand��$��1��._��� $ 
Horizontal=�.+�(� $��48��$��48��.���� $��24��$��24��.+�F�   Success-green-Color#��[ �����PCP�1 �`HP�1  L�g5 Ҁ�O`9 ��O�A> р�O��/Ҁ�O�$5 L �8�`H��<PC��<��yw ��<��pr ��<@yn  �8���j �$5��j ��/���j @fѰ.+ @fҠ%& @f ." ��(\��0@Ҁ�  �� �� �Q��+0@р� �yw Ҁ� �pr  ." @yn Ҡ%& ��j �.+ ��j ���j ��j ���j �A> ���j `9 @yn �g5 ��pr P�1 �yw P�1 ���j �G� � �| �'� �P!� �'� � z `� ��� ��� �q=
ףp @��� ѐ�l  R� �P/l �<� � �k �M� Ҁ�g �7� �.c @�� �^_ �� P[ ��� � z? ��� ��P\ �S� � 	= �'� � 2X �'� ���� ��)���� @fѐ�} @fѐ�} ��)���� pS� ���� �� � � �� � � pS� ����  �� ���� ��} � � ��} � �  �� ���� ��j ����  �D ѐ�}  �D ѐ�} ��j а�<��)Ѱ�<@fѐ�� @fѐ�� ��)а�<pS� Ѱ�<�� ѐ�� �� ѐ�� pS� а�< �� Ѱ�<��} ѐ�� ��} ѐ��  �� �<��j Ѱ�< �D ѐ��  �D ѐ�� ��j 	�� $*��$Export all the data as an Excel file��$��Center=�$��Center=�$��SemiBold"�$��16(�$
��Wrap=�$ Center=�#��[ �� -   $ Delete_excel_btn��$��0 5 5 5q�  Soft-red-Color#��[ $ 10��$ 15 10q�$
 Hand��$��2��._��� $ 
Horizontal=�.+�(� $��48��$��48��.���� $��24��$��24��.+�F�   Failed-red-Color#��[ �����@f 	= �@f��[ ���- ��[ ���-  	= Ѡ.c  	= ��pr ��- � �� ��- �`��  	= �@f 	= � 	= ��!� 	= ��j � $� ��j � $� ��!� $� ��2`h� @o@��� @o@р�[ @o@Ӡ�J @o@ 	= ��2 	= ��!���!��� �@o@��� �@o@@f���!@f���!��� ���!��j �@o@��j �@o@@]� ���!@]� ���!��j 	�� $-��'Delete all the data of this Application��$��Center=�$��Center=�$��SemiBold"�$��16(�$
��Wrap=�$ Center=�#��[ � $��1��$��10 0 0 0q� �� $��* ��� $��* ��� $��* �.+��� .+��� -    ��Name$ price_convert_value��$��0 5 5 5q�$��0��.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasTrailingIcon$
 True��  MaterialDesignDivider#���    textBoxInputStyle#���  )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Conversion Euro / Dinar��$��Center=�$��12q�   TrailingIcon$ Exchange=�${�False��� $��1��	 �� �� �� .+��� -   $ criticality_a��$��0 5 5 5q�$��0��$
 True��#���  #���  $��Center=�$ A��$��Center=�$��12q�$ Schedule=�${�False���� -   $ criticality_b��$��0 5 5 5q�$��1��$
 True��#���  #���  $��Center=�$ B��$��Center=�$��12q�$ Schedule=�${�False���� -   $ criticality_c��$��0 5 5 5q�$��2��$
 True��#���  #���  $��Center=�$ C��$��Center=�$��12q�$ Schedule=�${�False���� $��2��$��Center=�$ 
Horizontal=�$��Right=�$	��5 0q�.+��� -	    ��Name$ Edit_settings��$��0��$
��10 0q�+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��$
��Left=� 	 MaterialDesignFlatButton#��[	 +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�$y�Visible=�.��� 	 �� $��25 ��� $
��auto �.+��� $��25��$��25��$��0��.+�F� #��[ ����� 	= ��� � 	= @f� 	= ��!�k �)<�ا @o@��ا 0Vѐԩ ��Ӏ�l  � 	= ���(\0@ 	= ��� � � @]� �`�s @]�  	= �  	= @T� � 	=  � � 	= ��� `�s  $�  �  $� �p�  $� ���  $� @��  $� �@f�� �@�� �� �2� @]�  � @]� � � ��- �`�s ��-  	= �I  	= ��j � 	= ��� `�s �ا  � �ا ��Q��k0@�ا  -1���  -1��j � -1�I �Q��k0@��-  � ��- �@o@�ԩ �P%>�ԩ p<� �{:�l� ѐ9+஻ �`�J`3� Ѡ�Y �� ���\���  ]��� ��YP1� ���F�l� �@QE� `.C�ԩ �A�ԩ � �"��� �@]� ` !�@]� @o@� �� @o@� DBP�� � �"��� 	�� $
��EDIT��$��1��$��Center=�$��10,0,0,0q�#��[ �� -
   $ Save_changes��$��0��$
��10 0q�$ 0��$
��Left=�#��[	 $ Depth0=�$y�	Collapsed=�.��� 	 �� $��25 ��� $
��auto �.+��� $��25��$��25��$��0��.+�F� #��[ �����@f��- �@KL ��- �`�; ��- ��- `�; ��- @KL ���- ��!���- ��2`�; @o@@KL @o@��4� @o@�`A�  ]6�p� �+0� �y�`�� pc $� ������0@�a� �V� ��� p� �� @]�  � @]� ��ѽ @]� ��� ���  �� �� �P�� �y� �Rpٰ @o@��� �@o@��j �@f��- ���� @T� �@KL @T� �@KL @KL ���� @KL ���� @T� �pS� @o@�@]� ��р� @� �pS� 08��'�p� � �8��� �pS� @o@	�� $
��SAVE��$��1��$��Center=�$��10,0,0,0q�#��[ � $��2��
�������	 �� �� .+��� $��Accounts Settings :��$��10 0 0 0q�$��Stretch=�$��Stretch=�$��28(�$
��Bold"�$��Center=��� -   $ Add_new_user��$��1��$
��10 0q�$��0,0,18,0q� � ToolTip$ Add new tool to database��$ 0��$��Right=� "
 MaterialDesignFlatDarkBgButton#��[
 $ Depth1=�$��36��.��� 	 �� $��25 ��� $
��auto �.+��� $��24��$��24��.+�F� 
��������������� ��� �$� ��� ��j ��� ��j �����j  -1���^ -1���^�����^��� p���� ��� ��� Ѐ�[ ��� р�[ ��j � 	= ��j � 	= ��� �@B ��� �@B  � � 	=  � � 	= ��� р�[ ��� р�[  � �@T�  � �@T� ��� ����  � ���! z   	=  	= ����  	=   	=  	= ��ا  z   	=  	= ����  �   	=  	= 	�� $��Add User��$��1��$��Center=�$��10,0,0,0q�
�������� $��3��$��10q� �� $
��auto ��� .+���   Table-Header-style#��[ $��0q�._�� 	 �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��	User Name��  Table-Header-textBlock#��[   Label-Gray-Color#��[ �� $��1��$��	Full Name��#��[ #��[ �� $��2��$��Created Date��#��[ #��[ �� $��3��$��
Privileges��#��[ #��[ �� $��4��$��Last Time Connected��#��[ #��[ �� $
��Auto=�$��1��.���� -    ��Name$ users_rows_panel��$ Vertical=� �� CanVerticallyScroll$
 True��$��40��.+��� $��We can't find any user��$��Center=�$��18(�