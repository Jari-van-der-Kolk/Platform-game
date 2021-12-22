using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretRoomDoorAlpha : MonoBehaviour
{

    [SerializeField] private Color tileColor;
    private Tilemap tilemap;
    private Transform playerLoc;
    
    private void Awake()
    {
        playerLoc = GameObject.FindWithTag("Player").GetComponent<Transform>();
        tilemap = GetComponent<Tilemap>();
        //tilemap.GetTile<Tile>()
    }

    private void Update()
    {
        Vector3Int cellPos = tilemap.WorldToCell(playerLoc.position);
        Debug.DrawLine(playerLoc.position, cellPos + Vector3Int.up);
        ChangeTileAlpha(cellPos);
    }

    private void ChangeTileAlpha(Vector3Int playerPos)
    {
        Tile tile = tilemap.GetTile<Tile>(playerPos);
        
        if (tile != null)
        {
            tile.color = tileColor;
        }
    }
    
    
}
