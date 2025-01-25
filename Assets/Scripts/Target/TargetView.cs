using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TargetView : MonoBehaviour
{
    private TargetController _targetController;

    [SerializeField]
    private ParticleSystem _explosionParticles;

    public void SetTargetController(TargetController targetController)
    {
        _targetController = targetController;
    }

    public void PlayTargetExplosion()
    {
        _explosionParticles.transform.position = transform.position;
        _explosionParticles.gameObject.SetActive(true);

        _explosionParticles.Play();
        gameObject.SetActive(false);
        _targetController.DisableMarker();
    }

}
