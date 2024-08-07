using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform max;
    [SerializeField] Transform min;
    float xMax;
    float xMin;
    [SerializeField] float speed;
    bool isGoingRight;
    // Start is called before the first frame update
    void Start()
    {
        isGoingRight = true;
        xMax = max.position.x;
        xMin = min.position.x;
    }

    // Update is called once per frame
    void Update()
    {            
        Patroling();
    }
    private void Patroling()
    {
        if (isGoingRight)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if(transform.position.x >= xMax && isGoingRight == true)
        {
            transform.Rotate(0, 180, 0);
            isGoingRight = false;
        }
        if(transform.position.x <= xMin && isGoingRight == false)
        {
            transform.Rotate(0, 180, 0);
            isGoingRight = true;
        }
    }
}
