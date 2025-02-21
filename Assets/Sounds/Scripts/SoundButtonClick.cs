using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonClick : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource  _audioSource;
    [SerializeField] private  AudioClip _clip;

    private void OnValidate() {
        _button ??= GetComponent<Button>();
    }

    private void Start() {
        _button.onClick.AddListener(PlaySound);
    }

    private void OnDestroy() {
        _button.onClick.RemoveListener(PlaySound);
    }

    private void PlaySound()
    {
        _audioSource.PlayOneShot(_clip);
    }
}
