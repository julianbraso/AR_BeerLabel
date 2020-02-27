using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iOSVideoFix : MonoBehaviour {

    public MeshFilter mesh;

    Vector2[] uvs;

    // Use this for initialization
    void Start()
    {
    #if UNITY_IOS
		uvs = mesh.mesh.uv;

		for(int i = 0; i < uvs.Length; i++)
		{
			uvs[i] = new Vector2(uvs[i].x, 1.0f-uvs[i].y);
		}
		mesh.mesh.uv = uvs;
    #endif
    }
    // Update is called once per frame
    void Update() {
        	
	}
}
