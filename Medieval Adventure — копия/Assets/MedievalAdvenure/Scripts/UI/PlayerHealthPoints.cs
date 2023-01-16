using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHealthPoints : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Slider _playerHealthPointsSlider;
    [SerializeField] private TextMeshProUGUI _textGame;
    private int _playerHealthPoints = 500;
    private Enemy[] _enemys;

    public static bool GameOver = false;
    
    

    private void OnEnable()
    {
        HealBottle.OnHealCollected += IncrementHealthPoints;
        EnemySword.OnDamage += DecrementHealthPoints;
    }

    private void OnDisable()
    {
        HealBottle.OnHealCollected -= IncrementHealthPoints;
        EnemySword.OnDamage -= DecrementHealthPoints;
    }
    
    void Start()
    {
        _playerHealthPointsSlider.maxValue = _playerHealthPoints;
        _playerHealthPointsSlider.value = _playerHealthPoints;
        _enemys = FindObjectsOfType<Enemy>();
    }

   private void IncrementHealthPoints()
    {
        _playerHealthPoints += 20;
        _playerHealthPointsSlider.value = _playerHealthPoints;
    }

    private void DecrementHealthPoints()
    {
        _playerHealthPoints -= 20;
        _playerHealthPointsSlider.value = _playerHealthPoints;
    }
    private void Update()
    {
        if (!GameOver)
        {
            _enemys = FindObjectsOfType<Enemy>();
            if (_playerHealthPoints <= 0)
            {
                _player.GetComponentInChildren<Animator>().SetBool("Die", true);
                _player.GetComponent<Character>().enabled = false;
                _player.GetComponent<CharacterController>().enabled = false;
                _player.SetActive(false);
                _textGame.text = "Game Over";
                _textGame.gameObject.SetActive(true);
                GameOver = true;
            }
            else if (-_enemys.Length == 0)
            {
                _player.GetComponentInChildren<Animator>().SetBool("Die", true);
                _player.GetComponent<Character>().enabled = false;
                _player.GetComponent<CharacterController>().enabled = false;
                _player.SetActive(false);
                _textGame.text = "You Win";
                _textGame.gameObject.SetActive(true);
                GameOver = true;
            }

        }
       
    }
}
