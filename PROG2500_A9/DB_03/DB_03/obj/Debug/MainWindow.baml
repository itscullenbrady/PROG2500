   M S B A M L   `   `   `  ����@  <DB_03, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DB_03DB_03  5   	       DB_03.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:DB_03     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� .@�5      �� $��Person Data Entry��6   .��5      � $��10q�6   .+�5      �� -   5         ��Name$ tb_first��5      $
��Left=�60   $��23��6K   $��
158,34,0,0q�6W    �� TextWrapping$
 Wrap=�6k   $��
First Name��6   $	��Top=�6�   $	��120��6�   �� 5      -   5        $ tb_last��5      $
��Left=�6/   $��23��6J   $��
158,74,0,0q�6V   $
 Wrap=�6j   $��	Last Name��6~   $	��Top=�6�   $	��120��6�   �� 5      -   5        $ 
tb_address��5      $
��Left=�62   $��23��6M   $��158,114,0,0q�6Y   $
 Wrap=�6n   $��Address��6�   $	��Top=�6�   $	��120��6�   �� 5      -   5         ��Name$ l_first��5      $��
First Name��6-   $
��Left=�6B   $��	66,34,0,0q�6]   $	��Top=�6p   �� 5      -   5        $ l_last��5      $��	Last Name��6,   $
��Left=�6@   $��	66,74,0,0q�6[   $	��Top=�6n   �� 5      -   5        $ 	l_address��5      $��Address��6/   $
��Left=�6A   $��
66,114,0,0q�6\   $	��Top=�6p   �� 5      -   5         ��Name$ b_Add��5      $��
Add Person��6,   $
��Left=�6A   $��105,175,0,0q�6\   $	��Top=�6q   $��75��6�   6�   �� 5      -   5        $ b_update��5      $��Update Person��6/   $
��Left=�6G   $��201,175,0,0q�6b   $	��Top=�6w   $��95��6�   6�   �� 5      -	   5        $ b_delete��5      $��Delete Selected��6/   $
��Left=�6I   $��105,215,0,0q�6d   $	��Top=�6y   $��95��6�   6�   �� 5      -
   5        $ b_cancel��5      $��Cancel��6/   $
��Left=�6@   $��201,215,0,0q�6[   $	��Top=�6p   $��75��6�   6�   �� 5      -   5        $ b_prev��5      $��Previous��6-   $
��Left=�6@   $��105,255,0,0q�6[   $	��Top=�6p   $��75��6�   6�   �� 5      -   5        $ b_next��5      $
��Next��6-   $
��Left=�6<   $��201,255,0,0q�6W   $	��Top=�6l   $��75��6�   6�   �� 5      -   5        $ 	tb_search��5      $
��Left=�61   $��23��6L   $��158,295,0,0q�6X   $
 Wrap=�6m   $��Search by Last Name��6�   $	��Top=�6�   $	��120��6�   �� 5      -   5        $ b_search��5      $��Search��6/   $
��Left=�6@   $��105,325,0,0q�6[   $	��Top=�6p   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ 
gridPerson��5      $��Stretch=�63   $��Stretch=�6Q   $��311,34,10,10q�6m      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6T   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6=   �� *Id+6T     5      $ 
First Name��61   $	 2* 6_   
 6E   �� *fname+6_     5      $ 	Last Name��61   $	 2* 6^   
 6D   �� *lname+6^     5       $ Address��61   $	 3* 6^   
 6B   �� *	address+6^     5!      $
 Hair��61   $	 * 6X   
 6?   �� *Hair+6X     5"      $
 Eyes��61   $	 * 6X   
 6?   �� *Eyes+6X     5#      $ Mouth��61   $	 * 6Z   
 6@   �� *Mouth+6Z     5$      $
 Nose��61   $	 * 6X   
 6?   �� *Nose+6X   5&      5'      5(      �� 5)      $��
Face Maker��6   .��5*       �   � Source$ SecondPage.xaml?�6   5+      5,      5-      5.      