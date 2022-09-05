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

        public static UnityAction<int, TileObject> onTileSelected;

        public void OnRaycastHit()
        {
            Debug.Log(gameObject.name);
            isSelected = true;
            SetActiveTile();
            onTileSelected?.Invoke(id, this);
        }

        public void UnSelected()
        {
            isSelected = false;
            SetActiveTile();
        }

        public void SetActiveTile()
        {
            if (isSelected)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }

        public int GetID()
        {
            return id;
        }
    }
}

