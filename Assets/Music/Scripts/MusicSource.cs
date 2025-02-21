using UnityEngine;
using Unsl;

public class MusicSource : MonoBehaviour, ISource<AudioSource>
{
    public AudioClip[] AudioClips;
    public AudioSource AudioSource;

    public void SourceInitialize(AudioSource source)
    {
        var settingValue = FileSaveLoad.LoadList<float>(TypeSave.Settings);

        if(settingValue != null)
        {
            source.volume = settingValue.ListObjects[0];
        }
    }

    private void Start() 
    {
        SourceInitialize(AudioSource);

       var go = MusicPlayer.instance;
       go.Initialize(AudioClips, AudioSource);
    }
}