using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickInput : MonoBehaviour
{
    [SerializeField] private PlayerNavMover _playerNavMover;
    [SerializeField] private LayerMask _layerGroundMask;
    [SerializeField] private float _maxRayDistance = 100f;
    [SerializeField] private ClickMarker _clickMaker;
    private Camera _camera;
    private const int LeftMouseButton = 0;
    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            Ray ray = GetMouseRay();
            if (Physics.Raycast(ray, out RaycastHit hit, _maxRayDistance, _layerGroundMask))
            {
              _playerNavMover.MoveTo(hit.point);
                _clickMaker.ShowAt(hit.point);
            }
        }
    }

    private Ray GetMouseRay()
    {
        return _camera.ScreenPointToRay(Input.mousePosition);
    }
}
