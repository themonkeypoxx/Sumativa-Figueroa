using UnityEngine;

public class EnemigoVolador : MonoBehaviour
{
    public Vector3 PosInicial;
    public float velocidadMovimiento = 3f;
    public float distancia = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       PosInicial = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        //se supone que pingpong hace que los valores de la posición oscilen en 3 unidades (como un pendulo)¿
        float movimiento = Mathf.PingPong(Time.time * velocidadMovimiento, distancia);
        transform.position = new Vector3(PosInicial.x, PosInicial.y + movimiento, PosInicial.z);
    }  
    
}
