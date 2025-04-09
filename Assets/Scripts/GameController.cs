using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Sprite spriteCursor;

    void Start()
    {
        Cursor.SetCursor(spriteCursor.texture, Vector2.up * 10, CursorMode.ForceSoftware);
    }
}