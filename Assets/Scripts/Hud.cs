using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Text EnergyText;

    void Update()
    {
        EnergyText.text = GameState.Energy.ToString();
    }
}
