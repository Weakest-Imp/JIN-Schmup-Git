using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicController : InputController
{
      
    void Update() {
        engine.SetSpeed(Vector2.left);
    }
}
