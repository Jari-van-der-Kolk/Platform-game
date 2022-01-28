using System;
using System.Collections.Generic;
using UnityEngine;
using Inventory;

public class ItemHolderSystem : MonoBehaviour
{
    public Transform[] itemHolders;
    
    [SerializeField] private int index;

    private void Awake()
    {
        index = 2;
        itemHolders = new Transform[transform.childCount];
        for (int i = 0; i < itemHolders.Length; i++)
        {
            itemHolders[i] = transform.GetChild(i);
        }
        
        SetIndex(index = 0, false);
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) SetIndex(index = 0,false);
        if(Input.GetKeyDown(KeyCode.Alpha2)) SetIndex(index = 1,false);
        if(Input.GetKeyDown(KeyCode.Alpha3)) SetIndex(index = 2,false);
        if(Input.GetKeyDown(KeyCode.Alpha4)) SetIndex(index = 3,false);
        if(Input.GetKeyDown(KeyCode.Alpha5)) SetIndex(index = 4,false);
        if(Input.GetKeyDown(KeyCode.Alpha6)) SetIndex(index = 5,false);
        
        if(Input.GetAxis("Mouse ScrollWheel") >= 0) SetIndex(index++, true);
        if(Input.GetAxis("Mouse ScrollWheel") <= 0) SetIndex(index--, true);
    }

    private void SetIndex(int index, bool isScrollWheel)
    {
        IndexCheck(isScrollWheel, itemHolders.Length);
        for (int i = 0; i < itemHolders.Length; i++)
        {
            if (index == i)
            {
                itemHolders[i].gameObject.SetActive(true);
                continue;
            }
            itemHolders[i].gameObject.SetActive(false);
        }
    }

    private void IndexCheck(bool isScrollWheel, int childCount)
    {
        
        if (this.index > childCount - 1)
        {
            if (isScrollWheel)
            {
                this.index = 0;
            }
            else
            {
                index = childCount - 1;
            }    
        }
        if (this.index < 0)
        {
            if (isScrollWheel)
            {
                this.index = childCount - 1;
            }
            else
            {
                this.index = 0;
            }   
        }
    }

    
    
}
