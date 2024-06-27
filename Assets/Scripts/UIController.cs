using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SurvivorGame
{
    public class UIController : MonoBehaviour
    {
        #region Creating Instance
        private static UIController _uiControllerInstance;

        public static UIController Instance
        {
            get
            {
                if (_uiControllerInstance == null)
                {
                    _uiControllerInstance = FindObjectOfType<UIController>();
                }
                return _uiControllerInstance;
            }
        }
        #endregion

        #region Private Variables
        [Header("Health Values")]
        [SerializeField] private int _maxPlayerHealth = 100;
        [SerializeField] private int _coinCollectionAmount = 0;
        [Header("Health UI Components")]
        [SerializeField] private Slider _playerHealthSlider;
        [SerializeField] private TextMeshProUGUI _coinAmountTMP;
        private int _currentPlayerHealth;

        #endregion

        #region Private Methods
        private void Awake()
        {
            if (_uiControllerInstance == null)
            {
                _uiControllerInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (_uiControllerInstance != this)
            {
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            _currentPlayerHealth = _maxPlayerHealth;
            DisplayPlayerHealth();
        }

        private void DisplayPlayerHealth()
        {
            _playerHealthSlider.value = _currentPlayerHealth / _maxPlayerHealth;
        }
        #endregion

        #region Public Methods
        public void UpdatePlayerHealth(int damage, bool isIncrease)
        {
            Debug.Log("UpdatePlayerHealth");
            if (!isIncrease)
            {
                Debug.Log("False");
                _currentPlayerHealth -= damage;
                if (_currentPlayerHealth < 0)
                {
                    _currentPlayerHealth = 0; // Ensure health doesn't go below 0
                }
            }
            else
            {
                _currentPlayerHealth += damage;
                if (_currentPlayerHealth > _maxPlayerHealth)
                {
                    _currentPlayerHealth = _maxPlayerHealth; // Ensure health doesn't exceed max health
                }
            }

            DisplayPlayerHealth();
        }

        public void UpdateCoinCollection(int value)
        {
            _coinCollectionAmount += value;
        }
        #endregion
    }

}
