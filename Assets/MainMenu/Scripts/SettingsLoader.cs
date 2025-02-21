using UnityEngine.UI;
using Zenject;

enum SettingType
{
    Sensivity
}

public class SettingsLoader : MonoInstaller
{
    public Slider SensivitySlider;

    public override void InstallBindings()
    {
        Container.BindInstance(SensivitySlider).WithId(SettingType.Sensivity).AsSingle();
    }
}