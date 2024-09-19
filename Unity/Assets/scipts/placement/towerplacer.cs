using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerplacer : MonoBehaviour
{
    public GameObject placeholder;
    private Queue<Behaviour> queue = new Queue<Behaviour>();
    public static GameObject currentholder;
    private Vector2 mouseposition;
    public static event Action enable;
    private Queue<CircleCollider2D> colliders = new Queue<CircleCollider2D>();
    // Start is called before the first frame update
    void Start()
    {
        towerlock.clicked += scriptenabler;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void towerinstantiator()
    {
        if (currentholder == null)
        {
            currentholder = Instantiate(placeholder);
            foreach (Component component in currentholder.GetComponents<Component>())
            {
                if (component is mousefollower)
                {
                    ((mousefollower)component).enabled = true;
                }
                else if (component is check)
                {
                    ((check)component).enabled = true;
                }
                else if (component is CircleCollider2D)
                {
                    colliders.Enqueue(((CircleCollider2D)component));
                }
                else if (component is Behaviour ) //bitch code that also disables colliders if not handled explicitly AND beforehand (can't use middle finger emoji due to shit encoding, act as if this is a middle finger)
                {
                    queue.Enqueue(component as Behaviour); 
                    ((Behaviour)component).enabled = false;
                }

            }
        }
        enable?.Invoke();
    }
    public void scriptenabler()
    {
        foreach(Behaviour behaviour in queue)
        {
            behaviour.enabled = true;
        }
        foreach(CircleCollider2D collider in colliders)
        {
            collider.enabled = true;
        }
        currentholder = null;
    }
}
