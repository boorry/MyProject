   M S B A M L   `   `   `  ����G  CTimeSheetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TimeSheetApp.ViewTimeSheetApp.View  5      (    "TimeSheetApp.View.DetailProjetView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TimeSheetApp.View     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1.command http://www.galasoft.ch/mvvmlight  5	        � DataContext  5      �� *DetailProjetView+   Locator �� Source# [  .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $��45 �6    �� 5      $��35 �6    �� 5      $��24 �6    .+�5      �� 
�������$��1q�6,   ._�5      ]� $��45��6   $
��Left=�6(   $
��auto��6C   .+�5      ��   MyButton#���  6    � ToolTip$ Retour��6f   $��0q�6w   $��10,0,0,0q�6�   $
��Left=�6�   ��6@   �� *BackToHomeProject+��6�   0  *MaterialDesignThemes.Wpf.PackIconExtension  *UndoVariant+6�   �� 5      #���  6   $ Enregistrer��6e   $��0q�6{   $��10,0,0,0q�6�   $
��Left=�6�   ��6@   �� *DetailSaveChange+��6�     *ContentSave+6�   �� 5      #���  6   $��10,0,0,0q�6@   $ 	Supprimer��6t   $��0q�6�   $
��Left=�6�   ��6R   �� *DeleteProject+��6�     *Delete+6�   5      5      5      �� 5   
   $��36��6   $	��Top=�6   $��0,45,0,0q�65   
�������$��1q�6^   ._�5      ]� .+�5      �� $��25��6   $��10,5,0,0q�6)   $��DemiBold"�6;   
�������$��14(�6c   $
��Left=�6r   $��Projet��6�   5      5      � 5!   
   .+�5"      �� $	��Top=�6   $
��Left=�61   $	��700��6L   $	��410��6Y   $��	75,84,0,0q�6e   .+�5#      �� $��	TimeSheet��6   
�������$��20��6?   $	��Top=�6K   $��DemiBold"�6c   $��13(�6y   $	��100��6�   $
��Left=�6�   $��	10,30,0,0q�6�   �� 5$      $��20��6   $��20��6%   $ 
Historique��60   $��0q�6q   
�������
�������$��280,-25,0,0q�6�   ��6E     *	History+��6}   �� *ViewHistoryProject+6�   �� 5%      -   5         ��Name$
 Tex1��5%      
�������$��25��6:   $	��Top=�6F   $	��190��6e   $��135,-25,0,0q�6q   $
��Left=�6�   $	��Top=�6�   ��6�   �� *NameProject+ �� Mode$ TwoWay=�.��6�   5'      �� 5(      
�������$��Description��6.   $��20��6B   $��DemiBold"�6N   $
��Left=�6d   $��13(�6   $��	10,20,0,0q�6�   �� 5)      $	��100��6   $	��190��6'   
������� �� TextWrapping$
 Wrap=�6E    �� AcceptsReturn . $	��Top=�6n   $��135,-20,0,0q�6�   $
��Left=�6�   $	��Top=�6�   ��6�   �� *DescriptionProject+$ TwoWay=�6�   �� 5*      
�������$��Client��6.   $��20��6<   $��DemiBold"�6H   $
��Left=�6^   $��13(�6y   $��	10,20,0,0q�6�   �� 5+      $��25��6   
�������$	��Top=�68   $	��190��6W   $��135,-25,0,0q�6�   $
��Left=�6�   $	��Top=�6�   ��6c   �� *CustomerName+$ TwoWay=�6�   �� 5,      $��20��6   $��20��6%   $ 
Rechercher��6\   $��0q�6q   
�������
�������$��280,-20,0,0q�6�   ��60     *	Magnify+��6}   �� *ViewClientList+6�   �� 5-      $��Date de Debut��6   
�������$��20��6C   $��DemiBold"�6O   $
��Left=�6e   $��13(�6�   $��	10,20,0,0q�6�   (  "System.Windows.Controls.DatePicker  5.      $��24��6   
�������$	��Top=�6;   $	��190��6�   $��135,-25,0,0q�6�   $
��Left=�6�   $	��Top=�6�      SelectedDate 6Z   �� *StartDateProject+	 �� StringFormat$	 {0:dd/MM/yyyy HH:mm:ss}��$ TwoWay=�6�   �� 5/      $��Date de Fin��6   
�������$��20��6A   $��DemiBold"�6M   $
��Left=�6c   $��13(�6~   $��	10,20,0,0q�6�   �� 50      $��24��6   
�������{�.  $	��Top=�6J   $	��135��6�   $��135,-25,0,0q�6�   $
��Left=�6�   $	��Top=�6�   ��6i   �� *EndDateProject+$	 {0:dd/MM/yyyy HH:mm:ss}��$ TwoWay=�6�   �� 51      $��Durée Estimé��6   
�������$��20��6B   $��DemiBold"�6N   $
��Left=�6d   $��13(�6   $��	10,20,0,0q�6�   �� 52      $��25��6   
�������$	��Top=�68   $��90��6W   $��135,-25,0,0q�6b   $
��Left=�6w   $	��Top=�6�   .��6�   ��53      �� 54      
 �� Path$
 EstimateDuration�6   $ TwoWay=�66    �� UpdateSourceTrigger$ PropertyChanged=�6D    �� ValidationRules 55      5  /System.Windows.Controls.ExceptionValidationRule  56      58      .��59       5:      �� 5;      $��heures��6    
�������$��20��6A   $��DemiBold"�6M   $
��Left=�6c   $��11(�6~   $��235,-20,0,0q�6�   �� 5<      $��Durée Total��6   
�������$��20��6A   $��DemiBold"�6M   $
��Left=�6c   $��13(�6~   $��	10,20,0,0q�6�   �� 5=      $��heures��6   
�������$��25��6<   $��DemiBold"�6H   $
��Left=�6^   $��11(�6y   $��235,-25,0,0q�6�   �� 5>      $��25��6   $��90��6&   {�.  
�������$��135,-27,0,0q�6U   $
��Left=�6�   $	��Top=�6�   ��6j   �� *TotalDuration+$ TwoWay=�6�   �� 5?      $��Tâches��6   
�������$��20��6<   $��DemiBold"�6H   $
��Left=�6^   $��13(�6y   $��	10,20,0,0q�6�   �� 5@      $��25��6   
�������$	��240��69   $	��Top=�6E   $��135,-25,0,0q�6d    �� DisplayMemberPath$ TaskName��6�   $
��Left=�6�   $	��Top=�6   �� SelectedItem 6y   �� *AddTaskToMinus+��6�   �� *
TaskList+$ OneWay=�.  (System.Windows.Interactivity.Interaction   Triggers 5A      /  )System.Windows.Interactivity.EventTrigger  5B         	EventName$ MouseDoubleClick��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5C      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 65   �� *AddTaskCommand+   CommandParameter 6X   �� *AddTaskToMinus+5D      5F      �� 5G      $ Ajouter��6B   $��0q�6T   
�������
�������$��20��6�   $��380,-25,0,0q�6�   $��20��6�   ��6     *Plus+��6`   �� *AddTaskCommand+6�   �� 5H      $
��Auto=�6   $	��100��6B   $	��240��6O   $��	95,20,0,0q�6[   $
��Auto=�6n   .��5I      �� .@�5J      �� 
�������$��1q�6i   $ TaskName��6�   $	��240��6�   $	��100��6�   ��6"   �� *ListTacheMinus+$ TwoWay=� 6}   �� *
RemoovTask+ 5K        5L   "   $ MouseDoubleClick��61   . 5M   &      6=   �� *RemovTaskCommand+ 6b   �� *
RemoovTask+5N   #   5P      5Q      5R      �� 5S      $ Enlever��6C   $��0q�6U   
�������
�������$��20��6�   $��380,-180,0,0q�6�   $��20��6�   ��6     *Minus+��6a   �� *RemovTaskCommand+6�   5T      �� 5V      $	��Top=�6   $��Right=�62   $	��592��6N   $	��354��6[   $��
0,84,300,0q�6g   .+�5W      �� $��Céateur��6   
�������$��20��6=   $	��Top=�6I   $��DemiBold"�6a   $��13(�6w   $	��100��6�   $
��Left=�6�   $��	10,30,0,0q�6�   �� 5X      $��25��6   {�.  
�������$	��Top=�6J   $	��190��6i   $��165,-20,0,0q�6�   $
��Left=�6�   $	��Top=�6�   ��6u   �� *CreatorProject+$ TwoWay=�6�   �� 5Y      $��Date de Création��6   
�������$��20��6F   $	��Top=�6R   $��DemiBold"�6j   $��13(�6�   $	��130��6�   $
��Left=�6�   $��	10,30,0,0q�6�   �� 5Z      $��25��6   {�.  
�������$	��Top=�6J   $	��190��6i   $��165,-20,0,0q�6�   $
��Left=�6�   $	��Top=�6�   ��6u   �� *CreationDate+$	 {0:dd/MM/yyyy HH:mm:ss}��$ TwoWay=�6�   �� 5[      $��Modificateur��6   
�������$��20��6B   $	��Top=�6N   $��DemiBold"�6f   $��13(�6|   $	��100��6�   $
��Left=�6�   $��	10,30,0,0q�6�   �� 5\      $��25��6   {�.  
�������$	��Top=�6J   $	��190��6i   $��165,-20,0,0q�6�   $
��Left=�6�   $	��Top=�6�   ��6u   �� *Modificator+$ TwoWay=�6�   �� 5]      $��Date de Modification��6   
�������$��20��6J   $	��Top=�6V   $��DemiBold"�6n   $��13(�6�   $	��135��6�   $
��Left=�6�   $��	10,30,0,0q�6�   �� 5^      $��25��6   {�.  $	��Top=�68   
�������$	��190��6i   $��165,-20,0,0q�6�   $
��Left=�6�   $	��Top=�6�   ��6u   �� *
ModifyDate+$	 {0:dd/MM/yyyy HH:mm:ss}��$ TwoWay=�6�   5_      5a      5b       � 	Resources 5c       �� 
TargetType �� Property �� Value��%�   &	       �� 5d   
   " ��6!   .�5e      ��  � ��
 �����6+   �� 5f       � ��$ 2q�6'   �� 5g       � ��$ 35��6&   63   �� 5h       � ��$ 30��6'   64   �� 5i       � ��
 �����6=   5j      5l      5m      