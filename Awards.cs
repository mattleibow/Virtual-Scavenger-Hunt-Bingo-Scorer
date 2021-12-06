using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BingoScorer
{
    public class Awards
    {
        SortedList<float, (string name, string log)> Entries = new SortedList<float, (string name, string log)> (new DecendingComparer<float>());

        public Awards (params BingoBoard[] boards)
        {
            foreach (var board in boards)
            {
                board.CalculateScore ();

                var score = board.Score;

                // Small hack to have multiples of the same score inside the sortedList.
                // Add a small decimal value and treat the floats as ints later!
                while (Entries.ContainsKey(score))
                {
                    score += 0.001f;
                }
                    
                Entries.Add (score, new (board.Name, board.Log.ToString ()));
            }
        }

        public string GetDetailedReport()
        {
            StringBuilder sb = new StringBuilder ();
            var place = 1;
            foreach (var entry in Entries)
            {
                sb.AppendLine($"{place}. {entry.Value.name}: {(int)entry.Key} points\n{entry.Value.log}\n\n");
                place++;
            }

            return sb.ToString ();
        }

        public string GetPlaces()
        {
            StringBuilder sb = new StringBuilder();
            if (Entries.Count < 6)
            {
                return GetNumberPlaces();
            }

            var place = 1;
            int previousPlace = -1;
            int lastScore = -1;
            int tieCounter = 0;
            foreach (var entry in Entries)
            {
                // mark first place
                if (place == 1)
                {
                    sb.AppendLine($"1st Place. {entry.Value.name}: {(int)entry.Key} points\n");
                    previousPlace = 1;
                    lastScore = (int)entry.Key;
                    place++;
                }

                // see if there is a tie for first place
                else if (previousPlace == 1 && (int)entry.Key == lastScore)
                {
                    sb.AppendLine($"1st Place. {entry.Value.name}: {(int)entry.Key} points\n");
                    previousPlace = 1;
                    tieCounter++;
                    place++;
                }

                // mark second place
                else if (previousPlace == 1 && (int)entry.Key < lastScore)
                {
                    sb.AppendLine($"2nd Place. {entry.Value.name}: {(int)entry.Key} points\n");
                    lastScore = (int)entry.Key;
                    previousPlace = 2;
                    place++;
                }

                // see if there is a tie for second place
                else if (previousPlace == 2 && (int)entry.Key == lastScore)
                {
                    sb.AppendLine($"2st Place. {entry.Value.name}: {(int)entry.Key} points\n");
                    tieCounter++;
                    place++;
                }

                // mark the rest of scores based on their percentage tier
                else
                {
                    float percent = (float) (place - 2 - tieCounter) / (float) (Entries.Count - 2 - tieCounter);
                    var group = percent <= 0.25 ? "Top 25 Percent" : percent <= 0.75 ? "Middle 50 Percent" : "Lower 25 Percent";
                    sb.AppendLine($"{group}. {entry.Value.name}: {(int)entry.Key} points Percentage: {percent}\n");
                    place++;
                }
                
            }

            return sb.ToString();
        }

        // mark all the places based on their position - does not account for ties
        string GetNumberPlaces ()
        {
            StringBuilder sb = new StringBuilder();
            var place = 1;
            int previousPlace = -1;
            int lastScore = -1;

            foreach (var entry in Entries)
            {
                if ((int)entry.Key == lastScore)
                {
                    sb.AppendLine($"{previousPlace}. {entry.Value.name}: {(int)entry.Key} points\n");
                } else
                {
                    sb.AppendLine($"{place}. {entry.Value.name}: {(int)entry.Key} points\n");
                    previousPlace = place;
                }
                
                place++;
                lastScore = (int)entry.Key;
            }
            return sb.ToString();
        }
        
    }

    class DecendingComparer<TKey> : IComparer<float>
    {
        public int Compare(float x, float y)
        {
            return y.CompareTo(x);
        }
    }
}
