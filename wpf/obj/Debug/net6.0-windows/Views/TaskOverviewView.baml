   M S B A M L   `   `   `  ����>  :wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:wpf.Views	wpf.Views  5   	        wpf.Views.TaskOverviewView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:wpf.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  TaskOverviewView��5	   	   $	��450��6"   $	��800��6/   .��5
      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Center=�6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ title��6-   $��5,0,50,0q�6�   $��0��6�   $��14(�6�   $��Center=�6�   ��6T   �� *
Zoekfilter+ �� ValidatesOnDataErrors$
 True��6�   �� 5   
   $��0��6   $��Zoeken��65   $��5q�6O   $��35��6Z   $��0q�6e   $��Right=�6q    � ToolTip$ task zoeken��6�   ��6!   �� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�6&   $��20��64   $��20��6?   $��Center=�6K   5      �� 5   
   -   5         ��Name$ 
btnNewTask��5      $��0��6&   $��1��63   $��5q�6C   $	��new��5   %   $��OpenNewTaskWindow��63   ��6   �� 5!      �� 5"   
   -   5        $ btnEditTask��5"      $��0��6'   $��2��64   $��5q�6D   $
��edit��5#   %   $��OpenEditTaskWindow��64   ��6   �� 5%      �� 5&   
   -   5        $ btnDeleteTask��5&      $��0��6)   $��3��66   $��5q�6F   $��delete��5'   %   $��
DeleteTask��66   ��6   �� 5)      �� 5*   
   -   5        $ btnDetailTask��5*      $��0��6)   $��4��66   $��5q�6F   $��detail��5+   %   $��OpenDetailTaskWindow��66   ��6   �� 5-      &   System.Windows.Controls.DataGrid  53   
   -   5        $��dtgTasks��56      $��1��53      $��6��6       
IsReadOnly$
 True��54      	   AutoGenerateColumns$	 False��57      ��54   %   �� *Tasks+
 �� SelectedItem
 55      �� *GeselecteerdeTask+   Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6<     5:      $ title��6>    6%   �� *Name+6>     5;      $ description��6E    6%   �� *Description+6E     5<      $ state��6?    6%   �� *State+6?     5=      $ created��6C    6%   �� *	CreatedAt+6C     5>      $ deadline��6B    6%   �� *
Deadline+6B   5B      5C      5D      