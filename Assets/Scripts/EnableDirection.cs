using UnityEngine;

public class EnableDirection : MonoBehaviour
{
    GameObject KeyGuide;

    private void Start() {
        KeyGuide = transform.GetChild(0).gameObject;
    }

    private void OnTriggerStay2D(Collider2D other) {
        KeyGuide.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        KeyGuide.SetActive(false);
    }

    public void KeyTaken(){
        KeyGuide.SetActive(false);
        KeyGuide = transform.GetChild(1).gameObject;
    }
}
