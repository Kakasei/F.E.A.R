using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameMusic : MonoBehaviour
{
    private static gameMusic instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        Scene scene1 = SceneManager.GetActiveScene();
        Scene scene2 = SceneManager.GetSceneByName("mainScene");
        GameObject obj = GameObject.Find("Music");
        if (scene1 == scene2)
        {
            Destroy(obj);
            Debug.Log("Ïú»Ù¿ª³¡ÒôÀÖ");
        }
    }

}
