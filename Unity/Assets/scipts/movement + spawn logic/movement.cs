using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private List<GameObject> points = new List<GameObject>();
    public pointreference pointholder;
    private int currentpoint;
    // Start is called before the first frame update
    void Start()
    {
        pointholder = FindObjectOfType<pointreference>();
        foreach (Transform child in pointholder.transform)
        {
            points.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentpoint < points.Count)
        {
            Vector3 target = points[currentpoint].transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target, 2 * Time.deltaTime);
            if (transform.position == target)
            {
                currentpoint++;
            }
        }
    }
}
