using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public TankModel(TankTypes tankType, float movementSpeed, float rotationSpeed, Material tankMatColor, float initialHealth) 
    {
        _movementSpeed=movementSpeed;
        _rotationSpeed=rotationSpeed;
        _tankType=tankType;
        _tankMatColor=tankMatColor;
        _initialHealth=initialHealth;
    }

    public void SetTankController(TankController tankController)
    {
        _tankController = tankController;
    }

    public void reset()
    {
        _currentHealth = _initialHealth;
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

    public bool IsTankDead()
    {
        return _dead;
    }
    public void SetTankDead()
    {
        _dead=true;
    }
}
