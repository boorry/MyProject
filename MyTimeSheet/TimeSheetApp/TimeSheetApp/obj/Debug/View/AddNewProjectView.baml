   M S B A M L   `   `   `  ����  TimeSheetApp)    #TimeSheetApp.View.AddNewProjectView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1.command http://www.galasoft.ch/mvvmlight  5        � DataContext  5	      �� *AddNewProjectView+   Locator �� Source# [  .��5
      � .+�5   
   �  � RowDefinitions 5      �� 5      $��45 �6    �� 5      $��35 �6    �� 5      $��24 �6    .+�5      �� 
���iii�$��45��6+   $��1q�67   ._�5      ]� $��45��6   $
��Left=�6(   $	��Top=�6C   .+�5      ��   MyButton#���  6   $��20,0,0,0q�6@   $��0q�6{   $
��Left=�6�   ��6R   �� *ReturnTolistProject+��6�   0  *MaterialDesignThemes.Wpf.PackIconExtension  *UndoVariant+6�   �� 5      #���  6   $��10,0,0,0q�6@   $��0q�6v   $
��Left=�6�   ��6R   �� *AddedSaveChange+��6�     *ContentSave+6�   5      5      5      �� 5   
   $��36��6   $	��Top=�6   $��0,44,0,0q�65   
���iii�$��1q�6]   ._�5      ]� .+�5      �� $��25��6   
���iii�$	��100��6>   $��10,5,0,0q�6J   $��DemiBold"�6\   $��14(�6r   $
��Left=�6�   $��Nouveau Projet��6�   5      5      � 5   
   .+�5      �� $	��Top=�6   $
��Left=�61   $	��602��6L   $	��398��6Y   $��	75,84,0,0q�6e   .+�5       �� $��Nom de Projet��6   
���iii�$��20��6F   $	��Top=�6R   $��DemiBold"�6j   $��13(�6�   $	��100��6�   $
��Left=�6�   $��	10,30,0,0q�6�   �� 5!      -   5         ��Name$
 Tex1��5!      
���iii�$��25��6>   $	��Top=�6J   $	��190��6i   $��120,-25,0,0q�6u   $
��Left=�6�   $	��Top=�6�   ��6�   �� *NewProjectName+ �� Mode$ TwoWay=�.��6�   5#      �� 5$      $��Description��6   
���iii�$��20��6D   $��DemiBold"�6P   $
��Left=�6f   $��13(�6�   $��	10,25,0,0q�6�   �� 5%      $	��100��6   
���iii�$	��190��6<   
�������$��1q�6`    �� TextWrapping$
 Wrap=�6t    �� AcceptsReturn . $	��Top=�6�   $��120,-20,0,0q�6�   $
