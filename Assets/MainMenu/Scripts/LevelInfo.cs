using System.Collections.Generic;
using UnityEngine;

public static class LevelInfo
{
    public static List<int> CountStarsOnLevels;
    public static List<string> BestPlayerRecordOnLevels;
    public static List<double> BestPlayerTimeRun;
    public static TimeDataList TimeDatas;
    public static int NumberLevel;

    public static void InitializeCountLevels(int countLevels, TimeDataList timeDatas)
    {
        CountStarsOnLevels = new List<int>(countLevels);
        BestPlayerRecordOnLevels = new List<string>(countLevels);
        BestPlayerTimeRun = new List<double>(countLevels);
        TimeDatas = timeDatas;

        for (int i = 0; i < countLevels; i++)
        {
            CountStarsOnLevels.Add(0);
            BestPlayerRecordOnLevels.Add(string.Empty);
            BestPlayerTimeRun.Add(0.0); 
        }
        Debug.Log("LevelInfo initialized");
    }
}
