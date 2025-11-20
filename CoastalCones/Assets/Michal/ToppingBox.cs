using UnityEngine;

public class TopppingZone : MonoBehaviour
{
    public bool ScoopInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coop"))
        {
            ScoopInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("coop"))
        {
            ScoopInside = false;
        }
    }
}