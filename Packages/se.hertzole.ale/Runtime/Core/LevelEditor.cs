﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hertzole.ALE
{
#if UNITY_EDITOR
    [DisallowMultipleComponent]
    [AddComponentMenu("ALE/Level Editor", 1)]
#endif
    [DefaultExecutionOrder(-10000)]
    public class LevelEditor : MonoBehaviour, ILevelEditor
    {
        [SerializeField, RequireType(typeof(ILevelEditorCamera))]
        private GameObject editorCamera = null;
        [SerializeField, RequireType(typeof(ILevelEditorUI))]
        private GameObject ui = null;
        [SerializeField, RequireType(typeof(ILevelEditorSaveManager))]
        private GameObject saveManager = null;
        [SerializeField, RequireType(typeof(ILevelEditorObjectManager))]
        private GameObject objectManager = null;
        [SerializeField, RequireType(typeof(ILevelEditorInput))]
        private GameObject input = null;
        [SerializeField, RequireType(typeof(ILevelEditorSelection))]
        private GameObject selection = null;
        [SerializeField, RequireType(typeof(ILevelEditorUndo))]
        private GameObject undo = null;
        [SerializeField, RequireType(typeof(ILevelEditorPlayMode))]
        private GameObject playMode = null;

        [Space]

        [SerializeField]
        private LevelEditorSnapping snapSettings = new LevelEditorSnapping();

        private bool isDirty = false;

        private int selectedMode = -1;

        private ILevelEditorMode[] editorModes;

        private ILevelEditorCamera editorCameraComp;
        private ILevelEditorUI uiComp;
        private ILevelEditorSaveManager saveManagerComp;
        private ILevelEditorObjectManager objectManagerComp;
        private ILevelEditorPlayMode playModeComp;
        private ILevelEditorInput inputComp;
        private ILevelEditorSelection selectionComp;
        private ILevelEditorUndo undoComp;

        public ILevelEditorSnapping Snapping { get { return snapSettings; } }
        public ILevelEditorCamera LevelEditorCamera { get { return editorCameraComp; } set { editorCameraComp = value; } }
        public ILevelEditorUI UI { get { return uiComp; } set { uiComp = value; } }
        public ILevelEditorSaveManager SaveManager { get { return saveManagerComp; } set { saveManagerComp = value; } }
        public ILevelEditorObjectManager ObjectManager { get { return objectManagerComp; } set { objectManagerComp = value; } }
        public ILevelEditorPlayMode PlayMode { get { return playModeComp; } set { playModeComp = value; } }
        public ILevelEditorInput Input { get { return inputComp; } set { inputComp = value; } }
        public ILevelEditorSelection Selection { get { return selectionComp; } set { selectionComp = value; } }
        public ILevelEditorUndo Undo { get { return undoComp; } set { undoComp = value; } }

        public IReadOnlyList<ILevelEditorMode> EditorModes { get { return editorModes; } set { editorModes = value.ToArrayFast(); } }
        
        public bool IsDirty { get { return isDirty; } }

        private void Awake()
        {
            if (editorCamera != null) { editorCameraComp = editorCamera.NeedComponent<ILevelEditorCamera>(); }
            if (ui != null) { uiComp = ui.NeedComponent<ILevelEditorUI>(); } 
            if (saveManager != null) { saveManagerComp = saveManager.NeedComponent<ILevelEditorSaveManager>(); }
            if (objectManager != null) { objectManagerComp = objectManager.NeedComponent<ILevelEditorObjectManager>(); }
            if (input != null) { inputComp = input.NeedComponent<ILevelEditorInput>(); }
            if (selection != null) { selectionComp = selection.NeedComponent<ILevelEditorSelection>(); }
            if (undo != null) { undoComp = undo.NeedComponent<ILevelEditorUndo>(); }
            if (playMode != null) { playModeComp = playMode.NeedComponent<ILevelEditorPlayMode>(); }
            
            editorModes = GetComponents<ILevelEditorMode>();

            if (editorModes != null && editorModes.Length > 0)
            {
                for (int i = 0; i < editorModes.Length; i++)
                {
                    if (editorModes[i] is LevelEditorMode mode)
                    {
                        mode.LevelEditor = this;
                    }
                }
            }
        }

        private void Start()
        {
            if (uiComp != null)
            {
                uiComp.Initialize(this);
            }

            if (editorModes != null && editorModes.Length > 0)
            {
                for (int i = 0; i < editorModes.Length; i++)
                {
                    editorModes[i].OnModeDisable();
                }

                SetMode(0);
            }
            // else
            // {
            //     LevelEditorLogger.DebugLogError("There are no editor mode components (Extends LevelEditorMode or implements ILevelEditorMode) attached on the level editor object. At least one must be present to function.");
            // }
        }

        private void OnEnable()
        {
            if (objectManagerComp != null)
            {
                objectManagerComp.OnCreatedObject += OnCreateDeleteObject;
            }

            if (playModeComp != null)
            {
                playModeComp.OnStartPlayMode += OnStartPlayMode;
                playModeComp.OnStopPlayMode += OnStopPlayMode;
            }
        }

        private void OnDisable()
        {
            if (objectManagerComp != null)
            {
                objectManagerComp.OnCreatedObject -= OnCreateDeleteObject;
            }

            if (playModeComp != null)
            {
                playModeComp.OnStartPlayMode -= OnStartPlayMode;
                playModeComp.OnStopPlayMode -= OnStopPlayMode;
            }
        }

        private void Update()
        {
            if (selectedMode >= 0 && editorModes.Length > 0 && (playModeComp != null && !playModeComp.IsPlaying || playModeComp == null))
            {
                editorModes[selectedMode].OnModeUpdate();
            }
        }

        public void SetMode(int newMode, bool wrapAroundOutOfRange = false)
        {
#if !ALE_STRIP_SAFETY
            if (editorModes.Length == 0)
            {
                throw new MissingReferenceException($"There are no editor modes attached on {gameObject.name}.");
            }
#endif
            
            if (newMode < 0)
            {
                if (wrapAroundOutOfRange)
                {
                    newMode = editorModes.Length - 1;
                }
#if !ALE_STRIP_SAFETY
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(newMode), $"{nameof(newMode)} must be between 0 and {editorModes.Length - 1}.");
                }
#endif
            }
            else if (newMode >= editorModes.Length)
            {
                if (wrapAroundOutOfRange)
                {
                    newMode = 0;
                }
#if !ALE_STRIP_SAFETY
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(newMode), $"{nameof(newMode)} must be between 0 and {editorModes.Length - 1}.");
                }
