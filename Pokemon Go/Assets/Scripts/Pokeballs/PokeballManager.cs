using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeballManager : MonoBehaviour
{
    public bool HasCaught = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pokemon")
        {
            StartCoroutine("CatchPokemon", other.gameObject);
        }
    }
    IEnumerator CatchPokemon(GameObject Poekmon)
    {
        transform.Translate(Vector3.up * 1, Space.World);
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(Poekmon);
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("MainCamera").transform.LookAt(transform);
        GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<Camera>().fieldOfView = 10f;

        //shake - 1
        yield return new WaitForSeconds(1);
        transform.Rotate(Vector3.right * 10);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(-Vector3.right * 10);

        //shake - 2
        yield return new WaitForSeconds(1);
        transform.Rotate(Vector3.right * 10);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(-Vector3.right * 10);

        //shake 3
        yield return new WaitForSeconds(1);
        transform.Rotate(Vector3.right * 10);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(-Vector3.right * 10);

        HasCaught = true;

        //finished
        Debug.Log("Finished");

    }
}
