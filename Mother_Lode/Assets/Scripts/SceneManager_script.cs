using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_script : MonoBehaviour
{
    public List<Action_script> Timeline = new List<Action_script>();

    private bool _finished = false;

    private void Update()
    {
        if (!_finished)
        {
            foreach (var item in Timeline)
            {
                item.Act();
            }

            _finished = true;
        }
    }
}
