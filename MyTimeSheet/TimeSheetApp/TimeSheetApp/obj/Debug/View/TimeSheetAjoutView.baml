   M S B A M L   `   `   `  ����G  CTimeSheetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TimeSheetApp.ViewTimeSheetApp.View  5   	   *    $TimeSheetApp.View.TimeSheetAjoutView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TimeSheetApp.View     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1.command http://www.galasoft.ch/mvvmlight  5	   	     � Title$  TimeSheetAjoutView��5   	   $	��NaN��6$   $	��NaN��61    � DataContext 5   	   �� *TimeSheetAjoutViewModelVm+   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   6*   �� 5      $��35 �6   6*   �� 5      $��* �6   6)   �� 5      $��25 �6   6*   .+�5   
   �� $��0��6   
�������$��1q�62   ._�5      � $
��Left=�6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   66   .+�5      ]� $��10,0,0,0q�6   .+�5      ��   
ButtonMenu#���  6r    � ToolTip$ Retour��6�   ��6   �� *RetourCommand+��6@   0  *MaterialDesignThemes.Wpf.PackIconExtension  *ArrowLeftBold+5      �� 5      #���  6p   $ Ajouter��6�   ��6   �� *SauverCommand+��6@     *ContentSave+5       �� 5!      #���  6o   $ 
Actualiser��6�   ��6   �� *ActualiserCommand+��6C     *	Refresh+5"      5$      5&      5'      �� 5(   
   $��1��6   
�������$��1q�62   ._�5)   
   �  5+      �� 5,      $��90 �6#   60   �� 5-      $
��Auto �6#   62   .+�50      �� $��0��6   $��Projet��6$   
���iii�$��13(�6J   $��DemiBold"�6X   $��20,0,0,0q�6n   6�   �� 51      -   5        $��	mCbFiltre��51   +   $��1��6    �� DisplayMemberPath$ ProjectName��6�   $��Right=�6�   $	��247��6�   $��31��6�   $	��Top=�6�   $��
0,0,-222,0q�6  ��6>   �� *	LstProjet+ �� Mode$ TwoWay=� �� SelectedItem 6m   �� *SelectionComboBoxProjet+$ TwoWay=�6-  52      53      �� 55   
   $��2��6   
���   �$��1q�63   ._�56      � .+�57      &   System.Windows.Controls.DataGrid  	   
IsReadOnly	 . 
   AutoGenerateColumns
 .  ��6I   �� *LstPrjTache+$ TwoWay=� 6z   �� *	Selection+$ TwoWay=�   Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ Projet��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *ProjectName+$ OneWay=�6m     5:      $ Tache��6-   $ * 6h    6=   �� *
TaskName+$ OneWay=�6h     5;      $ 
Créer par��6-   $ * 6m    6A   �� *	CreatedBy+$ OneWay=�6m     5<      $ Date de création��6-   $ * 6v    6H   �� *CreationDate+$ OneWay=�6v   .  (System.Windows.Interactivity.Interaction   Triggers 5>      /  )System.Windows.Interactivity.EventTrigger  5?         	EventName$ MouseDoubleClick��6)   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 5@      /
  )GalaSoft.MvvmLight.Command.EventToCommand
   
  Command 65   �� *SauverCommand+ 
  CommandParameter 5A   !   �� *	Selection+5B      5D      5E      5F      �� 5H   
   $��3��6   
�������$��1q�62   ._�5J      �� ��6   �� *
NbResult+$ TwoWay=�6C   5K      5L       � 	Resources 5N       �� 
TargetType �� Property �� Value��%�   &	       �� 5O      " ��6'   .�5P      ��  � ��
 �����6/   �� 5Q       � ��$ 2q�6+   �� 5R       � ��$ 35��6*   67   �� 5S       � ��$ 30��6+   68   �� 5T       � ��
 �����6A   5U      5V      5Z      