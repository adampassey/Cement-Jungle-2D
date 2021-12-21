using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    //  editor associations
    public static PlayerData Instance;
    public Text resource_text;

    public static Sprite SelectedBuildingSprite;

    //  buildings
    public static int buildings = 0;

    //  resources
    public int resources {
        get { return _resources; }
        set {
            _resources = value;
            UpdateResourceLabel();
        }
    }

    private int _resources = 10;

    void Start()
    {
        Instance = this;

        if (resource_text == null) {
            Debug.LogError("PlayerData requires resource_text to be associated");
        }
    }

    private void UpdateResourceLabel() {
        resource_text.text = "Resources: " + resources.ToString();
    }
}
