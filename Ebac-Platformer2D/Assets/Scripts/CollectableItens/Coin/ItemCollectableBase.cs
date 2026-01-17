using System.Collections.ObjectModel;
using UnityEditor.AssetImporters;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        Debug.Log("Coin Collected");
        gameObject.SetActive(false);
        OnCollect();
    }
    
    protected virtual void OnCollect() {}

}
