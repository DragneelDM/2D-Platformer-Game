using UnityEngine;

public class TutorialGuide : MonoBehaviour
{
    [SerializeField] GameObject _guideToKey;
    [SerializeField] GameObject _guideToDoor;

    private void OnTriggerStay2D(Collider2D other)
    {
        _guideToKey.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _guideToKey.SetActive(false);
    }

    public void KeyTaken()
    {
        _guideToKey.SetActive(false);
        _guideToKey = _guideToDoor;
    }
}
