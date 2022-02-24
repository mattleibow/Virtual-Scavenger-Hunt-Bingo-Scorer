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

		public void CalculateScore ()
		{
			// We can only calculate the scores one time!
			if (Score != 0)
				return;

			CalculateShapes ();

			CalculateVerticalHorizontals ();

			AddEachSpace ();
		}

		void CalculateShapes ()
		{
			if (IsFullBoard ()) {
				Score += 1000000;
				Log.AppendLine("FullBoard! +1,000,000 Points!!");
			}

			if (IsN ()) {
				Score += 500;
				Log.AppendLine("'N' +500 Points");
			}

			if (IsE ()) {
				Score += 500;
				Log.AppendLine("'E' +500 Points");
			}

			if (IsT ()) {
				Score += 500;
				Log.AppendLine("'T' +500 Points");
			}

			if (Is6 ()) {
				Score += 500;
				Log.AppendLine("'6' +500 Points");
			}
		}

		void CalculateVerticalHorizontals()
		{
			if (IsVertical5()) {
				Score += 50;
				Log.AppendLine("Vertical 5 +50 Points");
			}

			if (IsVertical4()) {
				Score += 50;
				Log.AppendLine("Vertical 4 +50 Points");
			}

			if (IsVertical3()) {
				Score += 50;
				Log.AppendLine("Vertical 3 +50 Points");
			}

			if (IsVertical2()) {
				Score += 50;
				Log.AppendLine("Vertical 2 +50 Points");
			}

			if (IsVertical1()) {
				Score += 50;
				Log.AppendLine("Vertical 1 +50 Points");
			}

			if (IsHorizontal5()) {
				Score += 50;
				Log.AppendLine("Horizontal 5 +50 Points");
			}

			if (IsHorizontal4()) {
				Score += 50;
				Log.AppendLine("Horizontal 4 +50 Points");
			}

			if (IsHorizontal3()) {
				Score += 50;
				Log.AppendLine("Horizontal 3 +50 Points");
			}

			if (IsHorizontal2()) {
				Score += 50;
				Log.AppendLine("Horizontal 2 +50 Points");
			}

			if (IsHorizontal1()) {
				Score += 50;
				Log.AppendLine("Horizontal 1 +50 Points");
			}
		}

		void AddEachSpace()
		{
			if (CustomTeamsBackground) {
				Score += 10;
				Log.AppendLine("Find someone who has a custom uploaded Teams background +10 Points");
			}
			if (BreakfastPicture) {
				Score += 10;
				Log.AppendLine("Share a picture of you with your breakfast from today +10 Points");
			}
			if (ColorfulLights) {
				Score += 10;
				Log.AppendLine("Find someone who has colorful lights in their workspace +10 Points");
			}
			if (SameBirthday) {
				Score += 10;
				Log.AppendLine("Find someone who shares the same birthday month as you +10 Points");
			}
			if (PlantPicture) {
				Score += 10;
				Log.AppendLine("Share a picture of you with any plants you grow +10 Points");
			}
			if (PublishedApp) {
				Score += 10;
				Log.AppendLine("Find someone who has published an app on any app store +10 Points");
			}
			if (NewTeamMember) {
				Score += 10;
				Log.AppendLine("Find someone who has been on their team (at the M1 level) for less than 1 year +10 Points");
			}
			if (Pi20) {
				Score += 10;
				Log.AppendLine("Find someone who can recite at least the first 20 digits of pi from memory +10 Points");
			}
			if (WatchedFavoriteTVShow) {
				Score += 10;
				Log.AppendLine("Find someone who has watched your favorite TV show +10 Points");
			}
			if (WallArtPicture) {
				Score += 10;
				Log.AppendLine("Share a picture of some wall art +10 Points");
			}
			if (UniqueItemPicture) {
				Score += 10;
				Log.AppendLine("Share a picture of you with a unique item you have at your house  +10 Points");
			}
			if (NonCatDog) {
				Score += 10;
				Log.AppendLine("Find Someone who has a pet that is not a dog or cat +10 Points");
			}
			if (FavoriteMemory) {
				Score += 10;
				Log.AppendLine("Share your favorite memory (in any form) +10 Points");
			}
			if (CountryFlagPicture) {
				Score += 10;
				Log.AppendLine("a picture of you with a physical object that has your country's flag on it +10 Points");
			}
			if (MoreThanOneLanguage) {
				Score += 10;
				Log.AppendLine("Find someone who knows more than one language +10 Points");
			}
			if (PlayedFavoriteGame) {
				Score += 10;
				Log.AppendLine("Find someone who has played your favorite game +10 Points");
			}
			if (StartedCompany) {
				Score += 10;
				Log.AppendLine("Find someone who once started their own company +10 Points");
			}
			if (HairstyleTenYearsAgoPicture) {
				Score += 10;
				Log.AppendLine("Share a picture of you featuring your hairstyle from at least 10 years ago +10 Points");
			}
			if (PerformingMusic) {
				Score += 10;
				Log.AppendLine("Share a recent video of you performing music (at least 10 seconds) +10 Points");
			}
			if (HandmadePicture) {
				Score += 10;
				Log.AppendLine("Share a picture of you with something you handmade (i.e. painted, constructed, 3D-printed) +10 Points");
			}
			if (BookPicture) {
				Score += 10;
				Log.AppendLine("Share a picture of you with a book that you are reading or plan to read +10 Points");
			}
			if (PublishedBookAcademicResearch) {
				Score += 10;
				Log.AppendLine("Find someone who has published a book / academic research +10 Points");
			}
			if (BackwardsAlphabet) {
				Score += 10;
				Log.AppendLine("Find someone who can perfectly recite the alphabet backwards (any language, <15s) +10 Points");
			}
			if (FavoriteNerdyGeekyPastimePicture) {
				Score += 10;
				Log.AppendLine("Share a picture of you with your favorite nerdy/geeky pastime +10 Points");
			}
			if (FavoriteSnackPicture) {
				Score += 10;
				Log.AppendLine("Share a picture of you with your favorite snack +10 Points");
			}
		}

		bool IsVertical1 () => CustomTeamsBackground && PublishedApp && UniqueItemPicture
				&& PlayedFavoriteGame && BookPicture;

		bool IsVertical2 () => BreakfastPicture && NewTeamMember && NonCatDog
				&& StartedCompany && PublishedBookAcademicResearch;

		bool IsVertical3 () => ColorfulLights && Pi20
				&& HairstyleTenYearsAgoPicture && BackwardsAlphabet;

		bool IsVertical4 () => SameBirthday && WatchedFavoriteTVShow && CountryFlagPicture
				&& PerformingMusic && FavoriteNerdyGeekyPastimePicture;

		bool IsVertical5 () => PlantPicture && WallArtPicture && MoreThanOneLanguage
				&& HandmadePicture && FavoriteSnackPicture;

		bool IsHorizontal1 () => CustomTeamsBackground && BreakfastPicture && ColorfulLights
				&& SameBirthday && PlantPicture;

		bool IsHorizontal2 () => PublishedApp && NewTeamMember && Pi20
				&& WatchedFavoriteTVShow && WallArtPicture;

		bool IsHorizontal3 () => UniqueItemPicture && NonCatDog
				&& CountryFlagPicture && MoreThanOneLanguage;

		bool IsHorizontal4 () => PlayedFavoriteGame && StartedCompany
				&& HairstyleTenYearsAgoPicture && PerformingMusic && HandmadePicture;

		bool IsHorizontal5 () => BookPicture && PublishedBookAcademicResearch
				&& BackwardsAlphabet && FavoriteNerdyGeekyPastimePicture && FavoriteSnackPicture;

		bool IsDownhillDiagonal () => CustomTeamsBackground && NewTeamMember && FavoriteMemory
			&& PerformingMusic && FavoriteSnackPicture;

		bool IsN () => IsVertical1 () && IsDownhillDiagonal () && IsVertical5 ();

		bool IsE () => IsHorizontal1 () && IsHorizontal3 () && IsHorizontal5 () && IsVertical1 ();

		bool IsT () => IsHorizontal1 () && IsVertical3 ();

		bool Is6 () => IsHorizontal1 () && IsHorizontal3 () && IsHorizontal5 () && IsVertical1 ()
			&& HandmadePicture;

		bool IsFullBoard () => IsHorizontal1 () && IsHorizontal2 () &&
				IsHorizontal3 () && IsHorizontal4 () && IsHorizontal5 ();
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
