using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject panel;
    public GameObject menu;
    private GameObject Mustang;
    private GameObject FordPickup;
    private GameObject RSCoup;
    private GameObject Jaguar;
    private GameObject AstonMartin;
    

    public Spawn spawnCar;

    private bool isSpawned;

    public SpawingUI spawingUI;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        panel.SetActive(true);
        isSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Close()
    {
        menu.SetActive(true);
        panel.SetActive(false);
    }

    public void Open()
    {
        menu.SetActive(false);
        panel.SetActive(true);
    }

    public void DeleteCars()
    {
        Mustang = GameObject.FindGameObjectWithTag("Mustang");
        Destroy(Mustang);
        spawingUI.MustangInfo.enabled = false;

        FordPickup = GameObject.FindGameObjectWithTag("Pickup");
        Destroy(FordPickup);
        spawingUI.PickupInfo.enabled = false;

        AstonMartin = GameObject.FindGameObjectWithTag("Aston");
        Destroy(AstonMartin);
        spawingUI.AstonInfo.enabled = false;

        Jaguar = GameObject.FindGameObjectWithTag("Jaguar");
        Destroy(Jaguar);
        spawingUI.JaguarInfo.enabled = false;

        RSCoup = GameObject.FindGameObjectWithTag("RS");
        Destroy(RSCoup);
        spawingUI.RSInfo.enabled = false;
    }
}
