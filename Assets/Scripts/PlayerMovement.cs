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

    public float speed = 1; // speed in meters per second

    public AudioClip jumpsfx;
    public AudioClip cutsfx;
    private AudioSource source;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

    }

    void Awake()
    {

        source = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collide)
	{
		if (collide.gameObject.tag == "obstacle")
		{
            Invoke("ChangeLevel", 0.3f); //delays respawn for "cut" sfx

            source.PlayOneShot(cutsfx);
        }

        if (collide.gameObject.tag == "end")
        {
            Application.LoadLevel("stagev");
        }
    }

    void ChangeLevel()
    {
        Application.LoadLevel("stage1");
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

            source.PlayOneShot(jumpsfx);
        }
	    
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        Vector3 moveDir = Vector3.zero;
       // moveDir.x = Input.GetAxis("Horizontal"); // get result of AD keys in X
        moveDir.z = Input.GetAxis("Vertical"); // get result of WS keys in Z
                                               // move this object at frame rate independent speed:
        transform.position += moveDir * speed * Time.deltaTime;

    }
}
