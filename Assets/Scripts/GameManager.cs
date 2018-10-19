using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public int counter = 0;
    
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public void addPoint()
    {
        counter++;
        
    }
    public void Counter()
    {
        
     
        
    }


    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            FindObjectOfType<AudioManager>().Play("GameOver");
            Invoke("Restart", restartDelay);
        }

         
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }



}
