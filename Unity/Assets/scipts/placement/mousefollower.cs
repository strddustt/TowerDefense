using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousefollower : MonoBehaviour
{
    private Vector2 mouseposition;
    // Start is called before the first frame update
    void Start()
    {
        towerlock.clicked += destroyaction;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouseposition = Input.mousePosition;
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
        transform.position = mouseposition;
    }
    private void destroyaction()
    {
        Destroy(this);
    }
}
