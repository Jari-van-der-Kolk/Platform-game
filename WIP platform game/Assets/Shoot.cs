using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float shootSpeed;
    private float timer;
    
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime * shootSpeed;
        if (timer >= 1f)
        {
            //shoot
        }
    }
}
