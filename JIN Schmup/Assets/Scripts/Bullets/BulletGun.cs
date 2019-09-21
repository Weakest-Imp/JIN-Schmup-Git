using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    protected FactoryManager factory;

    public enum BulletType
    {
        simple,
        spiral
    }
    protected BulletType bulletType = BulletType.simple;
    
    [SerializeField] protected float simpleCost = 10;
    [SerializeField] protected float spiralCost = 20;

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
                
                switch (bulletType)
                {
                    case BulletType.simple :
                        SimpleFire();
                        break;
                    case BulletType.spiral:
                        SpiralFire();
                        break;
                    default:
                        break;
                }
            
            }
        } else { NotFire(); }
    }

    void SimpleFire() {
        UseEnergy(simpleCost);

        GameObject bullet = factory.Spawn(FactoryManager.ProductType.playerBullet);
        PlayerBullet playerBullet = bullet.GetComponent<PlayerBullet>();

        Vector2 bulletPosition = new Vector2(transform.position.x, transform.position.y);
        playerBullet.SetBulletType(bulletType);
        playerBullet.Init(damage, speed, Vector2.right, bulletPosition);
    }

    void SpiralFire() {
        UseEnergy(spiralCost);

        for (int i = 0; i < 4; i++) {
            GameObject bullet = factory.Spawn(FactoryManager.ProductType.playerBullet);
            PlayerBullet playerBullet = bullet.GetComponent<PlayerBullet>();

            Vector2 bulletPosition = new Vector2(transform.position.x, transform.position.y);
            playerBullet.SetBulletType(bulletType);
            playerBullet.Init(damage, speed, Rotate(Vector2.right, i * Mathf.PI/2), bulletPosition);
        }
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

    public void ChangeBulletType() {
        //needs to check for the last BulletType possible, to make it loop
        if (bulletType != BulletType.spiral) {
            bulletType++;
        } else {
            bulletType = BulletType.simple;
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



    Vector2 Rotate(Vector2 vector, float angle)
    { //returns vector rotated by the angle, does not lose vector
        float cos = Mathf.Cos(angle);
        float sin = Mathf.Sin(angle);

        return new Vector2(cos * vector.x - sin * vector.y, sin * vector.x + cos * vector.y);
    }


    public float GetMaxEnergy() { return maxEnergy; }
    public float GetEnergy() { return energy; }

}
