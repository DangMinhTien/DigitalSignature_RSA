   M S B A M L   `   `   `  ����R  NDangMinhTien_2020600144, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:DangMinhTien_2020600144DangMinhTien_2020600144  5   	   (    "DangMinhTien_2020600144.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:DangMinhTien_2020600144     5   	   X TFontAwesome.Sharp, Version=6.2.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	     � Title$	  RSA��5	   	   $	��800��5
   	   $
��1300��5   	    � WindowState$ 	Maximized=�5   	   
�������.��5      � $��5q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��0��6   $��0��6#   $��
15 0 15 15q�60   $��10 10q�6D   $��2��6T   
�������.��5      �� .+�5      �� $
��16px(�6   $
��Bold"�6,   $��Center=�6>   $	��0 5q�6[   Tạo khóa5      �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��0 10 0 0q�6S   .+�5      	� -   5         	�Name$ 	rb512bits��5   "   $	��512��65   $
��20 0q�6C   $��13(�6Q    d� 	IsChecked$
 TrueY�6`   	� 5      -   5        $ 
rb1024bits��5   "   $
��1024��66   $
��20 0q�6E   $��13(�6S   	� 5       -   5        $ 
rb2048bits��5    "   $
��2048��66   $
��20 0q�6E   $��13(�6S   	� 5!      -   5        $ 
rb4096bits��5!   "   $
��4096��66   $
��20 0q�6E   $��13(�6S   5"      � 5#       5$      �� 5%      �� 5&      .+�5)      �� $��	0 10 15 0q�6!   $��0��64   .+�5*      �� $��0��6    $��2��60   $��0��6D   $��0q�6Q   $��13(�6]   $��0 0 0 5q�6k   .��6|   Khóa công khai:5,      �� 5-      -   5         ��Name$ tbPublicKey��5-   m   $	��4 2q�6"   $��0��60   $��2��6@   $��1��6T   $��80��6a    �� 
IsReadOnly$
 True��6�   	 �� TextWrapping$
	 Wrap=�6�   
 �� AcceptsReturn$

 True��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   5.      �� 50      $��	15 10 0 0q�6!   $��1��64   .+�51      �� $��0��6    $��0��60   $��2��6=   $��0q�6Q   $��13(�6]   $��0 0 0 5q�6k   .��6|   Khóa bí mật:53      �� 54      -   5        $ tbPrivateKey��54   m   $	��4 2q�6"   $��0��60   $��1��6@   $��2��6M   $��80��6a   $
 True��6�   $
	 Wrap=�6�   $

 True��6�   $
 Auto=�6�   55      56      �� 57      $��0 15 0 0q�6   .+�58      �� -   5         ��Name$ btnCreateKey��58   <    	  myBtn#��[  6   $	��150��6R   $	��0 5q�6^   $��13(�6l   .��59      �� $ 
Horizontal=�6%   .+�5:      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.2.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$	 Key=�6+     	myBtnIcon#��[ 66   �� 5;      Tạo khóa62   5<      5=      5>      5?      5@      �� 5C   
   $��0��6   $��1��6#   $��15 10q�60   $
��10 5q�6?   
�������.��5D      �� .+�5E      �� $
��16px(�6   $
��Bold"�6,   $��Center=�6>   $	��0 5q�6[   Gửi5G      �� 5H      .+�5I      �� -   5        $ btnKy��5I   <   #��[  6   ${�False��6K   $	��150��6]   $	��0 5q�6i   $��13(�6w   .��5J      �� $ 
Horizontal=�6%   .+�5K        $ FileSignature=�6+   #��[ 6@   �� 5L      �� 6)   $�Thực hiện ký��6-   6D   5M      5N      5O      �� 5P      .+�5Q      � $��0 0 0 5q�6    5R      �� 5S      $��* �6/   �� 5T      $	��120 �6/   .+�5V      �� $��0��6    $��0q�60   $��13(�6<   $��30��6J   $��Bottom=�6V   .��6x   Văn bản:5X      �� 5Y      $��1��6%   $��5 0 0 0q�65   .+�5Z      �� -	   5        $ btnVanBanGui��5Z   D   #��[  6%   .��5[   "   �� $ 
Horizontal=�6-   .+�5\   &     #��[ 63   $ FileCirclePlus=�6V   �� 5]   &   Chọn file6;   5^   #   5_      5`      5a      � 5b      .+�5c      �� -
   5        $ tbVanBan��5c   =   $	��1 2q�6"   $	��150��60   $
	 Wrap=�6O   $

 True��6c   $
 Auto=�6x   �� 5d      -   5         ��Name$ webContainerGui��5d   !   
�������$��1 0 0 1q�6M   ._�5e      �� .+�5f   "   (  "System.Windows.Controls.WebBrowser  -   5          Name$ webGui��5f   -   $	��150��6=   5g      5h      5i      5j      �� 5k      $ 
Horizontal=�6   .+�5l      �� -   5        $ btnSave��5l   <   #��[  6   $	��150��6M   $	��0 5q�6Y   $��13(�6}   $
��10 0q�6�   .��5m      �� $ 
Horizontal=�6%   .+�5n        $
 Save=�6+   #��[ 67   �� 5o      �� 6)   $�Lưu chữ ký��6-   6B   5p      5q      �� 5r      -   5        $ 	btnChuyen��5r   <   #��[  6   $	��150��6O   $	��0 5q�6[   $��13(�6�   $
��10 0q�6�   .��5s      �� $ 
Horizontal=�6%   .+�5t        $ 
PaperPlane=�6+   #��[ 6=   �� 5u      �� 6)   $�Chuyển��6-   6>   5v      5w      �� 5x      $
��0 10q�6!   $ 
Horizontal=�6/   $��Center=�6H   .+�5y      �� -   5        $ btnResetSender��5y   @   #��[  6!   $	��150��6X   $	��0 5q�6d   $��13(�6�   $
��10 0q�6�   .��5z      �� $ 
Horizontal=�6)   .+�5{   "     $ Refresh=�6/   #��[ 6>   �� 5|   "   �� 6-   $�Refresh��61   6C   5}      5~      5      5�      �� 5�      .+�5�      �� $��0q�6   $��13(�6(   $��0 0 0 5q�66   $��30��6G   $��Bottom=�6S   .��6u   
Chữ ký:5�      �� 5�      -   5        $ tbChuKy��5�   J   $	��4 2q�6   $
{�True��6,   $	��100��6=   $
 True��6[   $
	 Wrap=�6m   $

 True��6�   $
 Auto=�6�   5�      5�      5�      �� 5�   
   $��1��6   $��1��6#   $��15 10q�60   $
��10 5q�6?   
�������.��5�      �� .+�5�      �� $
��16px(�6   $
��Bold"�6,   $��Center=�6>   $	��0 5q�6[   Nhận5�      �� 5�      .+�5�      �� -   5        $ 
btnKiemTra��5�   <   #��[  6   $	��150��6P   $	��0 5q�6\   $��13(�6j   .��5�      �� $ 
Horizontal=�6%   .+�5�        $ FileCircleCheck=�6+   #��[ 6B   �� 5�      �� 6)   $�Kiểm tra chữ ký��6-   6G   5�      5�      5�      �� 5�      .+�5�      � $��0 0 0 5q�6    5�      �� 5�      $��* �6/   �� 5�      $	��120 �6/   .+�5�      �� $��0��6    $��0q�60   $��13(�6<   $��Bottom=�6J   .��6l   Văn bản:5�      �� 5�      $��1��6%   $��5 0 0 0q�65   .+�5�      �� -   5        $ btnSelectFileDataReceiver��5�   %   #��[  6H   .��5�   "   �� $ 
Horizontal=�6-   .+�5�   &     #��[ 63   $ FileCirclePlus=�6V   �� 5�   &   Chọn file6;   5�   #   5�      5�      5�      � 5�      .+�5�      �� -   5        $ tbVanBanNhan��5�   =   $	��1 2q�6"   $	��150��60   $
	 Wrap=�6S   $

 True��6g   $
 Auto=�6|   �� 5�      -   5        $ webContainerReceiver��5�   !   
�������$��1 0 0 1q�6R   ._�5�      �� .+�5�   "     -   5        $ webReceiver��5�   -   $	��150��6B   5�      5�      5�      5�      �� 5�      .+�5�      � $��0 0 0 5q�6    5�      �� 5�      $��* �6/   �� 5�      $	��120 �6/   .+�5�      �� $��0��6    $��0q�60   $��13(�6<   $��Bottom=�6J   .��6l   
Chữ ký:5�      �� 5�      -   5        $ btnSelectSignature��5�   P   $��1��6!   #��[  61   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ FileCircleCheck=�6/   #��[ 6F   �� 5�   "   Chọn file67   5�      5�      5�      �� 5�      -   5        $ tbChuKyNhan��5�   J   $	��4 2q�6   $
{�True��6,   $	��100��6=   $
	 Wrap=�6_   $

 True��6s   $
 Auto=�6�   �� 5�      $
��0 10q�6!   $ 
Horizontal=�6/   $��Center=�6H   .+�5�      �� -   5        $ btnResetReveiver��5�   @   #��[  6!   $	��150��6Z   $	��0 5q�6f   $��13(�6�   $
��10 0q�6�   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ Refresh=�6/   #��[ 6>   �� 5�   "   �� 6-   $�Refresh��61   6C   5�      5�      5�      5�      5�      5�      5�      5�      