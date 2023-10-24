using UnityEngine;
using System.Collections;
public class PlayerInput : MonoBehaviour
{
    GameObject bob, alice; // declare bob and alice
    int playerHP = 10; //This is our hp
    int playerDMG = 3;
    Enemy _bob, _alice;
    void Start()
    {
        bob = Instantiate(Resources.Load("Bob"), new Vector3 (-2f, 0f, 0f), Quaternion.identity) as GameObject;
        alice = Instantiate(Resources.Load("Alice"), new Vector3(2f, 0f, 0f), Quaternion.identity) as GameObject;
        _bob = bob.GetComponent<Enemy>();
        _alice = alice.GetComponent<Enemy>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Bob takes damage if Spacebar is pressed
            _bob.TakeDamage(playerDMG);
            win();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _alice.TakeDamage();
            win();
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //Player takes damage from bob if left control is pressed
            playerHP -= _bob.damage;
            Debug.Log("Player HP: " + playerHP);
            win();
        }
        else if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //Player takes damage from alice if left alt is pressed
            playerHP -= _alice.damage;
            Debug.Log("Player HP: " + playerHP);
            win();
        }

            
    }
    
    public void win()
    {
        if (_bob.hitpoints < 1 && _alice.hitpoints < 1)
        {
            Debug.Log("Player Wins!");
            QuitGame();
        }
        if (playerHP < 1)
        {
            Debug.Log("Player Loses!");
            QuitGame();
        }
        
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}