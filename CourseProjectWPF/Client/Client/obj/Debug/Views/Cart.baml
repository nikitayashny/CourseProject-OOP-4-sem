   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5          Client.Views.Cart   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      -   5          N�Name$  pageCart��5       N� Title$
 Cart��5	      .��5      � .+�5   
   �� -   5         ��Name$ Basket��5         ScrollViewerDefault#���   5      .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ listviewBasket��5      $	��600��5      $
��Left=�5      ��5      �� 5       �� 
TargetType" ��6    .�5      -   5        5       �� View 5!      �� 5#      .P�5%      ��   m_YOUR_BASKET#���  6-    �� Width$	 200��5&   -    �� CellTemplate 5(   "   �� 5*   &   .R�5,   *   �� ��60   �� 	 �� Path$	 picture�5.   '   52      �� 54      $	 300��6-    56   "   �� 58   &   .R�5:   *   �� .+�5<   .   �� 
 ��Name$
 Basket_name��68     TextBlockFirstBasket#���  5>   8   ��5=   8   �� $
	 name��� 5@   2   $� ��66    �� 5A   2   $
��Bold"�5B   6   $��20(�5C   6   �5A   6   �� $	 price�5C   6    �� 5D   2   $�$��66   $
��Bold"�5E   6   $��20(�5F   6   5H   /   �� 5J   .     TextBlockBasket#���  68   $��0 30 0 0q�5K   8   �� 5M   2     m_Size:#��  66    �� 5N   2   �66   �� $
	 size�5P   /   �� 5R   .   #���  68   �� 5T   2     m_Color:#��  66    �� 5U   2   �66   �� $	 color�5W   /   �� 5Y   .    ��Name$ DeleteButton��65   $y�Hidden=�5\   5     
btTemplate#���  5]   5     DeleteBasket#���  5^   5     m_Delete#���  5_   5   ��5Z   5   �� *DataContext.DeleteFromBasket+ �� RelativeSource ��  �� AncestorType$
 PageL���5[   5   ��  �� ElementName$ pageCart��5_   5   5a   +   5c   '   5g      5i      5m      �� 5o       	 BorderBasket#��� 	 6   ._�5q      �� .+�5s      ��  
 m_YourOrder#��� 
 6$   $��20(�5t   $   $
��Bold"�5u   $   �� 5w      $��0 40 0 0q�6$   �� 5y        m_TotalPrice#��  6"   $
��Thin"�5z   "   $��20(�5{   "    �� 5|      -   5         ��Name$ RunSum��5|   "   $��SemiBold"�5}   "   $��20(�5~   "    �� 5      $�$��6"   $��SemiBold"�5�   "   $��20(�5�   "   5�      �� 5�      $��0 10 0 0q�6$   �� 5�        
m_Quantity#��  6"   $
��Thin"�5�   "   $��20(�5�   "    �� 5�      -   5        $ RunQuantity��5�   "   $��SemiBold"�5�   "   $��20(�5�   "    �� 5�        m_piece#��  6"   $��SemiBold"�5�   "   $��20(�5�   "   5�      �� 5�        
LineBasket#���  6!   �� 5�      #���  5�   !     
m_CheckOut#���  5�   !     ButtonCheckOut#���  5�   !   ��5�   !   �� *DataContext.CheckOut+ �� $
 PageL���5�   !   �� $ pageCart��5�   !   5�      5�      5�      5�      5�      5�      