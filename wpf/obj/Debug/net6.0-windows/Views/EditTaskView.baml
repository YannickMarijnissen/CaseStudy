   M S B A M L   `   `   `  ����>  :wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:wpf.Views	wpf.Views  5   	       wpf.Views.EditTaskView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:wpf.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  	Edit Task��5   	   $	��450��6   $	��800��6(      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5!   
   �� $��Title��6   $��0��5"      $��0��6   $��5q�5#      $��Center=�5$      $��14(�5%      �� 5'   
   $��0��5(      $��1��6   $��5q�5)      $��Center=�5*      $��14(�5+      ��5'      �� *	Task.Name+ �� ValidatesOnDataErrors$
 True��5+      �� 5-   
   $��Description��6   $��1��5.      $��0��6   $��5q�5/      $��Center=�50      $��14(�51      �� 53   
   $��1��54      $��1��6   $��5q�55      $��Center=�56      $��14(�57      ��53      �� *Task.Description+$
 True��57      �� 59   
   $��State��6   $��2��5:      $��0��6   $��5q�5;      $��Center=�5<      $��14(�5=      �� 5?   
   $��2��5A      $��1��6    $��5q�60   $��Center=�5B      $��14(�65    �� SelectedItem 5?      �� *
Task.State+ �� UpdateSourceTrigger$ PropertyChanged=���5@      �� *ComboBoxItems+5C      �� 5E   
   $��Deadline��6   $��3��5F      $��0��6   $��5q�5G      $��Center=�5H      $��14(�5I      (  "System.Windows.Controls.DatePicker  5K   
   $��3��5L      $��1��6   $��5q�5M      $��Center=�5N      $��14(�5O         SelectedDate 5K      �� *Task.Deadline+$
 True��5O      �� 5Q   
   $��Task aanpassen��6   $��4��6*   $��0��67   $��5q�6G   $��TaskAanpassen��5R   %   ��6   �� 6%   5S      5T      