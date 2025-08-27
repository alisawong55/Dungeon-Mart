using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UITextPopup : MonoBehaviour
{
    [SerializeField] GameObject popupPrefab;
    [SerializeField] Transform popupParent;//canvas
    float popupDuration = 1.5f;
    Vector2 offset = new Vector2(0, 50);

    public void ShowPopup(Transform parent, string text)
    {
        StartCoroutine(SpawnPopup(parent, text));
    }

    IEnumerator SpawnPopup(Transform parent, string text)
    {
        GameObject popup = Instantiate(popupPrefab, popupParent);
        TextMeshProUGUI textComponent = popup.GetComponent<TextMeshProUGUI>();

        textComponent.text = text;
        popup.transform.position = parent.position + (Vector3)offset;

        // Fade animation
        CanvasGroup canvasGroup = popup.AddComponent<CanvasGroup>();
        float elapsedTime = 0;
        float fadeTime = popupDuration / 2; 

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            popup.transform.position += Vector3.up * Time.deltaTime * 20; // Move up
            canvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime / fadeTime); // Fade out
            yield return null;
        }
        Destroy(popup);
    }
}

