   M S B A M L   `   `   `  ����G  CTimeSheetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TimeSheetApp.ViewTimeSheetApp.View  5      '    !TimeSheetApp.View.TacheDetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TimeSheetApp.View     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � DataContext  5
      �� *TacheDetailViewModelVm+   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   6*   �� 5      $��30 �6   6*   �� 5      $
��Auto �6   6,   .+�5   
   �� $��0��6   
�������$��0,0,0,1q�62   ._�5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6'   66   .+�5      ]� $��10,0,0,0q�6   .+�5      ��   
ButtonMenu#���  6�    � ToolTip$ Retour��6�   ��6   �� * RetourAvecAvertissementCommand+��6P   0  *MaterialDesignThemes.Wpf.PackIconExtension  *ArrowLeftBold+5      �� 5      #���  6p   $ Sauvegarder��6�   ��6   �� *SauverCommand+��6@     *ContentSave+5      �� 5       #���  6k   $ 	Supprimer��6�   ��6   �� *EffacerCommand+��6@     *Delete+5!      �� 5"      #���  6n   $ 
Actualiser��6�   ��6   �� *ActualiserCommand+��6C     *Cached+5#      5%      5&      5'      � 5(   
   $��1��6    5)      �� 5*      $��* �6#   .+�5,      �� $��2��6   
���iii�$��0,0,0,1q�6?   ._�5-      �� $��Detail d'une tâche��6   
���iii�$��12(�6K   $��DemiBold"�6Y   5.      52      � 53   
   $��2��6   .+�54      �� -   5        $
��Left��54      $
��Left=�6%   $��70,0,0,0q�6@   $	��400��6R   $	��550��6_   .+�55      �� $��Tâche��6   $��	40,40,0,0q�6(   $��30��6;   $	��150��6G   $
��Left=�6S   
���iii�$��12(�6�   $��DemiBold"�6�   �� 56      
���iii�$��30��6`   $	��270��6l   $��
90,-40,0,0q�6x   ��6   �� *Selection.TaskName+ �� Mode$ TwoWay=�6x   �� 57      $��20��6p   $��80��6|   $��Est activée��6�   $��400,-30,0,0q�6�    d� 	IsChecked 6   �� *
IsActive+$ TwoWay=���6I   �� *CheckActiveCommand+6�   �� 58      $��	Créateur��6   $��	40,40,0,0q�6+   $��30��6>   $	��150��6J   $
��Left=�6V   
���iii�$��12(�6�   $��DemiBold"�6�   �� 59      {�.  $��30��6^   $	��270��6j   $��
90,-40,0,0q�6v   ��6   �� *Selection.CreatedBy+$ TwoWay=�6v   �� 5:      $��Date de création��6   $��	40,40,0,0q�63   $��30��6F   $	��150��6R   $
��Left=�6^   
���iii�$��12(�6�   $��DemiBold"�6�   �� 5;      {�.  $��30��6�   $	��270��6�   $��
90,-40,0,0q�6�   ��6   �� *Selection.CreationDate+ �� StringFormat$ {0:dd/MM/yyyy HH:mm:ss}��$ TwoWay=�6�   �� 5<      $��Modificateur��6   $��	40,40,0,0q�6/   $��30��6B   $	��150��6N   $
��Left=�6Z   
���iii�$��12(�6�   $��DemiBold"�6�   �� 5=      {�.  $��30��6�   $	��270��6�   $��
90,-40,0,0q�6�   ��6   �� *Selection.ModifiedBy+$ {0:dd/MM/yyyy HH:mm:ss}��$ TwoWay=�6�   �� 5>      $��Date de modification��6   $��	40,40,0,0q�67   $��30��6J   $	��150��6V   $
��Left=�6b   
���iii�$��12(�6�   $��DemiBold"�6�   �� 5?      {�.  $��30��6�   $	��270��6�   $��
90,-40,0,0q�6�   ��6   �� *DateDeModification+$ {0:dd/MM/yyyy HH:mm:ss}��$ TwoWay=�6�   5@      5C      5E       � 	Resources 5I        ActiveRunning	 �� 
TargetType
 �� Triggers �� Binding �� Path �� Value �� Property �� Value��%�  &	       &	 �    �� 5J   
   "	 ��6&   
 5K      �� 5M       6   �� $ Selection.Active� 06H   .a�5N      ��  �@d�	IsChecked$ FalseY�62   5O      �� 5Q       6   �� $ Selection.Active�  6H   .a�5R      ��  �@d�	IsChecked$ FalseY�62   5S      �� 5U       6   �� $ Selection.Active� 16H   .a�5V      ��  �@d�	IsChecked$
 TrueY�62   5W      5Z      �� 5_   
   "	 ��6#   .�5`      ��  � ��
 �����6+   �� 5a       � ��$ 2q�6'   �� 5b       � ��$ 35��6&   63   �� 5c       � ��$ 30��6'   64   �� 5d       � ��
 �����6=   5e      5g      5l      