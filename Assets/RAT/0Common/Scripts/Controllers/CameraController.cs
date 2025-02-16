using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.Default;

    [SerializeField]
    Vector3 _delta = new Vector3 (0, 0, 0);

    [SerializeField]
    GameObject _player;

    void Start()
    {

    }

    void LateUpdate()
    {
        if (_mode == Define.CameraMode.Chapter)
        {
            transform.position = _player.transform.position + _delta;
            transform.LookAt(_player.transform);
        }
        else if (_mode == Define.CameraMode.Map)
        {

        }
    }

    public void SetDefaultView(Vector3 delta)
    {
        _mode = Define.CameraMode.Default;
        _delta = delta;
    }

    public void SetChapterView(Vector3 delta)
    {
        _mode = Define.CameraMode.Chapter;
        _delta = delta;
    }

    public void SetMapView(Vector3 delta)
    {
        _mode = Define.CameraMode.Map;
        _delta = delta;
    }
}
