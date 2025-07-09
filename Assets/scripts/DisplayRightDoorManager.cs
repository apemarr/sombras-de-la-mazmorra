using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayRightDoorManager : MonoBehaviour
{
    public TMP_Text texto;
    public Image imagen;
    public Button botonAvanzar;
    public Button botonRetroceder;
    public Button botonCambiarEscenaTest;

    private string[] parrafos = new string[]{
        "Tharion eligió la puerta de la derecha. No encontró trampas ni enemigos, solo un silencio antiguo y antorchas de llama azul que lo guiaron hasta una sala circular.",
        "Allí lo esperaba una figura espectral: el espíritu de su madre. Le reveló que el medallón era parte de un pacto ancestral y que su destino iba más allá del tesoro.",
        "Antes de desvanecerse, ella le otorgó una bendición mágica y un recuerdo perdido de su infancia.",
        "Tharion salió sin oro… pero con una verdad más valiosa: él era la clave para restaurar lo que Velmaris había olvidado."
    };

    private Sprite[] imagenes;
    private int indice = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imagenes = new Sprite[]{
            Resources.Load<Sprite>("Images/antorcha"),
            Resources.Load<Sprite>("Images/madre"),
            Resources.Load<Sprite>("Images/recuerdos"),
            Resources.Load<Sprite>("Images/bolsillos_vacios")
        };

        texto.text = parrafos[0];
        imagen.GetComponent<Image>().sprite = imagenes[0];

        botonRetroceder.gameObject.SetActive(false);
        
        botonAvanzar.onClick.AddListener(Avanzar);
        botonRetroceder.onClick.AddListener(Retroceder);
        botonCambiarEscenaTest.onClick.AddListener(CambiarEscenaTest);
    }

     void Avanzar()
    {
        if (indice >= parrafos.Length - 1) return;
        indice++;
        if (indice == 1)
        {
            botonRetroceder.gameObject.SetActive(true);
        }

        if (indice < parrafos.Length)
        {
            MostrarContenido();
        }

        if (indice == parrafos.Length - 1)
        {
            botonCambiarEscenaTest.gameObject.SetActive(true);
        } 
    }

    void Retroceder()
    {
        if (indice > 0)
        {
            indice--;
            MostrarContenido();
        }
    }

     void MostrarContenido()
    {
        texto.text = parrafos[indice];
        imagen.GetComponent<Image>().sprite = imagenes[indice];
    }


    void CambiarEscenaTest()
    {
        SceneSwitcher.CambiarEscena("TestScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
