   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5       TimeSheetApp(   "TimeSheetApp.Util.MessageBoxWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      9system&clr-namespace:System;assembly=mscorlib     5      Mmetro;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  MessageBoxWindow��5       � Topmost . $��14(�5      (  "MahApps.Metro.Controls.MetroWindow   ShowCloseButton .  $��Center=�5	       � 
ResizeMode$ NoResize=�5
         ShowTitleBar .   � WindowStyle$
 None=�5         MaterialDesignPaper#���   5        AccentColorBrush#���  5      $��4q�5       � WindowStartupLocation$ CenterScreen=�5      $	��400��5      $	��200��5       � 	Resources 5        
Primary500 �� Color	 �� MergedDictionaries
 �� Source�� 5   
   	 5      �� 5      $e
 _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h
 bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $y
 spack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.LightBlue.xaml?�6%   �� 5      $t
 npack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Green.xaml?�6%   �� 5!      $f
 `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   �� 5"      $g
 apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBox.xaml?�6%   %$   &	       �� 5      # �  67   5&      .��5)      � -   5        $��MainContentControl��5)       � RowDefinitions 5*   
   �� 5+      $
��Auto �6   �� 5,      $��* �6   �� 5-      $
��Auto �6   .+�50   
   � -   5         �Name$ TitleBackgroundPanel��50      $��0��6   #���  6S    � ColumnDefinitions 51      �� 52      $
��Auto �6#   �� 53      $��* �6#   .+�56      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=null]]   Kind$ MessageText=�6&   #���   69   $��Center=�6l   $��Center=�6�   $��6,0,6,0q�6�   �� 57      -   5        $��TxtTitle��57      $��1��6A   
�������$��Title��6d   $��Center=�6q   $��Medium"�6�   $��0,6,6,6q�6�   58      �� 5:   
   -   5        $��MessageControl��5:      $��1��6F   $
��Auto=�6S   .��5;      �� -   5        $��
TxtMessage��5;   1   $��80��6C   $��Message��6R   $
��Wrap=�6a    �� Padding$ 3q�6u   $	��Top=�6�   
���   �$��Normal"�6�   $��24,12q�6�   5<      � 5>   
   $��2��6   $��24,12q�6    5?      �� 5@      $
��Auto �6#   �� 5A      $��* �6#   .+�5D      �� -   5        $��BtnCopyMessage��5D   /   $��0��6d   $	��Top=�6t   $��30��6�   $��30��6�   
�����p�
������� � ToolTip$ Copy to clipbopard��6�   $
��Left=�6�   $��0q�6   * &MaterialDesignFloatingActionMiniButton#���  6  .��5E        $ ContentCopy=�6*   
�����p�6=   5F      �� 5G      $��1��6    �� Orientation$ 
Horizontal=�6)   $��Right=�6B   .+�5H      �� -   5        $��BtnOk��5H   3   #���   6V   $	��Oui��6�   $	��100��6�   $
��24,5q�6�   �� 5I      -   5        $��	BtnCancel��5I   3   $	��Non��6^   #���   6m   $	��100��6�   
���iii�$
��24,5q�6�   $��24,0,0,0q�6�   5J      5K      5L      5M      