   M S B A M L   `   `   `  ����G  CTimeSheetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TimeSheetApp.ViewTimeSheetApp.View  5   	   +    %TimeSheetApp.View.UserTimeHistoryView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TimeSheetApp.View     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  UserTimeHistoryView��5	   	   $	��477��6%   $	��NaN��62    � DataContext 5
   	   �� *UserTimeHistoryViewModelVm+   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   6*   �� 5      $	��372 �6   6+   �� 5      $��25 �6   6*   .+�5   
   �� $��0��6   
�������$��1q�61   ._�5      �� $��0��6   $
��Left=�6"     
ButtonMenu#���  6�    � ToolTip$ Retour��6�   ��6=   �� *RetourCommand+��6_   0  *MaterialDesignThemes.Wpf.PackIconExtension  *ArrowLeftBold+6�   5      &   System.Windows.Controls.DataGrid  5   
      AlternatingRowBackground �#ebefef �� AlternationCount$ 2��67   $��1��6L      
IsReadOnly .    AutoGenerateColumns .  ��6�   �� *LstUserTimeHistory+	 �� Mode$	 TwoWay=�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6j   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *TaskUserTimeHistoryID+$	 TwoWay=�6j     5      $ 
Date debut��6%   $ * 6�    6:   �� *	startDate+ �� StringFormat$ {0:dd/MM/yyyy HH:mm:ss}��$	 TwoWay=�6�     5      $ Date fin��6%   $ * 6�    68   �� *	EndDate+$ {0:dd/MM/yyyy HH:mm:ss}��$	 TwoWay=�6�     5      $ 
Créer par��6%   $ * 6d    69   �� *	CreatedBy+$	 TwoWay=�6d   5      �� 5    
   $��2��6   
�������$��1q�61   ._�5!      �� ��6   �� *
NbResult+$	 TwoWay=�6C   5"      5'       � 	Resources 5*       �� 
TargetType �� Property �� Value��%�   &	       �� 5+   
   " ��6#   .�5,      ��  � ��
 �����6+   �� 5-       � ��$ 2q�6'   �� 5.       � ��$ 35��6&   63   �� 5/       � ��$ 30��6'   64   �� 50       � ��
 �����6=   51      52      53      