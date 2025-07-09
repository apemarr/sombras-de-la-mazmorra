using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameObject sueloPrefab;
    public int cantidadBloquesX = 14;
    public int cantidadBloquesY = 10;
    public float anchoBloque = 1f;
    public float altoBloque = 1f;

    public Vector2 posicionInicial = new Vector2(-6.14f, 4.52f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int y = 0; y < cantidadBloquesY; y++)
        {
            for (int x = 0; x < cantidadBloquesX; x++)
            {
                Vector3 posicion = new Vector3(
                    posicionInicial.x + x * anchoBloque,
                    posicionInicial.y - y * altoBloque,
                    0 
                );
                Instantiate(sueloPrefab, posicion, Quaternion.identity);
            }  
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
