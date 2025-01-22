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

        _shellView = GameObject.Instantiate<ShellView>(shellView);
        _shellRB = _shellView.GetRigidBody();
        _shellView.SetShellController(this);

        _shellView.ChangeColor(_shellModel.GetShellMaterialColor());
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
}
