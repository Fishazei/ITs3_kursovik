   M S B A M L   `   `   `  ����I  EIT_3S_Kursovik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:IT_3S_KursovikIT_3S_Kursovik  5      !    IT_3S_Kursovik.MainGamePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:IT_3S_Kursovik     5      -   5          N� Title$  MainGamePage��5	       � 	Resources 5         SomeButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType��%�   &	        �� 5   
   " ��6(   .�5      ��  � ��
 ���� 6+   �� 5       � �� 5      �� 5      " ��6&   .R�5      � #��z��6   .+�5      �� 5      5      5      5      5      .��5      � $
|�True��6    � RowDefinitions 5   
   �� 5      $
��128* �6   �� 5      $
��547* �6   ��5"   
   �� 5#       �� ImageSource$ /assets/fon.png��6    j� Stretch$ Uniform=�67   .+�5'   
   �� -   5        	 ��Name$	 pointsTextBlock��5'      $��23(�6-   $��Better VCR Regular)�6;   $
��Left=�6[   $��50��6v   $��	35,70,0,0q�6�   $
��Wrap=�6�   $��OP: 0��6�   $	��Top=�6�   $	��218��6�   "   IT_3S_Kursovik.CircusTimerUC  5)   
   -   5        
  Name$
 cpb_uc��5)      $��304,95,772,492q�6.   $��2��6F      IT_3S_Kursovik.PauseUC  5,   
   -   5          Name$ PauseMenuUC��5,      $��400,37,400,37q�6-   $��2��6D    J� RenderTransformOrigin$ 
0.502,0.52&�6U   $y�	Collapsed=�6x   �� 5.   
   -   5        #��[  5.      $
��Left=�6S   $��
1037,5,0,0q�6n   $	��Top=�6�   ���	#00707070���	#00707070$��75��6�   $��75��6�   .��5/      �� $��/assets/pb.png��6   $��75��6,   $��75��68   50      �� 53   
   -   5         ��Name$ 
MainCanvas��53      $��568,0,568,0q�6%   $��2��6:   .+�54      �� -   5         ��Name$
 rope��54      $��Center=�6"   $	��144��6?   $��64��6L   $	��Top=�6W    �� Left$ 0��6o   
 �� Top$ 60��6   $��/assets/rope.png��6�   $
��Fill=�6�   �� 55      -   5        $
 rec1��55      $
��Left=�6"   $��98��6?   $��64��6L   $	��Top=�6W   $ 0��6o   $	 203��6   $��/assets/hook.png��6�   56      �� 59   
   -	   5        $ 	RiverHold��59      $��1��6$   5;      5<      5=      