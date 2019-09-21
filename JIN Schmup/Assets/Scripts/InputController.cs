using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    protected Engines engine;
    protected BulletGun bulletGun;

    protected float horInput;
    protected float verInput;
    protected float fireInput;

    protected float changeInput;
    protected float previousChangeInput = 0;
    protected bool changeInputpressed;



    void Awake() {
        engine = this.GetComponent<Engines>();
        bulletGun = this.GetComponent<BulletGun>();
    }

    
    void Update() {
        CheckInput();

        engine.SetDirection(new Vector2(horInput, verInput));

        if (changeInputpressed) {
            bulletGun.ChangeBulletType();
        }

        if(fireInput > 0) {
            bulletGun.Fire();
        } else {
            bulletGun.NotFire();
        }
    }

    void CheckInput() {
        horInput = Input.GetAxisRaw("Horizontal");
        verInput = Input.GetAxisRaw("Vertical");
        fireInput = Input.GetAxisRaw("Fire1");

        previousChangeInput = changeInput;
        changeInput = Input.GetAxisRaw("Change");
        changeInputpressed = (previousChangeInput == 0 && changeInput == 1);
    }

}
