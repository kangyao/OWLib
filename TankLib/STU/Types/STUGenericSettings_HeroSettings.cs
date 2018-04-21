// Instance generated by TankLibHelper.InstanceBuilder

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0x6021C7EC, "STUGenericSettings_HeroSettings")]
    public class STUGenericSettings_HeroSettings : STUGenericSettings_Base {
        [STUFieldAttribute(0x2EB919C9, "m_categories", ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STUHeroSettingCategory[] m_categories;

        [STUFieldAttribute(0x142A3CA9, ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STUHeroSettingBase[] m_142A3CA9;

        [STUFieldAttribute(0xFC1FFB1E, "m_heroSpecificSettings", ReaderType = typeof(InlineInstanceFieldReader))]
        public STUHeroSpecificSettings[] m_heroSpecificSettings;
    }
}
