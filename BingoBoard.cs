using System;
using System.Text;
using static BingoScorer.MarkBoard;
using static BingoScorer.BoadParts;
using System.ComponentModel;

namespace BingoScorer
{
	// This class is responsible for assigning the points to a bingo board
	// as well as creating a drawing and log for the points that were assigned
	public class BingoBoard
	{
		public readonly Dictionary<e, bool> Squares =
			Enum.GetValues<e>().ToDictionary(k => k, k => false);

		public string Name { get; set; }
		public float Score { get; set; }
		public StringBuilder Log { get; set; } = new StringBuilder("Point Breakdown:\n");
		public string Drawing { get; set; }

		public BingoBoard(string name, params e[] items)
		{
			Name = name;
			foreach (var item in items) {
				Squares[item] = true;
			}
		}

		public void DrawBoard ()
		{
			StringBuilder sb = new StringBuilder ("-----------\n");

			// Row 1
			sb.Append(
				$"|{Mark(m.Row1 | m.Col1)}" +
				$"|{Mark(m.Row1 | m.Col2)}" +
				$"|{Mark(m.Row1 | m.Col3)}" +
				$"|{Mark(m.Row1 | m.Col4)}" +
				$"|{Mark(m.Row1 | m.Col5)}|\n");

			// Row 2
			sb.Append(
				$"|{Mark(m.Row2 | m.Col1)}" +
				$"|{Mark(m.Row2 | m.Col2)}" +
				$"|{Mark(m.Row2 | m.Col3)}" +
				$"|{Mark(m.Row2 | m.Col4)}" +
				$"|{Mark(m.Row2 | m.Col5)}|\n");

			// Row 3
			sb.Append(
				$"|{Mark(m.Row3 | m.Col1)}" +
				$"|{Mark(m.Row3 | m.Col2)}" +
				$"|{Mark(m.Row3 | m.Col3)}" +
				$"|{Mark(m.Row3 | m.Col4)}" +
				$"|{Mark(m.Row3 | m.Col5)}|\n");

			// Row 4
			sb.Append(
				$"|{Mark(m.Row4 | m.Col1)}" +
				$"|{Mark(m.Row4 | m.Col2)}" +
				$"|{Mark(m.Row4 | m.Col3)}" +
				$"|{Mark(m.Row4 | m.Col4)}" +
				$"|{Mark(m.Row4 | m.Col5)}|\n");

			// Row 5
			sb.Append(
				$"|{Mark(m.Row5 | m.Col1)}" +
				$"|{Mark(m.Row5 | m.Col2)}" +
				$"|{Mark(m.Row5 | m.Col3)}" +
				$"|{Mark(m.Row5 | m.Col4)}" +
				$"|{Mark(m.Row5 | m.Col5)}|\n");

			sb.Append("-----------\n");

			Drawing = sb.ToString();
		}

		char Mark (m mask)
		{
			foreach (var square in Squares) {
				if (square.Key.HasFlag((e)(int)mask) && square.Value)
					return 'x';
			}
			return '_';
		}

		public void CalculateScore ()
		{
			// We can only calculate the scores one time!
			if (Score != 0)
				return;

			CalculateFullBoard (1_000_000);

			CalculateShapes (500);

			CalculateVerticalHorizontals (50);

			AddEachSpace (10);
		}

		void CalculateFullBoard (int score)
		{
			if (Is (m.All)) {
				Score += score;
				Log.AppendLine($"Full Board! +{score} Points!!");
			}
		}

		void CalculateShapes (int score)
		{
			var shapes = new [] {
				m.Shape1,
				m.Shape2,
				m.Shape3,
				m.Shape4,
			};

			foreach (var shape in shapes) {
				if (Is (shape)) {
					Score += score;
					Log.AppendLine($"'{Message(shape)}' +{score} Points");
				}
			}
		}

		void CalculateVerticalHorizontals(int score)
		{
			var verticals = new [] {
				m.Col1,
				m.Col2,
				m.Col3,
				m.Col4,
				m.Col5,
			};

			foreach (var shape in verticals) {
				if (Is (shape)) {
					Score += score;
					Log.AppendLine($"{Message(shape)} +{score} Points");
				}
			}

			var horizontals = new [] {
				m.Row1,
				m.Row2,
				m.Row3,
				m.Row4,
				m.Row5,
			};

			foreach (var shape in horizontals) {
				if (Is (shape)) {
					Score += score;
					Log.AppendLine($"{Message(shape)} +{score} Points");
				}
			}
		}

		void AddEachSpace(int score)
		{
			foreach (var square in Enum.GetValues<e>()) {
				if (Squares[square]) {
					Score += score;
					Log.AppendLine($"{Message(square)} +{score} Points");
				}
			}
		}

		bool Is (m mask) =>
			Squares.Where(p => p.Key.HasFlag((e)(int)mask)).All(p => p.Value == true);

		string Message<T>(T item)
		{
			var type = typeof(T);
			var memInfo = type.GetMember(item.ToString());
			var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
			return (attributes.Length > 0)
				? ((DescriptionAttribute)attributes[0]).Description
				: item.ToString();
		}
	}

