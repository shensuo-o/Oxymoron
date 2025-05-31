using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    public string elementType;
    public GameObject particles;
    public Sprite icon;
    [SerializeField] private float coolDown;


    public IEnumerator TurnOffAndOn()
    {
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(coolDown);
        gameObject.GetComponent<SphereCollider>().enabled = true;
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
    }

}
