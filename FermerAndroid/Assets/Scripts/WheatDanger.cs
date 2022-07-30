using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatDanger : MonoBehaviour
{
    public GameObject objectCut;
    public GameObject objectWheat;
    public GameObject dropWheat;

    public bool activCutWh;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mow"))
        {
            Debug.Log("GGOGO");
            StartCoroutine(waitDestroy(other.gameObject));
        }
        if (other.gameObject.CompareTag("MowCut"))
        {
            StartCoroutine(waitDestroyCut(other.gameObject));
        }
    }
    public IEnumerator waitDestroy(GameObject gameObjWheat)
    {
        yield return new WaitForSeconds(0.5f);
        try
        {
            Instantiate(objectCut, gameObjWheat.transform.position, Quaternion.identity);
            Instantiate(dropWheat, new Vector3(gameObjWheat.transform.position.x, gameObjWheat.transform.position.y + 2f, gameObjWheat.transform.position.z), Quaternion.Euler(20, 10, 0));
            Destroy(gameObjWheat);
            activCutWh = true;
        } catch { }
        
        yield break;
    }
    public IEnumerator waitDestroyCut(GameObject gameObj)
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(dropWheat, new Vector3(gameObj.transform.position.x, gameObj.transform.position.y + 2f, gameObj.transform.position.z), Quaternion.identity);
        gameObj.transform.position = new Vector3(gameObj.transform.position.x, -1.2f, gameObj.transform.position.z);
        gameObj.GetComponent<BoxCollider>().enabled = false;
        //activCutWh = false;
    }
}
