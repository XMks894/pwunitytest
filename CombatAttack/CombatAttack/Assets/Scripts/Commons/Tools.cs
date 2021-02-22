using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Commons
{
    public static class Tools
    {
        private static readonly List<InventoryItemModel> _inventoryItemList = new List<InventoryItemModel>();

        public static List<InventoryItemModel> GetOrCreateInventoryItemList()
        {
            if(_inventoryItemList.Count > 0) return _inventoryItemList;

            for(int i = 0; i < 10; i++)
            {
                _inventoryItemList.Add(new InventoryItemModel
                {
                    Name = $"Item { i + 1 }",
                    Description = $"Description {i + 1}",
                    Value = Random.Range(1, 100)
                });
            }

            return _inventoryItemList;
        }
    }
}
