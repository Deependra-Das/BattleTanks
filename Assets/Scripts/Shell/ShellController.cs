using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController
{
    private ShellModel _shellModel;
    private ShellView _shellView;
    private Rigidbody _shellRB;

    public ShellController(ShellModel shellModel, ShellView shellView)
    {
        _shellModel = shellModel;
        _shellModel.SetShellController(this);

        Transform originTransform = GetOrigintransform();
        _shellView = GameObject.Instantiate<ShellView>(shellView, originTransform.position, originTransform.rotation);
        _shellView.SetShellController(this);

        _shellView.ChangeColor(_shellModel.GetShellMaterialColor());

        _shellRB = _shellView.GetRigidBody();
        _shellRB.velocity = GetVelocity();
    }

    public float GetExplosionRadius()
    {
        return _shellModel.GetExplosionRadius();
    }
    public float GetExplosionForce()
    {
        return _shellModel.GetExplosionForce();
    }
    public float GetMaxDamage()
    {
        return _shellModel.GetMaxDamage();
    }
    public float GetMaxLifeTime()
    {
        return _shellModel.GetMaxLifeTime();
    }
    public Transform GetOrigintransform()
    {
        return _shellModel.GetOrigintransform();
    }
    public Vector3 GetVelocity()
    {
        return _shellModel.GetVelocity();
    }
}
