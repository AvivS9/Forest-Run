using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementTemplate : MonoBehaviour
{

    public float forwardSpeed = 10f;
    private Rigidbody rigidbody;
    private float sideForce = 500f;
    private float jumpForce = 5f;

    private ButtonPress LeftBtn, RightBtn, JumpBtn;

    private bool onGround = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        

        LeftBtn = GameObject.Find("LeftBtn").GetComponent<ButtonPress>();
        RightBtn = GameObject.Find("RightBtn").GetComponent<ButtonPress>();
        JumpBtn = GameObject.Find("JumpBtn").GetComponent<ButtonPress>();

        #region error checks
        if (rigidbody == null)
        {
            Debug.Log("no rigidbody on player");
        }
        if (LeftBtn == null)
        {
            Debug.Log("couldn't find left button");
        }
        if (RightBtn == null)
        {
            Debug.Log("couldn't find right button");
        }
        if (JumpBtn == null)
        {
            Debug.Log("couldn't find jump button");
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        /*
        transform.Translate(0, 0, forwardSpeed * Time.deltaTime);

        if (Input.GetKeyDown("a"))
        {
           
        }
        if (Input.GetKeyDown("d"))
        {
            
        }*/

    }

    private void FixedUpdate()
    {
        moveForward();

        //rigidbody.AddForce(0, 0, 2000f * Time.deltaTime);
        
        /*if (Input.GetKey("a") && onGround)
        {
            moveLeft();
        }
        if (Input.GetKey("d") && onGround)
        {
            moveRight();
        }
        if (Input.GetKeyDown("s") && onGround)
        {
            jump();
            Debug.Log("jumping");
        }*/

        if (LeftBtn.buttonPressed && onGround)
        {
            moveLeft();
        }
        if (RightBtn.buttonPressed && onGround)
        {
            moveRight();
        }
        if (JumpBtn.buttonPressed && onGround)
        {
            jump();
        }

    }

    public void moveForward()
    {
        transform.Translate(0, 0, forwardSpeed * Time.deltaTime);

    }

    public void moveLeft()
    {
        rigidbody.AddForce(-sideForce * Time.deltaTime, 0, 0);
    }

    public void moveRight()
    {
        rigidbody.AddForce(sideForce * Time.deltaTime, 0, 0);
    }

    public void jump()
    {
        onGround = false;
        rigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            onGround = true;
        }
    }

}
