using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAvatar : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;

    [SerializeField] protected float maxSpeed;

    private void Start()
    {
        health = maxHealth;
    }


    public void TakeDamage(int damage) {
        health -= damage;
        if(health < 1) {
            Die();
        }
    }

    void Die() {
        gameObject.SetActive(false);
    }


    public float GetMaxSpeed() { return maxSpeed; }
}
