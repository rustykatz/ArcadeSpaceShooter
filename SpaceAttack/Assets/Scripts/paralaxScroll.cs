using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxScroll : MonoBehaviour {

    public float scroll_speed = 0.2f;
    private MeshRenderer mesh_renderer;


    // Use this for initialization
    void Start()
    {
        mesh_renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = Time.time * scroll_speed;
        Vector2 offset = new Vector2(0, y);
        mesh_renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);


    }
}

