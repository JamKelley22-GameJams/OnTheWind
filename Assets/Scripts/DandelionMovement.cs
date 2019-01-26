using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionMovement : MonoBehaviour
{
    public float yaw;
    public float pitch;
    public float roll;
    public float x;
    public float y;
    public float z;
    public float gravity;
    public float speed;
    public float slerpSpeed;
    public float returnToSpeed;
    public float rotationSpeed;
    public float maxRotation;
    public float interpToSpeed;
    public int numSteps;

    public bool isFalling;

    public Camera camera;
    private Collider collider;
    private Rigidbody rb;
    public GameObject saplingPrefab;
    public GameObject spiritPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        rb.freezeRotation = true;
        Physics.gravity = new Vector3(0.0f, gravity, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnSapling();
        }
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < -.1)
        {
            isFalling = true;
        } else
        {
            isFalling = false;
        }
        float moveForBack = Input.GetAxis("Vertical");
        float moveLeftRight = Input.GetAxis("Horizontal");
        if ((moveForBack != 0.0f || moveLeftRight != 0.0f) && numSteps > 0)
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
            Vector3 goTo = new Vector3(this.transform.position.x + dir.x, this.transform.position.y, this.transform.position.z + dir.z);
            Vector3 velocity = new Vector3(Mathf.Clamp(dir.x, -1.0f, 1.0f), 
                                           0.0f, 
                                           Mathf.Clamp(dir.z, -1.0f, 1.0f));
            
            transform.position = Vector3.SmoothDamp(this.transform.position,
                                                     goTo, ref velocity, interpToSpeed);
            float tiltAroundX = Mathf.Clamp(this.transform.rotation.x + (dir.z * rotationSpeed * maxRotation), -maxRotation, maxRotation);
            float tiltAroundZ = Mathf.Clamp(this.transform.rotation.z - (dir.x * rotationSpeed * maxRotation), -maxRotation, maxRotation);
            Quaternion rotation = Quaternion.Euler(tiltAroundX, 0.0f, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, slerpSpeed);
            if (!isFalling)
            {
                numSteps--;
            }
        }
        else
        {
            //Debug.Log("Here");
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.identity, returnToSpeed);
        }

    }

    void SpawnSapling()
    {
        if (!isFalling)
        {
            this.collider.enabled = false;
            var spirit = (GameObject) Instantiate(spiritPrefab, transform.position + new Vector3(2.0f, 0.0f, 2.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            var sapling = (GameObject) Instantiate(saplingPrefab, transform.position + new Vector3(-1.0f, 0.0f, -1.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            Destroy(this, 0.0f);
        }
    }
}
