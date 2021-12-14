using System;
using System.Text;

namespace BingoScorer
{
    public class BingoBoard
    {
        internal bool Your_Work_Setup { get; set; }
        internal bool Frozen_Anything { get; set; }
        internal bool You_Doing_Exactly_What_A_Sign_Says { get; set; }
        internal bool A_Candle { get; set; }
        internal bool Something_With_Microsoft_Logo { get; set; }
        internal bool Your_Favorite_Mug { get; set; }
        internal bool Perform_A_Tiktok_Dance { get; set; }
        internal bool Something_You_Cooked_Baked { get; set; }
        internal bool Video_Telling_Us_Your_Favorite_Joke { get; set; }
        internal bool Sock_With_A_Hole_In_It { get; set; }
        internal bool Baby_Childhood_Photo { get; set; }
        internal bool Something_You_Cant_Live_Without { get; set; }
        internal bool A_Coin_From_The_Year_2021 { get; set; }
        internal bool The_View_From_Your_Window { get; set; }
        internal bool A_Very_Very_Large_Tree { get; set; }
        internal bool Something_That_Came_Out_The_Year_You_Were_Born { get; set; }
        internal bool Piece_Of_Workout_Equipment { get; set; }
        internal bool Imitate_Your_Favorite_Emoji { get; set; }
        internal bool Decoration_With_A_Quote_On_It { get; set; }
        internal bool Something_Winter_Holiday_Related { get; set; }
        internal bool Something_That_Begins_With_The_Letter_Z { get; set; }
        internal bool A_Book_With_At_Least_300_Pages { get; set; }
        internal bool A_Decorative_Pillow { get; set; }
        internal bool A_Cloud_That_Looks_Like_An_Animal { get; set; }
        internal bool Free_Space { get; set; } = true;

        public string Name { get; set; }
        public float Score { get; set; }
        public StringBuilder Log { get; set; } = new StringBuilder("Point Breakdown:\n");
        public string Drawing { get; set; }

        public BingoBoard(string name, params e[] items)
        {
            Name = name;
            foreach (var item in items)
            {
                this.IncludeItem(item);
            }
        }

        public void DrawBoard ()
        {
            StringBuilder sb = new StringBuilder ("-----------\n");
            // Row 1
            sb.Append($"|{Mark(Your_Work_Setup)}|{Mark(Frozen_Anything)}|{Mark(You_Doing_Exactly_What_A_Sign_Says)}|{Mark(A_Candle)}|{Mark(Something_With_Microsoft_Logo)}|\n");

            // Row 2
            sb.Append($"|{Mark(Your_Favorite_Mug)}|{Mark(Perform_A_Tiktok_Dance)}|{Mark(Something_You_Cooked_Baked)}|{Mark(Video_Telling_Us_Your_Favorite_Joke)}|{Mark(Sock_With_A_Hole_In_It)}|\n");

            // Row 3
            sb.Append($"|{Mark(Baby_Childhood_Photo)}|{Mark(Something_You_Cant_Live_Without)}|{Mark(Free_Space)}|{Mark(A_Coin_From_The_Year_2021)}|{Mark(The_View_From_Your_Window)}|\n");

            // Row 4
            sb.Append($"|{Mark(A_Very_Very_Large_Tree)}|{Mark(Something_That_Came_Out_The_Year_You_Were_Born)}|{Mark(Piece_Of_Workout_Equipment)}|{Mark(Imitate_Your_Favorite_Emoji)}|{Mark(Decoration_With_A_Quote_On_It)}|\n");

            // Row 5
            sb.Append($"|{Mark(Something_Winter_Holiday_Related)}|{Mark(Something_That_Begins_With_The_Letter_Z)}|{Mark(A_Book_With_At_Least_300_Pages)}|{Mark(A_Decorative_Pillow)}|{Mark(A_Cloud_That_Looks_Like_An_Animal)}|\n");

            sb.Append("-----------\n");

            Drawing = sb.ToString();
        }

        char Mark (bool val)
        {
            if (val)
                return 'X';
            return '_';
        }

        public void CalculateScore()
        {
            // We can only calculate the scores one time!
            if (Score != 0)
                return;

            CalculateAndFalsifyShapes();

            // Do not Falisfy Verticals and Horizontals til they are all finished!
            CalculateVerticalHorizontals();
            FalsifyVerticalHorizontals();

            CleanUpExtraSpaces();
        }

