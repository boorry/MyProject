   M S B A M L   `   `   `  ����G  CTimeSheetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TimeSheetApp.ViewTimeSheetApp.View  5   	   $    TimeSheetApp.View.CustumerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TimeSheetApp.View     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1.command http://www.galasoft.ch/mvvmlight  5	   	     � Title$  Recherche d'un Client��5   	   $	��600��6m   $	��500��6z    � DataContext 6'   �� *CustomerView+   Locator �� Source# [  .��5      � $��0,0,0,-5q�6   .+�5   
   �  � RowDefinitions 5      �� 5      $��40 �6    �� 5      $��70 �6    �� 5      $��* �6    .+�5      �� 
�������$	��1,1q�6(   ._�5      �� $��Recherche d'un Client��6   
���iii�$��14(�6N   $��DemiBold"�6\   $��10q�6r   5      5      �� 5   
   
�������$��1,0,1,1q�6$   $��70��6>   $	��Top=�6J   $��0,39,0,0q�6b   ._�5      �� .+�5      ]� $	��Top=�6   .+�5      �� $	��top=�6    � ToolTip$ Retour��65     MyButton#���  6F   $��0q�6�   $
��Left=�6�   $��	14,10,0,0q�6�   ��6i   �� *PreviewToDetailProject+��6�   0  *MaterialDesignThemes.Wpf.PackIconExtension  *UndoVariant+6�   �� 5      $	��top=�6   $ Enregistrer��65   #���  6K   $��0q�6�   $
��Left=�6�   $��	10,10,0,0q�6�   ��6n   �� *
SaveClient+��6�     *ContentSave+6�   �� 5      $	��top=�6   $ 
Actualiser��65   #���  6J   $��0q�6�   $
��Left=�6�   $��	10,10,0,0q�6�   ��6m   �� *RefreSheCustomerList+��6�     *	Refresh+6�   5      ]� 5      $��30��6   $��0,0,0,0q�6(   .+�5      �� $��Client��6    
���iii�$��13(�6C   $��DemiBold"�6Q   $��40��6g   $��20��6r   $
��Left=�6~   $��30,0,0,0q�6�   �� 5       $��1q�6q   $��25��6�   $��Center=�6�   
�������$
��Left=�6�   $��1,0,0,0q�6�   $	��350��6�   ��6   �� *ClienttFilter+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�.��6   .  (System.Windows.Interactivity.Interaction   Triggers 5!      /  )System.Windows.Interactivity.EventTrigger  5"         	EventName$ TextChanged��6-   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5#   "   /  )GalaSoft.MvvmLight.Command.EventToCommand  
   Command
 69   �� *FilterClient+5$      .��5%   2   5&      �� 5'      $	��top=�6   $��22��65   $��20��6A   $ Anuler��6L   
����� �
�������$��0q�6�   $
��Left=�6�   $��2,4,0,0q�6  ��6]   �� *CancelClientSearch+��6�     *Close+6  �� 5(      $	��top=�6   $ 
Rechercher��65   $��22��6J   $��20��6V   
����� �
�������$��0q�6�   $
��Left=�6�   $��2,4,0,0q�6�   ��6�     *	Magnify+6�   5)      5*      5+      � 5,   
   $��	0,109,0,0q�6   .+�5-      &   System.Windows.Controls.DataGrid  $��0,0,0,33q�6      AlternatingRowBackground �#ebefef �� AlternationCount$ 2��6|      
IsReadOnly .    AutoGenerateColumns .     CanUserAddRows .  ��6)   �� *
ClientList+$ TwoWay=� �� SelectedItem 6�   �� *ClientSelected+   Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Société��6J      Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	 6[   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6)   �� *Customername+6[    51        52      $ MouseDoubleClick��6%   .	 53        
 61   �� *
SaveClient+   CommandParameter 6P   �� *ClientSelected+54      56      57      �� 58   
   
�������$��1q�6(   $��30��6<   $��Bottom=�6H   ._�59      ]� .+�5:      �� $��15,0,0,0q�68   $��30��6J   ��6   �� *CountClient+6J   �� 5;      $
��Left=�66   $��30��6Q   ��6   �� *	Resultats+6Q   5<      5=      5>       � 	Resources 5?       �� 
TargetType �� Property �� Value��%�   &	       �� 5@   
   " ��6!   .�5A      ��  � ��
 �����6+   �� 5B       � ��$ 2q�6'   �� 5C       � ��$ 35��6&   63   �� 5D       � ��$ 30��6'   64   �� 5E       � ��
 �����6=   5F      5G      5H      