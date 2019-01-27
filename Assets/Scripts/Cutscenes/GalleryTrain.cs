using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryTrain : MonoBehaviour
{
    public float speed = 2f;

    public float duration = 60f;

    public IEnumerator MoveRight()
    {
        float t = 0f;

        while(t < duration)
        {
            t += Time.deltaTime;

            transform.position = transform.position + Time.deltaTime * speed * Vector3.right;

            yield return null;
        }


        SceneManager.LoadScene(0);

        yield break;
    }
}
