using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MatchTile.Base;

namespace MatchTile.Tile
{
    public class TileObject : MonoBehaviour, IRaycastable
    {
        [Header("Properties")]
        [SerializeField] private int id;

        private bool isSelected = false;

        public static UnityAction<int> onTileSelected;

        public void OnRaycastHit()
        {
            Debug.Log(gameObject.name);
            isSelected = true;
            onTileSelected?.Invoke(id);
        }

        public void UnSelected()
        {
            isSelected = false;
        }
    }
}

