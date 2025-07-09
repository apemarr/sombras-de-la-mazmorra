using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static void CambiarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
