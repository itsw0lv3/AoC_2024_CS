using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class AoC
{
    public static void GetListFromText(List<int> leftList, List<int> rightList)
    {
        string filePath = @"listsText.txt";
        using (StreamReader sr = File.OpenText(filePath))
        {
            string strLine = "";
            while ((strLine = sr.ReadLine()) != null)
            {
                var splitStr = strLine.Split("   ");
                leftList.Add(Convert.ToInt32(splitStr[0]));
                rightList.Add(Convert.ToInt32(splitStr[1]));
            }
            leftList.Sort();
            rightList.Sort();
        }
    }
    public static void GenerateDiff(List<int> leftList, List<int> rightList)
    {
        // For Pt.1
        List<int> diffList = new List<int>();
        for(int i = 0; i < leftList.Count; i++) 
        {
            int diff = 0;
            if (leftList[i] > rightList[i])
            {
                diff = leftList[i] - rightList[i];
            }
            else if (rightList[i] > leftList[i])
            {
                diff = rightList[i] - leftList[i];
            }
            diffList.Add(diff);
        }
        int sum = diffList.Sum();
        Console.WriteLine(sum);
    }

    public static void ScoreSimilarity(List<int> leftList, List<int> rightList)
    {
        // For Pt.2
        List<int> simScores = new List<int>();
        for (int i = 0; i < leftList.Count; i++)
        {
            int simCount = rightList.Count(n => n == leftList[i]);
            simScores.Add(leftList[i] * simCount);
        }
        int sum = simScores.Sum();
        Console.WriteLine(sum);
    }
    public static void Main(string[] args)
    {
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();
        
        GetListFromText(leftList, rightList);
        ScoreSimilarity(leftList, rightList);
    }
}
