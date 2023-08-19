using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed = 3f;

    private int score;
    private float time;
    public GameObject controller;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (controller.GetComponent<Controllers>().gamePlay)
        {
            if (gameObject.transform.rotation != Quaternion.Euler(0, 0, 0))
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isFastRun", true);
                Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                Vector3 hizEklentisi = playerInput * Time.deltaTime * moveSpeed;
                transform.Translate(hizEklentisi);
            }
            else
            {
                animator.SetBool("isFastRun", false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isBack", true);
                transform.Translate(new Vector3(0, 0, -2f) * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isBack", false);
            }

            if (Input.GetKey(KeyCode.Space)) //Zýplama
            {
                animator.SetBool("isJump", true);
                transform.Translate(new Vector3(0, 3f, 0) * Time.deltaTime);

            }
            else
            {
                animator.SetBool("isJump", false);
            }

        }
       
    }

    private void OnCollisionEnter(Collision other)
    { 

        string objName = other.gameObject.name;
        string objTag = other.gameObject.tag;

        if (objName.Equals("FinishPlane"))
        {
            controller.GetComponent<Controllers>().gamePlay = false;
            controller.GetComponent<Controllers>().isFinish = true;
        }

        if (objTag.Equals("Hit"))
        {
            score = controller.GetComponent<Controllers>().score;
            score -= 100;
            controller.GetComponent<Controllers>().score = score;

            time = controller.GetComponent<Controllers>().leftTime;
            time -= 10;
            controller.GetComponent<Controllers>().leftTime = time;
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        string objTag = other.gameObject.tag;
        if (objTag.Equals("Passage"))
        {
            score = controller.GetComponent<Controllers>().score;
            score += 100;
            controller.GetComponent<Controllers>().score = score;

            time = controller.GetComponent<Controllers>().leftTime;
            time += 5;
            controller.GetComponent<Controllers>().leftTime = time;

        }
    }
}