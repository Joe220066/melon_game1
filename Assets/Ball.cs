using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Numerics;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float[] size_array = { 0.4f, 0.5f, 0.62f, 0.77f, 0.95f, 1.18f, 1.47f, 1.83f, 2.27f, 2.82f, 3.5f };
        System.Random ri = new System.Random(Guid.NewGuid().GetHashCode());
        float size = size_array[ri.Next(0,3)];
        transform.localScale = new UnityEngine.Vector3(size, size, 0f);
    }
    
// Update is called once per frame
void Update()
    {
        
    }
}
