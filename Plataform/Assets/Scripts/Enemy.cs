using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Life life;
    [SerializeField] GameObject coin;
    [SerializeField] Transform dropPoint;
    [SerializeField] GameObject[] drop;
    [SerializeField] GameObject explosionSparks;
    [SerializeField] NextRoom nextRoom;
    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<Life>();
        if (nextRoom)
        {
            nextRoom.enemies++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    private void Death()
    {
        int number = Random.Range(0, drop.Length);
        if (life.GetHealth() <= 0)
        {
            if (nextRoom)
            {
               nextRoom.enemies--;
            }
            if (drop[number] != null)
            {
                Instantiate(drop[number], transform.position, transform.rotation);
            }
            Destroy(gameObject);
            Instantiate(explosionSparks, transform.position, transform.rotation);
        }
    }
}
