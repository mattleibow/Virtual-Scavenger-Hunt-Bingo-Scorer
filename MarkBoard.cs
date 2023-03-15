using System;
using System.Collections.Generic;
using static BingoScorer.Participants;
using static BingoScorer.BoadParts;

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
			TallyItems(e.Q1_FavoriteHobby, new string[]{
			});

			TallyItems(e.Q2_EplainYourJobToA5YearOld, new string[]{
			});

			TallyItems(e.Q3_BeenTo3Continents, new string[]{
			});

			TallyItems(e.Q4_ExercisesRegularly, new string[]{
			});

			TallyItems(e.Q5_FirstJob, new string[]{
			});

			// Heng's Categories
			TallyItems(e.Q6_GrowFood, new string[]{
			});

			TallyItems(e.Q7_NewThinYouWantToTry, new string[]{
			});

			TallyItems(e.Q8_KnowsASL, new string[]{
			});

			TallyItems(e.Q9_FavoriteRecipe, new string[]{
			});

			TallyItems(e.Q10_NonCSDegree, new string[]{
			});

			// Kunyi's Categories
			TallyItems(e.Q11_SideHustle, new string[]{
			});

			TallyItems(e.Q12_MemorableDream, new string[]{
			});

			TallyItems(e.Q13_TeamsEmojis, new string[]{
			});

			TallyItems(e.Q14_OldestItem, new string[]{
			});

			TallyItems(e.Q15_MBTIBuddy, new string[]{
			});

			// Matthew's Categories
			TallyItems(e.Q16_WorkshopTeacher, new string[]{
			});

			TallyItems(e.Q17_UselessTalen, new string[]{
			});

			TallyItems(e.Q18_TVFamous, new string[]{
			});

			TallyItems(e.Q19_FavoriteSpot, new string[]{
			});

			TallyItems(e.Q20_CPRCertified, new string[]{
			});

			// TJ's Categories
			TallyItems(e.Q21_FreezeSomething, new string[]{
			});

			TallyItems(e.Q22_GuiltyPleasure, new string[]{
			});

			TallyItems(e.Q23_PetPictures, new string[]{
			});

			TallyItems(e.Q24_SomethingYouMade, new string[]{
			});

			TallyItems(e.Q25_Speaks3PlusLanguaged, new string[]{
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
						board.Squares[item] = true;
						break;
					}
				}
				// if we didn't find a board with that name, create one and add that item
				if (!foundBoard) {
					Boards.Add(new BingoBoard(name, item));
				}
			}
		}
	}
}
