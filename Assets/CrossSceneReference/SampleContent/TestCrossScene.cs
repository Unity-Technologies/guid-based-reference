using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class TestCrossScene : MonoBehaviour
{

    public GuidReference crossSceneReference = new GuidReference();
    private Renderer cachedRenderer;

    void Awake()
    {
        // set up a callback when the target is destroyed so we can remove references to the destroyed object
        crossSceneReference.OnGuidRemoved += ClearCache;
    }

	void Update () 
    {
        // simple example looking for our reference and spinning both if we get one.
        // due to caching, this only causes a dictionary lookup the first time we call it, so you can comfortably poll. 
        if (crossSceneReference.gameObject != null)
        {
            transform.Rotate(new Vector3(0, 1, 0), 10.0f * Time.deltaTime);

            if (cachedRenderer == null)
            {
                cachedRenderer = crossSceneReference.gameObject.GetComponent<Renderer>();
            }

            if (cachedRenderer != null)
            {
                cachedRenderer.gameObject.transform.Rotate(new Vector3(0, 1, 0), 10.0f * Time.deltaTime, Space.World);
            }

        }

        // added a performance test if you want to see. Most cost is in the profiling tags.
        //TestPerformance();
    }

    void ClearCache()
    {
        cachedRenderer = null;
    }

    void TestPerformance()
    {
        GameObject derefTest = null;

        for (int i = 0; i < 10000; ++i)
        {
            Profiler.BeginSample("Guid Resolution");
            derefTest = crossSceneReference.gameObject;
            Profiler.EndSample();
        }
        
    }
   
}
