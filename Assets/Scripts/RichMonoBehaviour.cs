using UnityEngine;

public class RichMonoBehaviour : MonoBehaviour
{
    /// <summary>
    /// Gives information about what this object is.
    /// </summary>
    [TextArea]//this means a string will be 3 lines instead of a single line
    public string developerDescription = "Please enter a description.";//
}
