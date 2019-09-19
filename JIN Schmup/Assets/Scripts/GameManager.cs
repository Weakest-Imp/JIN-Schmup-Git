using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject poulp;
    [SerializeField] private float poulpPopTime = 1.5f;
    [SerializeField] private float poulpX;
    [SerializeField] private float poulpMinY;
    [SerializeField] private float poulpMaxY;


    void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        Instantiate(player, transform.position, transform.rotation);
        StartCoroutine(PoulpPop());
    }

    IEnumerator PoulpPop() {
        float poulpY = 0;
        while (true) {
            poulpY = Random.Range(poulpMinY, poulpMaxY);
            Instantiate(poulp, new Vector3(poulpX, poulpY, 0), Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(poulpPopTime);
        }
    }
}
