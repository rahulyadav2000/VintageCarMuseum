using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recticles : MonoBehaviour
{
    public float value = 0f;
    public float duration = 1f;
    public Image RectilePG;

    public bool IsActive = true;
    // Start is called before the first frame update
    void Start()
    {
        RectilePG = GetComponent<Image>();
        RectilePG.fillAmount = 0;
        RectilePG.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsActive)
        {
            RectilePG.enabled = true;
            value += Time.deltaTime / duration;
            RectilePG.fillAmount = value; 
        }

        if (value >= 1)
        {
            RectilePG.enabled = false;
            IsActive = false;
        }
    }
}
