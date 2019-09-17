using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engines : MonoBehaviour
{
    private Rigidbody2D rb;
    private BaseAvatar avatar;

    [SerializeField] private float speed;

    [SerializeField] private Vector2 direction;


    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        avatar = this.GetComponent<BaseAvatar>();
        
        speed = avatar.GetMaxSpeed();

        rb.velocity = speed * direction;
    }

    public void SetDirection(Vector2 dir) {
        direction = dir;
        direction.Normalize();

        rb.velocity = speed * direction;
    }
}
