using System;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace uAnimationPathRemap.Editor
{
    public class uAnimationPathRemapMainWindow : UnityEditor.EditorWindow
    {
        public static void ShowWindow(Animator target)
        {
            var window = GetWindow<uAnimationPathRemapMainWindow>();
            window.titleContent = new UnityEngine.GUIContent("uAnimationPathRemap");
            window._target = target;
            window.ShowModalUtility();
        }

        private Animator _target;
        private void OnGUI()
        {
            var clips = _target.runtimeAnimatorController.animationClips;
        }

        public static bool IsMissingPath(Animator animator)
        {
            if (animator == null)
                return false;
            if (animator.runtimeAnimatorController == null)
                return false;
            
            var clips = animator.runtimeAnimatorController.animationClips;
            foreach (var clip in clips)
            {
                var bindings = AnimationUtility.GetCurveBindings(clip);
                foreach (var binding in bindings)
                {
                    if (animator.transform.Find(binding.path) == null)
                        return true;
                }
            }

            return false;
        }
    }
}