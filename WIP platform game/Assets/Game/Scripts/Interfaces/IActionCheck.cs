using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionCheck
{
    public int Check(); 
    public RaycastHit2D[] results { get; set; }
}
