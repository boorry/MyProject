   M S B A M L   `   `   `  ����G  CTimeSheetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TimeSheetAppTimeSheetApp  5   	       TimeSheetApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TimeSheetApp     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1.command http://www.galasoft.ch/mvvmlight  5	   	     � Title$  
MainWindow��5   	   $	��NaN��6   $	��NaN��6)    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5   	   �� *Main+   Locator �� Source# [  ��5   	   �� *
MinWidth+��5   	   �� *	MinHeight+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closing��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command 6%   �� *WindowClosing+6G   5      .��5      � .+�5      �� 
�������$��1q�6    ._�5   
   � .+�5      � -   5        	 �Name$	 MyGrid1��5      
 � RowDefinitions
 5      �� 5       $��82 �6$   �� 5!      $��32 �6$   �� 5"      $��32 �6$   .+�5$      �� $��82��6   
�������$��0,0,0,1q�68   
�������$	��Top=�6i   $��0,0,0,0q�6�   ._�5%      ]� .+�5&      �� $��60��6    $	��100��6,   $��	20,15,0,0q�68   $!��Resource/logo_auxipress.png��6K   �� 5'      $��	TimeSheet��6$   $��DemiBold"�65   
�������$��14(�6]   $��	0,0,5,-10q�6k   $��25��6~   $��70��6�   $��Right=�6�   5(      5)      5*      �� 5,      $��32��6   
�������$��0,1,0,1q�64   
�������$	��Top=�6e   $��0,79,0,0q�6}   ._�5-      ]� .+�5.      �� 
�������$��DemiBold"�6O   $��13(�6e   $��20��6s   $	��150��6   $
��Left=�6�   $��10,5,0,0q�6�   ��6    �� *Utilisateur+6�   �� 5/      $��Version 1.0.0��6    $��DemiBold"�65   
�������$��12(�6a   $��	0,0,5,-10q�6o   $��15��6�   $��Right=�6�   50      51      � 52      $��	0,111,0,0q�6    � ColumnDefinitions 53      �� 54      $	��170 �6'   �� 55      $��* �6'   .+�57      �� 
�������
�������$��0,0,1,0q�6C   ._�58      �� $��0,0,0,0q�6!   .+�59      �� .+�5:      �� $
��Left=�6%   $��1,0,0,0q�6@     MyColor#���  6Q   $��1q�6s   $��45��6�   $	��167��6�   ��6�   �� *SortirCommande+.��5;   "   ]� $	��150��6,   .+�5<   &   �� $��Resource/export.png��6,   $��30��6I   $
��Left=�6U   $��15,0,0,0q�6p   $��20��6�   �� 5=   &   $��Sortir��60   $��20��6>   $��40��6J   
���iii�$��DemiBold"�6j   $��10,0,0,0q�6�   $
��Left=�6�   $��14(�6�   5>   #   5?      5@      �� 5A      $	��165��6%   $	��200��61   
�������$��0,2,0,0q�6U   .+�5B   "   �� $��0,0,0,0q�6W     MyColorChange#���  6q   $��DemiBold"�6�   $��45��6�   ��6)   �� *AllerSurTimeSheetCommande+.��5C   "   ]� $��45��6W   $	��165��6c   $��0,0,0,0q�6o   ��6,   �� *BackGroundTimeSheet+.+�5D   &   �� $��25��6,   $��22,0,0,0q�68   $��20��6J   $��Resource/timer.png��6U   �� 5E   &   
���iii�$��0,6,0,0q�6A   $��13(�6R   $��	TimeSheet��6`   5F   #   5G      �� 5I   "   -   5         ��Name$ ButtonProjet��5I   )   #���  6^   $��0,0,0,0q�6�   $��45��6�   ��6?   �� *
GoToProjet+.��5J   &   ]� $��45��6[   $	��165��6g   $��0,0,0,0q�6s   ��60   �� *MyBackGroundProject+.+�5K   *   �� $��25��60   $��25,0,0,0q�6<   $��20��6N   $
��Left=�6Y   $��Resource/folder.png��6t   �� 5L   *   
���iii�$��0,8,0,0q�6E   $��13(�6V   $��Projets��6d   5M   #   5N      �� 5O   "   $��0,0,0,0q�6S   #���  6d   $��0,0,0,0q�6�   $��45��6�   ��6)   �� *AllerSurTacheCommande+.��5P   &   ]� $��45��6V   $��0,0,0,0q�6b   $	��165��6s   ��60   �� *BackGroundTask+.+�5Q   *   �� $��25,0,0,0q�60   $��25��6B   $��20��6N   $��Resource/buffer.png��6Y   �� 5R   *   $��0,8,0,0q�60   
���iii�$��13(�6V   $��Tâches��6d   5S   '   5T      5U      5V      5W      5X      � 5Y      $��170,110,0,0q�6   .+�5Z      >� ��6   �� *CurrentView+ �� Mode$ OneWay=�5[      5\      5]      5^       � 	Resources 5`       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  &	       &	 �    �� 5a   
   " ��6&   .�5b      ��  � ��
 �����6+   �� 5c       � �� 5d      �� 5e      " ��6&   .R�5f      �� #��z��6!   ._�5g      �� $��Center=�6/   $��Center=�6L   5h      5i      5k       5l      P� 5m       �@J�IsMouseOver . . �5n      ��  � �� �#318CE76:   5o      P� 5p       � ��$
 True��66   . �5q      ��  � �� �#318CE76:   5r      5t      �� 5v   
   " ��6    .�5w      ��  � ��
 �����6+   �� 5x       � �� 5y      �� 5z      " ��6&   .R�5{      �� #��z��6!   ._�5|      �� $��Center=�6/   $��Center=�6L   5}      5~      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      ��  � ��
 �����6:   5�      P� 5�       � ��$
 True��66   . �5�      ��  � ��
 �����6N   5�      5�      5�      5�      