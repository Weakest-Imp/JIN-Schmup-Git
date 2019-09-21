using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    BulletGun.BulletType bulletType = BulletGun.BulletType.simple;

    [SerializeField] protected float spiralRotation = 0.2f;
    protected float currentSpiralRotation;
    [SerializeField] protected float spiralSlowDown = 0.95f;


    public void SetType(BulletGun.BulletType type) {
        bulletType = type;
    }

    override protected void Update() {
        if (bulletType == BulletGun.BulletType.spiral) {
            direction = Rotate(direction, currentSpiralRotation);
            RotateBullet();
            currentSpiralRotation *= 0.9f;
        }

        base.Update();
    }


    public override void Init(int iniDamage, float iniSpeed, Vector2 iniDirection, Vector2 iniPosition)
    {
        base.Init(iniDamage, iniSpeed, iniDirection, iniPosition);
        currentSpiralRotation = spiralRotation;
    }

    Vector2 Rotate(Vector2 vector, float angle) {
        //returns vector rotated by the angle, does not lose vector
        float cos = Mathf.Cos(angle);
        float sin = Mathf.Sin(angle);

        return new Vector2(cos * vector.x - sin * vector.y, sin * vector.x + cos * vector.y);
    }

    void RotateBullet()
    {
        float angle = Mathf.Atan2(-1 * direction.y, direction.x);
        this.transform.rotation = Quaternion.Euler(0, 0, -180 * angle / Mathf.PI);
    }


    public void SetBulletType(BulletGun.BulletType type) {
        bulletType = type;
    }
}
