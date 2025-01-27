using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    private EnemyController _enemyController;

    private float _movementSpeed;
    private float _rotationSpeed;
    private EnemyTypes _enemyType;
    private Material _enemyMatColor;

    private float _initialHealth;
    private float _currentHealth;
    private bool _dead;

    public float _minLaunchForce;
    public float _maxLaunchForce;
    public float _maxChargeTime;

    private float _chargeSpeed;
    private bool _fired;

    private Vector3 _spawnPosition;
    private Vector3 _spawnRotation;
    private Transform[] _patrolpoints;

    private float _waitTimeAtWaypoint;
    private float _shootingCooldown;
    private float _shootingRange;

    public EnemyModel(EnemyScriptableObject enemyScriptableObject, 
        Vector3 spawnPosition, 
        Vector3 spawnRotation,
        Transform[] patrolpoints
        )
    {
        _movementSpeed = enemyScriptableObject.movementSpeed;
        _rotationSpeed = enemyScriptableObject.rotationSpeed;
        _enemyType = enemyScriptableObject.enemyType;
        _enemyMatColor = enemyScriptableObject.enemyMatColor;
        _initialHealth = enemyScriptableObject.initialHealth;
        _minLaunchForce = enemyScriptableObject.minLaunchForce;
        _maxLaunchForce = enemyScriptableObject.maxLaunchForce;
        _maxChargeTime = enemyScriptableObject.maxChargeTime;
        _spawnPosition= spawnPosition;
        _spawnRotation= spawnRotation;
        _patrolpoints = patrolpoints;
        _waitTimeAtWaypoint = enemyScriptableObject.waitTimeAtWaypoint;
        _shootingCooldown = enemyScriptableObject.shootingCooldown;
        _shootingRange = enemyScriptableObject.shootingRange;
    }

    public void SetEnemyController(EnemyController enemyController)
    {
        _enemyController = enemyController;
    }

    public void ResetData()
    {
        _currentHealth = _initialHealth;
        _chargeSpeed = (_maxLaunchForce - _minLaunchForce) / _maxChargeTime;
        _dead = false;
        _enemyController.SetHealthUI();
    }

    public float GetMovementSpeed()
    {
        return _movementSpeed;
    }
    public float GetRotationSpeed()
    {
        return _rotationSpeed;
    }
    public EnemyTypes GetEnemyType()
    {
        return _enemyType;
    }
    public Material GetEnemyMaterialColor()
    {
        return _enemyMatColor;
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
    }
    public float GetCurrentHealth()
    {
        return _currentHealth;
    }
    public float GetInitialHealth()
    {
        return _initialHealth;
    }
    public float GetMinLaunchForce()
    {
        return _minLaunchForce;
    }
    public float GetMaxLaunchForce()
    {
        return _maxLaunchForce;
    }
    public float GetMaxChargeTime()
    {
        return _maxChargeTime;
    }
    public float GetChargeSpeed()
    {
        return _chargeSpeed;
    }
    public Vector3 GetSpawnPosition()
    {
        return _spawnPosition;
    }
    public Vector3 GetSpawnRotation()
    {
        return _spawnRotation;
    }
    public float GetWaitTimeAtWaypoint()
    {
        return _waitTimeAtWaypoint;
    }
    public float GetShootingCooldown()
    {
        return _shootingCooldown;
    }
    public float GetShootingRange()
    {
        return _shootingRange;
    }

    public bool HasFired()
    {
        return _fired;
    }

    public bool IsEnemyDead()
    {
        return _dead;
    }
    public void SetEnemyDead()
    {
        _dead = true;
    }

    public void SetFired(bool fireValue)
    {
        _fired = fireValue;
    }

    public Transform[] GetPatrolPoints()
    {
        return _patrolpoints;
    }
}
