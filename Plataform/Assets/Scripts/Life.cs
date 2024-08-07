using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] int health;
    public bool isVunerable;
    [SerializeField] float timeInvunerable;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float flickTime;
    Color originalColor;
    [SerializeField] Color hitColor;
    [SerializeField] float colorTime;
    [SerializeField] Vector2 scale;
    Vector2 originalScale;

    [Header("Audio")]
    [SerializeField] AudioClip takingDamageSFX;

    // Start is called before the first frame update
    void Start()
    {
        isVunerable = true;
        originalColor = sprite.color;
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int value)
    {
        if (!isVunerable)
        {
            return;
        }
        health -= value;
        if(colorTime >= 0)
        {
            StartCoroutine(ColorChange());
            StartCoroutine(ChangeScale());
        }
        if (timeInvunerable > 0)
        {
            StartCoroutine(DamageCooldown());    
            StartCoroutine(Flickering());
            isVunerable = false;
        }
    }
    public void Heal(int value)
    {
        health += value;
    }
    public int GetHealth()
    {
        return health;
    }
    IEnumerator DamageCooldown()
    {
        AudioSource.PlayClipAtPoint(takingDamageSFX, FindObjectOfType<Camera>().transform.position);
        yield return new WaitForSeconds(timeInvunerable);
        isVunerable = true;
    }
    IEnumerator Flickering()
    {
        yield return new WaitForSeconds(colorTime);
        float alpha = -1;
        while (!isVunerable)
        {
            sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a + alpha);
            alpha *= -1;
            yield return new WaitForSeconds(flickTime);
        }
        sprite.color = originalColor;
    }
    IEnumerator ColorChange()
    { 
        sprite.color = hitColor;
        yield return new WaitForSeconds(colorTime);
        sprite.color = originalColor;
    }
    IEnumerator ChangeScale()
    {
        sprite.transform.localScale = scale;
        yield return new WaitForSeconds(colorTime);
        sprite.transform.localScale = originalScale;
    }
}

