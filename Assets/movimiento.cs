using UnityEngine;
using TMPro;
//al final este codigo no solo maneja movimiento pero ps ya no le puedo cambiar el nombre
public class movimiento : MonoBehaviour
{
    public int contador_coleccionables = 0;
    public int coleccionables_total = 32;
    public TextMeshProUGUI contador_mostrado;
    //valor por defecto del checkP (-0.1375f, 2.8f, 4.25f). Dejado en público para evitar tener que pasar todos los tableros a la hora d probar 1
    //valor del tablero 6 (-0.06f, 16.293f, -75.93f)
    private Vector3 checkP = new Vector3(-0.1375f, 2.8f, 4.25f);



    private Rigidbody rg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // se asocia rg con el rigidbody que le pusimos al objeto al principio!!
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //no se ocupa pq no sirve bien para 3d
    void Update()
    {
        
    }
    // se ocupa ese
    // horizontal = lados
    // vertical = delante y detrás
    private void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        //vector 3
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV)*10;
        //0,0f es movimiento en eje Y. No se toca pq si no hacemos volar la pelota
        // el 10 es la velocidad
        rg.AddForce(movimiento);

    }
    private void ActualizarContador()
    {
        contador_mostrado.text = "Coleccionables: " + contador_coleccionables + " / " + coleccionables_total;
    }

    //para detectar colisiones.

    private void OnCollisionEnter(Collision choque)
    {
        if(choque.gameObject.CompareTag("moneda"))
        {
            Destroy(choque.gameObject);
            contador_coleccionables++;
            ActualizarContador();
            if(contador_coleccionables >= coleccionables_total)
            {
                contador_mostrado.text = "Recolectaste todas las monedas!";
            }
        }

        if(choque.gameObject.CompareTag("infierno"))
        {
            rg.position = checkP;
            rg.linearVelocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }

        if(choque.gameObject.CompareTag("checkpoint"))
        {
            checkP = choque.transform.position + Vector3.up * 1f; //eso ultimo era pq el coso salia volando al respawnear
        }

    }
}

