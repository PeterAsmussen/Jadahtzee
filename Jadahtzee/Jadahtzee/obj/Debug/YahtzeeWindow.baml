   M S B A M L   `   `   `  ����D  @Jadahtzee, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Jadahtzee	Jadahtzee  5   	       Jadahtzee.YahtzeeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Jadahtzee     5   	     � Title$  
Jadahtzee!��5   	   $	��500��6   $	��250��6)   .��5	      � -   5         �Name$ gridMain��5	      ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFE3BAAF��6    � Offset$ 0Q�61   � 5      $ White��6   $ 1Q�6-   5      .+�5   
   �� -   5         ��Name$ 
cnvNewGame��5      $��Center=�6%   $	��102��6B   $��Center=�6O   $	��178��6j   .+�5      �� -   5         ��Name$ 
txtNewGame��5      $
��Left=�6*   $��23��6E    �� TextWrapping$
 Wrap=�6Q   $	��Top=�6e   $��32��6}   	 �� Left$	 46��6�   

 �� Top$
 54��6�   �� 5      -   5         ��Name$ btn2NewGame��5      $	��Go!��6*   $
��Left=�68   $	��Top=�6S   $��45��6k   $��23��6v   $	 82��6�   $
 54��6�   6�   �� 5      -   5         ��Name$ grpbNewGame��5      $��Yahtzee!��6,   $��82��6>   $	 10��6J   $
 10��6[   $	��158��6k   $��14(�6w   �� 5      $
��Left=�6   $
��Wrap=�63   $��How many are playing?��6G   $	��Top=�6d   $	��108��6|   $��10(�6�   $	 38��6�   $
 38��6�   5      9� 5   
   -   5         9�Name$ 
expOptions��5      $��Options��6'   $
��Left=�68   $	��105��6S   $	��Top=�6`   $	��108��6x    9� 
IsExpanded .   K� ZIndex$ 1��6�   .��5      � 
�������$��0,0,3,0q�6&   .+�5      �� -   5        $ 
btnNewGame��5      $��New game��6-   $
��Left=�6@   $��7,5,0,0q�6[   $	��Top=�6l   $��88��6�   6�   �� 5      -   5        $ btnResetGame��5      $��
Reset game��6/   $
��Left=�6D   $��7,30,0,0q�6_   $	��Top=�6q   $��88��6�   6�   �� 5      -	   5        $ btnHighscores��5      $��
Highscores��60   $
��Left=�6E   $��7,55,0,0q�6`   $	��Top=�6r   $��88��6�   6�   5      5      �� 5   
   -
   5        $ cnvMain��5      $
��Left=�6"   $	��449��6=   $��	10,10,0,0q�6J   $	��Top=�6]   $	��222��6u   �� 5   
   $��90��6   $	��200��6   $��Center=�6(   $	��Top=�6E   ��5      ��5       Resources/Yahtzee-logo.png��6:   5"      5#      5$      