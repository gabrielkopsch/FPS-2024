using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()] 
public class WeaponData : ScriptableObject
{
    [SerializeField] float damage, range, fireRate, spread, reloadTime, timeBetweenShoots;
    [SerializeField] int magazineCap, bulletsForShoot;
    [SerializeField] bool automatic, scope;
    [SerializeField] Mesh model;
    [SerializeField] Material material;
    [SerializeField] Vector3 weaponPosition;


    #region
    public float Damage { get => damage; }
    public float Range { get => range;  }
    public float FireRate { get => fireRate;  }
    public float Spread { get => spread;  }
    public float ReloadTime { get => reloadTime; }
    public float TimeBetweenShoots { get => timeBetweenShoots; }
    public int MagazinCap { get => magazineCap; }
    public int BulletsForShoot { get => bulletsForShoot; }
    public Mesh Model { get => model; }
    public Material Material { get => material; }
    public Vector3 WeaponPosition { get => weaponPosition; }
    #endregion

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
