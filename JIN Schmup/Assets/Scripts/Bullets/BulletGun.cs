using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    protected FactoryManager factory;

    [SerializeField] protected GameObject simpleBullet;
    [SerializeField] protected float simpleCost = 10;

    [SerializeField] protected int damage = 1;
    [SerializeField] protected float speed = 10;
    [SerializeField] protected float cooldown = 0.3f;
    protected float currentCooldown = 0;

    [SerializeField] protected float maxEnergy = 100;
    protected float energy;
    [SerializeField] protected float recoverSpeed = 20;
    protected bool emptiedEnergy = false;
    [SerializeField] protected float emptyMalus = 0.75f;


    void Start()
    {
        energy = maxEnergy;

        factory = FactoryManager.Instance;
    }

    
    void Update() {
        if (currentCooldown > 0) {
            currentCooldown -= Time.deltaTime;
        }
    }

    virtual public void Fire() {
        if (!emptiedEnergy) {
            if (currentCooldown <= 0 && energy > 0) {
                currentCooldown = cooldown;
                UseEnergy(simpleCost);

                GameObject bullet = factory.Spawn(FactoryManager.ProductType.playerBullet);

                Vector2 bulletPosition = new Vector2(transform.position.x, transform.position.y);
                bullet.GetComponent<Bullet>().Init(damage, speed, Vector2.right, bulletPosition);
            }
        } else { NotFire(); }
    }

    virtual public void NotFire() {
        if (currentCooldown < 0) {
            if (!emptiedEnergy) {
                RestoreEnergy(recoverSpeed * Time.deltaTime);
            }
            else {
                RestoreEnergy(recoverSpeed * emptyMalus * Time.deltaTime);
            }
        }
    }




    protected void UseEnergy(float cost) {
        energy -= cost;
        if(energy <= 0) {
            energy = 0;
            emptiedEnergy = true;
        }
    }

    protected void RestoreEnergy (float restore) {
        energy += restore;
        if (energy > maxEnergy)
        {
            energy = maxEnergy;
            emptiedEnergy = false;
        }
    }



    public float GetMaxEnergy() { return maxEnergy; }
    public float GetEnergy() { return energy; }
}
