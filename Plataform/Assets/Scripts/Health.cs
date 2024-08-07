using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int healthPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Tocar a anima��o de "explos�o"
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Life>().Heal(healthPoints);
            Destroy(gameObject);
        }

    }
}
