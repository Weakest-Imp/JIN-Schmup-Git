using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.SetActive(false);
    }
}
