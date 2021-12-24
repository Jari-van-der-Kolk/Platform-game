using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
   private InventorySystem _inventorySystem;
   private InventoryCell[,] grid;
   private RectTransform _rectLocation;

   [SerializeField] private RectTransform inventoryHolderRectTransform;
   [SerializeField] int2 gridSize;
   [SerializeField] private Vector2 beginOffset;
   [SerializeField] private GameObject gridCellPrefab;

   private void Awake()
   {
      _rectLocation = GetComponent<RectTransform>();
      _inventorySystem = FindObjectOfType<InventorySystem>();
      inventoryHolderRectTransform = transform.GetChild(0).GetComponent<RectTransform>();
      if (inventoryHolderRectTransform == null)
      {
         Debug.LogError("The " + gameObject.name + " does not have a RectTransform to put the gridcells on");
      }
   }

   private void Start()
   {
      grid = new InventoryCell[gridSize.x, gridSize.y];
      for (int x = 0; x < grid.GetLength(0); x++)
      {
         for (int y = 0; y < grid.GetLength(1); y++)
         {
            var inventoryRect = transform.GetChild(0);
            grid[x, y].prefab = Instantiate(gridCellPrefab, inventoryRect);
            grid[x, y].icon = grid[x, y].prefab.GetComponent<Image>();
            grid[x, y].rect = GetComponent<RectTransform>();
            grid[x, y].prefab.transform.position = new Vector3((inventoryRect.position.x + beginOffset.x) * (x + 1) / 3, (inventoryRect.position.y + beginOffset.y) * (y + 1) / 3);
         }
      }
   }
   
   private struct InventoryCell
   {
      public GameObject prefab;
      public RectTransform rect;
      public Image icon;
   }
   
}
