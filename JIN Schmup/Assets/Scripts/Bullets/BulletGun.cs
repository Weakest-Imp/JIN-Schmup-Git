using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    [SerializeField] protected GameObject simpleBullet;

    [SerializeField] protected int damage = 1;
    [SerializeField] protected float speed = 10;
    [SerializeField] protected float cooldown = 0.3f;
    protected float currentCooldown = 0;

    void Start()
    {
        
    }

    
    void Update() {
        if (currentCooldown > 0) {
            currentCooldown -= Time.deltaTime;
        }
    }

    virtual public void Fire() {
        if (currentCooldown <= 0) {
            currentCooldown = cooldown;
            GameObject bullet = Instantiate(simpleBullet, this.transform.position, this.transform.rotation);
            bullet.GetComponent<Bullet>().Init(damage, speed, Vector2.right);
        }
    }
}
