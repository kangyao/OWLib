// Instance generated by TankLibHelper.InstanceBuilder

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0xB6243CC3, "STUPublishEntry")]
    public class STUPublishEntry : STUInstance {
        [STUFieldAttribute(0x2F709539, "m_key")]
        public teStructuredDataAssetRef<STUIdentifier> m_key;

        [STUFieldAttribute(0x07DD813E, "m_value", ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STUConfigVar m_value;
    }
}
