using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowManager_script : MonoBehaviour
{
    public List<SceneManager_script> Timeline = new List<SceneManager_script>();

    private int _index = 0;
    private bool _sceneStarted = false;

    private void Update()
    {
        if (_index < Timeline.Capacity)
        {
            if (!_sceneStarted)
            {
                _sceneStarted = true;
                Timeline[_index].AnimateScene();
            }
            else if (Timeline[_index].finished)
            {
                _sceneStarted = false;
                ++_index;
            }
        }
    }
}
