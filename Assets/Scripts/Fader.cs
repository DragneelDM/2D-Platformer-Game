using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

public class Fader : MonoBehaviour
{
    Image image;
    [SerializeField] AnimationCurve speedCurve;
    [SerializeField] float duration = 1f;

    void Start()
    {
        image = GetComponent<Image>();
        FadeAsync();
    }

    async void FadeAsync()
    {
        if (image != null)
        {
            float elapsedTime = 0f;
            // Get the Damn Timing
            while (elapsedTime < duration)
            {
                // Calculate 0 to 1
                float normalizedTime = elapsedTime / duration;
                // Associate The Value to the Curve
                float alpha = speedCurve.Evaluate(normalizedTime);

                // Assign Color
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

                // Increase Time
                elapsedTime += Time.deltaTime;
                // Allows other tasks to run in between frames
                await Task.Yield();
            }
        }
    }
}
