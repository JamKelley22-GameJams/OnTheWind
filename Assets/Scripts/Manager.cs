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
    public float dayTimer;

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
        dayTimer = dayTimer - Time.deltaTime;
        if (dayTimer < 0)
        {
            if (GameObject.Find("Dandelion"))
            {
                Destroy(GameObject.Find("Dandelion"), 0.1f);
                var newDandelion = (GameObject)Instantiate(dandelionPrefab, new Vector3(0.0f, 0.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                newDandelion.name = "Dandelion";
            }
            else
            {
                GameObject sapling = GameObject.Find("Sapling(Clone)");
                GameObject spirit = GameObject.Find("Spirit");
                Destroy(spirit, 0.0f);
                Vector3 saplingPos = sapling.transform.position;
                saplingPos.y = saplingPos.y + numWateringCans; 
                var newDandelion = (GameObject)Instantiate(dandelionPrefab, saplingPos, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                newDandelion.name = "Dandelion";
                Destroy(sapling, 0.1f);
            }
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