using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public int Damage {
        get { return damage; }
        set { damage = value; }
    }

    [SerializeField] protected float speed;
    [SerializeField] protected Vector2 direction;
    protected Vector2 position;


    void Start() {
        position = new Vector2(transform.position.x, transform.position.y);
    }
    
    virtual protected void Update() {
        position += speed * direction * Time.deltaTime;

        transform.position = new Vector3(position.x, position.y, 0);
    }

    virtual public void Init(int iniDamage, float iniSpeed, Vector2 iniDirection, Vector2 iniPosition)
    {
        damage = iniDamage;
        speed = iniSpeed;
        direction = iniDirection;

        position = iniPosition;
        transform.position = new Vector3(iniPosition.x, iniPosition.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        string tag = other.gameObject.tag;
        if (tag == "Bullet") {
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else if(tag == "Player" || tag == "Enemy") {
            BaseAvatar avatar = other.GetComponent<BaseAvatar>();
            avatar.TakeDamage(damage);
            this.gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }

}
