using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController 
{

    private TargetModel _targetModel;
    private TargetView _targetView;


    public TargetController(TargetModel targetModel, TargetView targetView, GameObject spawner)
    {
        _targetModel = targetModel;
        _targetModel.SetTargetController(this);

        _targetView = GameObject.Instantiate<TargetView>(targetView);
        _targetView.SetTargetController(this);

        _targetView.gameObject.transform.SetParent(spawner.transform);
        _targetView.gameObject.transform.transform.localPosition = Vector3.zero;
        _targetView.gameObject.transform.localRotation = Quaternion.identity;
        _targetView.gameObject.transform.localScale = Vector3.one;

        _targetView.SetImage(_targetModel.GetTargetSprite());
    }

    public Transform GetTarget()
    {
        return _targetModel.GetTarget();
    }
    public Vector3 GetOffset()
    {
        return _targetModel.GetOffset();
    }

}
