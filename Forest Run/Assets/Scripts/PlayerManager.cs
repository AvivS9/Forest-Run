using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Animator m_Animator;
    public static PlayerManager instance;
    private GameObject PlayBtn;
    private Camera mainCamera;
    public bool onGround = true;

    private Rigidbody rigidbody;


    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        mainCamera = Camera.main;

        rigidbody = GetComponent<Rigidbody>();

    }

    public void StartMoving()
    {
        GameManager.instance.setButtonsForGame();
        m_Animator.SetBool("GameStart", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onGround = true;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            m_Animator.SetBool("Lost", true);
            mainCamera.transform.parent = null;

            Debug.Log("lost");

        }
        if (collision.gameObject.tag == "FinishLine")
        {
            
            //m_Animator.SetBool("Won", true);
            Debug.Log("bug in collision");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FinishLine")
        {
            m_Animator.SetBool("Won", true);
            Debug.Log("finished");
        }
    }
}
