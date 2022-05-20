using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagazineController : MonoBehaviour
{
    [SerializeField] float maxAmmo = 6;
    [SerializeField] EyeBeam eyeBeam;

    private TextMeshProUGUI magText;
    private float currentAmmo;

    void Start()
    {
        magText = gameObject.GetComponent<TextMeshProUGUI>();

        magText.text = maxAmmo + " / " + maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        currentAmmo = eyeBeam.magazine;

        CheckText();
    }

    void CheckText()
    {
        if (currentAmmo >= 0)
        {
            magText.text = currentAmmo + " / " + maxAmmo;
        } else
        {
            magText.text = "^ 3 ^";
        }
        
    }
}
