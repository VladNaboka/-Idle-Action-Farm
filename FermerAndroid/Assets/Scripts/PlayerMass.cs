using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMass : MonoBehaviour
{
    public GameObject player;
    bool activWalk;
    public WheatP wp;
    private void Start()
    {
        player = GameObject.Find("Player");
        wp = GameObject.Find("Player").GetComponent<WheatP>();
    }
    private void Update()
    {
        StartCoroutine(waitDestroy());
        if (activWalk && !wp.activScoreClose)
            StartCoroutine(drop());
    }
    IEnumerator waitDestroy()
    {
        yield return new WaitForSeconds(1.3f);
        activWalk = true;
        yield return new WaitForSeconds(2f);
        wp.activP = true;
        Destroy(gameObject);
    }
    IEnumerator drop()
    {
        yield return new WaitForSeconds(1f);
        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.01f);
    }
}
