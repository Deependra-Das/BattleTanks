using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    private EnemyModel _enemyModel;
    private EnemyView _enemyView;
    private Rigidbody _enemyRB;


    public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
    {
        _enemyModel = enemyModel;
        _enemyModel.SetEnemyController(this);

        _enemyView = GameObject.Instantiate<EnemyView>(enemyView, _enemyModel.GetSpawnPosition(), Quaternion.Euler(_enemyModel.GetSpawnRotation()));
        _enemyRB = _enemyView.GetRigidBody();
        _enemyView.SetEnemyController(this);
        _enemyView.ChangeColor(_enemyModel.GetEnemyMaterialColor());
        _enemyView.SetPatrolWaypoints(_enemyModel.GetPatrolPoints());
        ResetData();
    }

    public void Move(float movement, float movementSpeed)
    {
        _enemyRB.velocity = _enemyView.transform.forward * movement * movementSpeed;
    }

    public void Rotate(float rotation, float rotationSpeed)
    {
        Vector3 vector = new Vector3(0f, rotation * rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        _enemyRB.MoveRotation(_enemyRB.rotation * deltaRotation);
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
    public float GetCurrentLaunchForce()
    {
        return _enemyModel.GetCurrentLaunchForce();
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
    public void SetCurrentLaunchForce(float forceValue)
    {
        _enemyModel.SetCurrentLaunchForce(forceValue);
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
        _enemyView.ResetUI();
    }

}
