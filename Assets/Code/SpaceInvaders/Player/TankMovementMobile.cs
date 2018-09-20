using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class TankMovementMobile : MonoBehaviour {
    [SerializeField]
    private float _moveRate;
    public float MoveRate
    {
        get { return _moveRate; }
        set { _moveRate = value; }
    }
    [SerializeField]
    private Vector2 _axisInput;
    public Vector2 AxisInput
    {
        get
        {
            _axisInput.Set(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
            return _axisInput;
        }
        private set { _axisInput = value; }
    }

    private void Update()
    {
        transform.Translate(AxisInput * Time.deltaTime * MoveRate);
    }
}
