using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public GameObject EnergySlider;
    public Text PunText;

    void Start()
    {
        float initialWaitTime = 1.0f;
        float cycleTime = 20.0f;
        InvokeRepeating("ShowPun", initialWaitTime, cycleTime);
    }

    void Update()
    {
        Slider energySlider = EnergySlider.GetComponent<Slider>();
        energySlider.maxValue = GameState.MaxEnergy;
        energySlider.value = GameState.Energy;

        RectTransform sliderTransform = EnergySlider.GetComponent<RectTransform>();
        sliderTransform.sizeDelta = new Vector2(sliderTransform.sizeDelta.x, GameState.MaxEnergy * 6);
    }

    void ShowPun() {
        Debug.Log("new pun");
        PunText.text = CowPuns.GetRandomPun();
    }
}
