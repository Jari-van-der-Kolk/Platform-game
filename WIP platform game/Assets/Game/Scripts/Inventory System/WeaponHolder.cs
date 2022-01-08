using System;
using UnityEngine;
using Inventory;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private int index;

    [SerializeField]private Transform[] children;
    
    private void Start()
    {
        children = new Transform[transform.childCount];     
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i);
            if (index == i) { continue; }
            children[i].gameObject.SetActive(false);
        }
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) Foo(index = 0,false);
        if(Input.GetKeyDown(KeyCode.Alpha2)) Foo(index = 1,false);
        if(Input.GetKeyDown(KeyCode.Alpha3)) Foo(index = 2,false);
        if(Input.GetKeyDown(KeyCode.Alpha4)) Foo(index = 3,false);
        if(Input.GetKeyDown(KeyCode.Alpha5)) Foo(index = 4,false);
        if(Input.GetKeyDown(KeyCode.Alpha6)) Foo(index = 5,false);
        
        //if(Input.mouseScrollDelta.y >= 1) Foo(index++);
        //if(Input.mouseScrollDelta.y <= 1) Foo(index--);
    }

    private void Foo(int index, bool isScrollWheel)
    {
        int childCount = transform.childCount;
        IndexCheck(ref index ,isScrollWheel, childCount);
        for (int i = 0; i < childCount; i++)
        {
            if (index == i)
            {
                children[i].gameObject.SetActive(true);
                continue;
            }
            children[i].gameObject.SetActive(false);
        }
    }

    private void IndexCheck(ref int index, bool isScrollWheel, int childCount)
    {
        
        if (index > childCount - 1)
        {
            if (isScrollWheel)
            {
                index = 0;
            }
            else
            {
                index = childCount - 1;
            }    
        }
        if (index < 0)
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
