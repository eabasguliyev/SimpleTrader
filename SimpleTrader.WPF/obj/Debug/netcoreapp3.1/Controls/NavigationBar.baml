   M S B A M L   `   `   `  ����K  GSimpleTrader.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SimpleTrader.WPF.ControlsSimpleTrader.WPF.Controls  5      U/clr-namespace:SimpleTrader.WPF.State.Navigators!SimpleTrader.WPF.State.Navigators  5      I)clr-namespace:SimpleTrader.WPF.ViewModelsSimpleTrader.WPF.ViewModels  5	      I)clr-namespace:SimpleTrader.WPF.ConvertersSimpleTrader.WPF.Converters  5
      -    'SimpleTrader.WPF.Controls.NavigationBar   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:SimpleTrader.WPF.Controls     5      ?nav/clr-namespace:SimpleTrader.WPF.State.Navigators     5      8vm)clr-namespace:SimpleTrader.WPF.ViewModels     5	      @
converters)clr-namespace:SimpleTrader.WPF.Converters     5
        � 	Resources  5      @   :SimpleTrader.WPF.Converters.EqualValueToParameterConverter "  EqualValueToParameterConverter��%   &	          5   
   64   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6    �� Padding$ 10q�5      $��28(�5      
�������$��Simple Trader��5        BrushPrimaryOne#��[ 5      � 5   
   $��1��6    �� EdgeMode$ Aliased=�5         BrushPrimaryTwo#��[ 5!        5"       �� 
TargetType  	NavButton �� BasedOn��%4   '	�       7  �� 5#      " 	�6   8   5$   ?   5%       � ColumnDefinitions 5'      �� 5(      $
��auto �6#   �� 5)      $
��auto �6#   �� 5*      $
��auto �6#   �� 5+      $
��auto �6#   �� 5,      $��* �6#   .+�5/      	� $��0��6   $
��Home��6*   0   *SimpleTrader.WPF.State.Navigators.ViewType   Home#��Z 52       d� 	IsChecked 50      �� *CurrentViewModel+	 �� Mode$	 OneWay=�
 �� ConverterParameter/   )SimpleTrader.WPF.ViewModels.HomeViewModel"
   �� 	Converter# [  ��51      �� *UpdateCurrentViewModelCommand+52      	� 53      $��1��6   $��	Portfolio��6*      	Portfolio#��Z 56       54      �� *CurrentViewModel+$	 OneWay=�4   .SimpleTrader.WPF.ViewModels.PortfolioViewModel"
  # [  ��55      �� *UpdateCurrentViewModelCommand+56      	� 57      $��2��6   $	��Buy��6*   	� 58      $��3��6   $
��Sell��6*   59      5:      5;      