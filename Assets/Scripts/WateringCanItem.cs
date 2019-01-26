using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Spirit")
        {
            Manager.Instance.addItem(0);
            Debug.Log(Manager.Instance.numWateringCans);
            Destroy(this.gameObject, 0.1f);
        }
    }
}
