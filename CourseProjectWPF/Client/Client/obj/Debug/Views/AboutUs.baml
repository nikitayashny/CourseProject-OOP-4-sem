   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5          Client.Views.AboutUs   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5        N� Title$  AboutUs��5      .��5
      � .+�5   
   �� -   5         ��Name$ StackPanelAboutUs��5         ScrollViewerDefault#���   5      .��5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $<��6C:\Users\User\Desktop\CourseProjectWPF\img\AboutUs.png��6     ImageAboutUs#���  5      �� 5        StackPanelSecondBlock#���  6!   .+�5      ��   TextBlockThirdBlock#���  6$   �� 5        	m_AboutUs#��  6   $��SemiBold"�5      5      �� 5        TextBlockSecondAboutUs#���  6$   �� 5         m_FullTextAboutUs#��  6   5"      �� 5$        TextBlockThirdAboutUs#���  6$   �� 5&        m_LastInAboutUs#��  6   5(      5*      5,      �� 5.       	 	m_Reviews#��� 	 6   $	��100��5/       �� TextAlignment$ Center=�50      $��30(�51      $��SemiBold"�52       �� Padding$ 0 30 0 0q�53      
���   �
�������55      �� 57      
���   �$��10q�6-   ���	#00000000._�58      �� -   5         ��Name$ listviewReviewsAboutUs��58      $
��1200��59       J� IsHitTestVisible .  ��5<      �� 5>      .R�5@   "   �  � Orientation$ 
Horizontal=�6,    K� IsItemsHost . $
��1200��5B       5D      	 �� View	 5H      �� 5J      .P�5L   "   �� 
 �� Width$	
 580��61    �� CellTemplate 5N   &   �� 5P   *   .R�5R   .   �� .+�5U   2   �� $
��Wrap=�5V   <   $��16(�5W   8   $��	0 40 0 0 q�5X   8   
�������$	��580��5Z   8   $ Center=�5[   8   ��5U   <   �� *review+5[   8   �� 5\   2   6>   �� 5]   2   $��	0 0 0 40 q�5^   7   $��20(�5_   8   
���   �$ Center=�5a   8   $	��580��5b   8   ��5]   <   �� *name+5b   8   5d   /   5f   +   5j   #   5l      5p      5q      5r      5t      5v      5w      