using UnityEngine;
public class VRSetup : MonoBehaviour
{
    public Camera camaraIzquierda;
    public Camera camaraDerecha;
    public float separacionOjos = 0.064f;
    void Start()
    {
        camaraIzquierda.transform.localPosition =
        new Vector3(-separacionOjos / 2, 0, 0);
        camaraDerecha.transform.localPosition =
        new Vector3(separacionOjos / 2, 0, 0);
        camaraIzquierda.rect =
        new Rect(0, 0, 0.5f, 1);
        camaraDerecha.rect =
        new Rect(0.5f, 0, 0.5f, 1);
    }
}
