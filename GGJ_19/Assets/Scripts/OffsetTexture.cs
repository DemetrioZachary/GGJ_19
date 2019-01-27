using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetTexture : MonoBehaviour
{
    Material mat;
    public float speed;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if(mat == null)
        {
            Debug.Log("KTM");
        }

        mat.SetTextureOffset("_MainTex", new Vector2(mat.mainTextureOffset.x + Time.deltaTime * speed, mat.mainTextureOffset.y));
    }
}
