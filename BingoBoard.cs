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
			var items = Enum.GetValues<e>()
				.Select(v => (Value: v, Name: Enum.GetName<e>(v)))
				.OrderBy(t => int.Parse(t.Name.Split('Q', '_')[1]));
			foreach (var item  in items) {
				if (Squares[item.Value]) {
					Score += score;
					Log.AppendLine($"{Message(item.Value)} +{score} Points");
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
			[Description("Share: Favorite hobby or pastime outside of work (proof: any)")]
			Q1_FavoriteHobby = m.Row1 | m.Col1 | m.Shape1 | m.Shape4,
			[Description("Share: What you are currently working on - explain it to a 5 year old (proof: any)")]
			Q2_EplainYourJobToA5YearOld = m.Row1 | m.Col2 | m.Shape2 | m.Shape3,
			[Description("Find: Someone who has been to 3+ continents (proof: pictures)")]
			Q3_BeenTo3Continents = m.Row1 | m.Col3 | m.Shape2 | m.Shape3,
			[Description("Find: Someone who exercises every week (proof: any)")]
			Q4_ExercisesRegularly = m.Row1 | m.Col4 | m.Shape2 | m.Shape3,
			[Description("Share: First ever job (proof: any)")]
			Q5_FirstJob = m.Row1 | m.Col5 | m.Shape1 | m.Shape4,

			// Row 2
			[Description("Find: Someone who has grown their own food (proof: picture) ")]
			Q6_GrowFood = m.Row2 | m.Col1 | m.Shape1 | m.Shape3,
			[Description("Share: Something new you've always wanted to try (proof: any)")]
			Q7_NewThinYouWantToTry = m.Row2 | m.Col2 | m.Shape2 | m.Shape4,
			[Description("Find: Someone who knows ASL (proof: video) ")]
			Q8_KnowsASL = m.Row2 | m.Col3,
			[Description("Share: Your favorite recipe (proof: any)")]
			Q9_FavoriteRecipe = m.Row2 | m.Col4 | m.Shape4,
			[Description("Find: Someone who has a degree in a non-CS or Computer Engineering field (proof: any) ")]
			Q10_NonCSDegree = m.Row2 | m.Col5 | m.Shape1,

			// Row 3
			[Description("Find: Someone who has a side hustle/started a business (proof: any) ")]
			Q11_SideHustle = m.Row3 | m.Col1 | m.Shape3,
			[Description("Share: a typical nightmare / most memorable or impressive dream (proof: any)")]
			Q12_MemorableDream = m.Row3 | m.Col2 | m.Shape1 | m.Shape2,
			[Description("Share: 5 most recently used Teams emojis (proof: any)")]
			Q13_TeamsEmojis = m.Row3 | m.Col3 | m.Shape2 | m.Shape4,
			[Description("Share: the oldest thing you own (proof: picture)")]
			Q14_OldestItem = m.Row3 | m.Col4 | m.Shape1 | m.Shape2,
			[Description("Find: someone who has the same MBTI as you, take the test here (proof: screenshot of results)")]
			Q15_MBTIBuddy = m.Row3 | m.Col5,

			// Row 4
			[Description("Find: Someone who has taught a class/workshop/bootcamp (proof: any) ")]
			Q16_WorkshopTeacher = m.Row4 | m.Col1 | m.Shape3,
			[Description("Share: Your most useless talent (proof: any)")]
			Q17_UselessTalen = m.Row4 | m.Col2 | m.Shape1 | m.Shape4,
			[Description("Find: Someone who has been on TV or the news (proof: any)")]
			Q18_TVFamous = m.Row4 | m.Col3,
			[Description("Share: Your favorite local spot   restaurant, hiking spot, etc. (proof: picture)")]
			Q19_FavoriteSpot = m.Row4 | m.Col4 | m.Shape1 | m.Shape2 | m.Shape4,
			[Description("Find: Someone who is CPR certified (proof: any)")]
			Q20_CPRCertified = m.Row4 | m.Col5,

			// Row5
			[Description("Share: Freeze something that shouldn't be frozen and provide a picture (Proof: picture)")]
			Q21_FreezeSomething = m.Row5 | m.Col1 | m.Shape4,
			[Description("Share: Your guilty pleasure show/movie/video you love to watch (Proof: Any)")]
			Q22_GuiltyPleasure = m.Row5 | m.Col2 | m.Shape2 | m.Shape3,
			[Description("Share: Pet pictures / what animal you would want as a pet (Proof: picture)")]
			Q23_PetPictures = m.Row5 | m.Col3 | m.Shape1 | m.Shape2 | m.Shape3,
			[Description("Find: Someone who made something they use - clay, knitting, furniture, etc. (Proof: picture)")]
			Q24_SomethingYouMade = m.Row5 | m.Col4 | m.Shape2 | m.Shape3,
			[Description("Find: Someone who speaks 3 or more languages (Proof: video)")]
			Q25_Speaks3PlusLanguaged = m.Row5 | m.Col5 | m.Shape4,
		}
	}
}
