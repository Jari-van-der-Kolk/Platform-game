using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionCheck
{
    public Collider2D Check(); 
    public Collider2D[] results { get; set; }
}
