using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetExplosion : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _explosionParticles;

    public void PlayTargetExplosion()
    {
        _explosionParticles.transform.position = transform.position;
        _explosionParticles.gameObject.SetActive(true);

        _explosionParticles.Play();
        gameObject.SetActive(false);
    }
}
