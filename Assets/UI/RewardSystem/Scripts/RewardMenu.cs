using TMPro;
using UnityEngine;
using Unsl;

public class RewardMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinView;
    [SerializeField] private int _coinReward = 10;

    [SerializeField] private TextMeshProUGUI _bestPlayerRunTime;
    [SerializeField] private TextMeshProUGUI _currentPlayerRunTime;
    [SerializeField] private StopWatch _stopWatch;

    [SerializeField] private Transform _stars;

    [SerializeField] private double FirstTime;
    [SerializeField] private double SecondTime;
    private int countActiveStars;

    private void OnEnable() 
    {
        InitializedData();

        Debug.Log(FirstTime);
        Debug.Log(SecondTime);


        _stopWatch.isActive = false;

        _currentPlayerRunTime.text = _stopWatch.TimerString;
        
        double CurrentTimeRun = (double)_stopWatch.deltaTime;
        double BestTimeRun = LevelInfo.BestPlayerTimeRun[LevelInfo.NumberLevel] != 0 ? LevelInfo.BestPlayerTimeRun[LevelInfo.NumberLevel] : 10000; 

        if(CurrentTimeRun < BestTimeRun)
        {
            ShowStars(CurrentTimeRun);

            _bestPlayerRunTime.text = _stopWatch.TimerString;

            LevelInfo.BestPlayerRecordOnLevels[LevelInfo.NumberLevel] = _bestPlayerRunTime.text;
            LevelInfo.BestPlayerTimeRun[LevelInfo.NumberLevel] = CurrentTimeRun;
            LevelInfo.CountStarsOnLevels[LevelInfo.NumberLevel]  = countActiveStars;
            
            FileSaveLoad.Save(LevelInfo.BestPlayerRecordOnLevels, TypeSave.BestResultOnLevels);
            FileSaveLoad.Save(LevelInfo.BestPlayerTimeRun, TypeSave.BestTimeRunOnLevels);
            FileSaveLoad.Save(LevelInfo.CountStarsOnLevels, TypeSave.CountStarsOnLevels);
            
        }
        else
        {
            ShowStars(CurrentTimeRun);
        }
        
    }

    private void InitializedData() 
    {
        if(LevelInfo.BestPlayerRecordOnLevels[LevelInfo.NumberLevel] != string.Empty)
            _bestPlayerRunTime.text = LevelInfo.BestPlayerRecordOnLevels[LevelInfo.NumberLevel];

        if(LevelInfo.TimeDatas.timeDataList.Count >= LevelInfo.NumberLevel)
        {
            FirstTime = LevelInfo.TimeDatas.timeDataList[LevelInfo.NumberLevel].FirstTime;
            SecondTime = LevelInfo.TimeDatas.timeDataList[LevelInfo.NumberLevel].SecondTime;
        }
    }


    private void ShowStars(double curTime)
    {
        if(SecondTime < FirstTime)
        {
            Debug.LogError($"SecondTime should be greater than FirstTime in {LevelInfo.NumberLevel}");

        }

        Debug.Log(curTime);

        if(curTime <= FirstTime)
        {
            for(int i = 0; i < _stars.childCount; i++)
            {
                _stars.GetChild(i).gameObject.SetActive(true);
            }
            countActiveStars = 3;
            _coinReward = SetCoinReward(3);
        }
        else if(curTime <= SecondTime)
        {
            for(int i = 0; i < _stars.childCount-1; i++)
            {
                _stars.GetChild(i).gameObject.SetActive(true);
            }
            countActiveStars = 2;
            _coinReward = SetCoinReward(2);
        }
        else
        {
            _stars.GetChild(0).gameObject.SetActive(true);
            countActiveStars = 1;
            
            LevelInfo.CountStarsOnLevels[LevelInfo.NumberLevel]  = countActiveStars;

            FileSaveLoad.Save(LevelInfo.CountStarsOnLevels, TypeSave.CountStarsOnLevels);
        }

        _coinView.text = _coinReward.ToString();
        
        SaveCoin();
    }

    private int SetCoinReward(int xCoins)
    {
        return _coinReward * xCoins;
    }

    private void SaveCoin()
    {
        Money.coins += _coinReward;

        FileSaveLoad.Save(Money.coins);
    }
}
