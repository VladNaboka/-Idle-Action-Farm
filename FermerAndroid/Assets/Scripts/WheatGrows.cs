using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatGrows : MonoBehaviour
{
    //public GameObject objectCut;
    //public GameObject dropWheat;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ScytheV1")
        {
            StartCoroutine(dontDestroyCut());
        }
    }
    public IEnumerator dontDestroyCut()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(true);
        yield break;
    }
}
