using System;
using System.Collections.Generic;

namespace BingoScorer
{
    public class MarkBoard
    {
        static List<BingoBoard> Boards = new List<BingoBoard>();

        public static List<BingoBoard> CreateBingoBoards()
        {
            TallyAllItems();
            return Boards;
        }

        // This is where the names for each event go!
        static void TallyAllItems()
        {
            TallyItems(e.Your_Work_Setup, new string[]{
                "Steve Hawley", "Jonathan Peppers", "Gerald Versluis", "Rachel Kang", "TJ Lambert",
                "E.Z. Hart", "Rui Marinho", "Shane Neuville", "Samantha Houts", "Jonathan Dick", "Alex Soto",
            });

            TallyItems(e.Frozen_Anything, new string[]{
                "Gerald Versluis", "Steve Hawley", "Shane Neuville", "Jonathan Dick", "Alex Soto", "Jonathan Peppers",  });

            TallyItems(e.You_Doing_Exactly_What_A_Sign_Says, new string[]{
                "Steve Hawley", "Shane Neuville", "Alex Soto",  });

            TallyItems(e.A_Candle, new string[]{
                "Steve Hawley", "Gerald Versluis", "Jonathan Peppers", "Shane Neuville",
                "Rui Marinho", "Alex Soto"
            });

            TallyItems(e.Something_With_Microsoft_Logo, new string[]{
                "Jonathan Peppers", "Gerald Versluis", "Samantha Houts", "Steve Hawley", "Rachel Kang",
                "E.Z. Hart", "Shane Neuville", "Rui Marinho", "Jonathan Dick", "Alex Soto",
            });

            TallyItems(e.Your_Favorite_Mug, new string[]{
                "Jonathan Peppers", "Gerald Versluis", "Steve Hawley", "Samantha Houts", "TJ Lambert",
                "Rui Marinho", "Shane Neuville", "Alex Soto", "Jonathan Dick",
            });

            TallyItems(e.Perform_A_Tiktok_Dance, new string[]{
                "TJ Lambert", "Gerald Versluis", "Steve Hawley", "Samantha Houts", "Shane Neuville", "Alex Soto",  });

            TallyItems(e.Something_You_Cooked_Baked, new string[]{
                "Steve Hawley", "Gerald Versluis", "Rachel Kang", "E.Z. Hart", "Shane Neuville", "Jonathan Dick", "Alex Soto", });

            TallyItems(e.Video_Telling_Us_Your_Favorite_Joke, new string[]{
                "Steve Hawley", "Gerald Versluis", "Shane Neuville", "Rui Marinho", "Alex Soto", });

            TallyItems(e.Sock_With_A_Hole_In_It, new string[]{
                "Gerald Versluis", "TJ Lambert", "Samantha Houts", "Shane Neuville", "Steve Hawley",
                "Rui Marinho", "Alex Soto",
            });

            TallyItems(e.Baby_Childhood_Photo, new string[]{
                "Steve Hawley", "Samantha Houts", "Gerald Versluis", "TJ Lambert",
                "Shane Neuville", "Rui Marinho", "E.Z. Hart", "Jonathan Peppers", "Alex Soto",
            });

            TallyItems(e.Something_You_Cant_Live_Without, new string[]{
                "TJ Lambert", "Gerald Versluis", "Rachel Kang", "Steve Hawley", "Shane Neuville", "Rui Marinho", "Jonathan Dick", "Alex Soto", });

            TallyItems(e.A_Coin_From_The_Year_2021, new string[]{
                "Steve Hawley", "Shane Neuville",
                "Gerald Versluis", "Alex Soto",
            });

            TallyItems(e.The_View_From_Your_Window, new string[]{
                "Steve Hawley", "Gerald Versluis", "Jonathan Peppers", "TJ Lambert",
                "Shane Neuville", "Rui Marinho", "Jonathan Dick", "Alex Soto",
            });

            TallyItems(e.A_Very_Very_Large_Tree, new string[]{
                "Steve Hawley", "TJ Lambert", "Rachel Kang", "Shane Neuville", "Gerald Versluis",
                "Samantha Houts",
            });

            TallyItems(e.Something_That_Came_Out_The_Year_You_Were_Born, new string[]{
                "Steve Hawley", "Shane Neuville", "Gerald Versluis", "Rui Marinho", "Samantha Houts",
                "Alex Soto", "Jonathan Dick",
            });

            TallyItems(e.Piece_Of_Workout_Equipment, new string[]{
                "Gerald Versluis", "Jonathan Peppers", "Steve Hawley", "Shane Neuville", "Rui Marinho",
                "Samantha Houts", "Alex Soto",
            });

            TallyItems(e.Imitate_Your_Favorite_Emoji, new string[]{
                "Samantha Houts", "Steve Hawley", "Gerald Versluis", "Rachel Kang", "Shane Neuville",
                "Alex Soto",
            });

            TallyItems(e.Decoration_With_A_Quote_On_It, new string[]{
                "Steve Hawley", "Gerald Versluis", "Shane Neuville", "Rui Marinho", "Jonathan Dick", "Alex Soto", "Jonathan Peppers"  });

            TallyItems(e.Something_Winter_Holiday_Related, new string[]{
                "Jonathan Peppers", "Gerald Versluis", "Steve Hawley", "Shane Neuville", "Rui Marinho",
                "Samantha Houts", "Alex Soto",
            });

            TallyItems(e.Something_That_Begins_With_The_Letter_Z, new string[]{
                "Steve Hawley", "Gerald Versluis", "Shane Neuville", "Alex Soto", });

            TallyItems(e.A_Book_With_At_Least_300_Pages, new string[]{
                "TJ Lambert", "Steve Hawley", "Samantha Houts", "Jonathan Peppers", "Gerald Versluis",
                "Shane Neuville", "Rui Marinho", "E.Z. Hart", "Alex Soto",
                "Jonathan Dick",
            });

            TallyItems(e.A_Decorative_Pillow, new string[]{
                "Jonathan Peppers", "TJ Lambert", "Steve Hawley", "Samantha Houts",
                "Shane Neuville", "Gerald Versluis", "Rui Marinho", "Alex Soto",
            });

            TallyItems(e.A_Cloud_That_Looks_Like_An_Animal, new string[]{
                "Steve Hawley", "Shane Neuville", "Alex Soto", "Jonathan Peppers" });
        }

