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
				Log.AppendLine($"FullBoard! +{score} Points!!");
			}
		}

		void CalculateShapes (int score)
		{
			if (Is (m.ShapeV)) {
				Score += score;
				Log.AppendLine($"'V' +{score} Points");
			}

			if (Is (m.ShapeS)) {
				Score += score;
				Log.AppendLine($"'S' +{score} Points");
			}

			if (Is (m.ShapeC)) {
				Score += score;
				Log.AppendLine($"'C' +{score} Points");
			}

			if (Is (m.ShapeX)) {
				Score += score;
				Log.AppendLine($"'X' +{score} Points");
			}
		}

		void CalculateVerticalHorizontals(int score)
		{
			if (Is(m.Col5)) {
				Score += 50;
				Log.AppendLine($"Vertical 5 +{score} Points");
			}

			if (Is(m.Col4)) {
				Score += 50;
				Log.AppendLine($"Vertical 4 +{score} Points");
			}

			if (Is(m.Col3)) {
				Score += 50;
				Log.AppendLine($"Vertical 3 +{score} Points");
			}

			if (Is(m.Col2)) {
				Score += 50;
				Log.AppendLine($"Vertical 2 +{score} Points");
			}

			if (Is(m.Col1)) {
				Score += 50;
				Log.AppendLine($"Vertical 1 +{score} Points");
			}

			if (Is(m.Row5)) {
				Score += 50;
				Log.AppendLine($"Horizontal 5 +{score} Points");
			}

			if (Is(m.Row4)) {
				Score += 50;
				Log.AppendLine($"Horizontal 4 +{score} Points");
			}

			if (Is(m.Row3)) {
				Score += 50;
				Log.AppendLine($"Horizontal 3 +{score} Points");
			}

			if (Is(m.Row2)) {
				Score += 50;
				Log.AppendLine($"Horizontal 2 +{score} Points");
			}

			if (Is(m.Row1)) {
				Score += 50;
				Log.AppendLine($"Horizontal 1 +{score} Points");
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

		string Message(e item)
		{
			var type = typeof(e);
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
			Row1    = 1 << 0,
			Row2    = 1 << 1,
			Row3    = 1 << 2,
			Row4    = 1 << 3,
			Row5    = 1 << 4,

			// type
			Col1      = 1 << 5,
			Col2      = 1 << 6,
			Col3      = 1 << 7,
			Col4      = 1 << 8,
			Col5      = 1 << 9,

			// shapes
			ShapeV   = 1 << 10,
			ShapeS   = 1 << 11,
			ShapeC   = 1 << 12,
			ShapeX   = 1 << 13,
		}

		public enum e
		{
			// Row 1
			[Description("Hello")]
			CustomTeamsBackground = m.Row1 | m.Col1 | m.ShapeV | m.ShapeX,
			BreakfastPicture = m.Row1 | m.Col2 | m.ShapeS | m.ShapeC,
			ColorfulLights = m.Row1 | m.Col3 | m.ShapeS | m.ShapeC,
			SameBirthday = m.Row1 | m.Col4 | m.ShapeS | m.ShapeC,
			PlantPicture = m.Row1 | m.Col5 | m.ShapeV | m.ShapeX,

			// Row 2
			PublishedApp = m.Row2 | m.Col1 | m.ShapeV | m.ShapeC,
			NewTeamMember = m.Row2 | m.Col2 | m.ShapeS | m.ShapeX,
			Pi20 = m.Row2 | m.Col3,
			WatchedFavoriteTVShow = m.Row2 | m.Col4 | m.ShapeX,
			WallArtPicture = m.Row2 | m.Col5 | m.ShapeV,

			// Row 3
			UniqueItemPicture = m.Row3 | m.Col1 | m.ShapeC,
			NonCatDog = m.Row3 | m.Col2 | m.ShapeV | m.ShapeS,
			FavoriteMemory = m.Row3 | m.Col3 | m.ShapeS | m.ShapeX,
			CountryFlagPicture = m.Row3 | m.Col4 | m.ShapeV | m.ShapeS,
			MoreThanOneLanguage = m.Row3 | m.Col5,

			// Row 4
			PlayedFavoriteGame = m.Row4 | m.Col1 | m.ShapeC,
			StartedCompany = m.Row4 | m.Col2 | m.ShapeV | m.ShapeX,
			HairstyleTenYearsAgoPicture = m.Row4 | m.Col3,
			PerformingMusic = m.Row4 | m.Col4 | m.ShapeV | m.ShapeS | m.ShapeX,
			HandmadePicture = m.Row4 | m.Col5,

			// Row5
			BookPicture = m.Row5 | m.Col1 | m.ShapeX,
			PublishedBookAcademicResearch = m.Row5 | m.Col2 | m.ShapeS | m.ShapeC,
			BackwardsAlphabet = m.Row5 | m.Col3 | m.ShapeV | m.ShapeS | m.ShapeC,
			FavoriteNerdyGeekyPastimePicture = m.Row5 | m.Col4 | m.ShapeS | m.ShapeC,
			FavoriteSnackPicture = m.Row5 | m.Col5 | m.ShapeX,
		}
	}
}
