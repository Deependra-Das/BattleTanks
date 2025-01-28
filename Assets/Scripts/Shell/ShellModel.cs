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
    private Vector3 _velocity;
    private Transform _originTransform;
    private ShellParentTypes _shellParentType;

    public ShellModel(ShellTypes shellType,
        Material shellMatColor, float maxDamage,
        float explosionForce,
        float maxLifeTime,
        float explosionRadius,
        Vector3 velocity,
        Transform originTransform,
        ShellParentTypes shellParentType
        )
    {
        _shellType = shellType;
        _shellMatColor = shellMatColor;
        _maxDamage = maxDamage;
        _explosionForce = explosionForce;
        _maxLifeTime = maxLifeTime;
        _explosionRadius = explosionRadius;
        _velocity = velocity;
        _originTransform = originTransform;
        _shellParentType= shellParentType;
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
    public Transform GetOrigintransform()
    {
        return _originTransform;
    }
    public Vector3 GetVelocity()
    {
        return _velocity;
    }
    public ShellParentTypes GetShellParentType()
    {
        return _shellParentType;
    }
}
