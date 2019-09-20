using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engines : MonoBehaviour
{
    private BaseAvatar avatar;

    [SerializeField] private float speed;

    [SerializeField] private Vector2 direction;
    private Vector2 position;


    void Awake() {
        avatar = this.GetComponent<BaseAvatar>();
        
        speed = avatar.GetMaxSpeed();
    }

    private void Start() {
        position = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update() {

        position = new Vector2(transform.position.x, transform.position.y);
        position += speed * direction * Time.deltaTime;

        transform.position = new Vector3(position.x, position.y, 0);
    }

    public void SetDirection(Vector2 dir) {
        direction = dir;
        direction.Normalize();
    }
}
