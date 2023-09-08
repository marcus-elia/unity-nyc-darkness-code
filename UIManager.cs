using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static bool IsPaused = true;

    public GameObject pauseMenuUI;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject uiLight;
    private int pageNumber = 0;

    public AudioSource audioSource;
    public AudioClip bg;
    public Slider audioSlider;

    void Start()
    {
        Pause();
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        audioSource.clip = bg;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        audioSource.volume = audioSlider.value;
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (!IsPaused)
            {
                Pause();
            }
        }
    }

    public void NextPage()
    {
        pageNumber++;
        if (pageNumber == 5)
        {
            pageNumber = 1;
        }
        if (pageNumber == 1)
        {
            page1.SetActive(true);
            page4.SetActive(false);
        } else if (pageNumber == 2)
        {
            page2.SetActive(true);
            page1.SetActive(false);
        }
        else if (pageNumber == 3)
        {
            page3.SetActive(true);
            page2.SetActive(false);
        } else
        {
            page4.SetActive(true);
            page3.SetActive(false);
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        uiLight.SetActive(false);
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        uiLight.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
