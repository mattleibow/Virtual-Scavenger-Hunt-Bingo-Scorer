using System;
using System.Text;
using static BingoScorer.MarkBoard;

namespace BingoScorer
{
	// This class is responsible for assigning the points to a bingo board
	// as well as creating a drawing and log for the points that were assigned
	public class BingoBoard
	{
		// Row 1
		internal bool CustomTeamsBackground { get; set; }
		internal bool BreakfastPicture { get; set; }
		internal bool ColorfulLights { get; set; }
		internal bool SameBirthday { get; set; }
		internal bool PlantPicture { get; set; }

		// Row 2
		internal bool PublishedApp { get; set; }
		internal bool NewTeamMember { get; set; }
		internal bool Pi20 { get; set; }
		internal bool WatchedFavoriteTVShow { get; set; }
		internal bool WallArtPicture { get; set; }

		// Row 3
		internal bool UniqueItemPicture { get; set; }
		internal bool NonCatDog { get; set; }
		internal bool FavoriteMemory { get; set; } = true;
		internal bool CountryFlagPicture { get; set; }
		internal bool MoreThanOneLanguage { get; set; }

		// Row 4
		internal bool PlayedFavoriteGame { get; set; }
		internal bool StartedCompany { get; set; }
		internal bool HairstyleTenYearsAgoPicture { get; set; }
		internal bool PerformingMusic { get; set; }
		internal bool HandmadePicture { get; set; }

		// Row 5
		internal bool BookPicture { get; set; }
		internal bool PublishedBookAcademicResearch { get; set; }
		internal bool BackwardsAlphabet { get; set; }
		internal bool FavoriteNerdyGeekyPastimePicture { get; set; }
		internal bool FavoriteSnackPicture { get; set; }

		public string Name { get; set; }
		public float Score { get; set; }
		public StringBuilder Log { get; set; } = new StringBuilder("Point Breakdown:\n");
		public string Drawing { get; set; }

		public BingoBoard(string name, params e[] items)
		{
			Name = name;
			foreach (var item in items) {
				this.IncludeItem(item);
			}
		}

		public void DrawBoard ()
		{
			StringBuilder sb = new StringBuilder ("-----------\n");
			// Row 1
			sb.Append($"|{Mark(CustomTeamsBackground)}|{Mark(BreakfastPicture)}|{Mark(ColorfulLights)}|{Mark(SameBirthday)}|{Mark(PlantPicture)}|\n");

			// Row 2
			sb.Append($"|{Mark(PublishedApp)}|{Mark(NewTeamMember)}|{Mark(Pi20)}|{Mark(WatchedFavoriteTVShow)}|{Mark(WallArtPicture)}|\n");

			// Row 3
			sb.Append($"|{Mark(UniqueItemPicture)}|{Mark(NonCatDog)}|{Mark(FavoriteMemory)}|{Mark(CountryFlagPicture)}|{Mark(MoreThanOneLanguage)}|\n");

			// Row 4
			sb.Append($"|{Mark(PlayedFavoriteGame)}|{Mark(StartedCompany)}|{Mark(HairstyleTenYearsAgoPicture)}|{Mark(PerformingMusic)}|{Mark(HandmadePicture)}|\n");

			// Row 5
			sb.Append($"|{Mark(BookPicture)}|{Mark(PublishedBookAcademicResearch)}|{Mark(BackwardsAlphabet)}|{Mark(FavoriteNerdyGeekyPastimePicture)}|{Mark(FavoriteSnackPicture)}|\n");

			sb.Append("-----------\n");

			Drawing = sb.ToString();
		}

		char Mark (bool val)
		{
			if (val)
				return 'x';
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
			if (IsFullBoard()) {
				FalsifyFullBoard();
				Score += 1000000;
				Log.AppendLine("FullBoard! +1,000,000 Points!!");
			}

			if (IsSnowFlake()) {
				FalsifySnowFlake();
				Score += 5000;
				Log.AppendLine("Snowflake +5,000 Points");
			}

			if (IsX()) {
				FalsifyX();
				Score += 1000;
				Log.AppendLine("X for Xamarin +1,000 Points");
			}

			if (IsFourCorners()) {
				FalsifyFourCorners();
				Score += 500;
				Log.AppendLine("Four Corners +500 Points");
			}
		}

