using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAvatar : MonoBehaviour
{
    [SerializeField] protected float maxSpeed;

    public float GetMaxSpeed() { return maxSpeed; }
}
