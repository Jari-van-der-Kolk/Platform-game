using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotTesting : MonoBehaviour
{
    public GameObject objectl;
    
    void Update()
    {
        Debug.Log(Vector2.Dot(Vector2.right, (transform.position - objectl.transform.position).normalized));
    }
}
