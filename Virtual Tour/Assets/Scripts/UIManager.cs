using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get; private set;}

    [SerializeField] GameObject leftPanel;
    [SerializeField] GameObject rightButtonsPanel;
    [SerializeField] GameObject slideshowPanel;
    [SerializeField] GameObject descriptionPanel;

    [SerializeField] Button audioButton;
    [SerializeField] Sprite nonMuteSprite;
    [SerializeField] Sprite muteSprite;

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

        setAudioButtonSprite();        
    }

    // sets audio button sprite based on mute state
    void setAudioButtonSprite()
    {
        if (AudioManager.Instance.isAudioMuted)
        {
            audioButton.image.sprite = muteSprite;
        }
        else
        {
            audioButton.image.sprite = nonMuteSprite;
        }
    }

    public void ShowSlideshowPanel()
    {
        slideshowPanel.SetActive(true);
    }

    public void HideSlideshowPanel()
    {
        slideshowPanel.SetActive(false);
    }

    public void ToggleAudioButton()
    {
        // TODO: refactor if possible
        // reverses the mute state
        AudioManager.Instance.ToggleMute();
        setAudioButtonSprite();
    }
}
