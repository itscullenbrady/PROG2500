   M S B A M L   `   `   `  ����F  BPROG2500_A7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PROG2500_A7PROG2500_A7  5   	       PROG2500_A7.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PROG2500_A7     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ RunUnsynchedButton_Thread��5
      $��Run Unsynched (Thread)��5   	   $��Center=�5   	   $��Bottom=�5   	   $��
0,0,300,10q�5   	   $	��150��5   	   5   	   �� 5   
   -   5        $ RunSynchedButton_Thread��5      $��Run Synched (Thread)��5   	   $��Center=�5   	   $��Bottom=�5   	   $��
300,0,0,10q�5   	   $	��150��5   	   5   	   � 5   
   -   5         �Name$ ProgressBar��5      $��Stretch=�5      $��Bottom=�5      $��30q�5      $��20��5      �� 5    
   -   5         ��Name$ Text_Output��5       $��Stretch=�5!      $	��Top=�5"      $��10q�5#      $	��300��5$       �� 
IsReadOnly$
 True��5%      " �� VerticalScrollBarVisibility$
 Auto=�5&       �� TextWrapping$
 Wrap=�5'      �� 5*   
   -   5        $ RunUnsynchedButton��5*      $��Run Unsynched (Task)��5+      $
��Left=�5,      $��Bottom=�5-      $��10q�5.      $	��120��5/      50      �� 52   
   -   5        $ RunSynchedButton��52      $��Run Synched (Task)��53      $��Right=�54      $��Bottom=�55      $��10q�56      $	��120��57      58      �� 5:   
   -   5        $ ClearButton��5:      $��Clear Output��5;      $��Center=�5<      $��Bottom=�5=      $��10q�5>      $	��120��5?      5@      5A      5B      