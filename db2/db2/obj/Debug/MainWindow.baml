   M S B A M L   `   `   `  ����>  :db2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:db2db2  5   	       db2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:db2     5   	   -   5          � Title$  
MainWindow��5   	   $	��487��6   $	��654��6)    � WindowStartupLocation$ CenterScreen=�6L   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   ��  	  label#��[  6   $��Stock Level��6/   $��0��6E   $��0��6R   �� 5   
   -   5        $��lbxStockLevel��5   0     Box#��[ 6   $��1��6E   $��0��6R   6b   �� 5   
   #��[  6   $��	Suppliers��6/   $��0��6C   $��1��6P   �� 5   
   -   5        $��lbxSuppliers��5   /   #��[ 6   $��1��6C   $��1��6P    �� DisplayMemberPath$ CompanyName��6`    �� SelectedValuePath$ 
SupplierID��6�   6�   �� 5   
   #��[  6   $��Country��6/   $��0��6A   $��2��6N   �� 5   
   -   5        $��lbxCountries��5   /   #��[ 6   $��1��6C   $��2��6P   $ Country��6`   $ Country��6|   6�   �� 5   
   #��[  6   $��Products��6/   $��2��6B   $��3��6O   �� 5    
   -   5        $��lbxProducts��5    /   #��[ 6   $��3��6B   $��3��6O   5!      5"      