using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string BOTTOM_TAG = "Bottom";
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(BOTTOM_TAG))
        {
            Destroy(gameObject);
        }
    }
}
