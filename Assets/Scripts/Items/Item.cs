using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Item : MonoBehaviour
{
    public float buffTime = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tank" && other.GetComponent<Tank>().isPlayer)
        {
            other.GetComponent<Tank>().StartCoroutine(Buff(other.GetComponent<Tank>()));
            Destroy(gameObject);
        }
    }

    protected IEnumerator Buff(Tank tank)
    {
        BuffOn(tank);
        yield return new WaitForSeconds(buffTime);
        BuffOff(tank);
    }

    protected abstract void BuffOn(Tank tank);
    protected abstract void BuffOff(Tank tank);
}
