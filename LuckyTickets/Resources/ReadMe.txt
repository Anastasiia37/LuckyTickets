The goal of this application is to count the number of lucky tickets.
There are 2 ways to count lucky tickets:
1. Moscow: the ticket is lucky if the sum of the first half of the digits is equal to the sum of the second half of the digits.
2. Piter: the ticket is lucky if the sum of the even digits of the ticket is equal to the sum of the odd digits of the ticket.
A text file is read to select the counting algorithm. The path to the text file is set in the console after the program starts. 
Algorithm Indicators: the word "Moskow" or the word "Piter" (without quotes).
If the number of digits in the ticket is not even the ticket is not lucky.

The program starts from the command line.
Input parameters: <File> <RangeOfTickets>
OR
Input parameters: <File> <StartTicket> <BoundaryTicket>
where
	<File> is the file with lucky ticket counting algorithm,
	<RangeOfTickets> is a number of ticket`s digits (must be from 1 to 18),
	<StartTicket> is a ticket from which to start counting,
	<BoundaryTicket> is a ticket from which to stop counting.