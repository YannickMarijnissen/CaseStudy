   M S B A M L   `   `   `  ����>  :wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:wpf.Views	wpf.Views  5   	       wpf.Views.TaskDetailsView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:wpf.Views     5   	     � Title$  TaskDetailsView��5   	   $	��450��6!   $	��800��6.   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Task Details��6   $
��Bold"�6(   $��18(�6:   $��0,0,0,10q�6H   �� 5   
   $��Title:��6   $��1��6"   $��0��6/   $��0,5,5,0q�6?   $��Center=�6P   �� 5   
   $��1��6K   $��1��6X   $��0,5,5,0q�6h   $��Center=�6y   ��6   �� *	Task.Name+ �� ValidatesOnDataErrors$
 true��6y   �� 5    
   $��Description:��6   $��2��6(   $��0��65   $��0,5,5,0q�6E   $��Center=�6V   �� 5!   
   $��2��66   $��1��6C   $��0,5,5,0q�6S   $��Center=�6d   ��6   �� *Task.Description+6d   �� 5#   
   $��State:��6   $��3��6"   $��0��6/   $��0,5,5,0q�6?   $��Center=�6P   �� 5$   
   $��3��60   $��1��6=   $��0,5,5,0q�6M   $��Center=�6^   ��6   �� *
Task.State+6^   �� 5&   
   $��Created At:��6   $��4��6'   $��0��64   $��0,5,5,0q�6D   $��Center=�6U   �� 5'   
   $��4��6X   $��1��6e   $��0,5,5,0q�6u   $��Center=�6�   ��6   �� *Task.CreatedAt+ �� StringFormat$ yyyy-MM-dd HH:mm:ss��6�   �� 5)   
   $��	Deadline:��6   $��5��6%   $��0��62   $��0,5,5,0q�6B   $��Center=�6S   �� 5*   
   $��5��63   $��1��6@   $��0,5,5,0q�6P   $��Center=�6a   ��6   �� *Task.Deadline+6a   �� 5-   
   $��Back to Overview��6   $��6��6,   $��0��69   $��2��6I   $��0,10,0,0q�6]   $��BackToOverview��5.   %   ��6   �� 6%   5/      50      