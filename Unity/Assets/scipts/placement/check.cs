using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    public static check Instance { get; private set; }
    public static bool allowed = false;
    private bool extracheck = false;
    private HashSet<Collider2D> colliders = new HashSet<Collider2D>();
    // Start is called before the first frame update
    void Start()
    {
        Instance = this; //setting a static instance for easy reference, allowed because singleton
        towerlock.clicked += destroybehaviour;
        Debug.Log(Instance.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "tower" && collision is CircleCollider2D)
        {
            CircleCollider2D circle = collision as CircleCollider2D;
            if (circle.radius < 0.75f)
            {
                allowed = false;
                Debug.Log("placement not allowed");
                extracheck = true;
            }
        }
        if (collision.tag == "placeable" && extracheck != true)
        {
            allowed = true;
            colliders.Add(collision);
            Debug.Log("placement allowed");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "tower" && collision is CircleCollider2D)
        {
            CircleCollider2D circle = collision as CircleCollider2D;
            if (circle.radius <= 0.75f && colliders.Count > 0)
            {
                extracheck = false;
                allowed = true; 
            }
            else if (circle.radius < 0.75f)
            {
                extracheck = false;
            }
            
        }
        if (collision.tag == "placeable")
        {
            colliders.Remove(collision);
            if (colliders.Count == 0)
            {
                allowed = false;
                Debug.Log("placement not allowed");
            }

        }
    }
    internal void destroybehaviour()
    {
        Destroy(Instance);
        Instance = null;
        towerlock.clicked -= destroybehaviour;
    }
}
