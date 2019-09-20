using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Factory
{
    public GameObject prefab;

    public int spawnNumber;
    private List<GameObject> instances;

    private int currentInstance;

    public void Initialize() {
        currentInstance = 0;
        instances = new List<GameObject>(spawnNumber);
        for (int i = 0; i < spawnNumber; i++) {
            instances.Add(GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity));
            instances[i].SetActive(false);
        }
    }


    public GameObject GetNextSpawn() {
        GameObject result = instances[currentInstance];
        currentInstance++;
        if(currentInstance >= spawnNumber) {
            currentInstance = 0;
        }

        return result;

    }
}
