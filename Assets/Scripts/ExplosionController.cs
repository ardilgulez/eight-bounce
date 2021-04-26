using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public bool fireExplosionEvent = false;

    public delegate void ExplosionEvent();
    public static event ExplosionEvent ExplosionFinished;

    public void OnParticleSystemStopped()
    {
        if (fireExplosionEvent)
        {
            ExplosionFinished();
        }
        Destroy(gameObject);
    }

}