        void CalculateAndFalsifyShapes()
        {
            if (IsFullBoard())
            {
                FalsifyFullBoard();
                Score += 1000000;
                Log.AppendLine("FullBoard! +1,000,000 Points!!");
            }

            if (IsSnowFlake())
            {
                FalsifySnowFlake();
                Score += 5000;
                Log.AppendLine("Snowflake +5,000 Points");
            }

            if (IsX())
            {
                FalsifyX();
                Score += 1000;
                Log.AppendLine("X for Xamarin +1,000 Points");
            }

            if (IsFourCorners())
            {
                FalsifyFourCorners();
                Score += 500;
                Log.AppendLine("Four Corners +500 Points");
            }
        }

        void CalculateVerticalHorizontals()
        {
            if (IsVertical5())
            {
                Score += 100;
                Log.AppendLine("Vertical 5 +100 Points");
            }

            if (IsVertical4())
            {
                Score += 100;
                Log.AppendLine("Vertical 4 +100 Points");
            }

            if (IsVertical3())
            {
                Score += 100;
                Log.AppendLine("Vertical 3 +100 Points");
            }

            if (IsVertical2())
            {
                Score += 100;
                Log.AppendLine("Vertical 2 +100 Points");
            }

            if (IsVertical1())
            {
                Score += 100;
                Log.AppendLine("Vertical 1 +100 Points");
            }

            if (IsHorizontal5())
            {
                Score += 100;
                Log.AppendLine("Horizontal 5 +100 Points");
            }

            if (IsHorizontal4())
            {
                Score += 100;
                Log.AppendLine("Horizontal 4 +100 Points");
            }

            if (IsHorizontal3())
            {
                Score += 100;
                Log.AppendLine("Horizontal 3 +100 Points");
            }

            if (IsHorizontal2())
            {
                Score += 100;
                Log.AppendLine("Horizontal 2 +100 Points");
            }

            if (IsHorizontal1())
            {
                Score += 100;
                Log.AppendLine("Horizontal 1 +100 Points");
            }
        }

        void FalsifyVerticalHorizontals()
        {
            if (IsVertical5())
                FalsifyVertical5();

            if (IsVertical4())
                FalsifyVertical4();

            if (IsVertical3())
                FalsifyVertical3();

            if (IsVertical2())
                FalsifyVertical2();

            if (IsVertical1())
                FalsifyVertical1();

            if (IsHorizontal5())
                FalsifyHorizontal5();

            if (IsHorizontal4())
                FalsifyHorizontal4();

            if (IsHorizontal3())
                FalsifyHorizontal3();

            if (IsHorizontal2())
                FalsifyHorizontal2();

            if (IsHorizontal1())
                FalsifyHorizontal1();
        }

