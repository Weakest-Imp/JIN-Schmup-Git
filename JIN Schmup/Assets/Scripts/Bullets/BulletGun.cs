using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    [SerializeField] private GameObject simpleBullet;

    [SerializeField] private int damage = 1;
    [SerializeField] private float speed = 10;
    [SerializeField] private float cooldown = 0.3f;
    private float currentCooldown = 0;

    void Start()
    {
        
    }

    
    void Update() {
        if (currentCooldown > 0) {
            currentCooldown -= Time.deltaTime;
        }
    }

    public void Fire() {
        if (currentCooldown <= 0) {
            currentCooldown = cooldown;
            GameObject bullet = Instantiate(simpleBullet, this.transform.position, this.transform.rotation);
            bullet.GetComponent<Bullet>().Init(damage, speed, Vector2.right);
        }
    }
}