#endif
            }

            if (selectedMode == newMode)
            {
                return;
            }

            if (selectedMode >= 0)
            {
                editorModes[selectedMode].OnModeDisable();
            }

            selectedMode = newMode;
            editorModes[selectedMode].OnModeEnable();
        }

        public void SetMode<T>() where T : ILevelEditorMode
        {
            for (int i = 0; i < editorModes.Length; i++)
            {
                if (editorModes[i] is T)
                {
                    SetMode(i);
                    return;
                }
            }
            
#if !ALE_STRIP_SAFETY
            throw new ArgumentException($"There's no editor mode on {gameObject.name} with the type {typeof(T)}.");
#endif
        }

        public T GetMode<T>() where T : ILevelEditorMode
        {
            if (editorModes == null || editorModes.Length == 0)
            {
                return default;
            }

            for (int i = 0; i < editorModes.Length; i++)
            {
                if (editorModes[i] is T mode)
                {
                    return mode;
                }
            }
            
#if !ALE_STRIP_SAFETY
            throw new ArgumentException($"There's no editor mode on {gameObject.name} with the type {typeof(T)}.");
#else
            return default;
#endif
        }

        public bool TryGetEditorMode<T>(out T mode) where T : ILevelEditorMode
        {
            mode = default;
            if (editorModes == null || editorModes.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < editorModes.Length; i++)
            {
                if (editorModes[i] is T foundMode)
                {
                    mode = foundMode;
                    return true;
                }
            }

            return false;
        }

        public void NewLevel()
        {
            objectManagerComp.DeleteAllObjects();
            objectManagerComp.ResetInstanceID();
            isDirty = false;
            UI.InspectorPanel.BindObject(null);
        }

        public void MarkDirty()
        {
            isDirty = true;
        }

        public bool StartPlayMode(out string failReason)
        {
#if DEBUG
            if (playModeComp == null)
            {
                Debug.LogError("There's no play mode assigned on the level editor. Play mode can not be started. " +
                    "This will not be caught in release! Remove play mode functionality from your level editor.");
                failReason = "Play mode is not supported.";
                return false;
            }
#endif

            if (!playModeComp.CanStartPlayMode(out failReason))
            {
                return false;
            }

            playModeComp.StartPlayMode(this);
            return true;
        }

        public bool StopPlayMode(out string failReason)
        {
#if DEBUG
            if (playModeComp == null)
            {
                Debug.LogError("There's no play mode assigned on the level editor. Play mode can not be stopped. " +
                    "This will not be caught in release! Remove play mode functionality from your level editor.");
                failReason = "Play mode is not supported.";
                return false;
            }
#endif

            if (!playModeComp.CanStopPlayMode(out failReason))
            {
                return false;
            }

            playModeComp.StopPlayMode(this);
            return true;
        }

        private void OnCreateDeleteObject(object sender, LevelEditorObjectEvent args)
        {
            MarkDirty();
        }

        private void OnStartPlayMode()
        {
            uiComp.OnPlayModeStart();
            editorModes[selectedMode].OnModeDisable();
        }

        private void OnStopPlayMode()
        {
            uiComp.OnPlayModeStop();
            editorModes[selectedMode].OnModeEnable();
        }
    }
}