        void CleanUpExtraSpaces()
        {
            //// Add a point for the Free Space if not yet Claimed
            //if (Free_Space)
            //{
            //    Score += 10;
            //    Log.AppendLine("Free Space +10 Points");
            //}
            if (Your_Work_Setup)
            {
                Score += 10;
                Log.AppendLine("Your Work Setup +10 Points");
            }
            if (Frozen_Anything)
            {
                Score += 10;
                Log.AppendLine("Frozen Anything +10 Points");
            }
            if (You_Doing_Exactly_What_A_Sign_Says)
            {
                Score += 10;
                Log.AppendLine("You Doing Exactly What A Sign Says +10 Points");
            }
            if (A_Candle)
            {
                Score += 10;
                Log.AppendLine("A Candle +10 Points");
            }
            if (Something_With_Microsoft_Logo)
            {
                Score += 10;
                Log.AppendLine("Something With Microsoft Logo +10 Points");
            }
            if (Your_Favorite_Mug)
            {
                Score += 10;
                Log.AppendLine("Your Favorite Mug +10 Points");
            }
            if (Perform_A_Tiktok_Dance)
            {
                Score += 10;
                Log.AppendLine("Perform A Tiktok Dance +10 Points");
            }
            if (Something_You_Cooked_Baked)
            {
                Score += 10;
                Log.AppendLine("Something You Cooked or Baked +10 Points");
            }
            if (Video_Telling_Us_Your_Favorite_Joke)
            {
                Score += 10;
                Log.AppendLine("Video Telling Us Your Favorite Joke +10 Points");
            }
            if (Sock_With_A_Hole_In_It)
            {
                Score += 10;
                Log.AppendLine("Sock With A Hole In It +10 Points");
            }
            if (Baby_Childhood_Photo)
            {
                Score += 10;
                Log.AppendLine("Baby or Childhood Photo +10 Points");
            }
            if (Something_You_Cant_Live_Without)
            {
                Score += 10;
                Log.AppendLine("Something You Cant Live Without +10 Points");
            }
            if (A_Coin_From_The_Year_2021)
            {
                Score += 10;
                Log.AppendLine("A Coin From The Year 2021 +10 Points");
            }
            if (The_View_From_Your_Window)
            {
                Score += 10;
                Log.AppendLine("The View From Your Window +10 Points");
            }
            if (A_Very_Very_Large_Tree)
            {
                Score += 10;
                Log.AppendLine("A Very Very Large Tree +10 Points");
            }
            if (Something_That_Came_Out_The_Year_You_Were_Born)
            {
                Score += 10;
                Log.AppendLine("Something That Came Out The Year You Were Born +10 Points");
            }
            if (Piece_Of_Workout_Equipment)
            {
                Score += 10;
                Log.AppendLine("Piece Of Workout Equipment +10 Points");
            }
            if (Imitate_Your_Favorite_Emoji)
            {
                Score += 10;
                Log.AppendLine("Imitate Your Favorite Emoji +10 Points");
            }
            if (Decoration_With_A_Quote_On_It)
            {
                Score += 10;
                Log.AppendLine("Decoration With A Quote On It +10 Points");
            }
            if (Something_Winter_Holiday_Related)
            {
                Score += 10;
                Log.AppendLine("Something Winter Holiday Related +10 Points");
            }
            if (Something_That_Begins_With_The_Letter_Z)
            {
                Score += 10;
                Log.AppendLine("Something That Begins With The Letter Z +10 Points");
            }
            if (A_Book_With_At_Least_300_Pages)
            {
                Score += 10;
                Log.AppendLine("A Book With At Least 300 Pages +10 Points");
            }
            if (A_Decorative_Pillow)
            {
                Score += 10;
                Log.AppendLine("A Decorative Pillow +10 Points");
            }
            if (A_Cloud_That_Looks_Like_An_Animal)
            {
                Score += 10;
                Log.AppendLine("A Cloud That Looks Like An Animal +10 Points");
            }
        }

        bool IsVertical1()
        {
            return Your_Work_Setup && Your_Favorite_Mug && Baby_Childhood_Photo
                && A_Very_Very_Large_Tree && Something_Winter_Holiday_Related;
        }

        void FalsifyVertical1()
        {
            Your_Work_Setup = false;
            Your_Favorite_Mug = false;
            Baby_Childhood_Photo = false;
            A_Very_Very_Large_Tree = false;
            Something_Winter_Holiday_Related = false;
        }

        bool IsVertical2()
        {
            return Frozen_Anything && Perform_A_Tiktok_Dance && Something_You_Cant_Live_Without
                && Something_That_Came_Out_The_Year_You_Were_Born
                && Something_That_Begins_With_The_Letter_Z;
        }

        void FalsifyVertical2()
        {
            Frozen_Anything = false;
            Perform_A_Tiktok_Dance = false;
            Something_You_Cant_Live_Without = false;
            Something_That_Came_Out_The_Year_You_Were_Born = false;
            Something_That_Begins_With_The_Letter_Z = false;
        }

        bool IsVertical3()
        {
            return You_Doing_Exactly_What_A_Sign_Says && Something_You_Cooked_Baked
                && Piece_Of_Workout_Equipment && A_Book_With_At_Least_300_Pages;
        }

        void FalsifyVertical3()
        {
            You_Doing_Exactly_What_A_Sign_Says = false;
            Something_You_Cooked_Baked = false;
            Piece_Of_Workout_Equipment = false;
            A_Book_With_At_Least_300_Pages = false;
            Free_Space = false;
        }

        bool IsVertical4()
        {
            return A_Candle && Video_Telling_Us_Your_Favorite_Joke && A_Coin_From_The_Year_2021
                && Imitate_Your_Favorite_Emoji && A_Decorative_Pillow;
        }

