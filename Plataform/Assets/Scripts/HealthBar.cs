using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    [SerializeField] Life life;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        SetHealth(life.GetHealth());
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }

}
