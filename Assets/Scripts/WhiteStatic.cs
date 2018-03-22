using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteStatic : MonoBehaviour {

    // Declaring 
    public GameObject go;

    private static int texDim = 256;
    private Color[] pixCol;

    private Texture2D tex;

	// Use this for initialization
	void Start () {

        pixCol = new Color[texDim * texDim];
        tex = new Texture2D(texDim, texDim);

        Init(); 

        go.GetComponent<Renderer>().material.mainTexture = tex; 
	}

	
	// Update is called once per frame
	void Update () {
        Stat();
	}

    private void Init()
    {
        for (int i = 0; i < texDim * texDim; i++)
        {
            pixCol[i] = Color.cyan;

        }

        tex.SetPixels(pixCol);
        tex.Apply();
    }

    private void Stat()
    {
        System.Random rnd = new System.Random();

        int numRands = 800;
        int[] rands = new int[numRands]; 
        for (int i = 0; i < numRands; i++)
        {
            rands[i] = rnd.Next(1, texDim*texDim);

        }

        for (int i = 0; i < numRands; i++)
        {
            int r = rnd.Next(1, 9);
            if (r == 1)
            {
                pixCol[rands[i]] = Color.black; 
            } else if (r == 2)
            { 
                pixCol[rands[i]] = Color.cyan;
            } else if (r == 3)
            {
                pixCol[rands[i]] = Color.magenta;
            } else
            {
                pixCol[rands[i]] = Color.white;
            }
        }

        tex.SetPixels(pixCol);
        tex.Apply();
    }
}
