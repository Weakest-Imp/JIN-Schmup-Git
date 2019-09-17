using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engines : MonoBehaviour
{
    private BaseAvatar avatar;

    private Vector2 position;
    private Vector2 speed;


    void Awake() {
        avatar = this.GetComponent<BaseAvatar>();

        position = new Vector2(transform.position.x, transform.position.y);
    }
    

    void Update() {
        speed.Normalize();
        speed = speed * avatar.GetMaxSpeed();
        
        position += speed * Time.deltaTime;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }


    public void SetSpeed(Vector2 newSpeed) { speed = newSpeed; }
}
