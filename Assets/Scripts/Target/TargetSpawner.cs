using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    private TargetView[] _targetViewList;

    [SerializeField]
    private TargetMarkerView _targetMarkerView;

    [SerializeField]
    private Canvas _canvasObj;

    [SerializeField]
    private Transform[] _targetAreaList;

    [System.Serializable]
    public class TargetMarkers
    {
        public TargetTypes targetType;
        public GameObject targetObject;
        public Sprite img;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 offset;
    }

    [SerializeField]
    private List<TargetMarkers> _targetMarkerList;

    public void CreateTargets()
    {
        for (int i = 0; i < _targetMarkerList.Count; i++)
        {
            TargetMarkers targetMarker = _targetMarkerList[i];
            TargetView _targetView = null;
            Transform _areaTransform = null;
            if (targetMarker != null)
            {
                TargetModel targetModel = new TargetModel(
                    targetMarker.targetType,
                    targetMarker.targetObject,
                    targetMarker.img,
                    targetMarker.position,
                    targetMarker.rotation,
                    targetMarker.offset
                );

                switch (targetMarker.targetType)
                {
                    case TargetTypes.OilStorage:
                        _targetView = _targetViewList[0];
                        _areaTransform = _targetAreaList[0];
                        break;
                    case TargetTypes.MilitaryBuilding:
                        _targetView = _targetViewList[1];
                        _areaTransform = _targetAreaList[1];
                        break;
                }
          
                TargetController targetController = new TargetController(targetModel, _targetView,_targetMarkerView, _areaTransform, _canvasObj);
            }
            else
            {
                Debug.Log("Tank data not found");
            }
    
        }

    }

}
