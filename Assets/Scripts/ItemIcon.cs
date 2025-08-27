using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemIcon : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image itemIcon;
    [SerializeField] Image currencyIcon;
    [SerializeField] Sprite coinSprite;
    [SerializeField] Sprite gemSprite;
    [SerializeField] TMP_Text cost;
    [SerializeField] TMP_Text itemName;
    public Item item;

    // Set the item data and icon for this slot
    public void SetItemInfo(Item newItem)
    {
        item = newItem;
        itemName.text = item.itemName;
        if(item.icon != null)
            itemIcon.sprite = item.icon;
        
        if(item.currencyType == CurrencyType.coin){
            currencyIcon.sprite = coinSprite;
        }
        if(item.currencyType == CurrencyType.gem){
            currencyIcon.sprite = gemSprite;
        }
        cost.text = item.cost.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(item != null){
            ShopUI.Instance.SetItemInfo(item);
        }
    }
}
