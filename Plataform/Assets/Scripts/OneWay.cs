using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWay : MonoBehaviour
{
    GameObject platform;
    BoxCollider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") < 0 && platform != null)
        {
            StartCoroutine(DisablePlatform());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("One Way Platform"))
        {
            platform = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("One Way Platform"))
        {
            platform = null;
        }
    }
    private IEnumerator DisablePlatform()
    {
        BoxCollider2D platformCollider = platform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.3f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}
