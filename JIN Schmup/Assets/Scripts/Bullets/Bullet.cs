using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;

    public float Damage {
        get { return damage; }
        set { damage = value; }
    }

    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    private Vector2 position;


     void Awake() {
        position = new Vector2(transform.position.x, transform.position.y);
    }
    
    void Update() {
        position += speed * direction * Time.deltaTime;

        transform.position = new Vector3(position.x, position.y, 0);
    }

    public void Init(float iniDamage, float iniSpeed, Vector2 iniDirection)
    {
        damage = iniDamage;
        speed = iniSpeed;
        direction = iniDirection;

        //Keep for pools
        //transform.position = new Vector3(iniPosition.x, iniPosition.y, 0);
    }

    
}
