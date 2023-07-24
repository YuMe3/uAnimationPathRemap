using UnityEditor;
using UnityEngine;

namespace uAnimationPathRemap.Editor
{
    public static class AnimatorContextMenu
    {
        [MenuItem("CONTEXT/Animator/PathRemap", validate = true)]
        private static bool OpenPathRemapValidate(MenuCommand menuCommand)
        {
            var animator = menuCommand.context as Animator;
            return uAnimationPathRemapMainWindow.IsMissingPath(animator);
        }
        [MenuItem("CONTEXT/Animator/PathRemap", validate = false)]
        private static void OpenPathRemap(MenuCommand menuCommand)
        {
            var animator = menuCommand.context as Animator;
            Debug.Log(animator);
            uAnimationPathRemapMainWindow.ShowWindow(animator);
        }
    }
}