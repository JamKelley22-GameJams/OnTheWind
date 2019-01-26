using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritMovement : MonoBehaviour
{

    public float gravity;
    public float speed;
    public float interpToSpeed;
    public float jumpForce;
    [Range(0, 2)]
    public float JumpDelay;
    public bool isFalling;
    public bool canJump;

    public Camera camera;
    private Collider collider;
    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        camera = Camera.allCameras[0];
        name = "Spirit";
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(GameObject.Find("Dandelion"), 0.1f);
        if (Input.GetKeyDown("space") && canJump)
        {
            StartCoroutine(Jump());
        }
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < -.1)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
            if (rb.velocity.y == 0.0f)
            {
                canJump = true;
            }
        }
        float moveForBack = Input.GetAxis("Vertical");
        float moveLeftRight = Input.GetAxis("Horizontal");
        if ((moveForBack != 0.0f || moveLeftRight != 0.0f))
        {
            Vector3 dir = new Vector3(0.0f, 0.0f, 0.0f);
            if (moveForBack > 0.0f)
            {
                dir = camera.transform.forward;
            }
            if (moveForBack < 0.0f)
            {
                dir = -camera.transform.forward;
            }
            if (moveLeftRight > 0.0f)
            {
                dir = camera.transform.right;
            }
            if (moveLeftRight < 0.0f)
            {
                dir = -camera.transform.right;
            }
            dir.x = dir.x * speed * Time.deltaTime;
            dir.y = 0.0f;
            dir.z = dir.z * speed * Time.deltaTime;
            transform.position = transform.position + dir * speed * Time.deltaTime;
        }
        rb.AddForce(Vector3.down * gravity);
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(JumpDelay);
        if (canJump)
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false;
        }
    }
}
