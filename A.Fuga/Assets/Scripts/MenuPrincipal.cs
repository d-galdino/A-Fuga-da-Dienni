using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
    public void Sair()
    {
        Debug.Log("Saiu :D");
        Application.Quit();
    }

    public void Jogar()
    {
        SceneManager.LoadScene("JogoF1");
    }
}
