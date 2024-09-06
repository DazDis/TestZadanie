using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private BlockManager _blockManager;
    public bool side = false;
    public void TouchWall()
    {
        

       
        _blockManager.TouchedWall.Invoke();
       
        
    }
}
