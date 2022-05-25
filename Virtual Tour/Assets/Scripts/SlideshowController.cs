using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideshowController : MonoBehaviour
{
    [SerializeField] Image slideshowImage;
    [SerializeField] Button slideshowButton;
    [SerializeField] GameObject slideshowPanel;

    Sprite[] slideshowImages;
    int currentImageIndex = 0;
    float slideshowFadeDuration = 0.8f;

    // TODO: figure out if I can merge awake and start
    void Awake()
    {
        TourManager.onLocationSphereChanged += UpdateSlideshowSystem;
    }

    void UpdateSlideshowSystem(GameObject currentLocationSphere)
    {
        // gets the slideshow images from locationSphereData
        slideshowImages = currentLocationSphere.GetComponent<LocationSphereData>().slideshowImages;

        if (slideshowImages.Length > 0)
        {
            slideshowButton.gameObject.SetActive(true);

            slideshowImage.sprite = slideshowImages[currentImageIndex];
        }        
        else
        {
            slideshowButton.gameObject.SetActive(false);
        }
    }

    public void SelectNextImage()
    {
            currentImageIndex++;
            // wraps around to the first array index
            if (currentImageIndex >= slideshowImages.Length)
            {
                currentImageIndex = 0;
            }
            UpdateSlideshowImage();
    }

    public void SelectPreviousImage()
    {
        currentImageIndex--;
            // wraps around to the last array index
            if (currentImageIndex < 0)
            {
                currentImageIndex = slideshowImages.Length - 1;
            }
            UpdateSlideshowImage();
    }

    public void ShowSlideshowPanel()
    {
        slideshowPanel.SetActive(true);
    }

    public void HideSlideshowPanel()
    {
        slideshowPanel.SetActive(false);
    }

    // transitions to the next selected slideshow image
    void UpdateSlideshowImage()
    {
        slideshowImage.canvasRenderer.SetAlpha(0f);
        slideshowImage.CrossFadeAlpha(1, slideshowFadeDuration, false);
        slideshowImage.sprite = slideshowImages[currentImageIndex];
    }
}
