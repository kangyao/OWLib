// Instance generated by TankLibHelper.InstanceBuilder
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0x0C3A5D53)]
    public class STU_0C3A5D53 : STUStatescriptState {
        [STUFieldAttribute(0x4D2DB658, "m_identifier")]
        public teStructuredDataAssetRef<STUIdentifier> m_identifier;

        [STUFieldAttribute(0xFFA188A2, ReaderType = typeof(InlineInstanceFieldReader))]
        public STU_62562540[] m_FFA188A2;

        [STUFieldAttribute(0xE75EFAE8, ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STUConfigVar m_E75EFAE8;

        [STUFieldAttribute(0x4A8F7760)]
        public Enum_58748208 m_4A8F7760;
    }
}
