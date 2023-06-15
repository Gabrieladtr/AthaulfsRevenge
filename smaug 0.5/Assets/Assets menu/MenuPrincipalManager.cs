using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomelvl;
    [SerializeField] private GameObject painelInicial;
    [SerializeField] private GameObject painelOptions;

    public void Jogar()
    {
        SceneManager.LoadScene(nomelvl);
    }

    public void AbrirOpcoes()
    {
        painelInicial.SetActive(false);
        painelOptions.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelInicial.SetActive(true);
        painelOptions.SetActive(false);
    }

    public void SairJogo()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }
}
