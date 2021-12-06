using System;
using System.Text;

namespace BingoScorer
{
    class Program
    {
        static void Main(string[] args)
        {
            var TJBoard = new BingoBoard("TJ Lambert",
                e.Something_You_Cant_Live_Without, e.A_Decorative_Pillow);

            var SteveBoard = new BingoBoard("Steve Hawley",
               e.A_Book_With_At_Least_300_Pages, e.Your_Work_Setup, 
               e.Baby_Childhood_Photo, e.A_Decorative_Pillow, e.Something_You_Cooked_Baked);

            var JonathanBoard = new BingoBoard("Jonathan Peppers",
                e.Your_Favorite_Mug);

            var awards = new Awards(TJBoard, SteveBoard, JonathanBoard);
            Console.Write (awards.GetPlaces());
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
