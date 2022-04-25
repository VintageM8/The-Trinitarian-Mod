﻿using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Assets
{
    public sealed class TextureAsset : IDisposable
    {
        public Ref<Texture2D> Texture { get; private set; }
        public string ModPath { get; private set; }
        public string Path { get; private set; }

        public bool HasPath => Path != null;
        public bool IsDisposed => Texture == null;

        public TextureAsset(Ref<Texture2D> texture)
        {
            Texture = texture;
            Path = null;
            ModPath = null;
        }

        public TextureAsset(Texture2D texture)
        {
            Texture = new Ref<Texture2D>(texture);
            Path = null;
            ModPath = null;
        }

        public TextureAsset(string path)
        {
            ModPath = path;
            Path = path;
            Texture = new Ref<Texture2D>(ModContent.Request<Texture2D>(path));
        }

        public TextureAsset(Mod mod, string path)
        {
            ModPath = path;
            Path = mod.Name + "/" + path;
            Texture = new Ref<Texture2D>(mod.Assets.Request<Texture2D>(path).Value);
        }

        public static implicit operator string(TextureAsset asset)
        {
            return asset.Path;
        }

        public static implicit operator Texture2D(TextureAsset asset)
        {
            return asset.Texture.Value;
        }

        public static implicit operator Ref<Texture2D>(TextureAsset asset)
        {
            return asset.Texture;
        }

        public void Dispose()
        {
            ModPath = null;
            Path = null;
            Texture = null;
        }
    }
}

