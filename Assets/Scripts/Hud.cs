using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Text PunText;

    public List<MilkUI> milks = new List<MilkUI>();

    void Start()
    {
        if(milks.Count == 0)
        {
            milks = new List<MilkUI>(GetComponentsInChildren<MilkUI>());
        }

        float initialWaitTime = 1.0f;
        float cycleTime = 20.0f;
        InvokeRepeating("ShowPun", initialWaitTime, cycleTime);
    }

    void Update()
    {
        float totalMilk = GameState.Energy;

        for(int i = 0; i < milks.Count; i++)
        {
            milks[i].SetCutoff(Mathf.Clamp01(totalMilk / 10f));
            totalMilk -= 10f;
            milks[i].transform.parent.gameObject.SetActive(GameState.TotalMilkBottles + GameState.NewMilkBottles > i);
        }
    }

    void ShowPun() {
        Debug.Log("new pun");
        PunText.text = CowPuns.GetRandomPun();
    }
}
