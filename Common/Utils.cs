using System;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace Trinitarian.Common
{
    public static class Utilty
    {
        public static Vector3 ScreenCoord(this Vector2 vector)
        {
            Vector2 screenCenter = new Vector2(Main.screenWidth / 2f, Main.screenHeight / 2f);
            Vector2 diff = vector - screenCenter;
            diff *= Main.GameZoomTarget;
            vector = screenCenter + diff;

            return new Vector3(-1 + vector.X / Main.screenWidth * 2, (-1 + vector.Y / Main.screenHeight * 2f) * -1, 0);
        }
        public static int AddItem(this Chest c, int ItemType, int stack = 1, bool overrideFirst = false)
        {
            for (int i = 0; i < c.item.Length; i++)
            {
                if (c.item[i].type == ItemID.None)
                {
                    Item t = new Item();
                    t.SetDefaults(ItemType);
                    c.item[i] = t;
                    c.item[i].stack = stack;
                    return i;
                }
            }
            if (overrideFirst)
            {
                Item t = new Item();
                t.SetDefaults(ItemType);
                c.item[0] = t;
                return 0;
            }
            return -1;
        }

        public static Vector2 GetInventoryPosition(Vector2 position, Rectangle frame, Vector2 origin, float scale)
        {
            return position + (((frame.Size() / 2f) - origin) * scale * Main.inventoryScale) + new Vector2(1.5f, 1.5f);
        }

        /*	WIP
		 *	public static void PlaceFrameImportatn(int Type,int i, int j)
			{
				Tile t = new Tile();
				t.type = (ushort)Type;

		}*/
    }
    public class PrimToDraw
    {
        public PrimitiveType type;
        internal List<VertexPositionColor> draws;
        public PrimToDraw(PrimitiveType t)
        {
            type = t;
            draws = new List<VertexPositionColor>();
        }
        public void Add(params VertexPositionColor[] additions)
        {
            for (int p = 0; p < additions.Length; p++)
            {
                var data = additions[p];
                data.Position.Z = 0;
                draws.Add(additions[p]);

            }
        }
    }
    /// <summary>
    /// Prims drawing and some related math
    /// </summary>
    public class Prims
    {
        public static PrimitiveType type;
        public static VertexPositionColor ToPrimitive(Vector2 worldPos, Color color)
        {
            Vector3 pos = (worldPos - Main.screenPosition).ScreenCoord();
            if (Main.LocalPlayer.gravDir == -1)
                pos.Y = -pos.Y;
            return new VertexPositionColor(pos, color);
        }

        internal static BasicEffect simpleVertexEffect;
        /// <summary>
        /// Draws one connected line with the postions in Pos
        /// </summary>
        /// <param name="Pos">Locations on the line, must be more then 2</param>
        /// <param name="Col">must match Pos' length, the colors of these vertices</param>
        public static void DrawLine(Vector2[] Pos, Color[] Col)
        {
            PrimToDraw p = new PrimToDraw(PrimitiveType.LineStrip);
            p.Add(ToPrimitive(Pos[0], Col[0]), ToPrimitive(Pos[1], Col[0]));
            for (int i = 2; i < Pos.Length; i++)
            {
                p.Add(ToPrimitive(Pos[i], Col[i]));
            }
            DrawPrim(p);
        }
        /// <summary>
        /// Draws one connected line with the postions in Pos
        /// </summary>
        /// <param name="Pos">Locations on the line, must be more then 2</param>
        /// <param name="Col">The color of the line</param>
        public static void DrawLine(Vector2[] Pos, Color Col)
        {
            PrimToDraw p = new PrimToDraw(PrimitiveType.LineStrip);
            p.Add(ToPrimitive(Pos[0], Col), ToPrimitive(Pos[1], Col));
            for (int i = 2; i < Pos.Length; i++)
            {
                p.Add(ToPrimitive(Pos[i], Col));
            }
            DrawPrim(p);
        }
        /// <summary>
        /// Draws Triangle(s) with the vertices pos, not connected.  
        /// </summary>
        /// <param name="Pos">Locations on the triangles, must be a mutple of 3</param>
        /// <param name="Col">The color of the triangles vertices</param>
        public static void DrawTriangleList(Vector2[] Pos, Color[] Col)
        {
            PrimToDraw p = new PrimToDraw(PrimitiveType.TriangleList);
            for (int i = 0; i < Pos.Length; i += 3)
            {
                p.Add(ToPrimitive(Pos[i], Col[i]), ToPrimitive(Pos[i + 1], Col[i + 1]), ToPrimitive(Pos[i + 2], Col[i + 2]));
            }
            DrawPrim(p);
        }
        /// <summary>
        /// Draws Triangle(s) with the vertices pos, not connected.  
        /// </summary>
        /// <param name="Pos">Locations on the triangles, must be a mutple of 3</param>
        /// <param name="Col">The color of the triangles</param>
        public static void DrawTriangleList(Vector2[] Pos, Color Col)
        {
            PrimToDraw p = new PrimToDraw(PrimitiveType.TriangleList);
            for (int i = 0; i < Pos.Length; i += 3)
            {
                p.Add(ToPrimitive(Pos[i], Col), ToPrimitive(Pos[i + 1], Col), ToPrimitive(Pos[i + 2], Col));
            }
            DrawPrim(p);
        }
        /// <summary>
        /// Draws connected triangles, with vertices Pos
        /// </summary>
        /// <param name="Pos">the vertices</param>
        /// <param name="Col">the colors</param>
        public static void DrawTriangleStrip(Vector2[] Pos, Color[] Col)
        {
            PrimToDraw p = new PrimToDraw(PrimitiveType.TriangleStrip);
            for (int i = 0; i < Pos.Length; i++)
            {
                p.Add(ToPrimitive(Pos[i], Col[i]));
            }
            DrawPrim(p);
        }
        /// <summary>
        /// Draws connected triangles, with vertices Pos
        /// </summary>
        /// <param name="Pos">the vertices</param>
        /// <param name="Col">the color</param>
        public static void DrawTriangleStrip(Vector2[] Pos, Color Col)
        {
            PrimToDraw p = new PrimToDraw(PrimitiveType.TriangleStrip);
            for (int i = 0; i < Pos.Length; i++)
            {
                p.Add(ToPrimitive(Pos[i], Col));
            }
            DrawPrim(p);
        }
        /// <summary>
        /// Draws a series of lines with every other vertice making a new one
        /// </summary>
        /// <param name="Pos">the postions, must be divisable by 2</param>
        /// <param name="Col">colors corsponding to the pos</param>
        public static void DrawLines(Vector2[] Pos, Color[] Col)
        {
            PrimToDraw p = new PrimToDraw(PrimitiveType.LineList);
            for (int i = 0; i < Pos.Length; i += 2)
                p.Add(ToPrimitive(Pos[i], Col[i]), ToPrimitive(Pos[i + 1], Col[i + 1]));
            DrawPrim(p);
        }
        /// <summary>
        /// Draws a series of lines with every other vertice making a new one
        /// </summary>
        /// <param name="Pos">the postions, must be divisable by 2</param>
        /// <param name="Col">colors  of the lines</param>
        public static void DrawLines(Vector2[] Pos, Color Col)
        {
            PrimToDraw p = new PrimToDraw(PrimitiveType.LineList);
            for (int i = 20; i < Pos.Length; i += 2)
                p.Add(ToPrimitive(Pos[i], Col), ToPrimitive(Pos[i + 1], Col));
            DrawPrim(p);
        }
        /// <summary>
        /// draws a rectangle with primatives
        /// </summary>
        /// <param name="TopLeft">the top left in world cords of the rectangle</param>
        /// <param name="BottomRight">the bottom right in world cords of the rectangle</param>
        /// <param name="colorTL">Color of the top left</param>
        /// <param name="colorTR">color of the top right</param>
        /// <param name="colorBL">color of bottom left</param>
        /// <param name="colorBR">color of BR</param>
        public static void DrawRectangle(Vector2 TopLeft, Vector2 BottomRight, Color colorTL, Color colorTR, Color colorBL, Color colorBR)
        {
            Vector2 TopRight = new Vector2(BottomRight.X, TopLeft.Y);
            Vector2 BottomLeft = new Vector2(TopLeft.X, BottomRight.Y);
            PrimToDraw p = new PrimToDraw(PrimitiveType.TriangleList);
            p.Add(ToPrimitive(BottomRight, colorTL), ToPrimitive(TopRight, colorTR), ToPrimitive(BottomLeft, colorBL));
            p.Add(ToPrimitive(BottomLeft, colorBL), ToPrimitive(TopRight, colorTR), ToPrimitive(TopLeft, colorBR));
            DrawPrim(p);
        }

        public static void Load()
        {
            simpleVertexEffect = new BasicEffect(Main.graphics.GraphicsDevice)
            {
                VertexColorEnabled = true
            };


        }
        /// <summary>
        /// Draws a polygon with the vertices
        /// must be non-complex, convex, and the points must be 
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="color">Colors, must be </param>
        public static void DrawPolygon(List<Vector2> vertices, Color[] color)
        {
            Main.NewText(color.Length);
            //Main.NewText(vertices.Count);
            List<Triangle> t = new List<Triangle>();

            for (int i = 2; i < vertices.Count; i++)
            {
                Vector2 a = vertices[0];
                Vector2 b = vertices[i - 1];
                Vector2 c = vertices[i];
                t.Add(new Triangle(a, b, c));
            }
            Main.NewText(t.Count * 3);
            DrawTriangles(t.ToArray(), color);
        }
        public static void DrawTriangles(Triangle[] t, Color[] c)
        {
            List<Vector2> p = new List<Vector2>();
            for (int i = 0; i < t.Length; i++)
            {
                Triangle Tri = t[i];
                p.Add(Tri.Vertices[0]);
                p.Add(Tri.Vertices[1]);
                p.Add(Tri.Vertices[2]);
            }
            DrawTriangleList(p.ToArray(), c);
        }
        static void DrawPrim(PrimToDraw packet)
        {
            int count = packet.draws.Count;

            switch (packet.type)
            {
                case PrimitiveType.LineList:
                    count = packet.draws.Count / 2;
                    break;
                case PrimitiveType.LineStrip:
                    count = packet.draws.Count - 1;
                    break;
                case PrimitiveType.TriangleList:
                    count = packet.draws.Count / 3;
                    break;
                case PrimitiveType.TriangleStrip:
                    count = packet.draws.Count - 2;
                    break;
            }
            if (count == 0)
            {
                ModContent.GetInstance<Trinitarian>().Logger.Info("a count of 0 prim was attempted to draw");
                return;
            }

            VertexBuffer buffer = new VertexBuffer(Main.graphics.GraphicsDevice, typeof(VertexPositionColor), packet.draws.Count, BufferUsage.WriteOnly);
            Main.graphics.GraphicsDevice.SetVertexBuffer(null);
            buffer.SetData(packet.draws.ToArray());
            Main.graphics.GraphicsDevice.SetVertexBuffer(buffer);
            simpleVertexEffect.CurrentTechnique.Passes[0].Apply();
            Main.graphics.GraphicsDevice.DrawPrimitives(packet.type, 0, count);
        }
    }
    public class Triangle
    {
        public Vector2[] Vertices;
        
        public Triangle(Vector2 a, Vector2 b, Vector2 c)
        {
            Vertices = new Vector2[3]
            {
                a,b,c
            };
            
        }
        public Triangle(Vector2[] v)
        {
            Vertices = new Vector2[3];
            if (v.Length != 3)
            {
                ModContent.GetInstance<Trinitarian>().Logger.Warn($"an attempt to make a triangle with {v.Length} happend");
                throw new Exception("Incorrect number of vertices of a triagle");
            }
           
        }
    }

}


