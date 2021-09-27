using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //The only one with MonoBehaviour
    private static GameManager _instance;

    public GameObject PlayerInstance;
    private PlayerMovement playerMovement;
    private StateMachine<GameManager> stateMachine;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    public void Start()
    {
        stateMachine = new StateMachine<GameManager>(this);

        playerMovement = new PlayerMovement(PlayerInstance, transform);
        playerMovement.OnEnter();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.OnUpdate();
    }
}