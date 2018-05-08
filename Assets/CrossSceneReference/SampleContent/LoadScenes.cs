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

    // a little User Interface 
    private void OnGUI()
    {
        // this code is a great example of how NOT to write Unity code

        Vector2 padding = new Vector2(5.0f, 5.0f);
        Vector2 buttonSize = new Vector2(150.0f, 50.0f);
        Rect buttonPosition = new Rect(padding, buttonSize);

        for ( int i = 0; i < scenes.Count; ++i )
        {
            // PER FRAME ALLOCATION HERE
            string buttonText = scenes[i].name;
            buttonText += scenes[i].shouldLoad ? " : Unload" : " : Load";

            if (GUI.Button(buttonPosition, buttonText))
            {
                // UGH! Lists mean I can't modify scenes[i].shouldLoad directly! I guess make an awkward copy and then set =/
                SceneInfo newInfo = scenes[i];
                newInfo.shouldLoad = !newInfo.shouldLoad;
                scenes[i] = newInfo;
            }

            buttonPosition.y += buttonSize.y + padding.y;
        }
    }
}
