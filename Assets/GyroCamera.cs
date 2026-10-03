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
            Quaternion q = gyro.attitude;
            // convierte del sistema del dispositivo al de Unity
            // esta corrección fue hecha por Claude
            // una vez agregadas estas funciones la cámara miraba al piso y se iba debajo de los tableros
            Quaternion convertido = new Quaternion(q.x, q.y, -q.z, -q.w);
            // Gira 90° en X para que el teléfono "de pie" signifique mirar al frente
            transform.localRotation = Quaternion.Euler(90f, 0f, 0f) * convertido;
        }
    }
}
