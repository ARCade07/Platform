using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPatrol : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float rayLenght;
    [SerializeField] LayerMask groundLayer;
    bool isGoingRight;
    bool holeAhead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HoleCheck();
        Patroling();
    }
    private void Patroling()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    private void HoleCheck()
    {
        Debug.DrawRay(rayOrigin.position, Vector2.down * rayLenght, Color.red);
        if (Physics2D.Raycast(rayOrigin.position, Vector2.down, rayLenght, groundLayer).collider == null)
        {
            transform.Rotate(0, 180, 0);
        }
    }
}

