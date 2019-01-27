using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkUI : MonoBehaviour
{
    protected float min = 0.9f;
    protected float max = 0.05f;

    protected Image img;

    private void Start()
    {
        img = GetComponent<Image>();

        // See this to clone materials: http://answers.unity.com/answers/1533602/view.html
        img.material = new Material(img.material);
    }

    public void SetCutoff(float value)
    {
        img.material.SetFloat("_Cutoff", Mathf.Lerp(min, max, value));
    }
}
