using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField][Range(10, 1000)] private int health = 50;

    [SerializeField] private bool isDead = false;
    public bool IsDead { get { return isDead; } }

    public void Wounded(int damage)
    {
        BroadcastMessage("OnDamageTaken");
        health -= damage;
        if (health <= 0)
        {
            //Destroy(gameObject);
            Die();
        }

    }

    private void Die()
    {
        if (IsDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
