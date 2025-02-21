using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private TextFadeAndMove _text;
    [SerializeField] private StopWatch _stopwatch;
    public override void InstallBindings()
    {
        Container.BindInstance(_text).AsSingle();
        Container.BindInstance(_stopwatch).AsSingle();
    }
}