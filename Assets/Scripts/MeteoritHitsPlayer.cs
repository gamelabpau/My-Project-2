using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritHitsPlayer : MonoBehaviour
{
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.takeDamage(30f);
        }
        Destroy(gameObject);
    }
}
