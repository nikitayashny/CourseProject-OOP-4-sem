   M S B A M L   `   `   `  ����
  Client    Client.Views.Home   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N�Name$  window��5   #    N� Title$
 Home��5      .��5
      � .+�5   
   �� -   5         ��Name$ StackPanelHome��5         ScrollViewerDefault#���   5      .��5      �� $��Center=�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      ��   StackPanelFirstBlock#���  6!   .+�5      ��   TextBlockFirstBlock#���  6$   �� 5        m_FirstBlockText#��  6"   5      �� 5      -   5          ButtonShopNow#���  5   !     
btTemplate#���  5   !     
m_SHOP_NOW#���  5   !   5       �� 5"      $>��8C:\Users\User\Desktop\CourseProjectWPF\img\firstHome.png��6     ImageFirstBlock#���  5#      5%      �� 5'      $ 
Horizontal=�6   .+�5)      ��   StackPanelSecondBlock#���  6!   .+�5+      ��  	 TextBlockSecondBlock#��� 	 6$   �� 5-       
 m_SecondBlockText#�� 
 6"   5/      �� 51      -   5          ButtonToBold#���  52   !   #���  53   !     m_GoShopping#���  54   !   56      �� 58      $?��9C:\Users\User\Desktop\CourseProjectWPF\img\secondHome.png��6     ImageSecondBlock#���  59      5;      �� 5=      $ 
Horizontal=�6   .+�5?      �� $?��9C:\Users\User\Desktop\CourseProjectWPF\img\thirdHome2.png��6     ImageThirdBlock#���  5@      �� 5B      #���  6!   .+�5D      ��   TextBlockThirdBlock#���  6$   �� 5F        	m_AboutUs#��  6#   $��SemiBold"�5G   #   5I      �� 5K        TextBlockThirdBlock2#���  6$   �� 5M        m_TextAboutUs#��  6"   5O      �� 5Q      -   5        #���  5R   !   #���  5S   !     m_LearnMore#���  5T   !   5V      5X      �� 5Z        	m_Reviews#���  6   $	��100��5[       �� TextAlignment$ Center=�5\      $��30(�5]      $��SemiBold"�5^       �� Padding$ 0 30 0 0q�5_      
���   �
�������5a      �� 5c      
���   �$��10q�6-   ���	#00000000._�5d      �� -   5         ��Name$ listviewReviews��5d      $
��1200��5e       J� IsHitTestVisible .  ��5h      �� 5j      .R�5l   "   �  � Orientation$ 
Horizontal=�6,   	 K� IsItemsHost	 . $
��1200��5n       5p      
 �� View
 5t      �� 5v      .P�5x   "   ��  �� Width$	 580��61    �� CellTemplate 5z   &   �� 5|   *   .R�5~   .   �� .+�5�   2   �� $
��Wrap=�5�   <   $��16(�5�   8   $��	0 40 0 0 q�5�   8   
�������$	��580��5�   8   $ Center=�5�   8   ��5�   <   �� *review+5�   8   �� 5�   2   6>   �� 5�   2   $��	0 0 0 40 q�5�   7   $��20(�5�   8   
���   �$ Center=�5�   8   $	��580��5�   8   ��5�   <   �� *name+5�   8   5�   /   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      