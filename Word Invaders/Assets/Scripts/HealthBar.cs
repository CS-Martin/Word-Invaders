using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
     /// <Note> Will be used for HealthBar calculation
    public Slider slider;

    public void Start() {
        SetMaxHealth(100);
    }

    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health) {
        slider.value = health; 
        if(health == 0) {
            //deads
            Debug.Log("Deads kana");
        }
    }
}
