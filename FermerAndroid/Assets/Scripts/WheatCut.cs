using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatCut : MonoBehaviour
{
    public GameObject objectWheat;
    public WheatDanger wD;

    bool activ;
    private void Start()
    {
        wD = GameObject.Find("ScytheV1").GetComponent<WheatDanger>();
        objectWheat = GameObject.Find("WhD Script");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ScytheV1")
        {
            StartCoroutine(growsObjCut(gameObject));
        }
        else if (wD.activCutWh)
            StartCoroutine(dontDestroyCut());
    }
    public IEnumerator growsObjCut(GameObject gameObj)
    {
        yield return new WaitForSeconds(5f);
        gameObj.transform.position = new Vector3(gameObj.transform.position.x, 0, gameObj.transform.position.z);
        gameObj.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(5f);
        Instantiate(objectWheat, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObj);
    }
    public IEnumerator dontDestroyCut()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(objectWheat, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
