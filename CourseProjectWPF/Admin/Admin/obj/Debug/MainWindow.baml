   M S B A M L   `   `   `  ����@  <Admin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:laba4laba4  5   	       Admin.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:laba4     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  window��5   $    � Title$ LSD clothing (Admin)��5	   	   $	��720��6&   $	��720��63    � 	Resources 5         ButtonStyle �� 
TargetType �� Property �� Value��%�  &	        �� 5   
   " ��6$   .�5      ��  � ��
 �   �62   �� 5       � ��
 �����62   �� 5       � ��$ SF Pro Display)�62   �� 5       � ��$
 Bold"�62   �� 5       � ��$ 20(�60   �� 5       � ��$ 70��6.   �� 5       � ��$	 200��6-   �� 5       � ��
 �   �63   �� 5       � ��$ 5q�67   5      5      .��5      � $	��360��6   $	��360��6   ��5   
   �� 5       �� ImageSource$; 5C:/Users/User/Desktop/ООТПиСП/laba4/img/bg.png��6    � RowDefinitions 5    
   �� 5!      �� 5"      �� 5#       � ColumnDefinitions 5%   
   �� 5&      �� 5'      �� 5(      .+�5+   
   �� $��0��6   $��0��6    $��3��6-   $=��7C:\Users\User\Desktop\ООТПиСП\laba4\img\logo.png��6A   �� 5-   
   -   5        	 ��Name$	 button_Catalog��5-      #��[  6k   $��0��6�   $��1��6�     	m_CATALOG#���  6�   ��6)   �� *OpenCatalog+
 �� ElementName$
 window�� �� Mode$ OneWay=�6�   �� 5.   
   -   5        $	 
button_Add��5.      $��1��6^   $��1��6n   #��[  6{    	 m_ADD#���  6�   ��6%   �� *Add+$
 window��$ OneWay=�6�   �� 5/   
   -   5        $	 button_Delete��5/      $��2��6d   $��1��6t   #��[  6�     m_DELETE#���  6�   ��6(   �� *Delete+$
 window��$ OneWay=�6�   �� 50   
   -   5        $	 button_LanguageEng��50      $��0��6p   $��2��6�   $��
Eng/Рус��6�   ��6-   �� *Changelanguge+$
 window��$ OneWay=���51      �� 52      " ��6   .�53      ��  � ��
 �   �6:   �� 54       � ��
 �����6:   �� 55       � ��$ SF Pro Display)�6:   �� 56       � ��$
 Bold"�6:   �� 57       � ��$ 20(�68   �� 58       � ��$ 70��66   �� 59       � ��$	 200��65   �� 5:       � ��
 �   �6;   �� 5;       � ��$ 5q�6?    �� Triggers 5<      :� 5=       :� RoutedEvent$ Click��6'   [�5>      �� 5?   "   .��5@   &   �� .��5A   *   W�  �� TargetProperty$ Width�6:    g� Duration$ 0:0:0.1D�6\   	 W� To$	 195X�6o    g� AutoReverse . 6x   W� 5B   *   $ Height�6:   $ 0:0:0.1D�6]   $ 65X�6p    . 6x   5C   '   5D   #   5F      5H      5J      �� 5K   
   -   5        $	 button_DarkLight��5K      $��1��6j   $��3��6z   #��[  6�     m_DarkLight#���  6�   ��6+   �� *	DarkLight+$
 window��$ OneWay=�6�   �� 5L   
   -   5        $	 button_Orders��5L      $��2��6d   $��3��6t   #��[  6�     m_Orders#���  6�   ��6(   �� *Orders+$
 window��$ OneWay=�6�   5M      5N      