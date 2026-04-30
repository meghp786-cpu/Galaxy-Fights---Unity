using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject explosionVFX;
    private GameScene gameScene;
    private void Start()
    {
        gameScene = FindFirstObjectByType<GameScene>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        gameScene.ReloadScene();
        Debug.Log("hit" + this.gameObject.name);
    }
}
