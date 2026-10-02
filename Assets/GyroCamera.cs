using UnityEngine;
public class GyroCamera : MonoBehaviour
{
private Gyroscope gyro;
private bool gyroActivo;
    void Start()
        {
            gyroActivo = SystemInfo.supportsGyroscope;
            if (gyroActivo)
                {
                gyro = Input.gyro;
                gyro.enabled = true;
                }
            }
    void Update()
        {
            if (gyroActivo)
                {
                transform.localRotation = gyro.attitude;
                }
        }
}

