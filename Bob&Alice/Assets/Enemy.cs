using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour
{
    public int hitpoints, damage;
    public string nameEnemy;
    public Enemy(int hp, int dmg, string ID)
    { //this constructor assigns hitpoints, damage, and name to
      //the values passed into the constructor
        hitpoints = hp;
        damage = dmg;
        name = ID;
    }
    private void Start()
    {
        
    }
    public void TakeDamage()
    {
        hitpoints--; //reduce HP by 1
        StartCoroutine(ColorChange());
        Debug.Log(name + "'s HP: " + hitpoints); //print out new hp
        if (hitpoints == 0) Die();
    }
    public void TakeDamage(int damage)
    {
        hitpoints--; //reduce HP by 1
        StartCoroutine(ColorChange());
        Debug.Log(name + "'s HP: " + hitpoints); //print out new hp
        if (hitpoints == 0) Die();
    }
    public void Die()
    {
        Debug.Log(name + " Has Died"); //print to the console
    }

    private IEnumerator ColorChange()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.4f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
