   M S B A M L   `   `   `  ����G  CTimeSheetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TimeSheetApp.ViewTimeSheetApp.View  5   	   ,    &TimeSheetApp.View.HistoriqueProjetView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TimeSheetApp.View     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  HistoriqueProjetView��5	   	   $	��600��6s   $	��700��6�    � DataContext 6&   �� *HistroryProjectView+   Locator �� Source# [  .��5
      � .+�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��48 �6    �� 5      $��60 �6    .+�5      �� 
�������$	��1,1q�6(   
�������._�5      �� $��Historique du Projet��6   $��DemiBold"�68   $��14(�6N   
���iii�$��20��6q   $	��150��6}   $
��Left=�6�   $��10,0,0,0q�6�   5      5      �� 5   
   
�������$��50��6%   $��1,0,1,1q�61   $��0,40,0,0q�6K   $	��Top=�6]   ._�5      ��   MyButton#���  6   $
��Left=�68    � ToolTip$ Retour��6S   $��0q�6�   $��20,0,0,0q�6�   ��6d   �� *PreviewToDetail+��6�   0  *MaterialDesignThemes.Wpf.PackIconExtension  *UndoVariant+6�   5      � 5   
   $��0,90,0,0q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��TimeSheetDataGrid��5      $��0,0,0,31q�60      
IsReadOnly .    AutoGenerateColumns .     CanUserAddRows .  ��6B   �� *TestViewMyHistories+ �� Mode$ TwoWay=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Projet��6I      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *ProjectName+6Y     5      $
 Durée Estimée��6F   $ * 6]    6)   �� *
LastTime+6]     5      $
 Date de Modification��6H   $ * 6f    6)   �� *
ActionDate+6f     5      $
 Modificateur��6H   $ * 6^    6)   �� *
ModifiedBy+6^   5       5!      �� 5"   
   
�������$��1q�6(   $��30��6<   $��Bottom=�6H   ._�5#      ]� .+�5$      �� $��20,0,0,0q�69   $��30��6K   ��6   �� *CountHistory+6K   �� 5%      $
��Left=�65   $��30��6P   ��6   �� *
Resultas+6P   5&      5'      5(       � 	Resources 5)       �� 
TargetType �� Property �� Value��%�   &	       �� 5*   
   " ��6!   .�5+      ��  � ��
 �����6+   �� 5,       � ��$ 2q�6'   �� 5-       � ��$ 35��6&   63   �� 5.       � ��$ 30��6'   64   �� 5/       � ��
 �����6=   50      51      52      