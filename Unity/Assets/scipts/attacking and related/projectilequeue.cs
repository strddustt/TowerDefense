using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class projectilequeue : MonoBehaviour
{
    public GameObject prefag;
    [SerializeField] internal Queue<GameObject> queue = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++) 
        {
            Instantiator();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Instantiator()
    {
        GameObject projectile = Instantiate(prefag, transform);
        queue.Enqueue(projectile);
    }
    internal void Remove() //use when needing a projectile
    {
        GameObject projectile = queue.Dequeue();
        projectile.SetActive(true);
    }
    internal void Add(GameObject projectile, Transform towerposition) //use at end of projectiles life to add it to the pool
    {
        queue.Enqueue(projectile);
        projectile.transform.position = towerposition.position;
        projectile.SetActive(false);
    }
}
