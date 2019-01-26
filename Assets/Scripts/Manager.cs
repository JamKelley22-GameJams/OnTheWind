using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager _instance;
    public static Manager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    public int originalDayTimer;
    public int dayTimer;

    public int numWateringCans;

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

    public void addItem(ItemType i)
    {
        switch (i)
        {
            case 0:
                numWateringCans++;
                break;
        }
    }
}

public enum ItemType {
    wateringCan
}

public class Item
{
    public ItemType itemType;
}