using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class FadeAnimation : MonoBehaviour
{
    private Image image;
    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private float duration = 1f;

    private void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeAsync());
    }

    private IEnumerator FadeAsync()
    {
        if (image != null)
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float normalizedTime = elapsedTime / duration;
                float alpha = speedCurve.Evaluate(normalizedTime);

                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

                elapsedTime += Time.deltaTime;

                yield return 0;
            }
        }
    }
}
