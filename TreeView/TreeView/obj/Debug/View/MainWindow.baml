   M S B A M L   `   `   `  ����C  ?TreeView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TreeViewTreeView  5   	   7 clr-namespace:TreeView.ViewModelTreeView.ViewModel  6.   /clr-namespace:TreeView.ModelTreeView.Model  6a   9!clr-namespace:TreeView.ConvertersTreeView.Converters  6�       TreeView.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TreeView     5   	   6	viewmodel clr-namespace:TreeView.ViewModel     6.   .modelclr-namespace:TreeView.Model     6a   8
converters!clr-namespace:TreeView.Converters     6�     � Title$  TreeView��5   	   $	��550��6   $	��500��6'    � 	Resources 5	      (  "TreeView.Converters.ExistConverter   ExistString��%   &	          5
   
   6$   5      .��5      �  � DataContext 6   �� *MainViewModel+  Locator �� Source# [  � RowDefinitions 5   
   �� 5      $	��13* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $
��140* �6   �� 5      $
��263* �6   .+�5   
   �� -   5         ��Name$ btn_load��5   5   $��1��6G   $��15q�6T   $��15(�6`   ��6   �� *LoadTreeCommand+.��6n   Load6t   �� 5   
   -   5         ��Name$ filter��5      $��20(�6j   $��10 2 0 0q�6x   $��1��6�   $��1��6�   $��10,15.2,10.2,15.4q�6�   ��6"   �� *Filter+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� Delay$		 250��6�   R� 5   
   -   5        
 R�Name$
 MainTree��5   �    %� VirtualizationMode$ 	Recycling=�6    %� CacheLength@  :System.Windows.Controls.VirtualizationCacheLengthConverter$	 500 6I    %� CacheLengthUnit$ Pixel=�6r   $��Hidden=�6�   $	��Top=�6�   $��Stretch=�6  $��10 20 10 20q�6E  $��2��6Z  ��6"  �� *
Categories+ 5       �� DataType   TreeView.Model.Category �� ItemsSource �� Orientation ��Name �� 	Converter �� StringFormat   TreeView.Model.Item �� Padding��%1  (��       5   +   *, +)7   (�� $    5      *, +)7   �� 5      "  6+    6N   �� *Items+.R�5      �� $ 
Horizontal=�6!   .+�5      �� $ categoryName��6$   ��6:   �� *CategoryName+��6X   �� *CategoryExist+8   �� 5      $��10,0,0,0q�6$   ��66   �� *Items.Count+$ [ {0} ]��5      5      �� 5      "  6   .R�5       �� $ 
Horizontal=�6!   .+�5!      �� $ 0 0 0 0q�6$   $��20 0 0 0q�66   ��6H   �� *
ItemName+$ • {0}����6v   �� *	ItemExist+8   5"      5#      5$      ��5%      �� 5&       �� 
TargetType" Q�6   .�5(      ��  �� Property � �� �� Value$ 1q�68   �� 5)       � �� 5*      �� 5+       �� 
TargetType" Q�6.   .R�5,   "   �� .+�5-   &   ��  ��Name$ Bd��5.   !   #��z��5/   !   #��z��50   !   #��z��51   !    �� Padding# z��52   !   ._�53   *   �  54   .   �� 55   2   $��19 �6C   �� 56   2   .+�58   .   ��  ��Name$ PART_Header��6?   $��1��6T   $��Stretch=�6d   $��Stretch=�6�   $��Header��6�   59   +   5:   '   �� 5;   &    ��Name$ 	ItemsHost��65   5<   #    �� Triggers 5=   "   P� 5>   &    P� Property �@Q�
IsSelected P� Value . . �5?   *   ��   �� 
TargetName$  Bd��61    � �� �	#FF80D3F76W   �� 5@   *    � ��
 �   �6G   5A   '   P� 5B   &    �@Q�IsSelectionActive .  . �5C   *   �� $  Bd��61    � ��
 �����6W   �� 5D   *    � ��
 �   �6G   5E   '   5G      5I      5J      5L      5M      5N      