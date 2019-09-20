using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private FactoryManager factory;

    [SerializeField] private GameObject player;
    private GameObject currentPlayer;

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

        currentPlayer = Instantiate(player, transform.position, transform.rotation);
        
    }

    private void Start()
    {
        factory = FactoryManager.Instance;

        StartCoroutine(PoulpPop());
    }

    IEnumerator PoulpPop() {
        float poulpY = 0;
        while (true) {
            poulpY = Random.Range(poulpMinY, poulpMaxY);
            GameObject poulp = factory.Spawn(FactoryManager.ProductType.enemy);
            poulp.transform.position = new Vector3(poulpX, poulpY, 0);
            yield return new WaitForSeconds(poulpPopTime);
        }
    }


    public void GameOver() {
        SceneManager.LoadScene("PoulpScene");
    }

    public GameObject GetPlayer() { return currentPlayer; }
}
