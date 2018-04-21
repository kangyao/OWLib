// Instance generated by TankLibHelper.InstanceBuilder

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0x71B08A4C, "STULocalPersistedSettings")]
    public class STULocalPersistedSettings : STUInstance {
        [STUFieldAttribute(0x9F827CDD, "m_bindings", ReaderType = typeof(InlineInstanceFieldReader))]
        public STULocalPersistedBinding[] m_bindings;

        [STUFieldAttribute(0x27315EFA, "m_settings", ReaderType = typeof(InlineInstanceFieldReader))]
        public STULocalPersistedHeroSetting[] m_settings;

        [STUFieldAttribute(0xAB634626, "m_gameplaySettings", ReaderType = typeof(InlineInstanceFieldReader))]
        public STULocalPersistedGameplaySettings m_gameplaySettings;

        [STUFieldAttribute(0x464225DD, "m_voiceChatSettings", ReaderType = typeof(InlineInstanceFieldReader))]
        public STULocalPersistedVoiceChatSettings m_voiceChatSettings;
    }
}
