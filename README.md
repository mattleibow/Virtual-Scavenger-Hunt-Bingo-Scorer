# Virtual-Scavenger-Hunt-Bingo-Scorer

## Different Components
### Program.cs
This file calls MarkBoard.cs to create a board for each player and mark the squares that each
player has completed. Then it will call Awards.cs and thus BingoBoard.cs to handle all the point tallying. Finally, Program.cs will write different forms of score counting outputs to the 'Virtual-Scavenger-Hunt-Bingo-Scorer' directory (if running the program in Visual Studio - Debug).

### MarkBoard.cs
`VSCX Team *** This is where we add the names!`
This file is where we will add players' names signifying which squares they have completed inside `TallyAllItems ()`. This file will create a BingoBoard instance for each player it finds inside TallyAllItems and then send the output back to Program.cs

### Awards.cs
This file is probably the messiest one that could use some cleanup. You will find logic that calls methods in BingoBoard.cs such as `DrawBoard ()` and `CalculateScore ()` which creates a string drawing of the bingo board and calculates the score for each board passed in. These properties get added into the 'Entries' list and used to score all the players against each other.

### BingoBoard.cs
This file contains the lower level logic called by Awards.cs. It can draw out the actually bingo board in a string and has all the rules to get point values based on the passed in BingoBoard.
