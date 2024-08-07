using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourette : MonoBehaviour
{
    bool isFiring;
    [SerializeField] int numberOfShots;
    [SerializeField] float cooldown;
    [SerializeField] float fireRate;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootingCoRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator ShootingCoRoutine()
    {
        while (true)
        {
            for(int i = 0; i < numberOfShots; i++)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                yield return new WaitForSeconds(fireRate);

            }

            yield return new WaitForSeconds(cooldown);
        }
    }
}
