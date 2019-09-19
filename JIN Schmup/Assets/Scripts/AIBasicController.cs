using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicController : InputController
{
      
    void Update() {
        engine.SetDirection(Vector2.left);
        bulletGun.Fire();
    }
}
