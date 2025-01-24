using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    private TargetView _targetView;

    [SerializeField]
    private MarkerUI _markerUIObj;

    [System.Serializable]
    public class TargetMarkers
    {
        public TargetTypes targetType;
        public Sprite img;
        public Transform target;
        public Vector3 offset;
    }

    [SerializeField]
    private List<TargetMarkers> _targetMarkerList;

    public void CreateTargets(TargetTypes targetType)
    {
        for (int i = 0; i < _targetMarkerList.Count; i++)
        {
            TargetMarkers targetMarker = _targetMarkerList[i];

            if (targetMarker != null)
            {
                TargetModel targetModel = new TargetModel(
                    targetMarker.targetType,
                    targetMarker.img,
                    targetMarker.target,
                    targetMarker.offset

                );


                TargetController targetController = new TargetController(targetModel, _targetView, this.gameObject);
            }
            else
            {
                Debug.Log("Tank data not found");
            }
            _markerUIObj.SetTargetList();
        }

    }

}
