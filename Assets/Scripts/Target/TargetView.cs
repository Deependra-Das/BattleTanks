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
    private GameObject _explosionPrefab;

    [SerializeField]
    private ParticleSystem _explosionParticles;


    public void SetTargetController(TargetController targetController)
    {
        _targetController = targetController;
    }

    public void InstantiateExplosion()
    {
        _explosionParticles = Instantiate(_explosionPrefab).GetComponent<ParticleSystem>();
        _explosionParticles.gameObject.SetActive(false);
    }

    public void PlayTargetExplosion()
    {
        _explosionParticles.transform.position = transform.position;
        _explosionParticles.gameObject.SetActive(true);

        _explosionParticles.Play();
        Destroy(_explosionParticles.gameObject, _explosionParticles.main.duration);

        _targetController.DisableMarker();

        Destroy(this.gameObject);
      
    }
    public void SetAreaParent(Transform area)
    {
        gameObject.transform.SetParent(area.gameObject.transform);
    }
}
