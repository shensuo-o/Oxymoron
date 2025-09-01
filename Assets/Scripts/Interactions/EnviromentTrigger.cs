using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentTrigger : MonoBehaviour, IDataPersistance
{
    [SerializeField] private string id;

    [ContextMenu("Generate id")]

    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    [SerializeField] private bool state = false;

    [SerializeField] private string[] allowedOximorons;
    [SerializeField] private Animator animator;

    public void LoadData(GameData data)
    {
        data.solvedPuzzles.TryGetValue(id, out state);
    }

    public void SaveData(ref GameData data)
    {
        if (data.solvedPuzzles.ContainsKey(id))
        {
            data.solvedPuzzles.Remove(id);
        }
        data.solvedPuzzles.Add(id, state);
    }

    private void Start()
    {
        if (state == true)
        {
            StartCoroutine(ActivateMoveAnim());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            for (int i = 0; i < allowedOximorons.Length; i++)
            {
                if (allowedOximorons[i] == other.GetComponent<StatsOximorones>().oxiName)
                {
                    StartCoroutine(ActivateMoveAnim());
                }
            }
        }
    }

    public IEnumerator ActivateMoveAnim()
    {
        animator.SetBool("Move", true);   
        yield return new WaitForSeconds(5f);
        animator.SetBool("Move", false); 
        state = true;
    }
}
