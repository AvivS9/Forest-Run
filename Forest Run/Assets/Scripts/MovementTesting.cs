using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTesting : MonoBehaviour
{
    public float forwardSpeed = 10f;
    private Rigidbody rigidbody;
    private float sideForce = 8f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();


       
        #region error checks
        if (rigidbody == null)
        {
            Debug.Log("no rigidbody on player");
        }
       
        #endregion
    }

 

    private void FixedUpdate()
    {
        transform.Translate(0, 0, forwardSpeed * Time.deltaTime);

        //rigidbody.AddForce(0, 0, 2000f * Time.deltaTime);

        if (Input.GetKey("a"))
        {
            transform.Translate(-sideForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(sideForce * Time.deltaTime, 0, 0);
        }




    }



   
   
}
