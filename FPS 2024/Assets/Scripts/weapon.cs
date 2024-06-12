using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletImpact;
    [SerializeField] int magazine;
    [SerializeField] MeshFilter ModeloAtual;
    [SerializeField] MeshRenderer materialAtual;



    int ammo;
    float timeToShoot;
    float timeToReload;
    bool reloading;
    void Start()
    {
        ModeloAtual = GetComponentInChildren<MeshFilter>();
        materialAtual = GetComponentInChildren<MeshRenderer>();

        magazine = weaponData.MagazinCap;

        ModeloAtual.mesh = weaponData.Model;
        materialAtual.material = weaponData.Material;


    }

    private void fire()
    {
        StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine()
    {
        if ( Time.time >= timeToShoot && !reloading   )
        {
            
                magazine -= weaponData.BulletsForShoot;
                timeToShoot = Time.time + 1 / weaponData.FireRate;
            for (int i =0;i <weaponData.BulletsForShoot;i++)
            {
                if(magazine > 0)
                {
                    magazine --;
                    Shoot();
                    yield return new WaitForSeconds(weaponData.TimeBetweenShoots);
                }
            }
            
        }
    }

    private void Shoot()
    {
       
        RaycastHit hit;

  

        Vector3 direction = new Vector3(Random.Range(-weaponData.Spread, weaponData.Spread), Random.Range(-weaponData.Spread, weaponData.Spread), 0) + firePoint.forward;

        if (Physics.Raycast(firePoint.position, direction, out hit,weaponData.Range))
        {         
            Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
            Debug.DrawLine(firePoint.position, firePoint.position + direction * weaponData.Range);
        }        
    }

    private void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {

        
        if (magazine <weaponData.MagazinCap && ammo >0)
        {
            if(magazine+ ammo >= weaponData.MagazinCap)
            {

           
            ammo -= weaponData.MagazinCap - magazine;
            magazine = weaponData.MagazinCap;
           
            }
            else
            {
                magazine += ammo;
                ammo = 0;
            }
            reloading = true;
            yield return  new WaitForSeconds(weaponData.ReloadTime);
        }
    }

    void UpdateWeapon()
    {
        weaponData = new WeaponData();
    }

    private void OnDrawGizmos()
    {
        // Você pode adicionar gizmos para visualizar coisas como o alcance do disparo
    }


}
