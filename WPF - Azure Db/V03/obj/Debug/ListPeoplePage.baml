   M S B A M L   `   `   `  ????>  :V03, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:V03V03  5          V03.ListPeoplePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:V03     5        N? Title$  ListPeoplePage??5	      .??5      ?    GradientBackground#??[  6   .+?5   
   ?? -   5         ??Name$ LvPeople??5       ?? AlternationCount$ 2??5      $??Right=?5      $	??Top=?5      $??	0,40,55,0q?6%   $	??270??68   $	??500??6E   ??5      ?? 5       ?? 
TargetType" ??6   .?5      -   5        ?? 5       ?? Property ? ?? ?? Value
 ??ح?63    ?? Triggers 5      P? 5       P? Property ?@??AlternationIndex P? Value$ 1??6G   . ?5      ??  ? ??
 ?????6;   5      ]? 5      	 ]? 
Conditions	 5      ?? 5   "   
 ?? Property
 ?@??
IsSelected ?? Value . 6B   ./?5      ??  ? ??
 ???_?6;   5      5"       ?? View 5&      ?? 5'      .P?5(      ??  ?? Width$	 126??5)      $??
First name??5*       ?? DisplayMemberBinding 5+      ?? *	FirstName+?? 5,      $	 126??5-      $??	Last name??5.       5/      ?? *
LastName+?? 50      $	 126??51      $	??Age??52       53      ?? *Age+?? 54      $	 126??55      $??Email??56       ?? CellTemplate 57      ?? 58      .R?59   "   ?? $??	Underline{?5:   ,   
???   ? ? Cursor$
 Hand??5<   ,   ??59   ,   ?? *Email+ ? ToolTip 5=   &   ?? 5>   *    ??Name$ Picture??60   $??60??5@   0   $??60??5A   0   ??5?   0   ?? *Image+5A   0   5D   #   5E      5H      ?? 5I      $	 126??5J      $??	SubjectID??5K       5L      ?? *	SubjectID+5M      5O      ?? 5P   
   -   5         ??Name$ BtnAdd??5Q      $	??Add??5R      
???????
??? ? ?$
??Left=?5V      $??133,333,0,0q?6,   $	??Top=?6A   $??25??6Y   $	??100??6e   ?? 5W   
   -   5        $ BtnEdit??5X      $
??Edit??5Y      
???????
???   ?$
??Left=?5^      $??383,333,0,0q?6(   $	??Top=?6=   $??25??6U   $	??100??6a   ?? 5_   
   -   5        $ 	BtnDelete??5`      $??Delete??5a      
???????
???  ??$
??Left=?5f      $??258,333,0,0q?6(   $	??Top=?6=   $??25??6U   $	??100??6a   ?? 5g   
   -   5        $ 
BtnSubject??5h      $??Subjects??5i      
???????
???????$
??Left=?5n      $??383,376,0,0q?6(   $	??Top=?6=   $??25??6U   $	??100??6a   5p      5q      