��Left=�6  $	��Top=�6  ��6�   �� *DescriptionProject+$ TwoWay=�6  �� 5&      $��Client��6   
���iii�$��20��6?   $��DemiBold"�6K   $
��Left=�6a   $��13(�6|   $��	10,20,0,0q�6�   �� 5'      $��25��6   
���iii�$	��190��6;   $	��Top=�6G   $��120,-25,0,0q�6�   $
��Left=�6�   $	��Top=�6�   ��6f   �� *AddCustomerName+$ TwoWay=�6�   �� 5(      $��20��6   $��20��6%    � ToolTip$ Client��60   $��0q�6m   
�������
�������$��250,-25,0,0q�6�   ��6A     *	Magnify+��6y   �� *GotoClientList+6�   �� 5)      $��Date de Debut��6   
���iii�$��20��6F   $��DemiBold"�6R   $
��Left=�6h   $��13(�6�   $��	10,20,0,0q�6�   (  "System.Windows.Controls.DatePicker  5*      $��25��6   
���iii�$	��Top=�6>   $	��190��6�   $��120,-25,0,0q�6�   $
��Left=�6  $	��Top=�6/     SelectedDate 6]   �� *StartDateProject+$ TwoWay=�	 �� NotifyOnValidationError	 . 
 �� UpdateSourceTrigger$
 PropertyChanged=� �� ValidatesOnDataErrors . 6/  �� 5+      $��Durée Estimée��6   
���iii�$��20��6F   $��DemiBold"�6R   $
��Left=�6h   $��13(�6�   $��	10,20,0,0q�6�   �� 5,      $��25��6   /  )MaterialDesignThemes.Wpf.ValidationAssist   UsePopup . $��90��6V   $	��Top=�6a   $��120,-25,0,0q�6�   $
��Left=�6�   $	��Top=�6�   .��6�   ��5-      �� 5.       �� Path$ EstimateDuration�6"   $
 PropertyChanged=�6:    �� ValidationRules 5/      5  /System.Windows.Controls.ExceptionValidationRule  50   "   52      .��53   $   54      �� 55      $��heures��6   $��20��6+   
���iii�$��DemiBold"�6L   $
��Left=�6b   $��11(�6}   $��220,-19,0,0q�6�   �� 56      $��Tâches��6   
���iii�$��20��6?   $��DemiBold"�6K   $
��Left=�6a   $��13(�6|   $��	10,20,0,0q�6�   �� 57      $��25��6   
�������$	��240��69   $	��Top=�6E   $��120,-25,0,0q�6d    �� DisplayMemberPath$ TaskName��6�   $
��Left=�6�   $	��Top=�6   �� SelectedItem 6y   �� *AddTaskProject+$ TwoWay=���6�   �� *AddTaskList+$ OneWay=�.  (System.Windows.Interactivity.Interaction   Triggers 58      /  )System.Windows.Interactivity.EventTrigger  59         	EventName$ MouseDoubleClick��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5:      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 65   �� *AddNewTaskProject+   CommandParameter 6[   �� *AddTaskProject+5;      5=      �� 5>      $ Ajouter��6B   $��0q�6T   
�������
�������$��20��6�   $��360,-25,0,0q�6�   $��20��6�   ��6     *Plus+��6`   �� *AddNewTaskProject+6�   �� 5?      $
��Auto=�6   $	��100��6B   $	��240��6O   $��	80,20,0,0q�6[   $
��Auto=�6n   .��5@      �� .@�5A      �� 
�������$��1q�6k   $ TaskName��6�   $	��240��6�   $	��100��6�   ��6"   �� *ListTacheProject+$ TwoWay=� 6   �� *RemoveMyTask+$ TwoWay=� 5B        5C   "   $ MouseDoubleClick��61   . 5D   &      6=   �� *RemovMyTaskCommand+ 6d   �� *RemoveMyTask+5E   #   5G      5H      5I      �� 5J      $ Enlever��6C   $��0q�6U   
�������
�������$��20��6�   $��360,-180,0,0q�6�   $��20��6�   ��6     *Minus+��6a   �� *RemovMyTaskCommand+6�   5N      �� 5P      $	��Top=�6   $��Right=�62   $	��592��6N   $	��354��6[   $��
0,84,300,0q�6g   .+�5Q      �� $��Céateur��6   
���iii�$��20��6@   $	��Top=�6L   $��DemiBold"�6d   $��13(�6z   $	��100��6�   $
��Left=�6�   $��	10,30,0,0q�6�   �� 5R      $��25��6   {�.  
���iii�$	��Top=�6M   $��150,-25,14,0q�6�   $	��Top=�6�   ��6l   �� *CreatorProject+$ TwoWay=�6�   �� 5S      $��Date de Création��6   
���iii�$��20��6I   $	��Top=�6U   $��DemiBold"�6m   $��13(�6�   $	��130��6�   $
��Left=�6�   $��	10,30,0,0q�6�   �� 5T      $��25��6   {�.  
���iii�$	��Top=�6M   $	��190��6l   $��150,-25,0,0q�6�   $
��Left=�6�   $	��Top=�6�   ��6x   �� *CreationDate+$ TwoWay=�6�   5U      5W      5X       � 	Resources 5Y       �� 
TargetType �� Property �� Value��%�   &	       �� 5[   
   " ��6!   .�5\      ��  � ��
 �����6+   �� 5]       � ��$ 2q�6'   �� 5^       � ��$ 35��6&   63   �� 5_       � ��$ 30��6'   64   �� 5`       � ��
 �����6=   5a      5c      5d      