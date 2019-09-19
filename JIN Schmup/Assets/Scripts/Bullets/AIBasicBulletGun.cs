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
            GameObject bullet = Instantiate(simpleBullet, this.transform.position, this.transform.rotation);
            bullet.GetComponent<Bullet>().Init(damage, speed, Vector2.left);
        }
    }
}
