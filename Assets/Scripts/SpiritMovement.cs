using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritMovement : MonoBehaviour
{

    public float gravity;
    public float speed;
    public float maxSpeed;
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
        camera = Camera.allCameras[0];
        name = "Spirit";
        Physics.gravity = new Vector3(0.0f, gravity, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(GameObject.Find("Dandelion"), 0.1f);
        if (Input.GetKeyDown("space") && canJump)
        {
            StartCoroutine(Jump());
        }
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f, layerMask))
        {
            canJump = true;
        } else
        {
            canJump = false;
        }
        Debug.Log(1 / Time.deltaTime);
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
            rb.AddForce(dir);
            Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
            Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed);
        }
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
