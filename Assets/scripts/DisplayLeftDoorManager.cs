using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayLeftDoorManager : MonoBehaviour
{
    public TMP_Text texto;
    public TMP_Text textoOpciones;
    public Image imagen;
    public Button botonAvanzar;
    public Button botonAvanzarEleccion;
    public Button botonRetroceder;
    public Button botonRetrocederEleccion;
    public Button botonSellar;
    public Button botonDespertar;
    public Button botonCambiarEscenaTest;

    private string[] parrafos = new string[]{
        "Tharion eligió la puerta de la izquierda. El pasillo que siguió estaba plagado de trampas antiguas y guardianes de piedra. Con su espada de fuego azul, logró abrirse paso, aunque salió herido y exhausto.",
        "Al final, encontró una sala con un trono derrumbado y cofres sellados. Usó la llave de hueso y halló el tesoro de Ithral-Tuun: una gema mágica, un pergamino con el nombre de su padre, y un anillo que hablaba de recuerdos perdidos.",
        "Pero cuando se giró para marcharse, el suelo se quebró bajo sus pies.",
        "Cayó. Y despertó más abajo, en una cámara que nadie había cartografiado...donde algo lo esperaba desde hacía siglos.",
        "La cámara era una sala antigua cubierta de murales que reflejaban su propia historia, encontró una figura misteriosa: el guardián final, una entidad atrapada entre mundos.",
        "El guardián reveló que Tharion es hijo de uno de los Custodios de la Brecha, y que su padre lo había protegido del destino que ahora lo alcanzaba. La gema que Tharion lleva es un fragmento del Ojo, un artefacto poderoso que su padre había ayudado a sellar.",
        "El guardián desapareció tras advertirle que debía tomar una decisión crucial: sellar nuevamente el Ojo... o despertarlo. Tomar la decisión de despertar el Ojo o sellarlo:"
    };

    private string[] parrafosSellar = new string[]{
        "Tharion extendió la espada. No para despertar el Ojo, sino para atravesarlo. La hoja azul cortó la gema con un destello seco. No explotó, no gritó. Solo se apagó, como una vela al final de su mecha. Fragmentos del Ojo cayeron al suelo como vidrio muerto.",
        "La cámara tembló. Pero no colapsó. Se disipó.",
        "Tharion se encontró de pie en una llanura fría bajo un cielo gris, lejos de la mazmorra, lejos de los ecos del pasado. En su cinturón, la espada aún brillaba suavemente, aunque su fuego azul nunca volvió a ser el mismo."
    };

    private string[] parrafosDespertar = new string[]{
        "Tharion no duda. Rechaza el miedo, rechaza huir, y elige aceptar su destino.",
        "Al tocar el Ojo, una explosión de llama azul lo envuelve. Su espada cambia: ya no es solo mágica, sino algo nuevo, más oscuro y poderoso. Tharion se transforma. Ya no es solo un aventurero, sino el Portador del Ojo Despierto, vinculado a fuerzas antiguas que ahora comienzan a reactivarse en el mundo.",
        "Su elección despierta un poder sellado durante siglos… y marca el inicio de un cambio que el mundo no está preparado para enfrentar."
    };

    private Sprite[] imagenes;
    private Sprite[] imagenesEleccionSellar;
    private Sprite[] imagenesEleccionDespertar;

    private int indice = 0;
    private int indiceEleccion = 0;
    private bool eleccionSellar = false;
    private bool eleccionDespertar = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        botonRetroceder.gameObject.SetActive(false);
        botonCambiarEscenaTest.gameObject.SetActive(false);
        botonDespertar.gameObject.SetActive(false);
        botonSellar.gameObject.SetActive(false);
        textoOpciones.gameObject.SetActive(false);
        botonAvanzarEleccion.gameObject.SetActive(false);
        botonRetrocederEleccion.gameObject.SetActive(false);


        imagenes = new Sprite[]{
            Resources.Load<Sprite>("Images/trampa"),
            Resources.Load<Sprite>("Images/gema"),
            Resources.Load<Sprite>("Images/suelo"),
            Resources.Load<Sprite>("Images/caer"),
            Resources.Load<Sprite>("Images/guardian"),
            Resources.Load<Sprite>("Images/ojo"),
            Resources.Load<Sprite>("Images/elegir_sellar_despertar")
        };

        imagenesEleccionSellar = new Sprite[]{
            Resources.Load<Sprite>("Images/vela"),
            Resources.Load<Sprite>("Images/disipar"),
            Resources.Load<Sprite>("Images/llanura")
        };

        imagenesEleccionDespertar = new Sprite[]{
            Resources.Load<Sprite>("Images/leon"),
            Resources.Load<Sprite>("Images/transformar"),
            Resources.Load<Sprite>("Images/guerra")
        };

        texto.text = parrafos[0];
        imagen.GetComponent<Image>().sprite = imagenes[0];

        botonAvanzar.onClick.AddListener(Avanzar);
        botonRetroceder.onClick.AddListener(Retroceder);
        botonSellar.onClick.AddListener(() => QuitarAvanzar(botonSellar));
        botonDespertar.onClick.AddListener(() => QuitarAvanzar(botonDespertar));
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
            botonDespertar.gameObject.SetActive(true);
            botonSellar.gameObject.SetActive(true);
            textoOpciones.gameObject.SetActive(true);
        } 
    }

    void Retroceder()
    {
        if (eleccionSellar && indiceEleccion > 0)
        {
            indiceEleccion--;
            MostrarContenido();
        }
        else if (eleccionDespertar && indiceEleccion > 0)
        {
            indiceEleccion--;
            MostrarContenido();
        }
        else if (indice > 0 && !eleccionSellar && !eleccionDespertar)
        {
            indice--;
            MostrarContenido();
        }
    
    }

    void MostrarContenido()
    {
        if (eleccionSellar)
        {
            texto.text = parrafosSellar[indiceEleccion];
            imagen.GetComponent<Image>().sprite = imagenesEleccionSellar[indiceEleccion];
        }
        else if (eleccionDespertar)
        {
            texto.text = parrafosDespertar[indiceEleccion];
            imagen.GetComponent<Image>().sprite = imagenesEleccionDespertar[indiceEleccion];
        }
        else
        {
            texto.text = parrafos[indice];
            imagen.GetComponent<Image>().sprite = imagenes[indice];  
        }   
    }

    void AvanzarEleccionSellar()
    {
        if (indiceEleccion >= parrafosSellar.Length - 1) return;
        indiceEleccion++;
        if (indiceEleccion == 1)
        {
            botonRetrocederEleccion.gameObject.SetActive(true);
        }

        if (indiceEleccion < parrafosSellar.Length)
        {
            MostrarContenido();
        }

        if (indiceEleccion == parrafosSellar.Length - 1)
        {
            botonCambiarEscenaTest.gameObject.SetActive(true);
        } 
    }

    void AvanzarEleccionDespertar()
    {
        if (indiceEleccion >= parrafosDespertar.Length - 1) return;
        indiceEleccion++;
        if (indiceEleccion == 1)
        {
            botonRetrocederEleccion.gameObject.SetActive(true);
        }

        if (indiceEleccion < parrafosDespertar.Length)
        {
            MostrarContenido();
        }

        if (indiceEleccion == parrafosDespertar.Length - 1)
        {
            botonCambiarEscenaTest.gameObject.SetActive(true);
        } 
    }

    void QuitarAvanzar(Button boton)
    {
        if (boton.name == "botonSellar")
        {
            eleccionSellar = true;
            texto.text = parrafosSellar[0];
            imagen.GetComponent<Image>().sprite = imagenesEleccionSellar[0];
            botonSellar.gameObject.SetActive(false);
            botonDespertar.gameObject.SetActive(false);
            botonAvanzar.gameObject.SetActive(false);
            botonRetroceder.gameObject.SetActive(false);
            textoOpciones.gameObject.SetActive(false);
            botonAvanzarEleccion.gameObject.SetActive(true);
            botonAvanzarEleccion.onClick.AddListener(AvanzarEleccionSellar);
            botonRetrocederEleccion.onClick.AddListener(Retroceder);
        }

        if (boton.name == "botonDespertar")
        {
            eleccionDespertar = true;
            texto.text = parrafosDespertar[0];
            imagen.GetComponent<Image>().sprite = imagenesEleccionDespertar[0];
            botonSellar.gameObject.SetActive(false);
            botonDespertar.gameObject.SetActive(false);
            botonAvanzar.gameObject.SetActive(false);
            botonRetroceder.gameObject.SetActive(false);
            textoOpciones.gameObject.SetActive(false);
            botonAvanzarEleccion.gameObject.SetActive(true);
            botonAvanzarEleccion.onClick.AddListener(AvanzarEleccionDespertar);
            botonRetrocederEleccion.onClick.AddListener(Retroceder);
        }
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
