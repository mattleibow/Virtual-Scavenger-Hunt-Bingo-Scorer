using System;
using static BingoScorer.Participants;
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
				steveHawley, jonathanPeppers, geraldVersluis, rachelKang, tjLambert, ezHart, ruiMarinho, shaneNeuville, samanthaHouts, jonathanDick, alexSoto, israelSoto,
			});

			TallyItems(e.Frozen_Anything, new string[]{
				geraldVersluis, steveHawley, shaneNeuville, alexSoto, jonathanPeppers, ruiMarinho, israelSoto,
			});

			TallyItems(e.You_Doing_Exactly_What_A_Sign_Says, new string[]{
				steveHawley, shaneNeuville, alexSoto, geraldVersluis, jonathanDick, jonathanPeppers, ruiMarinho, israelSoto,
			});

			TallyItems(e.A_Candle, new string[]{
			steveHawley, geraldVersluis, jonathanPeppers, shaneNeuville, ruiMarinho, alexSoto, ezHart, tjLambert, israelSoto,
			});

			TallyItems(e.Something_With_Microsoft_Logo, new string[]{
				jonathanPeppers, geraldVersluis, samanthaHouts, steveHawley, rachelKang, ezHart, shaneNeuville, ruiMarinho, alexSoto, ruiMarinho, tjLambert, israelSoto,
			});

			TallyItems(e.Your_Favorite_Mug, new string[]{
				jonathanPeppers, geraldVersluis, steveHawley, samanthaHouts, tjLambert, ruiMarinho, shaneNeuville, alexSoto, jonathanDick, deanEllis, israelSoto, ezHart,
			});

			TallyItems(e.Perform_A_Tiktok_Dance, new string[]{
				tjLambert, geraldVersluis, steveHawley, samanthaHouts, shaneNeuville, alexSoto, ruiMarinho, jonathanPeppers, israelSoto,
			});

			TallyItems(e.Something_You_Cooked_Baked, new string[]{
				steveHawley, geraldVersluis, rachelKang, ezHart, shaneNeuville, jonathanDick, alexSoto, ruiMarinho, jonathanPeppers, israelSoto, tjLambert,
			});

			TallyItems(e.Video_Telling_Us_Your_Favorite_Joke, new string[]{
				steveHawley, geraldVersluis, shaneNeuville, ruiMarinho, alexSoto, jonathanPeppers, israelSoto,
			});

			TallyItems(e.Sock_With_A_Hole_In_It, new string[]{
				geraldVersluis, tjLambert, samanthaHouts, shaneNeuville, steveHawley, ruiMarinho, alexSoto, jonathanPeppers, israelSoto,
			});

			TallyItems(e.Baby_Childhood_Photo, new string[]{
				steveHawley, samanthaHouts, geraldVersluis, tjLambert, shaneNeuville, ruiMarinho, ezHart, jonathanPeppers, alexSoto, rachelKang, israelSoto,
			});

			TallyItems(e.Something_You_Cant_Live_Without, new string[]{
				tjLambert, geraldVersluis, rachelKang, steveHawley, shaneNeuville, ruiMarinho, alexSoto, jonathanPeppers, israelSoto,
			});

			TallyItems(e.A_Coin_From_The_Year_2021, new string[]{
				steveHawley, shaneNeuville, geraldVersluis, alexSoto, ruiMarinho, ezHart, jonathanPeppers, israelSoto,
			});

			TallyItems(e.The_View_From_Your_Window, new string[]{
				steveHawley, geraldVersluis, jonathanPeppers, tjLambert, shaneNeuville, ruiMarinho, alexSoto, rachelKang, ezHart, israelSoto,
			});

			TallyItems(e.A_Very_Very_Large_Tree, new string[]{
				steveHawley, tjLambert, rachelKang, shaneNeuville, geraldVersluis, samanthaHouts, alexSoto, ruiMarinho, jonathanDick, jonathanPeppers, israelSoto,
			});

			TallyItems(e.Something_That_Came_Out_The_Year_You_Were_Born, new string[]{
				steveHawley, shaneNeuville, geraldVersluis, ruiMarinho, samanthaHouts, alexSoto, jonathanPeppers, tjLambert, israelSoto,
			});

			TallyItems(e.Piece_Of_Workout_Equipment, new string[]{
				geraldVersluis, jonathanPeppers, steveHawley, shaneNeuville, ruiMarinho, samanthaHouts, alexSoto, ezHart, tjLambert, israelSoto,
			});

			TallyItems(e.Imitate_Your_Favorite_Emoji, new string[]{
				steveHawley, geraldVersluis, rachelKang, shaneNeuville, alexSoto, ruiMarinho, jonathanDick, jonathanPeppers, israelSoto,
			});

			TallyItems(e.Decoration_With_A_Quote_On_It, new string[]{
				steveHawley, geraldVersluis, shaneNeuville, ruiMarinho, jonathanDick, alexSoto, jonathanPeppers, samanthaHouts, israelSoto,
			});

			TallyItems(e.Something_Winter_Holiday_Related, new string[]{
				jonathanPeppers, geraldVersluis, steveHawley, shaneNeuville, ruiMarinho, samanthaHouts, alexSoto, rachelKang, tjLambert, ezHart, israelSoto,
			});

			TallyItems(e.Something_That_Begins_With_The_Letter_Z, new string[]{
				steveHawley, geraldVersluis, shaneNeuville, alexSoto, ruiMarinho, rachelKang, jonathanPeppers, tjLambert, israelSoto,
			});

			TallyItems(e.A_Book_With_At_Least_300_Pages, new string[]{
				tjLambert, steveHawley, samanthaHouts, jonathanPeppers, geraldVersluis, shaneNeuville, ruiMarinho, ezHart, alexSoto, jonathanDick, deanEllis ,rachelKang, israelSoto,
			});

			TallyItems(e.A_Decorative_Pillow, new string[]{
				jonathanPeppers, tjLambert, steveHawley, samanthaHouts, shaneNeuville, geraldVersluis, alexSoto, ezHart, rachelKang, israelSoto,
			});

			TallyItems(e.A_Cloud_That_Looks_Like_An_Animal, new string[]{
				steveHawley, shaneNeuville, alexSoto, jonathanPeppers, ruiMarinho, geraldVersluis, rachelKang, tjLambert, israelSoto,
			});
		}

		// assign the items to the corresponding bingoboard or create a new one if it doesn't exist
		static void TallyItems(e item, string[] names)
		{
			foreach (var name in names) {
				var foundBoard = false;

				foreach (var board in Boards) {
					// if there is already a board with this name, add item
					if (board.Name == name) {
						foundBoard = true;
						board.IncludeItem(item);
						break;
					}
				}
				// if we didn't find a board with that name, create one and add that item
				if (!foundBoard) {
					Boards.Add(new BingoBoard(name, item));
				}
			}
		}

		public enum e
		{
			// Row 1
			Your_Work_Setup,
			Frozen_Anything,
			You_Doing_Exactly_What_A_Sign_Says,
			A_Candle,
			Something_With_Microsoft_Logo,

			// Row 2
			Your_Favorite_Mug,
			Perform_A_Tiktok_Dance,
			Something_You_Cooked_Baked,
			Video_Telling_Us_Your_Favorite_Joke,
			Sock_With_A_Hole_In_It,

			// Row 3
			Baby_Childhood_Photo,
			Something_You_Cant_Live_Without,
			A_Coin_From_The_Year_2021,
			The_View_From_Your_Window,

			// Row 4
			A_Very_Very_Large_Tree,
			Something_That_Came_Out_The_Year_You_Were_Born,
			Piece_Of_Workout_Equipment,
			Imitate_Your_Favorite_Emoji,
			Decoration_With_A_Quote_On_It,

			// Row5
			Something_Winter_Holiday_Related,
			Something_That_Begins_With_The_Letter_Z,
			A_Book_With_At_Least_300_Pages,
			A_Decorative_Pillow,
			A_Cloud_That_Looks_Like_An_Animal,
		}
	}
}
