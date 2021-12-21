using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent (typeof (TilemapCollider2D), typeof(CompositeCollider2D))]
public class OneWayPlatform : MonoBehaviour
{
    public float maxAngle = 45.0f;
    public bool upsideDown;

    private void Start()
    {
        float cos = Mathf.Cos(maxAngle);
        TilemapCollider2D tileCollider = GetComponent<TilemapCollider2D>();
        if (tileCollider == null)
        {
            Debug.LogError("PlatformCollision needs a TilemapCollider");
        }
        
    }


    private void Update()
    {
        
    }
}

/*public float maxAngle = 45.0f;
public bool upsideDown = false;

// Thanks https://stackoverflow.com/questions/25395231/how-to-detect-collisions-only-one-way
void Start ()
{
    float cos = Mathf.Cos(maxAngle);
    MeshCollider meshCollider = GetComponent<MeshCollider>();
    if (meshCollider == null)
    {
        Debug.LogError("PlatformCollision needs a MeshCollider");
        return;
    }
    Mesh genMeshCollider = new Mesh();
    Vector3[] verts = meshCollider.sharedMesh.vertices;
    List<int> triangles = new List<int>(meshCollider.sharedMesh.triangles);
    for (int i = triangles.Count-1; i >=0 ; i -= 3)
    {
        Vector3 P1 = transform.TransformPoint(verts[triangles[i-2]]);
        Vector3 P2 = transform.TransformPoint(verts[triangles[i-1]]);
        Vector3 P3 = transform.TransformPoint(verts[triangles[i  ]]);
        Vector3 faceNormal = Vector3.Cross(P3-P2,P1-P2).normalized;
        if ( (Vector3.Dot(faceNormal, upsideDown ? Vector3.down : Vector3.up) <= cos))
             // (!topCollision && Vector3.Dot(faceNormal, -Vector3.up) <= cos) )
        {
            triangles.RemoveAt(i);
            triangles.RemoveAt(i-1);
            triangles.RemoveAt(i-2);
        }
    }
    genMeshCollider.vertices = verts;
    genMeshCollider.triangles = triangles.ToArray();
    meshCollider.sharedMesh = genMeshCollider;
}

private void OnValidate()
{
    
}*/

/*

*/
