using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class TestManager : MonoBehaviour
{
    public TMP_Text textoIntroduccion;
    public TMP_Text textoPregunta;
    public TMP_InputField inputRespuesta;
    public Button botonComprobar;
    public TMP_Text textoResultado;

    private string[] preguntas;
    private string[] respuestas;
    private int indice = 0;
    private int puntuacion = 0;

    private Transform posicionCampoRespuesta;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textoPregunta.fontMaterial.SetColor("_OutlineColor", Color.black);
        textoPregunta.gameObject.SetActive(false);
        inputRespuesta.gameObject.SetActive(false);
        textoResultado.gameObject.SetActive(false);

        preguntas = new string[]{
            "1.El apellido de Tharion es Vientoscuro. (V/F)",
            "2.Tharion es hijo de un herrero y una panadera. (V/F)",
            "3.Tharion encontró en los restos de un campamento un medallón. (V/F)",
            "4.Tharion tuvo visiones de una mazmorra llamada Ithral-tuun. (V/F)",
            "5.Tharion después de despedirse de una bibliotecaria partió hacia la aventura sin la ayuda de un mapa. (V/F)",
            "6.El medallón le permitió a Tharion abrir la trampilla de la mazmorra. (V/F)",
            "7.En la mazmorra Tharion se encontró con goblins. (V/F)"
        };

        respuestas = new string[]{
            "V",
            "F",
            "V",
            "V",
            "F",
            "V",
            "F"
        };

        botonComprobar.onClick.AddListener(Empezar);
        posicionCampoRespuesta = inputRespuesta.GetComponent<Transform>();
    }

    void Empezar()
    {
        botonComprobar.GetComponentInChildren<TextMeshProUGUI>().text = "Comprobar";

        textoIntroduccion.gameObject.SetActive(false);
        textoPregunta.gameObject.SetActive(true);
        inputRespuesta.gameObject.SetActive(true);

        textoPregunta.text = preguntas[indice];

        botonComprobar.onClick.RemoveListener(Empezar);
        botonComprobar.onClick.AddListener(Comprobar);
    }

    void Comprobar()
    {
        if (inputRespuesta.text.ToUpper() == respuestas[indice])
        {
            textoResultado.text = "Correcto!";
            puntuacion++;
        }
        else
        {
            textoResultado.text = "Incorrecto";
        }
        textoResultado.gameObject.SetActive(true);

        StartCoroutine(CambiarDespuesDeTiempo());
    }

    IEnumerator CambiarDespuesDeTiempo()
    {
        yield return new WaitForSeconds(2f);
        
        indice ++;
        if (indice < preguntas.Length)
        {
            textoPregunta.text = preguntas[indice];
            inputRespuesta.text = "";
            textoResultado.text = "";
        }
        else
        {
            textoPregunta.gameObject.SetActive(false);
            inputRespuesta.gameObject.SetActive(false);
            textoResultado.gameObject.SetActive(false);
            botonComprobar.gameObject.SetActive(false);

            textoIntroduccion.GetComponent<Transform>().position = posicionCampoRespuesta.position;
            textoIntroduccion.gameObject.SetActive(true);
            
            textoIntroduccion.text = $"Fin de la partida. Has sacado una puntuación de {puntuacion}/{preguntas.Length}";
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