        // assign the items to the corresponding bingoboard or create a new one if it doesn't exist
        static void TallyItems(e item, string[] names)
        {
            foreach (var name in names)
            {
                var foundBoard = false;

                foreach (var board in Boards)
                {
                    // if there is already a board with this name, add item
                    if (board.Name == name)
                    {
                        foundBoard = true;
                        board.IncludeItem(item);
                        break;
                    }
                }
                // if we didn't find a board with that name, create one and add that item
                if (!foundBoard)
                {
                    Boards.Add(new BingoBoard(name, item));
                }
            }
        }

        public enum e
        {
            Your_Work_Setup,
            Frozen_Anything,
            You_Doing_Exactly_What_A_Sign_Says,
            A_Candle,
            Something_With_Microsoft_Logo,
            Your_Favorite_Mug,
            Perform_A_Tiktok_Dance,
            Something_You_Cooked_Baked,
            Video_Telling_Us_Your_Favorite_Joke,
            Sock_With_A_Hole_In_It,
            Baby_Childhood_Photo,
            Something_You_Cant_Live_Without,
            A_Coin_From_The_Year_2021,
            The_View_From_Your_Window,
            A_Very_Very_Large_Tree,
            Something_That_Came_Out_The_Year_You_Were_Born,
            Piece_Of_Workout_Equipment,
            Imitate_Your_Favorite_Emoji,
            Decoration_With_A_Quote_On_It,
            Something_Winter_Holiday_Related,
            Something_That_Begins_With_The_Letter_Z,
            A_Book_With_At_Least_300_Pages,
            A_Decorative_Pillow,
            A_Cloud_That_Looks_Like_An_Animal,
        }
    }
}
