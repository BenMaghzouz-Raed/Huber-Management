   M S B A M L   `   `   `  ���� K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  8    2Huber_Management.Controls.Single_tool_details_page   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  3local'clr-namespace:Huber_Management.Controls    N� Title$  Single_tool_details_page�� � 	Resources  �� 
TargetType �� Property �� Value   Label-Gray-Color��%H  '��       7   '�� �     7   �� " ��.���  � ��$ 16(���  � ��8   ��  � ��$ Center=���  �@��TextAlignment$ Right=���  � ��$ Stretch=���  � ��$
 Wrap=��� " ��.���  � ��$ 15(���  � ��$ DemiBold"���  � ��$ Center=���  � ��$
 Left=���  � ��8   .��� $��10q� � ColumnDefinitions �� $��* ��� $��* �.+��� $��0,0,2,0q�  MaterialDesignDivider#��[  �� Padding$ 0 0 15 0q�._��  � RowDefinitions �� �� �� �� �� �� .+�� $��0��$��Center=� �� $
��auto ��� $��* �.+��� $��Drawing:���� -    ��Name$ drawing��$��1��$��DPR-00353136��� $��1��$��Center=� �� $
��auto ��� $��* �.+��� $��Project:��$
��Left=��� -   $ project��$��1��$��
MM/Adapter��� $��2��$��Center=� �� $
��auto ��� $��* �.+��� $��Process:���� -   $ process��$��1��$��Assembly��� $��3��$��Center=� �� $
��auto ��� $��* �.+��� $��	Division:���� -   $ division��$��1��$	��FCI��� $��4��$��Center=� �� $
��auto ��� $��* �.+��� $��	Position:���� -   $ position��$��1��$
��T6.1��� $��5�� �� �� .+�� $��0��$��Center=� �� $
��auto ��� $��* �.+��� $��
Min Stcok:���� -   $	 min��$��1��$��2��	 �� TextAlignment$	 Center=�� $��1��$��Center=� �� $
��auto ��� $��* �.+��� $��
Max Stock:���� -   $	 max��$��1��$��4��$	 Center=�� $��2��$��15 0 0 0q� �� �� �� �� �� �� .+�� $��0��$��Center=� �� $
��auto ��� $��* �.+��� $��Unit price:���� -   $ 
unit_price��$��1��$��0.00 €��� $��1��$��Center=� �� $
��auto ��� $��* �.+��� $��Total price:���� -	   $ total_price��$��1��$��0.00 €��� $��2��$��Center=� �� $
��auto ��� $��* �.+��� $��	Supplier:���� -
   $ supplier��$��1��$	��H+S��� $��3��$��Center=� �� $
��auto ��� $��* �.+��� $��Supplier code article :���� -   $ supplier_code��$��1��$��DPR-00353136��� $��4��$��Center=� �� $
��auto ��� $��* �.+��� $��Criticality:���� -   
 ��Name$
 tool_criticality��$��1�� J� Opacity$ .8Q�$��A��$��0q�.  (MaterialDesignThemes.Wpf.TextFieldAssist   TextFieldCornerRadius$ 4��  Failed-red-Color#��[ $��35�� �� TextAlignment$ Center=�$��DemiBold"�$��Center=�$��Right=�
�������$��18(�$|�False��� $��5��$��Center=� �� $
��auto ��� $��* �.+��� $��Added date:���� -   $ 
added_date��$��1��$��
01/03/2021��