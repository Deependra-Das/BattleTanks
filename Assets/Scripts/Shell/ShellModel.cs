using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ShellSpawner;

public class ShellModel
{
    private ShellController _shellController;

    private ShellTypes _shellType;
    private Material _shellMatColor;
    private float _maxDamage;
    private float _explosionForce;
    private float _maxLifeTime;
    private float _explosionRadius;

    public ShellModel(ShellTypes shellType, Material shellMatColor, float maxDamage, float explosionForce, float maxLifeTime, float explosionRadius)
    {
        _shellType = shellType;
        _shellMatColor = shellMatColor;
        _maxDamage = maxDamage;
        _explosionForce = explosionForce;
        _maxLifeTime = maxLifeTime;
        _explosionRadius = explosionRadius;
    }
    public void SetShellController(ShellController shellController)
    {
        _shellController = shellController;

    }
    public Material GetShellMaterialColor()
    {
        return _shellMatColor;
    }
    public float GetExplosionRadius()
    {
        return _explosionRadius;
    }
    public float GetExplosionForce()
    {
        return _explosionForce;
    }
    public float GetMaxDamage()
    {
        return _maxDamage;
    }
    public float GetMaxLifeTime()
    {
        return _maxLifeTime;
    }
}