        void FalsifyVertical4()
        {
            A_Candle = false;
            Video_Telling_Us_Your_Favorite_Joke = false;
            A_Coin_From_The_Year_2021 = false;
            Imitate_Your_Favorite_Emoji = false;
            A_Decorative_Pillow = false;
        }

        bool IsVertical5()
        {
            return Something_With_Microsoft_Logo && Sock_With_A_Hole_In_It && The_View_From_Your_Window
                && Decoration_With_A_Quote_On_It && A_Cloud_That_Looks_Like_An_Animal;
        }

        void FalsifyVertical5()
        {
            Something_With_Microsoft_Logo = false;
            Sock_With_A_Hole_In_It = false;
            The_View_From_Your_Window = false;
            Decoration_With_A_Quote_On_It = false;
            A_Cloud_That_Looks_Like_An_Animal = false;
        }

        bool IsHorizontal1()
        {
            return Your_Work_Setup && Frozen_Anything && You_Doing_Exactly_What_A_Sign_Says
                && A_Candle && Something_With_Microsoft_Logo;
        }

        void FalsifyHorizontal1()
        {
            Your_Work_Setup = false;
            Frozen_Anything = false;
            You_Doing_Exactly_What_A_Sign_Says = false;
            A_Candle = false;
            Something_With_Microsoft_Logo = false;
        }

        bool IsHorizontal2()
        {
            return Your_Favorite_Mug && Perform_A_Tiktok_Dance && Something_You_Cooked_Baked
                && Video_Telling_Us_Your_Favorite_Joke && Sock_With_A_Hole_In_It;
        }

        void FalsifyHorizontal2()
        {
            Your_Favorite_Mug = false;
            Perform_A_Tiktok_Dance = false;
            Something_You_Cooked_Baked = false;
            Video_Telling_Us_Your_Favorite_Joke = false;
            Sock_With_A_Hole_In_It = false;
        }

        bool IsHorizontal3()
        {
            return Baby_Childhood_Photo && Something_You_Cant_Live_Without
                && A_Coin_From_The_Year_2021 && The_View_From_Your_Window;
        }

        void FalsifyHorizontal3()
        {
            Baby_Childhood_Photo = false;
            Something_You_Cant_Live_Without = false;
            A_Coin_From_The_Year_2021 = false;
            The_View_From_Your_Window = false;
            Free_Space = false;
        }

        bool IsHorizontal4()
        {
            return A_Very_Very_Large_Tree && Something_That_Came_Out_The_Year_You_Were_Born
                && Piece_Of_Workout_Equipment && Imitate_Your_Favorite_Emoji && Decoration_With_A_Quote_On_It;
        }

        void FalsifyHorizontal4()
        {
            A_Very_Very_Large_Tree = false;
            Something_That_Came_Out_The_Year_You_Were_Born = false;
            Piece_Of_Workout_Equipment = false;
            Imitate_Your_Favorite_Emoji = false;
            Decoration_With_A_Quote_On_It = false;
        }

        bool IsHorizontal5()
        {
            return Something_Winter_Holiday_Related && Something_That_Begins_With_The_Letter_Z
                && A_Book_With_At_Least_300_Pages && A_Decorative_Pillow && A_Cloud_That_Looks_Like_An_Animal;
        }

        void FalsifyHorizontal5()
        {
            Something_Winter_Holiday_Related = false;
            Something_That_Begins_With_The_Letter_Z = false;
            A_Book_With_At_Least_300_Pages = false;
            A_Decorative_Pillow = false;
            A_Cloud_That_Looks_Like_An_Animal = false;
        }

        bool IsFourCorners()
        {
            return Your_Work_Setup && Something_With_Microsoft_Logo
                && Something_Winter_Holiday_Related && A_Cloud_That_Looks_Like_An_Animal;
        }

        void FalsifyFourCorners()
        {
            Your_Work_Setup = false;
            Something_With_Microsoft_Logo = false;
            Something_Winter_Holiday_Related = false;
            A_Cloud_That_Looks_Like_An_Animal = false;
        }

        bool IsX()
        {
            return IsFourCorners() & Perform_A_Tiktok_Dance && Video_Telling_Us_Your_Favorite_Joke
                && Something_That_Came_Out_The_Year_You_Were_Born && Imitate_Your_Favorite_Emoji;
        }

        void FalsifyX()
        {
            FalsifyFourCorners();
            Perform_A_Tiktok_Dance = false;
            Video_Telling_Us_Your_Favorite_Joke = false;
            Something_That_Came_Out_The_Year_You_Were_Born = false;
            Imitate_Your_Favorite_Emoji = false;
            Free_Space = false;
        }

