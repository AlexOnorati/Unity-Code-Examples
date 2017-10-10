using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Helper functions to help writing clean easy to read code.
/// </summary>
public static class HelperFunctions {

    public static bool IsNull<T>(this T arg) {
        return arg == null;
    }

    public static bool IsNotNull<T>(this T arg) {
        return arg != null;
    }
}
