   M S B A M L   `   `   `  ����I  EIT_3S_Kursovik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:IT_3S_KursovikIT_3S_Kursovik  5          IT_3S_Kursovik.MenuPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:IT_3S_Kursovik     5        N� Title$  MenuPage��5	       � 	Resources 5
         CommonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��6$   .�5      ��  � ��$ Better VCR Regular)�6+   6H   �� 5       � ��$ 36(�6)   66   �� 5       � ��$
 Bold"�6+   6:   �� 5       � ��$ 40��6'   64   �� 5       � ��$	 219��6&   64   �� 5       � ��$	 Top=�62   6@   �� 5       � ��$
 Left=�64   6C   �� 5       � �� �	#007070706@   �� 5       � �� �	#007070706?   �� 5       � �� 5      �� 5      " ��6&   .R�5      � #��z��6   .+�5      �� 5      5      5        5!      P� 5"       �@J�IsMouseOver$
 True��61   . �5#      ��  � �� �	#FF132FA463   5$      5&      5'      .��5(      � 	 � ColumnDefinitions	 5)   
   �� 5*      $	��11* �6   �� 5+      $	��14* �6   �� 5,      $	��11* �6   
 � RowDefinitions
 5.   
   �� 5/      �� 50      $��4* �6   ��52   
   �� 53       �� ImageSource$ /assets/FonForMenu.jpg��6    j� Stretch$ UniformToFill=�6>   .+�56   
   �� $��2��6   $
��Left=�6    $	��348��6;   $��	10,75,0,0q�6H   $��1��6[   $	��Top=�6h   $	��324��6�   $$��/assets/Pixel-Art-1366x768.png��6�   �� 58   
   -   5        #��[  58      $��2��59      $��1��5:      $��
32,122,0,0q�5;      $��Новая игра��5<      $��53��5=   (   $	��275��64   �� 5>   
   -   5        #��[  5>      $��2��5?      $��1��5@      $��
32,181,0,0q�5A      $��Рекорды��5B      $��53��5C   ,   $	��275��68   �� 5D   
   -   5        #��[  5D      $��2��5E      $��1��5F      $��
32,300,0,0q�5G      $��  Выход  ��5H       J� RenderTransformOrigin$ 0.502,0.592&�5J      $��52��65   $	��275��6A   �� 5K   
   -   5        #��[  5K      $��2��5L      $��1��5M      $��
32,240,0,0q�5N      $��Бестиарий��5O      $��53��5P   *   $	��275��66   �� 5R   
   -   5         ��Name$ rotatingImage��5R      $��1��6(   $��Center=�5S      $	��Top=�6.   $	��350��5T      $��	0,-24,0,0q�6   $	��119��61   $ 0.25,-0.018&�5U      $��	/hook.png��5V      $��UniformToFill=�6$   $��2��6<   z�5X      �� 5Y      -   5        rotateTransform��5Y   "    � Triggers 5[      :� 5\       :� RoutedEvent$ Loaded��6   .[�5]      �� .��5^      �� .��5_      U�  g� RepeatBehavior$ Forever��6<    �� 
TargetName$ rotateTransform��5`   <    �� TargetProperty$ Angle�5a   <   .\�5c   "   9  3System.Windows.Media.Animation.EasingDoubleKeyFrame   O� Value$ 15Q�67    O� KeyTime$ 0:0:0��6B      EasingFunction 5d   &   2  ,System.Windows.Media.Animation.QuadraticEase  5e   *   7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode$ 	EaseInOut=�68   5g   #     5i   "   $	 -15Q�67   $ 0:0:3��6C    5j   &     5k   *   $ 	EaseInOut=�68   5m   #     5o   "   $ 15Q�67   $ 0:0:6��6B    5p   &     5q   *   $ 	EaseInOut=�68   5s   #   5t      5v      5w      5x      5z      �� 5{   
   $��Center=�6   $
��Wrap=�5|      $	��Top=�5}      $	��602��5~      $��72(�5       �� TextAlignment$ Center=�5�      $��Better VCR Regular)�5�      $
��Bold"�5�      $��-285,21,0,0q�6   $��3��63   $��1��6G   $��2��6W   �� 5�       � Language$ ru-ru�6
   $�Рыбалка 2.0��6   5�      5�      5�      