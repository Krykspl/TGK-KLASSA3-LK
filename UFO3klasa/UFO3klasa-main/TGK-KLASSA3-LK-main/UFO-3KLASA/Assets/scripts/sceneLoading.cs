using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class sceneLoading : MonoBehaviour
{
   public void LoadStartScene()
    {
        SceneManager.LoadScene(1);
    }

  public  void LoadNextScene()
    {
        int currentindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentindex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
