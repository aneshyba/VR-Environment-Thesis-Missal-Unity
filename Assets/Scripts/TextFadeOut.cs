using System.Collections;
using UnityEngine;
using UnityEngine.UI;

class TextFadeOut : MonoBehaviour
{
    //Fade time in seconds
    public GameObject textGO; 
    public float fadeOutTime;

    // private start time
    private int startTime;

    public void Start()
    {
        startTime = System.DateTime.Now.Second; 
    }


    public void Update()
    {
        int timeDiff = System.DateTime.Now.Second - startTime;
        if (timeDiff > 5 && timeDiff < 10)
        {
            FadeOut();
        } 


    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator FadeOutRoutine()
    {
        TextMesh text = textGO.GetComponent<TextMesh>();
        Color originalColor = text.color;
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
    }
}