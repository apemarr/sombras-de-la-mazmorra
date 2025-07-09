using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public Button botonEmpezar;
    void Start()
    {
        botonEmpezar.onClick.AddListener(ChangeScene);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("HistoriaScene");
    }
}
