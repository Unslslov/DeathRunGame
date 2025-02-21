using System;
using UnityEngine;
using Unsl;

[RequireComponent(typeof(AudioSource))]
public class SoundSource : MonoBehaviour, ISource<AudioSource>
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _clips;

    public event Action<AudioSource, AudioClip> OnClipPlayedEvent;
    public event Action<AudioSource, AudioClip[]> OnClipsPlayedEvent;

    public float volume = 1f;

    private void OnValidate() 
    {
        _audioSource ??= GetComponent<AudioSource>();
    }

    private void Start() 
    {
        SourceInitialize(_audioSource);
    }

    private void  OnCollisionEnter(Collision col) 
    {
        OnClipPlayedEvent?.Invoke(_audioSource, _clips[0]);
        OnClipsPlayedEvent?.Invoke(_audioSource, _clips);
    }

    public void SourceInitialize(AudioSource source)
    {
        var settingValue = FileSaveLoad.LoadList<float>(TypeSave.Settings);

        if(settingValue != null)
        {
            source.volume = settingValue.ListObjects[1];
        }
    }
}
