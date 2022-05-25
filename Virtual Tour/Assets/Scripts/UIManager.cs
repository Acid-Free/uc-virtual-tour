using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}

    [SerializeField] GameObject leftPanel;
    [SerializeField] GameObject rightButtonsPanel;
    [SerializeField] GameObject slideshowPanel;
    [SerializeField] GameObject descriptionPanel;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        leftPanel.SetActive(true);
        rightButtonsPanel.SetActive(true);
    }

    public void ShowSlideshowPanel()
    {
        slideshowPanel.SetActive(true);
    }

    public void HideSlideshowPanel()
    {
        slideshowPanel.SetActive(false);
    }
}
