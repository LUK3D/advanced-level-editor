﻿using System.Collections.Generic;

namespace Hertzole.ALE
{
    public static class SerializationHelper
    {
        public static Dictionary<string, int> GetTypePalette(LevelEditorSaveData data)
        {
            if (data.objects == null && data.customData == null)
            {
                return new Dictionary<string, int>();
            }

            Dictionary<string, int> palette = new Dictionary<string, int>();
            int nextID = 0;
            if (data.objects != null)
            {
                for (int i = 0; i < data.objects.Count; i++)
                {
                    for (int j = 0; j < data.objects[i].components.Length; j++)
                    {
                        LevelEditorComponentData comp = data.objects[i].components[j];

                        if (!palette.ContainsKey(comp.type))
                        {
                            palette.Add(comp.type, nextID);
                            nextID++;
                        }

                        for (int k = 0; k < comp.properties.Length; k++)
                        {
                            LevelEditorPropertyData prop = comp.properties[k];
                            if (!palette.ContainsKey(prop.typeName))
                            {
                                palette.Add(prop.typeName, nextID);
                                nextID++;
                            }
                        }
                    }
                }
            }

            if (data.customData != null)
            {
                foreach (KeyValuePair<string, LevelEditorCustomData> customData in data.customData)
                {
                    if (!palette.ContainsKey(customData.Value.typeName))
                    {
                        palette.Add(customData.Value.typeName, nextID);
                        nextID++;
                    }
                }
            }

            return palette;
        }

        public static Dictionary<string, int> GetObjectPalette(LevelEditorSaveData data)
        {
            if (data.objects == null)
            {
                return new Dictionary<string, int>();
            }

            Dictionary<string, int> palette = new Dictionary<string, int>();
            int nextID = 0;
            for (int i = 0; i < data.objects.Count; i++)
            {
                if (!palette.ContainsKey(data.objects[i].id))
                {
                    palette.Add(data.objects[i].id, nextID);
                    nextID++;
                }
            }

            return palette;
        }
    }
}
