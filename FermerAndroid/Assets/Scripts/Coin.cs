using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public GameObject scoreImage;
    Rigidbody rb;
    public bool activMoneyAdd;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreImage = GameObject.Find("MoneyCoinFind");
    }
    void Update()
    {
        StartCoroutine(waitCoinGoScore());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            
            Destroy(gameObject);
        }
    }
    IEnumerator waitCoinGoScore()
    {
        yield return new WaitForSeconds(0.3f);
        rb.isKinematic = true;
        transform.position = Vector3.Lerp(transform.position, scoreImage.transform.position, 0.1f);
    }
}
