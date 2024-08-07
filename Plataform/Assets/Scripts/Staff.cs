using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField] Transform aim;
    Player player;
    
    [Header("Shooting")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;

    Vector3 screenPos;
    Vector3 worldPos;

    bool reloading;
    [SerializeField] float reloadingTime;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        reloading = false;
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        screenPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        aim.position = new Vector3(worldPos.x, worldPos.y, 0);
        if(player.isDead == false)
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        if (Input.GetButtonDown("Fire1") && reloading == false)
        {
            Vector2 dir = aim.position - firePoint.position;
            float angle = Vector2.Angle(Vector2.right, dir);
            if (dir.y < 0)
            {
                angle = -angle;
            }
            firePoint.eulerAngles = new Vector3(0, 0, angle);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            StartCoroutine(Reloading());
        }
    }
    IEnumerator Reloading()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadingTime);
        reloading = false;
    }
}