        bool IsSnowFlake()
        {
            return IsX() && IsHorizontal3() && IsVertical3();
        }

        void FalsifySnowFlake()
        {
            FalsifyX();
            FalsifyHorizontal3();
            FalsifyVertical3();
            Free_Space = false;
        }


        bool IsFullBoard()
        {
            return IsSnowFlake() && Your_Favorite_Mug && Frozen_Anything && A_Candle
                && Sock_With_A_Hole_In_It && Decoration_With_A_Quote_On_It
                && A_Decorative_Pillow && Something_That_Begins_With_The_Letter_Z
                && A_Very_Very_Large_Tree;
        }

        void FalsifyFullBoard()
        {
            Your_Favorite_Mug = false;
            Frozen_Anything = false;
            A_Candle = false;
            Sock_With_A_Hole_In_It = false;
            Decoration_With_A_Quote_On_It = false;
            A_Decorative_Pillow = false;
            Something_That_Begins_With_The_Letter_Z = false;
            A_Very_Very_Large_Tree = false;
            Free_Space = false;
            FalsifySnowFlake();
        }
    }

    public static class BingoBoardExtensions
    {
        public static void IncludeItem(this BingoBoard board, e item)
        {
            switch (item)
            {
                case e.Your_Work_Setup:
                    board.Your_Work_Setup = true;
                    break;

                case e.Frozen_Anything:
                    board.Frozen_Anything = true;
                    break;

                case e.You_Doing_Exactly_What_A_Sign_Says:
                    board.You_Doing_Exactly_What_A_Sign_Says = true;
                    break;

                case e.A_Candle:
                    board.A_Candle = true;
                    break;

                case e.Something_With_Microsoft_Logo:
                    board.Something_With_Microsoft_Logo = true;
                    break;

                case e.Your_Favorite_Mug:
                    board.Your_Favorite_Mug = true;
                    break;

                case e.Perform_A_Tiktok_Dance:
                    board.Perform_A_Tiktok_Dance = true;
                    break;

                case e.Something_You_Cooked_Baked:
                    board.Something_You_Cooked_Baked = true;
                    break;

                case e.Video_Telling_Us_Your_Favorite_Joke:
                    board.Video_Telling_Us_Your_Favorite_Joke = true;
                    break;

                case e.Sock_With_A_Hole_In_It:
                    board.Sock_With_A_Hole_In_It = true;
                    break;

                case e.Baby_Childhood_Photo:
                    board.Baby_Childhood_Photo = true;
                    break;

                case e.Something_You_Cant_Live_Without:
                    board.Something_You_Cant_Live_Without = true;
                    break;

                case e.A_Coin_From_The_Year_2021:
                    board.A_Coin_From_The_Year_2021 = true;
                    break;

                case e.The_View_From_Your_Window:
                    board.The_View_From_Your_Window = true;
                    break;

                case e.A_Very_Very_Large_Tree:
                    board.A_Very_Very_Large_Tree = true;
                    break;

                case e.Something_That_Came_Out_The_Year_You_Were_Born:
                    board.Something_That_Came_Out_The_Year_You_Were_Born = true;
                    break;

                case e.Piece_Of_Workout_Equipment:
                    board.Piece_Of_Workout_Equipment = true;
                    break;

                case e.Imitate_Your_Favorite_Emoji:
                    board.Imitate_Your_Favorite_Emoji = true;
                    break;

                case e.Decoration_With_A_Quote_On_It:
                    board.Decoration_With_A_Quote_On_It = true;
                    break;

                case e.Something_Winter_Holiday_Related:
                    board.Something_Winter_Holiday_Related = true;
                    break;

                case e.Something_That_Begins_With_The_Letter_Z:
                    board.Something_That_Begins_With_The_Letter_Z = true;
                    break;

                case e.A_Book_With_At_Least_300_Pages:
                    board.A_Book_With_At_Least_300_Pages = true;
                    break;

                case e.A_Decorative_Pillow:
                    board.A_Decorative_Pillow = true;
                    break;

                case e.A_Cloud_That_Looks_Like_An_Animal:
                    board.A_Cloud_That_Looks_Like_An_Animal = true;
                    break;
            }
        }
    }
}
