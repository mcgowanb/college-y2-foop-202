   M S B A M L   `   `   `  ����D  @AWExample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AWExample	AWExample  5   	       AWExample.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:AWExample     5   	   -   5          � Title$  
MainWindow��5   	   $	��427��6   $	��589��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��3* �6   .+�5   
   �� $��	Customers��6   $��0��6$   $��0��61    	  label#��[  6A   �� 5   
   -   5        $��lbxCustomers��5      $��1��6&   $��0��63     Box#��[ 6C    �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$
 Name��5      �� 5   
   $��Order Summary��6   $��0��6(   $��1��65   #��[  6E   �� 5   
   -   5        $��	lbxOrders��5      $��1��6$   $��1��61   #��[ 6A   $ SalesOrderID��5      �� 5    
   $��Order Details��6   $��2��6(   $��2��65   #��[  6I   &   System.Windows.Controls.DataGrid  5"   
   -   5        $��dgOrderDetails��5"      $��3��6)   $��2��66     Grid#��[ 6J   5$      5'      