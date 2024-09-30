using UnityEngine;
using UnityEngine.Android;

namespace QR
{
    public class CameraPermission : MonoBehaviour
    {
        void Start()
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
            }
        }
    }
}