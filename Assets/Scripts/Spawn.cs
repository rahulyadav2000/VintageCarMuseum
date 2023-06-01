using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using GoogleARCore;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    private Transform currentObject;

    public Camera FPCamera;
    
    public GameObject plane;
    public GameObject spawnedVehicle;
    private GameObject spawnedObject;

    private bool isSpawned;

    public Text detectedPlanes;
    public Text vechile;
    public Text musCar;

    private Ray ray;
    private RaycastHit Hitinfo;

    public Slider slider;

    private float previousValue;

    public List<DetectedPlane> Planes = new List<DetectedPlane>();
    // Start is called before the first frame update

    private void Awake()
    {
        this.slider.onValueChanged.AddListener(this.OnSliderChanged);

        this.previousValue = this.slider.value;
    }

    void Start()
    {
        currentObject = null;
        ray = new Ray(FPCamera.transform.position, FPCamera.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {

        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }
        Session.GetTrackables<DetectedPlane>(Planes, TrackableQueryFilter.All);
        //Debug.Log(Planes.Count);
        detectedPlanes.text = "Planes : " + Planes.Count.ToString();

        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        }
        if ((Input.touchCount > 0) && ((touch = Input.GetTouch(0)).phase == TouchPhase.Began))
        {
            TrackableHit hit;
            TrackableHitFlags flags = TrackableHitFlags.PlaneWithinPolygon;

            if (Frame.Raycast(touch.position.x, touch.position.y, flags, out hit))
            {
                if (!isSpawned &&(hit.Trackable is DetectedPlane) && Vector3.Dot(FPCamera.transform.position - hit.Pose.position, hit.Pose.rotation * Vector3.up*2) > 0)
                {
                    //DetectedPlane plane = hit.Trackable as DetectedPlane;
                    spawnedObject = Instantiate(plane, hit.Pose.forward, hit.Pose.rotation);
                    spawnedObject.transform.position += new Vector3(0, -5, 10);
                    var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                    spawnedObject.transform.parent = anchor.transform;
                    vechile.text = "Spawned Plane : " + spawnedObject.ToString();
                    isSpawned = true;
                }
            }
        }   
    }
    
    public void RenderCar(GameObject carModel)
    {
        var go = Instantiate(carModel) as GameObject;
        carModel.transform.position = spawnedObject.transform.position + Vector3.up;
        musCar.text = "CarModel " + carModel.ToString();
    }

    public void OnSliderChanged(float value)
    {
        float delta = value - this.previousValue;
        this.spawnedObject.transform.Rotate(Vector3.up * delta * 360);
        this.previousValue = value;
    }
}