		void CalculateVerticalHorizontals()
		{
			if (IsVertical5()) {
				Score += 100;
				Log.AppendLine("Vertical 5 +100 Points");
			}

			if (IsVertical4()) {
				Score += 100;
				Log.AppendLine("Vertical 4 +100 Points");
			}

			if (IsVertical3()) {
				Score += 100;
				Log.AppendLine("Vertical 3 +100 Points");
			}

			if (IsVertical2()) {
				Score += 100;
				Log.AppendLine("Vertical 2 +100 Points");
			}

			if (IsVertical1()) {
				Score += 100;
				Log.AppendLine("Vertical 1 +100 Points");
			}

			if (IsHorizontal5()) {
				Score += 100;
				Log.AppendLine("Horizontal 5 +100 Points");
			}

			if (IsHorizontal4()) {
				Score += 100;
				Log.AppendLine("Horizontal 4 +100 Points");
			}

			if (IsHorizontal3()) {
				Score += 100;
				Log.AppendLine("Horizontal 3 +100 Points");
			}

			if (IsHorizontal2()) {
				Score += 100;
				Log.AppendLine("Horizontal 2 +100 Points");
			}

			if (IsHorizontal1()) {
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
			if (CustomTeamsBackground) {
				Score += 10;
				Log.AppendLine("Your Work Setup +10 Points");
			}
			if (BreakfastPicture) {
				Score += 10;
				Log.AppendLine("Frozen Anything +10 Points");
			}
			if (ColorfulLights) {
				Score += 10;
				Log.AppendLine("You Doing Exactly What A Sign Says +10 Points");
			}
			if (SameBirthday) {
				Score += 10;
				Log.AppendLine("A Candle +10 Points");
			}
			if (PlantPicture) {
				Score += 10;
				Log.AppendLine("Something With Microsoft Logo +10 Points");
			}
			if (PublishedApp) {
				Score += 10;
				Log.AppendLine("Your Favorite Mug +10 Points");
			}
			if (NewTeamMember) {
				Score += 10;
				Log.AppendLine("Perform A Tiktok Dance +10 Points");
			}
			if (Pi20) {
				Score += 10;
				Log.AppendLine("Something You Cooked or Baked +10 Points");
			}
			if (WatchedFavoriteTVShow) {
				Score += 10;
				Log.AppendLine("Video Telling Us Your Favorite Joke +10 Points");
			}
			if (WallArtPicture) {
				Score += 10;
				Log.AppendLine("Sock With A Hole In It +10 Points");
			}
			if (UniqueItemPicture) {
				Score += 10;
				Log.AppendLine("Baby or Childhood Photo +10 Points");
			}
			if (NonCatDog) {
				Score += 10;
				Log.AppendLine("Something You Cant Live Without +10 Points");
			}
			if (CountryFlagPicture) {
				Score += 10;
				Log.AppendLine("A Coin From The Year 2021 +10 Points");
			}
			if (MoreThanOneLanguage) {
				Score += 10;
				Log.AppendLine("The View From Your Window +10 Points");
			}
			if (PlayedFavoriteGame) {
				Score += 10;
				Log.AppendLine("A Very Very Large Tree +10 Points");
			}
			if (StartedCompany) {
				Score += 10;
				Log.AppendLine("Something That Came Out The Year You Were Born +10 Points");
			}
			if (HairstyleTenYearsAgoPicture) {
				Score += 10;
				Log.AppendLine("Piece Of Workout Equipment +10 Points");
			}
			if (PerformingMusic) {
				Score += 10;
				Log.AppendLine("Imitate Your Favorite Emoji +10 Points");
			}
			if (HandmadePicture) {
				Score += 10;
				Log.AppendLine("Decoration With A Quote On It +10 Points");
			}
			if (BookPicture) {
				Score += 10;
				Log.AppendLine("Something Winter Holiday Related +10 Points");
			}
			if (PublishedBookAcademicResearch) {
				Score += 10;
				Log.AppendLine("Something That Begins With The Letter Z +10 Points");
			}
			if (BackwardsAlphabet) {
				Score += 10;
				Log.AppendLine("A Book With At Least 300 Pages +10 Points");
			}
			if (FavoriteNerdyGeekyPastimePicture) {
				Score += 10;
				Log.AppendLine("A Decorative Pillow +10 Points");
			}
			if (FavoriteSnackPicture) {
				Score += 10;
				Log.AppendLine("A Cloud That Looks Like An Animal +10 Points");
			}
		}

		bool IsVertical1()
		{
			return CustomTeamsBackground && PublishedApp && UniqueItemPicture
				&& PlayedFavoriteGame && BookPicture;
		}

		void FalsifyVertical1()
		{
			CustomTeamsBackground = false;
			PublishedApp = false;
			UniqueItemPicture = false;
			PlayedFavoriteGame = false;
			BookPicture = false;
		}

		bool IsVertical2()
		{
			return BreakfastPicture && NewTeamMember && NonCatDog
				&& StartedCompany
				&& PublishedBookAcademicResearch;
		}

		void FalsifyVertical2()
		{
			BreakfastPicture = false;
			NewTeamMember = false;
			NonCatDog = false;
			StartedCompany = false;
			PublishedBookAcademicResearch = false;
		}

		bool IsVertical3()
		{
			return ColorfulLights && Pi20
				&& HairstyleTenYearsAgoPicture && BackwardsAlphabet;
		}

		void FalsifyVertical3()
		{
			ColorfulLights = false;
			Pi20 = false;
			HairstyleTenYearsAgoPicture = false;
			BackwardsAlphabet = false;
			FavoriteMemory = false;
		}

		bool IsVertical4()
		{
			return SameBirthday && WatchedFavoriteTVShow && CountryFlagPicture
				&& PerformingMusic && FavoriteNerdyGeekyPastimePicture;
		}

		void FalsifyVertical4()
		{
			SameBirthday = false;
			WatchedFavoriteTVShow = false;
			CountryFlagPicture = false;
			PerformingMusic = false;
			FavoriteNerdyGeekyPastimePicture = false;
		}

		bool IsVertical5()
		{
			return PlantPicture && WallArtPicture && MoreThanOneLanguage
				&& HandmadePicture && FavoriteSnackPicture;
		}

		void FalsifyVertical5()
		{
			PlantPicture = false;
			WallArtPicture = false;
			MoreThanOneLanguage = false;
			HandmadePicture = false;
			FavoriteSnackPicture = false;
		}

		bool IsHorizontal1()
		{
			return CustomTeamsBackground && BreakfastPicture && ColorfulLights
				&& SameBirthday && PlantPicture;
		}

		void FalsifyHorizontal1()
		{
			CustomTeamsBackground = false;
			BreakfastPicture = false;
			ColorfulLights = false;
			SameBirthday = false;
			PlantPicture = false;
		}

		bool IsHorizontal2()
		{
			return PublishedApp && NewTeamMember && Pi20
				&& WatchedFavoriteTVShow && WallArtPicture;
		}

		void FalsifyHorizontal2()
		{
			PublishedApp = false;
			NewTeamMember = false;
			Pi20 = false;
			WatchedFavoriteTVShow = false;
			WallArtPicture = false;
		}

		bool IsHorizontal3()
		{
			return UniqueItemPicture && NonCatDog
				&& CountryFlagPicture && MoreThanOneLanguage;
		}

		void FalsifyHorizontal3()
		{
			UniqueItemPicture = false;
			NonCatDog = false;
			CountryFlagPicture = false;
			MoreThanOneLanguage = false;
			FavoriteMemory = false;
		}

		bool IsHorizontal4()
		{
			return PlayedFavoriteGame && StartedCompany
				&& HairstyleTenYearsAgoPicture && PerformingMusic && HandmadePicture;
		}

		void FalsifyHorizontal4()
		{
			PlayedFavoriteGame = false;
			StartedCompany = false;
			HairstyleTenYearsAgoPicture = false;
			PerformingMusic = false;
			HandmadePicture = false;
		}

		bool IsHorizontal5()
		{
			return BookPicture && PublishedBookAcademicResearch
				&& BackwardsAlphabet && FavoriteNerdyGeekyPastimePicture && FavoriteSnackPicture;
		}

		void FalsifyHorizontal5()
		{
			BookPicture = false;
			PublishedBookAcademicResearch = false;
			BackwardsAlphabet = false;
			FavoriteNerdyGeekyPastimePicture = false;
			FavoriteSnackPicture = false;
		}

		bool IsFourCorners()
		{
			return CustomTeamsBackground && PlantPicture
				&& BookPicture && FavoriteSnackPicture;
		}

		void FalsifyFourCorners()
		{
			CustomTeamsBackground = false;
			PlantPicture = false;
			BookPicture = false;
			FavoriteSnackPicture = false;
		}

		bool IsX()
		{
			return IsFourCorners() & NewTeamMember && WatchedFavoriteTVShow
				&& StartedCompany && PerformingMusic;
		}

		void FalsifyX()
		{
			FalsifyFourCorners();
			NewTeamMember = false;
			WatchedFavoriteTVShow = false;
			StartedCompany = false;
			PerformingMusic = false;
			FavoriteMemory = false;
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
			FavoriteMemory = false;
		}


		bool IsFullBoard()
		{
			return IsSnowFlake() && PublishedApp && BreakfastPicture && SameBirthday
				&& WallArtPicture && HandmadePicture
				&& FavoriteNerdyGeekyPastimePicture && PublishedBookAcademicResearch
				&& PlayedFavoriteGame;
		}

		void FalsifyFullBoard()
		{
			PublishedApp = false;
			BreakfastPicture = false;
			SameBirthday = false;
			WallArtPicture = false;
			HandmadePicture = false;
			FavoriteNerdyGeekyPastimePicture = false;
			PublishedBookAcademicResearch = false;
			PlayedFavoriteGame = false;
			FavoriteMemory = false;
			FalsifySnowFlake();
		}
	}

