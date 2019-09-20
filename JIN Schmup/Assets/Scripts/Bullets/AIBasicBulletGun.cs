using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicBulletGun : BulletGun
{
    override public void Fire()
    {
        if (currentCooldown <= 0)
        {
            currentCooldown = cooldown;
            GameObject bullet = factory.Spawn(FactoryManager.ProductType.enemyBullet);

            Vector2 bulletPosition = new Vector2(transform.position.x, transform.position.y);
            bullet.GetComponent<Bullet>().Init(damage, speed, Vector2.left, bulletPosition);
        }
    }
}
