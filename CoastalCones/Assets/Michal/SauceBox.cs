using UnityEngine;

public class SauceZone : MonoBehaviour
{
    public bool sauceInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("scoop"))
        {
            sauceInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("scoop"))
        {
            sauceInside = false;
        }
    }
}