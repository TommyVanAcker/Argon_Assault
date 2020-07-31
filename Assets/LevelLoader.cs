using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    static GameObject myGameObject;

    float loadDelay = 5f;

    private void Awake()
    {
        if (!myGameObject)
        {
            myGameObject = this.gameObject;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadGameScene());
        
    }

    IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(loadDelay);
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
        
    }
}
