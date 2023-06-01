using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawingUI : MonoBehaviour
{
    public Image MustangInfo;
    public Image PickupInfo;
    public Image AstonInfo;
    public Image JaguarInfo;
    public Image RSInfo;

    private bool IsMusText = false;
    private bool IsPickupText = false;
    private bool IsRSText = false;
    private bool IsJaguarText = false;
    private bool IsAstonText = false;

    public Camera Cam;

    public Recticles Recticle;

    // Start is called before the first frame update
    void Start()
    {
        MustangInfo.enabled = false;
        PickupInfo.enabled = false;
        RSInfo.enabled = false;
        JaguarInfo.enabled = false;
        AstonInfo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Cam.transform.position, Cam.transform.forward);
        RaycastHit HitInfo;
        if(Physics.Raycast(ray, out HitInfo))
        {
            if(HitInfo.transform.gameObject.CompareTag("Mustang")) // Information about the Mustang GT
            {
                Debug.Log("Detected");
                Recticle.value = 0;
                Recticle.IsActive = true;
                Recticle.RectilePG.enabled = true;
                IsMusText = true;
            }
            else
            {
                if(Recticle.value >= 1 & IsMusText == true)
                {
                    MustangInfo.enabled = true;
                    Invoke("DeleteImage", 4f);
                }
            }

            if (HitInfo.transform.gameObject.CompareTag("Aston")) // Information about the Aston Martin
            {
                Debug.Log("Detected");
                Recticle.value = 0;
                Recticle.IsActive = true;
                Recticle.RectilePG.enabled = true;
                IsAstonText = true;
            }
            else
            {
                if (Recticle.value >= 1 & IsAstonText == true)
                {
                    AstonInfo.enabled = true;
                    Invoke("DeleteImage", 4f);
                }
            }

            if (HitInfo.transform.gameObject.CompareTag("Pickup")) // Information about the Ford Pickup
            {
                Debug.Log("Detected");
                Recticle.value = 0;
                Recticle.IsActive = true;
                Recticle.RectilePG.enabled = true;
                IsPickupText = true;
            }
            else
            {
                if (Recticle.value >= 1 & IsPickupText == true)
                {
                    PickupInfo.enabled = true;
                    Invoke("DeleteImage", 4f);
                }
            }

            if (HitInfo.transform.gameObject.CompareTag("Jaguar")) // Information about the Jaguar SS 100
            {
                Debug.Log("Detected");
                Recticle.value = 0;
                Recticle.IsActive = true;
                Recticle.RectilePG.enabled = true;
                IsJaguarText = true;
            }
            else
            {
                if (Recticle.value >= 1 & IsJaguarText == true)
                {
                    JaguarInfo.enabled = true;
                    Invoke("DeleteImage", 4f);
                }
            }

            if (HitInfo.transform.gameObject.CompareTag("RS")) // Information about the RS Coup
            {
                Debug.Log("Detected");
                Recticle.value = 0;
                Recticle.IsActive = true;
                Recticle.RectilePG.enabled = true;
                IsRSText = true;
            }
            else
            {
                if (Recticle.value >= 1 & IsRSText == true)
                {
                    RSInfo.enabled = true;
                    Invoke("DeleteImage", 4f);
                }
            }
        }
        else
        {
            Recticle.IsActive = false;
            Recticle.RectilePG.enabled = false;
        }
    }

    public void DeleteImage()
    {
        MustangInfo.enabled = false;
        PickupInfo.enabled = false;
        RSInfo.enabled = false;
        JaguarInfo.enabled = false;
        AstonInfo.enabled = false;
    }

}
