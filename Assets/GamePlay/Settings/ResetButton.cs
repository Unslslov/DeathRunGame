using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ResetButton : MonoBehaviour
{
    [SerializeField] private Button  _button;
    [SerializeField] private Slider _slider;
    [SerializeField] private SliderType sliderType;

    private void OnValidate() 
    {
       _button ??= GetComponent<Button>(); 
    }

    private void OnEnable() 
    {
        _button.onClick.AddListener(SetSettingDefaul);
    }

    private void SetSettingDefaul()
    {
        switch(sliderType)
        {
            case SliderType.Sensivity:
                _slider.value = SettingDefault.SensivityValue;
                break;
            case SliderType.Music:
                _slider.value = SettingDefault.MusicValue;
                break;
            case SliderType.Sound:
                _slider.value = SettingDefault.SoundValue;
                break;
        }
    }
}

enum  SliderType
{
    Sensivity,
    Music,
    Sound
}
