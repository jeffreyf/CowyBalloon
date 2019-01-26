using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Text EnergyText;
    public Text PunText;

    void Start()
    {
        float initialWaitTime = 1.0f;
        float cycleTime = 20.0f;
        InvokeRepeating("ShowPun", initialWaitTime, cycleTime);
    }

    void Update()
    {
        EnergyText.text = ((int)GameState.Energy).ToString();
    }

    void ShowPun() {
        Debug.Log("new pun");
        PunText.text = CowPuns.GetRandomPun();
    }
}
