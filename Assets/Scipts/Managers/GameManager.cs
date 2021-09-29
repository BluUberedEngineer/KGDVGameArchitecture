using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GameManager : MonoBehaviour
{
    //The only one with MonoBehaviour
    private static GameManager _instance;
    [BoxGroup("Gun")]
    public GameObject gunObject;
    [BoxGroup("Gun")]
    public List<GunModifier> gunModifiers;
    [BoxGroup("Player")]
    public GameObject PlayerInstance;
    private PlayerMovement playerMovement;
    private Gun gun;
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
        gun = new Gun();
        gun.GunStart(gunModifiers);

        playerMovement = new PlayerMovement(PlayerInstance, transform);
        playerMovement.OnEnter();

    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.OnUpdate();
        gun.GunUpdate();
        //vervang dit ff met dedicated input manager


        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(gun.Reload());
        }
    }
}