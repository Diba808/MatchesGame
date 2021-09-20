using MatchesGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace MatchesGame.FunctionalClasses
{
    public class FileHandler
    {
        public static string ReadFile(string filePath = "")
        {
            StreamReader reader = null;
            if (string.IsNullOrEmpty(filePath))
            {
                try
                {
                    reader = new StreamReader(Directory.GetCurrentDirectory() + "//AppData//List.csv");
                    return Execute(reader);
                }
                catch(Exception e)
                {
                    return $"Something went wrong reading the file {e.Message}";
                }
            }
            else
            {
                try
                {
                    reader = new StreamReader(filePath);
                    return Execute(reader);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Something is wrong with your file path: {e.Message}");
                    return "Failed Execution";
                }
            }
        }

        public static string Execute(StreamReader reader)
        {
            string data = reader.ReadToEnd();
            data = data.Replace("\r", "");
            string[] records = data.Split('\n');
            List<Person> dataSet = new List<Person>();

            foreach (string record in records)
            {
                string[] item = record.Split(',');
                dataSet.Add(new Person(item[0], item[1]));
            }

            var males = dataSet.Where(b => b.Gender == "M").OrderBy(a => a.Name).Distinct().ToList();
            var females = dataSet.Where(b => b.Gender == "F").OrderBy(a => a.Name).Distinct().ToList();

            List<(string score, string maleName, string femaleName)> scoreSheet = new List<(string score, string maleName, string femaleName)>();

            foreach (var male in males)
            {
                foreach (var female in females)
                {
                    var score = MatchGameUtility.MatchNames(male.Name, female.Name);
                    scoreSheet.Add((score, male.Name, female.Name));
                }
            }
            scoreSheet = scoreSheet.OrderByDescending(a => a.score).ThenBy(a => a.maleName).ThenBy(a => a.femaleName).ToList();

            StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + "//AppData//output.txt");

            foreach (var score in scoreSheet)
            {
                bool state = int.Parse(score.score.Replace("%", "")) >= 80;
                string result = $"{score.maleName} matches {score.femaleName} {score.score} {(state ? ", good match" : String.Empty)}";
                writer.WriteLine(result);
                Console.WriteLine(result);
            }

            writer.Close();
            return "Completed Files Successfully";
        }
    }
}
