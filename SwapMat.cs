using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMat : MonoBehaviour
{

    public Material[] mat;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = mat[Random.Range(0, mat.Length)];
    }
}
