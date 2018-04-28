// Instance generated by TankLibHelper.InstanceBuilder

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0x1C5DE3A3)]
    public class STU_1C5DE3A3 : STUInstance {
        [STUFieldAttribute(0xAC0061B5)]
        public teStructuredDataAssetRef<STUIdentifier> m_AC0061B5;

        [STUFieldAttribute(0x37AB13D3, "m_hero")]
        public teStructuredDataAssetRef<STUHero> m_hero;

        [STUFieldAttribute(0x948F409B)]
        public teStructuredDataAssetRef<STUEntityDefinition> m_948F409B;

        [STUFieldAttribute(0xC0A83121, "m_skin")]
        public teStructuredDataAssetRef<STUSkinTheme> m_skin;

        [STUFieldAttribute(0xB00E7BC2, ReaderType = typeof(InlineInstanceFieldReader))]
        public STUStatescriptGraphWithOverrides[] m_B00E7BC2;

        [STUFieldAttribute(0x3C2D37BD, ReaderType = typeof(InlineInstanceFieldReader))]
        public STUStatescriptGraphWithOverrides[] m_3C2D37BD;

        [STUFieldAttribute(0xDA5454CC)]
        public uint m_DA5454CC;

        [STUFieldAttribute(0x9AE2E3C5)]
        public float m_9AE2E3C5;
    }
}