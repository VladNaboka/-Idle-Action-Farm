using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoubleWh : MonoBehaviour
{
    public WheatP wheatP;
    public GameObject[] massBlock = new GameObject[39];
    public GameObject[] backBlock = new GameObject[39];
    int i;
    public GameObject backWh;

    public GameObject barnPoint;
    public TextMeshProUGUI coins;
    int scoreCoin = 0;

    public GameObject coinM;
    public GameObject pointC;

    public Coin coinSC;
    private void Update()
    {
        if (wheatP.activP == true)
        {
            for (i = 0; i < massBlock.Length; i++)
            {
                if (massBlock[i] == null)
                {
                    Debug.Log("Hi");
                    massBlock[i] = Instantiate(backWh, backBlock[i].transform.position, backBlock[i].transform.rotation);
                    massBlock[i].transform.parent = backBlock[i].transform;
                    wheatP.activP = false;
                    wheatP.wheat += 1;
                    break;
                }

            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Barn")
        {
            try
            {
                for (i = 0; i < massBlock.Length; i++)
                {
                    massBlock[i].transform.position = Vector3.Lerp(massBlock[i].transform.position, barnPoint.transform.position, 0.1f);
                    StartCoroutine(En(i));
                }
            }
            catch { }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barn"))
        {
            StartCoroutine(scoreADDMoneyInAmbar());
            Instantiate(coinM, pointC.transform.position, Quaternion.identity);
        }
    }
    IEnumerator scoreADDMoneyInAmbar()
    {
        yield return new WaitForSeconds(0.5f);
        scoreCoin += 15 * wheatP.wheat;
        coins.text = scoreCoin.ToString();
        wheatP.wheat = 0;
    }
    IEnumerator En(int i)
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(massBlock[i]);
        try
        {
            massBlock[i].transform.parent = null;
            massBlock[i] = null;
        }
        catch { }
    }
}
