using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchTile.Tile
{
    public class TileObject : MonoBehaviour
    {
        private Sprite image;

        public void SetImage(Sprite img)
        {
            image = img;
        }
    }
}

