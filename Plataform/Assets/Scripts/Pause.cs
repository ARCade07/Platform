using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    bool ispaused;

    // Start is called before the first frame update
    void Start()
    {
        ispaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !ispaused)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispaused)
        {
            DespauseGame();
        }
    }

    public void PauseGame()
    {
        Panel.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }
    public void DespauseGame()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }

}
