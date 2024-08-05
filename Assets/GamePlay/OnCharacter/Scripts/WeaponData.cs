using UnityEngine;

public struct WeaponData
{
    public float Speed {get; private set;}
    public float JumpForce {get; private set;}
    public float Gravity {get; private set;}
    public Sprite ImageIcon {get; private set;}
    public GameObject WeaponPrefab {get; private set;}

    public WeaponData(KnifeAttribute knife)
    {
        Speed = knife.Speed;
        JumpForce = knife.JumpForce;
        Gravity = knife.Gravity;
        ImageIcon = knife.ImageIcon;
        WeaponPrefab = knife.WeaponPrefab;
    }
}
