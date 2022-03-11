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
			// Advay's Categories
			TallyItems(e.CustomTeamsBackground, new string[]{
				tjLambert, rachelKang, ruiMarinho, steveHawley
			});

			TallyItems(e.PublishedApp, new string[]{
				ruiMarinho
			});

			TallyItems(e.UniqueItemPicture, new string[]{
				ruiMarinho, steveHawley
			});

			TallyItems(e.PlayedFavoriteGame, new string[]{
				maddyMontaquilaLeger, tjLambert
			});

			TallyItems(e.BookPicture, new string[]{
				rachelKang, ruiMarinho
			});

			// Heng's Categories
			TallyItems(e.BreakfastPicture, new string[]{
				ruiMarinho
			});

			TallyItems(e.NewTeamMember, new string[]{
				tjLambert, ruiMarinho
			});

			TallyItems(e.NonCatDog, new string[]{

			});

			TallyItems(e.StartedCompany, new string[]{
				ruiMarinho, tjLambert
			});

			TallyItems(e.PublishedBookAcademicResearch, new string[]{
				ruiMarinho, tjLambert
			});

			// James's Categories
			TallyItems(e.ColorfulLights, new string[]{

			});

			TallyItems(e.Pi20, new string[]{

			});

			TallyItems(e.FavoriteMemory, new string[]{

			});

			TallyItems(e.HairstyleTenYearsAgoPicture, new string[]{

			});

			TallyItems(e.BackwardsAlphabet, new string[]{

			});

			// Rachel's Categories
			TallyItems(e.SameBirthday, new string[]{

			});

			TallyItems(e.WatchedFavoriteTVShow, new string[]{

			});

			TallyItems(e.CountryFlagPicture, new string[]{

			});

			TallyItems(e.PerformingMusic, new string[]{

			});

			TallyItems(e.FavoriteNerdyGeekyPastimePicture, new string[]{

			});

			// TJ's Categories
			TallyItems(e.PlantPicture, new string[]{
				maddyMontaquilaLeger, steveHawley
			});

			TallyItems(e.WallArtPicture, new string[]{

			});

			TallyItems(e.MoreThanOneLanguage, new string[]{

			});

			TallyItems(e.HandmadePicture, new string[]{
				maddyMontaquilaLeger, steveHawley
			});

			TallyItems(e.FavoriteSnackPicture, new string[]{

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
			CustomTeamsBackground,
			BreakfastPicture,
			ColorfulLights,
			SameBirthday,
			PlantPicture,

			// Row 2
			PublishedApp,
			NewTeamMember,
			Pi20,
			WatchedFavoriteTVShow,
			WallArtPicture,

			// Row 3
			UniqueItemPicture,
			NonCatDog,
			FavoriteMemory,
			CountryFlagPicture,
			MoreThanOneLanguage,

			// Row 4
			PlayedFavoriteGame,
			StartedCompany,
			HairstyleTenYearsAgoPicture,
			PerformingMusic,
			HandmadePicture,

			// Row5
			BookPicture,
			PublishedBookAcademicResearch,
			BackwardsAlphabet,
			FavoriteNerdyGeekyPastimePicture,
			FavoriteSnackPicture,
		}
	}
}
