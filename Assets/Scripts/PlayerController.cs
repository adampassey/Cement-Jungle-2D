using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public Tilemap tilemap;
    public Sprite CementSprite;
    public GameObject BuildingPrefab;

    private static readonly int LEFT_BUTTON = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(LEFT_BUTTON)) {
            Vector3Int pos = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //  reset z otherwise it defaults to camera z, and no tiles will match
            pos.z = 0;
            Tile tile = tilemap.GetTile<Tile>(pos);

            if (tile == null) {
                return;
            }

            //  set to cement tile
            Tile new_tile = ScriptableObject.CreateInstance<Tile>();
            new_tile.sprite = CementSprite;
            tilemap.SetTile(pos, new_tile);

            //  add building
            GameObject building = GameObject.Instantiate(BuildingPrefab);
            building.transform.position = tilemap.CellToWorld(pos);

            //  TODO: sprite renderer based on pos
            //  TODO: update sprite to be current building

            PlayerData.buildings += 1;
        }
    }
}
