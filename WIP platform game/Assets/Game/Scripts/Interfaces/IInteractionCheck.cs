using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractionCheck
{
    public Collider2D[] Check(); 
    public Collider2D[] results { get; set; }
}
