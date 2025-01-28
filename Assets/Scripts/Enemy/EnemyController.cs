using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    private EnemyModel _enemyModel;
    private EnemyView _enemyView;
    private EnemyRadarView _enemyRadarView;
    private Rigidbody _enemyRB;


    public EnemyController(EnemyModel enemyModel, EnemyView enemyView, EnemyRadarView enemyRadarView)
    {
        _enemyModel = enemyModel;
        _enemyModel.SetEnemyController(this);

        _enemyView = GameObject.Instantiate<EnemyView>(enemyView, _enemyModel.GetSpawnPosition(), Quaternion.Euler(_enemyModel.GetSpawnRotation()));
        _enemyRB = _enemyView.GetRigidBody();
        _enemyView.SetEnemyController(this);
        ResetData();

        _enemyRadarView = GameObject.Instantiate<EnemyRadarView>(enemyRadarView);
        _enemyRadarView.SetRadarParent(_enemyView.GetEnemyTransform());
        _enemyRadarView.SetEnemyController(this);
    }

    public float GetMovementSpeed()
    {
        return _enemyModel.GetMovementSpeed();
    }
    public float GetRotationSpeed()
    {
        return _enemyModel.GetRotationSpeed();
    }

    public float GetCurrentHealth()
    {
        return _enemyModel.GetCurrentHealth();
    }
    public float GetInitialHealth()
    {
        return _enemyModel.GetInitialHealth();
    }
    public float GetMinLaunchForce()
    {
        return _enemyModel.GetMinLaunchForce();
    }
    public float GetMaxLaunchForce()
    {
        return _enemyModel.GetMaxLaunchForce();
    }
    public float GetMaxChargeTime()
    {
        return _enemyModel.GetMaxChargeTime();
    }
    public float GetChargeSpeed()
    {
        return _enemyModel.GetChargeSpeed();
    }
    public bool HasFired()
    {
        return _enemyModel.HasFired();
    }

    public void TakeDamage(float amount)
    {
        _enemyModel.TakeDamage(amount);
        SetHealthUI();
        if (GetCurrentHealth() <= 0f && !_enemyModel.IsEnemyDead())
        {
            OnDeath();
        }
    }
    public void SetHealthUI()
    {
        _enemyView.SetHealthUI();
    }
    public void SetFired(bool fireValue)
    {
        _enemyModel.SetFired(fireValue);
    }
    public void OnDeath()
    {
        _enemyModel.SetEnemyDead();
        _enemyView.EnemyExplosion();
    }
    public void ResetData()
    {
        _enemyModel.ResetData();
        _enemyView.ChangeColor(_enemyModel.GetEnemyMaterialColor());
        _enemyView.SetPatrolWaypoints(_enemyModel.GetPatrolPoints());
        _enemyView.SetWaitTimeAtWaypoint(_enemyModel.GetWaitTimeAtWaypoint());
        _enemyView.SetShootingCooldown(_enemyModel.GetShootingCooldown());
        _enemyView.SetShootingRange(_enemyModel.GetShootingRange());
    }

    public void SetPlayerInRange(bool value) => _enemyView.SetPlayerInRange(value);
    public void SetPlayerTransform(Transform value) => _enemyView.SetPlayerTransform(value);
    public Transform GetPlayerTransform()
    {
        return _enemyView.GetPlayerTransform();
    }

    public void SetPlayerInShootingRange(bool value) => _enemyView.SetPlayerInShootingRange(value);
    public bool GetPlayerInShootingRange()
    {
        return _enemyView.GetPlayerInShootingRange();
    }
    public float GetShootingRange()
    {
        return _enemyView.GetShootingRange();
    }

    public void PausePatrolling()
    {
        _enemyView.PausePatrolling();
    }
    public void ResumePatrolling()
    {
        _enemyView.ResumePatrolling();
    }
}
