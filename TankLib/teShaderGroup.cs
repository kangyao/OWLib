﻿using System.IO;
using System.Runtime.InteropServices;

namespace TankLib {
    /// <summary>Tank ShaderGroup, file type 085</summary>
    public class teShaderGroup {
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct GroupHeader {
            /// <summary>ShaderInstance array offset</summary>
            public long InstanceOffset; // 0
            
            public long HashOffset; // 8
            public long FlagsOffset; // 16
            
            public long OffsetD; // 24
            public long OffsetE; // 32
            
            /// <summary>teShaderSource that this group was generated from</summary>
            /// <remarks>088 GUID</remarks>
            public teResourceGUID SourceGUID; // 40
            
            /// <summary>A virtual reference. Usage unknown</summary>
            /// <remarks>00F GUID</remarks>
            public teResourceGUID CacheGUID; // 48

            public uint Unknown; // 56
            public uint Flags; // 60
            
            /// <summary>Number of referenced shaders</summary>
            public int NumShaders;  // m_numShaders, 64

            public Enums.teSHADER_STATE ShaderStateFlags;
        }

        /// <summary>Header Data</summary>
        public GroupHeader Header;
        
        /// <summary>ShaderInstances</summary>
        public teResourceGUID[] Instances;

        public ulong[] InstanceFlags;

        public uint[] Hashes;

        public ShaderQuality[] ShaderQualities;
        public ShaderUnk[] ShaderUnks;
        
        /// <summary>
        /// Read ShaderGroup from a stream
        /// </summary>
        /// <param name="stream">The stream to load from</param>
        public teShaderGroup(Stream stream) {
            using (BinaryReader reader = new BinaryReader(stream)) {
                Read(reader);
            }
        }

        /// <summary>
        /// Read ShaderGroup from a BinaryReader
        /// </summary>
        /// <param name="reader">The reader to load from</param>
        public teShaderGroup(BinaryReader reader) {
            Read(reader);
        }

        private void Read(BinaryReader reader) {
            Header = reader.Read<GroupHeader>();
            
            if (Header.InstanceOffset > 0) {
                reader.BaseStream.Position = Header.InstanceOffset;
                Instances = reader.ReadArray<teResourceGUID>(Header.NumShaders);
            }

            if (Header.HashOffset > 0) {
                reader.BaseStream.Position = Header.HashOffset;
                Hashes = reader.ReadArray<uint>(Header.NumShaders);
            }

            if (Header.FlagsOffset > 0) {
                reader.BaseStream.Position = Header.FlagsOffset;
                InstanceFlags = reader.ReadArray<ulong>(Header.NumShaders);
            }

            {
                reader.BaseStream.Position = 72;
                ShaderQualities = reader.ReadArray<ShaderQuality>(5);

                reader.BaseStream.Position = 104;
                ShaderUnks = reader.ReadArray<ShaderUnk>(5);
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct ShaderQuality {
            public short VertexIndex;
            public short PixelIndex;

            public short UnkA;
            public short UnkB;
        }
        
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct ShaderUnk {
            public short Vertex;
            public short Pixel;

            public short UnkA;
            public short UnkB;
        }

        public teResourceGUID GetShaderByHash(uint hash) {
            if (Hashes == null) return (teResourceGUID) 0;
            for (int i = 0; i < Header.NumShaders; i++) {
                if (Hashes[i] == hash) {
                    return Instances[i];
                }
            }
            return (teResourceGUID) 0;
        }
    }
}