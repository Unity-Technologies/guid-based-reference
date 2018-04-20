using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    [System.Serializable]
    public struct SceneInfo
    {
        public string name;
        public bool shouldLoad;
    }

    public List<SceneInfo> scenes = new List<SceneInfo>();

	// Update is called once per frame
	void Update ()
    {
		foreach( var info in scenes )
        {
            Scene scene = SceneManager.GetSceneByName(info.name);
            if (info.shouldLoad && !scene.isLoaded)
            {
                SceneManager.LoadScene(info.name, LoadSceneMode.Additive);
            }

            if (!info.shouldLoad && scene.isLoaded)
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
	}
}
