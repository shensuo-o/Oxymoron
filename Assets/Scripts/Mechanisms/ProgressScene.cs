using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressScene : MonoBehaviour
{
    public Vector3 pos;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Choque con algo");
        if (other.gameObject.layer == 7)
        {
            SceneManager.LoadScene("Scene Two");
        }
    }
}
