using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MatchTile.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameoverPanel;
        [SerializeField] private TMP_Text goldText;

        private void OnEnable()
        {
            Timer.Timer.onGameOver += ShowPanel;
        }

        public void ShowPanel()
        {
            gameoverPanel.SetActive(true);
        }
    }

}

