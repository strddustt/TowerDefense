using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class manualspawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onclick()
    {
        Instantiate(prefab, spawn.transform);   
    }
}
