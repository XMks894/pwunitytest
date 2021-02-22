using Assets.Scripts.Commons;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    private readonly List<InventoryItemComponent> _list = new List<InventoryItemComponent>();

    public GameObject InventoryItemPrefab;

    private float _money = 100;

    private void Start()
    {
        DisplayItems();
    }

    private void DisplayItems()
    {
        var list = Tools.GetOrCreateInventoryItemList();

        foreach(var item in list)
        {
            var obj = Instantiate(InventoryItemPrefab, gameObject.transform);

            var inventoryItemComponent = obj.GetComponent<InventoryItemComponent>();
            inventoryItemComponent.NameText.text = item.Name;
            inventoryItemComponent.DescriptionText.text = item.Description;
            inventoryItemComponent.ValueText.text = item.Value.ToString();
            inventoryItemComponent.SellButton.onClick.AddListener(() => SellButtonExecute(inventoryItemComponent));
            inventoryItemComponent.BuyButton.onClick.AddListener(() => BuyButtonExecute(inventoryItemComponent));

            _list.Add(inventoryItemComponent);
        }
    }

    private void SellButtonExecute(InventoryItemComponent inventoryItem)
    {
        var value = float.Parse(inventoryItem.ValueText.text);

        _money += value;

        Debug.Log($"Money: {_money}");
    }

    private void BuyButtonExecute(InventoryItemComponent inventoryItem)
    {
        var value = float.Parse(inventoryItem.ValueText.text);

        if(_money < value) return;

        _money -= value;

        Debug.Log($"Money: {_money}");
    }

    private void OnDestroy()
    {
        foreach(var item in _list)
        {
            item.SellButton.onClick.RemoveAllListeners();
            item.BuyButton.onClick.RemoveAllListeners();
        }
    }
}
