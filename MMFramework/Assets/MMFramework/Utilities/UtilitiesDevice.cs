using UnityEngine;

namespace MMFramework.Utilities
{
    public static partial class Utilities
    {
        public static bool IsTouchPlatform()
        {
            return Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android;
        }
    }
}