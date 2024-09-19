using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class towerlock : MonoBehaviour
{
    private check placementcheck;
    private towerplacer queue;
    public static event Action clicked;
    private Collider2D boxcollider;
    LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("mapplacement");
        boxcollider = GetComponent<Collider2D>();
        towerplacer.enable += enablecollider;
        boxcollider.enabled = false;
        clicked += disablecollider;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            if (check.allowed == true)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition, layerMask);
                if (hitCollider.CompareTag("placeable"))
                {
                    clicked?.Invoke();
                    Debug.Log("invoked clicked");
                    boxcollider.enabled = false;
                }
            }
        } 
    }
    private void enablecollider() //delay enabling collider to prevent issues
    {
        boxcollider.enabled = true;
    }
    private void disablecollider()
    {
        boxcollider.enabled = false;
    }
}
