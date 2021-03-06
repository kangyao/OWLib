// Instance generated by TankLibHelper.InstanceBuilder
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0x6F39A144, "STUUnlock_HeroMod")]
    public class STUUnlock_HeroMod : STUUnlock {
        [STUFieldAttribute(0xCA7E6EDC, "m_description")]
        public teStructuredDataAssetRef<ulong> m_description;

        [STUFieldAttribute(0x4D2DB658, "m_identifier")]
        public teStructuredDataAssetRef<STUIdentifier> m_identifier;

        [STUFieldAttribute(0xF24E4110, "m_slot")]
        public Enum_A7098AAD m_slot;
    }
}
