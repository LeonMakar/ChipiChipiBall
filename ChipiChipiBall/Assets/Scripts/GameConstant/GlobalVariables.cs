using UnityEngine;

public static class GlobalVariables
{
    public static string PLATFORM_TAG = "Platform";
    public static string DEFAULT_TAG = "Untagged";

    public static MediaMaterialController MEDIA;
    public static LayerMask CUBE_LAYER = 1 << 0;
    public static int TOTAL_BALLS;
}
