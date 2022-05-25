using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideshowController : MonoBehaviour
{
    public Image slideshowImage;
    public Sprite[] slideshowImages;
    int currentImageIndex = 0;

    float fadeDuration = 1f;

    void Start()
    {
        // slideshowImage.canvasRenderer.SetAlpha(0f);
        slideshowImage.sprite = slideshowImages[currentImageIndex];
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

    void UpdateSlideshowImage()
    {
        slideshowImage.canvasRenderer.SetAlpha(0f);
        slideshowImage.CrossFadeAlpha(1, fadeDuration, false);
        slideshowImage.sprite = slideshowImages[currentImageIndex];
    }
}
