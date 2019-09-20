using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public static FactoryManager Instance { get; private set; }

    [SerializeField] private Factory playerBulletFactory;
    [SerializeField] private Factory enemyBulletFactory;
    [SerializeField] private Factory enemyFactory;

    public enum ProductType
    {
        playerBullet,
        enemyBullet,
        enemy
    }

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }

        playerBulletFactory.Initialize();
        enemyBulletFactory.Initialize();
        enemyFactory.Initialize();
    }

    public GameObject Spawn(ProductType type) {
        GameObject result = this.gameObject; //Needed to initialize, will never be returned
        switch (type)
        {
            case ProductType.playerBullet :
                result = playerBulletFactory.GetNextSpawn();
                break;
            case ProductType.enemyBullet:
                result = enemyBulletFactory.GetNextSpawn();
                break;
            case ProductType.enemy:
                result = enemyFactory.GetNextSpawn();
                break;
            default:
                return null;
        }

        result.SetActive(true);
        return result;
    }
    
}
