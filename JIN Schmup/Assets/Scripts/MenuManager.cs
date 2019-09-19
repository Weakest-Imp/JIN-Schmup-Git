using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator explo;

    public void StartButton()
    {
        SceneManager.LoadScene("PoulpScene");
    }

    public void NotQuit() {
        explo.SetTrigger("Explosion");
    }
}
