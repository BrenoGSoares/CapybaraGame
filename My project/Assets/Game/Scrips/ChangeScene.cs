using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Nome da cena para a qual você deseja trocar
    public string sceneToLoad;


    // Método chamado quando o botão (ou outro objeto) é clicado
    public void OnChangeSceneButtonClick()
    {
        // Chama a função para trocar de cena
        ChangeSceneFunction();
    }
    // Função para trocar de cena
    private void ChangeSceneFunction()
    {
        // Carrega a cena especificada
        SceneManager.LoadScene(sceneToLoad);
    }
}
