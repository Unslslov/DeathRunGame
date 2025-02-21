using UnityEngine;
using Unsl;

public class AssignAllLevels : MonoBehaviour
{
    [SerializeField] private TimeDataList _timeDatas;
    [SerializeField] private Transform _levels;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip  _clip;
    private SaveLoadListData<int> LoadFileStarInLevels;
    private SaveLoadListData<string> LoadFileBestPlayerRecordOnLevels;
    private SaveLoadListData<double> LoadFileBestTimeRunOnLevels;

    private void OnValidate() 
    {
        _levels ??= transform;    
    }

    void Awake()
    { 
        LevelInfo.InitializeCountLevels(_levels.childCount, _timeDatas);

        LoadFileStarInLevels = FileSaveLoad.LoadList<int>(TypeSave.CountStarsOnLevels);
        LoadFileBestPlayerRecordOnLevels = FileSaveLoad.LoadList<string>(TypeSave.BestResultOnLevels);
        LoadFileBestTimeRunOnLevels = FileSaveLoad.LoadList<double>(TypeSave.BestTimeRunOnLevels);
        
        if(LoadFileStarInLevels != null)
            LevelInfo.CountStarsOnLevels = LoadFileStarInLevels.ListObjects;
        
        if(LoadFileBestPlayerRecordOnLevels != null)
            LevelInfo.BestPlayerRecordOnLevels = LoadFileBestPlayerRecordOnLevels.ListObjects;
        
        if(LoadFileBestPlayerRecordOnLevels != null)
            LevelInfo.BestPlayerTimeRun = LoadFileBestTimeRunOnLevels.ListObjects;

        for(int i = 0; i < _levels.childCount; i++)
        {
            var levelSelection = _levels.GetChild(i).GetComponent<LevelSelection>();
            
            levelSelection.CurrentLevel = i+1;

            levelSelection.Initialized(_audioSource, _clip);
        }
    }

}
