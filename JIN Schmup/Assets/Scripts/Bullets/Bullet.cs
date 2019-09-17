using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;


    [SerializeField] private float damage;

    public float Damage {
        get { return damage; }
        set { damage = value; }
    }

    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;


     void Awake() {
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    void Update() {
        
    }

    public void Init(float iniDamage, float iniSpeed, Vector2 iniDirection)
    {
        damage = iniDamage;
        speed = iniSpeed;
        direction = iniDirection;

        rb.velocity = speed * direction;

        //Keep for pools
        //transform.position = new Vector3(iniPosition.x, iniPosition.y, 0);
    }

    
}
