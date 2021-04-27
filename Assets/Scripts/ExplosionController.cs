using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : Scorable
{
    public bool fireExplosionEvent = false;
    public float ExplosionScore = 0;

    public delegate void ExplosionEvent();
    public static event ExplosionEvent ExplosionFinished;

    private void Start()
    {
        Score(ExplosionScore);
    }

    public void OnParticleSystemStopped()
    {
        if (fireExplosionEvent)
        {
            ExplosionFinished();
        }
        Destroy(gameObject);
    }

}