	public static class BoadParts
	{
		public enum m
		{
			All  = 0,

			// lines (rows or columns)
			[Description("Horizontal 1")]
			Row1    = 1 << 0,
			[Description("Horizontal 2")]
			Row2    = 1 << 1,
			[Description("Horizontal 3")]
			Row3    = 1 << 2,
			[Description("Horizontal 4")]
			Row4    = 1 << 3,
			[Description("Horizontal 5")]
			Row5    = 1 << 4,

			// type
			[Description("Vertical 1")]
			Col1      = 1 << 5,
			[Description("Vertical 2")]
			Col2      = 1 << 6,
			[Description("Vertical 3")]
			Col3      = 1 << 7,
			[Description("Vertical 4")]
			Col4      = 1 << 8,
			[Description("Vertical 5")]
			Col5      = 1 << 9,

			// Shape2
			[Description("V")]
			Shape1   = 1 << 10,
			[Description("S")]
			Shape2   = 1 << 11,
			[Description("C")]
			Shape3   = 1 << 12,
			[Description("X")]
			Shape4   = 1 << 13,
		}

		public enum e
		{
			// Row 1
			[Description("Find someone who has a custom uploaded Teams background")]
			CustomTeamsBackground = m.Row1 | m.Col1 | m.Shape1 | m.Shape4,
			[Description("Share a picture of you with your breakfast from today")]
			BreakfastPicture = m.Row1 | m.Col2 | m.Shape2 | m.Shape3,
			[Description("Find someone who has colorful lights in their workspace")]
			ColorfulLights = m.Row1 | m.Col3 | m.Shape2 | m.Shape3,
			[Description("Find someone who shares the same birthday month as you")]
			SameBirthday = m.Row1 | m.Col4 | m.Shape2 | m.Shape3,
			[Description("Share a picture of you with any plants you grow")]
			PlantPicture = m.Row1 | m.Col5 | m.Shape1 | m.Shape4,

			// Row 2
			[Description("Find someone who has published an app on any app store")]
			PublishedApp = m.Row2 | m.Col1 | m.Shape1 | m.Shape3,
			[Description("Find someone who has been on their team (at the M1 level) for less than 1 year")]
			NewTeamMember = m.Row2 | m.Col2 | m.Shape2 | m.Shape4,
			[Description("Find someone who can recite at least the first 20 digits of pi from memory")]
			Pi20 = m.Row2 | m.Col3,
			[Description("Find someone who has watched your favorite TV show")]
			WatchedFavoriteTVShow = m.Row2 | m.Col4 | m.Shape4,
			[Description("Share a picture of some wall art")]
			WallArtPicture = m.Row2 | m.Col5 | m.Shape1,

			// Row 3
			[Description("Share a picture of you with a unique item you have at your house ")]
			UniqueItemPicture = m.Row3 | m.Col1 | m.Shape3,
			[Description("Find Someone who has a pet that is not a dog or cat")]
			NonCatDog = m.Row3 | m.Col2 | m.Shape1 | m.Shape2,
			[Description("Share your favorite memory (in any form)")]
			FavoriteMemory = m.Row3 | m.Col3 | m.Shape2 | m.Shape4,
			[Description("a picture of you with a physical object that has your country's flag on it")]
			CountryFlagPicture = m.Row3 | m.Col4 | m.Shape1 | m.Shape2,
			[Description("Find someone who knows more than one language")]
			MoreThanOneLanguage = m.Row3 | m.Col5,

			// Row 4
			[Description("Find someone who has played your favorite game")]
			PlayedFavoriteGame = m.Row4 | m.Col1 | m.Shape3,
			[Description("Find someone who once started their own company")]
			StartedCompany = m.Row4 | m.Col2 | m.Shape1 | m.Shape4,
			[Description("Share a picture of you featuring your hairstyle from at least 10 years ago")]
			HairstyleTenYearsAgoPicture = m.Row4 | m.Col3,
			[Description("Share a recent video of you performing music (at least 10 seconds)")]
			PerformingMusic = m.Row4 | m.Col4 | m.Shape1 | m.Shape2 | m.Shape4,
			[Description("Share a picture of you with something you handmade (i.e. painted, constructed, 3D-printed)")]
			HandmadePicture = m.Row4 | m.Col5,

			// Row5
			[Description("Share a picture of you with a book that you are reading or plan to read")]
			BookPicture = m.Row5 | m.Col1 | m.Shape4,
			[Description("Find someone who has published a book / academic research")]
			PublishedBookAcademicResearch = m.Row5 | m.Col2 | m.Shape2 | m.Shape3,
			[Description("Find someone who can perfectly recite the alphabet backwards (any language, <15s)")]
			BackwardsAlphabet = m.Row5 | m.Col3 | m.Shape1 | m.Shape2 | m.Shape3,
			[Description("Share a picture of you with your favorite nerdy/geeky pastime")]
			FavoriteNerdyGeekyPastimePicture = m.Row5 | m.Col4 | m.Shape2 | m.Shape3,
			[Description("Share a picture of you with your favorite snack")]
			FavoriteSnackPicture = m.Row5 | m.Col5 | m.Shape4,
		}
	}
}
