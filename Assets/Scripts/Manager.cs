using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int originalDayTimer;
    public int dayTimer;
    public GameObject Dandelion;
    public GameObject dandelionPrefab;
    public GameObject Sapling;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        dayTimer--;
        if (dayTimer < 0)
        {
            Dandelion = GameObject.Find("Dandelion");
            Sapling = GameObject.Find("Sapling(Clone)");
            Vector3 saplingPosition = Sapling.transform.position;
            Destroy(Sapling);
            Dandelion.transform.position = saplingPosition;
            dayTimer = originalDayTimer;
        }
    }
}
