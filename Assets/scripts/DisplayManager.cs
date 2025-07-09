using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayManager : MonoBehaviour
{
    public TMP_Text texto;
    public TMP_Text textoIntroduccion;
    public TMP_Text textoOpciones;
    public Button botonAvanzar;
    public Button botonRetroceder;
    public Button botonIrPuertaIzquierda;
    public Button botonIrPuertaDerecha;
    public Image imagen;
    private string[] parrafos = new string[]{
        "En el reino fragmentado de Velmaris, entre tierras marchitas y bosques que murmuran nombres olvidados, nació Tharion Vientoscuro, hijo de un mercenario y una herborista del norte. Desde joven aprendió a sobrevivir entre acero y secretos, destacándose como rastreador y explorador para caravanas que cruzaban rutas peligrosas.",
        "Pero Tharion no era solo un aventurero cualquiera. A los 17 años, encontró entre los restos de un campamento arrasado un medallón negro de ónice, grabado con un símbolo que nadie supo identificar. Desde entonces, comenzó a tener sueños: visiones de una puerta sellada bajo tierra, de un fuego azul que no quemaba, y de una voz que lo llamaba por su nombre… una voz que conocía su pasado mejor que él mismo.",
        "Pasaron los años y las visiones se intensificaron. En una de ellas, la voz le susurró un nombre: Mazmorra de Ithral-Tuun, un lugar prohibido en las Montañas Negras, donde según las leyendas, se guardan las promesas rotas de antiguos reyes. Muchos la buscaban por oro o poder. Tharion, en cambio, sentía que algo suyo le había sido robado y lo esperaba allí dentro.",
        "Después de despedirse de la única persona en quien confiaba -una vieja bibliotecaria que lo crió como a un nieto-, Tharion partió al amanecer, siguiendo los fragmentos de un mapa antiguo que solo él parecía entender.",
        "Al llegar al pie de la montaña, encontró lo que parecía una capilla en ruinas. Bajo ella, escondida por raíces y piedra, una trampilla de hierro oxidado se abrió con el medallón. Una ráfaga de aire seco y antiguo escapó del hueco.",
        "Tharion Vientoscuro descendió sin mirar atrás. La oscuridad lo envolvió… y la mazmorra cerró sus fauces.",
        "Cuando sus pies tocaron el suelo de la primera cámara, un eco respondió a su presencia. La sala era vasta, con columnas partidas y tapices rotos que aún colgaban como jirones de recuerdos. El medallón de ónice en su pecho empezó a calentarse levemente, como si algo cercano lo reconociera.",
        "Avanzó con cautela, pero no llegó muy lejos antes de que los sonidos lo detuvieran: un crujido, el roce de huesos contra piedra. Desde las sombras, figuras se alzaron. Esqueletos, armados con herrumbre y ojos vacíos, pero decididos, como si la muerte no hubiera logrado arrancarles su voluntad.",
        "Tharion retrocedió, desenvainando su cuchillo de acero. El primero en atacarlo recibió un tajo que solo lo ralentizó: el arma mordía hueso, pero no lo destruía. Sabía que estaba perdido si no encontraba algo más útil.",
        "El crujir de los huesos avanzando resonaba como una marcha de muerte. Tharion sabía que no podía enfrentarlos con solo su cuchillo. Retrocedió hacia una columna caída, usándola como cobertura mientras su mente buscaba una salida. El medallón seguía ardiendo levemente, pulsando como un corazón acelerado. Entonces, algo más lo guió: una corriente de aire, tenue, distinta del aire estancado de la mazmorra.",
        "La siguió. Rodó por el suelo y se levantó frente a un altar derruido, donde un haz de luz azulada filtrado desde alguna grieta iluminaba una espada clavada en piedra. No era un arma común: su hoja, aunque cubierta de polvo, no mostraba signo de óxido. Tenía runas grabadas a lo largo del filo, y el pomo estaba adornado con una piedra que emitía un tenue resplandor... del mismo tono que las llamas de sus sueños.",
        "Tharion extendió la mano y la espada salió de la piedra sin resistencia, como si lo hubiera estado esperando.",
        "Al instante, un destello azul recorrió la hoja y se encendió una llama fría a lo largo del filo. Los esqueletos emitieron un sonido gutural, mezcla de temor y rabia. Tharion no esperó. Con un grito, se lanzó contra ellos. Esta vez, cuando la hoja de la espada cortó, los huesos estallaron en polvo, como si la magia que los sostenía fuera purgada por la llama.",
        "Entonces lo vio: al fondo de la sala, tras los restos del combate, un cofre empotrado en la pared, cubierto de telarañas y cadenas rotas. La espada brilló débilmente al acercarse, y las cerraduras del cofre se soltaron solas. Dentro, sobre terciopelo raído, descansaba una llave de hueso tallada con el mismo símbolo que su medallón.",
        "Con la espada envainada en su espalda y la llave firmemente en la mano, vió dos puertas grandes de piedra. Escoge a qué puerta ir:"
    };

    private Sprite[] imagenes;

    private int indice = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imagenes = new Sprite[] {
            Resources.Load<Sprite>("Images/castillo"),
            Resources.Load<Sprite>("Images/campamento"),
            Resources.Load<Sprite>("Images/mazmorra"),
            Resources.Load<Sprite>("Images/mapa"),
            Resources.Load<Sprite>("Images/capilla"),
            Resources.Load<Sprite>("Images/entrada_mazmorra"),
            Resources.Load<Sprite>("Images/medallon"),
            Resources.Load<Sprite>("Images/esqueleto"),
            Resources.Load<Sprite>("Images/daga"),
            Resources.Load<Sprite>("Images/aire"),
            Resources.Load<Sprite>("Images/espada"),
            Resources.Load<Sprite>("Images/coger_espada"),
            Resources.Load<Sprite>("Images/explosion"),
            Resources.Load<Sprite>("Images/cofre"),
            Resources.Load<Sprite>("Images/puerta")
        };
        imagen.gameObject.SetActive(false);
        texto.gameObject.SetActive(false);
        botonRetroceder.gameObject.SetActive(false);
        textoOpciones.gameObject.SetActive(false);
        botonIrPuertaDerecha.gameObject.SetActive(false);
        botonIrPuertaIzquierda.gameObject.SetActive(false);

        botonAvanzar.GetComponentInChildren<TextMeshProUGUI>().text = "Empezar";
        botonAvanzar.onClick.AddListener(Empezar);
        botonRetroceder.onClick.AddListener(Retroceder);
        botonIrPuertaDerecha.onClick.AddListener(CambiarEscenaPuertaDerecha);
        botonIrPuertaIzquierda.onClick.AddListener(CambiarEscenaPuertaIzquierda);
    }

    void Empezar()
    {
        textoIntroduccion.gameObject.SetActive(false);
        botonAvanzar.GetComponentInChildren<TextMeshProUGUI>().text = "Avanzar";

        imagen.gameObject.SetActive(true);
        texto.gameObject.SetActive(true);

        texto.text = parrafos[0];
        imagen.GetComponent<Image>().sprite = imagenes[0]; 

        botonAvanzar.onClick.RemoveListener(Empezar);
        botonAvanzar.onClick.AddListener(Avanzar);
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
            botonIrPuertaDerecha.gameObject.SetActive(true);
            botonIrPuertaIzquierda.gameObject.SetActive(true);
            textoOpciones.gameObject.SetActive(true);
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

    void CambiarEscenaPuertaDerecha()
    {
        SceneSwitcher.CambiarEscena("PuertaDerechaScene");
    }

    void CambiarEscenaPuertaIzquierda()
    {
        SceneSwitcher.CambiarEscena("PuertaIzquierdaScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
