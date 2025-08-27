using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    public static ShopUI Instance;
    public int amount;
    Item currentItem;
    [SerializeField] GameObject itemIcon;
    [SerializeField] Transform itemContainer;
    [SerializeField] UITextPopup textPopup;
    [Header("buy sell popup")]
    [SerializeField] GameObject buySellPopup;
    [SerializeField] TMP_Text ownText;
    [SerializeField] TMP_Text amountText;
    [SerializeField] TMP_Text costText;
    [SerializeField] Image currencyIcon;
    [SerializeField] Sprite coinSprite;
    [SerializeField] Sprite gemSprite;
    [Header("sound")]
    [SerializeField] AudioClip buySellClip;
    [SerializeField] AudioClip buyFailClip;

    Item[] itemPotion;
    Item[] itemEquip;
    Item[] itemPremium;
    SaveData saveData;

    void Awake(){
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start() {
        saveData = UIManager.Instance.saveData;
        itemPotion = Resources.LoadAll<Item>("Potion");
        itemEquip = Resources.LoadAll<Item>("Equip");
        itemPremium = Resources.LoadAll<Item>("Premium");
        Debug.Log("load item complete");
        CreateItemIcon("potion");
    }

    public void CreateItemIcon(string shopType){
        Item[] loadItem = new Item[0];
        switch(shopType){
            case "potion":
                loadItem = itemPotion;
                break;
            case "equip":
                loadItem = itemEquip;
                break;
            case "premium":
                loadItem = itemPremium;
                break;
        }
        //clear old item
        for (int i = itemContainer.childCount - 1; i >= 0; i--)
        {
            Transform child = itemContainer.GetChild(i);
            Destroy(child.gameObject);
        }
        foreach(var item in loadItem)
        {
            GameObject instantiated = Instantiate(itemIcon, itemContainer);
            ItemIcon itemSlot = instantiated.GetComponent<ItemIcon>();
            itemSlot.SetItemInfo(item);
        }
    }

    public void SetAmountText(){
        amountText.text = amount.ToString();
        costText.text = "" + currentItem.cost * amount;
    }

    public void ChangeAmount(int a){
        amount += a;
        if(amount < 0) amount = 0;
        SetAmountText();
    }

    public void SetItemInfo(Item item){
        currentItem = item;
        buySellPopup.SetActive(true);
        amount = 1;
        SetAmountText();
        ownText.text = "Own: " + saveData.GetItemAmount(item.sid);
        if(currentItem.currencyType == CurrencyType.coin) currencyIcon.sprite = coinSprite;
        else if(currentItem.currencyType == CurrencyType.gem) currencyIcon.sprite = gemSprite;
    }

    public void Action(){//click buy button
        if(currentItem.currencyType == CurrencyType.coin){
            if(saveData.coin >= currentItem.cost * amount){
                saveData.coin -= currentItem.cost * amount;
                saveData.AddItem(currentItem.sid, amount);
                AudioController.Instance.CreateSFX(buySellClip, transform.position);
                textPopup.ShowPopup(transform, "Buy item");
            }else{
                AudioController.Instance.CreateSFX(buyFailClip, transform.position);
                textPopup.ShowPopup(transform, "Not enough gold");
            }
        }
        if(currentItem.currencyType == CurrencyType.gem){
            if(saveData.gem >= currentItem.cost * amount){
                saveData.gem -= currentItem.cost * amount;
                saveData.AddItem(currentItem.sid, amount);
                AudioController.Instance.CreateSFX(buySellClip, transform.position);
                textPopup.ShowPopup(transform, "Buy item");
            }else{
                AudioController.Instance.CreateSFX(buyFailClip, transform.position);
                textPopup.ShowPopup(transform, "Not enough gem");
            }
        }
        UIManager.Instance.UpdateCurrencyText();
        buySellPopup.SetActive(false);
    }
}
