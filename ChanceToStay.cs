using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceToStay : MonoBehaviour
{
    [SerializeField] float stay = 0.75f;
    private float chance;
    private void Start()
    {
        chance = Random.Range(0f, 1f);
        if (chance > stay) Destroy(gameObject);
    }
}
