using System.Collections;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private GameObject fireBall; //Prefab
    [SerializeField] private Transform spawn; //Prefab
    [SerializeField] private float attackTime; //Prefab
    private Animator anim; //Prefab

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(attackRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator attackRoutine(){
        while(true){
            anim.SetTrigger("atacar");
            yield return new WaitForSeconds(attackTime);
        }
    }
    private void LanzarBola(){
            Instantiate(fireBall, spawn.position, transform.rotation);
    }
}
