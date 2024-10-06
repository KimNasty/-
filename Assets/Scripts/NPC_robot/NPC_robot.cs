using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_robot : MonoBehaviour
{
    public static NPC_robot Instance {  get; private set; }

    private Rigidbody2D _rb;

    private bool isDead = true;
    public bool IsDead {  get { return isDead; } }
    private float _interactionDistance = 2f;
    private int needPlastic = 1;
    private int needMetal = 1;
    private int needBiomas = 1;

    private void Awake()
    {
        Instance = this;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isDead) CheckForInteraction();
        
    }

    private void CheckForInteraction()
    {
        if (Vector3.Distance(transform.position, Character.Instance.GetCharacterPosition()) <= _interactionDistance &&
            Input.GetKey(KeyCode.Space) && Character.Instance.Running == Run.No)
        {
            if (Game.Instance.CountMetal >= needMetal && Game.Instance.CountBiomas >= needBiomas
                && Game.Instance.CountPlastic >= needPlastic)
            {
                isDead = false;
            }
            else
            {
                Debug.Log("n;vashaf");
                Game.Instance.ShowInfoRobotMessage("Для оживления робота необходимо металла " + needMetal + " пластика " + needPlastic + " биомассы" + needBiomas);
            }
        }
    }

    

}
