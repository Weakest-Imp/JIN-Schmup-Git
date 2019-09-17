using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    protected Engines engine;

    protected float horInput;
    protected float verInput;
    protected float fireInput;


    void Awake() {
        engine = this.GetComponent<Engines>();
    }

    
    void Update() {
        CheckInput();

        engine.SetSpeed(new Vector2(horInput, verInput));
    }

    void CheckInput() {
        horInput = Input.GetAxisRaw("Horizontal");
        verInput = Input.GetAxisRaw("Vertical");
        fireInput = Input.GetAxisRaw("Fire1");
    }

}
