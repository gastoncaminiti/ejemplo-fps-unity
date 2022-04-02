using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float hp = 100;

    public void DamagePlayer(float damage)
    {
        hp -= damage;
        Debug.Log("HIT POINTS ENEMY " + hp);
        if (hp <= 0)
        {
            Debug.Log("GAME OVER");
            GetComponent<DeathHandler>().HandleDeath();
        }

    }
}
