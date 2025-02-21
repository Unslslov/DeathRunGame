using UnityEngine;
using Unsl;

public class SoundKeeper : MonoBehaviour
{
    [SerializeField] private AudioSource[] AudioSource;

    private void Start() 
    {
        SourceInitialize(AudioSource);
    }

    private void SourceInitialize(AudioSource[] source)
    {
        var settingValue = FileSaveLoad.LoadList<float>(TypeSave.Settings);
        
        if(settingValue != null)
        {
            foreach  (var audioSource in source)
            {
                audioSource.volume = settingValue.ListObjects[1];
            }
        }
    }
}
