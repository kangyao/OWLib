// Instance generated by TankLibHelper.InstanceBuilder

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0x106956CF)]
    public class STU_106956CF : STUInstance {
        [STUFieldAttribute(0x5DB91CE2, "m_displayName")]
        public teStructuredDataAssetRef<STUUXDisplayText> m_displayName;

        [STUFieldAttribute(0xC71EA6BC, "m_graph")]
        public teStructuredDataAssetRef<STU_6BE90C5C> m_graph;

        [STUFieldAttribute(0xBC2A8DA3, "m_params", ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STU_9F7A0E66[] m_params;
    }
}
