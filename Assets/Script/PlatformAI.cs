using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAI : MonoBehaviour
{
    public List<Transform> points;

    public float range, speed = 8;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);

        print(index);
        if (Vector2.Distance(transform.position, points[index].position) <= range)
        {
            index++;
        }
    }
}
