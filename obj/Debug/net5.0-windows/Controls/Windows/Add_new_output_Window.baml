   M S B A M L   `   `   `  ����K  GHuber-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Huber_Management.ControlsHuber_Management.Controls  5   	   5    /Huber_Management.Controls.Add_new_output_Window   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Huber_Management.Controls     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Add a Checkout��5	   	   $	��400��6    $	��500��6-      MaterialDesignPaper#���   5
   	    � 
ResizeMode$ NoResize=�5   	    � Topmost$
 True��5   	     Huber_small_icon � Icon# [ 5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
    � -   5          �Name$ Add_reception_container��5        � Source$/ )/Controls//Windows_Pages/search_page.xaml?�61     � NavigationUIVisibility$ Hidden=�6d   � 5   
   $��2��6   	 � ColumnDefinitions	 5      �� 5      �� 5      .+�5"      �� -   5        
 ��Name$
 Add_new_tool��5"      $��0��6+   $
��10 0q�6;   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 0��6J   $
��Left=�5#        MaterialDesignFlatButton#��[ 60   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�6c   .��5%      � 	 5&      �� 5'      $��25 �6+   �� 5(      $
��auto �6+   .+�5+      �� $��25��6   $��25��6(   $��0��64   .+�5,      F�   Dark-main-Blue-Color#��[ 6   �����@f@]� �@]� @]� �@]� @f��ا @f��ا @]� ���j @]� ���j �ا ��ا �ا ��ا ��j �@]� ��j �@]� �ا �@f�ا � � �� ׀�  �  ��� ��� � � ��O ��� ��� ׀�O �  ��� ��� � � ��  ��� ��� 	6L   5-      �� 5.      $	��NEW��6    $��1��6+   $��Center=�6;   $��10,0,0,0q�6V   #��[ 6h   5/      50      �� 53      -   5        $
 
return_btn��53      $��0��6)   $
��10 0q�69   $ 0��6H   $y�	Collapsed=�6u   $
��Left=�54      #��[ 60   $ Depth0=�6c   .��56      � 	 57      �� 58      $��25 �6+   �� 59      $
��auto �6+   .+�5<      �� $��25��6   $��25��6(   $��0��64   .+�5=      F� #��[ 6   ����Ѐ�  � � � �� ���� ��� ׀�O � ���� ��� � � ��O���� ��� ׀�  � ���� ��� ����ا р�� �ا �`�� �pr рS�  �\ р�]  � рS�  p�`��  �� р�� @]� р�@]� р��ا 	6L   5>      �� 5?      $
��BACK��6    $��1��6,   $��Center=�6<   $��10,0,0,0q�6W   #��[ 6i   5@      5A      �� 5D      -   5        $
 next_btn��5D      $��1��6'    ! MaterialDesignFlatMidBgButton#��[ 68   $��5,0,0,0q�5E      $ 4��6*   $��Right=�6W   $ Depth1=�5F      
 J� Uid$7 1/Controls/Window-Pages/reception_fields_page.xaml��6a   .��5G      � 	 5H      �� 5I      $
��auto �6+   �� 5J      $��25 �6+   .+�5L      �� $
��NEXT��6    $��Center=�6,   $��0,0,10,0q�6G   #���   6Y   �� 5N      $��1��6   $��25��6-   $��25��68   .+�5O      F� #���   6   ����Ѐ�O � � � ��O���� ��� ׀�  � ���� ��� � � �� ���� ��� ׀�O � ���� ��� ���[ @]� р�� @]� Ѡ7�  �� р�  pр7 � р�  �\ Ѡ7� �pr р�� �ا р�[ �ا р�[ @]� 	6L   5P      5Q      5R      �� 5U      -   5        $
 confirm_btn��5U      $��1��6*   #��[ 6;   $y�	Collapsed=�6r   $��5,0,0,0q�5V      $ 4��6*   $��CONFIRM��6W   $��Right=�6i   $ Depth1=�5W      6J   5X      5Y      5Z      