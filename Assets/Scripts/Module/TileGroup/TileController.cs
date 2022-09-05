using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MatchTile.Tile;

namespace MatchTile.TileGroup
{
    public class TileController : MonoBehaviour
    {
        [Header("Board")]
        [SerializeField] private Vector2 sizeBoard;
        [SerializeField] private Vector2 padding;
        private Vector2 startPos;
        private Vector2 endPos;

        [Header("Tiles")]
        [SerializeField] private List<TileObject> tiles = new List<TileObject>();
        [SerializeField] private List<TileObject> selectedTiles = new List<TileObject>();
        [SerializeField] private TileData[] tileData;
        private Vector2 tileSize;

        public int tileSelectedID;

        private void OnEnable()
        {
            TileObject.onTileSelected += SetTileSelected;
        }

        private void OnDisable()
        {
            TileObject.onTileSelected -= SetTileSelected;
        }

        private void Start()
        {
            Setup();
            GenerateBoard();
        }

        public void Setup()
        {
            GameObject[] prefabs = Resources.LoadAll<GameObject>("Prefabs");
            tileData = new TileData[prefabs.Length];
            for(int i = 0; i < prefabs.Length; i++)
            {
                TileData temp = tileData[i];
                temp.prefab = prefabs[i];
                temp.count = 6;
                tileData[i] = temp;
            }

            tileSize = tileData[0].prefab.GetComponent<SpriteRenderer>().size;
            Vector2 totalSize = (tileSize + padding) * (sizeBoard - Vector2.one);
            startPos = (Vector2)transform.position - (totalSize / 2);
            endPos = startPos + totalSize;
        }

        public void GenerateBoard()
        {
            for (int x = 0; x < sizeBoard.x; x++)
            {
                for (int y = 0; y < sizeBoard.y; y++)
                {
                    int rand = Random.Range(0, tileData.Length);

                    while (CheckMaxCount(rand))
                    {
                        rand = Random.Range(0, tileData.Length);
                    }
                    
                    TileObject tile = Instantiate(tileData[rand].prefab).GetComponent<TileObject>();
                    tiles.Add(tile);
                    
                    Vector2 pos = new Vector2(startPos.x + (tileSize.x + padding.x) * x, startPos.y + (tileSize.y + padding.y) * y);
                    tile.transform.position = pos;
                    tile.transform.SetParent(gameObject.transform);
                }
            }
        }

        public bool CheckMaxCount(int id)
        {
            int count = 0;
            foreach(var t in tiles)
            {
                if(t.GetID() == id)
                {
                    count++;
                    foreach(var td in tileData)
                    {
                        if (td.prefab.GetComponent<TileObject>().GetID() == id)
                        {
                            if (count > tileData[id].count) return true;
                        }
                    }
                }
            }

            return false;
        }

        public void SetTileSelected(int id, TileObject obj)
        { 
            if(tileSelectedID == 0)
            {
                tileSelectedID = id;
                selectedTiles.Add(obj);
            }
            else
            {
                if(id != tileSelectedID)
                {
                    ResetSelectionTile();
                }
                else
                {
                    selectedTiles.Add(obj);
                }
            }
        }

        public bool CheckMatch(int id)
        {
            foreach(var t in tiles)
            {
                if (t.isActiveAndEnabled)
                {
                    if (t.GetID() == id)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void ResetSelectionTile()
        {
            tileSelectedID = 0;
            foreach(var tile in tiles)
            {
                tile.UnSelected();
            }

            foreach(var st in selectedTiles)
            {
                selectedTiles.Remove(st);
            }
        }
    }

    [System.Serializable]
    public struct TileData
    {
        public GameObject prefab;
        public int count;
    }

    [System.Serializable]
    public struct TileCount
    {
        public int id;
        public int count;

        public TileCount(int _id, int _count)
        {
            id = _id;
            count = _count;
        }
    }
}
