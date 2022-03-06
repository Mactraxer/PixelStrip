using UnityEngine;
using System.Collections;

public class GunFire : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private Transform _spawnBallTransform;
    [SerializeField] private float _force;
    [SerializeField] private float _maxCharge;
    [SerializeField] private float _chargeSpeed;
    [SerializeField] private float _chargeTickPerSeconds;
    private float _currentCharge;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CoroutineStartCharge());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopAllCoroutines();
            Fire(_currentCharge);
            _currentCharge = 0;
        }
    }

    private void Fire(float charge)
    {
        var instantiatedBall = Instantiate(_ball, _spawnBallTransform.position, _spawnBallTransform.rotation);
        Rigidbody rigidbodyComponent;

        if (instantiatedBall.TryGetComponent<Rigidbody>(out rigidbodyComponent))
        {
            instantiatedBall.transform.LookAt(_spawnBallTransform.position);
            rigidbodyComponent.AddRelativeForce(Vector3.right * (_force + charge), ForceMode.Impulse);
        }
        else
        {
            new System.Exception("Ball haven't rigidbody component");
        }
    }

    private IEnumerator CoroutineStartCharge()
    {
        var waitForSeconds = new WaitForSeconds(_chargeTickPerSeconds);

        while (_currentCharge != _maxCharge)
        {
            _currentCharge += _chargeSpeed;

            yield return waitForSeconds;
        }
    }

}
