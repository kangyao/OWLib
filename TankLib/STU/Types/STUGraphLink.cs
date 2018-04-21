// Instance generated by TankLibHelper.InstanceBuilder
using TankLib.Math;

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0x6E63F8E1, "STUGraphLink")]
    public class STUGraphLink : STUInstance {
        [STUFieldAttribute(0xE3B4FA5C, "m_uniqueID")]
        public teUUID m_uniqueID;

        [STUFieldAttribute(0x498B0009, "m_outputPlug", ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STUGraphPlug m_outputPlug;

        [STUFieldAttribute(0xEA1269DF, "m_inputPlug", ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STUGraphPlug m_inputPlug;
    }
}
