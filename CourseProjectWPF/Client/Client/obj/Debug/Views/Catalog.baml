   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5          Client.Views.Catalog   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      -   5          N�Name$  pageCatalog��5       N� Title$ Catalog��5	      .��5      � .+�5   
   �� -   5         ��Name$ listviewProducts��5      $
��1018��5      $��1��5       �� SelectionMode$ Extended=�5      ��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6     K� IsItemsHost . $
��1000��5       5      ��5      �� 5        �� 
TargetType" ��6   .�5"      -   5        5%       �� View 5)      �� 5+      .P�5-      ��    m_ALL_COLLECTIONS#���   6%    �� Width$	 230��5.   %   	 �� CellTemplate	 50      �� 52      .R�54   "   �� .+�56   &   ��   PictureCatalog#���  57   ,   ��56   ,   �� *	picture+57   ,   �� 59   &   
 ��Name$
 TextBlock_name��60   $
��Bold"�5;   0   ��5:   0   �� *name+5;   0   �� 5=   &   $
��Wrap=�60   �� 5?   .   �62   �� *price+ �� 5@   .   $�$��62   5B   '   5D   #   5F      5J      5L      5P      �� 5T   
   -   5         ��Name$ FullDescription��5T        ScrollViewerDefault#���  5U      $y�	Collapsed=�5V      .��5X      �� -   5        $ listviewFull��5X       5]      �� 5_      .P�5a      �� $	 500��6)   	 5c      �� 5e   "   .R�5g   &   ��   PictureFull#���  5h   ,   ��5g   ,   ��  �� Path$ picture�5h   ,   5j   #   5n      �� 5p      $	 600��6)   	 5r      �� 5t   "   .R�5v   &   �� .+�5x   *   ��   TextBlockNameFull#���  64   �� 5z   .   �62   �� $
 name�5|   +   �� 5~   *     TextBlockFull#���  64   �� 5�   .   �62   �� $ price� �� 5�   .   $�$��62   5�   +   �� 5�   *   #���  64   �� 5�   .   �62   �� $ color�5�   +   �� 5�   *   #���  64   �� 5�   .   $�Size: ��62    �� 5�   .   �62   �� $
 size�5�   +   �� 5�   *    �� Orientation$ 
Horizontal=�65   $��0 50 0 0q�5�   5   .+�5�   .   ��   ButtonAddToBasket#���  5�   5     m_AddToCart#���  5�   5     
btTemplate#���  5�   5   ��5�   5   �� *DataContext.AddToBasket+ �� RelativeSource ��  �� AncestorType$
 PageL���5�   5   ��  �� ElementName$ pageCatalog��5�   5   �� 5�   .    	 ButtonAddToFavorite#��� 	 5�   5   #���  5�   5   ��5�   5   �� *DataContext.AddToFavorites+ �� $
 PageL���5�   5   �� $ pageCatalog��.��5�   2   �� $9��3C:\Users\User\Desktop\CourseProjectWPF\img\like.png��68    	
 Heart#��� 
 5�   8   5�   /   5�   +   �� 5�   *     ButtonBachToShopping#���  5�   1   #���  5�   1     m_BackToShopping#���  5�   1   ��5�   1   �� *DataContext.OpenCatalog+ �� $
 PageL���5�   1   �� $ pageCatalog��5�   1   5�   '   5�   #   5�      5�      5�      5�      5�      5�      