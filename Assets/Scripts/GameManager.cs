using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject CheckA1;
    public GameObject CheckA2;
    public GameObject CheckB1;
    public GameObject CheckB2;
    public GameObject CheckC1;
    public GameObject CheckC2;
    public GameObject CheckD1;
    public GameObject CheckD2;
    public GameObject finalDoor;
    public GameObject YellowDoor;
    public GameObject EndLevel;
    public GameObject Leif;
    public GameObject Water;

    public bool CheckA;
    public bool CheckB;
    public bool CheckC;
    public bool CheckD;
    public bool WaterDie;
    public bool End;

    void Start()
    {
        CheckA = false;
        CheckB = false;
        CheckC = false;
        CheckD = false;
    }

    void Update()
    {
        CheckA = CheckA1.GetComponent<Collider>().bounds.Intersects(CheckA2.GetComponent<Collider>().bounds);
        CheckB = CheckB1.GetComponent<Collider>().bounds.Intersects(CheckB2.GetComponent<Collider>().bounds);
        CheckC = CheckC1.GetComponent<Collider>().bounds.Intersects(CheckC2.GetComponent<Collider>().bounds);
        CheckD = CheckD1.GetComponent<Collider>().bounds.Intersects(CheckD2.GetComponent<Collider>().bounds);
        End = EndLevel.GetComponent<Collider>().bounds.Intersects(Leif.GetComponent<Collider>().bounds);
        WaterDie = Leif.GetComponent<Collider>().bounds.Intersects(Water.GetComponent<Collider>().bounds);

        if (CheckA && CheckB && CheckC && CheckD == true)
        {
            finalDoor.transform.position = new Vector3(finalDoor.transform.position.x, 30.5f, finalDoor.transform.position.z);
        }
        else
        {
            finalDoor.transform.position = new Vector3(finalDoor.transform.position.x, 25.5f, finalDoor.transform.position.z);
        }

        if (CheckA == true)
        {
            YellowDoor.transform.position = new Vector3(YellowDoor.transform.position.x, 21.5f, YellowDoor.transform.position.z);
        }
        else
        {
            YellowDoor.transform.position = new Vector3(YellowDoor.transform.position.x, 10.6f, YellowDoor.transform.position.z);
        }

        if (End)
        {
            RestartScene();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }

        if (WaterDie)
        {
            Leif.transform.position = new Vector3(10.9f, 0.6f, Leif.transform.position.z);
        }
    }
    void RestartScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }


}





