using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TankSpawner;

public class TankModel
{
    private TankController _tankController;
      
    private float _movementSpeed;
    private float _rotationSpeed;
    private TankTypes _tankType;
    private Material _tankMatColor;

    private float _initialHealth;
    private float _currentHealth;
    private bool _dead;

    public float _minLaunchForce;       
    public float _maxLaunchForce;      
    public float _maxChargeTime;

    private float _currentLaunchForce;  
    private float _chargeSpeed;         
    private bool _fired;

    public TankModel(TankTypes tankType,
        float movementSpeed,
        float rotationSpeed,
        Material tankMatColor,
        float initialHealth,
        float minLaunchForce,
        float maxLaunchForce,
        float maxChargeTime) 
    {
        _movementSpeed=movementSpeed;
        _rotationSpeed=rotationSpeed;
        _tankType=tankType;
        _tankMatColor=tankMatColor;
        _initialHealth=initialHealth;
        _minLaunchForce=minLaunchForce;
        _maxLaunchForce=maxLaunchForce;
        _maxChargeTime=maxChargeTime;
    }

    public void SetTankController(TankController tankController)
    {
        _tankController = tankController;
    }

    public void ResetData()
    {
        _currentHealth = _initialHealth;
        _currentLaunchForce = _minLaunchForce;
        _dead = false;
        _tankController.SetHealthUI();
    }

    public float GetMovementSpeed()
    {
        return _movementSpeed;
    }
    public float GetRotationSpeed()
    {
        return _rotationSpeed;
    }
    public TankTypes GetTankType()
    {
        return _tankType;
    }
    public Material GetTankMaterialColor()
    {
        return _tankMatColor;
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
    public float GetCurrentLaunchForce()
    {
        return _currentLaunchForce;
    }
    public float GetChargeSpeed()
    {
        return _chargeSpeed;
    }
    public bool HasFired()
    {
        return _fired;
    }

    public bool IsTankDead()
    {
        return _dead;
    }
    public void SetTankDead()
    {
        _dead=true;
    }
    public void SetCurrentLaunchForce(float forceValue)
    {
        _currentLaunchForce= forceValue;
    }
    public void SetFired(bool fireValue)
    {
        _fired= fireValue;
    }
}
