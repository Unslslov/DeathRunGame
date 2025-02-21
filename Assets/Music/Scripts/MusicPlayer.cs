using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioClip[] _audioClips;
    private List<AudioClip> trackList;
    private AudioSource _audioSource;
    public static MusicPlayer instance 
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject("MusicInvoker");
                _instance = go.AddComponent<MusicPlayer>();
                //DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }
    private static MusicPlayer _instance;

    public void Initialize(AudioClip[] audioClips, AudioSource audioSource)
    {
        _audioClips = audioClips;
        _audioSource = audioSource;
        StartCoroutine(PlayTracks());
    }

    private IEnumerator PlayTracks()
    {
        while (true)
        {
            trackList = new List<AudioClip>(_audioClips); // Копируем массив в список
            trackList = Shuffle(trackList); // Перемешиваем список

            foreach (AudioClip track in trackList)
            {
                _audioSource.clip = track;
                Debug.Log($"Теперь проигрывается трек: {track.name}");
                _audioSource.Play();
                yield return new WaitForSeconds(track.length); // Ждем, пока трек закончится
            }

            yield return new WaitForSeconds(30f);
        }
    }

    private List<AudioClip> Shuffle(List<AudioClip> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            AudioClip temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }

        return list;
    }
}
