using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheatP : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int wheat = 0;
    public PlayerController plC;
    bool activE;
    public bool activP;
    public bool activScoreClose;
    private void Start()
    {
        plC = GetComponent<PlayerController>();
    }
    private void Update()
    {
        score.text = wheat.ToString();
        if (activE)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Input 1!");
                plC.anim.SetBool("PutD", true);
                StartCoroutine(waitPut());
                return;
            }
            activE = false;
        }
        if (wheat == 40)
            activScoreClose = true;
        else
            activScoreClose = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            activE = true;
            if (activP)
            {
                activP = false;
                activE = false;
                Destroy(other.gameObject);
            }
            Debug.Log("Trigger!");
        }
        else
        {
            activE = false;
            activP = false;
        }
            
    }
    IEnumerator waitPut()
    {
        yield return new WaitForSeconds(2.3f);
        wheat += 1;
        plC.anim.SetBool("PutD", false);
        //activP = true;
        activE = false;
    }
}
