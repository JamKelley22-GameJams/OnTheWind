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
    public float rotationSpeed;
    public float interpToSpeed;
    public Camera camera;
    private Collider collider;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, gravity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float moveForBack = Input.GetAxis("Vertical");
        float moveLeftRight = Input.GetAxis("Horizontal");
        if (moveForBack != 0.0f || moveLeftRight != 0.0f)
        {
            Vector3 dir = new Vector3(0.0f, 0.0f, 0.0f);
            if (moveForBack > 0.0f)
            {
                dir = Camera.main.transform.forward;
            }
            if (moveForBack < 0.0f)
            {
                dir = -Camera.main.transform.forward;
            }
            if (moveLeftRight > 0.0f)
            {
                dir = Camera.main.transform.right;
            }
            if (moveLeftRight < 0.0f)
            {
                dir = -Camera.main.transform.right;
            }
            dir.x = dir.x * speed * Time.deltaTime;
            dir.y = 0.0f;
            dir.z = dir.z * speed * Time.deltaTime;
            Vector3 goTo = new Vector3(this.transform.position.x + dir.x, this.transform.position.y, this.transform.position.z + dir.z);
            Vector3 velocity = new Vector3(Mathf.Clamp(dir.x, -1.0f, 1.0f), 
                                           0.0f, 
                                           Mathf.Clamp(dir.z, -1.0f, 1.0f));
            
            this.transform.position = Vector3.SmoothDamp(this.transform.position,
                                                         goTo, ref velocity, interpToSpeed);
        }
        else
        {
            //Debug.Log("Here");
       
        }
    }
}
