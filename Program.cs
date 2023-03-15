using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BingoScorer
{
	class Program
	{
		

		static void Main(string[] args)
		{
			// So we can call async methods from main
			MainAsync().GetAwaiter().GetResult();
		}

		static async Task MainAsync()
		{
			// Create the boards
			var boards = MarkBoard.CreateBingoBoards();
			// Organize the scoring of the boards
			var awards = new Awards(boards);

			// Write the scores to 2 text files - Running this in visual studio - Debug will place
			// these files in this same directory
			await WriteToFile(awards.GetNumberPlaces(), "NumberPlaces.txt");
			await WriteToFile(awards.GetDetailedReport(), "DetailedReport.txt");
			await WriteToFile(awards.GetPlaces(), "Places.txt");
		}

		static async Task WriteToFile(string content, string outputPath)
		{
			await File.WriteAllTextAsync(outputPath, content);
		}
	}
}
