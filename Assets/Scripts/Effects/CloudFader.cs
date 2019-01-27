using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFader : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        CloudFades.Instance.faders.Add(this);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Fade(float alpha)
    {
        Color col = spriteRenderer.color;
        col.a = alpha;

        spriteRenderer.color = col;
    }
}
