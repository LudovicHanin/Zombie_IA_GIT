using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float range = 100f;
    [SerializeField] private int ammoInClip = 20;
    [SerializeField] private int totalAmmo = 20;
    [SerializeField] private float reloadTime = 2f;
    
    private float timeSinceLastShot = 0f;
    private bool isReloading = false;

    private void Reload()
    {
        if (isReloading || totalAmmo <= 0 || ammoInClip == totalAmmo)
        {
            return;
        }

        isReloading = true;
        Invoke(nameof(FinishReloading), reloadTime);
    }

    private IEnumerator FinishReloading()
    {
        int ammoToReload = Mathf.Min(totalAmmo - ammoInClip, totalAmmo);
        ammoInClip += ammoToReload;
        isReloading = false;
        yield break;
    }

    private void Fire()
    {
        if (isReloading || ammoInClip <= 0 || timeSinceLastShot < fireRate)
        {
            return;
        }

        timeSinceLastShot = 0f;
        ammoInClip--;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range))
        {
            Z_ZombieBrain zombie = hit.transform.GetComponent<Z_ZombieBrain>();
            if (zombie != null)
            {
                Debug.Log("Hit Zombie");
            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        
        if(Input.GetKeyDown(KeyCode.Mouse0)) Fire();
        if (Input.GetKeyDown(KeyCode.R)) Reload();
    }
}
