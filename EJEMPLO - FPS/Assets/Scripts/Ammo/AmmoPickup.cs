using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    [SerializeField] private AmmoType ammoType;

    [Header("Ammo VFX Configuration")]
    [SerializeField] private int rotateSteps = 8;
    [SerializeField] private float rotateDelay = 0.4f;
    [SerializeField] private float rotateMagnitude = 45f;

    private void Start()
    {
        StartCoroutine(AmmoPickupVFX());
    }

    IEnumerator AmmoPickupVFX()
    {
        while (true)
        {
            for (int i = 0; i < rotateSteps; i++)
            {
                yield return new WaitForSeconds(rotateDelay);
                transform.Rotate(rotateMagnitude, 0f, rotateMagnitude);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Ammo playerAmmo = FindObjectOfType<Ammo>();
            playerAmmo.IncreaseCurrentAmmo(ammoType);
            Destroy(gameObject);
        }
    }
}
