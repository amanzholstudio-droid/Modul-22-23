using UnityEngine;

public class ClickMarker : MonoBehaviour
{
    [SerializeField] private GameObject _marker;

    private const float YHeight = 0.05f;

    public void ShowAt(Vector3 point)
    {
        Vector3 markerPosition = new Vector3(point.x, point.y + YHeight, point.z);
        _marker.transform.position = markerPosition;
        _marker.SetActive(true);
    }
}
