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
        [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
        private Vector2 tileSize;

        private void Start()
        {
            Setup();
            GenerateBoard();
        }

        public void Setup()
        {
            tileSize = prefabs[0].GetComponent<SpriteRenderer>().size;
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
                    int rand = Random.Range(0, prefabs.Count);
                    TileObject tile = Instantiate(prefabs[rand]).GetComponent<TileObject>();
                    tiles.Add(tile);
                    Vector2 pos = new Vector2(startPos.x + (tileSize.x + padding.x) * x, startPos.y + (tileSize.y + padding.y) * y);
                    tile.transform.position = pos;
                    tile.transform.SetParent(gameObject.transform);
                }
            }
        }

    }

}
