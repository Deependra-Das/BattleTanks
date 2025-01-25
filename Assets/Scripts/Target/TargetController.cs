using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController 
{

    private TargetModel _targetModel;
    private TargetView _targetView;
    private TargetMarkerView _targetMarkerView;

    public TargetController(TargetModel targetModel, TargetView targetView, TargetMarkerView targetMarkerView, Canvas canvas)
    {
        _targetModel = targetModel;
        _targetModel.SetTargetController(this);

        _targetView = GameObject.Instantiate<TargetView>(targetView, GetTargetPosition(), Quaternion.Euler(GetTargetRotation()));
        _targetView.SetTargetController(this);

        _targetMarkerView = GameObject.Instantiate<TargetMarkerView>(targetMarkerView);
        _targetMarkerView.SetTargetController(this);

        _targetMarkerView.SetImage(_targetModel.GetTargetSprite());

        _targetMarkerView.SetCanvasAsParent(canvas);
    }

    public GameObject GetTargetObject()
    {
        return _targetModel.GetTargetObject();
    }
    public Vector3 GetTargetPosition()
    {
        return _targetModel.GetTargetPosition();
    }
    public Vector3 GetTargetRotation()
    {
        return _targetModel.GetTargetRotation();
    }

    public Vector3 GetTargetOffset()
    {
        return _targetModel.GetTargetOffset();
    }
    public void DisableMarker()
    {
        _targetMarkerView.DisableMarker();
    }
    public void EnableMarker()
    {
        _targetMarkerView.EnableMarker();
    }

}
