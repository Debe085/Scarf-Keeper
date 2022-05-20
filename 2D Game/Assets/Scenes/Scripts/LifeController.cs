using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    private Slider slider;

    void Start() 
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = 120f;    
    }
    void Update()
    {
        slider.value = player.life;
    }
}
