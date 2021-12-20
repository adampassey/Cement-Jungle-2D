using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticker : MonoBehaviour
{
    public float tick_frequency = 0.25f; // in seconds
    public int base_resource_value = 10;

    private float _last_tick = 0f;
    private PlayerData _data;

    // Start is called before the first frame update
    void Start()
    {
        _last_tick = Time.timeSinceLevelLoad;
        _data = PlayerData.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (_last_tick + tick_frequency < Time.timeSinceLevelLoad) {
            AddResources();
            _last_tick = Time.timeSinceLevelLoad;
        }
    }

    private void AddResources() {
        Debug.Log("Adding resources");
        _data.resources += base_resource_value;
    }
}
