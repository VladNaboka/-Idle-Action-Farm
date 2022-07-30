using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Vector3 move;
    float speed = 5f;
    public CharacterController characterController;
    float gravityForce;
    public Animator anim;
    public GameObject mow;
    public Joystick joystick;
    private void Start()
    {
        mow.SetActive(false);
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Controller(true);
    }
    private void Update()
    {
        
        Gravity();
        //if (Input.GetMouseButtonDown(0))
        //{
        //    mow.SetActive(true);
        //    anim.SetBool("MudWheat", true);
        //    StartCoroutine(waitAnim(1));
        //}
        //if (Input.GetMouseButton(1))
        //{
        //    Debug.Log("ANIM");
        //    anim.SetBool("PutD", true);
        //    StartCoroutine(waitAnim(2.3f));
        //}

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);

        if (!Input.GetMouseButtonDown(0))
        {
            Controller(true);
        }
        else
        {
            Controller(false);
        }
    }
    public void HitPlayer()
    {
        mow.SetActive(true);
        anim.SetBool("MudWheat", true);
        StartCoroutine(waitAnim(1));
    }
    public IEnumerator waitAnim(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        anim.SetBool("MudWheat", false);
        mow.SetActive(false);
        anim.SetBool("PutD", false);
    }
    public void Controller(bool activ)
    {
        if (activ == true)
        {
            move = Vector3.zero;
            //move.x = Input.GetAxis("Horizontal");
            //move.z = Input.GetAxis("Vertical");
            move.x = joystick.Horizontal;
            move.z = joystick.Vertical;

            if (Vector3.Angle(Vector3.forward, move) > 1f || Vector3.Angle(Vector3.forward, move) == 0)
            {
                Vector3 direct = Vector3.RotateTowards(transform.forward, move, speed, 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);
            }

            move.y = gravityForce;

            if (move.x != 0 || move.z != 0)
            {
                anim.SetBool("statesPlayer", true);//walk
                characterController.Move(move * Time.deltaTime * speed);
            }
            else
                anim.SetBool("statesPlayer", false);//idle
        }
        
    }
    void Gravity()
    {
        if (!characterController.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;
    }
}
