using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] GameObject sparks;
    [SerializeField] Transform sparksPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(sparks, sparksPoint.position, transform.rotation);
        Destroy(gameObject);
    }
}
