   M S B A M L   `   `   `  ����@  <Tkani, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Tkani.WindowsTkani.Windows  5   	   0    *Tkani.Windows.Product_Administartor_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Tkani.Windows     5   	     � Title$"  Product_Administartor_Window��5   	   $	��720��5	   	   $
��1280��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	   .��5      (� .��5   
   �  � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��50 �6    �� 5      .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   $��Right=�6?   $��Center=�6[   $��5q�6v   .+�5      �� -   5         ��Name$ FIO_User��5      $
��Left=�6*   $	��Top=�6E   $�� ��6]   $��Comic Sans MS)�6h   �� 5      -   5         ��Name$ Exit_BTN��5      $��
Выход��6+   ���	#FF498C51$
��Left=�6i   $	��Top=�6�   $��Comic Sans MS)�6�   $��5q�6�   5      �� 5      -   5        $ Insert_Tovar_BTN��5   "   $��0��6   ���	#FF498C51$!��Добавить товар��6S   $
��Left=�6�   $��5q�6�   $��5q�6�   $��Center=�6�   $��Comic Sans MS)�6�   �� 5      -   5         ��Name$ tb_SearchProduct��5      ���	#FF498C51 � ToolTip$! Поиск продукта��6r   $��1��6�   $��5q�6�   $��5q�6�   $��Comic Sans MS)�6�   $
��Left=�6�   $��Center=�6�   $��Center=�6  $	��300��6"  �� 5      -   5        $ 	Search_LB��5      $��1��6'   ���	#FF76E383$��Center=�6K   $��Center=�6h   $��Center=�6�   $��Comic Sans MS)�6�   �� 5       -   5        	 ��Name$	 
Product_LV��5    H   $��2��6   $��5q�6$   $	��400��6/   $	��950��6<   $��Comic Sans MS)�6\   
 �� SelectionMode$
 Single=�6w   $��Stretch=�6�    � ContextMenu 5!      �� 5"      .@�5#      m� -   5         m�Name$ Product_Delete_BTN��5#   #   $��Удалить��6?    m� Icon$
 💀��6P   $��Comic Sans MS)�6Z   6u   5$      ��5&      �� 5'      .R�5(      �� $ 
Horizontal=�6%   $��5q�6>   $	��120��6I   .+�5)      �� $��2q�6%   
���   �$��5q�6M   ._�5*   "   � .+�5+   &   �� $��/Images/picture.png��6,   $	��100��6I   $	��150��6V   �� 5,   &   $	��100��6E   $	��150��6R   $
��Fill=�6^   ��6,   �� *Image+6^   5-   #   5.      �� 5/      $��1q�6%   
���   �$��5q�6M    �� Padding$ 5q�6X   ._�50   "   �� $��Stretch=�6-   $��Center=�6K   $	��590��6f   .+�51   &   �� $
��Wrap=�6N   $
��Bold"�6b   $��Comic Sans MS)�6t   ��60   �� *Product_Name+6t   �� 52   &   $
��Wrap=�6M   $��Comic Sans MS)�6a   ��60   �� *Description+6a   �� 53   &   $
��Wrap=�6N   $��Comic Sans MS)�6b   ��60   �� *Manufacturer+6b   �� 54   &   $��Comic Sans MS)�6F   ��60   �� *Cost+6F   55   #   56      �� 57      $��2q�6%   
���   �$��5q�6M   $ 5q�6X   ._�58   "   �� $	��100��6F    �� TextAlignment$ Center=�6R   $��Center=�6i   $��Center=�6�   $��Comic Sans MS)�6�   ��6,   �� *
Quantity+6�   59      5:      5;      ��5=      �� 5>       �� 
TargetType" ��6   .�5?      ��  �� Property � �� �� Value �	#FF76E3836K    �� Triggers 5@      �� 5A       �� Binding 6*   �� *
Quantity+ �� Value 06G   .a�5B   "   ��  � �� �	#FFD0CDCD6S   5C      5E      5G      5H      5I      5J      