using UnityEngine;
using static StupidTemplate.Settings;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Classes.RigManager;
using Unity.Mathematics;
using Oculus.Interaction.HandGrab;
using StupidTemplate.Notifications;
using Unity.XR.CoreUtils;
using System.Diagnostics;
using Photon.Pun;
using Technie.PhysicsCreator.QHull;
using UnityEngine.AI;
using System.Linq;

namespace StupidTemplate.Mods
{
    internal class AllMods
    {
        public static float originalMaxArmLength = GorillaLocomotion.GTPlayer.Instance.maxArmLength;
        public static float originalUnStickDistance = GorillaLocomotion.GTPlayer.Instance.unStickDistance;
        public static float originalSlideControl = GorillaLocomotion.GTPlayer.Instance.slideControl;
        public static float originalDefaultPrecision = GorillaLocomotion.GTPlayer.Instance.defaultPrecision;
        public static float originalDefaultSlideFactor = GorillaLocomotion.GTPlayer.Instance.defaultSlideFactor;

        public static Vector3 originalLeftHandOffset = GorillaLocomotion.GTPlayer.Instance.leftHandOffset;
        public static Vector3 originalRightHandOffset = GorillaLocomotion.GTPlayer.Instance.rightHandOffset;
        public static Vector3 originalHeadTrackingPositionOffset = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset;
        public static Vector3 originalHeadBodyOffset = GorillaTagger.Instance.offlineVRRig.headBodyOffset;
        public static Vector3 originalLeftHandTrackingPositionOffset = GorillaTagger.Instance.offlineVRRig.leftHand.trackingPositionOffset;
        public static Vector3 originalRightHandTrackingPositionOffset = GorillaTagger.Instance.offlineVRRig.rightHand.trackingPositionOffset;

        public static void EnterMovement()
        {
            buttonsType = 5;
        }

        public static void EnterTrolling()
        {
            buttonsType = 6;
        }

        public static void EnterRig()
        {
            buttonsType = 7;
        }

        public static void EnterGuns()
        {
            buttonsType = 8;
        }

        public static void EnterGame()
        {
            buttonsType = 9;
        }

        public static void EnterVisuals()
        {
            buttonsType = 10;
        }

        public static void EnterData()
        {
            buttonsType = 11;
        }

        public static void EnterOverTagged()
        {
            buttonsType = 12;
        }

        public static void EnterOverpowered()
        {
            buttonsType = 13;
        }

        public static void EnterPhoton()
        {
            buttonsType = 14;
        }

        public static void Speedboost()
        {
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = 6.5f * 2f;
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 1.1f * 2f;
        }

        public static void MosaSpeedboost()
        {
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = 6.5f * 1.25f;
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 1.1f * 1.25f;
        }

        public static void Fly()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }

