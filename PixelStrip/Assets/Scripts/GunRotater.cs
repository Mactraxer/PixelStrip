using UnityEngine;

public class GunRotater : MonoBehaviour
{

    [SerializeField] private GameObject _gun;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Vector3 _rotateOrigin;

    private void Start()
    {
        _rotateOrigin = _gun.transform.position - _rotateOrigin;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _gun.transform.RotateAround(_rotateOrigin, Vector3.forward, -_rotateSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _gun.transform.RotateAround(_rotateOrigin, Vector3.forward, _rotateSpeed);
        }
    }

}
