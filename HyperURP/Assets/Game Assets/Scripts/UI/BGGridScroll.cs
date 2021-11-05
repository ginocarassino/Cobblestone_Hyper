using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGGridScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private float xScroll;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Time.timeScale = 1f;
    }

    private void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        xScroll = Time.time * scrollSpeed;

        Vector2 offset = new Vector2(0f, xScroll);

        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
