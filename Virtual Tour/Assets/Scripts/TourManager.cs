using System;
using System.Collections;
using UnityEngine;

// TODO: null safety!
public class TourManager : MonoBehaviour
{
    public static TourManager Instance {get; private set;}
    public GameObject[] locationSpheres;
    [SerializeField] int initialLocationSphereIndex;

    public static event Action<GameObject> onLocationSphereChanged;

    // Note: Inconsistent; if I make this public, there would be no point in sending a game object from the event
    GameObject currentLocationSphere;
    GameObject previousLocationSphere;

    [SerializeField] GameObject transitionSphere;
    [SerializeField] float transitionDuration = 1f;

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
        LoadInitialSite();
    }
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.gameObject.tag == "Move")
                {
                    LoadSite(hit.transform.gameObject.GetComponent<MoveLocation>().GetLocationIndex());
                }
                if (hit.transform.gameObject.tag == "Description")
                {
                    UIManager.Instance.ToggleDescriptionPanel();
                }
            }
        }
    }

    void LoadInitialSite()
    {
        HideAllSites();

        // assign the current location sphere
        currentLocationSphere = locationSpheres[initialLocationSphereIndex];
        
        LoadLocationSphereData();

        // show selected location
        currentLocationSphere.SetActive(true);
        // call event 
        onLocationSphereChanged?.Invoke(currentLocationSphere);
    }
 
    public void LoadSite(int locationIndex)
    {
        // before loading the new site, keep reference of the previous one
        previousLocationSphere = currentLocationSphere;
        previousLocationSphere.SetActive(false);

        // assign the current location sphere
        currentLocationSphere = locationSpheres[locationIndex];

        LoadLocationSphereData();
        StartCoroutine(StartTransition());
    }

    IEnumerator StartTransition()
    {

        // animating transition sphere
        transitionSphere.SetActive(true);
        Material material = transitionSphere.GetComponent<Renderer>().material;
        Renderer renderer = transitionSphere.GetComponent<Renderer>();

        // animation 1: black to white
        Color color = material.color;
        float frameTime = Time.deltaTime;
        for (float i = 0; i < transitionDuration; i += frameTime)
        {
            frameTime = Time.deltaTime;

            color.r = color.g = color.b = i / transitionDuration;
            material.color = color;
            Debug.Log(color.a);

            yield return new WaitForSeconds(frameTime);
        }
        transitionSphere.SetActive(false);

        // show selected location
        currentLocationSphere.SetActive(true);
        // call event 
        onLocationSphereChanged?.Invoke(currentLocationSphere);
    }

    void LoadLocationSphereData()
    {
        Vector3 defaultLookRotation = currentLocationSphere.GetComponent<LocationSphereData>().lookRotation;
        float defaultFieldOfView = currentLocationSphere.GetComponent<LocationSphereData>().fieldOfView;

        Camera.main.GetComponent<CameraController>().ResetCamera(defaultLookRotation, defaultFieldOfView);
    }

    // TODO: deprecate? If so, replace int indexes with gameobject references
    void HideAllSites()
    {
        foreach (GameObject locationSphere in locationSpheres)
        {
            locationSphere.SetActive(false);
        }
    }
}
