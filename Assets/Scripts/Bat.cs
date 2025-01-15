using System.Collections;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float patrolVelocity;
    private Vector3 currentDestiny;
    private int currentIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = 0;
        currentDestiny = points[currentIndex].position;
        StartCoroutine(patrol());
    }

    IEnumerator patrol(){
      while(true){

        while(transform.position != currentDestiny){
            transform.position = Vector3.MoveTowards(transform.position, points[currentIndex].position, patrolVelocity * Time.deltaTime);
            yield return null;
        }
        defineNewDestiny();
      }
    }
    private void defineNewDestiny(){
        currentIndex++;
        if(currentIndex >= points.Length){
            currentIndex=0;
        }
        currentDestiny = points[currentIndex].position;
        focusObjective();
    }
    private void focusObjective(){
        if(currentDestiny.x > transform.position.x){
            transform.localScale = Vector3.one;
        }
        else{
            transform.localScale = new Vector3(-1,1,1);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.CompareTag("PlayerDetection")){
            Debug.Log("Te cachamos mi buen");
         }
         else if(other.gameObject.CompareTag("PlayerHitBox")){
            Debug.Log("Te tocamos prro");
         }
    }
}
