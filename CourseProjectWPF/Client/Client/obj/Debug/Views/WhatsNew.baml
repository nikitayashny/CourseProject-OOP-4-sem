   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5          Client.Views.WhatsNew   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      -   5          N�Name$  pageWhatsNew��5       N� Title$ WhatsNew��5	      .��5      � .+�5   
   �� -   5         ��Name$ listviewWhatsNew��5      $
��1018��5      $��1��5      ��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6     K� IsItemsHost . $
��1000��5       5      ��5      �� 5       �� 
TargetType" ��6   .�5!      -   5        5$       �� View 5(      �� 5*      .P�5,      ��    m_NEW_COLLECTIONS#���   6%    �� Width$	 230��5-   %    �� CellTemplate 5/      �� 51      .R�53   "   �� .+�55   &   ��   PictureCatalog#���  56   ,   ��55   ,   �� *	picture+56   ,   �� 58   &   	 ��Name$	 TextBlock_name��60   $
��Bold"�5:   0   ��59   0   �� *name+5:   0   �� 5<   &   $
��Wrap=�60   �� 5>   .   �62   �� *price+ �� 5?   .   $�$��62   5A   '   5C   #   5E      5I      5K      5O      �� 5S   
   -   5        
 ��Name$
 FullDescriptionWhatsNew��5S        ScrollViewerDefault#���  5T      $y�	Collapsed=�5U      .��5W      �� -   5        $ listviewFullWhatsNew��5W       5Z      �� 5\      .P�5^      �� $	 500��6)    5`      �� 5b   "   .R�5d   &   ��   PictureFull#���  5e   ,   ��5d   ,   ��  �� Path$ picture�5e   ,   5g   #   5k      �� 5m      $	 600��6)    5o      �� 5q   "   .R�5s   &   �� .+�5u   *   ��   TextBlockNameFull#���  64   �� 5w   .   �62   �� $
 name�5y   +   �� 5{   *     TextBlockFull#���  64   �� 5}   .   �62   �� $ price� �� 5~   .   $�$��62   5�   +   �� 5�   *   #���  64   �� 5�   .   �62   �� $ color�5�   +   �� 5�   *   #���  64   �� 5�   .     m_Size:#��  62    �� 5�   .   �62   �� $
 size�5�   +   �� 5�   *    �� Orientation$ 
Horizontal=�65   $��0 50 0 0q�5�   5   .+�5�   .   ��   ButtonAddToBasket#���  5�   5     m_AddToCart#���  5�   5    	 
btTemplate#��� 	 5�   5   ��5�   5   �� *!DataContext.AddToBasketWhatsNew+ �� RelativeSource ��  �� AncestorType$
 PageL���5�   5   ��  �� ElementName$ pageWhatsNew��5�   5   �� 5�   .    
 ButtonAddToFavorite#��� 
 5�   5   #��� 	 5�   5   ��5�   5   �� *$"DataContext.AddToFavoritesWhatsNew+ �� $
 PageL���5�   5   �� $ pageWhatsNew��.��5�   2   �� $9��3C:\Users\User\Desktop\CourseProjectWPF\img\like.png��68    	 Heart#���  5�   8   5�   /   5�   +   �� 5�   *     ButtonBachToShopping#���  5�   1   #��� 	 5�   1     m_BackToShopping#���  5�   1   ��5�   1   �� *DataContext.OpenWhatsNew+ �� $
 PageL���5�   1   �� $ pageWhatsNew��5�   1   5�   '   5�   #   5�      5�      5�      5�      5�      5�      