using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public SaveData saveData;
    [SerializeField] TMP_Text coinText;
    [SerializeField] TMP_Text gemText;

    void Awake(){
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start() {
        UpdateCurrencyText();
    }

    public void UpdateCurrencyText(){
        coinText.text = saveData.coin.ToString();
        gemText.text = saveData.gem.ToString();
    }
}
