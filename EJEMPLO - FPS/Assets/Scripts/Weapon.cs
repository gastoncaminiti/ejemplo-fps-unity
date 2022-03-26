using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private Transform shootOrigin;
    [SerializeField][Range(1, 200)] private int weaponRange = 100;
    [SerializeField][Range(1, 500)] private int weaponDamage = 25;
    [SerializeField] private ParticleSystem shootVFX;
    [SerializeField] private GameObject hitVFXSystem;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayShootVFX();
        ShootRaycast();

    }

    private void PlayShootVFX()
    {
        shootVFX.Play();
    }

    private void ShootRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootOrigin.position, shootOrigin.forward, out hit, weaponRange))
        {

            Debug.Log(hit.transform.name);
            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                CreateHitImpact(hit, 1);
                target.Wounded(weaponDamage);
            }
            else
            {
                CreateHitImpact(hit, 0);
            }
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit, int indexEffect)
    {
        Transform child = hitVFXSystem.transform.GetChild(indexEffect);
        Transform hitVFX = Instantiate(child, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitVFX.gameObject, 0.2f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(shootOrigin.position, shootOrigin.forward * weaponRange);
    }
}
