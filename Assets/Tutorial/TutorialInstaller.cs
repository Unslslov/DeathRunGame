using UnityEngine;
using Zenject;

public class TutorialInstaller : MonoInstaller
{
    [SerializeField] private ActivateJoystickTutorial _activateJoystickTutorial;
    [SerializeField] private ActivateJumpButtonTutorial  _activateJumpButtonTutorial;
    [SerializeField] private WeaponTutorail  _weaponTutorial;
    [SerializeField] private TutorialJoystick _joystickTutor;
    [SerializeField] private TutorialButtonJump _jumpButtonTutor;

    public override void InstallBindings()
    {
        Container.BindInstance(_weaponTutorial).AsSingle();
        
        Container.BindInstance(_activateJoystickTutorial).AsSingle();
        Container.BindInstance(_activateJumpButtonTutorial).AsSingle();
        Container.BindInstance(_joystickTutor).AsSingle();
        Container.BindInstance(_jumpButtonTutor).AsSingle();
    }
}