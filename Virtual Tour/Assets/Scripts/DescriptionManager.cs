using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    [SerializeField] Button descriptionButton;

    void Awake()
    {
        TourManager.onLocationSphereChanged += InitializeDescriptionSystem;
    }

    void InitializeDescriptionSystem(GameObject currentLocationSphere)
    {


        // makes sure that the entry was filled out, if not, the overlay button will not be shown
        if (currentLocationSphere.GetComponent<LocationSphereData>().locationDescription.Length > 0)
        {
            descriptionButton.gameObject.SetActive(true);

            string locationName = currentLocationSphere.GetComponent<LocationSphereData>().locationName;
            string locationDescription = currentLocationSphere.GetComponent<LocationSphereData>().locationDescription;
            UIManager.Instance.InitializeDescriptionData(locationName, locationDescription);
        }
        else
        {
            descriptionButton.gameObject.SetActive(false);
        }
    }
}
