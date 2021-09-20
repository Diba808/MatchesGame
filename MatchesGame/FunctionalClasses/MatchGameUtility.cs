using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MatchesGame.FunctionalClasses
{
    public class MatchGameUtility
    {
        public MatchGameUtility(string nameOne,  string nameTwo)
        {

        }

        public static string MatchNames(string nameOne, string nameTwo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(nameOne);
            stringBuilder.Append(" matches ");
            stringBuilder.Append(nameTwo);
            stringBuilder.Replace(" ", "");
            

            string sentence = stringBuilder.ToString().ToLower();

            List<char> usedCharacter = new List<char>();

            List<int> counts = new List<int>();

            foreach (char letter in sentence)
            {
                if (!usedCharacter.Contains(letter))
                {
                    int letterCount = sentence.Where(a => (a == letter)).ToList().Count();
                    counts.Add(letterCount);
                    usedCharacter.Add(letter);
                }
            }

        //    Console.WriteLine($"The combine string: { String.Join("", counts)} ");

            var finalArray =CalculateFinalArray(counts);

            return String.Join("",finalArray)+"%";
        }

        public static List<int> CalculateFinalArray(List<int> counts) 
        {

            if(counts.Count()==2)
            {
                return counts;
            }

            int arraySize = counts.Count();
            bool remainder = arraySize % 2 == 0 ? false : true;
            int halfSize = arraySize / 2;

            halfSize += remainder ? 1 : 0;

            List<int> arrayOne = counts.GetRange(0, halfSize);
            List<int> secondArray = counts.GetRange(halfSize,arraySize-halfSize);
            secondArray.Reverse();

            return CalculateFinalArray(Combine(arrayOne,secondArray));
        }
     
        public static List<int> Combine(List<int> arrayOne, List<int> arrayTwo)
        {
            List<int> temp = new List<int>();

            for(int i=0; i<arrayTwo.Count(); i++)
            {
                temp.Add(arrayOne[i] + arrayTwo[i]);
            }
          
            if(temp.Count()!=2 && (arrayOne.Count()+arrayTwo.Count())%2!=0)
            temp.Add(arrayOne.Last());

            string recombine = String.Join("", temp);
            temp.RemoveRange(0, temp.Count());
            foreach(char a in recombine)
            {
               
                temp.Add(int.Parse(a.ToString()));
            }

            return temp;
        }
        

    }


}
