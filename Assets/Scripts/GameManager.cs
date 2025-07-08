using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool CheckAmarillo;
    public bool CheckRojo;
    public bool CheckVerde;
    public bool CheckRosa;
    public bool Death;
    public bool Finish;

    public GameObject finalDoor;
    public GameObject Leif;

    private void Awake()
    {
        Instance = this;

        finalDoor = GameObject.Find("Exit");
        Leif = GameObject.Find("Leif");

        CheckAmarillo = false;
        CheckRojo = false;
        CheckVerde = false;
        CheckRosa = false;
    }

    private void Update()
    {
        if (CheckAmarillo && CheckRojo && CheckRosa && CheckVerde)
        {
            if(finalDoor != null)
            {
                finalDoor.transform.position = new Vector3(31.6f, 31.6f, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Prototype");
        }

        if (Finish)
        {
            SceneManager.LoadScene("Menu");
        }

        if (Death)
        {
            Leif.GetComponent<Personaje>().TakeDamage(10, Leif.transform.up);
            Death = false;
        }
    }
}







