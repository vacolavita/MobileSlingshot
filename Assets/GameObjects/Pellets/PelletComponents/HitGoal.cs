using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitGoal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            string scene = other.gameObject.GetComponent<LevelManager>().nextLevel;
            if (scene != "Placeholder") {
                SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Single);
            }
        }
    }
}
