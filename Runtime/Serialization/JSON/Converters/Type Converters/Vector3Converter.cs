﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace Hertzole.ALE.Json
{
    public class Vector3Converter : JsonConverter<Vector3>
    {
        private const string PROP_X = "x";
        private const string PROP_Y = "y";
        private const string PROP_Z = "z";

        public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);

            float x = token.GetValue(PROP_X, 0f);
            float y = token.GetValue(PROP_Y, 0f);
            float z = token.GetValue(PROP_Z, 0f);

            return new Vector3(x, y, z);
        }

        public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(PROP_X);
            writer.WriteValue(value.x);
            writer.WritePropertyName(PROP_Y);
            writer.WriteValue(value.y);
            writer.WritePropertyName(PROP_Z);
            writer.WriteValue(value.z);

            writer.WriteEndObject();
        }
    }
}
