   M S B A M L   `   `   `  ����G  CTimeSheetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TimeSheetApp.ViewTimeSheetApp.View  5   	   $    TimeSheetApp.View.UserTimeView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TimeSheetApp.View     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1.command http://www.galasoft.ch/mvvmlight  5	   	     � Title$  UserTimeView��5   	   $	��664��6   $	��NaN��6+    � DataContext 5   	   �� *UserTimeViewModelVm+   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   6*   �� 5      $
��Auto �6   $	��433��6*   6<   .+�5   
   �� $��0��6   
�������$��1q�61   ._�5      � $��0��6   $
��Left=�6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   66   .+�5      ]� $��10,0,0,0q�6   .+�5      ��   
ButtonMenu#���  6�    � ToolTip$ Retour��6�   ��6   �� *RetourAvecVerificationCommand+��6Q   0  *MaterialDesignThemes.Wpf.PackIconExtension  *ArrowLeftBold+5      �� 5      #���  6p   $ Sauvegarder��6�   ��6   �� *SauverCommand+��6@     *ContentSave+{�6�   �� *IsUnSelectionnE+5      �� 5      #���  6J   $ 
Actualiser��6�   ��6     *	Refresh+��6o   �� *ActualiserCommand+6�   �� 5      #���  6   $ 
Historique��6�   ��6     *FormatAlignCenter+��6T   �� *AfficherHistoryCommand+{�6�   �� *IsUnSelectionnE+6�   5!      5"      5#      � 5%   
   $��1��6   $��0,3,0,10q�6    5&      �� 5'      $	��304 �6    .+�5*      &   System.Windows.Controls.DataGrid     AlternatingRowBackground �#ebefef$	��304��6;   $	��Top=�6H   $��0,0,0,0q�6`    �� AlternationCount$ 2��6q      
IsReadOnly . 	   AutoGenerateColumns	 .  ��6�   �� *LstVTaskTime+
 �� Mode$
 TwoWay=� �� SelectedItem 6�   �� *	Selection+$
 TwoWay=�   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ 
ID TacheUT��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *TaskUserTimeID+$
 TwoWay=�6o     5-      $ Nom du projet��6)   $ * 6p    6A   �� *ProjectName+$
 TwoWay=�6p     5.      $ Nom de la tache��6)   $ * 6n    6C   �� *
TaskName+$
 TwoWay=�6n     5/      $ 
Date debut��6)   $ * 6�    6>   �� *	startDate+ �� StringFormat$ {0:dd/MM/yyyy HH:mm:ss}��$
 TwoWay=�6�     50      $ Date fin��6)   $ * 6�    6<   �� *	EndDate+$ {0:dd/MM/yyyy HH:mm:ss}��$
 TwoWay=�6�   .  (System.Windows.Interactivity.Interaction   Triggers 52      /  )System.Windows.Interactivity.EventTrigger  53         	EventName$ MouseDoubleClick��6%   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 54      /
  )GalaSoft.MvvmLight.Command.EventToCommand
   
  Command 61   �� *AfficherHistoryCommand+ 
  CommandParameter 55   !   �� *	Selection+56      58      �� 59      $��30��6   $��Bottom=�6!   
�������$��1q�6O   $��	0,0,0,-30q�6c   ._�5:      �� ��6   �� *
NbResult+$
 TwoWay=�6F   5;      5=      � 5?   
   $��2��6   $��
0,0,0,-110q�6   $��Bottom=�60   $	��205��6K   .+�5@      �� $��0,0,0,10q�6   .+�5A      �� $��Center=�6   $	��760��6:   $��0,0,0,0q�6F   $	��209��6W   .+�5B      �� $��Projet��6   $��30��6-   $��70��69   $��	70,20,0,0q�6D   $
��Left=�6W   �� 5C      $��30��6R   $��
70,-30,0,0q�6^   $	��500��6r   {�.  ��6   �� *Selection.ProjectName+$
 TwoWay=�6~   �� 5D      $��Tache��6   $��30��6,   $��70��68   $��	70,20,0,0q�6C   $
��Left=�6V   �� 5E      $	��500��6O   $��30��6[   $��
70,-40,0,0q�6g   {�.  ��6   �� *Selection.TaskName+$
 TwoWay=�6{   5F      ]� 5G      $	��100��6   $��
0,-120,0,0q�6)   .+�5H      �� $	��110��6!   $
��Left=�6.   $��	420,0,0,0q�6I   $	��300��6\   .+�5I      �� $��
Date debut��6    $��30��65   $	��100��6A   $��0,20,0,0q�6M   $
��Left=�6_   (  "System.Windows.Controls.DatePicker  5J      $��
60,-40,0,0q�6b   $	��170��6v   $��30��6�      SelectedDate 6%   �� *TaskUserTime.startDate+$
 TwoWay=�{�6�   �� *IsUnSelectionnE+�� 5K      $��Date fin��6    $��30��63   $	��100��6?   $��0,20,0,0q�6K   $
��Left=�6]     5L      $��
60,-40,0,0q�6`   $	��170��6t   $��30��6�    6%   �� *TaskUserTime.EndDate+$
 TwoWay=�{�6�   �� *IsDateFinExiste+$
 TwoWay=�5M      �� 5O      $	��110��6!   $��Right=�6.   $��	0,0,400,0q�6J   $	��320��6]   .+�5P      �� $��Heur début��6    $��30��65   $	��100��6A   $��	10,10,0,0q�6M   $
��Left=�6`   )  #MaterialDesignThemes.Wpf.TimePicker  5Q      $��
60,-30,0,0q�6e   $	��170��6y   $��30��6�      SelectedTimeFormat$
 Long=�6�      SelectedTime 64   �� *
StartHeure+$
 TwoWay=�{�6�   �� *IsUnSelectionnE+6�   �� 5R      $��Heur de fin��6!   $��30��67   $	��100��6C   $��	10,20,0,0q�6O   $
��Left=�6b     5S      $��
60,-30,0,0q�6d   $	��170��6x   $��30��6�   $
 Long=�6�    65   �� *
EndHeure+$
 TwoWay=�{�6�   �� *IsDateFinExiste+$
 TwoWay=�6�   5T      5U      5W      5Y      5\       � 	Resources 5^       �� 
TargetType �� Property �� Value��%�   &	       �� 5_   
   " ��6#   .�5`      ��  � ��
 �����6+   �� 5a       � ��$ 2q�6'   �� 5b       � ��$ 35��6&   63   �� 5c       � ��$ 30��6'   64   �� 5d       � ��
 �����6=   5e      5f      5j      