        public static void GripFly()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }

        public static void TriggerFly()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }

        public static void HighGravity()
        {
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Physics.gravity * Time.deltaTime;
        }

        public static void LowGravity()
        {
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Physics.gravity * -0.5f * Time.deltaTime;
        }

        public static void ZeroGravity()
        {
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Physics.gravity * -1f * Time.deltaTime;
        }

        public static void FlipGravity()
        {
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Physics.gravity * -2f * Time.deltaTime;
        }

        public static void Noclip()
        {
            MeshCollider[] meshColliders = Resources.FindObjectsOfTypeAll<MeshCollider>();

            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = false;
                    }
                }

                else
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = true;
                    }
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = false;
                    }
                }

                else
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = true;
                    }
                }
            }
        }

        public static void GripNoclip()
        {
            MeshCollider[] meshColliders = Resources.FindObjectsOfTypeAll<MeshCollider>();

            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = false;
                    }
                }

                else
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = true;
                    }
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = false;
                    }
                }

                else
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = true;
                    }
                }
            }
        }

        public static void TriggerNoclip()
        {
            MeshCollider[] meshColliders = Resources.FindObjectsOfTypeAll<MeshCollider>();

            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = false;
                    }
                }

                else
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = true;
                    }
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = false;
                    }
                }

                else
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = true;
                    }
                }
            }
        }

        public static void GhostMonke()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                }

                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                }

                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }

        public static void TriggerGhostMonke()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                }

                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                }

                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }

        public static void GripGhostMonke()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                }

                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                }

                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }

        public static bool disableRigNextFrame = false;
        public static bool updateRigWasLeftControllerPrimaryButton = ControllerInputPoller.instance.leftControllerPrimaryButton;
        public static bool updateRigWasRightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;

        public static void UpdateRig()
        {
            if (disableRigNextFrame)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                disableRigNextFrame = false;
            }

            if (rightHanded)
            {
                if (!updateRigWasLeftControllerPrimaryButton && ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    disableRigNextFrame = true;
                }
            }

            else
            {
                if (!updateRigWasRightControllerPrimaryButton && ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    disableRigNextFrame = true;
                }
            }

            updateRigWasLeftControllerPrimaryButton = ControllerInputPoller.instance.leftControllerPrimaryButton;
            updateRigWasRightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
        }

        public static bool triggerUpdateRigWasLeftControllerTrigger = ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f;
        public static bool triggerUpdateRigWasRightControllerTrigger = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f;

        public static void TriggerUpdateRig()
        {
            if (disableRigNextFrame)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                disableRigNextFrame = false;
            }

            if (rightHanded)
            {
                if (!triggerUpdateRigWasLeftControllerTrigger && ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    disableRigNextFrame = true;
                }
            }

            else
            {
                if (!triggerUpdateRigWasRightControllerTrigger && ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    disableRigNextFrame = true;
                }
            }

            triggerUpdateRigWasLeftControllerTrigger = ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f;
            triggerUpdateRigWasRightControllerTrigger = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f;
        }

        public static bool gripUpdateRigWasLeftGrab = ControllerInputPoller.instance.leftGrab;
        public static bool gripUpdateRigWasRightGrab = ControllerInputPoller.instance.rightGrab;

        public static void GripUpdateRig()
        {
            if (disableRigNextFrame)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                disableRigNextFrame = false;
            }

            if (rightHanded)
            {
                if (!gripUpdateRigWasLeftGrab && ControllerInputPoller.instance.leftGrab)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    disableRigNextFrame = true;
                }
            }

            else
            {
                if (!gripUpdateRigWasRightGrab && ControllerInputPoller.instance.rightGrab)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    disableRigNextFrame = true;
                }
            }

            gripUpdateRigWasLeftGrab = ControllerInputPoller.instance.leftGrab;
            gripUpdateRigWasRightGrab = ControllerInputPoller.instance.rightGrab;
        }

        public static bool toggleRigWasLeftControllerPrimaryButton = ControllerInputPoller.instance.leftControllerPrimaryButton;
        public static bool toggleRigWasRightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;

        public static void ToggleRig()
        {
            if (rightHanded)
            {
                if (!toggleRigWasLeftControllerPrimaryButton && ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = !GorillaTagger.Instance.offlineVRRig.enabled;
                }
            }

            else
            {
                if (!toggleRigWasRightControllerPrimaryButton && ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = !GorillaTagger.Instance.offlineVRRig.enabled;
                }
            }

            toggleRigWasLeftControllerPrimaryButton = ControllerInputPoller.instance.leftControllerPrimaryButton;
            toggleRigWasRightControllerPrimaryButton = ControllerInputPoller.instance.rightControllerPrimaryButton;
        }

        public static bool triggerToggleRigWasLeftControllerTrigger = ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f;
        public static bool triggerToggleRigWasRightControllerTrigger = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f;

        public static void TriggerToggleRig()
        {
            if (rightHanded)
            {
                if (!triggerToggleRigWasLeftControllerTrigger && ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = !GorillaTagger.Instance.offlineVRRig.enabled;
                }
            }

            else
            {
                if (!triggerToggleRigWasRightControllerTrigger && ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = !GorillaTagger.Instance.offlineVRRig.enabled;
                }
            }

            triggerToggleRigWasLeftControllerTrigger = ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f;
            triggerToggleRigWasRightControllerTrigger = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f;
        }

        public static bool gripToggleRigWasLeftGrab = ControllerInputPoller.instance.leftGrab;
        public static bool gripToggleRigWasRightGrab = ControllerInputPoller.instance.rightGrab;

        public static void GripToggleRig()
        {
            if (rightHanded)
            {
                if (!gripToggleRigWasLeftGrab && ControllerInputPoller.instance.leftGrab)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = !GorillaTagger.Instance.offlineVRRig.enabled;
                }
            }

            else
            {
                if (!gripToggleRigWasRightGrab && ControllerInputPoller.instance.rightGrab)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = !GorillaTagger.Instance.offlineVRRig.enabled;
                }
            }

            gripToggleRigWasLeftGrab = ControllerInputPoller.instance.leftGrab;
            gripToggleRigWasRightGrab = ControllerInputPoller.instance.rightGrab;
        }

        public static void DisableRig()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = false;
        }

        public static void EnableRig()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        public static void DisableMovement()
        {
            GorillaLocomotion.GTPlayer.Instance.disableMovement = true;
        }

        public static void EnableMovement()
        {
            GorillaLocomotion.GTPlayer.Instance.disableMovement = false;
        }

        public static void DisableOthersMovement()
        {
            GorillaLocomotion.GTPlayer[] gTPlayers = Resources.FindObjectsOfTypeAll<GorillaLocomotion.GTPlayer>();

            foreach (GorillaLocomotion.GTPlayer gTPlayer in gTPlayers)
            {
                if (gTPlayer != GorillaLocomotion.GTPlayer.Instance)
                {
                    gTPlayer.disableMovement = true;
                }
            }
        }

        public static void EnableOthersMovement()
        {
            GorillaLocomotion.GTPlayer[] gTPlayers = Resources.FindObjectsOfTypeAll<GorillaLocomotion.GTPlayer>();

            foreach (GorillaLocomotion.GTPlayer gTPlayer in gTPlayers)
            {
                if (gTPlayer != GorillaLocomotion.GTPlayer.Instance)
                {
                    gTPlayer.disableMovement = false;
                }
            }
        }

        public static void DisableAllsMovement()
        {
            GorillaLocomotion.GTPlayer[] gTPlayers = Resources.FindObjectsOfTypeAll<GorillaLocomotion.GTPlayer>();

            foreach (GorillaLocomotion.GTPlayer gTPlayer in gTPlayers)
            {
                gTPlayer.disableMovement = true;
            }
        }

        public static void EnableAllsMovement()
        {
            GorillaLocomotion.GTPlayer[] gTPlayers = Resources.FindObjectsOfTypeAll<GorillaLocomotion.GTPlayer>();

            foreach (GorillaLocomotion.GTPlayer gTPlayer in gTPlayers)
            {
                gTPlayer.disableMovement = false;
            }
        }

        public static void NoMaxJumpSpeed()
        {
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = math.INFINITY;
        }

        public static void NoMaxArmLength()
        {
            GorillaLocomotion.GTPlayer.Instance.maxArmLength = math.INFINITY;
        }

        public static void ResetMaxArmLength()
        {
            GorillaLocomotion.GTPlayer.Instance.maxArmLength = originalMaxArmLength;
        }

        public static void HandFly()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.leftHandFollower.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.rightHandFollower.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }

        public static void GripHandFly()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.leftHandFollower.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.rightHandFollower.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }

        public static void TriggerHandFly()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.leftHandFollower.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.rightHandFollower.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }

        public static void NoJumpMultiplier()
        {
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 1;
        }

        public static Vector3[] delayedCameraPositionHistory = new Vector3[10];
        public static int delayedCameraPositionIndex = 0;

        public static void DelayedCameraPosition()
        {
            Vector3 headColliderPosition = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position;
            Vector3 bodyColliderPosition = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position;
            Vector3 leftHandPosition = GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position;
            Vector3 rightHandPosition = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
            Vector3 leftHandFollowerPosition = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position;
            Vector3 rightHandFollowerPosition = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position;

            delayedCameraPositionIndex = (delayedCameraPositionIndex + 1) % delayedCameraPositionHistory.Length;
            GorillaLocomotion.GTPlayer.Instance.transform.position -= Camera.current.transform.localPosition - delayedCameraPositionHistory[delayedCameraPositionIndex];
            GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position = headColliderPosition;
            GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position = bodyColliderPosition;
            GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position = leftHandPosition;
            GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position = rightHandPosition;
            GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position = leftHandFollowerPosition;
            GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position = rightHandFollowerPosition;
            delayedCameraPositionHistory[delayedCameraPositionIndex] = headColliderPosition;
        }

        public static void CarMonke()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward, Physics.gravity.normalized).normalized * 6.5f * Time.deltaTime;
                }

                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward, Physics.gravity.normalized).normalized * -6.5f * Time.deltaTime;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward, Physics.gravity.normalized).normalized * -6.5f * Time.deltaTime;
                }

                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward, Physics.gravity.normalized).normalized * 6.5f * Time.deltaTime;
                }
            }
        }

        public static void TwistedNeck()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 180;
        }

        public static void ResetHeadTrackingRotationOffset()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset = Vector3.zero;
        }

        public static void NoVelocityLimit()
        {
            GorillaLocomotion.GTPlayer.Instance.velocityLimit = 0;
        }

        public static void LongArmsOffset()
        {
            GorillaLocomotion.GTPlayer.Instance.leftHandOffset.y = GorillaLocomotion.GTPlayer.Instance.maxArmLength / -4;
            GorillaLocomotion.GTPlayer.Instance.rightHandOffset.y = GorillaLocomotion.GTPlayer.Instance.maxArmLength / -4;
        }

        public static void ResetLeftHandOffset()
        {
            GorillaLocomotion.GTPlayer.Instance.leftHandOffset = originalLeftHandOffset;
        }

        public static void ResetRightHandOffset()
        {
            GorillaLocomotion.GTPlayer.Instance.rightHandOffset = originalRightHandOffset;
        }

        public static void ResetArmOffsets()
        {
            GorillaLocomotion.GTPlayer.Instance.leftHandOffset = originalLeftHandOffset;
            GorillaLocomotion.GTPlayer.Instance.rightHandOffset = originalRightHandOffset;
        }

        public static void UpAndDown()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Physics.gravity * -3 * Time.deltaTime;
                }

                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Physics.gravity * Time.deltaTime;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Physics.gravity * Time.deltaTime;
                }

                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Physics.gravity * -3 * Time.deltaTime;
                }
            }
        }

        public static void ForwardsAndBackwards()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward, Physics.gravity.normalized).normalized * 6.5f * Time.deltaTime;
                    ZeroGravity();
                }

                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward, Physics.gravity.normalized).normalized * -6.5f * Time.deltaTime;
                    ZeroGravity();
                }
            }

            else
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward, Physics.gravity.normalized).normalized * -6.5f * Time.deltaTime;
                    ZeroGravity();
                }

                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward, Physics.gravity.normalized).normalized * 6.5f * Time.deltaTime;
                    ZeroGravity();
                }
            }
        }

        public static void LeftAndRight()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right, Physics.gravity.normalized).normalized * 6.5f * Time.deltaTime;
                    ZeroGravity();
                }

                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right, Physics.gravity.normalized).normalized * -6.5f * Time.deltaTime;
                    ZeroGravity();
                }
            }

            else
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right, Physics.gravity.normalized).normalized * -6.5f * Time.deltaTime;
                    ZeroGravity();
                }

                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right, Physics.gravity.normalized).normalized * 6.5f * Time.deltaTime;
                    ZeroGravity();
                }
            }
        }

        private static int pullIndex = 0;

        public static void ChangePullPower()
        {
            float[] pullPowers = { 0.0625f, 0.125f, 0.25f, 0.5f, 1f };

            string[] pullPowerNames = { "Weak", "Normal", "Strong", "Powerful", "Uncontrollable" };

            pullIndex = (pullIndex + 1) % pullPowers.Length;
            pullPower = pullPowers[pullIndex];
            GetIndex("Change Pull Power").overlapText = "Change Pull Power <color=grey>[</color><color=green>" + pullPowerNames[pullIndex] + "</color><color=grey>]</color>" + " " + pullPowers[pullIndex];
        }

        private static float pullPower = 0.0625f;
        private static bool pullWasLeftHandTouching = false;
        private static bool pullWasRightHandTouching = false;

        public static void Pull()
        {
            if (((!GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true) && pullWasLeftHandTouching) || (!GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false) && pullWasRightHandTouching)))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity, Physics.gravity.normalized) * pullPower;
            }

            pullWasLeftHandTouching = GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true);
            pullWasRightHandTouching = GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false);
        }

        public static bool backwardsWalkWasLeftHandTouching = false;
        public static bool backwardsWalkWasRightHandTouching = false;

        public static void BackwardsWalk()
        {
            if (((!GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true) && backwardsWalkWasLeftHandTouching) || (!GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false) && backwardsWalkWasRightHandTouching)))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position = Physics.gravity.normalized * Vector3.Dot(Physics.gravity.normalized, GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity) + Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity, Physics.gravity.normalized) * -1;
            }

            backwardsWalkWasLeftHandTouching = GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true);
            backwardsWalkWasRightHandTouching = GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false);
        }

        public static void SteamLongArms()
        {
            GorillaTagger.Instance.offlineVRRig.transform.localScale = Vector3.one * GorillaLocomotion.GTPlayer.Instance.maxArmLength;
        }

        public static void ShortArms()
        {
            GorillaTagger.Instance.offlineVRRig.transform.localScale = Vector3.one * 0.5f;
        }

        public static void ResetLocalScale()
        {
            GorillaTagger.Instance.offlineVRRig.transform.localScale = Vector3.one;
        }

        public static void AlwaysMaxVelocity()
        {
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = math.INFINITY;
        }

        public static void NoTagFreeze()
        {
            GorillaLocomotion.GTPlayer.Instance.disableMovement = false;
        }

        public static int blackHoleIndex = 0;

        public static void ChangeBlackHoleMass()
        {
            float[] blackHoleMasses = { 1f, 10f, 100f, 1000f, 10000f };

            string[] blackHoleNames = { "Weak", "Normal", "Strong", "Powerful", "Super Powerful" };

            blackHoleIndex = (blackHoleIndex + 1) % blackHoleMasses.Length;
            blackHoleMass = blackHoleMasses[blackHoleIndex];
            GetIndex("Change Black Hole Mass").overlapText = "Change Black Hole Mass <color=grey>[</color><color=green>" + blackHoleNames[blackHoleIndex] + "</color><color=grey>]</color>" + " " + blackHoleMasses[blackHoleIndex];
        }

        public static Vector3 blackHolePosition = Vector3.zero;
        public static float blackHoleMass = 1f;

        public static void BlackHoleGun()
        {
            RaycastHit hitInfo;
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position, GorillaLocomotion.GTPlayer.Instance.leftHandFollower.forward, out hitInfo, math.INFINITY, GorillaLocomotion.GTPlayer.Instance.locomotionEnabledLayers.value))
                    {
                        blackHolePosition = hitInfo.point;
                    }
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position, GorillaLocomotion.GTPlayer.Instance.rightHandFollower.forward, out hitInfo, math.INFINITY, GorillaLocomotion.GTPlayer.Instance.locomotionEnabledLayers.value))
                    {
                        blackHolePosition = hitInfo.point;
                    }
                }
            }

            float r = Vector3.Distance(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position, blackHolePosition);
            float g = 6.6743f;
            float pull = (g * blackHoleMass) / math.pow(r, 2);

            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += (blackHolePosition - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position).normalized * pull * Time.deltaTime;
        }

        public static int whiteHoleIndex = 0;

        public static void ChangeWhiteHoleMass()
        {
            float[] whiteHoleMasses = { 1f, 10f, 100f, 1000f, 10000f };

            string[] whiteHoleNames = { "Weak", "Normal", "Strong", "Powerful", "Super Powerful" };

            whiteHoleIndex = (whiteHoleIndex + 1) % whiteHoleMasses.Length;
            whiteHoleMass = whiteHoleMasses[whiteHoleIndex];
            GetIndex("Change White Hole Mass").overlapText = "Change White Hole Mass <color=grey>[</color><color=green>" + whiteHoleNames[whiteHoleIndex] + "</color><color=grey>]</color>" + " " + whiteHoleMasses[whiteHoleIndex];
        }

        public static Vector3 whiteHolePosition = Vector3.zero;
        public static float whiteHoleMass = 1f;

        public static void WhiteHoleGun()
        {
            RaycastHit hitInfo;
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position, GorillaLocomotion.GTPlayer.Instance.leftHandFollower.forward, out hitInfo, math.INFINITY, GorillaLocomotion.GTPlayer.Instance.locomotionEnabledLayers.value))
                    {
                        whiteHolePosition = hitInfo.point;
                    }
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position, GorillaLocomotion.GTPlayer.Instance.rightHandFollower.forward, out hitInfo, math.INFINITY, GorillaLocomotion.GTPlayer.Instance.locomotionEnabledLayers.value))
                    {
                        whiteHolePosition = hitInfo.point;
                    }
                }
            }

            float r = Vector3.Distance(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position, whiteHolePosition);
            float g = 6.6743f;
            float pull = (g * whiteHoleMass) / math.pow(r, 2);

            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position - whiteHolePosition).normalized * pull * Time.deltaTime;
        }

        public static GameObject leftHandPlatform = null;
        public static GameObject rightHandPlatform = null;

        public static void Platforms()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (leftHandPlatform = null)
                {
                    leftHandPlatform = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    leftHandPlatform.transform.localScale = new Vector3(0.5f, 0.01f, 0.5f);
                    leftHandPlatform.transform.position = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position + (GorillaLocomotion.GTPlayer.Instance.leftHandFollower.forward * (GorillaLocomotion.GTPlayer.Instance.minimumRaycastDistance + leftHandPlatform.transform.localScale.y / 2));
                    leftHandPlatform.transform.rotation = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.rotation;
                    leftHandPlatform.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    leftHandPlatform.GetComponent<Renderer>().material.color = Color.black;
                }
            }

            else
            {
                if (leftHandPlatform != null)
                {
                    GameObject.Destroy(leftHandPlatform);
                }
            }

            if (ControllerInputPoller.instance.rightGrab)
            {
                if (rightHandPlatform = null)
                {
                    rightHandPlatform = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    rightHandPlatform.transform.localScale = new Vector3(0.5f, 0.01f, 0.5f);
                    rightHandPlatform.transform.position = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position + (GorillaLocomotion.GTPlayer.Instance.rightHandFollower.forward * (GorillaLocomotion.GTPlayer.Instance.minimumRaycastDistance + rightHandPlatform.transform.localScale.y / 2));
                    rightHandPlatform.transform.rotation = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.rotation;
                    rightHandPlatform.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    rightHandPlatform.GetComponent<Renderer>().material.color = Color.black;
                }
            }

            else
            {
                if (rightHandPlatform != null)
                {
                    GameObject.Destroy(rightHandPlatform);
                }
            }
        }

        public static Vector3 leftHandStickyPlatformPosition = Vector3.zero;
        public static Vector3 rightHandStickyPlatformPosition = Vector3.zero;

        public static bool invisibleStickyPlatformsWasLeftGrab = ControllerInputPoller.instance.leftGrab;
        public static bool invisibleStickyPlatformsWasRightGrab = ControllerInputPoller.instance.rightGrab;

        public static void InvisibleStickyPlatforms()
        {
            Vector3 rigidBodyMovement = Vector3.zero;

            if (!invisibleStickyPlatformsWasLeftGrab && ControllerInputPoller.instance.leftGrab)
            {
                leftHandStickyPlatformPosition = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position;
            }

            if (!invisibleStickyPlatformsWasRightGrab && ControllerInputPoller.instance.rightGrab)
            {
                rightHandStickyPlatformPosition = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position;
            }

            if (ControllerInputPoller.instance.leftGrab && ControllerInputPoller.instance.rightGrab)
            {
                rigidBodyMovement = ((leftHandStickyPlatformPosition - GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position) + (rightHandStickyPlatformPosition - GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position)) / 2;
            }

            else if (ControllerInputPoller.instance.leftGrab)
            {
                rigidBodyMovement = leftHandStickyPlatformPosition - GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position;
            }

            else if (ControllerInputPoller.instance.rightGrab)
            {
                rigidBodyMovement = rightHandStickyPlatformPosition - GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
            }

            if (ControllerInputPoller.instance.leftGrab || ControllerInputPoller.instance.rightGrab)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += rigidBodyMovement;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

            if (ControllerInputPoller.instance.leftGrab)
            {
                GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position = leftHandStickyPlatformPosition;
            }

            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position = rightHandStickyPlatformPosition;
            }

            if ((invisibleStickyPlatformsWasLeftGrab && !ControllerInputPoller.instance.leftGrab) && (invisibleStickyPlatformsWasRightGrab && !ControllerInputPoller.instance.rightGrab))
            {
                if (GorillaLocomotion.GTPlayer.Instance.AveragedVelocity.magnitude > GorillaLocomotion.GTPlayer.Instance.velocityLimit)
                {
                    if (GorillaLocomotion.GTPlayer.Instance.AveragedVelocity.magnitude * GorillaLocomotion.GTPlayer.Instance.jumpMultiplier > GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed)
                    {
                        GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.GTPlayer.Instance.AveragedVelocity.normalized * GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed;
                    }
                    else
                    {
                        GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.GTPlayer.Instance.jumpMultiplier * GorillaLocomotion.GTPlayer.Instance.AveragedVelocity;
                    }
                }
            }

            else if ((invisibleStickyPlatformsWasLeftGrab && !ControllerInputPoller.instance.leftGrab) && (!invisibleStickyPlatformsWasRightGrab && !ControllerInputPoller.instance.rightGrab))
            {
                if (GorillaLocomotion.GTPlayer.Instance.AveragedVelocity.magnitude > GorillaLocomotion.GTPlayer.Instance.velocityLimit)
                {
                    if (GorillaLocomotion.GTPlayer.Instance.AveragedVelocity.magnitude * GorillaLocomotion.GTPlayer.Instance.jumpMultiplier > GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed)
                    {
                        GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.GTPlayer.Instance.AveragedVelocity.normalized * GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed;
                    }
                    else
                    {
                        GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.GTPlayer.Instance.jumpMultiplier * GorillaLocomotion.GTPlayer.Instance.AveragedVelocity;
                    }
                }
            }

            else if ((!invisibleStickyPlatformsWasLeftGrab && !ControllerInputPoller.instance.leftGrab) && (invisibleStickyPlatformsWasRightGrab && !ControllerInputPoller.instance.rightGrab))
            {
                if (GorillaLocomotion.GTPlayer.Instance.AveragedVelocity.magnitude > GorillaLocomotion.GTPlayer.Instance.velocityLimit)
                {
                    if (GorillaLocomotion.GTPlayer.Instance.AveragedVelocity.magnitude * GorillaLocomotion.GTPlayer.Instance.jumpMultiplier > GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed)
                    {
                        GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.GTPlayer.Instance.AveragedVelocity.normalized * GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed;
                    }
                    else
                    {
                        GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.GTPlayer.Instance.jumpMultiplier * GorillaLocomotion.GTPlayer.Instance.AveragedVelocity;
                    }
                }
            }

            invisibleStickyPlatformsWasLeftGrab = ControllerInputPoller.instance.leftGrab;
            invisibleStickyPlatformsWasRightGrab = ControllerInputPoller.instance.rightGrab;
        }

        public static int wallWalkIndex = 0;

        public static void ChangeWallWalkPower()
        {
            float[] wallWalkPowers = { 0.0625f, 0.125f, 0.25f, 0.5f, 1f };

            string[] wallWalkNames = { "Weak", "Normal", "Strong", "Powerful", "Super Powerful" };

            wallWalkIndex = (wallWalkIndex + 1) % wallWalkPowers.Length;
            wallWalkPower = wallWalkPowers[wallWalkIndex];
            GetIndex("Change Wall Walk Power").overlapText = "Change Wall Walk Power <color=grey>[</color><color=green>" + wallWalkNames[wallWalkIndex] + "</color><color=grey>]</color>" + " " + wallWalkPowers[wallWalkIndex];
        }

        public static float wallWalkPower = 0.0625f;

        public static void WallWalk()
        {
            if (rightHanded)
            {
                if ((GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true) && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false)) && ControllerInputPoller.instance.leftGrab)
                {
                    GorillaTagger.Instance.rigidbody.AddForce(((GorillaLocomotion.GTPlayer.Instance.leftHandHitInfo.normal + GorillaLocomotion.GTPlayer.Instance.rightHandHitInfo.normal) / 2) * Physics.gravity.magnitude * wallWalkPower * -1, ForceMode.Acceleration);
                    ZeroGravity();
                }

                else if (GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true) && ControllerInputPoller.instance.leftGrab)
                {
                    GorillaTagger.Instance.rigidbody.AddForce(GorillaLocomotion.GTPlayer.Instance.leftHandHitInfo.normal * Physics.gravity.magnitude * wallWalkPower * -1, ForceMode.Acceleration);
                    ZeroGravity();
                }

                else if (GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false) && ControllerInputPoller.instance.leftGrab)
                {
                    GorillaTagger.Instance.rigidbody.AddForce(GorillaLocomotion.GTPlayer.Instance.rightHandHitInfo.normal * Physics.gravity.magnitude * wallWalkPower * -1, ForceMode.Acceleration);
                    ZeroGravity();
                }
            }

            else
            {
                if ((GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true) && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false)) && ControllerInputPoller.instance.rightGrab)
                {
                    GorillaTagger.Instance.rigidbody.AddForce(((GorillaLocomotion.GTPlayer.Instance.leftHandHitInfo.normal + GorillaLocomotion.GTPlayer.Instance.rightHandHitInfo.normal) / 2) * Physics.gravity.magnitude * wallWalkPower * -1, ForceMode.Acceleration);
                    ZeroGravity();
                }

                else if (GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true) && ControllerInputPoller.instance.rightGrab)
                {
                    GorillaTagger.Instance.rigidbody.AddForce(GorillaLocomotion.GTPlayer.Instance.leftHandHitInfo.normal * Physics.gravity.magnitude * wallWalkPower * -1, ForceMode.Acceleration);
                    ZeroGravity();
                }

                else if (GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false) && ControllerInputPoller.instance.rightGrab)
                {
                    GorillaTagger.Instance.rigidbody.AddForce(GorillaLocomotion.GTPlayer.Instance.rightHandHitInfo.normal * Physics.gravity.magnitude * wallWalkPower * -1, ForceMode.Acceleration);
                    ZeroGravity();
                }
            }
        }

        public static void NoFingerMovement()
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
            ControllerInputPoller.instance.leftControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerSecondaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerSecondaryButtonTouch = false;
        }

        public static void RestartGame()
        {
            Process.Start("steam://rungameid/1533390");
            Application.Quit();
        }

        public static void QuitGame()
        {
            Application.Quit();
        }

        public static void VisualDebugging()
        {
            ShowCoordinateLines();
            ShowVelocities();
            ShowNormals();
            ShowDistancesTraveled();
            ShowUnStickDistance();
            ShowVelocityAverage();
            ShowLongestJump();
        }

        public static void ShowCoordinateLines()
        {
            GameObject lineX = new GameObject("Line");
            LineRenderer lineXRenderer = lineX.AddComponent<LineRenderer>();
            lineXRenderer.material.shader = Shader.Find("GUI/Text Shader");
            lineXRenderer.startColor = new Color32(255, 0, 0, 128);
            lineXRenderer.endColor = new Color32(255, 0, 0, 128);
            lineXRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            lineXRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            lineXRenderer.positionCount = 2;
            lineXRenderer.useWorldSpace = true;
            lineXRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * GorillaLocomotion.GTPlayer.Instance.headCollider.radius * 10));
            lineXRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * GorillaLocomotion.GTPlayer.Instance.headCollider.radius * 10) + Vector3.right * GorillaLocomotion.GTPlayer.Instance.headCollider.radius);
            UnityEngine.Object.Destroy(lineX, Time.deltaTime);

            GameObject lineY = new GameObject("Line");
            LineRenderer lineYRenderer = lineY.AddComponent<LineRenderer>();
            lineYRenderer.material.shader = Shader.Find("GUI/Text Shader");
            lineYRenderer.startColor = new Color32(0, 255, 0, 128);
            lineYRenderer.endColor = new Color32(0, 255, 0, 128);
            lineYRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            lineYRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            lineYRenderer.positionCount = 2;
            lineYRenderer.useWorldSpace = true;
            lineYRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * GorillaLocomotion.GTPlayer.Instance.headCollider.radius * 10));
            lineYRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * GorillaLocomotion.GTPlayer.Instance.headCollider.radius * 10) + Vector3.up * GorillaLocomotion.GTPlayer.Instance.headCollider.radius);
            UnityEngine.Object.Destroy(lineY, Time.deltaTime);

            GameObject lineZ = new GameObject("Line");
            LineRenderer lineZRenderer = lineZ.AddComponent<LineRenderer>();
            lineZRenderer.material.shader = Shader.Find("GUI/Text Shader");
            lineZRenderer.startColor = new Color32(0, 0, 255, 128);
            lineZRenderer.endColor = new Color32(0, 0, 255, 128);
            lineZRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            lineZRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            lineZRenderer.positionCount = 2;
            lineZRenderer.useWorldSpace = true;
            lineZRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * GorillaLocomotion.GTPlayer.Instance.headCollider.radius * 10));
            lineZRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * GorillaLocomotion.GTPlayer.Instance.headCollider.radius * 10) + Vector3.forward * GorillaLocomotion.GTPlayer.Instance.headCollider.radius);
            UnityEngine.Object.Destroy(lineZ, Time.deltaTime);
        }

        public static Vector3 lastLeftHandPosition = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position;
        public static Vector3 lastRightHandPosition = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position;

        public static void ShowVelocities()
        {
            GameObject leftHandVelocity = new GameObject("Line");
            LineRenderer leftHandVelocityRenderer = leftHandVelocity.AddComponent<LineRenderer>();
            leftHandVelocityRenderer.material.shader = Shader.Find("GUI/Text Shader");
            leftHandVelocityRenderer.startColor = new Color32(255, 0, 0, 128);
            leftHandVelocityRenderer.endColor = new Color32(255, 0, 0, 128);
            leftHandVelocityRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            leftHandVelocityRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            leftHandVelocityRenderer.positionCount = 2;
            leftHandVelocityRenderer.useWorldSpace = true;
            leftHandVelocityRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position);
            leftHandVelocityRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position + (GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position - lastLeftHandPosition) / Time.deltaTime);
            UnityEngine.Object.Destroy(leftHandVelocity, Time.deltaTime);

            GameObject rightHandVelocity = new GameObject("Line");
            LineRenderer rightHandVelocityRenderer = rightHandVelocity.AddComponent<LineRenderer>();
            rightHandVelocityRenderer.material.shader = Shader.Find("GUI/Text Shader");
            rightHandVelocityRenderer.startColor = new Color32(255, 0, 0, 128);
            rightHandVelocityRenderer.endColor = new Color32(255, 0, 0, 128);
            rightHandVelocityRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            rightHandVelocityRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            rightHandVelocityRenderer.positionCount = 2;
            rightHandVelocityRenderer.useWorldSpace = true;
            rightHandVelocityRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position);
            rightHandVelocityRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position + (GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position - lastRightHandPosition) / Time.deltaTime);
            UnityEngine.Object.Destroy(rightHandVelocity, Time.deltaTime);

            lastLeftHandPosition = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position;
            lastRightHandPosition = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position;
        }

        public static void ShowNormals()
        {
            GameObject leftHandNormal = new GameObject("Line");
            LineRenderer leftHandNormalRenderer = leftHandNormal.AddComponent<LineRenderer>();
            leftHandNormalRenderer.material.shader = Shader.Find("GUI/Text Shader");
            leftHandNormalRenderer.startColor = new Color32(0, 0, 255, 128);
            leftHandNormalRenderer.endColor = new Color32(0, 0, 255, 128);
            leftHandNormalRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            leftHandNormalRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            leftHandNormalRenderer.positionCount = 2;
            leftHandNormalRenderer.useWorldSpace = true;
            leftHandNormalRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position);
            leftHandNormalRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position + GorillaLocomotion.GTPlayer.Instance.rightHandSlideNormal * GorillaLocomotion.GTPlayer.Instance.headCollider.radius * 0.1f);
            UnityEngine.Object.Destroy(leftHandNormal, Time.deltaTime);

            GameObject rightHandNormal = new GameObject("Line");
            LineRenderer rightHandNormalRenderer = rightHandNormal.AddComponent<LineRenderer>();
            rightHandNormalRenderer.material.shader = Shader.Find("GUI/Text Shader");
            rightHandNormalRenderer.startColor = new Color32(0, 0, 255, 128);
            rightHandNormalRenderer.endColor = new Color32(0, 0, 255, 128);
            rightHandNormalRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            rightHandNormalRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            rightHandNormalRenderer.positionCount = 2;
            rightHandNormalRenderer.useWorldSpace = true;
            rightHandNormalRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position);
            rightHandNormalRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position + GorillaLocomotion.GTPlayer.Instance.leftHandSlideNormal * GorillaLocomotion.GTPlayer.Instance.headCollider.radius * 0.1f);
            UnityEngine.Object.Destroy(rightHandNormal, Time.deltaTime);
        }

        public static void ShowDistancesTraveled()
        {
            GameObject leftHandDistanceTraveled = new GameObject("Line");
            LineRenderer leftHandDistanceTraveledRenderer = leftHandDistanceTraveled.AddComponent<LineRenderer>();
            leftHandDistanceTraveledRenderer.material.shader = Shader.Find("GUI/Text Shader");
            leftHandDistanceTraveledRenderer.startColor = new Color32(0, 255, 0, 128);
            leftHandDistanceTraveledRenderer.endColor = new Color32(0, 255, 0, 128);
            leftHandDistanceTraveledRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            leftHandDistanceTraveledRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            leftHandDistanceTraveledRenderer.positionCount = 2;
            leftHandDistanceTraveledRenderer.useWorldSpace = true;
            leftHandDistanceTraveledRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position);
            leftHandDistanceTraveledRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position + GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.rotation * GorillaLocomotion.GTPlayer.Instance.leftHandOffset);
            UnityEngine.Object.Destroy(leftHandDistanceTraveled, Time.deltaTime);

            GameObject rightHandDistanceTraveled = new GameObject("Line");
            LineRenderer rightHandDistanceTraveledRenderer = rightHandDistanceTraveled.AddComponent<LineRenderer>();
            rightHandDistanceTraveledRenderer.material.shader = Shader.Find("GUI/Text Shader");
            rightHandDistanceTraveledRenderer.startColor = new Color32(0, 255, 0, 128);
            rightHandDistanceTraveledRenderer.endColor = new Color32(0, 255, 0, 128);
            rightHandDistanceTraveledRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            rightHandDistanceTraveledRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            rightHandDistanceTraveledRenderer.positionCount = 2;
            rightHandDistanceTraveledRenderer.useWorldSpace = true;
            rightHandDistanceTraveledRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position);
            rightHandDistanceTraveledRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position + GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.rotation * GorillaLocomotion.GTPlayer.Instance.rightHandOffset);
            UnityEngine.Object.Destroy(rightHandDistanceTraveled, Time.deltaTime);
        }

        public static void ShowUnStickDistance()
        {
            GameObject leftHandUnStickDistance = new GameObject("Line");
            LineRenderer leftHandUnStickDistanceRenderer = leftHandUnStickDistance.AddComponent<LineRenderer>();
            leftHandUnStickDistanceRenderer.material.shader = Shader.Find("GUI/Text Shader");
            leftHandUnStickDistanceRenderer.startColor = new Color32(255, 255, 0, 128);
            leftHandUnStickDistanceRenderer.endColor = new Color32(255, 255, 0, 128);
            leftHandUnStickDistanceRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            leftHandUnStickDistanceRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            leftHandUnStickDistanceRenderer.positionCount = 2;
            leftHandUnStickDistanceRenderer.useWorldSpace = true;
            leftHandUnStickDistanceRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position);
            leftHandUnStickDistanceRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position + (GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position + GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.rotation * GorillaLocomotion.GTPlayer.Instance.leftHandOffset - GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position).normalized * GorillaLocomotion.GTPlayer.Instance.unStickDistance);
            UnityEngine.Object.Destroy(leftHandUnStickDistance, Time.deltaTime);

            GameObject rightHandUnStickDistance = new GameObject("Line");
            LineRenderer rightHandUnStickDistanceRenderer = rightHandUnStickDistance.AddComponent<LineRenderer>();
            rightHandUnStickDistanceRenderer.material.shader = Shader.Find("GUI/Text Shader");
            rightHandUnStickDistanceRenderer.startColor = new Color32(255, 255, 0, 128);
            rightHandUnStickDistanceRenderer.endColor = new Color32(255, 255, 0, 128);
            rightHandUnStickDistanceRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            rightHandUnStickDistanceRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            rightHandUnStickDistanceRenderer.positionCount = 2;
            rightHandUnStickDistanceRenderer.useWorldSpace = true;
            rightHandUnStickDistanceRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position);
            rightHandUnStickDistanceRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position + (GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position + GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.rotation * GorillaLocomotion.GTPlayer.Instance.rightHandOffset - GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position).normalized * GorillaLocomotion.GTPlayer.Instance.unStickDistance);
            UnityEngine.Object.Destroy(rightHandUnStickDistance, Time.deltaTime);
        }

        public static void ShowVelocityAverage()
        {
            GameObject velocityAverage = new GameObject("Line");
            LineRenderer velocityAverageRenderer = velocityAverage.AddComponent<LineRenderer>();
            velocityAverageRenderer.material.shader = Shader.Find("GUI/Text Shader");
            velocityAverageRenderer.startColor = new Color32(255, 255, 0, 128);
            velocityAverageRenderer.endColor = new Color32(255, 255, 0, 128);
            velocityAverageRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            velocityAverageRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            velocityAverageRenderer.positionCount = 2;
            velocityAverageRenderer.useWorldSpace = true;
            velocityAverageRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * GorillaLocomotion.GTPlayer.Instance.headCollider.radius * 10));
            velocityAverageRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + GorillaLocomotion.GTPlayer.Instance.AveragedVelocity + (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * GorillaLocomotion.GTPlayer.Instance.headCollider.radius * 10));
            UnityEngine.Object.Destroy(velocityAverage, Time.deltaTime);
        }

        public static void ShowVelocity()
        {
            GameObject velocity = new GameObject("Line");
            LineRenderer velocityRenderer = velocity.AddComponent<LineRenderer>();
            velocityRenderer.material.shader = Shader.Find("GUI/Text Shader");
            velocityRenderer.startColor = new Color32(255, 0, 0, 128);
            velocityRenderer.endColor = new Color32(255, 0, 0, 128);
            velocityRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            velocityRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
            velocityRenderer.positionCount = 2;
            velocityRenderer.useWorldSpace = true;
            velocityRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * GorillaLocomotion.GTPlayer.Instance.headCollider.radius * 10));
            velocityRenderer.SetPosition(1, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity + (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * GorillaLocomotion.GTPlayer.Instance.headCollider.radius * 10));
            UnityEngine.Object.Destroy(velocity, Time.deltaTime);
        }

        public static void ShowPredictedPositions()
        {
            Vector3 predictedVelocity = Vector3.zero;
            Vector3 predictedPosition = Vector3.zero;

            Vector3[] predictedPositions = new Vector3[60];

            predictedVelocity = GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity;
            predictedPosition = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position;

            for (int i = 0; i < predictedPositions.Length; i++)
            {
                predictedVelocity += Physics.gravity * Time.deltaTime;
                predictedPosition += predictedVelocity * Time.deltaTime;
                predictedPositions[i] = predictedPosition;
            }

            for (int i = 0; i < predictedPositions.Length; i++)
            {
                if (i == 0)
                {
                    GameObject lineToPredictedPosition = new GameObject("Line");
                    LineRenderer lineToPredictedPositionRenderer = lineToPredictedPosition.AddComponent<LineRenderer>();
                    lineToPredictedPositionRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    lineToPredictedPositionRenderer.startColor = new Color32(100, 100, 100, 128);
                    lineToPredictedPositionRenderer.endColor = new Color32(100, 100, 100, 128);
                    lineToPredictedPositionRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
                    lineToPredictedPositionRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
                    lineToPredictedPositionRenderer.positionCount = 2;
                    lineToPredictedPositionRenderer.useWorldSpace = true;
                    lineToPredictedPositionRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position);
                    lineToPredictedPositionRenderer.SetPosition(1, predictedPosition);
                    UnityEngine.Object.Destroy(lineToPredictedPosition, Time.deltaTime);
                }

                else
                {
                    GameObject lineToPredictedPosition = new GameObject("Line");
                    LineRenderer lineToPredictedPositionRenderer = lineToPredictedPosition.AddComponent<LineRenderer>();
                    lineToPredictedPositionRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    lineToPredictedPositionRenderer.startColor = new Color32(100, 100, 100, 128);
                    lineToPredictedPositionRenderer.endColor = new Color32(100, 100, 100, 128);
                    lineToPredictedPositionRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
                    lineToPredictedPositionRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
                    lineToPredictedPositionRenderer.positionCount = 2;
                    lineToPredictedPositionRenderer.useWorldSpace = true;
                    lineToPredictedPositionRenderer.SetPosition(0, predictedPositions[i - 1]);
                    lineToPredictedPositionRenderer.SetPosition(1, predictedPositions[i]);
                    UnityEngine.Object.Destroy(lineToPredictedPosition, Time.deltaTime);
                }
            }
        }

        public static Vector3 longJumpPointA;
        public static Vector3 longJumpPointB;
        public static Vector3 longestJumpPointA;
        public static Vector3 longestJumpPointB;

        public static float longestJumpDistance = 0;

        public static bool longestJumpSet = false;
        public static bool longJumpPointASet = false;
        public static bool longJumpPointBSet = false;

        public static int longestJumpIndex = 0;

        public static void ShowLongestJump()
        {
            if (GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true) || GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false))
            {
                longestJumpIndex = (longestJumpIndex + 1) % 2;

                if (longestJumpIndex == 1)
                {
                    if (GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true) && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false))
                    {
                        longJumpPointB = (GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position + GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position) / 2;
                        longJumpPointBSet = true;
                    }

                    else if (GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true))
                    {
                        longJumpPointB = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position;
                        longJumpPointBSet = true;
                    }

                    else if (GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false))
                    {
                        longJumpPointB = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position;
                        longJumpPointBSet = true;
                    }
                }

                else
                {
                    if (GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true) && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false))
                    {
                        longJumpPointA = (GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position + GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position) / 2;
                        longJumpPointASet = true;
                    }

                    else if (GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true))
                    {
                        longJumpPointA = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position;
                        longJumpPointASet = true;
                    }

                    else if (GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false))
                    {
                        longJumpPointA = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position;
                        longJumpPointASet = true;
                    }
                }
            }

            if ((longJumpPointASet && longJumpPointBSet) && (Vector3.Distance(longJumpPointA, longJumpPointB) > longestJumpDistance))
            {
                longestJumpPointA = longJumpPointA;
                longestJumpPointB = longJumpPointB;
                longestJumpDistance = Vector3.Distance(longestJumpPointA, longestJumpPointB);
                longestJumpSet = true;
            }

            if (longestJumpSet)
            {
                GameObject longestJumpLine = new GameObject("Line");
                LineRenderer longestJumpLineRenderer = longestJumpLine.AddComponent<LineRenderer>();
                longestJumpLineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                longestJumpLineRenderer.startColor = new Color32(0, 255, 0, 128);
                longestJumpLineRenderer.endColor = new Color32(0, 255, 0, 128);
                longestJumpLineRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
                longestJumpLineRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
                longestJumpLineRenderer.positionCount = 2;
                longestJumpLineRenderer.useWorldSpace = true;
                longestJumpLineRenderer.SetPosition(0, longestJumpPointA);
                longestJumpLineRenderer.SetPosition(1, longestJumpPointB);
                UnityEngine.Object.Destroy(longestJumpLine, Time.deltaTime);
            }
        }

        public static void ResetLongestJump()
        {
            longJumpPointA = Vector3.zero;
            longJumpPointB = Vector3.zero;
            longestJumpPointA = Vector3.zero;
            longestJumpPointB = Vector3.zero;
            longestJumpDistance = 0;
            longestJumpSet = false;
            longJumpPointASet = false;
            longJumpPointBSet = false;
            longestJumpIndex = 0;
        }

        public static void EasyUnStick()
        {
            GorillaLocomotion.GTPlayer.Instance.unStickDistance = 0;
        }

        public static void ResetUnStickDistance()
        {
            GorillaLocomotion.GTPlayer.Instance.unStickDistance = originalUnStickDistance;
        }

        public static void SlideControl()
        {
            GorillaLocomotion.GTPlayer.Instance.slideControl = 1f;
        }

        public static void ResetSlideControl()
        {
            GorillaLocomotion.GTPlayer.Instance.slideControl = originalSlideControl;
        }

        public static Vector3 jumpInfoPointA;
        public static Vector3 jumpInfoPointB;

        public static bool jumpInfoPointASet = false;
        public static bool jumpInfoPointBSet = false;

        public static int jumpInfoIndex = 0;

        public static bool notifyJumpInfoWasLeftHandTouching = false;
        public static bool notifyJumpInfoWasRightHandTouching = false;

        public static void NotifyJumpInfo()
        {
            if ((!notifyJumpInfoWasLeftHandTouching && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true)) || (!notifyJumpInfoWasRightHandTouching && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false)))
            {
                jumpInfoIndex = (jumpInfoIndex + 1) % 2;

                if (jumpInfoIndex == 1)
                {
                    if ((!notifyJumpInfoWasLeftHandTouching && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true)) && (!notifyJumpInfoWasRightHandTouching && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false)))
                    {
                        jumpInfoPointB = (GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position + GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position) / 2;
                        jumpInfoPointBSet = true;
                    }

                    else if (!notifyJumpInfoWasLeftHandTouching && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true))
                    {
                        jumpInfoPointB = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position;
                        jumpInfoPointBSet = true;
                    }

                    else if (!notifyJumpInfoWasRightHandTouching && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false))
                    {
                        jumpInfoPointB = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position;
                        jumpInfoPointBSet = true;
                    }
                }

                else
                {
                    if ((!notifyJumpInfoWasLeftHandTouching && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true)) && (notifyJumpInfoWasRightHandTouching && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false)))
                    {
                        jumpInfoPointA = (GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position + GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position) / 2;
                        jumpInfoPointASet = true;
                    }

                    else if (!notifyJumpInfoWasLeftHandTouching && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true))
                    {
                        jumpInfoPointA = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position;
                        jumpInfoPointASet = true;
                    }

                    else if (!notifyJumpInfoWasRightHandTouching && GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false))
                    {
                        jumpInfoPointA = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position;
                        jumpInfoPointASet = true;
                    }
                }
            }

            if (jumpInfoPointASet && jumpInfoPointBSet)
            {
                NotifiLib.SendNotification("Jump Info = {Distance = " + Vector3.Distance(jumpInfoPointA, jumpInfoPointB) + "m}");
            }

            notifyJumpInfoWasLeftHandTouching = GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true);
            notifyJumpInfoWasRightHandTouching = GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false);
        }

        public static void ClearAllNotifications()
        {
            NotifiLib.ClearAllNotifications();
        }

        public static void NotifySelfID()
        {
            NotifiLib.SendNotification(PhotonNetwork.LocalPlayer.UserId);
        }

        public static bool notifyPlayerIDWasLeftControllerTrigger = ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f;
        public static bool notifyPlayerIDWasRightControllerTrigger = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f;

        public static void NotifyPlayerID()
        {
            RaycastHit hitInfo;

            if (rightHanded)
            {
                if (!notifyPlayerIDWasLeftControllerTrigger && ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position, GorillaLocomotion.GTPlayer.Instance.leftHandFollower.forward, out hitInfo, math.INFINITY, GorillaLocomotion.GTPlayer.Instance.locomotionEnabledLayers.value))
                    {
                        VRRig vrRig = hitInfo.collider.GetComponentInParent<VRRig>();

                        if (vrRig && !PlayerIsLocal(vrRig))
                        {
                            NetPlayer netPlayer = GetPlayerFromVRRig(vrRig);

                            NotifiLib.SendNotification(netPlayer.UserId);
                        }
                    }
                }

                if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position, GorillaLocomotion.GTPlayer.Instance.leftHandFollower.forward, out hitInfo, math.INFINITY, GorillaLocomotion.GTPlayer.Instance.locomotionEnabledLayers.value))
                {
                    GameObject raycastLine = new GameObject("Line");
                    LineRenderer raycastLineRenderer = raycastLine.AddComponent<LineRenderer>();
                    raycastLineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    raycastLineRenderer.startColor = new Color32(255, 255, 255, 128);
                    raycastLineRenderer.endColor = new Color32(255, 255, 255, 128);
                    raycastLineRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
                    raycastLineRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
                    raycastLineRenderer.positionCount = 2;
                    raycastLineRenderer.useWorldSpace = true;
                    raycastLineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position);
                    raycastLineRenderer.SetPosition(1, hitInfo.point);
                    UnityEngine.Object.Destroy(raycastLine, Time.deltaTime);
                }
            }

            else
            {
                if (!notifyPlayerIDWasRightControllerTrigger && ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position, GorillaLocomotion.GTPlayer.Instance.rightHandFollower.forward, out hitInfo, math.INFINITY, GorillaLocomotion.GTPlayer.Instance.locomotionEnabledLayers.value))
                    {
                        VRRig vrRig = hitInfo.collider.GetComponentInParent<VRRig>();

                        if (vrRig && !PlayerIsLocal(vrRig))
                        {
                            NetPlayer netPlayer = GetPlayerFromVRRig(vrRig);

                            NotifiLib.SendNotification(netPlayer.UserId);
                        }
                    }
                }

                if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position, GorillaLocomotion.GTPlayer.Instance.rightHandFollower.forward, out hitInfo, math.INFINITY, GorillaLocomotion.GTPlayer.Instance.locomotionEnabledLayers.value))
                {
                    GameObject raycastLine = new GameObject("Line");
                    LineRenderer raycastLineRenderer = raycastLine.AddComponent<LineRenderer>();
                    raycastLineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    raycastLineRenderer.startColor = new Color32(255, 255, 255, 128);
                    raycastLineRenderer.endColor = new Color32(255, 255, 255, 128);
                    raycastLineRenderer.startWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
                    raycastLineRenderer.endWidth = 0.1f * GorillaLocomotion.GTPlayer.Instance.headCollider.radius;
                    raycastLineRenderer.positionCount = 2;
                    raycastLineRenderer.useWorldSpace = true;
                    raycastLineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position);
                    raycastLineRenderer.SetPosition(1, hitInfo.point);
                    UnityEngine.Object.Destroy(raycastLine, Time.deltaTime);
                }
            }

            notifyPlayerIDWasLeftControllerTrigger = ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f;
            notifyPlayerIDWasRightControllerTrigger = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f;
        }

        public static void NoclipFly()
        {
            MeshCollider[] meshColliders = Resources.FindObjectsOfTypeAll<MeshCollider>();

            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;

                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = false;
                    }
                }

                else
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = true;
                    }
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;

                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = false;
                    }
                }

                else
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = true;
                    }
                }
            }
        }

        public static void TriggerNoclipFly()
        {
            MeshCollider[] meshColliders = Resources.FindObjectsOfTypeAll<MeshCollider>();

            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;

                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = false;
                    }
                }

                else
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = true;
                    }
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;

                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = false;
                    }
                }

                else
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = true;
                    }
                }
            }
        }

        public static void GripNoclipFly()
        {
            MeshCollider[] meshColliders = Resources.FindObjectsOfTypeAll<MeshCollider>();

            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;

                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = false;
                    }
                }

                else
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = true;
                    }
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;

                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = false;
                    }
                }

                else
                {
                    foreach (MeshCollider meshCollider in meshColliders)
                    {
                        meshCollider.enabled = true;
                    }
                }
            }
        }

        public static void JumpSpeedBoost()
        {
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = 6.5f * 2f;
        }

        public static void MosaJumpSpeedBoost()
        {
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = 6.5f * 1.25f;
        }

        public static void JumpMultiplierBoost()
        {
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 1.1f * 2f;
        }

        public static void MosaJumpMultiplierBoost()
        {
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 1.1f * 1.25f;
        }

        public static void EnableKinematicRigidBody()
        {
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().isKinematic = true;
        }

        public static void DisableKinematicRigidBody()
        {
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().isKinematic = false;
        }

        public static void NoArmOffsets()
        {
            GorillaLocomotion.GTPlayer.Instance.leftHandOffset = Vector3.zero;
            GorillaLocomotion.GTPlayer.Instance.rightHandOffset = Vector3.zero;
        }

        public static void NoLeftHandOffset()
        {
            GorillaLocomotion.GTPlayer.Instance.leftHandOffset = Vector3.zero;
        }

        public static void NoRightHandOffset()
        {
            GorillaLocomotion.GTPlayer.Instance.rightHandOffset = Vector3.zero;
        }

        public static void FlingSelf()
        {
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Physics.gravity * -10;
        }

        public static void FastFly()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * 2f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * 2f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }

        public static void TriggerFastFly()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * 2f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * 2f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }

        public static void GripFastFly()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * 2f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * 6.5f * 2f * Time.deltaTime;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }

        public static void MultipliedVelocity()
        {
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity * Time.deltaTime;
        }

        public static void MosaMultipliedVelocity()
        {
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity * 0.25f * Time.deltaTime;
        }

        public static void DividedVelocity()
        {
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity -= GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity * 0.5f * Time.deltaTime;
        }

        public static void DoubledVelocity()
        {
            GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity * Time.deltaTime;
        }

        public static void HalfedVelocity()
        {
            GorillaLocomotion.GTPlayer.Instance.transform.position -= GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity * 0.5f * Time.deltaTime;
        }

        public static void HalfedJumpMultiplier()
        {
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 1.1f * 0.5f;
        }

        public static void NormalizedVelocity()
        {
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity.normalized * GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed;
        }

        public static int AdvancedRigIndex = 0;

        public static void ChangeAdvancedRigMultiplier()
        {
            float[] advancedRigMultipliers = { 0.0001f, 0.001f, 0.01f, 0.1f, 1f };

            string[] advancedRigMultiplierNames = { "Tiny", "Small", "Normal", "Big", "Huge" };

            AdvancedRigIndex = (AdvancedRigIndex + 1) % advancedRigMultipliers.Length;
            AdvancedRigMultiplier = advancedRigMultipliers[AdvancedRigIndex];
            GetIndex("Change Advanced Rig Multiplier").overlapText = "Change Advanced Rig Multiplier <color=grey>[</color><color=green>" + advancedRigMultiplierNames[AdvancedRigIndex] + "</color><color=grey>]</color>" + " " + advancedRigMultipliers[AdvancedRigIndex];
        }

        public static float AdvancedRigMultiplier = 1;

        public static void AdvancedRig()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset = originalHeadTrackingPositionOffset + new Vector3(Vector3.Dot(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right, GorillaLocomotion.GTPlayer.Instance.AveragedVelocity), Vector3.Dot(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.up, GorillaLocomotion.GTPlayer.Instance.AveragedVelocity), Vector3.Dot(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward, GorillaLocomotion.GTPlayer.Instance.AveragedVelocity)) * AdvancedRigMultiplier;
            GorillaTagger.Instance.offlineVRRig.headBodyOffset = originalHeadBodyOffset + new Vector3(Vector3.Dot(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right, GorillaLocomotion.GTPlayer.Instance.AveragedVelocity), Vector3.Dot(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.up, GorillaLocomotion.GTPlayer.Instance.AveragedVelocity), Vector3.Dot(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward, GorillaLocomotion.GTPlayer.Instance.AveragedVelocity)) * AdvancedRigMultiplier;
            GorillaTagger.Instance.offlineVRRig.leftHand.trackingPositionOffset = originalLeftHandTrackingPositionOffset + new Vector3(Vector3.Dot(GorillaLocomotion.GTPlayer.Instance.leftHandFollower.right, (((GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + GorillaLocomotion.GTPlayer.Instance.AveragedVelocity * AdvancedRigMultiplier) + (GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position)) - GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position)), Vector3.Dot(GorillaLocomotion.GTPlayer.Instance.leftHandFollower.up, (((GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + GorillaLocomotion.GTPlayer.Instance.AveragedVelocity * AdvancedRigMultiplier) + (GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position)) - GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position)), Vector3.Dot(GorillaLocomotion.GTPlayer.Instance.leftHandFollower.forward, (((GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + GorillaLocomotion.GTPlayer.Instance.AveragedVelocity * AdvancedRigMultiplier) + (GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position)) - GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position)));
            GorillaTagger.Instance.offlineVRRig.rightHand.trackingPositionOffset = originalRightHandTrackingPositionOffset + new Vector3(Vector3.Dot(GorillaLocomotion.GTPlayer.Instance.rightHandFollower.right, (((GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + GorillaLocomotion.GTPlayer.Instance.AveragedVelocity * AdvancedRigMultiplier) + (GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position)) - GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position)), Vector3.Dot(GorillaLocomotion.GTPlayer.Instance.rightHandFollower.up, (((GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + GorillaLocomotion.GTPlayer.Instance.AveragedVelocity * AdvancedRigMultiplier) + (GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position)) - GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position)), Vector3.Dot(GorillaLocomotion.GTPlayer.Instance.rightHandFollower.forward, (((GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + GorillaLocomotion.GTPlayer.Instance.AveragedVelocity * AdvancedRigMultiplier) + (GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position)) - GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position)));
        }

        public static void ResetOfflineVRRigOffsets()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset = originalHeadTrackingPositionOffset;
            GorillaTagger.Instance.offlineVRRig.headBodyOffset = originalHeadBodyOffset;
            GorillaTagger.Instance.offlineVRRig.leftHand.trackingPositionOffset = originalLeftHandTrackingPositionOffset;
            GorillaTagger.Instance.offlineVRRig.rightHand.trackingPositionOffset = originalRightHandTrackingPositionOffset;
        }

        public static bool groundAssistWasLeftHandTouching = false;
        public static bool groundAssistWasRightHandTouching = false;

        public static void GroundAssist()
        {
            if (((!GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true) && groundAssistWasLeftHandTouching) || (!GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false) && groundAssistWasRightHandTouching)))
            {
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity += (Vector3.ProjectOnPlane(GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward, Physics.gravity.normalized).normalized * GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed - GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity) / 2;
            }

            groundAssistWasLeftHandTouching = GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true);
            groundAssistWasRightHandTouching = GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false);
        }

        public static int antiWorldScaleCheckIndex = 0;

        public static void ChangeAntiWorldScaleCheckMultiplier()
        {
            float[] antiWorldScaleCheckMultipliers = { 0.0625f, 0.125f, 0.25f, 0.5f, 1f };

            string[] antiWorldScaleCheckMultiplierNames = { "Tiny", "Small", "Normal", "Big", "Huge" };

            antiWorldScaleCheckIndex = (antiWorldScaleCheckIndex + 1) % antiWorldScaleCheckMultipliers.Length;
            antiWorldScaleCheckMultiplier = antiWorldScaleCheckMultipliers[antiWorldScaleCheckIndex];
            GetIndex("Change Anti World Scale Check Multiplier").overlapText = "Change Anti World Scale Check Multiplier <color=grey>[</color><color=green>" + antiWorldScaleCheckMultiplierNames[antiWorldScaleCheckIndex] + "</color><color=grey>]</color>" + " " + antiWorldScaleCheckMultipliers[antiWorldScaleCheckIndex];
        }

        public static float antiWorldScaleCheckMultiplier = 0.0625f;

        public static void AntiWorldScaleCheck()
        {
            Vector3 antiWorldScaleCheckCurrentLeftHandPosition;
            Vector3 antiWorldScaleCheckCurrentRightHandPosition;

            if (Vector3.Distance(GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position + GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.rotation * GorillaLocomotion.GTPlayer.Instance.leftHandOffset, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position) < GorillaLocomotion.GTPlayer.Instance.maxArmLength)
            {
                antiWorldScaleCheckCurrentLeftHandPosition = GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position + GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.rotation * GorillaLocomotion.GTPlayer.Instance.leftHandOffset;
            }

            else
            {
                antiWorldScaleCheckCurrentLeftHandPosition = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + ((GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position + GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.rotation * GorillaLocomotion.GTPlayer.Instance.leftHandOffset) - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position).normalized * GorillaLocomotion.GTPlayer.Instance.maxArmLength;
            }

            if (Vector3.Distance(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position + GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.rotation * GorillaLocomotion.GTPlayer.Instance.rightHandOffset, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position) < GorillaLocomotion.GTPlayer.Instance.maxArmLength)
            {
                antiWorldScaleCheckCurrentRightHandPosition = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position + GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.rotation * GorillaLocomotion.GTPlayer.Instance.rightHandOffset;
            }

            else
            {
                antiWorldScaleCheckCurrentRightHandPosition = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + ((GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position + GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.rotation * GorillaLocomotion.GTPlayer.Instance.rightHandOffset) - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position).normalized * GorillaLocomotion.GTPlayer.Instance.maxArmLength;
            }

            float antiWorldScaleCheckLeftHandMultiplier = (1f - antiWorldScaleCheckMultiplier) + (Vector3.Distance(antiWorldScaleCheckCurrentLeftHandPosition, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position) / GorillaLocomotion.GTPlayer.Instance.maxArmLength) * antiWorldScaleCheckMultiplier;
            float antiWorldScaleCheckRightHandMultiplier = (1f - antiWorldScaleCheckMultiplier) + (Vector3.Distance(antiWorldScaleCheckCurrentRightHandPosition, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position) / GorillaLocomotion.GTPlayer.Instance.maxArmLength) * antiWorldScaleCheckMultiplier;

            GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + (antiWorldScaleCheckCurrentLeftHandPosition - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position) * antiWorldScaleCheckLeftHandMultiplier;
            GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position + (antiWorldScaleCheckCurrentRightHandPosition - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position) * antiWorldScaleCheckRightHandMultiplier;
        }

        public static float SphereGetDistanceToSphere(Vector3 spherePosition, float sphereRadius, Vector3 otherSpherePosition, float otherSphereRadius)
        {
            return math.max(0, Vector3.Distance(spherePosition, otherSpherePosition) - sphereRadius + otherSphereRadius);
        }

        public static float PointGetDistanceToSphere(Vector3 pointPosition, Vector3 spherePosition, float sphereRadius)
        {
            return math.max(0, Vector3.Distance(pointPosition, spherePosition) - sphereRadius);
        }

        public static float CylinderGetDistanceToSphere(Vector3 cylinderPosition, float cylinderRadius, float cylinderHeight, Vector3 spherePosition, float sphereRadius)
        {
            return 0;
        }

        public static float CapsuleGetDistanceToSphere(Vector3 capsulePosition, float capsuleRadius, float CapsuleHeight, Vector3 capsuleUpVector, Vector3 spherePosition, float sphereRadius)
        {
            return 0;
        }

        public static void NotifyIsMasterCilent()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("IsMasterCilent : true");
            }

            else
            {
                NotifiLib.SendNotification("IsMasterCilent : false");
            }
        }

        public static void SlowMotionMovement()
        {
            HalfedJumpSpeed();
            HalfedJumpMultiplier();
            JumpMultiplierBoost();
            LowGravity();
        }

        public static void HalfedJumpSpeed()
        {
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = 6.5f * 0.5f;
        }

        public static void Slowboost()
        {
            HalfedJumpSpeed();
            HalfedJumpMultiplier();
        }

        public static Vector3 CheckpointPosition = Vector3.zero;

        public static void Checkpoint()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    CheckpointPosition = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position;
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }

                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position = CheckpointPosition + (GorillaLocomotion.GTPlayer.Instance.transform.position - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position);
                    GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    CheckpointPosition = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position;
                }

                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.position = CheckpointPosition + (GorillaLocomotion.GTPlayer.Instance.transform.position - GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position);
                }
            }
        }

        public static Vector3 PathfindingCheckpointPosition = Vector3.zero;

        public static void PathfindingCheckpoint()
        {
            if (GorillaLocomotion.GTPlayer.Instance.bodyCollider.gameObject.GetComponent<NavMeshAgent>() == null)
            {
                GorillaLocomotion.GTPlayer.Instance.bodyCollider.AddComponent<NavMeshAgent>();
            }

            GorillaLocomotion.GTPlayer.Instance.bodyCollider.GetComponent<NavMeshAgent>().radius = GorillaLocomotion.GTPlayer.Instance.bodyCollider.radius;
            GorillaLocomotion.GTPlayer.Instance.bodyCollider.GetComponent<NavMeshAgent>().height = GorillaLocomotion.GTPlayer.Instance.bodyCollider.height;

            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    PathfindingCheckpointPosition = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position;
                }

                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.bodyCollider.GetComponent<NavMeshAgent>().SetDestination(PathfindingCheckpointPosition);
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    PathfindingCheckpointPosition = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position;
                }

                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    GorillaLocomotion.GTPlayer.Instance.bodyCollider.GetComponent<NavMeshAgent>().SetDestination(PathfindingCheckpointPosition);
                }
            }
        }

        public static void GripSpeedboost()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    Speedboost();
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    Speedboost();
                }
            }
        }

        public static void TriggerSpeedboost()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    Speedboost();
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    Speedboost();
                }
            }
        }

        public static void PrimaryButtonSpeedboost()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    Speedboost();
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    Speedboost();
                }
            }
        }

        public static void GripMosaSpeedboost()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    MosaSpeedboost();
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    MosaSpeedboost();
                }
            }
        }

        public static void TriggerMosaSpeedboost()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f)
                {
                    MosaSpeedboost();
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    MosaSpeedboost();
                }
            }
        }

        public static void PrimaryButtonMosaSpeedboost()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    MosaSpeedboost();
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    MosaSpeedboost();
                }
            }
        }

        public static Vector3 MarkedPosition;

        public static void MarkPosition()
        {
            if (rightHanded)
            {
                if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    MarkedPosition = GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position;
                }
            }

            else
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    MarkedPosition = GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position;
                }
            }
        }

        public static int ButtonSpamMarkedPositionIndex = 0;

        public static void ButtonSpamMarkedPosition()
        {
            ButtonSpamMarkedPositionIndex = (ButtonSpamMarkedPositionIndex + 1) % 2;

            if (ButtonSpamMarkedPositionIndex == 1)
            {
                if (rightHanded)
                {
                    GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position = MarkedPosition + (GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position - GorillaLocomotion.GTPlayer.Instance.leftHandFollower.position);
                }

                else
                {
                    GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position = MarkedPosition + (GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position - GorillaLocomotion.GTPlayer.Instance.rightHandFollower.position);
                }
            }
        }

        public static Vector3 noVelocityAverageLastPosition = GorillaLocomotion.GTPlayer.Instance.transform.position;

        public static void NoVelocityAverage()
        {
            Vector3 currentVelocity = (GorillaLocomotion.GTPlayer.Instance.transform.position - noVelocityAverageLastPosition) / Time.deltaTime;

            if (GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true) || GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false))
            {
                if (currentVelocity.magnitude > GorillaLocomotion.GTPlayer.Instance.velocityLimit)
                {
                    if (currentVelocity.magnitude * GorillaLocomotion.GTPlayer.Instance.jumpMultiplier > GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed)
                    {
                        GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = currentVelocity.normalized * GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed;
                    }
                    else
                    {
                        GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.GTPlayer.Instance.jumpMultiplier * currentVelocity;
                    }
                }
            }

            noVelocityAverageLastPosition = GorillaLocomotion.GTPlayer.Instance.transform.position;
        }

        public static void NoSlideControl()
        {
            GorillaLocomotion.GTPlayer.Instance.slideControl = 0;
        }

        public static void FullSlideFactor()
        {
            GorillaLocomotion.GTPlayer.Instance.defaultSlideFactor = 1;
        }

        public static void FullPrecision()
        {
            GorillaLocomotion.GTPlayer.Instance.defaultPrecision = 1;
        }
        public static void ResetDefaultPrecision()
        {
            GorillaLocomotion.GTPlayer.Instance.defaultPrecision = originalDefaultPrecision;
        }

        public static void ResetDefaultSlideFactor()
        {
            GorillaLocomotion.GTPlayer.Instance.defaultSlideFactor = originalDefaultSlideFactor;
        }

        public static void DisabledRigidBody()
        {
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;

            float distanceFallen = 0.5f * Physics.gravity.magnitude * Time.deltaTime * Time.deltaTime;

            if (!GorillaLocomotion.GTPlayer.Instance.IsHandTouching(true) && !GorillaLocomotion.GTPlayer.Instance.IsHandTouching(false))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position -= Physics.gravity.normalized * distanceFallen * -1;
            }
        }
    }
}