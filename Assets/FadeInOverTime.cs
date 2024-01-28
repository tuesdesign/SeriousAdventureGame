using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FadeInOverTime : MonoBehaviour
{
    public PostProcessVolume volume;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float duration = 1.5f; // duration of the fade in seconds
        float currentTime = 0.0f;

        while (currentTime < duration)
        {
            float weight = 1 - (currentTime / duration);
            volume.weight = weight;
            currentTime += Time.deltaTime;
            yield return null;
        }

        volume.weight = 0f; // ensure the weight is set to 0 at the end
    }
}