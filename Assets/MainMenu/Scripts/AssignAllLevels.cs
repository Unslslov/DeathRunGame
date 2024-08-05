using UnityEngine;

public class AssignAllLevels : MonoBehaviour
{
    [SerializeField] private Transform _levels;

    private void OnValidate() 
    {
        _levels ??= transform;    
    }

    void Awake()
    {  
        for(int i = 0; i < _levels.childCount; i++)
        {
            var levelSelection = _levels.GetChild(i).GetComponent<LevelSelection>();

            levelSelection.CurrentLevel = i+1;
        }
    }

}