	public static class BingoBoardExtensions
	{
		public static void IncludeItem(this BingoBoard board, e item)
		{
			switch (item) {
				case e.CustomTeamsBackground:
					board.CustomTeamsBackground = true;
					break;

				case e.BreakfastPicture:
					board.BreakfastPicture = true;
					break;

				case e.ColorfulLights:
					board.ColorfulLights = true;
					break;

				case e.SameBirthday:
					board.SameBirthday = true;
					break;

				case e.PlantPicture:
					board.PlantPicture = true;
					break;

				case e.PublishedApp:
					board.PublishedApp = true;
					break;

				case e.NewTeamMember:
					board.NewTeamMember = true;
					break;

				case e.Pi20:
					board.Pi20 = true;
					break;

				case e.WatchedFavoriteTVShow:
					board.WatchedFavoriteTVShow = true;
					break;

				case e.WallArtPicture:
					board.WallArtPicture = true;
					break;

				case e.UniqueItemPicture:
					board.UniqueItemPicture = true;
					break;

				case e.NonCatDog:
					board.NonCatDog = true;
					break;

				case e.CountryFlagPicture:
					board.CountryFlagPicture = true;
					break;

				case e.MoreThanOneLanguage:
					board.MoreThanOneLanguage = true;
					break;

				case e.PlayedFavoriteGame:
					board.PlayedFavoriteGame = true;
					break;

				case e.StartedCompany:
					board.StartedCompany = true;
					break;

				case e.HairstyleTenYearsAgoPicture:
					board.HairstyleTenYearsAgoPicture = true;
					break;

				case e.PerformingMusic:
					board.PerformingMusic = true;
					break;

				case e.HandmadePicture:
					board.HandmadePicture = true;
					break;

				case e.BookPicture:
					board.BookPicture = true;
					break;

				case e.PublishedBookAcademicResearch:
					board.PublishedBookAcademicResearch = true;
					break;

				case e.BackwardsAlphabet:
					board.BackwardsAlphabet = true;
					break;

				case e.FavoriteNerdyGeekyPastimePicture:
					board.FavoriteNerdyGeekyPastimePicture = true;
					break;

				case e.FavoriteSnackPicture:
					board.FavoriteSnackPicture = true;
					break;
			}
		}
	}
}
