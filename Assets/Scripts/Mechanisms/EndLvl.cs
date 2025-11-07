using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        LoadLevel.Instance.PlayStart();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
}
