using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Vector3 velocity;
    public static int movespeed = 1;
    public Vector3 userDirection = Vector3.right;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;


    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

    }


    void OnCollisionStay()
    {

        isGrounded = true;

    }

    // Update is called once per frame
    void Update () {

        //transform.position += Vector3.right * Time.deltaTime;


        transform.Translate(userDirection * movespeed * Time.deltaTime);

        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }
}
