using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class KnifeAttribute : ScriptableObject
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _jumpForce = 3.0f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Sprite _imageIcon;
    [SerializeField] private GameObject _weaponPrefab;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public float Gravity => _gravity; 
    public Sprite ImageIcon => _imageIcon;
    public GameObject WeaponPrefab => _weaponPrefab;
}